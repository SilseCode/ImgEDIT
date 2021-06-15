using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ImageMagick;
using ImgEDIT.Services;
using ImgEDIT.ViewModels;

namespace ImgEDIT.Commands
{
    public class MakeTransparentCommand : BaseCommand
    {
        private readonly MainWindowViewModel _mainWindow;

        public MakeTransparentCommand(MainWindowViewModel mainWindow)
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
            using (MagickImage image = new MagickImage(_mainWindow.ImagePath))
            {
                MagickFormat imageFormat = MagickFormat.Png;
                string imageName = Path.GetFileNameWithoutExtension(_mainWindow.ImagePath);
                string newFilePath = $"{imageName}_transparent.{imageFormat.ToString().ToLower()}";
                image.ColorFuzz = new Percentage(10);
                image.TransparentChroma(new MagickColor(250,250,250), new MagickColor(255,255,255));
                image.Transparent(MagickColors.White);
                image.Write(newFilePath, imageFormat);
                _mainWindow.ProcessedImagePath = newFilePath;
                _mainWindow.ProgressBarValue = 100;
                MessageBox.Show("Изображение обработано");
                _mainWindow.ProgressBarValue = 0;
            }
        }
    }
}
