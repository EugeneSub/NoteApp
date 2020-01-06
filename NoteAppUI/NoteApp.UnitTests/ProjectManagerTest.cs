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
        public void SaveToFile()
        {
            var test = new Project { Note1 = new List<Note>()};

            test.Note1.Add(new Note("Name", "Text", TheCategory.Misc, new DateTime(2020, 01, 05), new DateTime(2020, 01, 05)));

            test.Note1.Add(new Note("Name2", "Text2", TheCategory.Home, new DateTime(2020, 01, 05), new DateTime(2020, 01, 05)));

            test.Note1.Add(new Note("Name3", "Text3", TheCategory.Work, new DateTime(2020, 01, 05), new DateTime(2020, 01, 05)));

            ProjectManager.SaveToFile(test, @"test.json");

            var expected = File.ReadAllText(@"test.json");

            var actual = JsonConvert.SerializeObject(test);

            Assert.AreEqual(actual, expected, "Сравнение сериализатора ProjectManager и встроенного");
        }

        [Test(Description = "Тест десериализации")]
        public void LoadFromFile()
        {
            var actual = new Project { Note1 = new List<Note>() };

            actual.Note1.Add(new Note("Name", "Text", TheCategory.Misc, new DateTime(2020, 01, 05), new DateTime(2020, 01, 05)));

            actual.Note1.Add(new Note("Name2", "Text2", TheCategory.Home, new DateTime(2020, 01, 05), new DateTime(2020, 01, 05)));

            actual.Note1.Add(new Note("Name3", "Text3", TheCategory.Work, new DateTime(2020, 01, 05), new DateTime(2020, 01, 05)));

            var expected = ProjectManager.LoadFromFile(@"test.json");

            var actualText = JsonConvert.SerializeObject(actual);

            var expectedText = JsonConvert.SerializeObject(expected);

            Assert.AreEqual(actualText, expectedText, "Сравнение результата десериализованного объекта и ожидаемого");

        }
    }
}
