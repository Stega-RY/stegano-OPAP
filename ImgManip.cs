using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test2
{
    public class ImageEventArgs :EventArgs {
        public Bitmap bmap { get; set; }
    }
    class ImgManip
    {
        public event EventHandler<ImageEventArgs> ImageFinished;

        protected virtual void OnImageFinished(Bitmap bmap) {

            ImageFinished?.Invoke(this, new ImageEventArgs() { bmap = bmap });
        }

            public void Manipulate(object bmp) {
            Bitmap bmap = (Bitmap)bmp;

            Color theColor = new Color();


            for (int i= 0;i< bmap.Width; i++){
                for(int j = 0; j < bmap.Height; j++)
                {
                    theColor = bmap.GetPixel(i, j);

                    Color newColor = Color.FromArgb(150, theColor.G, 150);

                    bmap.SetPixel(i, j, newColor);
                }
            }
            OnImageFinished(bmap);
        }
 



    }
}
