using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TCProgress.Models;
using TCProgress.Services;

namespace TCProgress.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<User> _socialUsers;

        public ObservableCollection<User> SocialUsers
        {
            get
            {
                return _socialUsers;
            }
            set
            {
                _socialUsers = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            SocialUsers = SocialNetworksServices.GetUsers();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
