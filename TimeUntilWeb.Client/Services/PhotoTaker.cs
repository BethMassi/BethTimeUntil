using Root.Interfaces;
using System.ComponentModel;

namespace TimeUntilWeb.Client.Services
{
    public class PhotoTaker : IPhotoTaker
    {
        public string PhotoPath { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string SourceImage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void TakePhoto()
        {
            throw new NotImplementedException();
        }
    }
}
