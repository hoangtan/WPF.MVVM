using System.ComponentModel;

namespace WPF.MVVM.Services
{
    /// <summary>
    /// Inherit from this class when you want to implement INotifyPropertyChanged with the convenience of only raising 
    /// change events only when the value actually changes.
    /// </summary>
    public abstract class BindableBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        protected void SetProperty<T>(ref T member, T value, string propertyName = null)
        {
            if (object.Equals(member, value)) return;

            member = value;
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
