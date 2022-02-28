using System;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace Messenger
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {

            ;
            if (string.IsNullOrEmpty(textbox_regName.Text) || string.IsNullOrEmpty(textbox_regPass.Text))
            {
                MessageBox.Show("Please Enter your name and password");
            }
            else
            {

                if (!IsNotOriginal(textbox_regName.Text) == false)
                    MessageBox.Show("This User Already Exists");
                else
                if (textbox_regName.Text.Contains(" ") || textbox_regName.Text.Contains("_") || textbox_regName.Text.Contains("."))
                    MessageBox.Show("Please use only Letters and Nubmers, Thanks");
                else
                {
                    AddUser(textbox_regName.Text, textbox_regPass.Text);
                    MessageBox.Show("Account Created, now you may Log In.");
                    this.textbox_regName.Clear();
                    this.textbox_regPass.Clear();

                }

            }
        }

        public static SqlConnection Openconnection()
        {
            try
            {

                string path = System.IO.Directory.GetParent(System.IO.Directory.GetParent(Environment.CurrentDirectory).FullName).FullName + "\\Database1.mdf";


                var connectionString = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={path};Integrated Security=True";
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                return connection;




            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to connect to the database.");
                return null;
            }

        }
        public static bool IsNotOriginal(string name)
        {
            SqlConnection connection = Openconnection();
            SqlCommand find = new SqlCommand("SELECT * FROM [Table] WHERE Name = @tname", connection);
            find.Parameters.AddWithValue("@tname", name);
            SqlDataReader reader = find.ExecuteReader();
            bool a = reader.Read();
            reader.Close();
            connection.Close();
            return a;

        }
        public static void AddUser(string name, string password)
        {
            SqlConnection connection = Openconnection();
            SqlCommand find = new SqlCommand($"INSERT INTO [Table] (Name, Password) VALUES (@tname,@tpassword)", connection);
            find.Parameters.AddWithValue("@tname", name);
            find.Parameters.AddWithValue("@tpassword", password);
            find.ExecuteNonQuery();
            connection.Close();
        }

        public static bool PasswordCorrect(string name, string password)
        {
            string bdpass = "";
            SqlConnection connection = Openconnection();
            SqlCommand find = new SqlCommand("SELECT Password FROM [Table] WHERE Name = @tname", connection);
            find.Parameters.AddWithValue("@tname", name);
            SqlDataReader reader = find.ExecuteReader();
            while (reader.Read())
            {
                bdpass = reader["Password"].ToString();
            }
            reader.Close();

            return bdpass == password;



        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textbox_login_Name.Text) || string.IsNullOrEmpty(textbox_login_pass.Text))
            {
                MessageBox.Show("Please Enter your name and password");
            }
            else
            {

                if (IsNotOriginal(textbox_login_Name.Text) == false)
                    MessageBox.Show("This User Does not Exists, Check the Name or Create new Account.");
                else
                {
                    if (PasswordCorrect(textbox_login_Name.Text, textbox_login_pass.Text))
                    {
                        string path = System.IO.Directory.GetParent(System.IO.Directory.GetParent(Environment.CurrentDirectory).FullName).FullName + "/UserData/" + textbox_login_Name.Text;

                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        this.Visible= false;

                        Messenger f = new Messenger(textbox_login_Name.Text);
                        f.ShowDialog();

                        


                    }
                    else
                    {
                        MessageBox.Show("Incorrect Password.");
                    }
                }

            }


        }

    }
}
