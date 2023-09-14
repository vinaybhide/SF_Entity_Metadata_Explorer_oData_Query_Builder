using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Linq.Expressions;

namespace SF_Entity_Metadata
{
    public partial class MainForm : Form
    {
        public SFConfiguration sfConfigObject = null;

        public string xmlEntityMetadata { get; set; }

        public MainForm()
        {
            InitializeComponent();

            sfConfigObject = new SFConfiguration();
            sfConfigObject.companyid = tbCompanyId.Text;
            sfConfigObject.userid = tbUserId.Text;
            sfConfigObject.clientid = tbClientId.Text;
            sfConfigObject.granttype = tbGrantType.Text;
            sfConfigObject.clientsecret = tbClientSecret.Text;
            sfConfigObject.assertionurl = tbAssertionUrl.Text;
            sfConfigObject.tokenurl = tbTokenURL.Text;
            sfConfigObject.apiurl = tbAPIURL.Text;
            sfConfigObject.metadataurl = tbMetadatUrl.Text;
        }

        /// <summary>
        // XDocument po = XDocument.Load("PurchaseOrders.xml");

        /// LINQ to XML query
        //IEnumerable<XElement> list1 =
        //from el in po.Descendants("Address")
        //where (string)el.Attribute("Type") == "Shipping"
        //select el;
        //// XPath expression
        //IEnumerable<XElement> list2 = po.XPathSelectElements(".//Address[@Type='Shipping']");
        //if (list1.Count() == list2.Count() &&
        //        list1.Intersect(list2).Count() == list1.Count())
        //    Console.WriteLine("Results are identical");
        //else
        //    Console.WriteLine("Results differ");
        //foreach (XElement el in list1)
        //    Console.WriteLine(el);
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetMetadata_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (GetOAuthToken())
                {
                    xmlEntityMetadata = GetMetadata(tbMetadatUrl.Text);
                    Cursor = Cursors.Default;
                    if (string.IsNullOrEmpty(xmlEntityMetadata) == false)
                    {
                        if (MessageBox.Show("Do you want to save metadata to a file?", "Save Metadata", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            SaveFileDialog saveFile = new SaveFileDialog();
                            saveFile.Filter = "XML files (*.xml)|*.xml";
                            saveFile.DefaultExt = "xml";

                            saveFile.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
                            saveFile.FileName = "SF_Metadata";
                            if (saveFile.ShowDialog() == DialogResult.OK)
                            {
                                File.WriteAllText(saveFile.FileName, xmlEntityMetadata);
                            }
                        }
                        formEntityView dlgEntityView = new formEntityView(xmlEntityMetadata, sfConfigObject);
                        dlgEntityView.ShowDialog();
                    }
                }
            }
            catch
            { }
            finally { Cursor = Cursors.Default; }
        }
        private void btnLoadMetadata_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XML files (*.xml)|*.xml";
            openFileDialog.DefaultExt = "xml";
            openFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Cursor = Cursors.WaitCursor;
                xmlEntityMetadata = File.ReadAllText(openFileDialog.FileName);
                formEntityView dlgEntityView = new formEntityView(xmlEntityMetadata, sfConfigObject);
                Cursor = Cursors.Default;
                dlgEntityView.ShowDialog();
            }
        }

        /// <summary>
        /// Open selected configuration file and loads all config data into respective variables
        /// Format of xml
        /// <root>
        /// <companyid></companyid>
        /// <userid></userid>
        /// <clientid></clientid>
        /// <assertionurl></assertionurl>
        /// <tokenurl></tokenurl>
        /// <granttype></granttype>
        /// <clientsecret></clientsecret>
        /// <apiurl></apiurl>
        /// </root>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoadConfig_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XML files (*.xml)|*.xml";
            openFileDialog.DefaultExt = "xml";
            openFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(openFileDialog.FileName);
                XmlNode root = doc.DocumentElement;
                if ((root != null) && (root.HasChildNodes))
                {
                    tbCompanyId.Text = ""; tbUserId.Text = ""; tbClientId.Text = ""; tbClientSecret.Text = "";
                    tbAPIURL.Text = ""; tbAssertionUrl.Text = ""; tbGrantType.Text = ""; tbTokenURL.Text = "";
                    tbMetadatUrl.Text = "";

                    foreach (XmlNode node in root.ChildNodes)
                    {
                        if (node.Name == "companyid")
                        {
                            tbCompanyId.Text = node.InnerText;
                        }
                        else if (node.Name == "userid")
                        {
                            tbUserId.Text = node.InnerText;
                        }
                        else if (node.Name == "clientid")
                        {
                            tbClientId.Text = node.InnerText;
                        }
                        else if (node.Name == "assertionurl")
                        {
                            tbAssertionUrl.Text = node.InnerText;
                        }
                        else if (node.Name == "tokenurl")
                        {
                            tbTokenURL.Text = node.InnerText;
                        }
                        else if (node.Name == "granttype")
                        {
                            tbGrantType.Text = node.InnerText;
                        }
                        else if (node.Name == "clientsecret")
                        {
                            tbClientSecret.Text = node.InnerText;
                        }
                        else if (node.Name == "apiurl")
                        {
                            tbAPIURL.Text = node.InnerText;
                        }
                        else if (node.Name == "metadataurl")
                        {
                            tbMetadatUrl.Text = node.InnerText;
                        }

                    }

                    if (string.IsNullOrEmpty(tbCompanyId.Text) || string.IsNullOrEmpty(tbUserId.Text) ||
                        string.IsNullOrEmpty(tbClientId.Text) || string.IsNullOrEmpty(tbClientSecret.Text) ||
                        string.IsNullOrEmpty(tbAPIURL.Text) || string.IsNullOrEmpty(tbAssertionUrl.Text) ||
                        string.IsNullOrEmpty(tbGrantType.Text) || string.IsNullOrEmpty(tbTokenURL.Text) ||
                        string.IsNullOrEmpty(tbMetadatUrl.Text))
                    {
                        MessageBox.Show("Not all configuration parameters loaded. Operation can not continue",
                            "Error - Load Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tbCompanyId.Text = ""; tbUserId.Text = ""; tbClientId.Text = ""; tbClientSecret.Text = "";
                        tbAPIURL.Text = ""; tbAssertionUrl.Text = ""; tbGrantType.Text = ""; tbTokenURL.Text = "";
                        tbMetadatUrl.Text = "";

                        sfConfigObject.companyid = "";
                        sfConfigObject.userid = "";
                        sfConfigObject.clientid = "";
                        sfConfigObject.granttype = "";
                        sfConfigObject.clientsecret = "";
                        sfConfigObject.assertionurl = "";
                        sfConfigObject.tokenurl = "";
                        sfConfigObject.apiurl = "";
                        sfConfigObject.metadataurl = "";
                    }
                    else
                    {
                        sfConfigObject.companyid = tbCompanyId.Text;
                        sfConfigObject.userid = tbUserId.Text;
                        sfConfigObject.clientid = tbClientId.Text;
                        sfConfigObject.granttype = tbGrantType.Text;
                        sfConfigObject.clientsecret = tbClientSecret.Text;
                        sfConfigObject.assertionurl = tbAssertionUrl.Text;
                        sfConfigObject.tokenurl = tbTokenURL.Text;
                        sfConfigObject.apiurl = tbAPIURL.Text;
                        sfConfigObject.metadataurl = tbMetadatUrl.Text;
                    }
                    sfConfigObject.oAuthAssertionToken = "";
                    sfConfigObject.oAuthToken = null;
                }
            }
        }
        private void btnSaveConfig_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            XmlElement rootElement = doc.CreateElement("root");
            XmlElement nodeToAdd = doc.CreateElement("companyid");
            nodeToAdd.InnerText = tbCompanyId.Text;
            rootElement.AppendChild(nodeToAdd);
            nodeToAdd = doc.CreateElement("userid");
            nodeToAdd.InnerText = tbUserId.Text;
            rootElement.AppendChild(nodeToAdd);
            nodeToAdd = doc.CreateElement("clientid");
            nodeToAdd.InnerText = tbClientId.Text;
            rootElement.AppendChild(nodeToAdd);
            nodeToAdd = doc.CreateElement("clientsecret");
            nodeToAdd.InnerText = tbClientSecret.Text;
            rootElement.AppendChild(nodeToAdd);
            nodeToAdd = doc.CreateElement("apiurl");
            nodeToAdd.InnerText = tbAPIURL.Text;
            rootElement.AppendChild(nodeToAdd);
            nodeToAdd = doc.CreateElement("assertionurl");
            nodeToAdd.InnerText = tbAssertionUrl.Text;
            rootElement.AppendChild(nodeToAdd);
            nodeToAdd = doc.CreateElement("granttype");
            nodeToAdd.InnerText = tbGrantType.Text;
            rootElement.AppendChild(nodeToAdd);
            nodeToAdd = doc.CreateElement("tokenurl");
            nodeToAdd.InnerText = tbTokenURL.Text;
            rootElement.AppendChild(nodeToAdd);
            nodeToAdd = doc.CreateElement("metadataurl");
            nodeToAdd.InnerText = tbMetadatUrl.Text;
            rootElement.AppendChild(nodeToAdd);
            doc.AppendChild(rootElement);

            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "XML files (*.xml)|*.xml";
            saveFile.DefaultExt = "xml";

            saveFile.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            saveFile.FileName = "SF_Metadata_Config";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                doc.Save(saveFile.FileName);
                MessageBox.Show("File :" + saveFile.FileName + " saved!", "Save Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);

                sfConfigObject.companyid = tbCompanyId.Text;
                sfConfigObject.userid = tbUserId.Text;
                sfConfigObject.clientid = tbClientId.Text;
                sfConfigObject.granttype = tbGrantType.Text;
                sfConfigObject.clientsecret = tbClientSecret.Text;
                sfConfigObject.assertionurl = tbAssertionUrl.Text;
                sfConfigObject.tokenurl = tbTokenURL.Text;
                sfConfigObject.apiurl = tbAPIURL.Text;
                sfConfigObject.metadataurl = tbMetadatUrl.Text;
            }
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

                    postData.Add(new KeyValuePair<string, string>("client_id", tbClientId.Text));
                    postData.Add(new KeyValuePair<string, string>("user_id", tbUserId.Text));
                    postData.Add(new KeyValuePair<string, string>("token_url", tbTokenURL.Text));
                    postData.Add(new KeyValuePair<string, string>("private_key", tbClientSecret.Text));

                    HttpContent content = new FormUrlEncodedContent(postData);
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");

                    var responseResult = client.PostAsync(tbAssertionUrl.Text, content).Result;

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

                        postData.Add(new KeyValuePair<string, string>("client_id", tbClientId.Text));
                        postData.Add(new KeyValuePair<string, string>("grant_type", tbGrantType.Text));
                        postData.Add(new KeyValuePair<string, string>("company_id", tbCompanyId.Text));

                        //postData.Add(new KeyValuePair<string, string>("assertion", assertiondata));
                        postData.Add(new KeyValuePair<string, string>("assertion", sfConfigObject.oAuthAssertionToken));

                        //postData.Add(new KeyValuePair<string, string>("client_secret", oAuthClientSecret));

                        HttpContent content = new FormUrlEncodedContent(postData);
                        content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");

                        var responseResult = client.PostAsync(tbTokenURL.Text, content).Result;
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

        public string GetMetadata(string parameters)
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

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sfConfigObject.oAuthToken.access_token);

                    //HttpResponseMessage result = client.GetAsync(EndPoint + parameters).Result;
                    //for queries returning large data set we need to provide timeouts
                    client.Timeout = TimeSpan.FromMinutes(30);
                    HttpResponseMessage result = client.GetAsync(tbAPIURL.Text + parameters, HttpCompletionOption.ResponseContentRead).Result;
                    //string tempurl = "EmpJob?$filter=userId eq '100'&$format=json";//"Entity('EmpJob')?$format=JSON";//"$metadata";
                    //HttpResponseMessage result = client.GetAsync(oAuthAPIUrl + tempurl, HttpCompletionOption.ResponseContentRead).Result;
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
                    if (string.IsNullOrEmpty(responseData) == false)
                    {
                        //we received data or error
                        if ((responseData.StartsWith("Exception:") == true) || (responseData.StartsWith("ErrorStatusCode:") == true))
                        {
                            throw new Exception(responseData);
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
            return responseData;
        }

    }

    public class TokenRoot
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
    }

    public class SFConfiguration
    {
        public string companyid { get; set; } = string.Empty;
        public string userid { get; set; } = string.Empty;
        public string clientid { get; set; } = string.Empty;
        public string granttype { get; set; } = string.Empty;
        public string clientsecret { get; set; } = string.Empty;
        public string assertionurl { get; set; } = string.Empty;
        public string tokenurl { get; set; } = string.Empty;
        public string apiurl { get; set; } = string.Empty;
        public string metadataurl { get; set; } = string.Empty;
        public string oAuthAssertionToken { get; set; } = string.Empty;
        public TokenRoot oAuthToken { get; set; } = null;
    }
}
