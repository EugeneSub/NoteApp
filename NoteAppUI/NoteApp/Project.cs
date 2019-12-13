using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp
{
    /// <summary>
    /// Класс, внутри которого находится список.
    /// </summary>
    public class Project
    {
        /// <summary>
        /// Список, в котором находится ключ и значение из полей Note
        /// </summary>
        public List<Note> dictionary = new List<Note>();
    }
}
