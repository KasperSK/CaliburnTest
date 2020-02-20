using System;
using System.Collections.Generic;
using System.Text;
using Caliburn.Micro;
using TestApp.Views;

namespace TestApp
{
    public class App : FormsApplication
    {
        private readonly SimpleContainer container;
        public App(SimpleContainer container)
        {
            this.container = container;

            DisplayRootView<TestView>();
        }
    }
}
