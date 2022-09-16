using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project_korobkov
{
    public partial class end : Form
    {
        public end()
        {
            InitializeComponent();
        }
        Button btn;
        PictureBox pic;
        int y = 10;
        Object ob;
        bool ex = true;
        private void end_Load(object sender, EventArgs e)
        {
            if (sending.Itog.Count == 0)
            {
                lbl1.Text = "Здесь пока ничего нет";
            }
            if (sending.Itog.Count >= 5)
            {
                panel1.Size = new Size(170, 374);
                lbl1.Location = new Point(188, 9);
                lblRes.Location = new Point(188, 29);
                pic1.Location = new Point(188, 170);
                btnEx.Location = new Point(188, 360);
                this.Size = new Size(400, 434);
            }
            for (int i = 0; i < sending.Itog.Count; i++)
            {
                pic = new PictureBox();
                ob = Properties.Resources.ResourceManager.GetObject(sending.ItogPic.ElementAt(i));
                pic.Image = (Bitmap)ob;
                pic.Location = new Point(90, y);
                pic.Size = new Size(50, 50);
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                panel1.Controls.Add(pic);
                btn = new Button();
                btn.Text = "Игра №" + (i + 1).ToString();
                btn.Tag = i;
                btn.Location = new Point(10, y + 13);
                btn.Click += Btn_Click;
                panel1.Controls.Add(btn);
                y += 100;
            }

        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            lbl1.Text = "Игра № " + ((int)btn.Tag + 1).ToString();
            lblRes.Text = sending.Itog.ElementAt((int)btn.Tag);
            ob = Properties.Resources.ResourceManager.GetObject(sending.ItogPic.ElementAt((int)btn.Tag));
            pic1.Image = (Bitmap)ob;
        }

        private void btnEx_Click(object sender, EventArgs e)
        {
            ex = false;
            this.Close();
            this.Dispose();
        }
        private void end_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ex)
            {
                Application.Exit();
                Environment.Exit(0);
            }
        }
    }
}