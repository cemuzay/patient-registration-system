using Microsoft.VisualBasic.ApplicationServices;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
namespace patient_registration_system
{
    public partial class Form1 : Form
    {
        string id;
        string name;
        String password;
        public Form1()
        {


            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {

            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString;

            myConnectionString = "server=127.0.0.1;uid=root;pwd=Graniti27_;database=patientlogin";

            try
            {
                string Query = "insert into patientlogin.patientlog(User_name,Password) values('" + name  + "','"  + password + "'); ";

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
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            name = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            password=textBox2.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("server=127.0.0.1;uid=root;pwd=Graniti27_;database=patientlogin"); // making connection
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM patientlog WHERE User_name='" + name + "' AND Password='" + password + "'", con);
            /* in above line the program is selecting the whole data from table and the matching it with the user name and password provided by user. */
            
            try
            {
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                    {
                    /* I have made a new page called home page. If the user is successfully authenticated then the form will be moved to the next form */
                    Registerpage registerpage = new Registerpage();
                    //MessageBox.Show("successful login ");
                    this.Hide();
                    registerpage.Show();
                }
                else
                {
                    MessageBox.Show("Invalid username or password");
                }
               
                   
                
            }
            catch(Exception)
            {
                MessageBox.Show("query not working");
            }
           
             
        }
       
    }
}