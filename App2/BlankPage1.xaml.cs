using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace App2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BlankPage1 : Page
    {
        public BlankPage1()
        {
            this.InitializeComponent();
        }
       


        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }
       

        private void listView1_Loaded(object sender, RoutedEventArgs e)
        {
            var obj = App.Current as App;
            TextBlock l1 = new TextBlock();
            l1.Text = (obj.score1[0].ToString().Length.ToString());
            l1.FontSize = 26;
            gridView.Items.Add(l1);
            gridView.Items.Add("hhh");
            gridView.Items.Add("hhh");
            gridView.Items.Add("hhh");
           
           

                   
            for (int i = 1; i <= obj.gameno; i++)
            {
                listView1.Items.Add(obj.score1[i]);
                listView2.Items.Add(obj.score2[i]);
                listView3.Items.Add(obj.score3[i]);
                listView4.Items.Add(obj.shape[i]);

            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }
    }


   
         
}
