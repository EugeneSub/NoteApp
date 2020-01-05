using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;



namespace NoteApp
{
    /// <summary>
    /// Класс сериализации, с помощью которого выполняется загрузка/выгрузка информации в формате JSON.
    /// </summary>
    public class ProjectManager
    {
        public static void SaveToFile(Project note, string filename )
        {
            //Экземпляр сериализатора.
            JsonSerializer serializer = new JsonSerializer();
            //Открытие потока для записи в файл с указанием пути.
            using (StreamWriter sw = new StreamWriter(filename))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                //Вызов сериализации и передача объекта, которого нужно сериализовать.
                serializer.Serialize(writer, note);
            }
        }
        public static Project LoadFromFile(string filename)
        {
            //Переменная, в которую помещается результат десериализации.
            Project note = null;
            //Экземпляр сериализатора.
            JsonSerializer serializer = new JsonSerializer();
            //Открытие потока для чтения файла с указанием пути.
            using (StreamReader sr = new StreamReader(filename))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                //Вызов десериализации и явно преобразуем результат в целевой тип данных.
                note = serializer.Deserialize<Project>(reader);
             
            }
            return note;
        }
    }
}
