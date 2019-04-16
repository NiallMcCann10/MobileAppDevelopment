﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ToDo.Views;
using Xamarin.Forms;

namespace ToDo.ViewModels
{
    class MainPageViewModel : BaseViewModel
    {
        #region == private fields ==
        private ObservableCollection<TasksViewModel> tasksList;
        private TasksViewModel selectedTask;
        #endregion

        #region == Public Properties ==
        public ObservableCollection<TasksViewModel> TasksList
        {
            get { return tasksList; }
            set { SetValue(ref tasksList, value); }
        }
        public TasksViewModel SelectedTask
        {
            get { return selectedTask; }
            set
            {
                SetValue(ref selectedTask, value);

            }
        }
        #endregion

        #region == Command Properties ==
        // ICommand is an interface with two methods
        // can execute and execute
        public ICommand ReadListCommand { get; private set; }
        public ICommand SaveListCommand { get; private set; }
        public ICommand DeleteFromListCommand { get; private set; }
        #endregion

        #region == public events ==
        private readonly IPageService _pageService;
        public MainPageViewModel(IPageService pageService)
        {
            _pageService = pageService;
            ReadList();
            ReadListCommand = new Command(ReadList);
            SaveListCommand = new Command(SaveList);
            DeleteFromListCommand = new Command<TasksViewModel>(DeleteFromList);
        }

        private void SaveList()
        {
            TasksViewModel.SaveTasksListData(TasksList);
        }

        private void ReadList()
        {
            TasksList = TasksViewModel.ReadTasksListData();
        }

        private void DeleteFromList(TasksViewModel t)
        {
            TasksList.Remove(t);
            SelectedTask = null;
        }

        public async Task SelectOneTask(TasksViewModel task)
        {
            // can't use a command directly as there is only a commandRefresh
            // attribute

            if (tasksList == null)
                return;
            
            await _pageService.PushAsnyc(new TasksDetailsPage(task));

        }

        #endregion
    }
}