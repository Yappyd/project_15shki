using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace project_korobkov
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool dif = false;
        PictureBox pic;
        int x, y, number, rand1, rand2, rand3, rand4, checkX, checkY, rand, size, quantity, forquantity, size2;
        Object ob, p1, p2;
        string xy1, xy2, picSelect, picSize;
        List<int> lst = new List<int>();
        Random rnd = new Random();
        private void btnRes_Click(object sender, EventArgs e)
        {
            end frm2 = new end();
            this.Hide();
            frm2.ShowDialog();
            this.Show();
            frm2.Dispose();

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ComboBox1.SelectedIndex)
            {
                case 0:
                    picSelect = "h";
                    break;
                case 1:
                    picSelect = "s";
                    break;
                case 2:
                    picSelect = "c";
                    break;
                case 3:
                    picSelect = "p";
                    break;
            }
            if (radioButton1.Checked == false)
            {
                Hard();
            }
            else
            {
                Easy();
            }
        }
        private void cmbSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbSize.SelectedIndex)
            {
                case 0:
                    size = 60;
                    quantity = 9;
                    forquantity = 3;
                    picSize = "3x3";
                    size2 = 140;
                    break;
                case 1:
                    size = 45;
                    quantity = 16;
                    forquantity = 4;
                    picSize = "4x4";
                    size2 = 105;
                    break;
                case 2:
                    size = 36;
                    quantity = 25;
                    forquantity = 5;
                    picSize = "5x5";
                    size2 = 84;
                    break;
            }
            if (!radioButton1.Checked)
            {
                Hard();
            }
            else
            {
                Easy();
            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (!radioButton1.Checked)
            {
                p2 = (panel1.Controls[xy2] as PictureBox).Image;
                (panel1.Controls[xy1] as PictureBox).Image = (Bitmap)p2;
                (panel1.Controls[xy2] as PictureBox).BorderStyle = BorderStyle.None;
                (panel1.Controls[xy1] as PictureBox).BorderStyle = BorderStyle.None;
                (panel1.Controls[xy2] as PictureBox).Image = null;
                (panel1.Controls[xy1] as PictureBox).Name = xy1.Substring(0, 2);
                (panel1.Controls[xy2] as PictureBox).Name += "a";
                xy1 = (panel1.Controls[xy2 + "a"] as PictureBox).Name;
                rand1 = Convert.ToInt16((panel1.Controls[xy1] as PictureBox).Name.ToString()[0].ToString());
                rand2 = Convert.ToInt16((panel1.Controls[xy1] as PictureBox).Name.ToString()[1].ToString());
            }
            else
            {
                p1 = (panel1.Controls[xy1] as PictureBox).Image;
                p2 = (panel1.Controls[xy2] as PictureBox).Image;
                (panel1.Controls[xy1] as PictureBox).Image = (Bitmap)p2;
                (panel1.Controls[xy2] as PictureBox).Image = (Bitmap)p1;
                (panel1.Controls[xy1] as PictureBox).BorderStyle = BorderStyle.None;
            }
            timer1.Start();
        }
        private void xy()
        {
            rand3 = rnd.Next(forquantity);
            rand4 = rnd.Next(forquantity);
            checkX = Math.Abs(rand1 - rand3);
            checkY = Math.Abs(rand2 - rand4);
        }
        private void Easy()
        {
            x = 0;
            y = 0;
            lst.Clear();
            number = 0;
            timer1.Stop();
            timer2.Stop();
            panel1.Controls.Clear();
            for (int i = 0; i < forquantity; i++)
            {
                for (int j = 0; j < forquantity; j++)
                {
                    pic = new PictureBox();
                    pic.Name = i + "" + j;
                    while (lst.Contains(number)) number = rnd.Next(quantity);
                    lst.Add(number);
                    if (picSelect == "h")
                    {
                        ob = Properties.Resources.ResourceManager.GetObject(picSelect + (number + 1));
                        pic.Image = (Bitmap)ob;
                    }
                    else
                    {
                        ob = Properties.Resources.ResourceManager.GetObject(picSelect + picSize + (number + 1));
                        pic.Image = (Bitmap)ob;
                    }
                    pic.Size = new Size(size, size);
                    pic.Location = new Point(x + 5, y + 5);
                    pic.SizeMode = PictureBoxSizeMode.StretchImage;
                    panel1.Controls.Add(pic);
                    x += size;
                }
                x = 0;
                y += size;
            }
            timer1.Start();
            timer2.Start();
        }
        private void Hard()
        {
            x = 0;
            y = 0;
            lst.Clear();
            number = 0;
            timer1.Stop();
            timer2.Stop();
            panel1.Controls.Clear();
            for (int i = 0; i < forquantity; i++)
            {
                for (int j = 0; j < forquantity; j++)
                {
                    pic = new PictureBox();
                    pic.Name = i + "" + j;
                    while (lst.Contains(number)) number = rnd.Next(quantity);
                    lst.Add(number);
                    if (number == quantity - 1)
                    {
                        pic.Name += "a";
                        rand1 = i;
                        rand2 = j;
                        xy1 = pic.Name;
                    }
                    else
                    {
                        if (picSelect == "h")
                        {
                            ob = Properties.Resources.ResourceManager.GetObject(picSelect + (number + 1));
                            pic.Image = (Bitmap)ob;
                        }
                        else
                        {
                            ob = Properties.Resources.ResourceManager.GetObject(picSelect + picSize + (number + 1));
                            pic.Image = (Bitmap)ob;
                        }
                    }
                    pic.Size = new Size(size, size);
                    pic.Location = new Point(x + 5, y + 5);
                    pic.SizeMode = PictureBoxSizeMode.StretchImage;
                    panel1.Controls.Add(pic);
                    x += size;
                }
                x = 0;
                y += size;
            }
            timer1.Start();
            timer2.Start();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!radioButton1.Checked)
            {
                rand = rnd.Next(2);
                if (rand == 1)
                {
                    (panel1.Controls[xy1] as PictureBox).BorderStyle = BorderStyle.Fixed3D;
                    do
                    {
                        xy();
                    }
                    while (checkX > 1 || checkY > 1 || (checkX == checkY));
                    xy2 = rand3.ToString() + rand4.ToString();
                }
                else
                {
                    do
                    {
                        xy();
                    }
                    while (checkX > 1 || checkY > 1 || (checkX == checkY));
                    xy2 = rand3.ToString() + rand4.ToString();
                    (panel1.Controls[xy2] as PictureBox).BorderStyle = BorderStyle.Fixed3D;
                }
            }
            else
            {
                rand1 = rnd.Next(forquantity);
                rand2 = rnd.Next(forquantity);
                xy1 = rand1.ToString() + rand2.ToString();
                (panel1.Controls[xy1] as PictureBox).BorderStyle = BorderStyle.Fixed3D;
                do
                {
                    xy();
                }
                while (checkX > 1 || checkY > 1 || (checkX == checkY));
                xy2 = rand3.ToString() + rand4.ToString();
            }
            timer1.Stop();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            Second frm = new Second();
            Third frm1 = new Third();

            if (!dif)
            {
                frm.picSelect = picSelect;
                frm.picSize = picSize;
                frm.forquantity = forquantity;
                frm.quantity = quantity;
                frm.size = size2;
                frm.itogPic = ComboBox1.SelectedItem.ToString();
                this.Hide();
                frm.ShowDialog();
                this.Show();
                frm.Dispose();

            }
            else
            {
                frm1.picSelect = picSelect;
                frm1.picSize = picSize;
                frm1.forquantity = forquantity;
                frm1.quantity = quantity;
                frm1.size = size2;
                frm1.picSelect = picSelect;
                frm1.itogPic = ComboBox1.SelectedItem.ToString();
                this.Hide();
                frm1.ShowDialog();
                this.Show();
                frm1.Dispose();
            }

        }
        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            x = 0;
            y = 0;
            lst.Clear();
            if (!radioButton1.Checked)
            {
                dif = true;
                panel1.Controls.Clear();
                Hard();
            }
            else
            {
                dif = false;
                panel1.Controls.Clear();
                Easy();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            end frm2 = new end();
            ComboBox1.SelectedIndex = 0;
            cmbSize.SelectedIndex = 1;
            Easy();
            timer1.Start();
            timer2.Start();
        }
    }
}
