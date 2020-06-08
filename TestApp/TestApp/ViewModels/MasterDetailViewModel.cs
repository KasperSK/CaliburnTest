using System;
using System.Collections.Generic;
using System.Text;
using Caliburn.Micro;

namespace TestApp.ViewModels
{
    public class MasterDetailViewModel : Conductor<Screen>.Collection.OneActive
    {
        public MasterDetailViewModel(TestViewModel testViewModelOne, TestViewModel testViewModelTwo)
        {
            Items.Add(testViewModelTwo);
            Items.Add(testViewModelOne);
        }
    }
}
