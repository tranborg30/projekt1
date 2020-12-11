using System;
using System.Data.SqlClient; // SqlConnection
using System.IO;
using System.Windows.Forms;

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

        // == GROUPBOX ==
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

     
        private void Form1_Load_1(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'semesterprojekt1DataSet.BOLIG' table. You can move, or remove it, as needed.
            this.bOLIGTableAdapter.Fill(this.semesterprojekt1DataSet.BOLIG);
            // TODO: This line of code loads data into the 'semesterprojekt1DataSet.SÆLGER' table. You can move, or remove it, as needed.
            this.sÆLGERTableAdapter.Fill(this.semesterprojekt1DataSet.SÆLGER);
            // TODO: This line of code loads data into the 'semesterprojekt1DataSet.KØBER' table. You can move, or remove it, as needed.
            this.kØBERTableAdapter.Fill(this.semesterprojekt1DataSet.KØBER);

        }

        // == OPRET SÆLGER ==
        private void btnsælgeropret_Click(object sender, EventArgs e)
        {
            string S_Fornavn = textBox15.Text;
            string S_Efternavn = textBox16.Text;
            string S_Gadenavn = textBox17.Text;
            int S_Gade_nr = int.Parse(textBox18.Text);
            int S_Postnummer = int.Parse(textBox19.Text);
            string S_Email = textBox21.Text;
            string S_Tlf_nr = textBox20.Text;
            int S_ID = int.Parse(textBox22.Text);
            int EID = int.Parse(textBox23.Text);

            //C(RUD)
            string sSQL = "INSERT INTO SÆLGER VALUES ('" + S_Fornavn + "', '" + S_Efternavn + "', '" + S_Gadenavn + "', " + S_Gade_nr + ", " + S_Postnummer + ", '" + S_Email
                                                       + "', '" + S_Tlf_nr + "', " + S_ID + ", " + EID + ");";

            MessageBox.Show(sSQL);

            if (test) MessageBox.Show(sSQL);

            SqlCommand command = new SqlCommand(sSQL, conn);
            command.ExecuteNonQuery();

        }

        
        // == OPDATER SÆLGER ==
        private void btnsælgeropdater_Click(object sender, EventArgs e)
        {
            try
            {
                string S_ID = textBox22.Text;
                string S_Email = textBox21.Text;
                string S_Tlf_nr = textBox20.Text;

               string sSQL = $"UPDATE SÆLGER SET S_Tlf_nr='{S_Tlf_nr}' WHERE S_ID = {S_ID}; UPDATE SÆLGER SET S_Email='{S_Email}' WHERE S_ID = {S_ID}";

                SqlCommand command = new SqlCommand(sSQL, conn);
                MessageBox.Show(sSQL);
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("Det er kun muligt at opdatere Telefonnummer og Email.");
            }

        }

        // == SLET SÆLGER ==
        private void btnsælgerslet_Click(object sender, EventArgs e)
        {
            try
            {
                int S_ID = int.Parse(textBox22.Text);
                string sSQL = $"DELETE FROM SÆLGER WHERE S_ID = {S_ID}";
                SqlCommand command = new SqlCommand(sSQL, conn);
                command.ExecuteNonQuery();

                DialogResult Result = MessageBox.Show($"Vil du slette sælger med ID {S_ID} ?", "Er du sikker?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(Result == DialogResult.Yes)
                {
                    MessageBox.Show($"Sælger med ID {S_ID} er blevet slettet.");
                 
                }
                else if( Result == DialogResult.No)
                {
                    return;
                }
              
            }
            catch (Exception)
            {
                MessageBox.Show("Indtast sælger ID for at slette sælger.");
            }

        }

        // == OPRET BOLIG ==
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
            int Handels_pris = int.Parse(textBox13.Text);
            string Handels_dato = textBox14.Text;
            int B_Status = radioButton1.Checked ? 0 : 1;
            int EID = int.Parse(textBox12.Text);
            int S_ID = int.Parse(textBox11.Text);


            string sSQL = "INSERT INTO BOLIG VALUES( " + B_ID + ", " + B_Areal + ", '" + B_Gadenavn + "', " + B_Gade_nr + ", " + B_postnummer
                                                        + ", '" + B_type + "', " + B_værelser + ", " + udbuds_pris + ", " + Handels_pris + ", '" + Handels_dato + "', " + B_Status + ", " + EID + ", " + S_ID + " )";

            MessageBox.Show(sSQL);

            if (test) MessageBox.Show(sSQL);

            SqlCommand command = new SqlCommand(sSQL, conn);
            command.ExecuteNonQuery();


        }

        // == OPDATER BOLIG ==
        private void btnboligopdater_Click(object sender, EventArgs e)
        {

            try {
                int Handelspris = int.Parse(textBox13.Text);
                int B_id = int.Parse(textBox3.Text);

                string sSQL = $"UPDATE BOLIG SET Handels_pris= {Handelspris} WHERE B_ID = {B_id}; ";
                SqlCommand command = new SqlCommand(sSQL, conn);

                MessageBox.Show(sSQL);
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("Kun handelspris kan ændres.");
            }
        }

        // == SLET BOLIG ==
        private void btnboligslet_Click(object sender, EventArgs e)
        {
            int B_ID = int.Parse(textBox3.Text);

           

            DialogResult Result = MessageBox.Show($"Vil du slette bolig med ID {B_ID} ?", "Er du sikker?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Result == DialogResult.Yes)
            { 
                string sSQL = $"DELETE FROM BOLIG WHERE B_ID = {B_ID}";

                SqlCommand command = new SqlCommand(sSQL, conn);
                command.ExecuteNonQuery();
                MessageBox.Show($"Bolig med ID {B_ID} er blevet slettet.");

            }
            
        }

        // == OPRET KØBER ==
        private void btnkøberopret_Click(object sender, EventArgs e)
        {
            string K_Fornavn = textBox32.Text;
            string K_Efternavn = textBox31.Text;
            string K_Gadenavn = textBox30.Text;
            int K_Gade_nr = int.Parse(textBox29.Text);
            int K_Postnummer = int.Parse(textBox28.Text);
            string K_Email = textBox26.Text;
            string K_Tlf_nr = textBox27.Text;
            int K_ID = int.Parse(textBox25.Text);
            int EID = int.Parse(textBox24.Text);

            //C(RUD)
           string sSQL = "INSERT INTO KØBER VALUES ('" + K_Fornavn + "', '" + K_Efternavn + "', '" + K_Gadenavn + "', " + K_Gade_nr + ", " + K_Postnummer + ", '" + K_Email + "', '" + K_Tlf_nr + "', " + K_ID + ", " + EID + ");";
                                                                
            MessageBox.Show(sSQL);

            if (test) MessageBox.Show(sSQL);

            SqlCommand command = new SqlCommand(sSQL, conn);
            command.ExecuteNonQuery();

        }
        
        // == OPDATER KØBER ==
        private void btnkøberopdater_Click(object sender, EventArgs e)
        {

            try
            {
                string K_Email = textBox26.Text;
                int K_ID = int.Parse(textBox25.Text);
                int K_Tlf_nr = int.Parse(textBox27.Text);


                string sSQL = $"UPDATE KØBER SET K_Email='{K_Email}' WHERE K_ID = {K_ID}; UPDATE KØBER SET K_Tlf_nr= {K_Tlf_nr} WHERE K_ID = {K_ID}";
                SqlCommand command = new SqlCommand(sSQL, conn);
                MessageBox.Show(sSQL);
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("Kun Email og Tlfnr kan ændres.");
            }
        }

        // == SLET KØBER ==
        private void btnkøberslet_Click(object sender, EventArgs e)
        {
            try
            {
                int K_ID = int.Parse(textBox25.Text);

                string sSQL = $"DELETE FROM KØBER WHERE K_ID = {K_ID}";
                SqlCommand command = new SqlCommand(sSQL, conn);
                command.ExecuteNonQuery();
                MessageBox.Show($"Køber med ID {K_ID} er blevet slettet");


            }
            catch (Exception)
            {
                MessageBox.Show("Køber kan kun slettes ved at indtaste Køber ID. ");
            }

        }
         // == Statistik over solgte huse med udskrift til text. fil i sorteret reækkefølge efter handelspris ==
       private void button6_Click(object sender, EventArgs e)
        {
            StreamWriter Stream = null;
            String UdFil = "C:\\Users\\Gitte\\Documents\\ProjektSorter.txt";

            try
            {
                Stream = new StreamWriter(UdFil); // open file output
                string Output = "";
                string sSQL = $"SELECT B_ID,  Handels_pris, Handels_dato, udbuds_pris, B_Gadenavn, B_Gade_nr, B_Postnummer, B_Status, SÆLGER_ID FROM BOLIG WHERE B_Status= {1} ORDER BY Handels_pris ASC";

                SqlCommand command = new SqlCommand(sSQL, conn);
                SqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    Output = Output + "B ID:\t\t ".PadRight(20) + reader.GetValue(0) + "\t".PadRight(20) + "Handelspris:\t ".PadRight(20) + reader.GetValue(1) + "\t".PadRight(20) + "Handelsdato:\t ".PadRight(20) + reader.GetValue(2) + "\t".PadRight(20) + 
                                      "Udbudspris: \t ".PadRight(20) + reader.GetValue(3) + "\t".PadRight(20) + "Gadenavn:\t ".PadRight(20) + reader.GetValue(4) + "\t".PadRight(20) + "Gade Nr:\t ".PadRight(20) + reader.GetValue(5) + "\t".PadRight(30) + 
                                      "Postnummer:\t ".PadRight(20) + reader.GetValue(6) + "\t".PadRight(20) + "Status:\t\t " + reader.GetValue(7) + "\t".PadRight(20) + "Sælger ID:\t ".PadRight(20) + reader.GetValue(8) + "\n" + "---------------------------" + "\n";

                }

                MessageBox.Show("Oversigt over solgte huse udskrevet til fil.");

                Stream.Write(Output);
               reader.Close();
            }

            catch (Exception entry)
            {
                MessageBox.Show(entry.Message);
            }
            finally
            {
                if (Stream != null)
                    Stream.Close();// close file
            }
        }

        // == Refresh knap ==
        private void button7_Click(object sender, EventArgs e)
        {
            Form1_Load(sender, e);
        }

        // == Vis boliger efter postnummer ==
        private void btnVisBoliger_Click(object sender, EventArgs e)
        {
            StreamWriter Stream = null;  // skrive til en fil
            String UdFil = "C:\\Users\\Gitte\\Documents\\Projekt.txt";

           try
            {
                Stream = new StreamWriter(UdFil); // open file output

                int B_Postnummer = int.Parse(textBox33.Text);
                string Output = "";
                string sSQL = "SELECT BOLIG.B_ID, BOLIG.B_Gadenavn, BOLIG.B_Gade_nr, BOLIG.udbuds_pris, BOLIG.SÆLGER_ID, SÆLGER.S_Fornavn, SÆLGER.S_Efternavn, SÆLGER.S_Tlf_nr FROM BOLIG JOIN SÆLGER ON BOLIG.SÆLGER_ID = SÆLGER.S_ID WHERE B_Postnummer=" + B_Postnummer;
                SqlCommand command = new SqlCommand(sSQL, conn);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {

                    Output = Output + "Bolig ID: " + reader.GetValue(0) + "\tAdresse: " + reader.GetValue(1) + "\t" + reader.GetValue(2) + "\t  Udbudspris: " + reader.GetValue(3) + "\tSælger ID: " + reader.GetValue(4) + "\tNavn: " + reader.GetValue(5) + " " + reader.GetValue(6) + "\t   Tlfnr: " + reader.GetValue(7) + "\n";
                }
                MessageBox.Show("Succesfuld udskrivning til tekstfil.");
                Stream.WriteLine(Output);
                reader.Close();
            }
            catch (Exception entry)
            {
                MessageBox.Show(entry.Message);
            }
            finally
            {
                if (Stream != null)
                    Stream.Close();// close file
            }
        }

        // == ROMERTAL - KONVERTERING ==
        private void btnKonverter_Click(object sender, EventArgs e)
        {

            string a = Convert.ToString(romTilNorm(txtFraRomertal.Text));
            txtTilTal.Text = a;

            string b = romerTalConverter(Convert.ToInt32(txtFraTal.Text));

            txtTilRomertal.Text = b;
        }



        private static string romerTalConverter(int normalTal)
        {

            string romerTalEfter = "";

            int tu = normalTal / 1000;
            int h = normalTal % 1000 / 100;
            int t = normalTal % 100 / 10;
            int e = normalTal % 10;

            switch (tu)
            {
                case 1:
                    romerTalEfter = romerTalEfter + "M";
                    break;
                case 2:
                    romerTalEfter = romerTalEfter + "MM";
                    break;
                case 3:
                    romerTalEfter = romerTalEfter + "MMM";
                    break;
                default:
                    break;
            }
            switch (h)
            {
                case 1:
                    romerTalEfter = romerTalEfter + "C";
                    break;
                case 2:
                    romerTalEfter = romerTalEfter + "CC";
                    break;
                case 3:
                    romerTalEfter = romerTalEfter + "CCC";
                    break;
                case 4:
                    romerTalEfter = romerTalEfter + "CD";
                    break;
                case 5:
                    romerTalEfter = romerTalEfter + "D";
                    break;
                case 6:
                    romerTalEfter = romerTalEfter + "DC";
                    break;
                case 7:
                    romerTalEfter = romerTalEfter + "DCC";
                    break;
                case 8:
                    romerTalEfter = romerTalEfter + "DCCC";
                    break;
                case 9:
                    romerTalEfter = romerTalEfter + "CM";
                    break;
                default:
                    break;
            }
            switch (t)
            {
                case 1:
                    romerTalEfter = romerTalEfter + "X";
                    break;
                case 2:
                    romerTalEfter = romerTalEfter + "XX";
                    break;
                case 3:
                    romerTalEfter = romerTalEfter + "XXX";
                    break;
                case 4:
                    romerTalEfter = romerTalEfter + "XL";
                    break;
                case 5:
                    romerTalEfter = romerTalEfter + "L";
                    break;
                case 6:
                    romerTalEfter = romerTalEfter + "LX";
                    break;
                case 7:
                    romerTalEfter = romerTalEfter + "LXX";
                    break;
                case 8:
                    romerTalEfter = romerTalEfter + "LXXX";
                    break;
                case 9:
                    romerTalEfter = romerTalEfter + "XC";
                    break;
                default:
                    break;
            }
            switch (e)
            {
                case 1:
                    romerTalEfter = romerTalEfter + "I";
                    break;
                case 2:
                    romerTalEfter = romerTalEfter + "II";
                    break;
                case 3:
                    romerTalEfter = romerTalEfter + "III";
                    break;
                case 4:
                    romerTalEfter = romerTalEfter + "IV";
                    break;
                case 5:
                    romerTalEfter = romerTalEfter + "V";
                    break;
                case 6:
                    romerTalEfter = romerTalEfter + "VI";
                    break;
                case 7:
                    romerTalEfter = romerTalEfter + "VII";
                    break;
                case 8:
                    romerTalEfter = romerTalEfter + "VIII";
                    break;
                case 9:
                    romerTalEfter = romerTalEfter + "IX";
                    break;
                default:
                    break;
            }

            return romerTalEfter;

        }
        private static int romTilNorm(string romTal)
        {
            int sum = 0;

            for (int i = 0; i < romTal.Length; i++)
            {
                if (romTal[i] == 'M')
                {
                    sum = sum + 1000;
                }

                if (romTal[i] == 'C')
                {
                    sum = sum + 100;
                }

                if (romTal[i] == 'D')
                {
                    sum = sum + 500;
                }

                if (romTal[i] == 'L')
                {
                    sum = sum + 50;
                }

                if (romTal[i] == 'X')
                {
                    sum = sum + 10;
                }

                if (romTal[i] == 'V')
                {
                    sum = sum + 5;
                }

                if (romTal[i] == 'I')
                {
                    sum = sum + 1;
                }

            }

            if (romTal.Contains("CM"))
            {
                sum = sum - 200;
            }

            if (romTal.Contains("CD"))
            {
                sum = sum - 200;
            }

            if (romTal.Contains("XC"))
            {
                sum = sum - 20;
            }

            if (romTal.Contains("XL"))
            {
                sum = sum - 20;
            }

            if (romTal.Contains("IX"))
            {
                sum = sum - 2;
            }

            if (romTal.Contains("IV"))
            {
                sum = sum - 2;
            }

            return sum;

        }






        // == SØG BOLIGER EFTER DATO OG HANDELSPRIS ==
        private void btnSøg_Click(object sender, EventArgs e) {

            Hus[] huse = new Hus[100];
            int tæller = 0;
            int FraDato = int.Parse(txtFraDato.Text);
            int TilDato = int.Parse(txtTilDato.Text);
            int ønsketPris = int.Parse(ØnsketSøgePris.Text);
            string tekst = "";
            string sSql = $"SELECT B_ID, B_Gadenavn, B_Gade_nr,Handels_pris, Handels_dato, B_Status FROM BOLIG WHERE Handels_dato >= {FraDato} AND Handels_dato <= {TilDato};";

                SqlCommand command = new SqlCommand(sSql, conn);
                SqlDataReader reader = command.ExecuteReader();

                
                while (reader.Read())
                {
                huse[tæller] = new Hus(reader.GetInt32(0), reader.GetInt32(3), reader.GetInt32(5));
               
                    if (ønsketPris < huse[tæller].handelsPris && huse[tæller].status == 1){
                    tekst = $"{tekst}Bolig ID: {huse[tæller].id} \nSalgspris: {huse[tæller].handelsPris} \n\n";
                    }

                tæller = tæller + 1;
                }

                reader.Close();
                

                MessageBox.Show(tekst);
            }

                 
            private void label41_Click(object sender, EventArgs e)
            {

            }

        
        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        // == TOOLTIP ON HOVER ==
        private void btnkøberopdater_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Indtast køber ID, Telefonnummer og Email for at opdatere.", btnkøberopdater);
        }

        private void btnboligslet_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Indtast bolig ID for at slette.", btnboligslet);
        }

        private void btnsælgeropdater_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Indtast Sælger ID samt Telefonnummer og Email.", btnsælgeropdater);
        }

        private void btnboligopdater_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Indtast bolig ID og handelspris for at opdatere.", btnboligopdater);
        }
    }
    }