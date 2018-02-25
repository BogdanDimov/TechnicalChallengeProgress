using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TechnicalChallengeProgress.Models
{
    public class User
    {
        public string Name { get; set; }

        public string SocialNetwork { get; set; }

        public string StatusMessage { get; set; }

        public DateTime TimeOfPosting { get; set; }

        public Uri Picture { get; set; }
    }
}
