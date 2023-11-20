using System.ComponentModel;
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
                //MAUI abstracts the device specific code for us
                FileResult photo = await MediaPicker.Default.CapturePhotoAsync();

                if (photo != null)
                {
                    //razor component needs a base64 encoded string so it can display the image in <img /> tag
                    using Stream sourceStream = await photo.OpenReadAsync();

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
