using System.Windows;
using System.Windows.Controls;

namespace cursach
{
    public partial class TestWindow : Window
    {
        public TestWindow(Test testObj)
        {
            InitializeComponent();
            QuestionsPanel.Children.Add(CreateVisualOfQuestions(testObj));
        }
        private StackPanel CreateVisualOfQuestions(Test test)
        {
            StackPanel questionsPanel = new StackPanel();
            foreach (Question question in test.questions)
            {
                TextBlock questionName = new TextBlock();
                questionName.Text = question.questionName;
                questionName.FontSize = 15;
                questionsPanel.Children.Add(questionName);
                questionsPanel.Children.Add(CreateVisualOfOptions(question));
            }
            return questionsPanel;
        }
        private StackPanel CreateVisualOfOptions(Question question)
        {
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
