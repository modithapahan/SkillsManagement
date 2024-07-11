using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace StudentManagementSystem
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
            LoadRegistrationNumber();
        }

        // SQL Connection
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-EQ7FR1M\\SQLEXPRESSCUSTOM;Initial Catalog=Student;Integrated Security=True;TrustServerCertificate=True");

        private bool isLoggedin = false;
        private string username;

        //Logout Function
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.isLoggedin = false;
            this.username = null;

            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        //Get for the get registration number
        private void LoadRegistrationNumber()
        {
            cbRegNo.Items.Clear();
            string query = "SELECT regNo FROM Registration";

            try
            {
                using (SqlConnection connection = new SqlConnection(con.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cbRegNo.Items.Add(reader["regNo"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Show register Numbers
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedNumber = cbRegNo.SelectedItem.ToString();
            LoadDetails(selectedNumber);
        }

        //Fetch all the details from the database related to the register number
        private void LoadDetails(string regNo)
        {
            string query = "SELECT * FROM Registration WHERE regNo = @regNo";

            try
            {
                using (SqlConnection connection = new SqlConnection(con.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@regNo", regNo);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtFirstName.Text = reader["firstName"].ToString();
                                txtLastName.Text = reader["lastName"].ToString();
                                dob.Text = reader["dateOfBirth"].ToString();

                                string gender = reader["gender"].ToString();
                                if (gender == "Male")
                                {
                                    male.Checked = true;
                                }
                                else
                                {
                                    female.Checked = true;
                                }

                                txtAddress.Text = reader["address"].ToString();
                                txtEmail.Text = reader["email"].ToString();
                                txtMobilePhone.Text = reader["mobilePhone"].ToString();
                                txtHomePhone.Text = reader["homePhone"].ToString();
                                txtParentName.Text = reader["parentName"].ToString();
                                txtParentNIC.Text = reader["nic"].ToString();
                                txtParentMobile.Text = reader["contactNo"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        //Clear Details
        private void button3_Click(object sender, EventArgs e)
        {
            Clear();
            txtFirstName.Focus();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        //Exit Function
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult res;
            res = MessageBox.Show("Are you sure, Do you really want to Exit...?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (res == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                this.Show();
            }
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        //clear texbox values
        private void Clear()
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            dob.ResetText();
            male.Checked = false;
            female.Checked = false;
            txtAddress.Clear();
            txtEmail.Clear();
            txtMobilePhone.Clear();
            txtHomePhone.Clear();
            txtParentName.Clear();
            txtParentNIC.Clear();
            txtParentMobile.Clear();
            cbRegNo.ResetText();
        }

        //Register Function
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValid() == true)
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Registration values (@firstName, @lastName, @dateOfBirth, @gender, @address, @email, @mobilePhone, @homePhone, @parentName, @nic, @contactNo)", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@firstName", txtFirstName.Text);
                    cmd.Parameters.AddWithValue("@lastName", txtLastName.Text);
                    cmd.Parameters.AddWithValue("@dateOfBirth", dob.Text);
                    cmd.Parameters.AddWithValue("@gender", male.Checked ? "Male" : female.Checked ? "Female" : "");
                    cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@mobilePhone", txtMobilePhone.Text);
                    cmd.Parameters.AddWithValue("@homePhone", txtHomePhone.Text);
                    cmd.Parameters.AddWithValue("@parentName", txtParentName.Text);
                    cmd.Parameters.AddWithValue("@nic", txtParentNIC.Text);
                    cmd.Parameters.AddWithValue("@contactNo", txtParentMobile.Text);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Record Added Successfully", "Register Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadRegistrationNumber();

                    Clear();
                    txtFirstName.Focus();
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Simple Validation
        private bool IsValid()
        {
            if (txtFirstName.Text == string.Empty || txtEmail.Text == string.Empty || txtParentMobile.Text == string.Empty)
            {
                MessageBox.Show("Pleae fill all the necessaty details", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFirstName.Focus();
                return false;
            }
            return true;
        }

        private void male_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void female_CheckedChanged(object sender, EventArgs e)
        {

        }

        //Update Details 
        private void button1_Click(object sender, EventArgs e)
        {
            string regNo = cbRegNo.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(regNo))
            {
                MessageBox.Show("Please select a registration number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (IsValid() == true)
                {
                    string query = "UPDATE Registration SET firstName = @firstName, lastName = @lastName, dateOfBirth = @dateOfBirth, gender = @gender, address = @address, email = @email, mobilePhone = @mobilePhone, homePhone = @homePhone, parentName = @parentName, nic = @nic, contactNo = @contactNo WHERE regNo = @regNo";

                    using (SqlConnection connection = new SqlConnection(con.ConnectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@firstName", txtFirstName.Text);
                            cmd.Parameters.AddWithValue("@lastName", txtLastName.Text);
                            cmd.Parameters.AddWithValue("@dateOfBirth", dob.Text);
                            cmd.Parameters.AddWithValue("@gender", male.Checked ? "Male" : female.Checked ? "Female" : "");
                            cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                            cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                            cmd.Parameters.AddWithValue("@mobilePhone", txtMobilePhone.Text);
                            cmd.Parameters.AddWithValue("@homePhone", txtHomePhone.Text);
                            cmd.Parameters.AddWithValue("@parentName", txtParentName.Text);
                            cmd.Parameters.AddWithValue("@nic", txtParentNIC.Text);
                            cmd.Parameters.AddWithValue("@contactNo", txtParentMobile.Text);
                            cmd.Parameters.AddWithValue("@regNo", regNo);

                            connection.Open();
                            cmd.ExecuteNonQuery();
                            connection.Close();
                        }
                    }
                    MessageBox.Show("Record Updated Successfully", "Register Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Delete Details
        private void button4_Click(object sender, EventArgs e)
        {
            string regNo = cbRegNo.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(regNo))
            {
                MessageBox.Show("Please select a registration number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult res = MessageBox.Show("Are you sure, Do you really want to delete this record?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (res == DialogResult.Yes)
            {
                try
                {
                    string query = "DELETE FROM Registration WHERE regNo = @regNo";
                    using (SqlConnection connection = new SqlConnection(con.ConnectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@regNo", regNo);

                            connection.Open();
                            int rowsAffected = cmd.ExecuteNonQuery();
                            connection.Close();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Record Deleted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                cbRegNo.Items.Remove(regNo);
                                Clear();
                                
                            }
                            else
                            {
                                MessageBox.Show("No records were deleted. Please check the registration number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
