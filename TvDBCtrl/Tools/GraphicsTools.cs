using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Net;

namespace TvDBCtrl.Tools
{
    public static class GraphicsTools
    {
        /// <summary>Resizes an image to a new width and height (Web to Memory operations.</summary>
        /// <param name="FileURI">Is the web location where to get image.</param>
        /// <param name="ImgSize">Contain needed Width and Height.</param>
        /// <param name="EpNumber">Is the value to draw over image ( 0 if we dont want any number )</param>
        /// <param name="Width">Is the needed Max Width</param>
        /// <param name="Height">Is the needed Max Height</param>
        public static Image ResizeInternetImage(string FileURI, int EpNumber, int Width = 185, int Height = 278)
        {
            WebClient       Client      = new WebClient();
            byte[]          InData      = Client.DownloadData(FileURI);
            MemoryStream    InStream    = new MemoryStream(InData);
            Image           InImage     = Image.FromStream(InStream);
            InStream.Close();
            InImage                     = ResizeImage(InImage, new Size(Width, Height), EpNumber);

            return InImage;
        }

        /// <summary>Resizes an image to a new width and height (Memory to Memory operations).</summary>
        /// <param name="InPict">Contain the original image.</param>
        /// <param name="OutSize">Contain needed Width and Height.</param>
        /// <param name="EpNumer">Is the number value to draw over Image</param>
        private static Image ResizeImage(Image InPict, Size OutSize, int EpNumber)
        {
            if (InPict != (Image)null)
            {
                int         InWidth     = InPict.Width;
                int         InHeight    = InPict.Height;

                float       RatioX      = (OutSize.Width / (float)InWidth);
                float       RatioY      = (OutSize.Height / (float)InHeight);

                float       ImgRatio    = RatioY < RatioX ? RatioY : RatioX;

                int         OutWidth    = (int)(InWidth * ImgRatio);
                int         OutHeight   = (int)(InHeight * ImgRatio);

                Bitmap      OutImage    = new Bitmap(OutWidth, OutHeight);
                Graphics    Pict        = Graphics.FromImage(OutImage);

                Pict.InterpolationMode  = InterpolationMode.HighQualityBicubic;
                Pict.DrawImage(InPict, 0, 0, OutWidth, OutHeight);

                if (EpNumber > 0)
                {
                    StringFormat    strFormat   = new StringFormat();
                    strFormat.Alignment         = StringAlignment.Far;
                    strFormat.LineAlignment     = StringAlignment.Far;
                    Pict.DrawString(EpNumber.ToString(), new Font("Tahoma", 64), Brushes.DarkGray, new RectangleF(0, 0, OutWidth + 5, OutHeight + 5), strFormat);
                    Pict.DrawString(EpNumber.ToString(), new Font("Tahoma", 64), Brushes.White, new RectangleF(0, 0, OutWidth, OutHeight), strFormat);
                }

                Pict.Dispose();

                return OutImage;
            }
            return null;
        }
    }
}
