using System;
using Xamarin.Forms;

namespace TechnicalChallengeProgress.Models
{
    public class User
    {
        public string Name { get; set; }

        public string SocialNetwork { get; set; }

        public string StatusMessage { get; set; }

        public DateTime TimeOfPosting { get; set; }

        public ImageSource ImageSource { get; set; }
    }
}
