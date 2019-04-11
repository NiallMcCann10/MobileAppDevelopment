using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo;
using ToDo.Model;
using ToDo.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDo.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TasksDetailsPage : ContentPage
	{
        TasksViewModel _task;
        public TasksDetailsPage (TasksViewModel task)
		{
			InitializeComponent();
            _task = task;
            this.Title = _task.Task;
        }
	}
}