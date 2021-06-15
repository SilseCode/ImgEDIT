using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using ImgEDIT.Services;
using ImgEDIT.ViewModels;
using Microsoft.Win32;

namespace ImgEDIT.Commands
{
    public class OpenImageCommand : BaseCommand
    {
        private readonly MainWindowViewModel _mainWindow;

        public OpenImageCommand(MainWindowViewModel mainWindow)
        {
            _mainWindow = mainWindow;
        }
        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            string filePath = ImageService.OpenFileDialog();
            _mainWindow.ImagePath = filePath;
            _mainWindow.ImageLabel = "";
        }
    }
}
