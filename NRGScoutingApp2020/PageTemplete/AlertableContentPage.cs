using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace NRGScoutingApp2020.PageTemplete
{
    public class AlertableContentPage : ContentPage
    {
        public static readonly BindableProperty EnableBackConfimationProperty =
                    BindableProperty.Create(nameof(EnableBackConfimation), typeof(bool), typeof(AlertableContentPage), false);

        public bool EnableBackConfimation
        {
            get
            {
                return (bool) GetValue(EnableBackConfimationProperty);
            }
            set
            {
                SetValue(EnableBackConfimationProperty, value);
            }
        }

        public Action backAction { get; set; }

        protected void InitializeBackAction()
        {
            backAction = async () =>
            {
                var result = await DisplayAlert("Alert", "Do you want to DISCARD progress?", "Yes", "No");

                if (result)
                {
                    await Navigation.PopAsync(true);
                }
            };
        }
    }
}