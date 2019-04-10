using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.ViewModels;
using Xamarin.Forms;


namespace ToDo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = new MainPageViewModel(new PageService());
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            TasksViewModel task = (sender as MenuItem).CommandParameter as TasksViewModel;
            (BindingContext as MainPageViewModel).DeleteFromListCommand.Execute(task);
        }

        private void ToDoTaskSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await (BindingContext as MainPageViewModel).SelectOneDog(e.SelectedItem as TasksViewModel);
        }
    }
}
