using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using Root.Interfaces;

namespace TimeUntilMAUI.Services
{
    public class PhotoTaker : IPhotoTaker, INotifyPropertyChanged

    {
        private string photoPath; 
        private string sourceImage;

        public async void TakePhoto()
        {
            if (MediaPicker.Default.IsCaptureSupported)
            {
                FileResult photo = await MediaPicker.Default.CapturePhotoAsync();

                if (photo != null)
                {
                    // save the file into local storage
                    //string localFilePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);

                    using Stream sourceStream = await photo.OpenReadAsync();
                    //using FileStream localFileStream = File.OpenWrite(localFilePath);

                    //await sourceStream.CopyToAsync(localFileStream);
                    //sourceStream.Position = 0;

                    byte[] imageBytes = new byte[sourceStream.Length];
                    sourceStream.Read(imageBytes, 0, (int)sourceStream.Length);

                    var imageSource = Convert.ToBase64String(imageBytes);
                    imageSource = string.Format("data:image/jpg;base64,{0}", imageSource);

                    PhotoPath = photo.FullPath;
                    SourceImage = imageSource;
                }
            }
        }

        protected void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, e);
        }
        protected void OnPropertyChanged(string propertyName)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        public string SourceImage
        {
            get { return sourceImage; }
            set
            {
                if (value != sourceImage)
                {
                    sourceImage = value;
                    OnPropertyChanged("SourceImage");
                }
            }
        }   
        public string PhotoPath
        {
            get { return photoPath; }
            set
            {
                if (value != photoPath)
                {
                    photoPath = value;
                    OnPropertyChanged("PhotoPath");
                }
            }
        }        
        public event PropertyChangedEventHandler PropertyChanged;

      
    }

}
