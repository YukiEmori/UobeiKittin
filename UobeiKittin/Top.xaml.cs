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

        //初期値
        int count = 0;
        string statustei = "〇";
        string statusmi = "未";

        //windowが起動したとき
        private void Window_Loaded(object sender, RoutedEventArgs e) {

            sushiOrderDBDataSet1 = ((UobeiKittin.SushiOrderDBDataSet1)(this.FindResource("sushiOrderDBDataSet1")));
            // テーブル 注文情報 にデータを読み込みます。必要に応じてこのコードを変更できます。
            sushiOrderDBDataSet1注文情報TableAdapter = new UobeiKittin.SushiOrderDBDataSet1TableAdapters.注文情報TableAdapter();
            sushiOrderDBDataSet1注文情報TableAdapter.Fill(sushiOrderDBDataSet1.注文情報);
            注文情報ViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("注文情報ViewSource")));
            注文情報ViewSource.View.MoveCurrentToFirst();
                        
            //未の数を持ってくる
            miteikyou();

            //注文ボタンの表示
            for (int i = 0; i<miteikyou(); i++) {
                var drv = (DataRow)sushiOrderDBDataSet1.注文情報.Rows[mitegyou()[i]];
                if (drv[9].ToString() == statusmi && count == 0) {
                    Order1.Visibility = Visibility.Visible;
                    Order1.Content = drv[6] + drv[7].ToString();
                    count++;
                }
                else if (drv[9].ToString() == statusmi && count == 1) {
                    Order2.Visibility = Visibility.Visible;
                    Order2.Content = drv[6] + drv[7].ToString();
                    count++;
                } 
                else if (drv[9].ToString() == statusmi && count == 2) {
                    Order3.Visibility = Visibility.Visible;
                    Order3.Content = drv[6] + drv[7].ToString();
                    count++;
                }
                else if (drv[9].ToString() == statusmi && count == 3) {
                    Order4.Visibility = Visibility.Visible;
                    count++;
                }
                else if (drv[9].ToString() == statusmi && count == 4) {
                    Order5.Visibility = Visibility.Visible;
                    count++;
                }
                else if (drv[9].ToString() == statusmi && count == 5) {
                    Order6.Visibility = Visibility.Visible;
                    count++;
                }
                else if (drv[9].ToString() == statusmi && count == 6) {
                    Order7.Visibility = Visibility.Visible;
                    count++;
                }
                else if (drv[9].ToString() == statusmi && count == 7) {
                    Order8.Visibility = Visibility.Visible;
                    count++;
                }
                else if (drv[9].ToString() == statusmi && count == 8) {
                    Order9.Visibility = Visibility.Visible;
                    count++;
                }
                else if (drv[9].ToString() == statusmi && count == 9) {
                    Order10.Visibility = Visibility.Visible;
                    count++;
                }
                else if (drv[9].ToString() == statusmi && count == 10) {
                    Order11.Visibility = Visibility.Visible;
                    count++;
                } 
                else if (drv[9].ToString() == statusmi && count == 11) {
                    Order12.Visibility = Visibility.Visible;
                    count++;
                } 
                else if (drv[9].ToString() == statusmi && count == 12) {
                    Order13.Visibility = Visibility.Visible;
                    count++;
                } 
                else if (drv[9].ToString() == statusmi && count == 13) {
                    Order14.Visibility = Visibility.Visible;
                    count++;
                }
                else if (drv[9].ToString() == statusmi && count == 14) {
                    Order15.Visibility = Visibility.Visible;
                    count++;
                }
                
                
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

       


        //件数カウント
        private int miteikyou() {
            //未の数を持ってくる
            var num = sushiOrderDBDataSet1注文情報TableAdapter.ScalarQuery();
            //件数表示
            if(num == null) {
                countkensuu.Content =" 0件";
            } else {
                countkensuu.Content = num + " 件";
            }
            
            if(num != null ) {
                return num.Value;
            } else {
                return 0;
            }
           
        }

        
        //未提供の場所(行)を持ってくる。
        private int[] mitegyou() {
            var nums = sushiOrderDBDataSet1.注文情報.Where(x => x.Status.Contains("未")).Select(x => x.ID).ToArray();
            return nums;
        }
        

        //注文ボタン1つ目
        private void order_Click1(object sender, RoutedEventArgs e) {
            Order1.Visibility = Visibility.Hidden;
            var drv = (DataRow)sushiOrderDBDataSet1.注文情報.Rows[mitegyou()[0]];
            drv[9] = statustei;
            sushiOrderDBDataSet1注文情報TableAdapter.Update(sushiOrderDBDataSet1.注文情報);
            miteikyou();
            count = 0;
            //Window_Loaded(sender, e);
            
        }
        //注文ボタン2つ目
        private void order_Click2(object sender, RoutedEventArgs e) {
            Order2.Visibility = Visibility.Hidden;
            var drv = (DataRow)sushiOrderDBDataSet1.注文情報.Rows[mitegyou()[1]];
            drv[9] = statustei;
            sushiOrderDBDataSet1注文情報TableAdapter.Update(sushiOrderDBDataSet1.注文情報);
            miteikyou();
            count = 0;
            //Window_Loaded(sender, e);
        }

        private void order_Click3(object sender, RoutedEventArgs e) {
            Order3.Visibility = Visibility.Hidden;
            var drv = (DataRow)sushiOrderDBDataSet1.注文情報.Rows[mitegyou()[2]];
            drv[9] = statustei;
            sushiOrderDBDataSet1注文情報TableAdapter.Update(sushiOrderDBDataSet1.注文情報);
            miteikyou();
            count = 0;
            //Window_Loaded(sender, e);
        }
    }
}
