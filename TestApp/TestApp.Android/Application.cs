using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Android.App;
using Android.Content;
using Android.Hardware.Usb;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Caliburn.Micro;

namespace TestApp.Droid
{
    [Application()]
    class Application : CaliburnApplication
    {
        private SimpleContainer container;

        public Application(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {

        }

        public override void OnCreate()
        {
            Initialize();
        }

        protected override void Configure()
        {
            container = new SimpleContainer();
            container.Singleton<App>();
        }

        protected override IEnumerable<Assembly> SelectAssemblies()
        {
            return new List<Assembly>()
            {
                typeof(App).Assembly,
                typeof(Application).Assembly
            };
        }

        protected override void BuildUp(object instance)
        {
            container.BuildUp(instance);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {

            return container.GetAllInstances(service);
        }

        protected override object GetInstance(Type service, string key)

        {
            return container.GetInstance(service, key);
        }
    }
}