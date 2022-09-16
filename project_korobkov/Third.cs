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
    public partial class Third : Form
    {
        public Third()
        {
            InitializeComponent();
        }
        List<int> lst = new List<int>();
        PictureBox pic;
        Random rnd = new Random();
        int x, y, number, name, checkI1, checkI2, checkI3, checkI4, winCheckI, schet, tik, checkIE1, checkIE2, checkX, checkY;
        bool checkB = false, ex = true;
        Object ob, checkO1, checkO2;
        string checkS, winTag1, winTag2, time;
        public string picSelect, picSize, itogPic;
        string[] winArray = new string[25];
        public int size, quantity, forquantity;
        DialogResult res;
        private void Third_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ex)
            {
                Application.Exit();
                Environment.Exit(0);
            }
        }
        private void clear()
        {
            if (timer1.Enabled)
            {
                sending.Itog.Add("Результат - поражение" + "\r\n" + "Уровень - сложный" + "\r\n" + "Картинка - " + itogPic.ToLower() + "\r\n" + "Размер поля - " + picSize.ToString());
                if (picSelect == "h")
                {
                    sending.ItogPic.Add(picSelect + picSize);
                }
                else
                {
                    sending.ItogPic.Add(picSelect);
                }
            }
            x = 0;
            y = 0;
            progressBar1.Value = 1;
            timer1.Stop();
            tik = 1;
            lst.Clear();
            panel1.Controls.Clear();
            button1.Text = "Старт";
        }
        private void btnRes_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                timer1.Stop();
                res = MessageBox.Show("Вы уверены, что хотите посмотреть результат?\r\nТекущая игра завершится и засчитается, как поражение.", "", MessageBoxButtons.YesNo);
                timer1.Start();
                if (res == DialogResult.No)
                {
                    return;
                }
            }
            end frm2 = new end();
            this.Hide();
            clear();
            frm2.ShowDialog();
            this.Show();
            frm2.Dispose();
        }
        private void Third_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                winArray[i] = i.ToString() + "0";
            }
            for (int i = 10; i < quantity; i++)
            {
                winArray[i] = i.ToString();
            }
        }
        private void BtnMenu_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                timer1.Stop();
                res = MessageBox.Show("Вы уверены, что хотите выйти в меню?\r\nТекущая игра завершится и засчитается, как поражение.", "", MessageBoxButtons.YesNo);
                timer1.Start();
                if (res == DialogResult.No)
                {
                    return;
                }
            }
            ex = false;
            clear();
            this.Close();
            this.Dispose();
        }
        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                pictureBox1.Visible = true;
                if (picSelect == "h")
                {
                    ob = Properties.Resources.ResourceManager.GetObject(picSelect + picSize);
                    pictureBox1.Image = (Bitmap)ob;
                }
                else
                {
                    ob = Properties.Resources.ResourceManager.GetObject(picSelect);
                    pictureBox1.Image = (Bitmap)ob;
                }
            }
            else
            {
                pictureBox1.Visible = false;
            }
        }
        private void Timer1_Tick(object sender, EventArgs e)
        {
            tik++;
            if (progressBar1.Value != progressBar1.Maximum)
            {
                progressBar1.Value = tik;
            }
            if (tik == 3003)
            {
                timer1.Stop();
                sending.Itog.Add("Результат - поражение" + "\r\n" + "Уровень - сложный" + "\r\n" + "Картинка - " + itogPic.ToLower() + "\r\n" + "Размер поля - " + picSize.ToString());
                if (picSelect == "h")
                {
                    sending.ItogPic.Add(picSelect + picSize);
                }
                else
                {
                    sending.ItogPic.Add(picSelect);
                }
                MessageBox.Show("Вы проиграли!");
                button1.Text = "Старт";
                panel1.Controls.Clear();
                progressBar1.Value = 1;
            }
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                timer1.Stop();
                res = MessageBox.Show("Вы уверены, что хотите закончить игру?\r\nТекущая игра завершится и засчитается, как поражение.", "", MessageBoxButtons.YesNo);
                timer1.Start();
                if (res == DialogResult.No)
                {
                    return;
                }
                else
                {
                    clear();
                    button1.Text = "Старт";
                    return;
                }
            }
            clear();
            timer1.Start();
            button1.Text = "Завершить";
            for (int i = 0; i < forquantity; i++)
            {
                for (int j = 0; j < forquantity; j++)
                {
                    pic = new PictureBox();
                    pic.Name = name.ToString();
                    while (lst.Contains(number)) number = rnd.Next(quantity);
                    lst.Add(number);
                    name++;
                    if (number == quantity - 1)
                    {
                        pic.Tag = i + "" + j + "" + "" + 1 + number + "0";
                    }
                    else
                    {
                        if (picSelect == "h")
                        {

                            ob = Properties.Resources.ResourceManager.GetObject(picSelect + (number + 1));
                            pic.Image = (Bitmap)ob;
                            pic.Tag = i + "" + j + "" + "" + 0 + number + "0";
                        }
                        else
                        {
                            ob = Properties.Resources.ResourceManager.GetObject(picSelect + picSize + (number + 1));
                            pic.Image = (Bitmap)ob;
                            pic.Tag = i + "" + j + "" + "" + 0 + number + "0";
                        }
                    }
                    pic.Size = new Size(size, size);
                    pic.Location = new Point(x + 10, y + 10);
                    pic.SizeMode = PictureBoxSizeMode.StretchImage;
                    panel1.Controls.Add(pic);
                    pic.Click += Pic_Click;
                    x += size;
                }
                x = 0;
                y += size;
            }
        }
        private void Pic_Click(object sender, EventArgs e)
        {
            schet = 0;
            winCheckI = 0;
            PictureBox pic = (PictureBox)sender;
            for (int i = 0; i < quantity; i++)
            {
                (panel1.Controls[i] as PictureBox).BorderStyle = BorderStyle.None;
            }
            pic.BorderStyle = BorderStyle.Fixed3D;
            if (!checkB)
            {
                checkB = true;

                checkO1 = pic.Image;
                checkI1 = Convert.ToInt16(pic.Tag.ToString()[0].ToString());
                checkI2 = Convert.ToInt16(pic.Tag.ToString()[1].ToString());
                checkIE1 = Convert.ToInt16(pic.Tag.ToString()[2].ToString());
                winTag1 = pic.Tag.ToString().Substring(3, 2);
                checkS = pic.Name;
            }
            else
            {
                checkB = false;
                checkI3 = Convert.ToInt16(pic.Tag.ToString()[0].ToString());
                checkI4 = Convert.ToInt16(pic.Tag.ToString()[1].ToString());
                checkIE2 = Convert.ToInt16(pic.Tag.ToString()[2].ToString());
                checkX = Math.Abs(checkI1 - checkI3);
                checkY = Math.Abs(checkI2 - checkI4);
                winTag2 = pic.Tag.ToString().Substring(3, 2);
                if (checkX <= 1 && checkY <= 1 && (checkX != checkY) && checkIE1 == 1)
                {
                    pic.Tag = checkI3 + "" + checkI4 + "" + 1 + "" + winTag1;
                    checkO2 = pic.Image;
                    pic.Image = (Bitmap)checkO1;
                    (panel1.Controls[checkS] as PictureBox).Image = (Bitmap)checkO2;
                    (panel1.Controls[checkS] as PictureBox).BorderStyle = BorderStyle.None;
                    (panel1.Controls[checkS] as PictureBox).Tag = checkI1 + "" + checkI2 + "" + 0 + "" + winTag2;

                }
                else
                {
                    if (checkX <= 1 && checkY <= 1 && (checkX != checkY) && checkIE2 == 1)
                    {
                        pic.Tag = checkI3 + "" + checkI4 + "" + 0 + "" + winTag1;
                        checkO2 = pic.Image;
                        pic.Image = (Bitmap)checkO1;
                        (panel1.Controls[checkS] as PictureBox).Image = (Bitmap)checkO2;
                        (panel1.Controls[checkS] as PictureBox).BorderStyle = BorderStyle.None;
                        (panel1.Controls[checkS] as PictureBox).Tag = checkI1 + "" + checkI2 + "" + 1 + "" + winTag2;
                    }
                }
                pic.BorderStyle = BorderStyle.None;
            }
            foreach (PictureBox p in panel1.Controls)
            {
                if (p.Tag.ToString().Substring(3, 2) == winArray[schet])
                {
                    winCheckI++;
                }
                schet++;
            }
            if (winCheckI == quantity)
            {
                tik = tik / 10;
                if (tik > 9 && tik < 20)
                {
                    time = "секунд";
                }
                else
                {
                    switch (tik % 10)
                    {
                        case 1:
                            time = "секунда";
                            break;
                        case 2:
                        case 3:
                        case 4:
                            time = "секунды";
                            break;
                        default:
                            time = "секунд";
                            break;
                    }
                }
                timer1.Stop();
                sending.Itog.Add("    Результат - победа" + "\r\n" + "    Уровень - сложный" + "\r\n" + "    Время - " + tik + " " + time + "\r\n" + "    Картинка - " + itogPic.ToLower() + "\r\n" + "    Размер поля - " + picSize.ToString());
                if (picSelect == "h")
                {
                    sending.ItogPic.Add(picSelect + picSize);
                }
                else
                {
                    sending.ItogPic.Add(picSelect);
                }
                MessageBox.Show("Вы победили!");
                button1.Text = "Старт";
                panel1.Controls.Clear();
                progressBar1.Value = 1;
            }
        }
    }
}
