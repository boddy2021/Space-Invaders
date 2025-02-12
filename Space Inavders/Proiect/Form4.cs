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
    public partial class Form4 : Form
    {
        public Form4()
        {
            
            InitializeComponent();
            if(Int32.Parse(LVL.level) >= Int32.Parse(button1.Text))
            {
                button1.BackColor = Color.Green;
                button1.Cursor = Cursors.Hand;
            }
            else
            {
                button1.BackColor = Color.Red;
                button1.Cursor = Cursors.Default;
            }


            if (Int32.Parse(LVL.level) >= Int32.Parse(button2.Text))
            {
                button2.BackColor = Color.Green;
                button2.Cursor = Cursors.Hand;
            }
            else
            {
                button2.BackColor = Color.Red;
                button2.Cursor = Cursors.Default;
            }



            if (Int32.Parse(LVL.level) >= Int32.Parse(button3.Text))
            {
                button3.BackColor = Color.Green;
                button3.Cursor = Cursors.Hand;
            }
            else
            {
                button3.BackColor = Color.Red;
                button3.Cursor = Cursors.Default;
            }



            if (Int32.Parse(LVL.level) >= Int32.Parse(button4.Text))
            {
                button4.BackColor = Color.Green;
                button4.Cursor = Cursors.Hand;
            }
            else
            {
                button4.BackColor = Color.Red;
                button4.Cursor = Cursors.Default;
            }



            if (Int32.Parse(LVL.level) >= Int32.Parse(button5.Text))
            {
                button5.BackColor = Color.Gold;
                button5.Cursor = Cursors.Hand;
            }
            else
            {
                button5.BackColor = Color.Red;
                button5.Cursor = Cursors.Default;
            }



            if (Int32.Parse(LVL.level) >= Int32.Parse(button6.Text))
            {
                button6.BackColor = Color.Green;
                button6.Cursor = Cursors.Hand;
            }
            else
            {
                button6.BackColor = Color.Red;
                button6.Cursor = Cursors.Default;
            }



            if (Int32.Parse(LVL.level) >= Int32.Parse(button7.Text))
            {
                button7.BackColor = Color.Green;
                button7.Cursor = Cursors.Hand;
            }
            else
            {
                button7.BackColor = Color.Red;
                button7.Cursor = Cursors.Default;
            }



            if (Int32.Parse(LVL.level) >= Int32.Parse(button8.Text))
            {
                button8.BackColor = Color.Green;
                button8.Cursor = Cursors.Hand;
            }
            else
            {
                button8.BackColor = Color.Red;
                button8.Cursor = Cursors.Default;
            }



            if (Int32.Parse(LVL.level) >= Int32.Parse(button9.Text))
            {
                button9.BackColor = Color.Green;
                button9.Cursor = Cursors.Hand;
            }
            else
            {
                button9.BackColor = Color.Red;
                button9.Cursor = Cursors.Default;
            }



            if (Int32.Parse(LVL.level) >= Int32.Parse(button10.Text))
            {
                button10.BackColor = Color.Gold;
                button10.Cursor = Cursors.Hand;
            }
            else
            {
                button10.BackColor = Color.Red;
                button10.Cursor = Cursors.Default;
            }
           
        }

        private void show()
        {
            Form5 f5 = new Form5();
            this.Close();
            f5.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.BackColor == Color.Green)
            {
                LVL.alevel = button1.Text;
                show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.BackColor == Color.Green)
            {
                LVL.alevel = button2.Text;
                show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.BackColor == Color.Green)
            {
                LVL.alevel = button3.Text;
                show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.BackColor == Color.Green)
            {
                LVL.alevel = button4.Text;
                show();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (button5.BackColor == Color.Gold)
            {
                LVL.alevel = button5.Text;
                show();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (button6.BackColor == Color.Green)
            {
                LVL.alevel = button6.Text;
                show();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (button7.BackColor == Color.Green)
            {
                LVL.alevel = button7.Text;
                show();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (button8.BackColor == Color.Green)
            {
                LVL.alevel = button8.Text;
                show();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (button9.BackColor == Color.Green)
            {
                LVL.alevel = button9.Text;
                show();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (button10.BackColor == Color.Gold)
            {
                LVL.alevel = button10.Text;
                show();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            this.Close();
            f3.Show();
        }
    }
}
