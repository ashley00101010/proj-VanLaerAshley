﻿using BarTender.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BarTender
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnGoToList_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CocktailListTP());
        }
    }
}
