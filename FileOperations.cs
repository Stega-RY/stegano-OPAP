using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test2
{
    class FileOperations
    {
        Bitmap newImage;
        public Bitmap OpenFile()
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.InitialDirectory = "C:\\Users\\Ray\\Desktop";
          //  ofd.Filter = " Images |*.png *.bmp *.jpg";
            ofd.Filter= "jpg files|*.jpg|png files|*.png|bmp files | *.bmp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                newImage = new Bitmap(Image.FromFile(ofd.FileName));
            }

            return newImage;
        }


    }
}
