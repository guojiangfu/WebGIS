using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Npgsql;
using System.Configuration;

namespace WebForm
{
    public partial class WebGIS : System.Web.UI.Page
    {
        //数据库连接字符串
        string ConStr = ConfigurationManager.ConnectionStrings["Postgre"].ConnectionString;
        private NpgsqlConnection conn = null;
        private NpgsqlCommand cmd = null;
        //SQL语句
        private string SQL = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            openDatabase();
        }

        public void openDatabase()
        {
            conn = new NpgsqlConnection(ConStr);
            conn.Open();
            SQL = "SELECT * FROM namelist";
            cmd = new NpgsqlCommand(SQL, conn);
            NpgsqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                tbName.Text = (String)dr[0].ToString().Trim();
                tbNumber.Text = (String)dr[1].ToString().Trim();
                tbID.Text = (String)dr[2].ToString().Trim();
                tbScore.Text = (String)dr[3].ToString().Trim();
                tbCourse.Text = (String)dr[4].ToString().Trim();
            }
            conn.Close();
        }
        protected void BtnLoad_Click(object sender, EventArgs e)
        {
            
        }
    }
}