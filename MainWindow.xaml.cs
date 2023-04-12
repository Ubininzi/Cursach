using System.Collections.Generic;
using System.Windows;
using System.IO;
using System.Windows.Controls;
using System.Windows.Media;
using cursach;
using System.Windows.Shapes;

namespace cursach
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            StackPanel1.Children.Add(CreateVisualOfTests());
        }
        private StackPanel CreateVisualOfTests()
        {
            List<Test> listOfTests = TestClass.CreateListOfTestsFromLocalDirectory();
            StackPanel testsPanel = new StackPanel();

            foreach (Test test in listOfTests)
            {
                TestClassVisual TestObj = new TestClassVisual();
                TestObj.TestName.Text = test.testName;
                TestObj.BeginButton.Tag = test;
                testsPanel.Children.Add(TestObj);
            }
            return testsPanel;
        }
    }
}
