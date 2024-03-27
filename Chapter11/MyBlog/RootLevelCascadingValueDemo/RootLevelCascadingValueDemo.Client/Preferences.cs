using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RootLevelCascadingValueDemo.Client;

public class Preferences:INotifyPropertyChanged
{
    private bool _darkTheme;
    public bool DarkTheme 
    { 
        get => _darkTheme;
        set
        {
            if (_darkTheme == value)
                return;
            _darkTheme = value;
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs("DarkTheme"));
            }
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
}
