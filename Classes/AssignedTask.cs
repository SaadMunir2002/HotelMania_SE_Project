using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finalsProject.Classes
{
    public class AssignedTask
    {
        private int taskid;
        private int staffid;
        

        public AssignedTask(int taskid, int staffid)
        {
            this.taskid = taskid;
            this.staffid = staffid;
        }
        public int Taskid { get => taskid; set => taskid = value; }
        public int Staffid { get => staffid; set => staffid = value; }
    }
}
