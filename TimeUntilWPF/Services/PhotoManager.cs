using System;
using System.IO;
using System.Windows.Controls;

namespace TimeUntilWPF.Services
{
    public class PhotoManager : Root.Services.PhotoManager
    {
        public override void PickPhoto()
        {
            var ofd = new Microsoft.Win32.OpenFileDialog() 
            { 
                Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif" ,
                DefaultDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)                
            };
            var result = ofd.ShowDialog();
            if (result == false) return;
            
            this.PhotoPath = ofd.FileName;
            Stream photoStream = ofd.OpenFile();
            SetSourceImage(photoStream);
            
        }
        public override void TakePhoto()
        {
            throw new NotImplementedException();
        }
    }
}
