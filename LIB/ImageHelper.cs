using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace LIB
{
    public class ImageHelper
    {
        HttpRequest Request;
        public ImageHelper()
        {
            Request = HttpContext.Current.Request;
        }

        public void Resize(string PhotoPath, string SavePath, int W)
        {

            System.IO.FileStream fs = new System.IO.FileStream(PhotoPath, FileMode.Open, FileAccess.ReadWrite);
            byte[] imgData = new byte[fs.Length];

            fs.Read(imgData, 0, int.Parse(fs.Length.ToString()));
            fs.Close();

            
            System.Drawing.Image img = System.Drawing.Image.FromStream(new MemoryStream(imgData));

            int OrgW = img.Width;
            int OrgH = img.Height;

            int newW = 0;
            int newH = 0;

            if (OrgW > W)
            {
                newW = W;
                newH = (int)(OrgH / ((double)OrgW / W));

                Bitmap b = new Bitmap(newW, newH);
                Graphics g = Graphics.FromImage((System.Drawing.Image)b);
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(img, 0, 0, newW, newH);
                g.Dispose();

                img = (System.Drawing.Image)b;
            }

            img.Save(SavePath);
        }

        public void Crop(string PhotoPath, string SavePath, int W, int H, bool Resizing)
        {

            System.IO.FileStream fs = new System.IO.FileStream(PhotoPath, FileMode.Open, FileAccess.ReadWrite);
            byte[] imgData = new byte[fs.Length];

            fs.Read(imgData, 0, int.Parse(fs.Length.ToString()));
            fs.Close();

            System.Drawing.Image img = System.Drawing.Image.FromStream(new MemoryStream(imgData));            

            if (Resizing)
            {
                if (img.Width > W)
                {
                    int resizeH = (int)(img.Height / ((double)img.Width / W));
                    Bitmap bmpResize = new Bitmap(W, resizeH);
                    Graphics gResize = Graphics.FromImage((System.Drawing.Image)bmpResize);
                    gResize.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    gResize.DrawImage(img, 0, 0, W, resizeH);
                    gResize.Dispose();

                    img = (System.Drawing.Image)bmpResize;          
                }

                else if (img.Height > H)
                {
                    int resizeW = (int)(img.Width / ((double)img.Height / H));
                    Bitmap bmpResize = new Bitmap(resizeW, H);
                    Graphics gResize = Graphics.FromImage((System.Drawing.Image)bmpResize);
                    gResize.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    gResize.DrawImage(img, 0, 0, resizeW, H);
                    gResize.Dispose();

                    img = (System.Drawing.Image)bmpResize;
                }
            }

            if (img.Width < W) W = img.Width;
            if (img.Height < H) H = img.Height;

            int X = 0;
            int Y = 0;

            X = (img.Width > W) ? Convert.ToInt32((img.Width - W) / 2) : X;           
            Y = (img.Height > H) ? Convert.ToInt32((img.Height - H) / 2) : Y;

            Bitmap b = new Bitmap(W, H, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            b.SetResolution(72, 72);
            Graphics g = Graphics.FromImage((System.Drawing.Image)b);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.DrawImage(img, new Rectangle(0, 0, W, H), X, Y, W, H, GraphicsUnit.Pixel);

            img = (System.Drawing.Image)b;
            img.Save(SavePath);

            img.Dispose();
            b.Dispose();
            g.Dispose();
        }
    }
}