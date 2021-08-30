using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Control c;
        Control subc;
        public static int row = 0, col = 50;
        private void toolStripButton1_Click(object sender, EventArgs e)//textbox
        {
            col += 30;
            if (col > 350)
            {
                col = 40;
                row += 120;
            }
            else if (row > 480)
            {
                row = 5;
            }
            this.c = new TextBox();
            c.Location = new Point(row, col);
            c.MouseUp += new MouseEventHandler(mainC_MouseUp);
            c.MouseDown += new MouseEventHandler(mainC_MouseDown);
            c.MouseMove += new MouseEventHandler(mainC_ButtonOnClick);
            panel1.Controls.Add(c);
            
        }

        private void toolStripButton2_Click(object sender, EventArgs e)//label
        {
            col += 30;
            if (col > 350)
            {
                col = 40;
                row += 120;
            }
            else if (row > 480)
            {
                row = 5;
            }
            this.c = new Label();
            c.BackColor = Color.Gainsboro;
            c.Location = new Point(row, col);
            c.MouseUp += new MouseEventHandler(mainC_MouseUp);
            c.MouseDown += new MouseEventHandler(mainC_MouseDown);
            c.MouseMove += new MouseEventHandler(mainC_ButtonOnClick);
            panel1.Controls.Add(c);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)//checkbox
        {
            col += 30;
            if (col > 350)
            {
                col = 40;
                row += 120;
            }
            else if (row > 480)
            {
                row = 5;
            }
            this.c = new CheckBox();
            c.BackColor = Color.Gainsboro;
            c.Location = new Point(row, col);
            c.MouseUp += new MouseEventHandler(mainC_MouseUp);
            c.MouseDown += new MouseEventHandler(mainC_MouseDown);
            c.MouseMove += new MouseEventHandler(mainC_ButtonOnClick);
            panel1.Controls.Add(c);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)//combobox
        {
            col += 30;
            if (col > 350)
            {
                col = 40;
                row += 120;
            }
            else if (row > 480)
            {
                row = 5;
            }
            this.c = new ComboBox();
            c.BackColor = Color.Gainsboro;
            c.Location = new Point(row, col);
            c.MouseUp += new MouseEventHandler(mainC_MouseUp);
            c.MouseDown += new MouseEventHandler(mainC_MouseDown);
            c.MouseMove += new MouseEventHandler(ComboBox_ButtonOnClick);
            panel1.Controls.Add(c);

        }

        private void toolStripButton5_Click(object sender, EventArgs e)//button
        {
            col += 30;
            if (col > 350)
            {
                col = 40;
                row += 120;
            }
            else if (row > 480)
            {
                row = 5;
            }
            this.c = new Button();
            c.Location = new Point(row, col);
            c.MouseUp += new MouseEventHandler(mainC_MouseUp);
            c.MouseDown += new MouseEventHandler(mainC_MouseDown);
            c.MouseMove += new MouseEventHandler(mainC_ButtonOnClick);
            c.MouseDown += new MouseEventHandler(stretchingC_MouseDown);
            panel1.Controls.Add(c);
        }


        //ВСЕ МЕТОДЫ
        int MouseX;
        int MouseY;
        int fromLeftCornerToMouseX;
        int fromLeftCornerToMouseY;
        public static bool moving;
        public static bool stretching;
        public static bool stretchingcombo;
        //Moving
        public void mainC_MouseUp(object sender, MouseEventArgs e)//отмена перетаскивания при отпускании мышки
        {
            moving = false;
            Control mainC = (Control)sender;
            mainC.Cursor = Cursors.IBeam;
        }
        public void mainC_MouseDown(object sender, MouseEventArgs e)//активация перетаскивания через moving после клика
        {
            Control mainC = (Control)sender;
            fromLeftCornerToMouseX = Cursor.Position.X - mainC.Location.X;
            fromLeftCornerToMouseY = Cursor.Position.Y - mainC.Location.Y;
            mainC.Cursor = Cursors.Hand;
            moving = true;
            ((Control)sender).BringToFront();
            c = (Control)sender;
            subc = (Control)sender;
        }
        public void mainC_ButtonOnClick(object sender, MouseEventArgs e)//перетаскивание через удержание мышки для всех, кроме combobox
        {

            if (moving == true)
            {
                ((Control)sender).Location = new Point((Cursor.Position.X - fromLeftCornerToMouseX),(Cursor.Position.Y - fromLeftCornerToMouseY));
            }
            Control mainC = (Control)sender;
            MouseX = Cursor.Position.X - this.Location.X - mainC.Location.X - 20; 
            MouseY = Cursor.Position.Y - this.Location.Y - mainC.Location.Y - 75;
            if (MouseX > mainC.Width - 8 && MouseX < mainC.Width + 8)
            {
                Cursor = Cursors.SizeNWSE;
                mainC.AutoSize = false;
                mainC.MouseDown += new MouseEventHandler(stretchingC_MouseDown);
                mainC.MouseUp += new MouseEventHandler(stretchingC_MouseUp);
                mainC.MouseMove += new MouseEventHandler(stretchingC_MouseMove);
            }
            else
            {
                Cursor = Cursors.Default;
            }

        }
        public void ComboBox_ButtonOnClick(object sender, MouseEventArgs e)//перетаскивание через удержание мышки только для combobox
        {

            if (moving == true)
            {
                ((Control)sender).Location = new Point((Cursor.Position.X - fromLeftCornerToMouseX), (Cursor.Position.Y - fromLeftCornerToMouseY));
            }
            Control mainC = (Control)sender;
            MouseX = Cursor.Position.X - this.Location.X - mainC.Location.X - 20;
            MouseY = Cursor.Position.Y - this.Location.Y - mainC.Location.Y - 75;
            if (MouseX > mainC.Width - 8 && MouseX < mainC.Width + 8)
            {
                Cursor = Cursors.SizeNWSE;
                mainC.AutoSize = false;
                mainC.MouseDown += new MouseEventHandler(stretchingC_MouseDown);
                mainC.MouseUp += new MouseEventHandler(stretchingC_MouseUp);
                mainC.MouseMove += new MouseEventHandler(ComboBox_MouseMove);
            }
            else
            {
                Cursor = Cursors.Default;
            }

        }
        //Stretching
        private void stretchingC_MouseDown(object sender, MouseEventArgs e)
        {
            Control stretchinC = (Control)sender;
            if(MouseX < stretchinC.Width+8 && MouseX > stretchinC.Width - 8)
            {
                moving = false;
                stretching = true;
                stretchingcombo = true;
            }
        }
        private void stretchingC_MouseUp(object sender, MouseEventArgs e)
        {
            stretching = false;
            stretchingcombo = false;
        }
        private void stretchingC_MouseMove(object sender, MouseEventArgs e)
        {
            Control stretchinC = (Control)sender;
            if (stretching ==true)
            {
                stretchinC.Width = Cursor.Position.X - stretchinC.Location.X - this.Location.X - 20;
                stretchinC.Height = Cursor.Position.Y - stretchinC.Location.Y - this.Location.Y - 70;
            }
            
        }
        private void ComboBox_MouseMove(object sender, MouseEventArgs e)
        {
            Control stretchinC = (Control)sender;
            if (stretchingcombo== true)
            {
                stretchinC.Width = Cursor.Position.X - stretchinC.Location.X - this.Location.X - 15;
            }

        }

        private void button1_Click(object sender, EventArgs e)//save config
        {
            if(textBox5.Text != "")
            {
                subc.Text = textBox5.Text;
            }
            int mycheck;
            if(int.TryParse(textBox1.Text, out mycheck))
            {
                subc.Width = int.Parse(textBox1.Text);
            }
            else
            {
                
            }
            if (int.TryParse(textBox2.Text, out mycheck))
            {
                subc.Height = int.Parse(textBox2.Text);
            }
            else
            {
                
            }
            if((int.TryParse(textBox3.Text, out mycheck)) && (int.TryParse(textBox4.Text, out mycheck)))
            {
                subc.Location = new Point(int.Parse(textBox3.Text), int.Parse(textBox4.Text));
            }
            else
            {
                
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)//inner text
        {
            subc.Text = textBox5.Text;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)//delete
        {
            panel1.Controls.Remove(subc);
        }





    }
}
