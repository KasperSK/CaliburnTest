using System;
using System.Collections.Generic;
using System.Text;
using Caliburn.Micro;
using TestApp.ViewModels;
using TestApp.Views;
using Xamarin.Forms;

namespace TestApp
{
    public class App : FormsApplication
    {
        private readonly SimpleContainer _container;
        public App(SimpleContainer container)
        {
            ViewModelLocator.AddNamespaceMapping("TestApp.ViewModels", "TestApp.Views");
            ViewModelLocator.AddNamespaceMapping("TestApp.Views", "TestApp.ViewModels");

            this._container = container;

            _container.PerRequest<TestViewModel>();
            _container.PerRequest<MasterDetailViewModel>();

            DisplayRootView(new MasterDetailView());
        }

        protected override void PrepareViewFirst(NavigationPage navigationPage)
        {
            var service = new NavigationPageAdapter(navigationPage);
            _container.Instance<INavigationService>(service);
            _container.Instance(service);
        }

        protected void DisplayRootView(MasterDetailPage viewType) 
        {
            FormsApplication formsApplication = this;

            PrepareViewFirst();

            if (viewType.Detail != RootNavigationPage)
                viewType.Detail = RootNavigationPage;

            var model = ViewModelLocator.LocateForView(viewType);

            ViewModelBinder.Bind(model, viewType, null);


            formsApplication.MainPage = (Page)viewType;
        }
    }
}
