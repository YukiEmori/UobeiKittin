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

        private void Window_Loaded(object sender, RoutedEventArgs e) {

            UobeiKittin.SushiOrderDBDataSet1 sushiOrderDBDataSet1 = ((UobeiKittin.SushiOrderDBDataSet1)(this.FindResource("sushiOrderDBDataSet1")));
            // テーブル 注文情報 にデータを読み込みます。必要に応じてこのコードを変更できます。
            UobeiKittin.SushiOrderDBDataSet1TableAdapters.注文情報TableAdapter sushiOrderDBDataSet1注文情報TableAdapter = new UobeiKittin.SushiOrderDBDataSet1TableAdapters.注文情報TableAdapter();
            sushiOrderDBDataSet1注文情報TableAdapter.Fill(sushiOrderDBDataSet1.注文情報);
            System.Windows.Data.CollectionViewSource 注文情報ViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("注文情報ViewSource")));
            注文情報ViewSource.View.MoveCurrentToFirst();
        }
    }
}
