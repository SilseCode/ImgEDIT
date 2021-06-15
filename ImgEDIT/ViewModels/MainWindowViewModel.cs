using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using ImageMagick;
using ImgEDIT.Commands;
using ImgEDIT.Models;

namespace ImgEDIT.ViewModels
{
    public class MainWindowViewModel : Notify
    {
        private string _imagePath;
        private int _imageHeight;
        private int _imageWidth;
        private string _imageLabel;
        private string _processedImagePath;
        private int _progressBarValue;

        public MainWindowViewModel()
        {
            ImageLabel = "Выберите изображение";
        }

        public int ProgressBarValue
        {
            get => _progressBarValue;
            set { _progressBarValue = value; OnPropertyChanged();}
        }

        public string ImageLabel
        {
            get => _imageLabel;
            set { _imageLabel = value; OnPropertyChanged(); }
        }

        public string ProcessedImagePath
        {
            get => _processedImagePath;
            set { _processedImagePath = value; OnPropertyChanged();}
        }

        public string ImagePath
        {
            get => _imagePath;
            set
            {
                _imagePath = value; OnPropertyChanged();
                if (!string.IsNullOrWhiteSpace(_imagePath))
                {
                    MagickImage image = new MagickImage(_imagePath);
                    ImageHeight = image.Height;
                    ImageWidth = image.Width;
                }
            }
        }

        public int ImageHeight
        {
            get => _imageHeight;
            set
            {
                _imageHeight = value;
                OnPropertyChanged();
            }
        }
        public int ImageWidth
        {
            get => _imageWidth;
            set
            {
                _imageWidth = value;
                OnPropertyChanged();
            }
        }

        public ChangeSizeCommand ChangeSizeCommand => new ChangeSizeCommand(this);
        public JpgToIcoCommand JpgToIcoCommand => new JpgToIcoCommand(this);
        public PngToIcoCommand PngToIcoCommand => new PngToIcoCommand(this);
        public JpgToPngCommand JpgToPngCommand => new JpgToPngCommand(this);
        public PngToJpgCommand PngToJpgCommand => new PngToJpgCommand(this);
        public SaveImageCommand SaveImageCommand => new SaveImageCommand(this);
        public OpenImageCommand OpenImageCommand => new OpenImageCommand(this);
        public MakeTransparentCommand MakeTransparent => new MakeTransparentCommand(this);

    }

    
}
