using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; // SqlConnection

namespace projekt
{
    public partial class Form1 : Form
    {

        private SqlConnection conn = null;      
        string strconn = "Server=den1.mssql8.gear.host; Database=semesterprojekt1; User ID=semesterprojekt1; Password=Zf49T!jU!np0";


        public Form1()
        {
            InitializeComponent();

            conn = new SqlConnection(strconn);
            conn.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            forsidebox.Visible = true;
            boligbox.Visible = false;
            sælgerbox.Visible = false;
            køberbox.Visible = false;
            statistikbox.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            boligbox.Visible = true;
            forsidebox.Visible = false;
            sælgerbox.Visible = false;
            køberbox.Visible = false;
            statistikbox.Visible = false;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            sælgerbox.Visible = true;
            køberbox.Visible = false;
            boligbox.Visible = false;
            boligbox.Visible = false;
            statistikbox.Visible = false;
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            køberbox.Visible = true;
            forsidebox.Visible = false;
            sælgerbox.Visible = false;
            boligbox.Visible = false;
            statistikbox.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            statistikbox.Visible = true;
            forsidebox.Visible = false;
            boligbox.Visible = false;
            sælgerbox.Visible = false;
            køberbox.Visible = false;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            boligbox.Visible = true;
            forsidebox.Visible = false;
        }
    }
}
