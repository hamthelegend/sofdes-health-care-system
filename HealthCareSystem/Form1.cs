using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HealthCareSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Resources.connectionString);
            SqlCommand command = con.CreateCommand();
            command.CommandText = "SELECT user_id from [user] WHERE user_username=@username and user_password=@password";
            command.Parameters.AddWithValue("@username",txtUsername.Text);
            command.Parameters.AddWithValue("@password", txtPassword.Text);
            con.Open();
            var results = command.ExecuteScalar();
            con.Close();
            if (results != null)
            {
                if (txtUsername.Text == "admin")
                {
                    MessageBox.Show("Admin Login Successful!");  //admin account
                    this.Hide();
                    AdminPanel adminPanel = new AdminPanel();
                    adminPanel.ShowDialog();
                    this.Show();
                }
                else
                {
                    con.Open();
                    command.CommandText = "SELECT account_id, account_type FROM account WHERE account_user_id=@user_id";
                    command.Parameters.AddWithValue("@user_id",results.ToString());
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        int account_id = reader.GetInt32(0);
                        int account_type = reader.GetInt32(1);
                        if (account_type == 0)
                        {
                            //login for secretary
                            MessageBox.Show("Secretary Login Successfull!");
                            this.Hide();
                            SecretaryPanel secretaryPanel = new SecretaryPanel(account_id);
                            secretaryPanel.ShowDialog();
                            this.Show();
                        }
                        else if (account_type == 1)
                        {
                            //login for doctor
                            MessageBox.Show("Doctor Login Successfull!");
                            
                            this.Hide();
                            DoctorPanel doctorPanel = new DoctorPanel(account_id);
                            doctorPanel.ShowDialog();
                            this.Show();
                        }
                    }
                    con.Close();
                }
                
            }
            else
            {
                MessageBox.Show("Login Failed!");
            }

           

        }
    }
}
