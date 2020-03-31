using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Npgsql;
using System.Configuration;
using System.Web.UI.HtmlControls;

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
        public List<string> studentsName = new List<string>();
        public List<string> studentsNumber = new List<string>();
        public List<string> studentsID = new List<string>();
        public List<string> studentsScore = new List<string>();
        public List<string> studentsCourse = new List<string>();
        public int count = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            
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
                //tbName.Text = (String)dr[0].ToString().Trim();
                //tbNumber.Text = (String)dr[1].ToString().Trim();
                //tbID.Text = (String)dr[2].ToString().Trim();
                //tbScore.Text = (String)dr[3].ToString().Trim();
                //tbCourse.Text = (String)dr[4].ToString().Trim();

                //studentsName.Add((String)dr[0].ToString().Trim());
                //studentsNumber.Add((String)dr[0].ToString().Trim());
                //studentsID.Add((String)dr[0].ToString().Trim());
                //studentsScore.Add((String)dr[0].ToString().Trim());
                //studentsCourse.Add((String)dr[0].ToString().Trim());

                HtmlTableRow tr = new HtmlTableRow();

                HtmlTableCell NameTd = new HtmlTableCell();
                Label NameLabel = new Label();
                NameLabel.Text = (String)dr[0].ToString().Trim();
                NameTd.Controls.Add(NameLabel);
                tr.Cells.Add(NameTd);
                tab1.Rows.Add(tr);

                HtmlTableCell NumberTd = new HtmlTableCell();
                Label NumberLabel = new Label();
                NumberLabel.Text = (String)dr[1].ToString().Trim();
                NumberTd.Controls.Add(NumberLabel);
                tr.Cells.Add(NumberTd);
                tab1.Rows.Add(tr);

                HtmlTableCell IDTd = new HtmlTableCell();
                Label IDLabel = new Label();
                IDLabel.Text = (String)dr[2].ToString().Trim();
                IDTd.Controls.Add(IDLabel);
                tr.Cells.Add(IDTd);
                tab1.Rows.Add(tr);

                HtmlTableCell SoureTd = new HtmlTableCell();
                Label SoureLabel = new Label();
                SoureLabel.Text = (String)dr[3].ToString().Trim();
                SoureTd.Controls.Add(SoureLabel);
                tr.Cells.Add(SoureTd);
                tab1.Rows.Add(tr);

                HtmlTableCell ScourseTd = new HtmlTableCell();
                Label ScourseLabel = new Label();
                ScourseLabel.Text = (String)dr[4].ToString().Trim();
                ScourseTd.Controls.Add(ScourseLabel);
                tr.Cells.Add(ScourseTd);
                tab1.Rows.Add(tr);

                count += 1;
            }
            conn.Close();
        }
        protected void BtnLoad_Click(object sender, EventArgs e)
        {
            openDatabase();
        }
    }
}