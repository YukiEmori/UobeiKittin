using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Navigation;

namespace UobeiKittin {
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();

            Uri uri = new Uri("/Top.xaml", UriKind.Relative);
            frame.Source = uri;
        }

        //運用メニュー
        private void ToggleButton_Loaded(object sender, RoutedEventArgs e) {
            var btn = (ToggleButton)sender;
            btn.SetBinding(ToggleButton.IsCheckedProperty, new Binding("IsOpen") { Source = btn.ContextMenu });
            btn.ContextMenu.PlacementTarget = btn;
            btn.ContextMenu.Placement = PlacementMode.Bottom;
          
        }

        private void Order(object sender, RoutedEventArgs e) {
                  
        }

        private void btconfig_Click(object sender, RoutedEventArgs e) {
           
        }
    }
}
