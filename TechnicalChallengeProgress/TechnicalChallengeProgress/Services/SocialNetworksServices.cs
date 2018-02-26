using System;
using System.Collections.ObjectModel;
using TechnicalChallengeProgress.Models;

namespace TechnicalChallengeProgress.Services
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
                    TimeOfPosting = DateTime.Today,
                    Picture = new Uri("http://zvezdichka.blog.bg/photos/8593/DSCN2624_resize.JPG")
                },
                new User()
                {
                    Name = "Otets Nafarforiy",
                    SocialNetwork = "Twitter",
                    StatusMessage = "Tarsya si greshnitsi, da im oprostya grehovete.",
                    TimeOfPosting = DateTime.Today,
                    Picture = new Uri("https://img.bg.sof.cmestatic.com/media/images/620x349/Jan2012/1369485063.jpg")
                },
                new User()
                {
                    Name = "Pena",
                    SocialNetwork = "Instagram",
                    StatusMessage = "Vizhte novata mi dieta s kiselo zele",
                    TimeOfPosting = DateTime.Today,
                    Picture = new Uri("http://sbj-bg.eu/thumbs/923_11416.jpg")
                },
                new User()
                {
                    Name = "Tsenko Chokov",
                    SocialNetwork = "LinkedIn",
                    StatusMessage = "Bezplatno more za vsichki glasuvali za men",
                    TimeOfPosting = DateTime.Today,
                    Picture = new Uri("https://static.fakti.bg/news2017/218929/172bf46618de6d17efe03570490bd221_big.jpg")
                }
            };

            return list;
        }
    }
}
