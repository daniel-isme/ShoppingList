using System;
using System.Threading.Tasks;
using ShoppingList.Models;
using Xamarin.Forms;

namespace ShoppingList.ViewModels
{
    public class PageViewModel : BaseViewModel, IContentPageViewModel
    {
        public StatusPageModel StatusPage { get; private set; } = StatusPageModel.NoLoad;

        private bool isBusy;
        public bool IsBusy
        {
            get => isBusy;
            set => SetProperty(ref isBusy, value);
        }

        private bool isValueDataEmpty = false;
        public bool IsValueDataEmpty
        {
            get => isValueDataEmpty;
            set => SetProperty(ref isValueDataEmpty, value);
        }

        private string title = string.Empty;
        public virtual string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }

        private Thickness safeAreaInset;
        public Thickness SafeAreaInset
        {
            get => safeAreaInset;
            set
            {
                SetProperty(ref safeAreaInset, value);
                SafeAreaInsetOnlyBySide = new Thickness(value.Left, 0, value.Right, 0);
            }
        }

        private Thickness safeAreaInsetOnlyBySide;
        public Thickness SafeAreaInsetOnlyBySide
        {
            get => safeAreaInsetOnlyBySide;
            set => SetProperty(ref safeAreaInsetOnlyBySide, value);
        }

        public IValueModel Model { get; set; }

        private bool IsCache = false;
        private bool isRefreshing;
        public virtual bool IsRefreshing
        {
            get => isRefreshing;
            set
            {
                SetProperty(ref isRefreshing, value);
                IsCache = true;
            }
        }

        public Command RefreshCommand { get; set; }

        public bool IsPageNotLoaded => IsBusy && (StatusPage == StatusPageModel.NoLoad || StatusPage == StatusPageModel.ReLoad);
        public bool IsPageReload => StatusPage == StatusPageModel.ReLoad;
        public bool StatusCache => IsCache || IsPageReload;

        public PageViewModel(bool IsBusy = false)
        {
            this.IsBusy = IsBusy;
            RefreshCommand = new Command(() => {
                IsRefreshing = false;
                LoadPageModel(true);
            });
        }

        public virtual void OnAppearing()
        {
            if (IsPageNotLoaded)
            {
                LoadPageModel();
            }
        }

        public virtual void OnDisAppearing()
        {
        }

        public virtual void LoadPageModel(bool isReload = false)
        {
            SetNotLoadedPage(isReload);

            var task = Task.Run(async () =>
            {
                var newModel = await GetModel();
                SetModelView(newModel);
            });
        }

        public virtual async Task<IValueModel> GetModel()
        {
            return await Task.Run(() => new BaseValueModel());
        }

        public virtual void SetModelView(IValueModel valueModel)
        {
            Model = valueModel;
            IsBusy = false;
        }

        public void SetViewNoData()
        {
            IsCache = false;
            IsBusy = false;
            StatusPage = StatusPageModel.ProlemWithData;
            IsValueDataEmpty = true;
        }

        public void SetViewSuccess()
        {
            StatusPage = StatusPageModel.Loaded;
            IsValueDataEmpty = false;
            IsBusy = false;
            IsCache = false;
        }

        private void SetNotLoadedPage(bool isReload = false)
        {
            StatusPage = !isReload ? StatusPageModel.NoLoad : StatusPageModel.ReLoad;
            IsBusy = true;
            IsValueDataEmpty = false;
            IsCache = false;
        }

        public enum StatusPageModel { NoLoad, ReLoad, Loaded, ProlemWithData }
    }
}
