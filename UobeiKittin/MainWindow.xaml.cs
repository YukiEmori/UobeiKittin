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

        private void OnDragMoveWindow(object sender, System.Windows.Input.MouseButtonEventArgs e) {
            DragMove();
        }

       public void Closes() {
            Close();
        }
    }
    }
