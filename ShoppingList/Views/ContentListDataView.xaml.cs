using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ShoppingList.Views
{
    public partial class ContentListDataView : ContentView
    {
        // IsBusy
        public static readonly BindableProperty IsBusyProperty =
           BindableProperty.Create(nameof(IsBusy), typeof(bool), typeof(ContentListDataView), default(bool), BindingMode.TwoWay);
        public bool IsBusy
        {
            get => (bool)GetValue(IsBusyProperty);
            set => SetValue(IsBusyProperty, value);
        }

        // IsValueDataEmpty
        public static readonly BindableProperty IsValueDataEmptyProperty =
            BindableProperty.Create(nameof(IsValueDataEmpty), typeof(bool), typeof(ContentListDataView), default(bool), BindingMode.TwoWay);
        public bool IsValueDataEmpty
        {
            get => (bool)GetValue(IsValueDataEmptyProperty);
            set => SetValue(IsValueDataEmptyProperty, value);
        }

        // RefreshCommand
        public static readonly BindableProperty RefreshCommandProperty =
            BindableProperty.Create(nameof(RefreshCommand), typeof(Command), typeof(ContentListDataView), default(Command));
        public Command RefreshCommand
        {
            get => (Command)GetValue(RefreshCommandProperty);
            set => SetValue(RefreshCommandProperty, value);
        }

        // IsRefreshing
        public static readonly BindableProperty IsRefreshingProperty =
            BindableProperty.Create(nameof(IsRefreshing), typeof(bool), typeof(ContentListDataView), default(bool), BindingMode.TwoWay);
        public bool IsRefreshing
        {
            get => (bool)GetValue(IsRefreshingProperty);
            set => SetValue(IsRefreshingProperty, value);
        }

        // ItemTemplate
        public static readonly BindableProperty ItemTemplateProperty =
            BindableProperty.Create(nameof(ItemTemplate), typeof(DataTemplateSelector), typeof(ContentListDataView), default(DataTemplateSelector), BindingMode.TwoWay);
        public DataTemplate ItemTemplate
        {
            get => (DataTemplate)GetValue(ItemTemplateProperty);
            set => SetValue(ItemTemplateProperty, value);
        }

        // ListValues
        public static readonly BindableProperty ListValuesProperty =
            BindableProperty.Create(nameof(ListValues), typeof(IEnumerable<object>), typeof(ContentListDataView), default(IEnumerable<object>), BindingMode.TwoWay);
        public IEnumerable<object> ListValues
        {
            get => (IEnumerable<object>)GetValue(ListValuesProperty);
            set => SetValue(ListValuesProperty, value);
        }

        // SelectedItem
        public static readonly BindableProperty SelectedItemProperty =
            BindableProperty.Create(nameof(SelectedItem), typeof(object), typeof(ContentListDataView), default(object), BindingMode.TwoWay);
        public object SelectedItem
        {
            get => (object)GetValue(SelectedItemProperty);
            set => SetValue(SelectedItemProperty, value);
        }

        // FooterSpaceHeight
        public static readonly BindableProperty FooterSpaceHeightProperty =
            BindableProperty.Create(nameof(FooterSpaceHeight), typeof(float), typeof(ContentListDataView), (float)44.0f, BindingMode.TwoWay);
        public float FooterSpaceHeight
        {
            get => (float)GetValue(FooterSpaceHeightProperty);
            set => SetValue(FooterSpaceHeightProperty, value);
        }

        // IsVisibleRefreshButton
        public static readonly BindableProperty IsVisibleRefreshButtonProperty =
            BindableProperty.Create(nameof(IsVisibleRefreshButton), typeof(bool), typeof(ContentListDataView), default(bool));

        public bool IsVisibleRefreshButton
        {
            get => (bool)GetValue(IsVisibleRefreshButtonProperty);
            set => SetValue(IsVisibleRefreshButtonProperty, value);
        }

        // Header
        public static readonly BindableProperty HeaderProperty =
            BindableProperty.Create(nameof(Header), typeof(object), typeof(ContentListDataView), default, BindingMode.TwoWay);
        public object Header
        {
            get => GetValue(HeaderProperty);
            set => SetValue(HeaderProperty, value);
        }

        // NoDataDisplayText
        public static readonly BindableProperty NoDataDisplayTextProperty =
            BindableProperty.Create(nameof(NoDataDisplayText), typeof(string),
                typeof(ContentListDataView), "No data", BindingMode.TwoWay,
                propertyChanged: OnNoDataDisplayTextPropertyChanged);

        private static void OnNoDataDisplayTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable != null && bindable is ContentListDataView dataView)
                dataView.NoDataDisplayText = (string)newValue;
        }

        public string NoDataDisplayText
        {
            get => (string)GetValue(NoDataDisplayTextProperty);
            set => SetValue(NoDataDisplayTextProperty, value);
        }

        public ContentListDataView()
        {
            InitializeComponent();

            this.SetBinding(IsBusyProperty, nameof(IsBusy));
            this.SetBinding(IsValueDataEmptyProperty, nameof(IsValueDataEmpty));

            this.SetBinding(RefreshCommandProperty, nameof(RefreshCommand));
            this.SetBinding(IsRefreshingProperty, nameof(IsRefreshing));

            this.SetBinding(ItemTemplateProperty, nameof(ItemTemplate));
            this.SetBinding(SelectedItemProperty, nameof(SelectedItem));
            this.SetBinding(ListValuesProperty, nameof(ListValues));

            this.SetBinding(NoDataDisplayTextProperty, nameof(NoDataDisplayText));
        }

        public void ListViewItem_Tapped(object sender, EventArgs arg)
        {
            if (!(sender is ListView listView))
                return;

            listView.SelectedItem = null;
        }
    }
}
