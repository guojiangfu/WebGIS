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
        static string ConStr = ConfigurationManager.ConnectionStrings["Postgre"].ConnectionString;
        private NpgsqlConnection conn = new NpgsqlConnection(ConStr);
        NpgsqlCommand cmd = null;
        private string SQL = null;
        NpgsqlDataReader dr = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public void  openDatabase()
        {
            conn.Open();
        }
        public void closeDatebase()
        {
            conn.Close();
        }
        public void LoadInfo(string sql)
        {
            openDatabase();
            cmd = new NpgsqlCommand(sql, conn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
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
            }
            closeDatebase();
        }
        public void Add()
        {
           SQL = "INSERT INTO namelist VALUES('" + tbName.Text.ToString().Trim() + "','" + tbNumber.Text.ToString().Trim() + "','" + tbID.Text.ToString().Trim() + "','" + tbScore.Text.ToString().Trim() + "','" + tbCourse.Text.ToString().Trim() + "')";
            Excute(SQL);
        }
        public void Del()
        {
            SQL = "DELETE FROM namelist WHERE \"学号No\"='" + tbNumber.Text.ToString().Trim() + "'";
            Excute(SQL);
        }
        public void Update()
        {
            SQL = "UPDATE namelist SET \"姓名Name\" = '" + tbName.Text.ToString().Trim() + "', \"ID\" = '" + tbID.Text.ToString().Trim() + "', \"成绩Score\" = '" + tbScore.Text.ToString().Trim() + "', \"科目\" = '" + tbCourse.Text.ToString().Trim() + "' WHERE  \"学号No\" ='" + tbNumber.Text.ToString().Trim() + "'";
            Excute(SQL);
        }
        public void Select()
        {
            SQL = "SELECT * FROM namelist WHERE \"学号No\"='"+tbNumber.Text.ToString().Trim()+"'";
            LoadInfo(SQL);
        }
        public void Excute(string sql)
        {
            openDatabase();
            cmd = new NpgsqlCommand(sql,conn);
            cmd.ExecuteNonQuery();
            closeDatebase();       
        }
        public void Inform()
        {
            Response.Write("<script>alert('Success!')</script>");
        }
        protected void BtnLoad_Click(object sender, EventArgs e)
        {
            SQL = "SELECT * FROM namelist";
            LoadInfo(SQL);
        }
        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            Add();
            Inform();
        }

        protected void BtnDel_Click(object sender, EventArgs e)
        {
            Del();
            Inform();
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            Update();
            Inform();
        }

        protected void BtnSelect_Click(object sender, EventArgs e)
        {
            Select();
            Inform();
        }

        protected void BtnClose_Click(object sender, EventArgs e)
        {
            closeDatebase();
        }
    }
}