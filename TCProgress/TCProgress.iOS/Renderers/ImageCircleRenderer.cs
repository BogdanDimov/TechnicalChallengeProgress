﻿using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using CoreAnimation;
using CoreGraphics;
using Foundation;
using TCProgress.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace TCProgress.iOS.Renderers
{
    [Preserve(AllMembers = true)]
    public class ImageCircleRenderer : ImageRenderer
    {
        private const string BorderName = "borderLayerName";

        public async static void Init()
        {
            var temp = DateTime.Now;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);
            if (Element == null)
                return;
            CreateCircle();
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == VisualElement.HeightProperty.PropertyName ||
                e.PropertyName == VisualElement.WidthProperty.PropertyName ||
                e.PropertyName == CircleImage.BorderColorProperty.PropertyName ||
                e.PropertyName == CircleImage.BorderThicknessProperty.PropertyName ||
                e.PropertyName == CircleImage.FillColorProperty.PropertyName)
            {
                CreateCircle();
            }
        }

        private void CreateCircle()
        {
            try
            {
                var min = Math.Min(Element.Width, Element.Height);
                Control.Layer.CornerRadius = (nfloat)(min / 2.0);
                Control.Layer.MasksToBounds = false;
                Control.BackgroundColor = ((CircleImage)Element).FillColor.ToUIColor();
                Control.ClipsToBounds = true;

                var borderThickness = ((CircleImage)Element).BorderThickness;

                //Remove previously added layers
                var tempLayer = Control.Layer.Sublayers?
                                       .Where(p => p.Name == BorderName)
                                       .FirstOrDefault();
                tempLayer?.RemoveFromSuperLayer();

                var externalBorder = new CALayer();
                externalBorder.Name = BorderName;
                externalBorder.CornerRadius = Control.Layer.CornerRadius;
                externalBorder.Frame = new CGRect(-.5, -.5, min + 1, min + 1);
                externalBorder.BorderColor = ((CircleImage)Element).BorderColor.ToCGColor();
                externalBorder.BorderWidth = ((CircleImage)Element).BorderThickness;

                Control.Layer.AddSublayer(externalBorder);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Unable to create circle image: " + ex);
            }
        }
    }
}
