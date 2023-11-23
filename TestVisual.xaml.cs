using System.Windows;
using System.Windows.Controls;

namespace cursach
{
    /// <summary>
    /// Логика взаимодействия для TestClassVM.xaml
    /// </summary>
    public partial class TestClassVisual : UserControl
    {
        public TestClassVisual()
        {
            InitializeComponent();
        }
        private void BeginButton_Click(object sender, RoutedEventArgs e)
        {
            TestWindow testWindowObj = new TestWindow((TestStruct)((Control)sender).Tag);
            testWindowObj.Show();
        }
    }
}
