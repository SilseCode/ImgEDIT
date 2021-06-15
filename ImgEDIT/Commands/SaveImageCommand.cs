using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using ImageMagick;
using ImgEDIT.Services;
using ImgEDIT.ViewModels;
using Microsoft.Win32;

namespace ImgEDIT.Commands
{
    public class SaveImageCommand : BaseCommand
    {
        private readonly MainWindowViewModel _mainWindow;

        public SaveImageCommand(MainWindowViewModel mainWindow)
        {
            _mainWindow = mainWindow;
        }

        public override bool CanExecute(object parameter)
        {
            if (!string.IsNullOrWhiteSpace(_mainWindow.ProcessedImagePath))
            {
                return true;
            }

            return false;
        }

        public override void Execute(object parameter)
        {
            try
            {
                string destinationFileName = ImageService.SaveFileDialog(_mainWindow.ProcessedImagePath);
                if (File.Exists(destinationFileName))
                {
                    File.Delete(destinationFileName);
                    using (MagickImage image = new MagickImage(destinationFileName))
                    {
                        image.Write(destinationFileName);
                    }
                }
                else
                {
                    File.Copy(_mainWindow.ProcessedImagePath, destinationFileName);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
