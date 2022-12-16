using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace patient_registration_system
{
    public partial class Registerpage : Form
    {
        string patientname;
        string patientsurname;
        string patientid;
        string phone;
        string adress;
        string diagnosis;
        string usedmedicine;
        string doctorname;
        string allergy;
        string bloodgroup;
        string search;
        List<string> doctors=new List<string>();
        public Registerpage()
        {
            InitializeComponent();

        }

        private void Registerpage_Load(object sender, EventArgs e)
        {

            KisiGetir();

            string myConnectionString;
            MySql.Data.MySqlClient.MySqlConnection conn;

            myConnectionString = "server=127.0.0.1;uid=root;pwd=Graniti27_;database=patientlogin";
            conn = new MySql.Data.MySqlClient.MySqlConnection(myConnectionString);
            MySqlConnection MyConn2 = new MySqlConnection(myConnectionString);
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT *FROM patientregisterpage", MyConn2);
            DataTable tablo = new DataTable();
            conn.Open();
           adapter.Fill(tablo);
            dataGridView1.DataSource = tablo;

            MySqlConnection con = new MySqlConnection("server=127.0.0.1;uid=root;pwd=Graniti27_;database=patientlogin"); // making connection
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM patientregisterpage", con);
            MySqlDataReader mySqlDataReader = cmd.ExecuteReader();
            MySqlDataReader reader = mySqlDataReader;        
            while (reader.Read())
            {
              doctors.Add(reader["doctorname"].ToString());
                doctors.Add("Opr.Dr.Ahmet Coşkun Uzay");
                doctors.Add("Prof Dr Enver Altaş");
                doctors.Add("Doç. Dr. Ragıp Kayar");
                doctors.Add("Opr. Dr. Mustafa Kertmen");
             
            }
            foreach(var doctor in doctors)
            {
                if (!comboBox1.Items.Contains(doctor))
                {
                    comboBox1.Items.Add(doctor);
                }
            }
            dataGridView1.DataSource = tablo;
            conn.Close();
            MyConn2.Close();
        
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            patientname = textBox1.Text;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            KisiGetir();
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox9.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox10.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            textBox11.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();

        }
        private void KisiGetir()
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString;
            myConnectionString = "server=127.0.0.1;uid=root;pwd=Graniti27_;database=patientlogin";
            conn = new MySql.Data.MySqlClient.MySqlConnection(myConnectionString);
            MySqlConnection MyConn2 = new MySqlConnection(myConnectionString);
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT *FROM patientregisterpage", MyConn2);
            DataTable tablo = new DataTable();
            conn.Open();
            adapter.Fill(tablo);
            dataGridView1.DataSource = tablo;
            conn.Close();
        }
        private void DisplayandSearch(string id)
        {

            String myConnectionString = "server=127.0.0.1;uid=root;pwd=Graniti27_;database=patientlogin";
            string Query = "select * from patientlogin.patientregisterpage where patientid=@id";
            if (id == null || id == "")
            {
                Query = "select * from patientlogin.patientregisterpage ";
            }
            MySql.Data.MySqlClient.MySqlConnection conn;
            conn = new MySql.Data.MySqlClient.MySqlConnection(myConnectionString);
            MySqlConnection MyConn3 = new MySqlConnection(myConnectionString);
            //This is command class which will handle the query and connection object.
            MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn3);
        
            MyConn3.Open();
            MyCommand2.Parameters.AddWithValue("@id", id); 
            // Here our query will be executed and data saved into the database.
            DataTable tablo3 = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(MyCommand2);
            adapter.Fill(tablo3);
            dataGridView1.DataSource = tablo3;
            MyConn3.Close();
           

        }
        private void delete(string id)
        {
            String myConnectionString = "server=127.0.0.1;uid=root;pwd=Graniti27_;database=patientlogin";
            string Query = "delete from patientlogin.patientregisterpage where patientid=@id";
            MySql.Data.MySqlClient.MySqlConnection conn;
            
            conn = new MySql.Data.MySqlClient.MySqlConnection(myConnectionString);
            MySqlConnection MyConn3 = new MySqlConnection(myConnectionString);
            MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn3);
            MyConn3.Open();
            MyCommand2.Parameters.AddWithValue("@id", id);
            MyCommand2.ExecuteNonQuery();
            MyConn3.Close();
            //This is command class which will handle the query and connection object.
           

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            patientsurname = textBox2.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            patientid = textBox3.Text;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            phone = textBox6.Text;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            adress = textBox4.Text;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            diagnosis = textBox7.Text;
        }
 

        private void label10_Click(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {

            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString;

            myConnectionString = "server=127.0.0.1;uid=root;pwd=Graniti27_;database=patientlogin";

            try
            {
                string Query = "insert into patientlogin.patientregisterpage(patientname,patientsurname,phone,adress,diagnosis,doctorname,usedmedicine,patientid,allergy,bloodgroup) values('" + patientname + "','" + patientsurname + "','" + phone + "','" + adress + "','" + diagnosis + "','" + doctorname + "','" + usedmedicine + "','" + patientid + "','" + allergy + "','" + bloodgroup + "')";
                //This is  MySqlConnection here i have created the object and pass my connection string.
                MySqlConnection MyConn2 = new MySqlConnection(myConnectionString);
                //This is command class which will handle the query and connection object.
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();

                MyReader2 = MyCommand2.ExecuteReader();     // Here our query will be executed and data saved into the database.
                MyConn2.Close();
                MessageBox.Show("sucessfully saved");
               
            }
            catch (Exception)
            {

                MessageBox.Show("registration unsucessfull");
            }
            KisiGetir();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            try
            {
                MySql.Data.MySqlClient.MySqlConnection conn;
                string myConnectionString;

                myConnectionString = "server=127.0.0.1;uid=root;pwd=Graniti27_;database=patientlogin";
                Registerpage registerpage = new Registerpage();
                MySql.Data.MySqlClient.MySqlConnection conn2;
                string myconnectionString;
                myConnectionString = "server=127.0.0.1;uid=root;pwd=Graniti27_;database=patientlogin";
                string UpdateQuery = "UPDATE patientregisterpage set patientname=@patientname,patientsurname=@patientsurname,patientid=@patientid,phone=@phone,adress=@adress,diagnosis=@diagnosis,doctorname=@doctorname,usedmedicine=@usedmedicine,patientid=@patientid,allergy=@allergy,bloodgroup=@bloodgroup where patientname=@patientname ";

                MySqlConnection MyConn2 = new MySqlConnection(myConnectionString);
                //This is command class which will handle the query and connection object.
                MySqlCommand MyCommand2 = new MySqlCommand(UpdateQuery, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                MyCommand2.Parameters.AddWithValue("@patientname", patientname);
                MyCommand2.Parameters.AddWithValue("@patientsurname", patientsurname);
                MyCommand2.Parameters.AddWithValue("@patientid", patientid);
                MyCommand2.Parameters.AddWithValue("@phone", phone);
                MyCommand2.Parameters.AddWithValue("@adress", adress);
                MyCommand2.Parameters.AddWithValue("@diagnosis", diagnosis);
                MyCommand2.Parameters.AddWithValue("@doctorname", doctorname);
                MyCommand2.Parameters.AddWithValue("@usedmedicine", usedmedicine);
                MyCommand2.Parameters.AddWithValue("@allergy", allergy);
                MyCommand2.Parameters.AddWithValue("@bloodgroup", bloodgroup);
                MyCommand2.ExecuteNonQuery();
                // Here our query will be executed and data saved into the database.
                MyConn2.Close();
                KisiGetir();
                MessageBox.Show("sucessfully Updated");
            }
            catch (Exception)
            {
                MessageBox.Show("unsucessfully updated");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            doctorname = comboBox1.Text;
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            search = textBox8.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DisplayandSearch(search);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            delete(search);
            KisiGetir();
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            bloodgroup = textBox11.Text;
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            allergy=textBox10.Text;
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            usedmedicine = textBox9.Text;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dataGridView1.CurrentRow.Selected = true;
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["patientname"].FormattedValue.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["patientsurname"].FormattedValue.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["patientid"].FormattedValue.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["adress"].FormattedValue.ToString();
                textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells["phone"].FormattedValue.ToString();
                textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells["diagnosis"].FormattedValue.ToString();
                textBox9.Text = dataGridView1.Rows[e.RowIndex].Cells["usedmedicine"].FormattedValue.ToString();
                textBox10.Text = dataGridView1.Rows[e.RowIndex].Cells["allergy"].FormattedValue.ToString();
                textBox11.Text = dataGridView1.Rows[e.RowIndex].Cells["bloodgroup"].FormattedValue.ToString();
            }
        }
    }
    
}
