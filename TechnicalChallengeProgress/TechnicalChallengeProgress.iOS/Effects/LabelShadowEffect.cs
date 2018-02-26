using System;
using System.ComponentModel;
using System.Linq;
using CoreGraphics;
using TechnicalChallengeProgress.Effects;
using TechnicalChallengeProgress.iOS.Effects;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;

[assembly: ResolutionGroupName("MyCompany")]
[assembly: ExportEffect(typeof(LabelShadowEffect), "LabelShadowEffect")]

namespace TechnicalChallengeProgress.iOS.Effects
{
    public class LabelShadowEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            try
            {
                UpdateRadius();
                UpdateColor();
                UpdateOffset();
                Control.Layer.ShadowOpacity = 1.0f;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot set property on attached control. Error: ", ex.Message);
            }
        }

        protected override void OnDetached()
        {
        }

        void UpdateRadius()
        {
            Control.Layer.CornerRadius = (nfloat) ShadowEffect.GetRadius(Element);
        }

        void UpdateColor()
        {
            Control.Layer.ShadowColor = ShadowEffect.GetColor(Element).ToCGColor();
        }

        void UpdateOffset()
        {
            Control.Layer.ShadowOffset = new CGSize(
                (double) ShadowEffect.GetDistanceX(Element),
                (double) ShadowEffect.GetDistanceY(Element));
        }

        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            if (args.PropertyName == ShadowEffect.RadiusProperty.PropertyName)
            {
                UpdateRadius();
            }
            else if (args.PropertyName == ShadowEffect.ColorProperty.PropertyName)
            {
                UpdateColor();
            }
            else if (args.PropertyName == ShadowEffect.DistanceXProperty.PropertyName ||
                     args.PropertyName == ShadowEffect.DistanceYProperty.PropertyName)
            {
                UpdateOffset();
            }
        }
    }
}