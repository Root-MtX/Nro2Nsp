using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;


namespace MtX.Control
{
    public static class IconImport
    {
        public static void IconConvert(string Input)
        {
            Bitmap ImageInput = new Bitmap(Input);
            Bitmap ImageOuput = new Bitmap(256, 256);
            Rectangle rec = new Rectangle(0, 0, 256, 256);
            if (ImageInput.Height != 256 || ImageInput.Width != 256)
            {
                ImageOuput.SetResolution(ImageInput.HorizontalResolution, ImageInput.VerticalResolution);
                Graphics convert = Graphics.FromImage(ImageOuput);
                convert.CompositingMode = CompositingMode.SourceCopy;
                convert.InterpolationMode = InterpolationMode.HighQualityBicubic;
                convert.CompositingQuality = CompositingQuality.HighQuality;
                convert.PixelOffsetMode = PixelOffsetMode.HighQuality;
                convert.SmoothingMode = SmoothingMode.HighQuality;
                ImageAttributes attr = new ImageAttributes();
                attr.SetWrapMode(WrapMode.TileFlipXY);
                convert.DrawImage(ImageInput, rec, 0, 0, ImageInput.Width, ImageInput.Height, GraphicsUnit.Pixel, attr);
            }
            else
            {
                Graphics convert = Graphics.FromImage(ImageOuput);
                convert.DrawImage(ImageInput, rec);
            }
            if (Directory.Exists(DircControl.buildpath + DircControl.controlpath))
            {
                if (File.Exists(DircControl.buildpath + DircControl.controlpath + @"icon_AmericanEnglish.dat"))
                {
                    System.GC.Collect();
                    System.GC.WaitForPendingFinalizers();
                    File.Delete(DircControl.buildpath + DircControl.controlpath + @"icon_AmericanEnglish.dat");
                }
                ImageOuput.Save(DircControl.buildpath + DircControl.controlpath + @"icon_AmericanEnglish.dat", ImageFormat.Jpeg);
            }
            else
            {
                if (File.Exists(DircControl.buildpath + DircControl.controlpath + @"icon_AmericanEnglish.dat"))
                {
                    System.GC.Collect();
                    System.GC.WaitForPendingFinalizers();
                    File.Delete(DircControl.buildpath + DircControl.controlpath + @"icon_AmericanEnglish.dat");
                }
                System.IO.Directory.CreateDirectory(DircControl.buildpath + DircControl.controlpath);
                ImageOuput.Save(DircControl.buildpath + DircControl.controlpath + @"icon_AmericanEnglish.dat", ImageFormat.Jpeg);
            }
        }
    }
}
