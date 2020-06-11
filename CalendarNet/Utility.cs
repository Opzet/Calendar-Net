using System.Drawing;
using System.IO;
using System.Reflection;

namespace CalendarNet
{
    internal static class Utility
    {
        internal static Bitmap LoadImageFromEmbeddedResource(string resourceName)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream == null)
                    return null;

                Bitmap image = new Bitmap(stream);

                return image;
            }
        }

        private static Size ScaleRect(Size dest, Size src, bool keepWidth, bool keepHeight)
        {
            Size destSize = new Size();

            int sourceAspect = src.Width/src.Height;
            int destAspect = dest.Width/dest.Height;

            if (sourceAspect > destAspect)
            {
                destSize.Width = dest.Width;
                destSize.Height = dest.Width/sourceAspect;

                if (keepHeight)
                {
                    int resizePerc = dest.Height/destSize.Height;
                    destSize.Width = dest.Width*resizePerc;
                    destSize.Height = dest.Height;
                }
            }
            else
            {
                destSize.Height = dest.Height;
                destSize.Width = dest.Width * sourceAspect;

                if (keepWidth)
                {
                    int resizePerc = dest.Width / destSize.Width;
                    destSize.Width = dest.Width;
                    destSize.Height = dest.Height*resizePerc;
                }
            }

            return destSize;
        }

        internal static Bitmap ResizeBitmap(Bitmap bmp, Color backgroundColor, int newWidth, int newHeight, bool keepWidth, bool keepHeight)
        {
            Size size = ScaleRect(new Size(newWidth, newHeight), new Size(bmp.Width, bmp.Height), false, true);
            Bitmap bmp2 = new Bitmap(newWidth, newHeight);

            using (Graphics g = Graphics.FromImage(bmp2))
            {

                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;

                g.Clear(backgroundColor);
                g.DrawImage(bmp, 0, 0, newWidth, newHeight);
            }

            return bmp2;
        }

        internal static Bitmap ResizeBitmap(Bitmap bmp, Color backgroundColor, Size newSize, bool keepWidth, bool keepHeight)
        {
            return ResizeBitmap(bmp, backgroundColor, newSize.Width, newSize.Height, keepWidth, keepHeight);
        }
    }
}
