using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ShoppingList.Views
{
    public partial class NoDataView : ContentView
    {
        public static readonly BindableProperty DisplayTextProperty =
            BindableProperty.Create(nameof(DisplayText), typeof(string), typeof(NoDataView), default(string));

        public string DisplayText
        {
            get => (string)GetValue(DisplayTextProperty);
            set => SetValue(DisplayTextProperty, value);
        }

        public static readonly BindableProperty IsVisibleRefreshButtonProperty =
            BindableProperty.Create(nameof(IsVisibleRefreshButton), typeof(bool), typeof(NoDataView), default(bool));

        public bool IsVisibleRefreshButton
        {
            get => (bool)GetValue(IsVisibleRefreshButtonProperty);
            set => SetValue(IsVisibleRefreshButtonProperty, value);
        }

        public static readonly BindableProperty RefreshCommandProperty =
            BindableProperty.Create(nameof(RefreshCommand), typeof(Command), typeof(NoDataView), default(Command));

        public Command RefreshCommand
        {
            get => (Command)GetValue(RefreshCommandProperty);
            set => SetValue(RefreshCommandProperty, value);
        }

        public NoDataView()
        {
            InitializeComponent();
        }
    }
}
