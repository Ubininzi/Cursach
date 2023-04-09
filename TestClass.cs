using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;


namespace cursach
{
    public struct Test
    {
        public string testName;
        public string time;
        public List<Question> questions;
        public Dictionary<int, int> marks;
    }
    public struct Question
    {
        public string questionName;
        public List<string> options;
        public List<string> rightAnswers;
    }
    class TestClass
    {
        internal static List<Test> CreateListOfTestsFromLocalDirectory()
        {
            string[] ListOfPathToTests = Directory.GetFiles("C:\\Users\\Максим\\AppData\\Local\\Ubininzi", "*.json");
            List<Test> listOfTests = new List<Test>();
            if (ListOfPathToTests != null)
            {
                foreach (string testFilePath in ListOfPathToTests)
                {
                    string jsonText = File.ReadAllText(testFilePath);
                    listOfTests.Add(JsonConvert.DeserializeObject<Test>(jsonText));
                }
            }
            return listOfTests;
        }
    }
}
