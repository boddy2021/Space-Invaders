using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using System.Windows.Input;
using System.Runtime.CompilerServices;
using System.IO;
using System.Data.SqlClient;
using Proiect.Properties;

namespace Proiect
{
    public partial class Form5 : Form
    {
        private PictureBox[] inv;
        private entity[] ent;
        private bullet[] eblt;
        private PictureBox[] invb;
        private ProgressBar[] pb;
        private ProgressBar bhp;
        private entity pyr;
        private bullet blt;
        private PictureBox pblt;
        private int boss = 0;
        private int bh;
        private int hs;
        private aboss bos;
        private boss2 bos2;
        public Form5()
        {
            set_background();
             InitializeComponent();
            initiate_components();
        }

        struct entity
        {
            public int speed, hs, bs, x, y, ihelth;
            public int helth, damage, fblt, top, bdamage;
        };

        struct bullet
        {
            public int speed;
            public bool shooting, st;
        };

        struct aboss
        {
            public int top, ftop, topd, tops, atopd, speed;
        };

        struct boss2
        {
            public int top, speed;
            public int helth, bdamage;
            public int bs,bs1,bs2,hs,hs1,hs2,ahs1,ahs2;
            public int fblt,damage;
            public int order,ahelth;
            public int ad,fd,sd,td,ftd,phs,aphs;
            public bool create_bullet;
        };
        bool gl = false, gr = false;
        private void initiate_components()
        {
            create_enemies();
            create_player();
            initiate_bulette();
            ilbl();
            add_progress_bar();
            GameTimer.Start();
        }

        private void ilbl()
        {
            label2.BackColor = Color.Transparent;
            label3.BackColor = Color.Transparent;
            label2.Text = "Level " +LVL.alevel.ToString();
            label3.Text = ("helth: " + pyr.helth.ToString());
        }
        private void initiate_bulette()
        {
            blt.speed = 34;
            blt.shooting = false;
            blt.st = false;
        }

        private void set_background()
        {
            if(LVL.alevel == "1")
            {
                this.BackgroundImage = Properties.Resources.background1;
            }
            else if (LVL.alevel == "2")
            {
                this.BackgroundImage = Properties.Resources.background2;
            }
            else if (LVL.alevel == "3")
            {
                this.BackgroundImage = Properties.Resources.background3;
            }
            else if (LVL.alevel == "4")
            {
                this.BackgroundImage = Properties.Resources.background4;
            }
            else if (LVL.alevel == "5")
            {
                this.BackgroundImage = Properties.Resources.background5;
            }
            else if (LVL.alevel == "6")
            {
                this.BackgroundImage = Properties.Resources.background6;
            }
            else if (LVL.alevel == "7")
            {
                this.BackgroundImage = Properties.Resources.background7;
            }
            else if (LVL.alevel == "8")
            {
                this.BackgroundImage = Properties.Resources.background8;
            }
            else if (LVL.alevel == "9")
            {
                this.BackgroundImage = Properties.Resources.background9;
            }
            else if (LVL.alevel == "10")
            {
                this.BackgroundImage = Properties.Resources.background10;
            }
        }
        private void create_bulette()
        {
            if (bos2.order != 4)
            {
                pblt = new PictureBox();
                pblt.BackColor = Color.Transparent;
                pblt.Image = Properties.Resources.bullet;
                pblt.SizeMode = PictureBoxSizeMode.StretchImage;
                pblt.Width = 10;
                pblt.Height = 20;
                pblt.Left = player.Left + player.Width/3;
                pblt.Top = player.Top;
                this.Controls.Add(pblt);
                pblt.BringToFront();
            }
            else
            if(bos2.phs <= 0)
            {
                pblt = new PictureBox();
                pblt.BackColor = Color.Transparent;
                pblt.Image = Properties.Resources.bullet;
                pblt.SizeMode = PictureBoxSizeMode.StretchImage;
                pblt.Width = 10;
                pblt.Height = 20;
                pblt.Left = player.Left + player.Width/3;
                pblt.Top = player.Top;
                this.Controls.Add(pblt);
                pblt.BringToFront();
            }
        }

