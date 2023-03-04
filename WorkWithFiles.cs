using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

using Newtonsoft.Json;


namespace workWithFiles
{
    class Test
    {
        public string name;
        public List<Question> questions;
        public Test(string name, List<Question> questions)
        {
            this.name = name;
            this.questions = questions;
        }
    }
    class Question
    {
        public string questionName;
        public List<string> answers;
        public List<string> rightAnswers;
        public Question(string questionName, List<string> answers, List<string> rightAnswers)
        {
            this.questionName = questionName;
            this.answers = answers;
            this.rightAnswers = rightAnswers;
        }
    }
    class WorkWithFiles
    {
        public static void createJsonFromTestClass(Test testObj)
        {
            string json = JsonConvert.SerializeObject(testObj);
            if (!File.Exists("D:\\amalgama.json"))
                File.Create("D:\\amalgama.json");
            File.WriteAllText("D:\\amalgama.json", json);
        }

    }
}
