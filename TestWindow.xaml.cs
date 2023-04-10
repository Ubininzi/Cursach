using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace cursach
{
	public partial class TestWindow : Window
	{
		Dictionary<string, string> answers = new();
		public TestWindow(Test testObj)
		{
			InitializeComponent();
			TestName.Text = testObj.testName;
			TimeBlock.Text = testObj.time;
			QuestionsPanel.Children.Add(CreateVisualOfQuestions(testObj));

			
			//DispatcherTimer TestTimer = new DispatcherTimer();
			//TestTimer.Tick += new EventHandler(TestTimer_Tick);
			//TestTimer.Interval = new TimeSpan(0, 0, 1);
			//TestTimer.Start();
		}
		private void TestTimer_Tick(object sender, EventArgs e)
		{
			// Updating the Label which displays the current second
			//TimeBlock.Text

			// Forcing the CommandManager to raise the RequerySuggested event
			CommandManager.InvalidateRequerySuggested();
		}

		private StackPanel CreateVisualOfQuestions(Test test)
		{
			StackPanel questionsPanel = new();
			foreach (Question question in test.questions)
			{
				QuestionVisual que = new();
				que.QuestionName.Text = question.questionName;
				foreach (string option in question.options)
				{
					RadioButton answer = new()
					{
						GroupName = question.questionName,
						Content = option,
						Margin = new Thickness(5),
					};
					answer.Checked += Answer_Checked;
					que.OptionsPanel.Children.Add(answer);
				}
				questionsPanel.Children.Add(que);
			}
			return questionsPanel;
		}
		private void AcceptAnswers() {
			//foreach (QuestionVisual auestion in QuestionsPanel)
		}
		private void Answer_Checked(object sender, RoutedEventArgs e)
		{
			answers.Remove(((RadioButton)sender).GroupName);
			answers.Add(((RadioButton)sender).GroupName,((RadioButton)sender).Content.ToString());
		}
		private void Confirm_Click(object sender, RoutedEventArgs e)
		{
			AcceptAnswers();
		}
	}
}
