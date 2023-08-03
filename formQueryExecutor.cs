using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using Newtonsoft.Json;

namespace SF_Entity_Metadata
{
    public partial class formQueryExecutor : Form
    {
        public SFConfiguration sfConfigObject = null;
        public string strQuery = string.Empty;
        public string oAssertionToken = string.Empty;
        public formQueryExecutor()
        {
            InitializeComponent();
        }

        public formQueryExecutor(string sQuery, SFConfiguration sfConfigObject)
        {
            InitializeComponent();
            tbQuery.Text = this.strQuery = sQuery;
            this.sfConfigObject = sfConfigObject;
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                tbOutput.Text = ExecuteODataAPI(tbQuery.Text);
            }
            catch { }
            finally
            {
                Cursor= Cursors.Default;
            }
        }
        private void btnSaveOutput_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "JSON files (*.json)|*.json";
            saveFile.DefaultExt = "json";
            saveFile.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            saveFile.FileName = "odata_output";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                File.AppendAllText(saveFile.FileName, tbOutput.Text);
                MessageBox.Show("File :" + saveFile.FileName + " saved!", "Save Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public string ExecuteODataAPI(string odataurl)
        {
            string responseData = string.Empty;
            try
            {
                //try to get token again
                if (sfConfigObject.oAuthToken == null)
                {
                    GetOAuthToken();
                }
                //if (/* token refreshed, repeat the request using the new access token */)
                using (var client = new HttpClient())
                {
                    //TokenRoot deserializedToken = JsonConvert.DeserializeObject<TokenRoot>(oAuthToken);

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",sfConfigObject.oAuthToken.access_token);

                    //HttpResponseMessage result = client.GetAsync(EndPoint + parameters).Result;
                    //for queries returning large data set we need to provide timeouts
                    client.Timeout = TimeSpan.FromMinutes(30);
                    HttpResponseMessage result = client.GetAsync(odataurl, HttpCompletionOption.ResponseContentRead).Result;
                    if (result.StatusCode == HttpStatusCode.OK)
                    {
                        responseData = result.Content.ReadAsStringAsync().Result;
                        //StreamWriter file = null;
                        //file = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "maxeon_empjob.json", append: true, Encoding.UTF8);
                        //file.WriteLine(responseData);
                        //file.Close();
                    }
                    else //if (result.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        // Process the error
                        responseData = "ErrorStatusCode: " + result.StatusCode + " | " + "Error Message: " + result.Content.ReadAsStringAsync();
                    }
                    result.Dispose();
                }
            }
            catch //(Exception ex)
            {
                //throw ex;
            }
            return responseData;
        }

        public bool GetAssertionToken()
        {
            bool breturn = false;
            try
            {
                sfConfigObject.oAuthAssertionToken = "";

                using (var client = new HttpClient())
                {
                    var postData = new List<KeyValuePair<string, string>>();

                    postData.Add(new KeyValuePair<string, string>("client_id", sfConfigObject.clientid));
                    postData.Add(new KeyValuePair<string, string>("user_id", sfConfigObject.userid));
                    postData.Add(new KeyValuePair<string, string>("token_url", sfConfigObject.tokenurl));
                    postData.Add(new KeyValuePair<string, string>("private_key", sfConfigObject.clientsecret));

                    HttpContent content = new FormUrlEncodedContent(postData);
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");

                    var responseResult = client.PostAsync(sfConfigObject.assertionurl, content).Result;

                    sfConfigObject.oAuthAssertionToken = responseResult.Content.ReadAsStringAsync().Result;

                    responseResult.Dispose();

                    breturn = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Assertion Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sfConfigObject.oAuthAssertionToken = null;
                breturn = false;
            }
            return breturn;
        }

        public bool GetOAuthToken()
        {
            bool breturn = false;
            try
            {
                GetAssertionToken();
                using (var client = new HttpClient())
                {
                    if (string.IsNullOrEmpty(sfConfigObject.oAuthAssertionToken) == false)
                    {
                        var postData = new List<KeyValuePair<string, string>>();

                        postData.Add(new KeyValuePair<string, string>("client_id", sfConfigObject.clientid));
                        postData.Add(new KeyValuePair<string, string>("grant_type", sfConfigObject.granttype));
                        postData.Add(new KeyValuePair<string, string>("company_id", sfConfigObject.companyid));

                        //postData.Add(new KeyValuePair<string, string>("assertion", assertiondata));
                        postData.Add(new KeyValuePair<string, string>("assertion", sfConfigObject.oAuthAssertionToken));

                        //postData.Add(new KeyValuePair<string, string>("client_secret", oAuthClientSecret));

                        HttpContent content = new FormUrlEncodedContent(postData);
                        content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");

                        var responseResult = client.PostAsync(sfConfigObject.tokenurl, content).Result;
                        if (responseResult.StatusCode == HttpStatusCode.OK)
                        {
                            sfConfigObject.oAuthToken = new TokenRoot();
                            sfConfigObject.oAuthToken = JsonConvert.DeserializeObject<TokenRoot>(responseResult.Content.ReadAsStringAsync().Result);
                            breturn = true;
                            responseResult.Dispose();
                        }
                        else
                        {
                            string exMessage = "ErrorStatusCode: " + responseResult.StatusCode + " | " + "Error Message: " + responseResult.Content.ReadAsStringAsync();
                            responseResult.Dispose();
                            throw new Exception(exMessage);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "oAuth Token Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sfConfigObject.oAuthToken = null;
                breturn = false;
            }
            return breturn;
        }
    }
}
