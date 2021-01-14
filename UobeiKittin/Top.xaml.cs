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

namespace UobeiKittin {
    /// <summary>
    /// Top.xaml の相互作用ロジック
    /// </summary>
    public partial class Top : Page {
        public Top() {
            InitializeComponent();
        }

        private void ToggleButton_Loaded(object sender, RoutedEventArgs e) {

        }

        private void config_Click(object sender, RoutedEventArgs e) {
            var page2 = new Configuration();
            NavigationService.Navigate(page2);
        }
    }
}
