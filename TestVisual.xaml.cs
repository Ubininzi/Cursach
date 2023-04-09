using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
            TestWindow testWindowObj = new TestWindow((Test)((Control)sender).Tag);
            testWindowObj.Show();
        }
    }
}
