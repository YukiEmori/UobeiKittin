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
using System.Windows.Threading;
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
                                    
            BtVisibility(sender, e);
            BtNameQuantitl(sender, e);
            count = 0;
            Timers(sender, e);
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
            if (num == null) {
                countkensuu.Content = " 0件";
            } else {
                countkensuu.Content = num + " 件";
            }

            if (num != null) {
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

        //ボタン表示と名前と数量反映
        private void BtNameQuantitl(object sender, RoutedEventArgs e) {
            for (int i = 0; i < miteikyou(); i++) {
                var drv = (DataRow)sushiOrderDBDataSet1.注文情報.Rows[mitegyou()[i]];
                if (drv[9].ToString() == statusmi && count == 0) {
                    Order1.Visibility = Visibility.Visible;
                    Order1.Content = " " + drv[6] + "\n\n数量："+drv[7].ToString();
                    count++;
                } else if (drv[9].ToString() == statusmi && count == 1) {
                    Order2.Visibility = Visibility.Visible;
                    Order2.Content = " " + drv[6] + "\n\n数量：" + drv[7].ToString();
                    count++;
                } else if (drv[9].ToString() == statusmi && count == 2) {
                    Order3.Visibility = Visibility.Visible;
                    Order3.Content = " " + drv[6] + "\n\n数量：" + drv[7].ToString();
                    count++;
                } else if (drv[9].ToString() == statusmi && count == 3) {
                    Order4.Visibility = Visibility.Visible;
                    Order4.Content = " " + drv[6] + "\n\n数量：" + drv[7].ToString();
                    count++;
                } else if (drv[9].ToString() == statusmi && count == 4) {
                    Order5.Visibility = Visibility.Visible;
                    Order5.Content = " " + drv[6] + "\n\n数量：" + drv[7].ToString();
                    count++;
                } else if (drv[9].ToString() == statusmi && count == 5) {
                    Order6.Visibility = Visibility.Visible;
                    Order6.Content = " " + drv[6] + "\n\n数量：" + drv[7].ToString();
                    count++;
                } else if (drv[9].ToString() == statusmi && count == 6) {
                    Order7.Visibility = Visibility.Visible;
                    Order7.Content = " " + drv[6] + "\n\n数量：" + drv[7].ToString();
                    count++;
                } else if (drv[9].ToString() == statusmi && count == 7) {
                    Order8.Visibility = Visibility.Visible;
                    Order8.Content = " " + drv[6] + "\n\n数量：" + drv[7].ToString();
                    count++;
                } else if (drv[9].ToString() == statusmi && count == 8) {
                    Order9.Visibility = Visibility.Visible;
                    Order9.Content = " " + drv[6] + "\n\n数量：" + drv[7].ToString();
                    count++;
                } else if (drv[9].ToString() == statusmi && count == 9) {
                    Order10.Visibility = Visibility.Visible;
                    Order10.Content = " " + drv[6] + "\n\n数量：" + drv[7].ToString();
                    count++;
                } else if (drv[9].ToString() == statusmi && count == 10) {
                    Order11.Visibility = Visibility.Visible;
                    Order11.Content = " " + drv[6] + "\n\n数量：" + drv[7].ToString();
                    count++;
                } else if (drv[9].ToString() == statusmi && count == 11) {
                    Order12.Visibility = Visibility.Visible;
                    Order12.Content = " " + drv[6] + "\n\n数量：" + drv[7].ToString();
                    count++;
                } else if (drv[9].ToString() == statusmi && count == 12) {
                    Order13.Visibility = Visibility.Visible;
                    Order13.Content = " " + drv[6] + "\n\n数量：" + drv[7].ToString();
                    count++;
                } else if (drv[9].ToString() == statusmi && count == 13) {
                    Order14.Visibility = Visibility.Visible;
                    Order14.Content = " " + drv[6] + "\n\n数量：" + drv[7].ToString();
                    count++;
                } else if (drv[9].ToString() == statusmi && count == 14) {
                    Order15.Visibility = Visibility.Visible;
                    Order15.Content = " " + drv[6] + "\n\n数量：" + drv[7].ToString();
                    count++;
                }
            }
        }

        #region　注文された商品が押された時の動作
        //注文ボタン1つ目
        private void order_Click1(object sender, RoutedEventArgs e) {
            Order1.Visibility = Visibility.Hidden;
            var drv = (DataRow)sushiOrderDBDataSet1.注文情報.Rows[mitegyou()[0]];
            drv[9] = statustei;
            sushiOrderDBDataSet1注文情報TableAdapter.Update(sushiOrderDBDataSet1.注文情報);
            count = 0;
            
            
        }

        //注文ボタン2つ目
        private void order_Click2(object sender, RoutedEventArgs e) {
            Order2.Visibility = Visibility.Hidden;
            var drv = (DataRow)sushiOrderDBDataSet1.注文情報.Rows[mitegyou()[1]];
            drv[9] = statustei;
            sushiOrderDBDataSet1注文情報TableAdapter.Update(sushiOrderDBDataSet1.注文情報);
            count = 0;

        }

        //注文ボタン3つ目
        private void order_Click3(object sender, RoutedEventArgs e) {
            Order3.Visibility = Visibility.Hidden;
            var drv = (DataRow)sushiOrderDBDataSet1.注文情報.Rows[mitegyou()[2]];
            drv[9] = statustei;
            sushiOrderDBDataSet1注文情報TableAdapter.Update(sushiOrderDBDataSet1.注文情報);
            count = 0;
        }

        //注文ボタン4つ目
        private void order_Click4(object sender, RoutedEventArgs e) {
            Order4.Visibility = Visibility.Hidden;
            var drv = (DataRow)sushiOrderDBDataSet1.注文情報.Rows[mitegyou()[3]];
            drv[9] = statustei;
            sushiOrderDBDataSet1注文情報TableAdapter.Update(sushiOrderDBDataSet1.注文情報);
            count = 0;
        }

        //注文ボタン5つ目
        private void order_Click5(object sender, RoutedEventArgs e) {
            Order5.Visibility = Visibility.Hidden;
            var drv = (DataRow)sushiOrderDBDataSet1.注文情報.Rows[mitegyou()[4]];
            drv[9] = statustei;
            sushiOrderDBDataSet1注文情報TableAdapter.Update(sushiOrderDBDataSet1.注文情報);
            count = 0;
        }
        //注文ボタン6つ目
        private void order_Click6(object sender, RoutedEventArgs e) {
            Order6.Visibility = Visibility.Hidden;
            var drv = (DataRow)sushiOrderDBDataSet1.注文情報.Rows[mitegyou()[5]];
            drv[9] = statustei;
            sushiOrderDBDataSet1注文情報TableAdapter.Update(sushiOrderDBDataSet1.注文情報);
            count = 0;
        }
        //注文ボタン7つ目
        private void order_Click7(object sender, RoutedEventArgs e) {
            Order7.Visibility = Visibility.Hidden;
            var drv = (DataRow)sushiOrderDBDataSet1.注文情報.Rows[mitegyou()[6]];
            drv[9] = statustei;
            sushiOrderDBDataSet1注文情報TableAdapter.Update(sushiOrderDBDataSet1.注文情報);
            count = 0;
        }
        //注文ボタン8つ目
        private void order_Click8(object sender, RoutedEventArgs e) {
            Order8.Visibility = Visibility.Hidden;
            var drv = (DataRow)sushiOrderDBDataSet1.注文情報.Rows[mitegyou()[7]];
            drv[9] = statustei;
            sushiOrderDBDataSet1注文情報TableAdapter.Update(sushiOrderDBDataSet1.注文情報);
            count = 0;
        }
        //注文ボタン9つ目
        private void order_Click9(object sender, RoutedEventArgs e) {
            Order9.Visibility = Visibility.Hidden;
            var drv = (DataRow)sushiOrderDBDataSet1.注文情報.Rows[mitegyou()[8]];
            drv[9] = statustei;
            sushiOrderDBDataSet1注文情報TableAdapter.Update(sushiOrderDBDataSet1.注文情報);
            count = 0;
        }
        //注文ボタン10つ目
        private void order_Click10(object sender, RoutedEventArgs e) {
            Order10.Visibility = Visibility.Hidden;
            var drv = (DataRow)sushiOrderDBDataSet1.注文情報.Rows[mitegyou()[9]];
            drv[9] = statustei;
            sushiOrderDBDataSet1注文情報TableAdapter.Update(sushiOrderDBDataSet1.注文情報);
            count = 0;
        }
        //注文ボタン11つ目
        private void order_Click11(object sender, RoutedEventArgs e) {
            Order11.Visibility = Visibility.Hidden;
            var drv = (DataRow)sushiOrderDBDataSet1.注文情報.Rows[mitegyou()[10]];
            drv[9] = statustei;
            sushiOrderDBDataSet1注文情報TableAdapter.Update(sushiOrderDBDataSet1.注文情報);
            count = 0;
        }
        //注文ボタン12つ目
        private void order_Click12(object sender, RoutedEventArgs e) {
            Order12.Visibility = Visibility.Hidden;
            var drv = (DataRow)sushiOrderDBDataSet1.注文情報.Rows[mitegyou()[11]];
            drv[9] = statustei;
            sushiOrderDBDataSet1注文情報TableAdapter.Update(sushiOrderDBDataSet1.注文情報);
            count = 0;
        }
        //注文ボタン13つ目
        private void order_Click13(object sender, RoutedEventArgs e) {
            Order13.Visibility = Visibility.Hidden;
            var drv = (DataRow)sushiOrderDBDataSet1.注文情報.Rows[mitegyou()[12]];
            drv[9] = statustei;
            sushiOrderDBDataSet1注文情報TableAdapter.Update(sushiOrderDBDataSet1.注文情報);
            count = 0;
        }
        //注文ボタン14つ目
        private void order_Click14(object sender, RoutedEventArgs e) {
            Order14.Visibility = Visibility.Hidden;
            var drv = (DataRow)sushiOrderDBDataSet1.注文情報.Rows[mitegyou()[13]];
            drv[9] = statustei;
            sushiOrderDBDataSet1注文情報TableAdapter.Update(sushiOrderDBDataSet1.注文情報);
            count = 0;
        }
        //注文ボタン15つ目
        private void order_Click15(object sender, RoutedEventArgs e) {
            Order15.Visibility = Visibility.Hidden;
            var drv = (DataRow)sushiOrderDBDataSet1.注文情報.Rows[mitegyou()[14]];
            drv[9] = statustei;
            sushiOrderDBDataSet1注文情報TableAdapter.Update(sushiOrderDBDataSet1.注文情報);
            count = 0;
        }


        #endregion


        //ボタン非表示設定
        private void BtVisibility(object sender, RoutedEventArgs e) {
            if (miteikyou() < 1) {
                Order1.Visibility = Visibility.Hidden;
            } 
            if (miteikyou() < 2) {
                Order2.Visibility = Visibility.Hidden;
            } 
            if (miteikyou() < 3) {
                Order3.Visibility = Visibility.Hidden;
            }  
            if (miteikyou() < 4) {
                Order4.Visibility = Visibility.Hidden;
            }
            if (miteikyou() < 5) {
                Order5.Visibility = Visibility.Hidden;
            }
            if (miteikyou() < 6) {
                Order6.Visibility = Visibility.Hidden;
            }
            if (miteikyou() < 7) {
                Order7.Visibility = Visibility.Hidden;
            }
            if (miteikyou() < 8) {
                Order8.Visibility = Visibility.Hidden;
            }
            if (miteikyou() < 9) {
                Order9.Visibility = Visibility.Hidden;
            }
            if (miteikyou() < 10) {
                Order10.Visibility = Visibility.Hidden;
            }
            if (miteikyou() < 11) {
                Order11.Visibility = Visibility.Hidden;
            }
            if (miteikyou() < 12) {
                Order12.Visibility = Visibility.Hidden;
            }
            if (miteikyou() < 13) {
                Order13.Visibility = Visibility.Hidden;
            }
            if (miteikyou() < 14) {
                Order14.Visibility = Visibility.Hidden;
            }
            if (miteikyou() < 15) {
                Order15.Visibility = Visibility.Hidden;
            }
        }

        //タイマー更新
        private void Timers(object sender, RoutedEventArgs e) {
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            //  タイマーイベント
            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            //1秒間隔に設定
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0,1 );
            dispatcherTimer.Start();
        }

        //ここが一定時間ごとに実行される
        private void dispatcherTimer_Tick(object sender, EventArgs e) {
            sushiOrderDBDataSet1 = ((UobeiKittin.SushiOrderDBDataSet1)(this.FindResource("sushiOrderDBDataSet1")));
            // テーブル 注文情報 にデータを読み込みます。必要に応じてこのコードを変更できます。
            sushiOrderDBDataSet1注文情報TableAdapter = new UobeiKittin.SushiOrderDBDataSet1TableAdapters.注文情報TableAdapter();
            sushiOrderDBDataSet1注文情報TableAdapter.Fill(sushiOrderDBDataSet1.注文情報);
            注文情報ViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("注文情報ViewSource")));
            注文情報ViewSource.View.MoveCurrentToFirst();

            BtVisibility(sender, e as RoutedEventArgs);
            BtNameQuantitl(sender, e as RoutedEventArgs);
            count = 0;
        }

        //後で消す
        private void syokika(object sender, RoutedEventArgs e) {
            for (int i = 0; i < 21; i++) {
                var drv = (DataRow)sushiOrderDBDataSet1.注文情報.Rows[i];
                drv[9] = "未";
                sushiOrderDBDataSet1注文情報TableAdapter.Update(sushiOrderDBDataSet1.注文情報);
            }
        }

        
    }
}