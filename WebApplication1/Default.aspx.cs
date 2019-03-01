using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private SqlConnection cn = new SqlConnection(@"Data Source=SOUFIANE-PC\SQLEXPRESS;Initial Catalog=webShop;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.Session["iduser"] != null)
            {
                if (Request.Params["logout"] != null)
                {
                    this.Session.Abandon();
                    Response.Redirect("Default.aspx");
                }
                else
                    Response.Redirect("collection.aspx");

            }

        }

        protected void btn_connexion_Click(object sender, EventArgs e)
        {

            try
            {
                cn.Open();
                if(TextBox1.Text.Trim() != "" && TextBox2.Text != "")
                {
                    SqlCommand cmd = new SqlCommand("select * from utilisateurs where username= @username and motpasse=@motpasse", cn);
                    cmd.Parameters.AddWithValue("username", TextBox1.Text);
                    cmd.Parameters.AddWithValue("motpasse", TextBox2.Text);
                    var iduser = cmd.ExecuteScalar();
                    if(iduser != null)
                    {
                        this.Page.Session["iduser"] = (Int32)iduser;
                        this.Page.Session["login"] = TextBox1.Text;
                        cmd = new SqlCommand("select count(*) from lineitems where iduti= @iduser", cn);
                        cmd.Parameters.AddWithValue("iduser", (Int32)iduser);
                        this.Page.Session["CartItemsCount"] = cmd.ExecuteScalar();
                        Response.Redirect("/produits.aspx");
                    } else
                    {
                        Lbl_error1.Text = "Les coordonnées saisies sont incorrectes";
                    }

                } else
                {
                    Lbl_error1.Text = "Veuillez remplir les champs si dessus";
                }

            }
            finally
            {
                cn.Close();
            }
        }
    }
}