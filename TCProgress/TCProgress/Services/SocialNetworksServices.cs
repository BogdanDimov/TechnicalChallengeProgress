using System;
using System.Collections.ObjectModel;
using TCProgress.Models;
using TCProgress.Helpers;
using Xamarin.Forms;

namespace TCProgress.Services
{
    public static class SocialNetworksServices
    {
        public static ObservableCollection<User> GetUsers()
        {
            var list = new ObservableCollection<User>
            {
                new User
                {
                    Name = "Trendafil",
                    SocialNetwork = "Facebook",
                    StatusMessage = "Tarsya si bulka. Ima li kandidatki?",
                    TimeOfPosting = DateTime.Now.AddHours(-1.5).ToString("f"),
                    ImageSource = ImageSource.FromResource(ResourceHelper.GetResourceFromFileName("trendafil.JPG"))
                },
                new User()
                {
                    Name = "Otets Nafarforiy",
                    SocialNetwork = "Twitter",
                    StatusMessage = "Tarsya si greshnitsi, da im oprostya grehovete.",
                    TimeOfPosting = DateTime.Now.AddHours(-3).ToString("f"),
                    ImageSource = ImageSource.FromResource(ResourceHelper.GetResourceFromFileName("nafarforiy.jpg"))
                },
                new User()
                {
                    Name = "Pena",
                    SocialNetwork = "Instagram",
                    StatusMessage = "Vizhte novata mi dieta s kiselo zele",
                    TimeOfPosting = DateTime.Now.AddHours(-0.40).ToString("f"),
                    ImageSource = ImageSource.FromResource(ResourceHelper.GetResourceFromFileName("babapena.jpg"))
                },
                new User()
                {
                    Name = "Tsenko Chokov",
                    SocialNetwork = "LinkedIn",
                    StatusMessage = "Bezplatno more za vsichki glasuvali za men",
                    TimeOfPosting = DateTime.Now.AddHours(-5.55).ToString("f"),
                    ImageSource = ImageSource.FromResource(ResourceHelper.GetResourceFromFileName("tsenko.jpg"))
                }
            };

            return list;
        }
    }
}
