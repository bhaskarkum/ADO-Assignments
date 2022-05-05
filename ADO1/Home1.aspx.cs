using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
namespace ADO1
{
    public partial class Home1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("data source =.; database =Master; integrated Security = SSPI");
            SqlCommand cmd = new SqlCommand("select WinningTeam from FootBall WHERE MatchStatus ='WIN';SELECT * FROM FootBall WHERE TeamName1 ='JAPAN' OR TeamName2 ='JAPAN';  ", con);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            GridView1.DataSource = rdr;
            GridView1.DataBind();

            while (rdr.NextResult())
            {
                GridView2.DataSource = rdr;
                GridView2.DataBind();
            }
            con.Close();

        }

    }
}