        private void create_player()
        {
            player.BringToFront();
            pyr.x = player.Left;
            pyr.y = player.Top;
            pyr.speed = 7;
            pyr.damage = 100;
            pyr.helth = 100;
            pyr.hs = 500;
            pyr.bs = 25;
            pyr.fblt = 0;
            pyr.bdamage = 400;
        }
        private void create_enemies()
        {
            if (LVL.alevel == "1")
            {
                inv = new PictureBox[9];
                ent = new entity[9];
                eblt = new bullet[9];
                invb = new PictureBox[9];
                Random rnd = new Random();
                for (int i = 0; i < inv.Length; i++)
                {
                    inv[i] = new PictureBox();
                    inv[i].BackColor = Color.Transparent;
                    inv[i].Size = new Size(50, 50);
                    inv[i].Image = Properties.Resources.invaders;
                    inv[i].Top = 25 + 50 * (i / 3);
                    inv[i].Left = 100 * ((i + 1) % 3 + 1);
                    inv[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    this.Controls.Add(inv[i]);
                    ent[i].x = inv[i].Left;
                    ent[i].y = inv[i].Top;
                    ent[i].damage = 50;
                    ent[i].helth = 100;
                    ent[i].speed = 5;
                    ent[i].hs = 2000;
                    ent[i].bs = 9;
                    ent[i].ihelth = 100;
                    ent[i].top = 0;
                    ent[i].fblt = rnd.Next(1000, ent[i].hs);
                }
                create_ebullet();
            }
            if (LVL.alevel == "2")
            {
                 inv = new PictureBox[8];
                ent = new entity[8];
                eblt = new bullet[8];
                invb = new PictureBox[8];
                Random rnd = new Random();
                for (int i = 0; i < inv.Length; i++)
                {
                    inv[i] = new PictureBox();
                    inv[i].BackColor = Color.Transparent;
                    inv[i].Size = new Size(50, 50);
                    inv[i].Image = Properties.Resources.invader3;
                    inv[i].Top = 25 + 70 * (i / 4);
                    inv[i].Left = 80 * ((i + 1) % 4 + 1);
                    inv[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    this.Controls.Add(inv[i]);
                    ent[i].x = inv[i].Left;
                    ent[i].y = inv[i].Top;
                    ent[i].damage = 0;
                    ent[i].helth = 200;
                    ent[i].speed = 15;
                    ent[i].hs = 0;
                    ent[i].bs = 7;
                    ent[i].top = 20;
                    ent[i].ihelth = 200;
                    ent[i].bdamage = 100;
                }
                create_ebullet();
            }
            if (LVL.alevel == "3")
            {
                inv = new PictureBox[15];
                ent = new entity[15];
                eblt = new bullet[15];
                invb = new PictureBox[15];
                Random rnd = new Random();
                for (int i = 0; i < 10; i++)
                {
                    inv[i] = new PictureBox();
                    inv[i].BackColor = Color.Transparent;
                    inv[i].Size = new Size(50, 50);
                    inv[i].Image = Properties.Resources.invaders;
                    inv[i].Top = 25 + 70 * (i / 5);
                    inv[i].Left = 60 * ((i + 1) % 5 + 1);
                    inv[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    this.Controls.Add(inv[i]);
                    ent[i].x = inv[i].Left;
                    ent[i].y = inv[i].Top;
                    ent[i].damage = 50;
                    ent[i].helth = 100;
                    ent[i].speed = 7;
                    ent[i].hs = 3000;
                    ent[i].ihelth = 100;
                    ent[i].bs = 7;
                    ent[i].top = 0;
                    ent[i].bdamage = 0;
                    ent[i].fblt = rnd.Next(1000, ent[i].hs);
                }
                for(int i=10;i<15;i++)
                {
                    inv[i] = new PictureBox();
                    inv[i].BackColor = Color.Transparent;
                    inv[i].Size = new Size(50, 50);
                    inv[i].Image = Properties.Resources.invader3;
                    inv[i].Top = 200;
                    inv[i].Left = 60 * ((i + 1) % 5 + 1);
                    inv[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    this.Controls.Add(inv[i]);
                    ent[i].x = inv[i].Left;
                    ent[i].y = inv[i].Top;
                    ent[i].damage = 0;
                    ent[i].helth = 200;
                    ent[i].speed = 15;
                    ent[i].hs = 0;
                    ent[i].bs = 0;
                    ent[i].top = 20;
                    ent[i].ihelth = 200;
                    ent[i].bdamage = 100;
                }
                create_ebullet();
            }
            if (LVL.alevel == "4")
            {
                inv = new PictureBox[5];
                ent = new entity[5];
                eblt = new bullet[5];
                invb = new PictureBox[5];
                Random rnd = new Random();
                for (int i = 0; i < inv.Length; i++)
                {
                    inv[i] = new PictureBox();
                    inv[i].BackColor = Color.Transparent;
                    inv[i].Size = new Size(40, 40);
                    inv[i].Image = Properties.Resources.invader4;
                    if (i == 0 || i == 1)
                    {
                        inv[i].Top = 25;
                        inv[i].Left = 100 * (i + 1);
                    }
                    else
                    {
                        inv[i].Top = 125;
                        inv[i].Left = 75 * (i + 1);
                    }
                    inv[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    this.Controls.Add(inv[i]);
                    ent[i].x = inv[i].Left;
                    ent[i].y = inv[i].Top;
                    ent[i].damage = 75;
                    ent[i].helth = 400;
                    ent[i].speed = 10;
                    ent[i].hs = 2000;
                    ent[i].bs = 12;
                    ent[i].top = 0;
                    ent[i].ihelth = 400;
                    ent[i].fblt = rnd.Next(1000, ent[i].hs);
                }
                create_ebullet();
            }
            if (LVL.alevel == "5")
            {
                inv = new PictureBox[1];
                ent = new entity[1];
                eblt = new bullet[3];
                invb = new PictureBox[3];
                bos = new aboss();
                Random rnd = new Random();
                for (int i = 0; i < inv.Length; i++)
                {
                    inv[i] = new PictureBox();
                    inv[i].BringToFront();
                    inv[i].BackColor = Color.Transparent;
                    inv[i].Size = new Size(210, 135);
                    inv[i].Image = Properties.Resources.invader2;
                    inv[i].Top = 50;
                    inv[i].Left = 100;
                    inv[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    this.Controls.Add(inv[i]);
                    ent[i].x = inv[i].Left;
                    ent[i].y = inv[i].Top;
                    ent[i].damage = 100;
                    ent[i].helth = 4000;
                    ent[i].speed = 15  ;
                    ent[i].hs = 1500;
                    hs = 1500;
                    ent[i].bs = 10;
                    ent[i].top = 0;
                    ent[i].ihelth = 4000;
                    ent[i].fblt = 1000;
                    ent[i].bdamage = 10;
                    bos.tops = 7500;
                    bos.ftop = bos.tops;
                    bos.topd = 1000;
                    bos.top = 275;
                    bos.atopd = bos.topd;
                    bos.speed = ent[i].speed;
                    boss = 1;
                }
                create_ebullet();
            }
            if (LVL.alevel == "6")
            {
                inv = new PictureBox[15];
                ent = new entity[15];
                eblt = new bullet[15];
                invb = new PictureBox[15];
                Random rnd = new Random();
                for (int i = 0; i < 10; i++)
                {
                    inv[i] = new PictureBox();
                    inv[i].BackColor = Color.Transparent;
                    inv[i].Size = new Size(40, 40);
                    inv[i].Image = Properties.Resources.invader1;
                    inv[i].Top = 60 * ((i/5)+1);
                    inv[i].Left = 50 * ((i + 1)%5);
                    inv[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    this.Controls.Add(inv[i]);
                    ent[i].damage = 25;
                    ent[i].helth = 200;
                    ent[i].speed = 17;
                    ent[i].hs = 2500;
                    ent[i].bs = 15;
                    ent[i].top = 0;
                    ent[i].ihelth = 200;
                    ent[i].fblt = rnd.Next(0, ent[i].hs);
                }
                for(int i=10;i<15;i++)
                {
                    inv[i] = new PictureBox();
                    inv[i].BackColor = Color.Transparent;
                    inv[i].Size = new Size(40, 40);
                    inv[i].Image = Properties.Resources.invader4;
                    inv[i].Top = 180;
                    inv[i].Left = 50 * ((i + 1) % 5);
                    inv[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    this.Controls.Add(inv[i]);
                    ent[i].damage = 75;
                    ent[i].helth = 400;
                    ent[i].speed = 10;
                    ent[i].hs = 3000;
                    ent[i].bs = 9;
                    ent[i].ihelth = 400;
                    ent[i].top = 0;
                    ent[i].fblt = rnd.Next(0, ent[i].hs);
                }
                create_ebullet();
            }
            if (LVL.alevel == "7")
            {
                inv = new PictureBox[20];
                ent = new entity[20];
                eblt = new bullet[20];
                invb = new PictureBox[20];
                Random rnd = new Random();
                for (int i = 0; i < 10; i++)
                {
                    inv[i] = new PictureBox();
                    inv[i].BackColor = Color.Transparent;
                    inv[i].Size = new Size(40, 40);
                    inv[i].Image = Properties.Resources.invader1;
                    inv[i].Top = 60 * ((i / 5) + 1);
                    inv[i].Left = 50 * ((i + 1) % 5);
                    inv[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    this.Controls.Add(inv[i]);
                    ent[i].damage = 25;
                    ent[i].helth = 200;
                    ent[i].speed = 17;
                    ent[i].hs = 2500; 
                    ent[i].bs = 15;
                    ent[i].top = 0;
                    ent[i].ihelth = 200;
                    ent[i].fblt = rnd.Next(0, ent[i].hs);
                }
                for (int i = 10; i < 15; i++)
                {
                    inv[i] = new PictureBox();
                    inv[i].BackColor = Color.Transparent;
                    inv[i].Size = new Size(40, 40);
                    inv[i].Image = Properties.Resources.invader4;
                    inv[i].Top = 180;
                    inv[i].Left = 50 * ((i + 1) % 5);
                    inv[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    this.Controls.Add(inv[i]);
                    ent[i].damage = 75;
                    ent[i].bdamage = 100;
                    ent[i].helth = 200;
                    ent[i].speed = 15;
                    ent[i].hs = 0;
                    ent[i].bs = 9;
                    ent[i].ihelth = 200;
                    ent[i].top = 20;
                    ent[i].fblt = rnd.Next(0, ent[i].hs);
                }
                for (int i = 15; i < 20; i++)
                {
                    inv[i] = new PictureBox();
                    inv[i].BackColor = Color.Transparent;
                    inv[i].Size = new Size(45, 40);
                    inv[i].Image = Properties.Resources.invader5;
                    inv[i].Top = 260;
                    inv[i].Left = 60 * ((i + 1) % 5);
                    inv[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    this.Controls.Add(inv[i]);
                    ent[i].damage = 75;
                    ent[i].helth = 100;
                    ent[i].speed = 30;
                    ent[i].hs = 0;
                    ent[i].bs = 9;
                    ent[i].bdamage = 50;
                    ent[i].ihelth = 100;
                    ent[i].top = 25;
                    ent[i].fblt = rnd.Next(0, ent[i].hs);
                }
                create_ebullet();
            }
            if (LVL.alevel == "8")
            {
                inv = new PictureBox[4];
                ent = new entity[4];
                eblt = new bullet[4];
                invb = new PictureBox[4];
                Random rnd = new Random();
                for (int i = 0; i < inv.Length; i++)
                {
                    inv[i] = new PictureBox();
                    inv[i].BackColor = Color.Transparent;
                    inv[i].Size = new Size(80, 80);
                    inv[i].Image = Properties.Resources.invader6;
                    inv[i].Top = 40 + 150 * (i / 2);
                    inv[i].Left = 50 + 150 * ((i + 1) % 2);
                    inv[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    this.Controls.Add(inv[i]);
                    ent[i].x = inv[i].Left;
                    ent[i].y = inv[i].Top;
                    ent[i].damage = 50;
                    ent[i].helth = 5000;
                    if (i < 2)
                    {
                        ent[i].speed = 10;
                    }
                    else
                    {
                        ent[i].speed = -10;
                    }
                    ent[i].hs = 2000;
                    ent[i].bs = 17;
                    ent[i].ihelth = 5000;
                    ent[i].top = 0;
                    ent[i].fblt = rnd.Next(0, ent[i].hs);
                }
                create_ebullet();
            }
            if (LVL.alevel == "9")
            {
                inv = new PictureBox[50];
                ent = new entity[50];
                eblt = new bullet[50];
                invb = new PictureBox[50];
                Random rnd = new Random();
                for (int i = 0; i < 10; i++)
                {
                    inv[i] = new PictureBox();
                    inv[i].BackColor = Color.Transparent;
                    inv[i].Size = new Size(35, 35);
                    inv[i].Image = Properties.Resources.invaders;
                    inv[i].Top = 20;
                    inv[i].Left = 20 + 38 * ((i + 1) % 10);
                    inv[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    this.Controls.Add(inv[i]);
                    ent[i].x = inv[i].Left;
                    ent[i].y = inv[i].Top;
                    ent[i].damage = 15;
                    ent[i].helth = 100;
                    ent[i].speed = 5;
                    ent[i].hs = 5000;
                    ent[i].bs = 10;
                    ent[i].ihelth = 100;
                    ent[i].top = 0;
                    ent[i].fblt = rnd.Next(0, ent[i].hs);
                }
                for (int i = 10; i < 20; i++)
                {
                    inv[i] = new PictureBox();
                    inv[i].BackColor = Color.Transparent;
                    inv[i].Size = new Size(35, 35);
                    inv[i].Image = Properties.Resources.invader1;
                    inv[i].Top = 70;
                    inv[i].Left = 20 + 38 * ((i - 9) % 10);
                    inv[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    this.Controls.Add(inv[i]);
                    ent[i].x = inv[i].Left;
                    ent[i].y = inv[i].Top;
                    ent[i].damage = 10;
                    ent[i].helth = 200;
                    ent[i].speed = 10;
                    ent[i].hs = 4000;
                    ent[i].bs = 15;
                    ent[i].ihelth = 200;
                    ent[i].top = 0;
                    ent[i].fblt = rnd.Next(0, ent[i].hs);
                }
                for (int i = 20; i < 30; i++)
                {
                    inv[i] = new PictureBox();
                    inv[i].BackColor = Color.Transparent;
                    inv[i].Size = new Size(35, 35);
                    inv[i].Image = Properties.Resources.invader4;
                    inv[i].Top = 120;
                    inv[i].Left = 20 + 38 * ((i - 19) % 10);
                    inv[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    this.Controls.Add(inv[i]);
                    ent[i].x = inv[i].Left;
                    ent[i].y = inv[i].Top;
                    ent[i].damage = 20  ;
                    ent[i].helth = 400;
                    ent[i].speed = 5;
                    ent[i].hs = 6000;
                    ent[i].bs = 9;
                    ent[i].ihelth = 400;
                    ent[i].top = 0;
                    ent[i].fblt = rnd.Next(0, ent[i].hs);
                }
                for (int i = 30; i < 40; i++)
                {
                    inv[i] = new PictureBox();
                    inv[i].BackColor = Color.Transparent;
                    inv[i].Size = new Size(35, 35);
                    inv[i].Image = Properties.Resources.invader3;
                    inv[i].Top = 170;
                    inv[i].Left = 20 + 38 * ((i - 29) % 10);
                    inv[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    this.Controls.Add(inv[i]);
                    ent[i].x = inv[i].Left;
                    ent[i].y = inv[i].Top;
                    ent[i].damage = 50;
                    ent[i].helth = 200;
                    ent[i].speed = 7;
                    ent[i].hs = 0;
                    ent[i].bs = 10;
                    ent[i].ihelth = 200;
                    ent[i].top = 20;
                    ent[i].fblt = rnd.Next(0, ent[i].hs);
                }
                for (int i = 40; i < 50; i++)
                {
                    inv[i] = new PictureBox();
                    inv[i].BackColor = Color.Transparent;
                    inv[i].Size = new Size(35, 35);
                    inv[i].Image = Properties.Resources.invader5;
                    inv[i].Top = 220;
                    inv[i].Left = 20 + 38 * ((i + 1) % 10);
                    inv[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    this.Controls.Add(inv[i]);
                    ent[i].x = inv[i].Left;
                    ent[i].y = inv[i].Top;
                    ent[i].damage = 50;
                    ent[i].helth = 100;
                    ent[i].speed = 15;
                    ent[i].hs = 2000;
                    ent[i].bs = 10;
                    ent[i].ihelth = 100;
                    ent[i].top = 25;
                    ent[i].fblt = rnd.Next(0, ent[i].hs);
                }
                create_ebullet();
            }
            if (LVL.alevel == "10")
            {
                inv = new PictureBox[1];
                ent = new entity[1];
                eblt = new bullet[5];
                invb = new PictureBox[5];
                bos2 = new boss2();
                Random rnd = new Random();
                for (int i = 0; i < inv.Length; i++)
                {
                    inv[i] = new PictureBox();
                    inv[i].BringToFront();
                    inv[i].BackColor = Color.Transparent;
                    inv[i].Size = new Size(180, 140);
                    inv[i].Image = Properties.Resources.invader7;
                    inv[i].Top = 50;
                    inv[i].Left = 100;
                    inv[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    this.Controls.Add(inv[i]);
                    bos2.create_bullet = false;
                    bos2.top = 275;
                     bos2.speed = 15;
                    bos2.order = 1;
                    boss = 2;
                    bos2.hs = 2500;
                    bos2.hs1 = 1000;
                    bos2.ahs1 = 1000;
                    bos2.ahs2 = 2000;
                    bos2.bs1 = 30;
                    bos2.damage = 100;
                    bos2.bs = 10;
                    bos2.bs2 = 15;
                    bos2.bdamage = 10;
                    bos2.hs2 = 2000;
                    bos2.helth = 10000;
                    bos2.ahelth = 10000;
                    bos2.fd = 15000;
                    bos2.fblt = 1000;
                    bos2.sd = 1000;
                    bos2.td = 10000;
                    bos2.ftd = 7500;
                    bos2.ad = 15000;
                    bos2.phs = 0;
                    bos2.aphs =250;
                    bh = 200;
                }
                create_ebullet();
            }
        }

        private void create_ebullet()
        {
            if(LVL.alevel == "1")
            {
                for(int i=0;i<invb.Length;i++)
                {
                    invb[i] = new PictureBox();
                    invb[i].BackColor = Color.Transparent;
                    eblt[i].shooting = false;
                    eblt[i].st = false;
                    invb[i].Left = inv[i].Left;
                    invb[i].Top = inv[i].Top + inv[i].Height;
                    invb[i].Image = Properties.Resources.bullet6;
                    invb[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    invb[i].Width = 20;
                    invb[i].Height = 40;
                }
            }
            if(LVL.alevel == "2")
            {
                for (int i = 0; i < invb.Length; i++)
                {
                    invb[i] = new PictureBox();
                    invb[i].BackColor = Color.Transparent;
                    eblt[i].shooting = false;
                    eblt[i].st = false;
                }
            }
            if(LVL.alevel == "3")
            {
                for (int i = 0; i < 10; i++)
                {
                    invb[i] = new PictureBox();
                    invb[i].BackColor = Color.Transparent;
                    eblt[i].speed = 20;
                    eblt[i].shooting = false;
                    eblt[i].st = false;
                    invb[i].Left = inv[i].Left;
                    invb[i].Top = inv[i].Top + inv[i].Height;
                    invb[i].Image = Properties.Resources.bullet6;
                    invb[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    invb[i].Width = 20;
                    invb[i].Height = 40;
                }
                for(int i=10;i<15;i++)
                {
                    invb[i] = new PictureBox();
                    invb[i].BackColor = Color.Transparent;
                    eblt[i].speed = 20;
                    eblt[i].shooting = false;
                    eblt[i].st = false;
                }
            }
            if (LVL.alevel == "4")
            {
                for (int i = 0; i < inv.Length; i++)
                {
                    invb[i] = new PictureBox();
                    invb[i].BackColor = Color.Transparent;
                    eblt[i].speed = 40;
                    eblt[i].shooting = false;
                    eblt[i].st = false;
                    invb[i].Left = inv[i].Left;
                    invb[i].Top = inv[i].Top + inv[i].Height;
                    invb[i].Image = Properties.Resources.bullet1;
                    invb[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    invb[i].Width = 20;
                    invb[i].Height = 40;
                }
            }
            if (LVL.alevel == "5")
            {
                for (int i = 0; i < 3; i++)
                {
                    invb[i] = new PictureBox();
                    invb[i].BackColor = Color.Transparent;
                    eblt[i].speed = 25;
                    eblt[i].shooting = false;
                    eblt[i].st = false;
                    invb[i].Left = inv[0].Left + i * 80;
                    invb[i].Top = inv[0].Top + inv[0].Height;
                    invb[i].Image = Properties.Resources.bullet;
                    invb[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    invb[i].Width = 25;
                    invb[i].Height = 50;
                }
            }
            if (LVL.alevel == "6")
            {
                for (int i = 0; i < invb.Length; i++)
                {
                    invb[i] = new PictureBox();
                    invb[i].BackColor = Color.Transparent;
                    eblt[i].shooting = false;
                    eblt[i].st = false;
                    invb[i].Left = inv[i].Left;
                    invb[i].Top = inv[i].Top + inv[i].Height;
                    invb[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    if (i < 10 || i >= 15)
                    {
                        invb[i].Image = Properties.Resources.bullet5;
                        invb[i].Width = 20;
                        invb[i].Height = 40;
                    }
                    else
                    {
                        invb[i].Image = Properties.Resources.bullet1;
                        invb[i].Width = 20;
                        invb[i].Height = 40;
                    }
                }
            }
            if (LVL.alevel == "7")
            {
                for (int i = 0; i < invb.Length; i++)
                {
                    invb[i] = new PictureBox();
                    invb[i].BackColor = Color.Transparent;
                    eblt[i].shooting = false;
                    eblt[i].st = false;
                    invb[i].Left = inv[i].Left;
                    invb[i].Top = inv[i].Top + inv[i].Height;
                    invb[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    invb[i].Image = Properties.Resources.bullet5;
                    invb[i].Width = 20;
                    invb[i].Height = 40;
                }
            }
            if (LVL.alevel == "8")
            {
                for (int i = 0; i < invb.Length; i++)
                {
                    invb[i] = new PictureBox();
                    invb[i].BackColor = Color.Transparent;
                    eblt[i].shooting = false;
                    eblt[i].st = false;
                    invb[i].Left = inv[i].Left;
                    invb[i].Top = inv[i].Top + inv[i].Height;
                    invb[i].Image = Properties.Resources.bullet1;
                    invb[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    invb[i].Width = 25;
                    invb[i].Height = 50;
                }
            }
            if (LVL.alevel == "9")
            {
                for (int i = 0; i < invb.Length; i++)
                {
                    invb[i] = new PictureBox();
                    invb[i].BackColor = Color.Transparent;
                    eblt[i].shooting = false;
                    eblt[i].st = false;
                    invb[i].Left = inv[i].Left;
                    invb[i].Top = inv[i].Top + inv[i].Height;
                    if(i<10)
                        invb[i].Image = Properties.Resources.bullet6;
                    else
                        if(i<20)
                             invb[i].Image = Properties.Resources.bullet5;
                    else
                        if (i < 30)
                            invb[i].Image = Properties.Resources.bullet1;
                    invb[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    invb[i].Width = 10;
                    invb[i].Height = 20;
                }
            }
            if (LVL.alevel == "10")
            {
                for (int i = 0; i < invb.Length; i++)
                {
                    invb[i] = new PictureBox();
                    invb[i].BackColor = Color.Transparent;
                    eblt[i].shooting = false;
                    eblt[i].st = false;
                    invb[i].Left = inv[0].Left + i * 90;
                    invb[i].Top = inv[0].Top + inv[0].Height;
                    invb[i].Image = Properties.Resources.bullet;
                    invb[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    invb[i].Width = 25;
                    invb[i].Height = 50;
                }
            }
        }
        private void caltob()
        {
            if(boss == 0)
            {
                for (int i = 0; i < invb.Length; i++)
                {
                    if (ent[i].hs != 0)
                        if (ent[i].fblt > 0)
                            ent[i].fblt -= GameTimer.Interval;
                        else
                        {
                            ent[i].fblt = ent[i].hs;
                            invb[i].Left = inv[i].Left;
                            invb[i].Top = inv[i].Top + inv[i].Height;
                        }
                }
            }
            else if(boss == 1)
            {
                if (ent[0].hs != 0)
                    if (ent[0].fblt > 0)
                        ent[0].fblt -= GameTimer.Interval;
                    else {
                        for (int i = 0; i < invb.Length; i++)
                        {
                           ent[0].fblt = ent[0].hs;
                           invb[i].Left = inv[0].Left + i * 70;
                           invb[i].Top = inv[0].Top + inv[0].Height;
                        }
                }
            }
            else if(boss == 2)
            {
                if(bos2.order == 1)
                {
                    if (bos2.fblt > 0)
                        bos2.fblt -= GameTimer.Interval;
                    else
                    {
                        for (int i = 0; i < invb.Length; i++)
                        {
                            bos2.fblt = bos2.hs;
                            invb[i].Left = inv[0].Left + i * 70;
                            invb[i].Top = inv[0].Top + inv[0].Height;
                            eblt[0].shooting = true;
                        }
                    }
                }
            }
        }

        private void boss_abilities()
        {
            if(boss==1)
            {
                if (bos.ftop > 0)
                {
                    bos.ftop -= GameTimer.Interval;
                }
                else
                {
                    if (bos.atopd == bos.topd)
                    {
                        inv[0].Top += bos.top;
                        ent[0].speed = 0;
                        ent[0].hs = 0;
                        ent[0].hs = 0;
                    }
                    if (bos.atopd > 0)
                    {
                        bos.atopd -= GameTimer.Interval;
                    }
                    else
                    {
                        inv[0].Top -= bos.top;
                        bos.ftop = bos.tops;
                        bos.atopd = bos.topd;
                        ent[0].speed = bos.speed;
                        ent[0].hs = hs;
                    }
                }
            }
            if(boss==2)
            {
                if(bos2.order == 1)
                {
                    bos2.ad -= GameTimer.Interval;
                    if(bos2.ad <= 0)
                    {
                        bos2.order++;
                        bos2.ad = bos2.sd;
                        inv[0].Top += bos2.top;
                        for (int i = 0; i < 5; i++)
                            this.Controls.Remove(invb[i]);
                    }
                }
                if(bos2.order == 2)
                {
                    bos2.ad -= GameTimer.Interval;
                    if(bos2.ad <= 0)
                    {
                        bos2.order++;
                        bos2.ad = bos2.td;
                        inv[0].Top -= bos2.top;
                        bos2.create_bullet = true;
                        invb[0].Image = Properties.Resources.bullet5;
                        invb[0].Height = 50;
                        invb[0].Width = 25;
                        if (bos2.speed < 0)
                            bos2.speed -= 10;
                        else
                            bos2.speed += 10;
                    }
                }
                if(bos2.order == 3)
                {
                    bos2.ad -= GameTimer.Interval;
                    if (bos2.create_bullet == true)
                    {
                        invb[0].Left = inv[0].Left + inv[0].Height / 2;
                        invb[0].Top = inv[0].Top;
                        bos2.create_bullet = false;
                        this.Controls.Add(invb[0]);
                    }
                    else
                    {
                        bos2.hs1 -= GameTimer.Interval;
                        invb[0].Top += bos2.bs1;
                        if (bos2.hs1 <= 0)
                        {
                            bos2.create_bullet = true;
                            bos2.hs1 = bos2.ahs1;
                        }
                    }
                    if (bos2.ad <= 0)
                    {
                        bos2.order++;
                        bos2.ad = bos2.ftd;
                        invb[0].Image = Properties.Resources.bullet8;
                        invb[0].Width = 25;
                        invb[0].Height = 50;
                        if (bos2.speed < 0)
                            bos2.speed += 10;
                        else
                            bos2.speed -= 10;
                        bos2.phs = 0;
                        bos2.create_bullet = true;
                    }
                }
                if(bos2.order == 4)
                {
                    bos2.ad -= GameTimer.Interval;
                    if (bos2.ad <= 0)
                    {
                        bos2.order = 1;
                        bos2.ad = bos2.fd;
                        invb[0].Image = Properties.Resources.bullet;
                    }
                    if (bos2.create_bullet == true)
                    {
                        invb[0].Left = inv[0].Left + inv[0].Height / 2;
                        invb[0].Top = inv[0].Top;
                        bhp = new ProgressBar();
                        bhp.Width = invb[0].Width * 2 / 3;
                        bhp.Height = 5;
                        bhp.Top = invb[0].Top - 5;
                        bhp.Left = invb[0].Left + invb[0].Width * 1 / 5;
                        bhp.Value = 100;
                        this.Controls.Add(bhp);
                        bhp.BringToFront();
                        bos2.create_bullet = false;
                        bh = 200;
                        this.Controls.Add(invb[0]);
                    }
                    else
                    {
                        if (bh > 0)
                        {
                            bhp.Top = invb[0].Top - 5;
                            bhp.Left = invb[0].Left + invb[0].Width * 1 / 5;
                            bhp.Value = bh * 1 / 2;
                        }
                        bos2.hs2 -= GameTimer.Interval;
                        invb[0].Top += bos2.bs2;
                        if(bh <= 0)
                        {
                            this.Controls.Remove(invb[0]);
                            this.Controls.Remove(bhp);
                        }
                        if (invb[0].Left > player.Left + 10)
                        {
                            invb[0].Left -= 10;
                        }
                        else
                        if(invb[0].Left < player.Left - 10)
                        {
                            invb[0].Left += 10;
                        }
                        if (bos2.hs2 <= 0)
                        {
                            bos2.create_bullet = true;
                            bos2.hs2 = bos2.ahs2;
                        }
                    }
                }
            }
        }
        private void seb()
        {
            if(boss == 0)
            {
                for (int i = 0; i < eblt.Length; i++)
                {
                    if (ent[i].hs != 0)
                        if (eblt[i].shooting == true || eblt[i].st == true)
                        {
                            if (eblt[i].st == false && ent[i].helth > 0)
                            {
                                this.Controls.Add(invb[i]);
                                eblt[i].st = true;
                            }
                            else if(ent[i].helth > 0)
                            {
                                invb[i].Top += ent[i].bs;
                                if (invb[i].Top > 450)
                                {
                                    this.Controls.Remove(invb[i]);
                                    eblt[i].st = false;
                                    eblt[i].shooting = false;
                                }
                            }
                        }
                }
            }
            else if(boss == 1)
            {
                if (eblt[0].shooting == true || eblt[0].st == true)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (eblt[i].st == false && ent[0].helth>0)
                        {
                            this.Controls.Add(invb[i]);
                            eblt[i].st = true;
                        }
                        else
                        {
                            invb[i].Top += ent[0].bs;
                            if (invb[i].Top > 450)
                            {
                                this.Controls.Remove(invb[i]);
                                eblt[i].st = false;
                                eblt[i].shooting = false;
                            }
                        }
                    }
                }
            }
            else if(boss==2)
            {
                if(bos2.order==1)
                {
                if (eblt[0].shooting == true || eblt[0].st == true)
                {
                    for (int i = 0; i < 5; i++)
                    {
                            if (eblt[i].st == false && bos2.helth > 0)
                            {
                                this.Controls.Add(invb[i]);
                                eblt[i].st = true;
                            }
                            else
                            {
                                invb[i].Top += bos2.bs;
                                if (invb[i].Top > 450)
                                {
                                    this.Controls.Remove(invb[i]);
                                    eblt[i].st = false;
                                    eblt[i].shooting = false;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void verificare()
        {
            if (LVL.alevel == "1")
            {
                if (inv[0].Left > 310 || inv[0].Left < 90)
                {
                    for (int i = 0; i < inv.Length; i++)
                    {
                        ent[i].speed *= -1;
                        inv[i].Top += ent[i].top;
                    }
                }
            }
            if(LVL.alevel=="2")
            {
                if (inv[0].Left > 240 || inv[0].Left <= 40)
                {
                    for (int i = 0; i < inv.Length; i++)
                    {
                        ent[i].speed *= -1;
                        inv[i].Top += ent[i].top;
                    }
                }
            }
            if (LVL.alevel == "3")
            {
                if (inv[0].Left > 200 || inv[0].Left <= 40)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        ent[i].speed *= -1;
                        inv[i].Top += ent[i].top;
                    }
                }
                if(inv[10].Left > 220 || inv[10].Left <= 60)
                {
                    for (int i = 10; i < 15; i++)
                    {
                        ent[i].speed *= -1;
                        inv[i].Top += ent[i].top;
                    }
                }
            }
            if (LVL.alevel == "4")
            {
                if (inv[0].Left > 260 || inv[0].Left <= 40)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        ent[i].speed *= -1;
                        inv[i].Top += ent[i].top;
                    }
                }
                if (inv[2].Left > 270 || inv[2].Left <= 40)
                {
                    for (int i = 2; i < 5; i++)
                    {
                        ent[i].speed *= -1;
                        inv[i].Top += ent[i].top;
                    }
                }
            }
            if (LVL.alevel == "5")
            {
                if (inv[0].Left > 240 || inv[0].Left <= 20)
                {
                        ent[0].speed *= -1;
                        inv[0].Top += ent[0].top;
                }
                if(inv[0].Left>240)
                {
                    inv[0].Left = 240;
                }
                if(inv[0].Left<20)
                {
                    inv[0].Left = 20;
                }
            }
            if (LVL.alevel == "6")
            {
                if (inv[0].Left > 240 || inv[0].Left <= 40)
                {
                    for (int i = 0; i < 10; i++)
                    { 
                        ent[i].speed *= -1;
                        inv[i].Top += ent[i].top;
                    }
                }
                if (inv[10].Left > 240 || inv[10].Left <= 40)
                {
                    for (int i = 10; i < 15; i++)
                    {
                        ent[i].speed *= -1;
                        inv[i].Top += ent[i].top;
                    }
                }
            }
            if (LVL.alevel == "7")
            {
                if (inv[0].Left > 240 || inv[0].Left <= 40)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        ent[i].speed *= -1;
                        inv[i].Top += ent[i].top;
                    }
                }
                if (inv[10].Left > 240 || inv[10].Left <= 40)
                {
                    for (int i = 10; i < 15; i++)
                    {
                        ent[i].speed *= -1;
                        inv[i].Top += ent[i].top;
                    }
                }
                if (inv[15].Left > 300)
                {
                    for (int i = 15; i < 20; i++)
                    {
                        inv[i].Top += ent[i].top;
                        inv[i].Left = -180 + ((i - 15) * 60); 
                    }
                }
            }
            if (LVL.alevel == "8")
            {
                if (inv[0].Left > 390 || inv[0].Left < 120)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        ent[i].speed *= -1;
                        inv[i].Top += ent[i].top;
                    }
                }
                if(inv[2].Left> 390 || inv[2].Left < 120)
                {
                    for (int i = 2; i < 4; i++)
                    {
                        ent[i].speed *= -1;
                        inv[i].Top += ent[i].top;
                    }
                }
            }
            if (LVL.alevel == "9")
            {
                if (inv[0].Left > 200 || inv[0].Left < -20)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        ent[i].speed *= -1;
                        inv[i].Top += ent[i].top;
                    }
                }
                if (inv[10].Left > 200 || inv[10].Left < -20)
                {
                    for (int i = 10; i < 20; i++)
                    {
                        ent[i].speed *= -1;
                        inv[i].Top += ent[i].top;
                    }
                }
                if (inv[20].Left > 200 || inv[20].Left < -20)
                {
                    for (int i = 20; i < 30; i++)
                    {
                        ent[i].speed *= -1;
                        inv[i].Top += ent[i].top;
                    }
                }
                if (inv[30].Left > 200 || inv[30].Left < -20)
                {
                    for (int i = 30; i < 40; i++)
                    {
                        ent[i].speed *= -1;
                        inv[i].Top += ent[i].top;
                    }
                }
                if (inv[40].Left > 300)
                {
                    for (int i = 40; i < 50; i++)
                    {
                        inv[i].Top += ent[i].top;
                        inv[i].Left = -180 + ((i - 40  ) * 30); 
                    }
                }
            }
            if (LVL.alevel == "10")
            {
                if (inv[0].Left > 240 || inv[0].Left <= 20)
                {
                    bos2.speed *= -1;
                    inv[0].Top += ent[0].top;
                }
                if (inv[0].Left > 240)
                {
                    inv[0].Left = 240;
                }
                if (inv[0].Left < 20)
                {
                    inv[0].Left = 20;
                }
            }
        }

        private void GameTimerEvent(object sender, EventArgs e)
        {
            verificare();
            menemies();
            update_progress_bar();
            if(boss>0)
            {
                boss_abilities();
            }
            if(gl==true&&player.Left>0)
            {
                player.Left -= pyr.speed;
            }
            if(gr==true&&player.Left<400)
            {
                player.Left += pyr.speed;
            }
            if (blt.shooting == true||blt.st==true)
            {
                if (blt.st == false)
                {
                    create_bulette();
                    blt.st = true;
                }
                else
                {
                    if (bos2.order != 4 || (bos2.order == 4 && bos2.phs <= 0))
                    {
                        pblt.Top -= blt.speed;
                    }
                    if(boss==2)
                    {
                       if(bos2.order == 4 && bos2.phs <= 0)
                        if ((pblt.Top + pblt.Height) >= invb[0].Top
                    && pblt.Top <= (invb[0].Top + invb[0].Height)
                    && (pblt.Left + pblt.Width) >= invb[0].Left
                    && (pblt.Left) <= (invb[0].Left + invb[0].Height))
                        {
                            pblt.Top = -100;
                            bos2.phs = bos2.aphs;
                            this.Controls.Remove(pblt);
                            blt.st = false;
                            bh -= pyr.damage;
                        }
                    }
                    for(int i=0;i<inv.Length;i++)
                    {
                        if(bos2.order!=4 || (bos2.order == 4 && bos2.phs <= 0))
                        if ((pblt.Top + pblt.Height) >= inv[i].Top
                    && pblt.Top <= (inv[i].Top + inv[i].Height)
                    && (pblt.Left + pblt.Width ) >= inv[i].Left
                    && (pblt.Left) <= (inv[i].Left + inv[i].Height)&&(ent[i].helth>0||bos2.helth>0))
                        {
                            if (boss < 2)
                            {
                                ent[i].helth -= pyr.damage;
                                this.Controls.Remove(pblt);
                                blt.st = false;
                                break;
                            }
                            else
                            {
                                bos2.helth -= pyr.damage;
                                this.Controls.Remove(pblt);
                                blt.st = false;
                            }
                        }
                        if (boss < 2)
                        {
                            if (ent[i].helth <= 0)
                            {
                                this.Controls.Remove(inv[i]);
                                this.Controls.Remove(invb[i]);
                            }
                        }
                        else
                        {
                            if (bos2.helth <= 0)
                            {
                                this.Controls.Remove(inv[i]);
                                this.Controls.Remove(invb[i]);
                            }
                        }
                    }
                    if (bos2.order != 4 || (bos2.order == 4 && bos2.phs <= 0))
                        if (pblt.Top < 0)
                        {
                             this.Controls.Remove(pblt);
                             blt.st = false;
                        }  
                }
            }
            if(bos2.order == 4)
            {
                bos2.phs -= GameTimer.Interval;
            }
            seb();
            caltob();
            check_if_is_endgame();
        }

        private void menemies()
        {
            if(boss<2)
            {
                for (int i = 0; i < inv.Length; i++)
                {
                   // this.BackgroundImage = Properties.Resources.background1;
                    inv[i].Left += ent[i].speed;
                    if (ent[i].fblt <= 0 && ent[i].helth > 0)
                    {
                        eblt[i].shooting = true;
                    }
                    if (ent[i].helth <= 0)
                    {
                        this.Controls.Remove(inv[i]);
                    }
                }
            }
            else
            {
                if (bos2.order != 2)
                {
                    inv[0].Left += bos2.speed;
                    if (bos2.helth <= 0)
                    {
                        this.Controls.Remove(inv[0]);
                    }
                }
            }
        }

        private void add_progress_bar()
        {
            pb = new ProgressBar[inv.Length];
            for(int i=0;i<inv.Length;i++)
            {
                pb[i] = new ProgressBar();
                pb[i].Width = inv[i].Width*2/3;
                pb[i].Height = 5;
                pb[i].Top = inv[i].Top - 5;
                pb[i].Left = inv[i].Left + inv[i].Width * 1 / 5;
                pb[i].Value = 100;
                this.Controls.Add(pb[i]);
                pb[i].BringToFront();
            }
        }

        private void update_progress_bar()
        {
            if(boss<2)
            {
                for (int i = 0; i < inv.Length; i++)
                {
                    pb[i].Top = inv[i].Top - 5;
                    pb[i].Left = inv[i].Left + inv[i].Width * 1 / 5;
                    if (ent[i].helth > 0)
                    {
                        pb[i].Value = ent[i].helth * 100 / ent[i].ihelth;
                    }
                    else
                    {
                        this.Controls.Remove(pb[i]);
                    }
                }
            }
            else
            {
                pb[0].Top = inv[0].Top - 5;
                pb[0].Left = inv[0].Left + inv[0].Width * 1 / 5;
                if(bos2.helth > 0)
                {
                    pb[0].Value = bos2.helth * 100 / bos2.ahelth;
                }
                else
                {
                    this.Controls.Remove(pb[0]);
                }
            }
        }
        private void addlvl()
        {
            if (LVL.level == LVL.alevel && Int32.Parse(LVL.level) < 10)
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database\SpaceInvaders.mdf;Integrated Security=True");

                    con.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE Login SET Level=@level WHERE Username = @id", con);
                    cmd.Parameters.AddWithValue("id", LVL.username);
                    cmd.Parameters.AddWithValue("level", (Int32.Parse(LVL.level) + 1).ToString());
                    LVL.level = (Int32.Parse(LVL.level) + 1).ToString();
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    con.Close();
            }
        }

        private void check_if_is_endgame()
        {
            bool yw = true;
            bool yl = false;
            if (boss < 2)
            {
                for (int i = 0; i < ent.Length; i++)
                    if (ent[i].helth > 0)
                    {
                        yw = false;
                        break;
                    }
            }
            else
            {
                if(bos2.helth>0)
                {
                    yw = false;
                }
            }
            for(int i=0;i<invb.Length;i++)
            {
                if((invb[i].Top+invb[i].Height*3/4) >= player.Top 
                    && (invb[i].Top) <= (player.Height*2/3 + player.Top) 
                    && (invb[i].Left + invb[i].Width*2/3) >= (player.Left) 
                    && (invb[i].Left) <= (player.Width*2/3 + player.Left))
                if((bos2.order<=1 && (eblt[i].shooting == true || eblt[i].st == true)) 
                   || ((bos2.order == 3 && i == 0) || (bos2.order == 4 && bh > 0 && i == 0)))  
                    {
                        if (boss == 0)
                        {
                            pyr.helth -= ent[i].damage;
                        }
                        else
                            if(boss == 1)
                        {
                            pyr.helth -= ent[0].damage;
                        }
                        else
                            if(boss == 2)
                        {
                            pyr.helth -= bos2.damage;
                        }
                        eblt[i].shooting = false;
                        eblt[i].st = false;
                        this.Controls.Remove(invb[i]);
                        label3.Text = ("helth: " + pyr.helth.ToString());
                    }
                if (boss == 0)
                {
                    if ((inv[i].Top+inv[i].Height) >= player.Top 
                        && inv[i].Left >= player.Left 
                        && inv[i].Left <= (player.Width + player.Left)
                        && ent[i].helth > 0)
                    {
                        pyr.helth -= ent[i].bdamage;
                        eblt[i].shooting = false;
                        eblt[i].st = false;
                        ent[i].helth -= pyr.bdamage;
                        label3.Text = ("helth: " + pyr.helth.ToString());
                    }
                    if (inv[i].Top >= 500 && ent[i].helth > 0)
                    {
                        yl = true;
                        break;
                    }
                }
                if(boss == 1)
                {
                    if ((inv[0].Top + inv[0].Height) >= player.Top
                    && (inv[0].Top) <= (player.Height + player.Top)
                    && (inv[0].Left + inv[0].Width) >= (player.Left)
                    && (inv[0].Left) <= (player.Width + player.Left))
                    {
                        pyr.helth -= ent[0].bdamage;
                        label3.Text = ("helth: " + pyr.helth.ToString());
                    }
                }
                if(boss == 2)
                {
                    {
                        if ((inv[0].Top + inv[0].Height) >= player.Top
                        && (inv[0].Top) <= (player.Height + player.Top)
                        && (inv[0].Left + inv[0].Width) >= (player.Left)
                        && (inv[0].Left) <= (player.Width + player.Left))
                        {
                            pyr.helth -= bos2.bdamage;
                            label3.Text = ("helth: " + pyr.helth.ToString());
                        }
                    }
                }
            }

            if(pyr.helth<=0)
            {
                this.Controls.Remove(player);
                Thread.Sleep(1000);
                yl = true;
            }

            if(yw==true)
            {
                LVL.yw = true;
                GameTimer.Stop();
                addlvl();
                Form f6 = new Form6();
                this.Close();
                f6.Show();
            }
            else if(yl==true)
            {
                LVL.yw = false;
                GameTimer.Stop();
                Form f6 = new Form6();
                this.Close();
                f6.Show();
            }
        }
        private void Form6_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right && pyr.x <= 380)
            {
                gr = false;
            }
            if (e.KeyCode == Keys.Left && pyr.x >= 40)
            {
                gl = false;
            }
            if(e.KeyCode==Keys.Space)
            {
                blt.shooting = false;
            }
        }

        private void Form6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right&&pyr.x<=380)
            {
                gr = true;
            }
            if (e.KeyCode == Keys.Left&&pyr.x>=40)
            {
                gl = true;
            }
            if (e.KeyCode == Keys.Space)
            {
                blt.shooting = true;
            }
        }
    }
}
