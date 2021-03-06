﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// orderlist.xaml の相互作用ロジック
    /// </summary>
    /// 



    public partial class orderlist : Page {
        public orderlist() {
            InitializeComponent();
        }

        

        UobeiKittin.SushiOrderDBDataSet1 sushiOrderDBDataSet1;
       UobeiKittin.SushiOrderDBDataSet1TableAdapters.注文情報TableAdapter sushiOrderDBDataSet1注文情報TableAdapter;
        System.Windows.Data.CollectionViewSource 注文情報ViewSource;

        #region　ページ移動

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

        //Topページに移動
        private void Close_Click(object sender, RoutedEventArgs e) {
            Topseni(sender, e);
        }
        
        //Topページに移動
        private void MenuItem_Click(object sender, RoutedEventArgs e) {
            Topseni(sender, e);
        }

        //Topページの遷移
        public void Topseni(object sender, RoutedEventArgs e) {
            var toppage = new Top();
            NavigationService.Navigate(toppage);
        }

        //終了ボタン
        private void Closes_Click(object sender, RoutedEventArgs e) {

            Application.Current.Shutdown();
        }

        //閉じるボタン
        private void Top_page(object sender, RoutedEventArgs e) {
            Topseni(sender, e);
        }


        #endregion

        //データベース
        private void Window_Load(object sender, RoutedEventArgs e) {
           sushiOrderDBDataSet1 = ((UobeiKittin.SushiOrderDBDataSet1)(this.FindResource("sushiOrderDBDataSet1")));
           // テーブル 注文情報 にデータを読み込みます。必要に応じてこのコードを変更できます。
           sushiOrderDBDataSet1注文情報TableAdapter = new UobeiKittin.SushiOrderDBDataSet1TableAdapters.注文情報TableAdapter();
           sushiOrderDBDataSet1注文情報TableAdapter.teikyouzumi(sushiOrderDBDataSet1.注文情報);
           注文情報ViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("注文情報ViewSource")));
           注文情報ViewSource.View.MoveCurrentToFirst();

            //var drv = (DataRow)sushiOrderDBDataSet1.注文情報.Count();

        }
        

        //マイナスオーダーボタン
        private void Mainasu_Click(object sender, RoutedEventArgs e) {
            
            //選択している行データを取得
            DataRowView drv = (DataRowView)注文情報ViewSource.View.CurrentItem;
           

            int count = int.Parse(drv[7].ToString());

            if(count != 0) {
                count--;
            }

            drv[7] = count;

            if(count == 0) {
                drv[8] = 0;
                drv[9] = "-";
            } else {
                drv[8] = (int.Parse(drv[8].ToString()) / ++count) * --count;
            }

            
            touroku.IsEnabled = true;
            
            
        }

        //登録ボタン
        private void Touroku_Click(object sender, RoutedEventArgs e) {
            sushiOrderDBDataSet1注文情報TableAdapter.Update(sushiOrderDBDataSet1.注文情報);
            touroku.IsEnabled = false;
        }

        
    }
}
