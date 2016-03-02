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
using Windows.UI.Xaml.Media.Imaging;
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
            var obj = App.Current as App;
            TextBlock temp = new TextBlock();
            temp.FontSize = 18;
            Image temp2 = new Image();
            BitmapImage bitmapImage = new BitmapImage();



            for (int i = 0; i <= obj.gameno; i++)
            {
                temp.Text = obj.gameno.ToString();
                game_no.Items.Add(temp);
                temp = new TextBlock(); temp.FontSize = 18;
                temp.Text = obj.score1[i].ToString();
                score1.Items.Add(temp);
                temp = new TextBlock(); temp.FontSize = 18;
                temp.Text = obj.score2[i].ToString();
                score2.Items.Add(temp);
                temp = new TextBlock(); temp.FontSize = 18;
                temp.Text = obj.score3[i].ToString();
                score3.Items.Add(temp);
                temp = new TextBlock(); temp.FontSize = 18;
                temp.Text = obj.score4[i].ToString();
                score4.Items.Add(temp);
                temp = new TextBlock(); temp.FontSize = 18;
                temp.Text = obj.call1[i].ToString();
                call1.Items.Add(temp);
                temp = new TextBlock(); temp.FontSize = 18;
                temp.Text = obj.call2[i].ToString();
                call2.Items.Add(temp);
                temp = new TextBlock(); temp.FontSize = 18;
                temp.Text = obj.call3[i].ToString();
                call3.Items.Add(temp);
                temp = new TextBlock(); temp.FontSize = 18;
                temp.Text = obj.call4[i].ToString();
                call4.Items.Add(temp);







            }


        }
       

       

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        private void listBox_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
           
        }
    }


   
         
}
