using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp
{
    public class Note
    {
        public string name { get; set; }
        public string category { get; set; }
        public string text { get; set; }
        private DateTime created { get; set; }
        private DateTime changed { get; set; }
    }

    enum NoteCategory
    {
        Work,
        Home,
        Health,
        People,
        Documents,
        Phinances,
        Misc
    }

    public class Project
    {

    }

    public class ProjectManager
    {

    }

}
