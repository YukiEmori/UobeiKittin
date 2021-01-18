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
    /// Configuration.xaml の相互作用ロジック
    /// </summary>
    public partial class Configuration : Page {
        public Configuration() {
            InitializeComponent();
        }

        //閉じるボタン
        private void Close_Click(object sender, RoutedEventArgs e) {
            var toppege = new Top();
            NavigationService.Navigate(toppege);
        }

        //握りボタン
        private void Nigiri_Click_1(object sender, RoutedEventArgs e) {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {

            UobeiKittin.SushiOrderDBproduct sushiOrderDBproduct = ((UobeiKittin.SushiOrderDBproduct)(this.FindResource("sushiOrderDBproduct")));
            // テーブル 商品テーブル にデータを読み込みます。必要に応じてこのコードを変更できます。
            UobeiKittin.SushiOrderDBproductTableAdapters.商品テーブルTableAdapter sushiOrderDBproduct商品テーブルTableAdapter = new UobeiKittin.SushiOrderDBproductTableAdapters.商品テーブルTableAdapter();
            sushiOrderDBproduct商品テーブルTableAdapter.Fill(sushiOrderDBproduct.商品テーブル);
            System.Windows.Data.CollectionViewSource 商品テーブルViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("商品テーブルViewSource")));
            商品テーブルViewSource.View.MoveCurrentToFirst();
        }

        
    }
}
