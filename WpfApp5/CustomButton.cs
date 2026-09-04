using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfApp5
{
    public class CustomButton : Button
    {
        public static readonly DependencyProperty CornerRadiusProperty;

        public CornerRadius CornerRadius
        {
            get
            {
                return (CornerRadius)GetValue(CornerRadiusProperty);
            }
            set
            {
                SetValue(CornerRadiusProperty, value);
            }
        }

        static CustomButton()
        {
            CornerRadiusProperty = DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(CustomButton), new FrameworkPropertyMetadata(default(CornerRadius), FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender));
        }




        public Brush BackgroundHover
        {
            get { return (Brush)GetValue(BackgroundHoverProperty); }
            set { SetValue(BackgroundHoverProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BackgroundHover.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BackgroundHoverProperty =
            DependencyProperty.Register(nameof(BackgroundHover), typeof(Brush), typeof(CustomButton));



        public Brush BackgroundPressd
        {
            get { return (Brush)GetValue(BackgroundPressdProperty); }
            set { SetValue(BackgroundPressdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BackgroundPressd.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BackgroundPressdProperty =
            DependencyProperty.Register(nameof(BackgroundPressd), typeof(Brush), typeof(CustomButton));




    }
}
