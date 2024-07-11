using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace StudentManagementSystem
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        // SQL Connection
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-EQ7FR1M\\SQLEXPRESSCUSTOM;Initial Catalog=Student;Integrated Security=True;TrustServerCertificate=True");

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Login_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        //Show Password Function
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = showPass.Checked ? '\0' : '*';
        }

        //Exit Function
        private void button3_Click(object sender, EventArgs e)
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

        //Login Function
        private void button2_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (CheckCredentials(username, password))
            {
                Register reg = new Register();
                reg.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Login credentials, please check Username and password and try again", "Invalid login Details", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Clear();
                txtUsername.Focus();
            }
        }

        // Check Login Details
        private bool CheckCredentials(string username, string password)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(con.ConnectionString))
                {
                    connection.Open();
                    string query = "SELECT COUNT(1) FROM Logins WHERE username = @username AND password = @password";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@Password", password);

                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count == 1;
                    }
                }               
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred", ex.Message);
                return false;
            }
        }

        private void Clear() 
        {
            txtUsername.Clear();
            txtPassword.Clear();
        }

        //Clear Function
        private void button1_Click(object sender, EventArgs e)
        {
            Clear();
            txtUsername.Focus();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
