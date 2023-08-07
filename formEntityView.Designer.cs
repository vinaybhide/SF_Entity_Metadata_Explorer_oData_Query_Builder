namespace SF_Entity_Metadata
{
    partial class formEntityView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvEntitySetList = new System.Windows.Forms.DataGridView();
            this.dgvKey = new System.Windows.Forms.DataGridView();
            this.dgvProperty = new System.Windows.Forms.DataGridView();
            this.dgvNavigation = new System.Windows.Forms.DataGridView();
            this.tbSearchEntity = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvEntityTags = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnSearchEntity = new System.Windows.Forms.Button();
            this.cmbColNames = new System.Windows.Forms.ComboBox();
            this.grpB1 = new System.Windows.Forms.GroupBox();
            this.btnSearchPropColumn = new System.Windows.Forms.Button();
            this.tbPropSearch = new System.Windows.Forms.TextBox();
            this.cmbPropColumn = new System.Windows.Forms.ComboBox();
            this.btnBuildQuery = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnExecute = new System.Windows.Forms.Button();
            this.tbQuery = new System.Windows.Forms.TextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEntitySetList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKey)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProperty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNavigation)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEntityTags)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.grpB1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvEntitySetList
            // 
            this.dgvEntitySetList.AllowUserToAddRows = false;
            this.dgvEntitySetList.AllowUserToDeleteRows = false;
            this.dgvEntitySetList.AllowUserToOrderColumns = true;
            this.dgvEntitySetList.AllowUserToResizeRows = false;
            this.dgvEntitySetList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEntitySetList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEntitySetList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvEntitySetList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEntitySetList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvEntitySetList.EnableHeadersVisualStyles = false;
            this.dgvEntitySetList.Location = new System.Drawing.Point(5, 33);
            this.dgvEntitySetList.Margin = new System.Windows.Forms.Padding(2);
            this.dgvEntitySetList.MultiSelect = false;
            this.dgvEntitySetList.Name = "dgvEntitySetList";
            this.dgvEntitySetList.RowHeadersVisible = false;
            this.dgvEntitySetList.RowHeadersWidth = 62;
            this.dgvEntitySetList.RowTemplate.Height = 28;
            this.dgvEntitySetList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEntitySetList.Size = new System.Drawing.Size(1362, 157);
            this.dgvEntitySetList.TabIndex = 22;
            this.dgvEntitySetList.SelectionChanged += new System.EventHandler(this.dgvEntitySetList_SelectionChanged);
            // 
            // dgvKey
            // 
            this.dgvKey.AllowUserToAddRows = false;
            this.dgvKey.AllowUserToDeleteRows = false;
            this.dgvKey.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvKey.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvKey.ColumnHeadersHeight = 34;
            this.dgvKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKey.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvKey.EnableHeadersVisualStyles = false;
            this.dgvKey.Location = new System.Drawing.Point(3, 25);
            this.dgvKey.Margin = new System.Windows.Forms.Padding(2);
            this.dgvKey.Name = "dgvKey";
            this.dgvKey.RowHeadersVisible = false;
            this.dgvKey.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvKey.RowTemplate.Height = 28;
            this.dgvKey.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKey.Size = new System.Drawing.Size(711, 142);
            this.dgvKey.TabIndex = 24;
            this.dgvKey.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKey_CellContentClick_1);
            this.dgvKey.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKey_CellValueChanged);
            // 
            // dgvProperty
            // 
            this.dgvProperty.AllowUserToAddRows = false;
            this.dgvProperty.AllowUserToDeleteRows = false;
            this.dgvProperty.AllowUserToResizeRows = false;
            this.dgvProperty.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProperty.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProperty.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvProperty.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProperty.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvProperty.EnableHeadersVisualStyles = false;
            this.dgvProperty.Location = new System.Drawing.Point(6, 33);
            this.dgvProperty.Margin = new System.Windows.Forms.Padding(2);
            this.dgvProperty.Name = "dgvProperty";
            this.dgvProperty.RowHeadersVisible = false;
            this.dgvProperty.RowHeadersWidth = 62;
            this.dgvProperty.RowTemplate.Height = 28;
            this.dgvProperty.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProperty.Size = new System.Drawing.Size(664, 141);
            this.dgvProperty.TabIndex = 25;
            // 
            // dgvNavigation
            // 
            this.dgvNavigation.AllowUserToAddRows = false;
            this.dgvNavigation.AllowUserToDeleteRows = false;
            this.dgvNavigation.AllowUserToResizeRows = false;
            this.dgvNavigation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvNavigation.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNavigation.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvNavigation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNavigation.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvNavigation.EnableHeadersVisualStyles = false;
            this.dgvNavigation.Location = new System.Drawing.Point(5, 33);
            this.dgvNavigation.Margin = new System.Windows.Forms.Padding(2);
            this.dgvNavigation.Name = "dgvNavigation";
            this.dgvNavigation.RowHeadersVisible = false;
            this.dgvNavigation.RowHeadersWidth = 62;
            this.dgvNavigation.RowTemplate.Height = 28;
            this.dgvNavigation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNavigation.Size = new System.Drawing.Size(664, 141);
            this.dgvNavigation.TabIndex = 26;
            // 
            // tbSearchEntity
            // 
            this.tbSearchEntity.Location = new System.Drawing.Point(256, 29);
            this.tbSearchEntity.Margin = new System.Windows.Forms.Padding(2);
            this.tbSearchEntity.Name = "tbSearchEntity";
            this.tbSearchEntity.Size = new System.Drawing.Size(255, 28);
            this.tbSearchEntity.TabIndex = 28;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.dgvEntitySetList);
            this.groupBox1.Location = new System.Drawing.Point(8, 105);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(1372, 196);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Entity Collection";
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox2.Controls.Add(this.dgvEntityTags);
            this.groupBox2.Location = new System.Drawing.Point(8, 306);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(648, 171);
            this.groupBox2.TabIndex = 32;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tag Collection";
            // 
            // dgvEntityTags
            // 
            this.dgvEntityTags.AllowUserToAddRows = false;
            this.dgvEntityTags.AllowUserToDeleteRows = false;
            this.dgvEntityTags.AllowUserToResizeRows = false;
            this.dgvEntityTags.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEntityTags.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEntityTags.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvEntityTags.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEntityTags.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvEntityTags.EnableHeadersVisualStyles = false;
            this.dgvEntityTags.Location = new System.Drawing.Point(5, 33);
            this.dgvEntityTags.Margin = new System.Windows.Forms.Padding(2);
            this.dgvEntityTags.MultiSelect = false;
            this.dgvEntityTags.Name = "dgvEntityTags";
            this.dgvEntityTags.RowHeadersVisible = false;
            this.dgvEntityTags.RowHeadersWidth = 62;
            this.dgvEntityTags.RowTemplate.Height = 28;
            this.dgvEntityTags.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEntityTags.Size = new System.Drawing.Size(638, 125);
            this.dgvEntityTags.TabIndex = 23;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox3.Controls.Add(this.dgvKey);
            this.groupBox3.Location = new System.Drawing.Point(663, 306);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Size = new System.Drawing.Size(717, 171);
            this.groupBox3.TabIndex = 33;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Entity Key Properties";
            // 
            // groupBox4
            // 
            this.groupBox4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox4.Controls.Add(this.dgvProperty);
            this.groupBox4.Location = new System.Drawing.Point(7, 481);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox4.Size = new System.Drawing.Size(679, 201);
            this.groupBox4.TabIndex = 32;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Entity Properties";
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox5.Controls.Add(this.dgvNavigation);
            this.groupBox5.Location = new System.Drawing.Point(692, 481);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox5.Size = new System.Drawing.Size(679, 201);
            this.groupBox5.TabIndex = 32;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Entity Navigation Properties";
            // 
            // btnSearchEntity
            // 
            this.btnSearchEntity.Location = new System.Drawing.Point(538, 24);
            this.btnSearchEntity.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearchEntity.Name = "btnSearchEntity";
            this.btnSearchEntity.Size = new System.Drawing.Size(82, 38);
            this.btnSearchEntity.TabIndex = 29;
            this.btnSearchEntity.Text = "Search";
            this.btnSearchEntity.UseVisualStyleBackColor = true;
            this.btnSearchEntity.Click += new System.EventHandler(this.btnSearchEntity_Click);
            // 
            // cmbColNames
            // 
            this.cmbColNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbColNames.FormattingEnabled = true;
            this.cmbColNames.Location = new System.Drawing.Point(31, 28);
            this.cmbColNames.Margin = new System.Windows.Forms.Padding(2);
            this.cmbColNames.Name = "cmbColNames";
            this.cmbColNames.Size = new System.Drawing.Size(189, 30);
            this.cmbColNames.TabIndex = 30;
            // 
            // grpB1
            // 
            this.grpB1.Controls.Add(this.cmbColNames);
            this.grpB1.Controls.Add(this.btnSearchEntity);
            this.grpB1.Controls.Add(this.tbSearchEntity);
            this.grpB1.Location = new System.Drawing.Point(7, 13);
            this.grpB1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpB1.Name = "grpB1";
            this.grpB1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpB1.Size = new System.Drawing.Size(644, 70);
            this.grpB1.TabIndex = 31;
            this.grpB1.TabStop = false;
            this.grpB1.Text = "Select Entity Collection Column:";
            // 
            // btnSearchPropColumn
            // 
            this.btnSearchPropColumn.AutoSize = true;
            this.btnSearchPropColumn.Location = new System.Drawing.Point(537, 24);
            this.btnSearchPropColumn.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearchPropColumn.Name = "btnSearchPropColumn";
            this.btnSearchPropColumn.Size = new System.Drawing.Size(94, 38);
            this.btnSearchPropColumn.TabIndex = 35;
            this.btnSearchPropColumn.Text = "Search";
            this.btnSearchPropColumn.UseVisualStyleBackColor = true;
            this.btnSearchPropColumn.Click += new System.EventHandler(this.btnSearchPropColumn_Click);
            // 
            // tbPropSearch
            // 
            this.tbPropSearch.Location = new System.Drawing.Point(244, 29);
            this.tbPropSearch.Margin = new System.Windows.Forms.Padding(2);
            this.tbPropSearch.Name = "tbPropSearch";
            this.tbPropSearch.Size = new System.Drawing.Size(282, 28);
            this.tbPropSearch.TabIndex = 34;
            // 
            // cmbPropColumn
            // 
            this.cmbPropColumn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPropColumn.FormattingEnabled = true;
            this.cmbPropColumn.Location = new System.Drawing.Point(31, 28);
            this.cmbPropColumn.Margin = new System.Windows.Forms.Padding(2);
            this.cmbPropColumn.Name = "cmbPropColumn";
            this.cmbPropColumn.Size = new System.Drawing.Size(187, 30);
            this.cmbPropColumn.TabIndex = 33;
            // 
            // btnBuildQuery
            // 
            this.btnBuildQuery.AutoSize = true;
            this.btnBuildQuery.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnBuildQuery.Location = new System.Drawing.Point(28, 31);
            this.btnBuildQuery.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuildQuery.Name = "btnBuildQuery";
            this.btnBuildQuery.Size = new System.Drawing.Size(167, 32);
            this.btnBuildQuery.TabIndex = 31;
            this.btnBuildQuery.Text = "Build oData Query";
            this.btnBuildQuery.UseVisualStyleBackColor = true;
            this.btnBuildQuery.Click += new System.EventHandler(this.btnBuildQuery_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox6.Controls.Add(this.btnExecute);
            this.groupBox6.Controls.Add(this.tbQuery);
            this.groupBox6.Controls.Add(this.btnBuildQuery);
            this.groupBox6.Location = new System.Drawing.Point(7, 682);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox6.Size = new System.Drawing.Size(1373, 91);
            this.groupBox6.TabIndex = 36;
            this.groupBox6.TabStop = false;
            // 
            // btnExecute
            // 
            this.btnExecute.AutoSize = true;
            this.btnExecute.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnExecute.Location = new System.Drawing.Point(1106, 30);
            this.btnExecute.Margin = new System.Windows.Forms.Padding(2);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(192, 32);
            this.btnExecute.TabIndex = 32;
            this.btnExecute.Text = "Execute oData Query";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // tbQuery
            // 
            this.tbQuery.Location = new System.Drawing.Point(242, 18);
            this.tbQuery.Margin = new System.Windows.Forms.Padding(2);
            this.tbQuery.Multiline = true;
            this.tbQuery.Name = "tbQuery";
            this.tbQuery.Size = new System.Drawing.Size(823, 66);
            this.tbQuery.TabIndex = 28;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.cmbPropColumn);
            this.groupBox7.Controls.Add(this.btnSearchPropColumn);
            this.groupBox7.Controls.Add(this.tbPropSearch);
            this.groupBox7.Location = new System.Drawing.Point(669, 13);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(644, 70);
            this.groupBox7.TabIndex = 37;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Select Entity Properties Column:";
            // 
            // formEntityView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1392, 774);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.grpB1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox4);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "formEntityView";
            this.Text = "Entity View";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgvEntitySetList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKey)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProperty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNavigation)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEntityTags)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.grpB1.ResumeLayout(false);
            this.grpB1.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvEntitySetList;
        private System.Windows.Forms.DataGridView dgvKey;
        private System.Windows.Forms.DataGridView dgvProperty;
        private System.Windows.Forms.DataGridView dgvNavigation;
        private System.Windows.Forms.TextBox tbSearchEntity;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvEntityTags;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnSearchEntity;
        private System.Windows.Forms.ComboBox cmbColNames;
        private System.Windows.Forms.GroupBox grpB1;
        private System.Windows.Forms.Button btnBuildQuery;
        private System.Windows.Forms.Button btnSearchPropColumn;
        private System.Windows.Forms.TextBox tbPropSearch;
        private System.Windows.Forms.ComboBox cmbPropColumn;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox tbQuery;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.GroupBox groupBox7;
    }
}