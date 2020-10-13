using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextBoxGenerationTool.ViewModels;
using Xamarin.Forms;

namespace TextBoxGenerationTool
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            Task.Run(() => 
            {
                var vm = BindingContext as MainViewModel;
                vm.Initialize();
            });
        }
    }
}
