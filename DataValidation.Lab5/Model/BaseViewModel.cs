using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DataValidation.Lab5
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propetyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propetyName));
        }
    }
}
