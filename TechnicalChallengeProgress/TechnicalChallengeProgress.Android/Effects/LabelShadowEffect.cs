using System;
using System.ComponentModel;
using System.Linq;
using TechnicalChallengeProgress.Droid.Effects;
using TechnicalChallengeProgress.Effects;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;

[assembly: ResolutionGroupName("MyCompany")]
[assembly: ExportEffect(typeof(LabelShadowEffect), "LabelShadowEffect")]
namespace TechnicalChallengeProgress.Droid.Effects
{
    //public class LabelShadowEffect : PlatformEffect
    //{
    //    protected override void OnAttached()
    //    {
    //        try
    //        {
    //            var control = Control as Android.Widget.TextView;
    //            var effect = (ShadowEffect)Element.Effects.FirstOrDefault(e => e is ShadowEffect);
    //            if (effect != null)
    //            {
    //                float radius = effect.Radius;
    //                float distanceX = effect.DistanceX;
    //                float distanceY = effect.DistanceY;
    //                Android.Graphics.Color color = effect.Color.ToAndroid();
    //                control.SetShadowLayer(radius, distanceX, distanceY, color);
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            Console.WriteLine("Cannot set property on attached control. Error: ", ex.Message);
    //        }
    //    }

    //    protected override void OnDetached() { }
    //}

    public class LabelShadowEffect : PlatformEffect
    {
        Android.Widget.TextView control;
        Android.Graphics.Color color;
        float radius, distanceX, distanceY;

        protected override void OnAttached()
        {
            try
            {
                control = Control as Android.Widget.TextView;
                UpdateRadius();
                UpdateColor();
                UpdateOffset();
                UpdateControl();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot set property on attached control. Error: ", ex.Message);
            }
        }

        protected override void OnDetached() { }

        void UpdateControl()
        {
            if (control != null)
            {
                control.SetShadowLayer(radius, distanceX, distanceY, color);
            }
        }

        void UpdateRadius()
        {
            radius = (float)ShadowEffect.GetRadius(Element);
        }

        void UpdateColor()
        {
            color = ShadowEffect.GetColor(Element).ToAndroid();
        }

        void UpdateOffset()
        {
            distanceX = (float)ShadowEffect.GetDistanceX(Element);
            distanceY = (float)ShadowEffect.GetDistanceY(Element);
        }

        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            if (args.PropertyName == ShadowEffect.RadiusProperty.PropertyName)
            {
                UpdateRadius();
                UpdateControl();
            }
            else if (args.PropertyName == ShadowEffect.ColorProperty.PropertyName)
            {
                UpdateColor();
                UpdateControl();
            }
            else if (args.PropertyName == ShadowEffect.DistanceXProperty.PropertyName ||
                     args.PropertyName == ShadowEffect.DistanceYProperty.PropertyName)
            {
                UpdateOffset();
                UpdateControl();
            }
        }
    }
}