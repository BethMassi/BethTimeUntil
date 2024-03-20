using System.ComponentModel;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Root.Interfaces;

namespace TimeUntilMAUI.Services
{
    public class PhotoManager : Root.Services.PhotoManager
    {
        public override async void PickPhoto() 
        {
            //MAUI abstracts the device specific code for us
            FileResult photo = await MediaPicker.Default.PickPhotoAsync();
            SetPhoto(photo);
        }
        public override async void TakePhoto()
        {
            if (MediaPicker.Default.IsCaptureSupported)
            {
                try
                {
                    //MAUI abstracts the device specific code for us
                    FileResult photo = await MediaPicker.Default.CapturePhotoAsync();
                    SetPhoto(photo);
                }
                catch (FileNotFoundException ex)
                {
                    //Capture is not supported or could not be completed.
                    Debug.WriteLine(ex);                    
                }                
            }
        }
        private async void SetPhoto(FileResult photo)
        {
            if (photo != null)
            {                
                using Stream sourceStream = await photo.OpenReadAsync();
                PhotoPath = photo.FullPath;
                //razor component needs a base64 encoded string so it can display the image in <img /> tag
                SetSourceImage(sourceStream);
            }
        }
      
    }

}
