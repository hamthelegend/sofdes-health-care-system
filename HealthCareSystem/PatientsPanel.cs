using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HealthCareSystem
{
    public partial class PatientsPanel : Form
    {
        public PatientsPanel()
        {
            InitializeComponent();
        }

        private void updateList(string query)
        {
            SqlConnection con = new SqlConnection(Properties.Resources.connectionString);
            SqlCommand command = con.CreateCommand();
            con.Open();
            command.CommandText = "SELECT patient_id, patient_name, patient_phone FROM patient WHERE patient_name LIKE @query OR patient_phone LIKE @query";
            command.Parameters.AddWithValue("@query", query + "%");
            SqlDataReader reader = command.ExecuteReader();
            patientsListBox.Items.Clear();
            while (reader.Read())
            {
                patientsListBox.Items.Add(new Patient(reader.GetInt32(0), reader.GetString(1), reader.GetString(2)));
            }
            con.Close();
        }

        private void PatientsPanel_Load(object sender, EventArgs e)
        {
            updateList("");
        }

        private void searchInput_TextChanged(object sender, EventArgs e)
        {
            updateList(searchInput.Text);
        }

        private void patientsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int patient_id;
            try
            {
                patient_id = ((Patient)patientsListBox.SelectedItem).id;
            }
            catch (Exception)
            {
                return;
            }
            SqlConnection con = new SqlConnection(Properties.Resources.connectionString);
            SqlCommand command = con.CreateCommand();
            command.CommandText = "SELECT * FROM patient WHERE patient_id=@id";
            command.Parameters.AddWithValue("@id", patient_id);
            con.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                patientIdInput.Text = reader.GetInt32(0).ToString();
                nameInput.Text = reader.GetString(1);
                var dob = reader.GetValue(2);
                try
                {
                    dobInput.Value = (DateTime)dob;
                }
                catch (InvalidCastException)
                {
                    dobInput.Value = dobInput.MinDate;
                }
                phoneInput.Text = reader.GetString(3);
                notesInput.Text = reader.GetString(4);
                patientCreationDateBox.Text = reader.GetValue(5).ToString();
            }
            con.Close();

        }

        private void createButton_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Resources.connectionString);
            SqlCommand command = con.CreateCommand();
            con.Open();
            if (nameInputCreate.Text.Length > 0)
            {
                //create an account
                command.CommandText = "INSERT INTO patient (patient_name, patient_phone, patient_notes, patient_creation_date) VALUES(@name, @phone, @notes, @creationDate)";
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@name", nameInputCreate.Text);
                command.Parameters.AddWithValue("@phone", phoneInputCreate.Text);
                command.Parameters.AddWithValue("@notes", notesInputCreate.Text);
                command.Parameters.AddWithValue("@creationDate", DateTime.Now);
                if (command.ExecuteNonQuery() > 0)
                {
                    //Can create and load the account
                    MessageBox.Show("Patient Successfully Created");
                    clearCreateFields();
                }
                else
                {
                    MessageBox.Show("Error while creating the account");
                }
            }
            else
            {
                MessageBox.Show("Name cannot be empty");
            }
            con.Close();
            updateList("");
        }

        SqlConnection con = new SqlConnection(Properties.Resources.connectionString);
        private void updateButton_Click(object sender, EventArgs e)
        {
            if (nameInput.Text == "")
            {
                MessageBox.Show("Name field required!");
                return;
            }

            SqlCommand command = con.CreateCommand();
            command.CommandText = "UPDATE patient SET patient_name=@name, patient_dob=@dob, patient_phone=@phone, patient_notes=@notes WHERE patient_id=@id";
            command.Parameters.AddWithValue("@name", nameInput.Text);
            command.Parameters.AddWithValue("@dob", dobInput.Value);
            command.Parameters.AddWithValue("@phone", phoneInput.Text);
            command.Parameters.AddWithValue("@notes", notesInput.Text);
            command.Parameters.AddWithValue("@id", patientIdInput.Text);
            con.Open();
            if (command.ExecuteNonQuery() > 0)
            {
                //we can update the account
                MessageBox.Show("Patient successfully updated!");
            }
            else
            {
                MessageBox.Show("Error updating the patient!");
            }
            con.Close();
            updateList(searchInput.Text);
        }

        void clearCreateFields()
        {
            nameInputCreate.Text =
                phoneInputCreate.Text =
                    notesInputCreate.Text = "";
        }
    }
}
