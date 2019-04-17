using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;


namespace ToDo.ViewModels
{
    public class TasksViewModel : BaseViewModel
    {
        public string Task { get; set; }
        public string Status { get; set; }

        #region == Methods ==
        public static ObservableCollection<TasksViewModel> ReadTasksListData()
        {
            ObservableCollection<TasksViewModel> myList = new ObservableCollection<TasksViewModel>();
            string jsonText;

            try  // reading the localApplicationFolder first
            {
                string path = Environment.GetFolderPath(
                                Environment.SpecialFolder.LocalApplicationData);
                string filename = Path.Combine(path, MyUtils.JSON_TASKS_FILE);
                using (var reader = new StreamReader(filename))
                {
                    jsonText = reader.ReadToEnd();
                    // need json library
                }
            }
            catch // fallback is to read the default file
            {
                var assembly = IntrospectionExtensions.GetTypeInfo(
                                                typeof(MainPage)).Assembly;
                // create the stream
                Stream stream = assembly.GetManifestResourceStream(
                                    "ToDo.Data.Tasks.txt");
                using (var reader = new StreamReader(stream))
                {
                    jsonText = reader.ReadToEnd();
                    // include JSON library now
                }
            }

            myList = JsonConvert.DeserializeObject<ObservableCollection<TasksViewModel>>(jsonText);

            return myList;
        }

        public static void UpdateTasksListData(TasksViewModel updatedTask)
        {
            ObservableCollection<TasksViewModel> tasksList = ReadTasksListData();
            foreach (var task in tasksList)
            {
                if(task.Task == updatedTask.Task)
                {
                    task.Status = updatedTask.Status;
                }
            }

            WriteToTaskList(tasksList);
        }

        public static void SaveTasksListData(TasksViewModel newTask)
        {
            ObservableCollection<TasksViewModel> tasksList = ReadTasksListData();
            tasksList.Add(newTask);

            WriteToTaskList(tasksList);
        }

        public static void WriteToTaskList(ObservableCollection<TasksViewModel> tasksList)
        {
            string path = Environment.GetFolderPath(
                Environment.SpecialFolder.LocalApplicationData);
            string filename = Path.Combine(path, MyUtils.JSON_TASKS_FILE);
            // use a stream writer to write the list
            using (var writer = new StreamWriter(filename, false))
            {
                // stringify equivalent
                string jsonText = JsonConvert.SerializeObject(tasksList);
                writer.WriteLine(jsonText);
            }
        }

        #endregion
    }
}
