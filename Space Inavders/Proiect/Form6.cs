using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
            if(LVL.yw==true)
            {
                this.BackColor = Color.DarkOrange;
                this.label1.Text = "You Won!";
                this.label1.BackColor = Color.DarkOrange;
                this.label1.ForeColor = Color.White;
                this.button1.BackColor = Color.DarkOrange;
                this.button1.Text = "Next level";
                this.button2.BackColor = Color.DarkOrange;
            }
            else
            {
                this.BackColor = Color.Red;
                this.label1.Text = "You Lost!";
                this.label1.BackColor = Color.Red;
                this.label1.ForeColor = Color.White;
                this.button1.BackColor = Color.Red;
                this.button1.Text = "Restart";
                this.button2.BackColor = Color.Red;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(LVL.yw==true)
            {
                if(Int32.Parse(LVL.alevel)<10)
                LVL.alevel = (Int32.Parse(LVL.alevel) + 1).ToString();
                Form5 f5 = new Form5();
                this.Close();
                f5.Show();
            }
            else
            {
                Form5 f5 = new Form5();
                this.Close();
                f5.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            this.Close();
            f3.Show();
        }
    }
}
