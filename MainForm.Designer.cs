namespace SF_Entity_Metadata
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.tbCompanyId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbUserId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbClientId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbGrantType = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbClientSecret = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbAssertionUrl = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbTokenURL = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbAPIURL = new System.Windows.Forms.TextBox();
            this.btnGetMetadata = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.tbMetadatUrl = new System.Windows.Forms.TextBox();
            this.btnLoadMetadata = new System.Windows.Forms.Button();
            this.btnLoadConfig = new System.Windows.Forms.Button();
            this.btnSaveConfig = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Company ID:";
            // 
            // tbCompanyId
            // 
            this.tbCompanyId.Location = new System.Drawing.Point(123, 13);
            this.tbCompanyId.Name = "tbCompanyId";
            this.tbCompanyId.Size = new System.Drawing.Size(100, 26);
            this.tbCompanyId.TabIndex = 1;
            this.tbCompanyId.Text = "iochpemaxi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(242, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "User ID:";
            // 
            // tbUserId
            // 
            this.tbUserId.Location = new System.Drawing.Point(310, 13);
            this.tbUserId.Name = "tbUserId";
            this.tbUserId.Size = new System.Drawing.Size(100, 26);
            this.tbUserId.TabIndex = 3;
            this.tbUserId.Text = "onama_ad";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Client ID:";
            // 
            // tbClientId
            // 
            this.tbClientId.Location = new System.Drawing.Point(123, 43);
            this.tbClientId.Name = "tbClientId";
            this.tbClientId.Size = new System.Drawing.Size(361, 26);
            this.tbClientId.TabIndex = 5;
            this.tbClientId.Text = "MGI5NWFkMzUwNjIwYzlmMTM3ZTVjNGY0YzI2Zg";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Grant Type:";
            // 
            // tbGrantType
            // 
            this.tbGrantType.Location = new System.Drawing.Point(123, 74);
            this.tbGrantType.Name = "tbGrantType";
            this.tbGrantType.Size = new System.Drawing.Size(318, 26);
            this.tbGrantType.TabIndex = 7;
            this.tbGrantType.Text = "urn:ietf:params:oauth:grant-type:saml2-bearer";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(428, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Client Secret:";
            // 
            // tbClientSecret
            // 
            this.tbClientSecret.Location = new System.Drawing.Point(532, 10);
            this.tbClientSecret.Multiline = true;
            this.tbClientSecret.Name = "tbClientSecret";
            this.tbClientSecret.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbClientSecret.Size = new System.Drawing.Size(668, 89);
            this.tbClientSecret.TabIndex = 9;
            this.tbClientSecret.Text = resources.GetString("tbClientSecret.Text");
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 107);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "Assertion URL:";
            // 
            // tbAssertionUrl
            // 
            this.tbAssertionUrl.Location = new System.Drawing.Point(123, 105);
            this.tbAssertionUrl.Name = "tbAssertionUrl";
            this.tbAssertionUrl.Size = new System.Drawing.Size(237, 26);
            this.tbAssertionUrl.TabIndex = 11;
            this.tbAssertionUrl.Text = "https://api19.sapsf.com/oauth/idp";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(438, 107);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 20);
            this.label7.TabIndex = 12;
            this.label7.Text = "Token URL:";
            // 
            // tbTokenURL
            // 
            this.tbTokenURL.Location = new System.Drawing.Point(532, 107);
            this.tbTokenURL.Name = "tbTokenURL";
            this.tbTokenURL.Size = new System.Drawing.Size(254, 26);
            this.tbTokenURL.TabIndex = 13;
            this.tbTokenURL.Text = "https://api19.sapsf.com/oauth/token";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(808, 107);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 20);
            this.label8.TabIndex = 14;
            this.label8.Text = "API URL:";
            // 
            // tbAPIURL
            // 
            this.tbAPIURL.Location = new System.Drawing.Point(922, 107);
            this.tbAPIURL.Name = "tbAPIURL";
            this.tbAPIURL.Size = new System.Drawing.Size(236, 26);
            this.tbAPIURL.TabIndex = 15;
            this.tbAPIURL.Text = "https://api19.sapsf.com/odata/v2/";
            // 
            // btnGetMetadata
            // 
            this.btnGetMetadata.Location = new System.Drawing.Point(652, 138);
            this.btnGetMetadata.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnGetMetadata.Name = "btnGetMetadata";
            this.btnGetMetadata.Size = new System.Drawing.Size(106, 31);
            this.btnGetMetadata.TabIndex = 16;
            this.btnGetMetadata.Text = "Get Metadata";
            this.btnGetMetadata.UseVisualStyleBackColor = true;
            this.btnGetMetadata.Click += new System.EventHandler(this.btnGetMetadata_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(418, 141);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(118, 20);
            this.label10.TabIndex = 19;
            this.label10.Text = "Metadata URL:";
            // 
            // tbMetadatUrl
            // 
            this.tbMetadatUrl.Location = new System.Drawing.Point(532, 141);
            this.tbMetadatUrl.Name = "tbMetadatUrl";
            this.tbMetadatUrl.Size = new System.Drawing.Size(98, 26);
            this.tbMetadatUrl.TabIndex = 20;
            this.tbMetadatUrl.Text = "$metadata";
            // 
            // btnLoadMetadata
            // 
            this.btnLoadMetadata.Location = new System.Drawing.Point(768, 138);
            this.btnLoadMetadata.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLoadMetadata.Name = "btnLoadMetadata";
            this.btnLoadMetadata.Size = new System.Drawing.Size(132, 31);
            this.btnLoadMetadata.TabIndex = 21;
            this.btnLoadMetadata.Text = "Load Metadata";
            this.btnLoadMetadata.UseVisualStyleBackColor = true;
            this.btnLoadMetadata.Click += new System.EventHandler(this.btnLoadMetadata_Click);
            // 
            // btnLoadConfig
            // 
            this.btnLoadConfig.Location = new System.Drawing.Point(14, 138);
            this.btnLoadConfig.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLoadConfig.Name = "btnLoadConfig";
            this.btnLoadConfig.Size = new System.Drawing.Size(145, 31);
            this.btnLoadConfig.TabIndex = 22;
            this.btnLoadConfig.Text = "Load Configuration";
            this.btnLoadConfig.UseVisualStyleBackColor = true;
            this.btnLoadConfig.Click += new System.EventHandler(this.btnLoadConfig_Click);
            // 
            // btnSaveConfig
            // 
            this.btnSaveConfig.Location = new System.Drawing.Point(163, 138);
            this.btnSaveConfig.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSaveConfig.Name = "btnSaveConfig";
            this.btnSaveConfig.Size = new System.Drawing.Size(145, 31);
            this.btnSaveConfig.TabIndex = 23;
            this.btnSaveConfig.Text = "Save Configuration";
            this.btnSaveConfig.UseVisualStyleBackColor = true;
            this.btnSaveConfig.Click += new System.EventHandler(this.btnSaveConfig_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1208, 202);
            this.Controls.Add(this.btnSaveConfig);
            this.Controls.Add(this.btnLoadConfig);
            this.Controls.Add(this.btnLoadMetadata);
            this.Controls.Add(this.tbMetadatUrl);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnGetMetadata);
            this.Controls.Add(this.tbAPIURL);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbTokenURL);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbAssertionUrl);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbClientSecret);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbGrantType);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbClientId);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbUserId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbCompanyId);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MainForm";
            this.Text = "SF Entity Metadata Explorer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbCompanyId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbUserId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbClientId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbGrantType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbClientSecret;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbAssertionUrl;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbTokenURL;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbAPIURL;
        private System.Windows.Forms.Button btnGetMetadata;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbMetadatUrl;
        private System.Windows.Forms.Button btnLoadMetadata;
        private System.Windows.Forms.Button btnLoadConfig;
        private System.Windows.Forms.Button btnSaveConfig;
    }
}

