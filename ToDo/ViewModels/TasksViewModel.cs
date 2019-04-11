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
        private string _task;
        public string Task
        {
            get { return _task; }
            set { SetValue(ref _task, value); }
        }

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

        public static void SaveTasksListData(ObservableCollection<TasksViewModel> saveList)
        {
            // need the path to the file
            string path = Environment.GetFolderPath(
                Environment.SpecialFolder.LocalApplicationData);
            string filename = Path.Combine(path, MyUtils.JSON_TASKS_FILE);
            // use a stream writer to write the list
            using (var writer = new StreamWriter(filename, false))
            {
                // stringify equivalent
                string jsonText = JsonConvert.SerializeObject(saveList);
                writer.WriteLine(jsonText);
            }
        }

        #endregion
    }
}
