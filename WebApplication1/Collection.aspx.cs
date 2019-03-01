using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class Collection : System.Web.UI.Page
    {
        private SqlConnection cn = new SqlConnection(@"Data Source=SOUFIANE-PC\SQLEXPRESS;Initial Catalog=webShop;Integrated Security=True");
        public DataTable Produits = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (cn.State == ConnectionState.Closed)
                    cn.Open();

                SqlCommand cmd = new SqlCommand("", cn);
                cmd.CommandText = @"Select * from produits";
                SqlDataReader dr = cmd.ExecuteReader();
                this.Produits.Load(dr);
                
                
            }
            finally
            {
                cn.Close();
            }

        }
    }
}