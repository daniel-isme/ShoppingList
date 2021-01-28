using System;
using ShoppingList.ViewModels;
using Xamarin.Forms;

namespace ShoppingList.Renderer
{
    public partial class CustomPage : ContentPage
    {
        public static readonly BindableProperty SafeAreaInsetProperty =
            BindableProperty.Create(nameof(SafeAreaInset), typeof(Thickness), typeof(CustomPage), default(Thickness), BindingMode.TwoWay);

        public Thickness SafeAreaInset
        {
            get => (Thickness)GetValue(SafeAreaInsetProperty);
            set => SetValue(SafeAreaInsetProperty, value);
        }

        public static readonly BindableProperty SafeAreaInsetOnlyBySideProperty =
            BindableProperty.Create(nameof(SafeAreaInsetOnlyBySide), typeof(Thickness), typeof(CustomPage), default(Thickness), BindingMode.TwoWay);

        public Thickness SafeAreaInsetOnlyBySide
        {
            get => (Thickness)GetValue(SafeAreaInsetProperty);
            set => SetValue(SafeAreaInsetProperty, value);
        }

        public static readonly BindableProperty SafeAreaInsetBottomProperty =
           BindableProperty.Create(nameof(SafeAreaInsetBottom), typeof(Thickness), typeof(CustomPage), default(Thickness), BindingMode.TwoWay);

        public Thickness SafeAreaInsetBottom
        {
            get => (Thickness)GetValue(SafeAreaInsetBottomProperty);
            set => SetValue(SafeAreaInsetBottomProperty, value);
        }

        private double width = 0;
        private double height = 0;
        public bool IsLandscapeMode => Width > Height;

        public CustomPage()
        {

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (BindingContext is IContentPageViewModel pageViewModel)
                pageViewModel.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            if (BindingContext is IContentPageViewModel pageViewModel)
                pageViewModel.OnDisAppearing();
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if (this.width != width || this.height != height)
            {
                this.width = width;
                this.height = height;
                OrientationChanged(width > height);
            }
        }

        public virtual void OrientationChanged(bool isLandscapeMode)
        {

        }

        public virtual void SafeAreaInsetsChanged(Thickness safeAreaInset)
        {
            if (Device.RuntimePlatform != Device.iOS)
                return;

            SafeAreaInset = new Thickness(safeAreaInset.Left, safeAreaInset.Top, safeAreaInset.Right, safeAreaInset.Bottom);
            SafeAreaInsetOnlyBySide = new Thickness(SafeAreaInset.Left, 0, safeAreaInset.Right, 0);
            SafeAreaInsetBottom = new Thickness(SafeAreaInset.Left, 0, safeAreaInset.Right, safeAreaInset.Bottom);

            if (!(BindingContext is IContentPageViewModel contentModel))
                return;
            contentModel.SafeAreaInset = SafeAreaInset;

            if (!(BindingContext is IListContentViewModel listModel))
                return;
            listModel.ListValues.UpdateSafeAreaInset(SafeAreaInsetOnlyBySide);
        }
    }
}
