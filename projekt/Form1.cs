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
        const bool test = false;
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

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'semesterprojekt1DataSet.KØBER' table. You can move, or remove it, as needed.
            this.kØBERTableAdapter.Fill(this.semesterprojekt1DataSet.KØBER);
            // TODO: This line of code loads data into the 'semesterprojekt1DataSet.BOLIG' table. You can move, or remove it, as needed.
            this.bOLIGTableAdapter.Fill(this.semesterprojekt1DataSet.BOLIG);
            // TODO: This line of code loads data into the 'semesterprojekt1DataSet.SÆLGER' table. You can move, or remove it, as needed.
            this.sÆLGERTableAdapter.Fill(this.semesterprojekt1DataSet.SÆLGER);

        }

       /* private void button6_Click(object sender, EventArgs e)
        {
            string S_Fornavn = textBox15.Text;
            string S_Efternavn = textBox16.Text;
            string S_Gadenavn = textBox17.Text;
            int S_Gade_nr = int.Parse(textBox18.Text);
            int S_Postnummer = int.Parse(textBox19.Text);
            string S_Email = textBox20.Text;
            string S_Tlf_nr = textBox21.Text;
            string S_ID = textBox22.Text;
            string EID = textBox23.Text;




            //C(RUD)
            string sSQL = "INSERT INTO SÆLGER VALUES ('" + S_Fornavn + "', '" + S_Efternavn + "', '" + S_Gadenavn + "', " + S_Gade_nr + ", " + S_Postnummer + ", '" + S_Email
                                                       + "', '" + S_Tlf_nr + "', '" + S_ID + "', '" + EID + "');";
            MessageBox.Show(sSQL);
            if (test) MessageBox.Show(sSQL);


            SqlCommand command = new SqlCommand(sSQL, conn);
            command.ExecuteNonQuery();
       


        } */


        private void button13_Click(object sender, EventArgs e)
        {
            string K_Fornavn = textBox32.Text;
            string K_Efternavn = textBox31.Text;
            string K_Gadenavn = textBox30.Text;
            int K_Gade_nr = int.Parse(textBox29.Text);
            int K_Postnummer = int.Parse(textBox28.Text);
            string K_Email = textBox27.Text;
            string K_Tlf_nr = textBox26.Text;
            int K_ID = int.Parse(textBox25.Text);
            int EID = int.Parse(textBox24.Text);



            //C(RUD)
            string sSQL = "INSERT INTO KØBER VALUES ('" + K_Fornavn + "', '" + K_Efternavn + "', '" + K_Gadenavn + "', " + K_Gade_nr + ", " + K_Postnummer + ", '" + K_Email
                                                       + "', '" + K_Tlf_nr + "', " + K_ID + ", " + EID + ");";

            MessageBox.Show(sSQL);

            if (test) MessageBox.Show(sSQL);

            SqlCommand command = new SqlCommand(sSQL, conn);
            command.ExecuteNonQuery();

        }


       private void btnKøber_indlæs_Click(object sender, EventArgs e)
        {
            //(C)R(UD)


        }

        private void btnKøber_opdater_Click(object sender, EventArgs e)
        {

        }

        private void btnKøber_slet_Click(object sender, EventArgs e)
        {

        }

        private void txtFra_Romertal_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFRa_Normaltal_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTil_Normaltal_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTil_Romertal_TextChanged(object sender, EventArgs e)
        {

        }

       /* private void btnKonverter_Click(object sender, EventArgs e)
        {
            string romerTalEfter;
            int normalTalEfter;

            int romertal = int.Parse(txtFra_Romertal.Text);
            int normaltal = int.Parse(txtFRa_Normaltal.Text);

            int t = normaltal % 1000;



        }  */

        private void Form1_Load_1(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'semesterprojekt1DataSet.BOLIG' table. You can move, or remove it, as needed.
            this.bOLIGTableAdapter.Fill(this.semesterprojekt1DataSet.BOLIG);
            // TODO: This line of code loads data into the 'semesterprojekt1DataSet.SÆLGER' table. You can move, or remove it, as needed.
            this.sÆLGERTableAdapter.Fill(this.semesterprojekt1DataSet.SÆLGER);
            // TODO: This line of code loads data into the 'semesterprojekt1DataSet.KØBER' table. You can move, or remove it, as needed.
            this.kØBERTableAdapter.Fill(this.semesterprojekt1DataSet.KØBER);

        }

        private void btnsælgeropret_Click(object sender, EventArgs e)
        {
            string S_Fornavn = textBox32.Text;
            string S_Efternavn = textBox31.Text;
            string S_Gadenavn = textBox30.Text;
            int S_Gade_nr = int.Parse(textBox29.Text);
            int S_Postnummer = int.Parse(textBox28.Text);
            string S_Email = textBox27.Text;
            string S_Tlf_nr = textBox26.Text;
            int S_ID = int.Parse(textBox25.Text);
            int EID = int.Parse(textBox24.Text);



            //C(RUD)
            string sSQL = "INSERT INTO KØBER VALUES ('" + S_Fornavn + "', '" + S_Efternavn + "', '" + S_Gadenavn + "', " + S_Gade_nr + ", " + S_Postnummer + ", '" + S_Email
                                                       + "', '" + S_Tlf_nr + "', " + S_ID + ", " + EID + ");";

            MessageBox.Show(sSQL);

            if (test) MessageBox.Show(sSQL);

            SqlCommand command = new SqlCommand(sSQL, conn);
            command.ExecuteNonQuery();

        }

        private void btnsælgerindlæs_Click(object sender, EventArgs e)
        {

        }

        private void btnsælgeropdater_Click(object sender, EventArgs e)
        {

            string S_Fornavn = textBox15.Text;
            string S_Efternavn = textBox16.Text;
            string S_ID = textBox22.Text;
           

           string sSQL = $"UPDATE SÆLGER SET S_Fornavn='{S_Fornavn}' WHERE S_ID = {S_ID}; UPDATE SÆLGER SET S_Efternavn='{S_Efternavn}' WHERE S_ID = {S_ID}";
           SqlCommand command = new SqlCommand(sSQL, conn);
            MessageBox.Show(sSQL);
            command.ExecuteNonQuery();          

        }

        private void btnsælgerslet_Click(object sender, EventArgs e)
        {

            string S_ID = textBox22.Text;

            string sSQL = $"DELETE FROM SÆLGER WHERE S_ID = {S_ID}";
            SqlCommand command = new SqlCommand(sSQL, conn);
            command.ExecuteNonQuery();

        }

        private void btnboligopret_Click(object sender, EventArgs e)
        {
            int B_ID = int.Parse(textBox3.Text);
            int B_Areal = int.Parse(textBox4.Text);
            string B_Gadenavn = textBox5.Text;
            int B_Gade_nr = int.Parse(textBox6.Text);
            int B_postnummer = int.Parse(textBox7.Text);
            string B_type = textBox8.Text;
            int B_værelser = int.Parse(textBox9.Text);
            int udbuds_pris = int.Parse(textBox10.Text);
            int S_ID = int.Parse(textBox11.Text);
            int EID = int.Parse(textBox12.Text);
            int Handels_pris = int.Parse(textBox13.Text);
            string Handels_dato = textBox14.Text;
           // string B_Status = radioButton1.

            string sSQL = "INSERT INTO BOLIG VALUES( " + B_ID + ", " + B_Areal + ", '" + B_Gadenavn + "', " + B_Gade_nr + ", " + B_postnummer
                                                        + ", '" + B_type + "', " + B_værelser + ", " + udbuds_pris + "," + S_ID + "," + EID + ", " + Handels_pris + ", '" + Handels_dato + "')";

            MessageBox.Show(sSQL);

            if (test) MessageBox.Show(sSQL);

            SqlCommand command = new SqlCommand(sSQL, conn);
            command.ExecuteNonQuery();


        }

        private void btnboligindlæs_Click(object sender, EventArgs e)
        {

        }

        private void btnboligopdater_Click(object sender, EventArgs e)
        {
            int Handelspris = int.Parse(textBox13.Text);
            int S_ID = int.Parse(textBox11.Text);

            string sSQL = $"UPDATE BOLIG SET Handels_pris= {Handelspris} WHERE S_ID = {S_ID}; ";
            SqlCommand command = new SqlCommand(sSQL, conn);
            MessageBox.Show(sSQL);
            command.ExecuteNonQuery();
        }

        private void btnboligslet_Click(object sender, EventArgs e)
        {
            string S_ID = textBox11.Text;

            string sSQL = $"DELETE FROM BOLIG WHERE S_ID = {S_ID}";
            SqlCommand command = new SqlCommand(sSQL, conn);
            command.ExecuteNonQuery();
        }

        private void btnkøberopret_Click(object sender, EventArgs e)
        {

        }

        private void btnkøberindlæs_Click(object sender, EventArgs e)
        {

        }

        private void btnkøberopdater_Click(object sender, EventArgs e)
        {

            string K_Fornavn = textBox32.Text;
            string K_Efternavn = textBox31.Text;
            int K_ID = int.Parse(textBox25.Text);


            string sSQL = $"UPDATE KØBER SET K_Fornavn='{K_Fornavn}' WHERE S_ID = {K_ID}; UPDATE KØBER SET K_Efternavn='{K_Efternavn}' WHERE S_ID = {K_ID}";
            SqlCommand command = new SqlCommand(sSQL, conn);
            MessageBox.Show(sSQL);
            command.ExecuteNonQuery();
        }

        private void btnkøberslet_Click(object sender, EventArgs e)
        {

            string K_ID = textBox25.Text;

            string sSQL = $"DELETE FROM KØBER WHERE K_ID = {K_ID}";
            SqlCommand command = new SqlCommand(sSQL, conn);
            command.ExecuteNonQuery();
        }
    }
}


    

