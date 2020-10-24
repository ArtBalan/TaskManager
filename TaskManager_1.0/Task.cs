using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager_1._0
{
    class Task
    {
        public string name;
        public bool done;

        public Task() { }


        public Task(string name)
        {
            this.name = name;
            done = false;
        }

        public Task(string name, bool done)
        {
            this.name = name;
            this.done = done;
        }
    }
}
