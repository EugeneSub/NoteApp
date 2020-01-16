using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.IO;
using System.Reflection;
using NoteApp;
using Newtonsoft.Json;


namespace NoteApp.UnitTests
{
    [TestFixture]
    class ProjectManagerTest
    {
        [Test(Description = "Тест сериализации")]
        public void SaveToFileTest()
        {
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string testfile = $@"{path}\test.json";
            string actualfile = $@"{path}\test1.json";
            var test = new Project { Note1 = new List<Note>()};

            test.Note1.Add(new Note("Name", "Text1", TheCategory.Misc, new DateTime(2020, 01, 14).Date, new DateTime(2020, 01, 14).Date));
            test.Note1.Add(new Note("Name2", "Text2", TheCategory.Home, new DateTime(2020, 01, 14).Date, new DateTime(2020, 01, 14).Date));
            test.Note1.Add(new Note("Name3", "Text3", TheCategory.Work, new DateTime(2020, 01, 14).Date, new DateTime(2020, 01, 14).Date));

            string expected = File.ReadAllText(testfile);
            ProjectManager.SaveToFile(test, actualfile);
            string actual = File.ReadAllText(actualfile);
            Assert.AreEqual(actual, expected, "Файлы не совпадают");
        }

        [Test(Description = "Тест десериализации")]
        public void LoadFromFileTest()
        {
            var expected = new Project { Note1 = new List<Note>() };

            expected.Note1.Add(new Note("Name", "Text1", TheCategory.Misc, new DateTime(2020, 01, 14).Date, new DateTime(2020, 01, 14).Date));
            expected.Note1.Add(new Note("Name2", "Text2", TheCategory.Home, new DateTime(2020, 01, 14).Date, new DateTime(2020, 01, 14).Date));
            expected.Note1.Add(new Note("Name3", "Text3", TheCategory.Work, new DateTime(2020, 01, 14).Date, new DateTime(2020, 01, 14).Date));
            
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string actualfile = $@"{path}\test.json";

            var actual = ProjectManager.LoadFromFile(actualfile);

            var expectedText = JsonConvert.SerializeObject(expected);

            var actualText = JsonConvert.SerializeObject(actual);
            Assert.AreEqual(actualText, expectedText, "Файлы не совпадают");
        }
    }
}
