using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Root.Interfaces
{
    public interface IPhotoManager : INotifyPropertyChanged
    {
        public void TakePhoto();
        public void PickPhoto();
        public string PhotoPath { get; set; }
        public string SourceImage { get; set; }        
    }
}
