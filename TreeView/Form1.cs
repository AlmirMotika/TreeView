using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using TreeView.Extensions;

namespace TreeView
{
    public partial class Form1 : Form
    {
        private readonly SqlConnection Con;

        public Form1()
        {
            InitializeComponent();
            Con = new SqlConnection(Properties.Settings.Default.SqlConnectionString);
        }

        private void Button_Populate_Click(object sender, EventArgs e)
        {
            try
            {
                ClearTreeView();
                PopulateTreeView(GetData());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private SqlDataReader GetData()
        {
            SqlCommand cm = new SqlCommand("Select o.OsobaID,o.Ime,vp.IznosVanrednogPrihoda from Osoba as o left join dbo.VanredniPrihodi as vp on o.OsobaID=vp.OsobaID", Con);
            return cm.ExecuteReader();
        }

        private void ClearTreeView()
        {
            treeView1.Nodes.Clear();
        }

        private void PopulateTreeView(SqlDataReader sqlDataReader)
        {
            while (sqlDataReader.Read())
            {
                AddTreeNodes(sqlDataReader, treeView1.Nodes);
            }
        }

        private void AddTreeNodes(SqlDataReader sqlDataReader, TreeNodeCollection nodeCollection)
        {
            TreeNode node = new TreeNode(sqlDataReader.GetValueAsString("Ime"));
            node.Nodes.Add(sqlDataReader.GetValueAsString("OsobaID"));
            node.Nodes.Add(sqlDataReader.GetValueAsInt("IznosVanrednogPrihoda").ToString()); ;
            nodeCollection.Add(node);
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            try
            {
                Con.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.ExitThread();
            }
        }
    }
}
