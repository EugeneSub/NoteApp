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
        public List<Note> Note1 = new List<Note>();

        public List<Note> SortedList()
        {
            var sortedList = Note1.OrderByDescending(note => note.Changed).ToList();
            return sortedList;
        }

        public List<string> SortedList(TheCategory thecategory)
        {
            Note1 = Note1.OrderByDescending(note => note.Changed).ToList();

            var titles = new List<string>();
            foreach (var note in Note1)
            {
                if (thecategory == TheCategory.All)
                {
                    titles.Add(note.Name);
                }
                else if(note.theCategory == thecategory)
                {
                    titles.Add(" > " + note.Name);
                }
                else
                {
                    titles.Add(note.Name);
                }
            }
            return titles;
            //var sortedList2 = Note1.OrderBy(note => note.theCategory).ToList();
            //return sortedList2;
        }



    }
}
