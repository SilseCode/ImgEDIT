using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageMagick;
using Microsoft.Win32;

namespace ImgEDIT.Services
{
    public static class ImageService
    {
        public static string OpenFileDialog()
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select Multiple Pictures";
            op.Multiselect = true;
            op.Filter = "Image files (*.jpg, *.png, *.ico) | *.jpg; *.ico; *.png;";
            op.ShowDialog();
            return op.FileName;
        }

        public static string SaveFileDialog(string filePath)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = filePath;
            saveFileDialog.Filter = "Image files (*.jpg, *.png, *.ico) | *.jpg; *.ico; *.png;";
            saveFileDialog.ShowDialog();
            return saveFileDialog.FileName;
        }
        public static MagickFormat GetFileFormat(string path)
        {
            string imageExt = Path.GetExtension(path);
            MagickFormat imageFormat = MagickFormat.Png;
            if (imageExt == ".png")
            {
                imageFormat = MagickFormat.Png;
            }
            else if (imageExt == ".jpg")
            {
                imageFormat = MagickFormat.Jpg;
            }
            else if (imageExt == ".ico")
            {
                imageFormat = MagickFormat.Ico;
            }
            return imageFormat;
        }
    }
}
