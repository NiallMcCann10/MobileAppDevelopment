using System;
using System.Collections.Generic;
using System.Text;

namespace ToDo.Model
{
    public class Tasks
    {
        public string Task { get; set; }
        public string Status { get; set; }

        public Tasks()
        {

        }
        public Tasks(string t, string s)
        {
            Task = t;
            Status = s;
        }
    }
}
