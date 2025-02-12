using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Proiect
{
    public partial class Form1 : Form
    {
        string username;
        string password;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database\SpaceInvaders.mdf;Integrated Security=True;Connect Timeout=30;");

            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM Login WHERE Username='" + textBox1.Text + "' AND Password='" + textBox2.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows[0][0].ToString() == "1")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Login WHERE Username=@username", con);
                cmd.Parameters.AddWithValue("@username", textBox1.Text);
                SqlDataReader red = cmd.ExecuteReader();
                while (red.Read())
                {
                    if (textBox1.Text == red[0].ToString())
                    {
                        LVL.username = red[0].ToString();
                        LVL.level = red[2].ToString();
                        LVL.alevel = LVL.level;
                    }
                }
                con.Close();
                Form3 f3 = new Form3();
                this.Hide();
                f3.Show();
            }
            else
            {
                MessageBox.Show("Invalid credentials!");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            username = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            password = textBox2.Text;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
