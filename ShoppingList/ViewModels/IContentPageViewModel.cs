using System;
using System.Threading.Tasks;
using ShoppingList.Models;

namespace ShoppingList.ViewModels
{
    public interface IContentPageViewModel : IContentViewModel
    {
        void LoadPageModel(bool isReload = false);

        Task<IValueModel> GetModel();

        void SetModelView(IValueModel valueModel);

        void SetViewNoData();

        void SetViewSuccess();

        void OnAppearing();

        void OnDisAppearing();
    }
}
