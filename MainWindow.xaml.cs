using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using TestLogic;

namespace cursach
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            StackPanel1.Children.Add(CreateVMOfTests());
        }
        private StackPanel CreateVMOfTests()
        {
            List<Test> listOfTests = TestClass.createListOfTestsFromLocalDirectory();
            StackPanel testsPanel = new StackPanel();

            foreach (Test test in listOfTests)
            {
                TestClassVM TestObj = new TestClassVM();
                TestObj.TestName.Text = test.testName;
                testsPanel.Children.Add(TestObj);
            }
            return testsPanel;
        }
        private StackPanel CreateVMOfQuestions(Test test)
        {
            StackPanel questionsPanel = new StackPanel();
            foreach (Question question in test.questions)
            {
                TextBlock questionName = new TextBlock();
                questionName.Text = question.questionName;
                questionName.FontSize = 15;
                questionsPanel.Children.Add(questionName);
                questionsPanel.Children.Add(CreateVMOfOptions(question));
            }
            return questionsPanel;
        }
        private StackPanel CreateVMOfOptions(Question question) {
            StackPanel optionsPanel = new StackPanel();
            optionsPanel.Orientation = Orientation.Horizontal;
            foreach (string option in question.options)
            {
                RadioButton answer = new RadioButton();
                answer.Content = option;
                answer.Margin = new System.Windows.Thickness(5);

                optionsPanel.Children.Add(answer);
            }
            optionsPanel.Margin = new System.Windows.Thickness(10);
            return optionsPanel;
        }
    }
}
