using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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

　　　　

        //運用メニューのページを出す
        private void ToggleButton_Loaded(object sender, RoutedEventArgs e) {
            var btn = (ToggleButton)sender;

            btn.SetBinding(ToggleButton.IsCheckedProperty, new Binding("IsOpen") { Source = btn.ContextMenu });
            btn.ContextMenu.PlacementTarget = btn;
            btn.ContextMenu.Placement = PlacementMode.Bottom;
        }

        //売切れ設定ページに移動
        private void config_Click(object sender, RoutedEventArgs e) {
            var confingpage = new Configuration();
            NavigationService.Navigate(confingpage);
        }

        //オーダーリストのページに移動
        private void order_Click(object sender, RoutedEventArgs e) {
            var orderpage = new orderlist();
            NavigationService.Navigate(orderpage);
        }
    }
}
