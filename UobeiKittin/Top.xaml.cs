using System;
using System.Collections.Generic;
using System.Data;
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
using UobeiKittin.SushiOrderDBDataSet1TableAdapters;

namespace UobeiKittin {
    /// <summary>
    /// Top.xaml の相互作用ロジック
    /// </summary>
    public partial class Top : Page {
        public Top() {
            InitializeComponent();
        }
        
        UobeiKittin.SushiOrderDBDataSet1 sushiOrderDBDataSet1;
        UobeiKittin.SushiOrderDBDataSet1TableAdapters.注文情報TableAdapter sushiOrderDBDataSet1注文情報TableAdapter;
        System.Windows.Data.CollectionViewSource 注文情報ViewSource;
        

        //windowが起動したとき
        private void Window_Loaded(object sender, RoutedEventArgs e) {

            sushiOrderDBDataSet1 = ((UobeiKittin.SushiOrderDBDataSet1)(this.FindResource("sushiOrderDBDataSet1")));
            // テーブル 注文情報 にデータを読み込みます。必要に応じてこのコードを変更できます。
            sushiOrderDBDataSet1注文情報TableAdapter = new UobeiKittin.SushiOrderDBDataSet1TableAdapters.注文情報TableAdapter();
            sushiOrderDBDataSet1注文情報TableAdapter.Fill(sushiOrderDBDataSet1.注文情報);
            注文情報ViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("注文情報ViewSource")));
            注文情報ViewSource.View.MoveCurrentToFirst();

            var num =sushiOrderDBDataSet1注文情報TableAdapter.ScalarQuery();

            int count = 0;
            string status = "未";
           
            for (int i = 0; i<num; i++) {
                var drv = (DataRow)sushiOrderDBDataSet1.注文情報.Rows[i];
                status = drv[9].ToString();
                if (drv[9].ToString() == status && count == 0) {
                    Order1.Visibility = Visibility.Visible;
                }
                else if (drv[9].ToString() == status && count == 1) {
                    Order2.Visibility = Visibility.Visible;
                } 
                else if (drv[9].ToString() == status && count == 2) {
                    Order3.Visibility = Visibility.Visible;
                }
                else if (drv[9].ToString() == status && count == 3) {
                    Order4.Visibility = Visibility.Visible;
                }
                else if (drv[9].ToString() == status && count == 4) {
                    Order5.Visibility = Visibility.Visible;
                }
                else if (drv[9].ToString() == status && count == 5) {
                    Order6.Visibility = Visibility.Visible;
                }
                else if (drv[9].ToString() == status && count == 6) {
                    Order7.Visibility = Visibility.Visible;
                }
                else if (drv[9].ToString() == status && count == 7) {
                    Order8.Visibility = Visibility.Visible;
                }
                else if (drv[9].ToString() == status && count == 8) {
                    Order9.Visibility = Visibility.Visible;
                }
                else if (drv[9].ToString() == status && count == 9) {
                    Order10.Visibility = Visibility.Visible;
                }
                else if (drv[9].ToString() == status && count == 10) {
                    Order11.Visibility = Visibility.Visible;
                } 
                else if (drv[9].ToString() == status && count == 11) {
                    Order12.Visibility = Visibility.Visible;
                } 
                else if (drv[9].ToString() == status && count == 12) {
                    Order13.Visibility = Visibility.Visible;
                } 
                else if (drv[9].ToString() == status && count == 13) {
                    Order14.Visibility = Visibility.Visible;
                }
                else if (drv[9].ToString() == status && count == 14) {
                    Order15.Visibility = Visibility.Visible;
                }

                count++;
                
            }


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

        //注文ボタン一つ目
        
    }
}
