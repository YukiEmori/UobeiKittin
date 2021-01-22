using System;
using System.Collections.Generic;
using System.Data;
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

        UobeiKittin.SushiOrderDBproduct sushiOrderDBproduct;
        UobeiKittin.SushiOrderDBproductTableAdapters.商品テーブルTableAdapter sushiOrderDBproduct商品テーブルTableAdapter;
        System.Windows.Data.CollectionViewSource 商品テーブルViewSource;
        public Configuration() {
            InitializeComponent();
        }

        //WPFを起動したときに実行する
        private void Window_Loaded(object sender, RoutedEventArgs e) {

            sushiOrderDBproduct = ((UobeiKittin.SushiOrderDBproduct)(this.FindResource("sushiOrderDBproduct")));
            // テーブル 商品テーブル にデータを読み込みます。必要に応じてこのコードを変更できます。
            sushiOrderDBproduct商品テーブルTableAdapter = new UobeiKittin.SushiOrderDBproductTableAdapters.商品テーブルTableAdapter();
            sushiOrderDBproduct商品テーブルTableAdapter.Fill(sushiOrderDBproduct.商品テーブル);
            商品テーブルViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("商品テーブルViewSource")));
            商品テーブルViewSource.View.MoveCurrentToFirst();
        }

        //閉じるボタン
        private void Close_Click(object sender, RoutedEventArgs e) {
            var toppege = new Top();
            NavigationService.Navigate(toppege);
        }

        //全て表示ボタン
        private void All_Click(object sender, RoutedEventArgs e) {
            Window_Loaded(sender, e);
        }

        //握りボタン
        private void Nigiri_Click_1(object sender, RoutedEventArgs e) {
            sushiOrderDBproduct = ((UobeiKittin.SushiOrderDBproduct)(this.FindResource("sushiOrderDBproduct")));
            // テーブル 商品テーブル にデータを読み込みます。必要に応じてこのコードを変更できます。
            sushiOrderDBproduct商品テーブルTableAdapter = new UobeiKittin.SushiOrderDBproductTableAdapters.商品テーブルTableAdapter();
            sushiOrderDBproduct商品テーブルTableAdapter.FillByType01(sushiOrderDBproduct.商品テーブル);
            商品テーブルViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("商品テーブルViewSource")));
            商品テーブルViewSource.View.MoveCurrentToFirst();
        }

        //軍艦巻物ボタン
        private void Gunkan_Click(object sender, RoutedEventArgs e) {
            sushiOrderDBproduct = ((UobeiKittin.SushiOrderDBproduct)(this.FindResource("sushiOrderDBproduct")));
            // テーブル 商品テーブル にデータを読み込みます。必要に応じてこのコードを変更できます。
            sushiOrderDBproduct商品テーブルTableAdapter = new UobeiKittin.SushiOrderDBproductTableAdapters.商品テーブルTableAdapter();
            sushiOrderDBproduct商品テーブルTableAdapter.FillByType02(sushiOrderDBproduct.商品テーブル);
            商品テーブルViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("商品テーブルViewSource")));
            商品テーブルViewSource.View.MoveCurrentToFirst();
        }

        //サイドボタン
        private void Saido_Click_1(object sender, RoutedEventArgs e) {
            sushiOrderDBproduct = ((UobeiKittin.SushiOrderDBproduct)(this.FindResource("sushiOrderDBproduct")));
            // テーブル 商品テーブル にデータを読み込みます。必要に応じてこのコードを変更できます。
            sushiOrderDBproduct商品テーブルTableAdapter = new UobeiKittin.SushiOrderDBproductTableAdapters.商品テーブルTableAdapter();
            sushiOrderDBproduct商品テーブルTableAdapter.FillByType03(sushiOrderDBproduct.商品テーブル);
            商品テーブルViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("商品テーブルViewSource")));
            商品テーブルViewSource.View.MoveCurrentToFirst();

        }
        //デザート・ドリンクボタン
        private void Drink_Click(object sender, RoutedEventArgs e) {
            sushiOrderDBproduct = ((UobeiKittin.SushiOrderDBproduct)(this.FindResource("sushiOrderDBproduct")));
            // テーブル 商品テーブル にデータを読み込みます。必要に応じてこのコードを変更できます。
            sushiOrderDBproduct商品テーブルTableAdapter = new UobeiKittin.SushiOrderDBproductTableAdapters.商品テーブルTableAdapter();
            sushiOrderDBproduct商品テーブルTableAdapter.FillByType04(sushiOrderDBproduct.商品テーブル);
            商品テーブルViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("商品テーブルViewSource")));
            商品テーブルViewSource.View.MoveCurrentToFirst();


        }

        //品切れ設定ボタン
        private void Settei_Click(object sender, RoutedEventArgs e) {
            DataRowView drv = (DataRowView)商品テーブルViewSource.View.CurrentItem;
            drv.Row[5] = "販売終了";
        }

        //品切れ解除ボタン
        private void Setteikaijyo(object sender, RoutedEventArgs e) {
            DataRowView drv = (DataRowView)商品テーブルViewSource.View.CurrentItem;
            drv.Row[5] = null;
        }

        
        //登録ボタン
        private void Touroku_Click(object sender, RoutedEventArgs e) {
            sushiOrderDBproduct商品テーブルTableAdapter.Update(sushiOrderDBproduct.商品テーブル);
        }
    }
}
