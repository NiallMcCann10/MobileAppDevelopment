using System;
using System.Collections.Generic;
using System.Text;

namespace ToDo.Model
{
    class Tasks
    {
        public string Task { get; set; }

        public Tasks()
        {

        }
        public Tasks(string t)
        {
            Task = t;
        }
    }
}
