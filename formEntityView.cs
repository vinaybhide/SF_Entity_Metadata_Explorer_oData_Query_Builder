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

        public formEntityView(string fetchedMetadata)
        {
            InitializeComponent();
            strEntityMetadata = fetchedMetadata;
            dtEntitySet = new DataTable();
            dtEntitySet.Columns.Add("EntityName");
            dtEntitySet.Columns.Add("EntityType");
            dtEntitySet.Columns.Add("sap:label");
            dtEntitySet.Columns.Add("sap:creatable");
            dtEntitySet.Columns.Add("sap:updatable");
            dtEntitySet.Columns.Add("sap:upsertable");
            dtEntitySet.Columns.Add("sap:deletable");
            dtEntitySet.Columns.Add("Summary");
            dtEntitySet.Columns.Add("LongDescription");

            dtEntityTags = new DataTable();
            dtEntityTags.Columns.Add("EntityName");
            dtEntityTags.Columns.Add("sap:tag");

            dtEntityKey = new DataTable();
            dtEntityKey.Columns.Add("EntityName"); dtEntityKey.Columns.Add("Key_Name");

            dtEntityProperty = new DataTable();
            dtEntityProperty.Columns.Add("EntityName");
            dtEntityProperty.Columns.Add("Property_Name");
            dtEntityProperty.Columns.Add("Type");
            dtEntityProperty.Columns.Add("Nullable");
            dtEntityProperty.Columns.Add("sap:required");
            dtEntityProperty.Columns.Add("sap:creatable");
            dtEntityProperty.Columns.Add("sap:updatable");
            dtEntityProperty.Columns.Add("sap:upsertable");
            dtEntityProperty.Columns.Add("sap:visible");
            dtEntityProperty.Columns.Add("sap:sortable");
            dtEntityProperty.Columns.Add("sap:filterable");
            dtEntityProperty.Columns.Add("sap:label");

            dtEntityNavigationProperty = new DataTable();
            dtEntityNavigationProperty.Columns.Add("EntityName");
            dtEntityNavigationProperty.Columns.Add("NavigationProperty_Name");
            dtEntityNavigationProperty.Columns.Add("sap:required");
            dtEntityNavigationProperty.Columns.Add("sap:creatable");
            dtEntityNavigationProperty.Columns.Add("sap:updatable");
            dtEntityNavigationProperty.Columns.Add("sap:upsertable");
            dtEntityNavigationProperty.Columns.Add("sap:visible");
            dtEntityNavigationProperty.Columns.Add("sap:sortable");
            dtEntityNavigationProperty.Columns.Add("sap:filterable");
            dtEntityNavigationProperty.Columns.Add("Relationship");
            dtEntityNavigationProperty.Columns.Add("FromRole");
            dtEntityNavigationProperty.Columns.Add("ToRole");
            dtEntityNavigationProperty.Columns.Add("sap:field-control");
            dtEntityNavigationProperty.Columns.Add("sap:label");

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
                    foreach (DataColumn colName in dtEntitySet.Columns)
                    {
                        cmbColNames.Items.Add(colName.ColumnName);
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
                            dr["sap:label"] = nodeEntitySet.Attributes["sap:label"] != null ? nodeEntitySet.Attributes["sap:label"].Value.ToString() : "";
                            dr["sap:creatable"] = nodeEntitySet.Attributes["sap:creatable"] != null ? nodeEntitySet.Attributes["sap:creatable"].Value.ToString() : "";
                            dr["sap:updatable"] = nodeEntitySet.Attributes["sap:updatable"] != null ? nodeEntitySet.Attributes["sap:updatable"].Value.ToString() : "";
                            dr["sap:upsertable"] = nodeEntitySet.Attributes["sap:upsertable"] != null ? nodeEntitySet.Attributes["sap:upsertable"].Value.ToString() : "";
                            dr["sap:deletable"] = nodeEntitySet.Attributes["sap:deletable"] != null ? nodeEntitySet.Attributes["sap:deletable"].Value.ToString() : "";

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
                                                drTags["sap:tag"] = nodeChildTag.InnerText;
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
                                        drProperty["sap:required"] = nodeChildEntity.Attributes["sap:required"] != null ? nodeChildEntity.Attributes["sap:required"].Value : "";
                                        drProperty["sap:creatable"] = nodeChildEntity.Attributes["sap:creatable"] != null ? nodeChildEntity.Attributes["sap:creatable"].Value : "";
                                        drProperty["sap:updatable"] = nodeChildEntity.Attributes["sap:updatable"] != null ? nodeChildEntity.Attributes["sap:updatable"].Value : "";
                                        drProperty["sap:upsertable"] = nodeChildEntity.Attributes["sap:upsertable"] != null ? nodeChildEntity.Attributes["sap:upsertable"].Value : "";
                                        drProperty["sap:visible"] = nodeChildEntity.Attributes["sap:visible"] != null ? nodeChildEntity.Attributes["sap:visible"].Value : "";
                                        drProperty["sap:sortable"] = nodeChildEntity.Attributes["sap:sortable"] != null ? nodeChildEntity.Attributes["sap:sortable"].Value : "";
                                        drProperty["sap:filterable"] = nodeChildEntity.Attributes["sap:filterable"] != null ? nodeChildEntity.Attributes["sap:filterable"].Value : "";
                                        drProperty["sap:label"] = nodeChildEntity.Attributes["sap:label"] != null ? nodeChildEntity.Attributes["sap:label"].Value : "";
                                        dtEntityProperty.Rows.Add(drProperty);
                                    }
                                    else if (nodeChildEntity.Name.Equals("NavigationProperty"))
                                    {
                                        drNavigationProperty = dtEntityNavigationProperty.NewRow();
                                        drNavigationProperty["EntityName"] = strEntityName;
                                        drNavigationProperty["NavigationProperty_Name"] = nodeChildEntity.Attributes["Name"] != null ? nodeChildEntity.Attributes["Name"].Value : "";
                                        drNavigationProperty["sap:required"] = nodeChildEntity.Attributes["sap:required"] != null ? nodeChildEntity.Attributes["sap:required"].Value : "";
                                        drNavigationProperty["sap:creatable"] = nodeChildEntity.Attributes["sap:creatable"] != null ? nodeChildEntity.Attributes["sap:creatable"].Value : "";
                                        drNavigationProperty["sap:updatable"] = nodeChildEntity.Attributes["sap:updatable"] != null ? nodeChildEntity.Attributes["sap:updatable"].Value : "";
                                        drNavigationProperty["sap:upsertable"] = nodeChildEntity.Attributes["sap:upsertable"] != null ? nodeChildEntity.Attributes["sap:upsertable"].Value : "";
                                        drNavigationProperty["sap:visible"] = nodeChildEntity.Attributes["sap:visible"] != null ? nodeChildEntity.Attributes["sap:visible"].Value : "";
                                        drNavigationProperty["sap:sortable"] = nodeChildEntity.Attributes["sap:sortable"] != null ? nodeChildEntity.Attributes["sap:sortable"].Value : "";
                                        drNavigationProperty["sap:filterable"] = nodeChildEntity.Attributes["sap:filterable"] != null ? nodeChildEntity.Attributes["sap:filterable"].Value : "";
                                        drNavigationProperty["Relationship"] = nodeChildEntity.Attributes["Relationship"] != null ? nodeChildEntity.Attributes["Relationship"].Value : "";
                                        drNavigationProperty["FromRole"] = nodeChildEntity.Attributes["FromRole"] != null ? nodeChildEntity.Attributes["FromRole"].Value : "";
                                        drNavigationProperty["ToRole"] = nodeChildEntity.Attributes["ToRole"] != null ? nodeChildEntity.Attributes["ToRole"].Value : "";
                                        drNavigationProperty["sap:field-control"] = nodeChildEntity.Attributes["sap:field-control"] != null ? nodeChildEntity.Attributes["sap:field-control"].Value : "";
                                        drNavigationProperty["sap:label"] = nodeChildEntity.Attributes["sap:label"] != null ? nodeChildEntity.Attributes["sap:label"].Value : "";
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

        private void dgvEntitySetList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if ((dgvEntitySetList.Columns[e.ColumnIndex].HeaderText.Equals("EntityName")) &&
            //    (e.RowIndex >= 0))
            if (e.RowIndex >= 0)
            {
                //strSelectedEntityName = dgvEntitySetList[e.ColumnIndex, e.RowIndex].Value.ToString();
                strSelectedEntityName = dgvEntitySetList[0, e.RowIndex].Value.ToString();
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
                    if ((dgvProperty.DataSource != null) &&(dgvProperty.Rows.Count > 0))
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
                    else
                    {
                        MessageBox.Show("No tags available", "Entity Tags", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    tempRows = dtEntityKey.Select(expression);
                    if ((tempRows != null) && (tempRows.Length > 0))
                    {
                        DataTable tempTable = tempRows.CopyToDataTable();//dtEntityTags.Select(expression).CopyToDataTable();
                        dgvKey.DataSource = tempTable;
                    }
                    else
                    {
                        MessageBox.Show("No Keys available", "Entity Keys", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    tempRows = dtEntityProperty.Select(expression);
                    if ((tempRows != null) && (tempRows.Length > 0))
                    {
                        DataTable tempTable = tempRows.CopyToDataTable();
                        dgvProperty.DataSource = tempTable;
                    }
                    else
                    {
                        MessageBox.Show("No Properties available", "Entity Property", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    tempRows = dtEntityNavigationProperty.Select(expression);
                    if ((tempRows != null) && (tempRows.Length > 0))
                    {
                        DataTable tempTable = tempRows.CopyToDataTable();
                        dgvNavigation.DataSource = tempTable;
                    }
                    else
                    {
                        MessageBox.Show("No Navigation properties available", "Navigation properties", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void btnSearchEntity_Click(object sender, EventArgs e)
        {
            //dgvEntitySetList.
            ////string expression = String.Format(" Name LIKE '%{0}%' ", tbSearchEntity.Text))
            ///
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
            if (string.IsNullOrEmpty(tbSearchEntity.Text) == false)
            {
                //string expression = String.Format(" {0} LIKE '{1}%' ", cmbColNames.Text, tbSearchEntity.Text);
                string expression = String.Format(" {0} LIKE '{1}' ", cmbColNames.Text, tbSearchEntity.Text);
                DataRow[] tempRows = dtEntitySet.Select(expression);
                if ((tempRows != null) && (tempRows.Length > 0))
                {
                    DataTable tempTable = tempRows.CopyToDataTable();
                    dgvEntitySetList.DataSource = tempTable;
                }
                else
                {
                    MessageBox.Show("No match found", "Search Entities", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvEntitySetList.DataSource = dtEntitySet;
                }
            }
            else
            {
                dgvEntitySetList.DataSource = dtEntitySet;
            }
        }

        private void btnBuildQuery_Click(object sender, EventArgs e)
        {
            string sEntityName = string.Empty;
            string sFilter = string.Empty;
            string sSelect = string.Empty;

            if (dgvEntitySetList.SelectedRows != null)
            {
                sEntityName = dgvEntitySetList.SelectedRows[0].Cells[0].Value.ToString();
                
                if(dgvKey.SelectedRows != null)
                {
                    foreach (DataGridViewRow itemSelected in dgvKey.SelectedRows)
                    {
                        if(string.IsNullOrEmpty(sFilter) == false)
                        {
                            sFilter += "& ";
                        }
                        else
                        {
                            sFilter = "filter=";
                        }
                        sFilter += itemSelected.Cells[1].Value.ToString() + " eq " + "'[Enter Value]' ";
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
                }

                    }

                }
    }
}
