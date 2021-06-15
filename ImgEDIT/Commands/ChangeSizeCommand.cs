using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ImageMagick;
using ImageProcessor;
using ImageProcessor.Imaging.Formats;
using ImgEDIT.Services;
using ImgEDIT.ViewModels;
using Microsoft.Win32;

namespace ImgEDIT.Commands
{
    public class ChangeSizeCommand : BaseCommand
    {
        private readonly MainWindowViewModel _mainWindow;

        public ChangeSizeCommand(MainWindowViewModel mainWindow)
        {
            _mainWindow = mainWindow;
        }
        public override bool CanExecute(object parameter)
        {
            if (!string.IsNullOrWhiteSpace(_mainWindow.ImagePath))
            {
                return true;
            }

            return false;
        }

        public override void Execute(object parameter)
        {
            int newWidth = _mainWindow.ImageWidth;
            int newHeight = _mainWindow.ImageHeight;
            MagickFormat imageFormat = ImageService.GetFileFormat(_mainWindow.ImagePath);
            try
            {
                using (MagickImage image = new MagickImage(_mainWindow.ImagePath))
                {
                    image.Resize(newWidth, newHeight);
                    string imageName = Path.GetFileNameWithoutExtension(_mainWindow.ImagePath);
                    string newFilePath = $"{imageName}_resized.{imageFormat.ToString().ToLower()}";
                    image.Write(newFilePath, imageFormat);
                    _mainWindow.ProcessedImagePath = newFilePath;
                    _mainWindow.ProgressBarValue = 100;
                    MessageBox.Show("Изображение обработано");
                    _mainWindow.ProgressBarValue = 0;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
