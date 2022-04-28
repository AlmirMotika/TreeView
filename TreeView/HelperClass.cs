using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace TreeView
{
    public class HelperClass
    {
        static readonly SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-M15F5BI\MSSQLSERVER_OLAP;Initial Catalog=prihodi;Integrated Security=True");

    }
}
