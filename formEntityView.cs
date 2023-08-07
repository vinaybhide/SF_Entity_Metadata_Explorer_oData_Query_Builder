using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace SF_Entity_Metadata
{
    public partial class formEntityView : Form
    {
        public bool bSearchPropertyClicked = false;
        public SFConfiguration sfConfigObject = null;
        public string strEntityMetadata = string.Empty;
        public XmlDocument xmlMetadata = null;
        public XmlNodeList nodelistSchema = null;

        public string strSFODataSet = "SFODataSet";
        public string strSFOData = "SFOData";
        public string strSelectedEntityName = string.Empty;

        DataTable dtEntitySet = null;
        DataTable dtEntityTags = null;

        DataTable dtEntityKey = null;
        DataTable dtEntityProperty = null;
        DataTable dtEntityNavigationProperty = null;

        public formEntityView()
        {
            InitializeComponent();
        }

        public formEntityView(string fetchedMetadata, SFConfiguration sfConfigObject)
        {
            InitializeComponent();
            strEntityMetadata = fetchedMetadata;
            this.sfConfigObject = sfConfigObject;

            dtEntitySet = new DataTable();
            dtEntitySet.Columns.Add("EntityName");
            dtEntitySet.Columns.Add("EntityType");
            dtEntitySet.Columns.Add("sap_label");
            //dtEntitySet.Columns.Add("sap_creatable");
            //dtEntitySet.Columns.Add("sap_updatable");
            //dtEntitySet.Columns.Add("sap_upsertable");
            //dtEntitySet.Columns.Add("sap_deletable");
            dtEntitySet.Columns.Add("Summary");
            dtEntitySet.Columns.Add("LongDescription");

            dtEntityTags = new DataTable();
            dtEntityTags.Columns.Add("EntityName");
            dtEntityTags.Columns.Add("sap_tag");

            dtEntityKey = new DataTable();
            dtEntityKey.Columns.Add("X", typeof(bool));
            dtEntityKey.Columns.Add("EntityName"); 
            dtEntityKey.Columns.Add("Key_Name");

            dtEntityProperty = new DataTable();
            dtEntityProperty.Columns.Add("EntityName");
            dtEntityProperty.Columns.Add("Property_Name");
            dtEntityProperty.Columns.Add("Type");
            dtEntityProperty.Columns.Add("Nullable");
            //dtEntityProperty.Columns.Add("sap_required");
            //dtEntityProperty.Columns.Add("sap_creatable");
            //dtEntityProperty.Columns.Add("sap_updatable");
            //dtEntityProperty.Columns.Add("sap_upsertable");
            dtEntityProperty.Columns.Add("sap_visible");
            //dtEntityProperty.Columns.Add("sap_sortable");
            //dtEntityProperty.Columns.Add("sap_filterable");
            dtEntityProperty.Columns.Add("sap_label");

            dtEntityNavigationProperty = new DataTable();
            dtEntityNavigationProperty.Columns.Add("EntityName");
            dtEntityNavigationProperty.Columns.Add("NavigationProperty_Name");
            //dtEntityNavigationProperty.Columns.Add("sap_required");
            //dtEntityNavigationProperty.Columns.Add("sap_creatable");
            //dtEntityNavigationProperty.Columns.Add("sap_updatable");
            //dtEntityNavigationProperty.Columns.Add("sap_upsertable");
            //dtEntityNavigationProperty.Columns.Add("sap_visible");
            //dtEntityNavigationProperty.Columns.Add("sap_sortable");
            //dtEntityNavigationProperty.Columns.Add("sap_filterable");
            dtEntityNavigationProperty.Columns.Add("Relationship");
            dtEntityNavigationProperty.Columns.Add("FromRole");
            dtEntityNavigationProperty.Columns.Add("ToRole");
            dtEntityNavigationProperty.Columns.Add("sap_field-control");
            dtEntityNavigationProperty.Columns.Add("sap_label");

            PopulateTables();
        }

        public void PopulateTables()
        {
            string strEntityName = string.Empty;
            nodelistSchema = null;
            xmlMetadata = new XmlDocument();
            //xmlMetadata.Load("D:\\Development\\SF_Metadata\\maxeon_metadata.xml");
            xmlMetadata.LoadXml(strEntityMetadata);
            if (xmlMetadata != null)
            {
                nodelistSchema = xmlMetadata.GetElementsByTagName("Schema");
                if ((nodelistSchema != null) && (nodelistSchema.Count > 0))
                {
                    if (dtEntitySet != null)
                    {
                        dtEntitySet.Clear();
                    }
                    if (dtEntityTags != null)
                    {
                        dtEntityTags.Clear();
                    }
                    if (dtEntityKey != null)
                    {
                        dtEntityKey.Clear();
                    }
                    if (dtEntityProperty != null)
                    {
                        dtEntityProperty.Clear();
                    }
                    if (dtEntityNavigationProperty != null)
                    {
                        dtEntityNavigationProperty.Clear();
                    }

                    foreach (XmlNode nodeFoundSchema in nodelistSchema)
                    {
                        if (nodeFoundSchema.Attributes["Namespace"] != null)
                        {
                            if (nodeFoundSchema.Attributes["Namespace"].Value.Equals(strSFODataSet))
                            {
                                FillEntitySet(nodeFoundSchema);
                            }
                            else if (nodeFoundSchema.Attributes["Namespace"].Value.Equals(strSFOData))
                            {
                                FillEntityType(nodeFoundSchema);
                            }
                        }
                    }
                    dgvEntitySetList.DataSource = dtEntitySet;
                    dgvEntityTags.DataSource = dtEntityTags;
                    dgvKey.DataSource = dtEntityKey;

                    //foreach (DataGridViewRow row in dgvKey.Rows)
                    //{
                    //    row.ReadOnly = true;
                    //    row.Cells["X"].ReadOnly = false;
                    //}
                    dgvKey.Columns["X"].Width = 10;
                    //dgvKey.Columns["X"].FillWeight = 40;

                    dgvProperty.DataSource = dtEntityProperty;
                    dgvNavigation.DataSource = dtEntityNavigationProperty;

                    foreach (DataColumn colName in dtEntitySet.Columns)
                    {
                        cmbColNames.Items.Add(colName.ColumnName);
                    }
                    foreach (DataColumn colName in dtEntityProperty.Columns)
                    {
                        cmbPropColumn.Items.Add(colName.ColumnName);
                    }

                }
            }
        }

        public void FillEntitySet(XmlNode nodeSchema)
        {
            string strEntityName = string.Empty;
            try
            {
                XmlNode nodeEntityContainer = nodeSchema.HasChildNodes == true ? nodeSchema.ChildNodes[0] : null;

                if ((nodeEntityContainer != null) && (nodeEntityContainer.HasChildNodes == true))
                {
                    DataRow dr = null;
                    DataRow drTags = null;
                    XmlNode nodeDocumentation = null;

                    foreach (XmlNode nodeEntitySet in nodeEntityContainer.ChildNodes)
                    {
                        dr = dtEntitySet.NewRow();
                        if (nodeEntitySet.Attributes["Name"] != null)
                        {
                            //add EntitySet Node
                            dr["EntityName"] = strEntityName = nodeEntitySet.Attributes["Name"].Value.ToString();
                            dr["EntityType"] = nodeEntitySet.Attributes["EntityType"] != null ? nodeEntitySet.Attributes["EntityType"].Value.ToString() : "";
                            dr["sap_label"] = nodeEntitySet.Attributes["sap:label"] != null ? nodeEntitySet.Attributes["sap:label"].Value.ToString() : "";
                            //dr["sap_creatable"] = nodeEntitySet.Attributes["sap:creatable"] != null ? nodeEntitySet.Attributes["sap:creatable"].Value.ToString() : "";
                            //dr["sap_updatable"] = nodeEntitySet.Attributes["sap:updatable"] != null ? nodeEntitySet.Attributes["sap:updatable"].Value.ToString() : "";
                            //dr["sap_upsertable"] = nodeEntitySet.Attributes["sap:upsertable"] != null ? nodeEntitySet.Attributes["sap:upsertable"].Value.ToString() : "";
                            //dr["sap_deletable"] = nodeEntitySet.Attributes["sap:deletable"] != null ? nodeEntitySet.Attributes["sap:deletable"].Value.ToString() : "";

                            //now get child
                            nodeDocumentation = nodeEntitySet.HasChildNodes == true ? nodeEntitySet.ChildNodes[0] : null;
                            if ((nodeDocumentation != null) && (nodeDocumentation.HasChildNodes == true))
                            {
                                foreach (XmlNode nodeChildDocument in nodeDocumentation.ChildNodes)
                                {
                                    if (nodeChildDocument.Name.Equals("Summary"))
                                    {
                                        dr["Summary"] = nodeChildDocument.InnerText;
                                    }
                                    else if (nodeChildDocument.Name.Equals("LongDescription"))
                                    {
                                        dr["LongDescription"] = nodeChildDocument.InnerText;
                                    }
                                    else if (nodeChildDocument.Name.Equals("sap:tagcollection"))
                                    {
                                        if (nodeChildDocument.HasChildNodes == true)
                                        {
                                            foreach (XmlNode nodeChildTag in nodeChildDocument.ChildNodes)
                                            {
                                                drTags = dtEntityTags.NewRow();
                                                drTags["EntityName"] = strEntityName;
                                                drTags["sap_tag"] = nodeChildTag.InnerText;
                                                dtEntityTags.Rows.Add(drTags);
                                            }
                                        }
                                    }
                                }
                            }
                            dtEntitySet.Rows.Add(dr);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception in Method : FillEntitySet", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void FillEntityType(XmlNode nodeSchema)
        {
            string strEntityName = string.Empty;
            try
            {
                if ((nodeSchema != null) && (nodeSchema.HasChildNodes == true))
                {
                    DataRow drKey = null;
                    DataRow drProperty = null;
                    DataRow drNavigationProperty = null;

                    foreach (XmlNode nodeEntityType in nodeSchema.ChildNodes)
                    {
                        if (nodeEntityType.Attributes["Name"] != null)
                        {
                            strEntityName = nodeEntityType.Attributes["Name"].Value.ToString();
                            if (nodeEntityType.HasChildNodes)
                            {
                                foreach (XmlNode nodeChildEntity in nodeEntityType.ChildNodes)
                                {
                                    if ((nodeChildEntity.Name.Equals("Key")) && (nodeChildEntity.HasChildNodes))
                                    {
                                        foreach (XmlNode nodeChildKey in nodeChildEntity.ChildNodes)
                                        {
                                            drKey = dtEntityKey.NewRow();
                                            drKey["X"] = false;
                                            drKey["EntityName"] = strEntityName;
                                            drKey["Key_Name"] = nodeChildKey.Attributes["Name"] != null ? nodeChildKey.Attributes["Name"].Value : "";
                                            dtEntityKey.Rows.Add(drKey);
                                        }
                                    }
                                    else if (nodeChildEntity.Name.Equals("Property"))
                                    {
                                        drProperty = dtEntityProperty.NewRow();
                                        drProperty["EntityName"] = strEntityName;
                                        drProperty["Property_Name"] = nodeChildEntity.Attributes["Name"] != null ? nodeChildEntity.Attributes["Name"].Value : "";
                                        drProperty["Type"] = nodeChildEntity.Attributes["Type"] != null ? nodeChildEntity.Attributes["Type"].Value : "";
                                        drProperty["Nullable"] = nodeChildEntity.Attributes["Nullable"] != null ? nodeChildEntity.Attributes["Nullable"].Value : "";
                                        //drProperty["sap_required"] = nodeChildEntity.Attributes["sap:required"] != null ? nodeChildEntity.Attributes["sap:required"].Value : "";
                                        //drProperty["sap_creatable"] = nodeChildEntity.Attributes["sap:creatable"] != null ? nodeChildEntity.Attributes["sap:creatable"].Value : "";
                                        //drProperty["sap_updatable"] = nodeChildEntity.Attributes["sap:updatable"] != null ? nodeChildEntity.Attributes["sap:updatable"].Value : "";
                                        //drProperty["sap_upsertable"] = nodeChildEntity.Attributes["sap:upsertable"] != null ? nodeChildEntity.Attributes["sap:upsertable"].Value : "";
                                        drProperty["sap_visible"] = nodeChildEntity.Attributes["sap:visible"] != null ? nodeChildEntity.Attributes["sap:visible"].Value : "";
                                        //drProperty["sap_sortable"] = nodeChildEntity.Attributes["sap:sortable"] != null ? nodeChildEntity.Attributes["sap:sortable"].Value : "";
                                        //drProperty["sap_filterable"] = nodeChildEntity.Attributes["sap:filterable"] != null ? nodeChildEntity.Attributes["sap:filterable"].Value : "";
                                        drProperty["sap_label"] = nodeChildEntity.Attributes["sap:label"] != null ? nodeChildEntity.Attributes["sap:label"].Value : "";
                                        dtEntityProperty.Rows.Add(drProperty);
                                    }
                                    else if (nodeChildEntity.Name.Equals("NavigationProperty"))
                                    {
                                        drNavigationProperty = dtEntityNavigationProperty.NewRow();
                                        drNavigationProperty["EntityName"] = strEntityName;
                                        drNavigationProperty["NavigationProperty_Name"] = nodeChildEntity.Attributes["Name"] != null ? nodeChildEntity.Attributes["Name"].Value : "";
                                        //drNavigationProperty["sap_required"] = nodeChildEntity.Attributes["sap:required"] != null ? nodeChildEntity.Attributes["sap:required"].Value : "";
                                        //drNavigationProperty["sap_creatable"] = nodeChildEntity.Attributes["sap:creatable"] != null ? nodeChildEntity.Attributes["sap:creatable"].Value : "";
                                        //drNavigationProperty["sap_updatable"] = nodeChildEntity.Attributes["sap:updatable"] != null ? nodeChildEntity.Attributes["sap:updatable"].Value : "";
                                        //drNavigationProperty["sap_upsertable"] = nodeChildEntity.Attributes["sap:upsertable"] != null ? nodeChildEntity.Attributes["sap:upsertable"].Value : "";
                                        //drNavigationProperty["sap_visible"] = nodeChildEntity.Attributes["sap:visible"] != null ? nodeChildEntity.Attributes["sap:visible"].Value : "";
                                        //drNavigationProperty["sap_sortable"] = nodeChildEntity.Attributes["sap:sortable"] != null ? nodeChildEntity.Attributes["sap:sortable"].Value : "";
                                        //drNavigationProperty["sap_filterable"] = nodeChildEntity.Attributes["sap:filterable"] != null ? nodeChildEntity.Attributes["sap:filterable"].Value : "";
                                        drNavigationProperty["Relationship"] = nodeChildEntity.Attributes["Relationship"] != null ? nodeChildEntity.Attributes["Relationship"].Value : "";
                                        drNavigationProperty["FromRole"] = nodeChildEntity.Attributes["FromRole"] != null ? nodeChildEntity.Attributes["FromRole"].Value : "";
                                        drNavigationProperty["ToRole"] = nodeChildEntity.Attributes["ToRole"] != null ? nodeChildEntity.Attributes["ToRole"].Value : "";
                                        drNavigationProperty["sap_field-control"] = nodeChildEntity.Attributes["sap:field-control"] != null ? nodeChildEntity.Attributes["sap:field-control"].Value : "";
                                        drNavigationProperty["sap_label"] = nodeChildEntity.Attributes["sap:label"] != null ? nodeChildEntity.Attributes["sap:label"].Value : "";
                                        dtEntityNavigationProperty.Rows.Add(drNavigationProperty);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception in Method : FillEntityType", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvEntitySetList_SelectionChanged(object sender, EventArgs e)
        {
            if (bSearchPropertyClicked == false)
            {
                DataGridView dgvLocal = (DataGridView)sender;
                if (dgvLocal.SelectedRows.Count > 0)
                {
                    if (dgvLocal.SelectedRows[0].Selected == true)
                    { //strSelectedEntityName = dgvEntitySetList[e.ColumnIndex, e.RowIndex].Value.ToString();
                        strSelectedEntityName = dgvLocal.SelectedRows[0].Cells[0].Value.ToString(); //dgvEntitySetList[0, e.RowIndex].Value.ToString();
                        if (string.IsNullOrEmpty(strSelectedEntityName) == false)
                        {
                            if ((dgvEntityTags.DataSource != null) && (dgvEntityTags.Rows.Count > 0))
                            {
                                dgvEntityTags.DataSource = null;
                            }
                            if ((dgvKey.DataSource != null) && (dgvKey.Rows.Count > 0))
                            {
                                dgvKey.DataSource = null;
                            }
                            if ((dgvProperty.DataSource != null) && (dgvProperty.Rows.Count > 0))
                            {
                                dgvProperty.DataSource = null;
                            }
                            if ((dgvNavigation.DataSource != null) && (dgvNavigation.Rows.Count > 0))
                            {
                                dgvNavigation.DataSource = null;
                            }
                            string expression = "EntityName = '" + strSelectedEntityName + "'";
                            DataRow[] tempRows = dtEntityTags.Select(expression);
                            if ((tempRows != null) && (tempRows.Length > 0))
                            {
                                DataTable tempTable = tempRows.CopyToDataTable();//dtEntityTags.Select(expression).CopyToDataTable();
                                dgvEntityTags.DataSource = tempTable;
                            }
                            //else
                            //{
                            //    MessageBox.Show("No tags available", "Entity Tags", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //}

                            tempRows = dtEntityKey.Select(expression);
                            if ((tempRows != null) && (tempRows.Length > 0))
                            {
                                DataTable tempTable = tempRows.CopyToDataTable();//dtEntityTags.Select(expression).CopyToDataTable();
                                dgvKey.DataSource = tempTable;
                            }
                            //else
                            //{
                            //    MessageBox.Show("No Keys available", "Entity Keys", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //}

                            tempRows = dtEntityProperty.Select(expression);
                            if ((tempRows != null) && (tempRows.Length > 0))
                            {
                                DataTable tempTable = tempRows.CopyToDataTable();
                                dgvProperty.DataSource = tempTable;
                            }
                            //else
                            //{
                            //    MessageBox.Show("No Properties available", "Entity Property", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //}

                            tempRows = dtEntityNavigationProperty.Select(expression);
                            if ((tempRows != null) && (tempRows.Length > 0))
                            {
                                DataTable tempTable = tempRows.CopyToDataTable();
                                dgvNavigation.DataSource = tempTable;
                            }
                            //else
                            //{
                            //    MessageBox.Show("No Navigation properties available", "Navigation properties", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //}
                        }
                    }
                }
            }
        }

        //private void dgvEntitySetList_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    //if ((dgvEntitySetList.Columns[e.ColumnIndex].HeaderText.Equals("EntityName")) &&
        //    //    (e.RowIndex >= 0))
        //    if (e.RowIndex >= 0)
        //    {
        //        //strSelectedEntityName = dgvEntitySetList[e.ColumnIndex, e.RowIndex].Value.ToString();
        //        strSelectedEntityName = dgvEntitySetList[0, e.RowIndex].Value.ToString();
        //        if (string.IsNullOrEmpty(strSelectedEntityName) == false)
        //        {
        //            if ((dgvEntityTags.DataSource != null) && (dgvEntityTags.Rows.Count > 0))
        //            {
        //                dgvEntityTags.DataSource = null;
        //            }
        //            if ((dgvKey.DataSource != null) && (dgvKey.Rows.Count > 0))
        //            {
        //                dgvKey.DataSource = null;
        //            }
        //            if ((dgvProperty.DataSource != null) && (dgvProperty.Rows.Count > 0))
        //            {
        //                dgvProperty.DataSource = null;
        //            }
        //            if ((dgvNavigation.DataSource != null) && (dgvNavigation.Rows.Count > 0))
        //            {
        //                dgvNavigation.DataSource = null;
        //            }
        //            string expression = "EntityName = '" + strSelectedEntityName + "'";
        //            DataRow[] tempRows = dtEntityTags.Select(expression);
        //            if ((tempRows != null) && (tempRows.Length > 0))
        //            {
        //                DataTable tempTable = tempRows.CopyToDataTable();//dtEntityTags.Select(expression).CopyToDataTable();
        //                dgvEntityTags.DataSource = tempTable;
        //            }
        //            else
        //            {
        //                MessageBox.Show("No tags available", "Entity Tags", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            }

        //            tempRows = dtEntityKey.Select(expression);
        //            if ((tempRows != null) && (tempRows.Length > 0))
        //            {
        //                DataTable tempTable = tempRows.CopyToDataTable();//dtEntityTags.Select(expression).CopyToDataTable();
        //                dgvKey.DataSource = tempTable;
        //            }
        //            else
        //            {
        //                MessageBox.Show("No Keys available", "Entity Keys", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            }

        //            tempRows = dtEntityProperty.Select(expression);
        //            if ((tempRows != null) && (tempRows.Length > 0))
        //            {
        //                DataTable tempTable = tempRows.CopyToDataTable();
        //                dgvProperty.DataSource = tempTable;
        //            }
        //            else
        //            {
        //                MessageBox.Show("No Properties available", "Entity Property", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            }

        //            tempRows = dtEntityNavigationProperty.Select(expression);
        //            if ((tempRows != null) && (tempRows.Length > 0))
        //            {
        //                DataTable tempTable = tempRows.CopyToDataTable();
        //                dgvNavigation.DataSource = tempTable;
        //            }
        //            else
        //            {
        //                MessageBox.Show("No Navigation properties available", "Navigation properties", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            }
        //        }
        //    }
        //}

        private void btnSearchEntity_Click(object sender, EventArgs e)
        {
            //dgvEntitySetList.
            ////string expression = String.Format(" Name LIKE '%{0}%' ", tbSearchEntity.Text))
            ///
            if (string.IsNullOrEmpty(tbSearchEntity.Text) == false)
            {
                //string expression = String.Format(" {0} LIKE '{1}%' ", cmbColNames.Text, tbSearchEntity.Text);
                string expression = String.Format(" {0} LIKE '{1}' ", cmbColNames.Text, tbSearchEntity.Text);
                DataRow[] tempRows = dtEntitySet.Select(expression);
                if ((tempRows != null) && (tempRows.Length > 0))
                {
                    DataTable tempTable = tempRows.CopyToDataTable();
                    dgvEntitySetList.DataSource = tempTable;

                    //reset all other DGV's to empty
                    if ((dgvEntityTags.DataSource != null) && (dgvEntityTags.Rows.Count > 0))
                    {
                        dgvEntityTags.DataSource = null;
                    }
                    if ((dgvKey.DataSource != null) && (dgvKey.Rows.Count > 0))
                    {
                        dgvKey.DataSource = null;
                    }
                    if ((dgvProperty.DataSource != null) && (dgvProperty.Rows.Count > 0))
                    {
                        dgvProperty.DataSource = null;
                    }
                    if ((dgvNavigation.DataSource != null) && (dgvNavigation.Rows.Count > 0))
                    {
                        dgvNavigation.DataSource = null;
                    }

                    dgvEntitySetList.Rows[0].Selected = false;
                    //dgvEntitySetList.Rows[0].Selected = true;
                }
                else
                {
                    MessageBox.Show("No match found", "Search Entities", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //dgvEntitySetList.DataSource = dtEntitySet;
                }
            }
            else
            {
                dgvEntitySetList.DataSource = dtEntitySet;
            }
        }
        private void btnSearchPropColumn_Click(object sender, EventArgs e)
        {
            bSearchPropertyClicked = true;
            try
            {
                //dgvEntitySetList.
                ////string expression = String.Format(" Name LIKE '%{0}%' ", tbSearchEntity.Text))
                ///
                if (string.IsNullOrEmpty(tbPropSearch.Text) == false)
                {
                    //string expression = String.Format(" {0} LIKE '{1}%' ", cmbColNames.Text, tbSearchEntity.Text);
                    string expression = String.Format(" {0} LIKE '{1}' ", cmbPropColumn.Text, tbPropSearch.Text);
                    DataRow[] tempRows = dtEntityProperty.Select(expression);
                    if ((tempRows != null) && (tempRows.Length > 0))
                    {
                        DataTable tempTable = tempRows.CopyToDataTable();
                        dgvProperty.DataSource = tempTable;

                        //reset all other DGV's to empty except Entity Properties
                        //if ((dgvEntitySetList.DataSource != null) && (dgvEntitySetList.Rows.Count > 0))
                        //{
                        //    dgvEntitySetList.DataSource = null;
                        //}
                        if ((dgvEntityTags.DataSource != null) && (dgvEntityTags.Rows.Count > 0))
                        {
                            dgvEntityTags.DataSource = null;
                        }
                        if ((dgvKey.DataSource != null) && (dgvKey.Rows.Count > 0))
                        {
                            dgvKey.DataSource = null;
                        }
                        //if ((dgvProperty.DataSource != null) && (dgvProperty.Rows.Count > 0))
                        //{
                        //    dgvProperty.DataSource = null;
                        //}
                        if ((dgvNavigation.DataSource != null) && (dgvNavigation.Rows.Count > 0))
                        {
                            dgvNavigation.DataSource = null;
                        }

                        //Now populate dgvEntitySetList with those entities available in dgvProperties
                        string[] TobeDistinct = { dtEntityProperty.Columns[0].ColumnName };
                        DataTable tempTableEntityName = tempTable.DefaultView.ToTable(true, TobeDistinct);
                        expression = "";
                        foreach (DataRow itemRow in tempTableEntityName.Rows)
                        {
                            if (string.IsNullOrEmpty(expression) == false)
                            {
                                expression += " OR ";
                            }
                            expression += " EntityName = '" + itemRow[0].ToString() + "'";
                        }
                        DataRow[] tempRowsFilter = dtEntitySet.Select(expression);
                        if ((tempRowsFilter != null) && (tempRowsFilter.Length > 0))
                        {
                            DataTable tempFilterTable = tempRowsFilter.CopyToDataTable();
                            dgvEntitySetList.DataSource = tempFilterTable;

                            dgvEntitySetList.Rows[0].Selected = false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("No match found", "Search Entities", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //dgvEntitySetList.DataSource = dtEntitySet;
                    }
                }
                else
                {
                    dgvEntitySetList.DataSource = dtEntitySet;
                }
            }
            catch
            {

            }
            finally
            {
                bSearchPropertyClicked = false;
            }

        }

        private void btnBuildQuery_Click(object sender, EventArgs e)
        {
            string sEntityName = string.Empty;
            string sFilter = string.Empty;
            string sSelect = string.Empty;
            string sExpand = string.Empty;
            string sQuery = sfConfigObject.apiurl;

            if (dgvEntitySetList.SelectedRows != null)
            {
                sEntityName = dgvEntitySetList.SelectedRows[0].Cells[0].Value.ToString();
                sQuery += sEntityName + "?$format=json";
                if (dgvKey.SelectedRows != null)
                {
                    //foreach (DataGridViewRow itemSelected in dgvKey.SelectedRows)
                    foreach (DataGridViewRow itemSelected in dgvKey.Rows)
                    {
                        if ((bool)itemSelected.Cells[0].Value == true)
                        {
                            if (string.IsNullOrEmpty(sFilter) == false)
                            {
                                sFilter += "& ";
                            }
                            else
                            {
                                sFilter = "filter=";
                            }
                            sFilter += itemSelected.Cells[2].Value.ToString() + " eq " + "'[Enter Value]' ";
                        }
                    }
                    if(string.IsNullOrEmpty(sFilter) == false)
                    {
                        sQuery += "&$" + sFilter;
                    }
                }
                if (dgvProperty.SelectedRows != null)
                {
                    foreach (DataGridViewRow itemSelected in dgvProperty.SelectedRows)
                    {
                        if (string.IsNullOrEmpty(sSelect) == false)
                        {
                            sSelect += ",";
                        }
                        else
                        {
                            sSelect = "select=";
                        }
                        sSelect += itemSelected.Cells[1].Value.ToString();
                    }
                    if(string.IsNullOrEmpty (sSelect) == false)
                    {
                        sQuery += "&$" + sSelect;
                    }
                }
                if (dgvNavigation.SelectedRows != null)
                {
                    foreach (DataGridViewRow itemSelected in dgvNavigation.SelectedRows)
                    {
                        if (string.IsNullOrEmpty(sExpand) == false)
                        {
                            sExpand += ",";
                        }
                        else
                        {
                            sExpand = "expand=";
                        }
                        sExpand += itemSelected.Cells[1].Value.ToString();
                    }
                    if(string.IsNullOrEmpty(sExpand) == false)
                    {
                        sQuery += "&$" + sExpand;
                    }
                }
            }

            if(sQuery.Equals(sfConfigObject.apiurl) == false)
            {
                tbQuery.Text = sQuery;
            }
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            formQueryExecutor dlgQueryExecutor = new formQueryExecutor(tbQuery.Text, sfConfigObject);
            dlgQueryExecutor.ShowDialog();
        }

        private void dgvKey_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvKey_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvKey.Columns[e.ColumnIndex].HeaderText.Equals("X"))
            {
                dgvKey.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgvKey_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            //if (dgvKey.Columns[e.ColumnIndex].HeaderText.Equals("X"))
            {
                if (e.RowIndex == -1)
                {
                    if (dgvKey.Columns[e.ColumnIndex].HeaderText.Equals("X"))
                    {
                        foreach (DataGridViewRow rowitem in dgvKey.Rows)
                        {
                            //rowitem.Cells[e.ColumnIndex].Value = !(bool)rowitem.Cells[e.ColumnIndex].Value;
                            rowitem.Cells[0].Value = !(bool)rowitem.Cells[0].Value;
                        }
                    }
                }
                else //if (dgvKey.Columns[e.ColumnIndex].HeaderText.Equals("X"))
                {
                    //dgvKey.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = !(bool)dgvKey.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                    dgvKey.Rows[e.RowIndex].Cells[0].Value = !(bool)dgvKey.Rows[e.RowIndex].Cells[0].Value;
                }
            }
        }
    }
}
