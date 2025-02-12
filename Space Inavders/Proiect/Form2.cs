using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace Proiect
{
    public partial class Form2 : Form
    {
        private SqlConnection con;

        // Hide labels initially
        void Hide_labels()
        {
            label1.Hide();
            label2.Hide();
            label3.Hide();
        }

        public Form2()
        {
            InitializeComponent();
            Hide_labels();
        }

        // Reset text when user clicks on a textbox
        private void textBox1_Click(object sender, EventArgs e) { textBox1.Text = ""; }
        private void textBox2_Click(object sender, EventArgs e) { textBox2.Text = ""; }
        private void textBox3_Click(object sender, EventArgs e) { textBox2.Text = ""; }
        private void textBox4_Click(object sender, EventArgs e) { textBox3.Text = ""; }
        private void textBox5_Click(object sender, EventArgs e) { }

        // TextChanged event handlers (you can remove or implement them if needed)
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void textBox3_TextChanged(object sender, EventArgs e) { }
        private void textBox4_TextChanged(object sender, EventArgs e) { }
        private void textBox5_TextChanged(object sender, EventArgs e) { }

        // Validate if the username already exists in the database
        bool username_valid()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database\SpaceInvaders.mdf;Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) From Login where Username='" + textBox1.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt.Rows[0][0].ToString() == "0";  // Return true if username doesn't exist
        }

        // Handle account creation logic
        private void button1_Click(object sender, EventArgs e)
        {
            Hide_labels();

            // Check if the username is valid (not already taken)
            if (username_valid())
            {
                // Check if the password and confirmation password match
                if (textBox2.Text == textBox3.Text)
                {
                    // Open connection to the database
                    con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database\SpaceInvaders.mdf;Integrated Security=True;Connect Timeout=30;");

                    // Insert query for creating a new user (setting level 1 by default)
                    string InsertQuery = "INSERT INTO Login (Username, Password, Level) VALUES (@Username, @Password, @Level)";
                    con.Open();
                    SqlCommand command = new SqlCommand(InsertQuery, con);
                    command.Parameters.AddWithValue("@Username", textBox1.Text);
                    command.Parameters.AddWithValue("@Password", textBox2.Text);
                    command.Parameters.AddWithValue("@Level", 1); // Default level set to 1

                    // Execute the query
                    int i = command.ExecuteNonQuery();
                    con.Close();
                    command.Dispose();

                    // Show success message and go back to login screen
                    MessageBox.Show("Account created successfully!");
                    Form1 f1 = new Form1();
                    this.Close();
                    f1.Show();
                }
                else
                {
                    // Show error if passwords do not match
                    label3.Show();
                }
            }
            else
            {
                // Show error if username already exists
                label1.Show();
            }
        }
    }
}
