﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using TechnicalChallengeProgress.Models;
using TechnicalChallengeProgress.Services;

namespace TechnicalChallengeProgress.ViewModels
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
            var socialNetworksServices = new SocialNetworksServices();

            SocialUsers = socialNetworksServices.GetUsers();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
