using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test2
{
    public partial class Form1 : Form
    {

        Bitmap newFile;
        ImgManip modifyRGB = new ImgManip();
        FileOperations getFile = new FileOperations();

        public Form1()
        {
            InitializeComponent();
            Manipulate.Enabled = false;
            modifyRGB.ImageFinished += OnImageFinished;
        }

        public void DisplayImage(Bitmap b,int window)
        {
            if (window == 1)
            {
                pictureBox1.Image = b;
            }else if (window == 2)
            {
                pictureBox2.Image = b;
            }else
            {
                pictureBox1.Image = b;
                pictureBox2.Image = b;
            }
            Manipulate.Enabled = true;

        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String imageLocation = "";
            try {

                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files|*.jpg|png files|*.png|All Files|*.*";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    imageLocation = dialog.FileName;
                    pictureBox1.ImageLocation= imageLocation;


                    
                }
            }
            catch (Exception) {
                MessageBox.Show("An eror occured","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
           


        }

       
        
        private void button2_Click(object sender, EventArgs e)
        {
            /* Form2 f = new Form2();
             f.Show();*/

            newFile = getFile.OpenFile();
            DisplayImage(newFile, 3);
        }

        private void Manipulate_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            this.timer1.Start();
            #region Call ImgManip Class

            Thread t1 = new Thread(new ParameterizedThreadStart(modifyRGB.Manipulate));
            t1.Start(newFile);
           
            #endregion

        }

        public void OnImageFinished(object sender,ImageEventArgs e)
        {
            DisplayImage(e.bmap,2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel2.Height = button4.Height;
            panel2.Top = button4.Top;
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            panel2.Height = button1.Height;
            panel2.Top = button1.Top;
            
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel2.Height = button3.Height;
            panel2.Top = button3.Top;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.progressBar1.Increment(1);
        }
    }
}
