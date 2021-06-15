using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using ImageMagick;
using ImgEDIT.Services;
using ImgEDIT.ViewModels;

namespace ImgEDIT.Commands
{
    public class JpgToPngCommand : BaseCommand
    {
        private readonly MainWindowViewModel _mainWindow;

        public JpgToPngCommand(MainWindowViewModel mainWindow)
        {
            _mainWindow = mainWindow;
        }
        public override bool CanExecute(object parameter)
        {
            if (!string.IsNullOrWhiteSpace(_mainWindow.ImagePath))
            {
                string imageExtension = ImageService.GetFileFormat(_mainWindow.ImagePath).ToString().ToLower();
                if (imageExtension == "jpg")
                {
                    return true;
                }
            }

            return false;
        }

        public override void Execute(object parameter)
        {
            using (MagickImage image = new MagickImage(_mainWindow.ImagePath))
            {
                string imageName = Path.GetFileNameWithoutExtension(_mainWindow.ImagePath);
                MagickFormat imageFormat = MagickFormat.Png;
                string newFilePath = $"{imageName}_converted.{imageFormat.ToString().ToLower()}";
                image.Write(newFilePath, imageFormat);
                _mainWindow.ProcessedImagePath = newFilePath;
                _mainWindow.ProgressBarValue = 100;
                MessageBox.Show("Изображение обработано");
                _mainWindow.ProgressBarValue = 0;
            }
        }
    }
}
