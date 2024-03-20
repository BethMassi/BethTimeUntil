using System.ComponentModel;
using Root.Interfaces;

namespace Root.Services
{
    public abstract class PhotoManager : IPhotoManager, INotifyPropertyChanged
    {
        private string photoPath; 
        private string sourceImage;
        public abstract void PickPhoto();
        public abstract void TakePhoto();
        protected void SetSourceImage(Stream photoStream)
        {
            if (photoStream != null)
            {
                //razor component needs a base64 encoded string so it can display the image in <img /> tag
                byte[] imageBytes = new byte[photoStream.Length];
                photoStream.Read(imageBytes, 0, (int)photoStream.Length);

                var imageSource = Convert.ToBase64String(imageBytes);
                imageSource = string.Format("data:image/jpg;base64,{0}", imageSource);
                                
                SourceImage = imageSource;
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
