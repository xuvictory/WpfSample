using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp6
{
    public class PasswordBoxHelper
    {


        public static string GetPwd(DependencyObject obj)
        {
            return (string)obj.GetValue(PwdProperty);
        }

        public static void SetPwd(DependencyObject obj, string value)
        {
            obj.SetValue(PwdProperty, value);
        }

        // Using a DependencyProperty as the backing store for Pwd.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PwdProperty =
            DependencyProperty.RegisterAttached("Pwd", typeof(string), typeof(PasswordBoxHelper), new PropertyMetadata("", OnPropertyChanedCallBack));

        private static void OnPropertyChanedCallBack(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PasswordBox pwdbox = d as PasswordBox;
            if (pwdbox == null) return;

            pwdbox.Password = (string)e.NewValue;

            //设置光标移动到最后一位
            SetSelection(pwdbox, pwdbox.Password.Length, 0);
        }

        private static void SetSelection(PasswordBox passwordBox, int start, int length)
        {
            passwordBox.GetType()
            .GetMethod("Select", BindingFlags.Instance | BindingFlags.NonPublic)
            ?.Invoke(passwordBox, new object[] { start, length });
        }

        /*******************************************************************************************************************************************/



        public static bool GetIsEnablePasswordPropertyChanged(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsEnablePasswordPropertyChangedProperty);
        }

        public static void SetIsEnablePasswordPropertyChanged(DependencyObject obj, bool value)
        {
            obj.SetValue(IsEnablePasswordPropertyChangedProperty, value);
        }

        // Using a DependencyProperty as the backing store for IsEnablePasswordPropertyChanged.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsEnablePasswordPropertyChangedProperty =
            DependencyProperty.RegisterAttached("IsEnablePasswordPropertyChanged", typeof(bool), typeof(PasswordBoxHelper), new PropertyMetadata(false, OnPasswordPropertyChanged));

        private static void OnPasswordPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PasswordBox pwdbox = d as PasswordBox;
            if (pwdbox == null)
                return;

            if((bool)e.NewValue)
            {
                pwdbox.PasswordChanged += Pwdbox_PasswordChanged;
            }
            else
            {
                pwdbox.PasswordChanged -= Pwdbox_PasswordChanged;
            }
        }

        private static void Pwdbox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox pwdbox = (PasswordBox)sender;

            SetPwd(pwdbox, pwdbox.Password);
        }
    }
}
