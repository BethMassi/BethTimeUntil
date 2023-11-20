using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Root.Interfaces
{
    public interface IPhotoTaker : INotifyPropertyChanged
    {
        public void TakePhoto(); 
        public string PhotoPath { get; set; }
        public string SourceImage { get; set; }        
    }
}
