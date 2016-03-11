using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace EstimationCalculator
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
            TextBlock temp;

            name1.Text = obj.name1;
            name2.Text = obj.name2;
            name3.Text = obj.name3;
            name4.Text = obj.name4;
            for (int i = 1; i <= obj.gameno; i++)
            {
                temp = new TextBlock();
                temp.FontSize = 18;
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
                temp = new TextBlock(); temp.FontSize = 18;
                temp.Text = obj.lammat1[i].ToString();
                lammat1.Items.Add(temp);
                temp = new TextBlock(); temp.FontSize = 18;
                temp.Text = obj.lammat2[i].ToString();
                lammat2.Items.Add(temp);
                temp = new TextBlock(); temp.FontSize = 18;
                temp.Text = obj.lammat3[i].ToString();
                lammat3.Items.Add(temp);
                temp = new TextBlock(); temp.FontSize = 18;
                temp.Text = obj.lammat4[i].ToString();
                lammat4.Items.Add(temp);
                if(obj.shape[i]==0)
                {
                    temp = new TextBlock(); temp.FontSize = 18;
                    temp.Text = "☼";
                }
                if (obj.shape[i] == 1)
                {
                    temp = new TextBlock(); temp.FontSize = 18;
                    temp.Text = "♠";
                }
                if (obj.shape[i] == 2)
                {
                    temp = new TextBlock(); temp.FontSize = 18;
                    temp.Text = "♥";
                }
                if (obj.shape[i] == 3)
                {
                    temp = new TextBlock(); temp.FontSize = 18;
                    temp.Text = "♦";
                }
                if (obj.shape[i] == 4)
                {
                    temp = new TextBlock(); temp.FontSize = 18;
                    temp.Text = "♣";
                }
                shape.Items.Add(temp);               

            }
        }      
       
        private void button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainMenu));
        }
        private const string Jsonfile = "estimationsa.json";
        private async void button1_Click(object sender, RoutedEventArgs e)
        {
            var obj = App.Current as App;

            


                bool p1added = false;
                bool p2added = false;
                bool p3added = false;
                bool p4added = false;
                List<int> sort = new List<int>();
                sort.Add(obj.score1[obj.gameno]);
                sort.Add(obj.score2[obj.gameno]);
                sort.Add(obj.score3[obj.gameno]);
                sort.Add(obj.score4[obj.gameno]);
                sort.Sort();
                List<Player_history> plhilist = await gethistorylist();
            


                foreach (Player_history plhi in plhilist)
                {

                    if (plhi.name.Equals(name1.Text, StringComparison.OrdinalIgnoreCase))
                    {
                        if (sort.IndexOf(obj.score1[obj.gameno]) == 0)
                            plhi.King = plhi.King + 1;
                        if (sort.IndexOf(obj.score1[obj.gameno]) == 1)
                            plhi.subking = plhi.subking + 1;
                        if (sort.IndexOf(obj.score1[obj.gameno]) == 2)
                            plhi.subkooz = plhi.subkooz + 1;
                        if (sort.IndexOf(obj.score1[obj.gameno]) == 3)
                            plhi.kooz = plhi.kooz + 1;
                        p1added = true;
                    }
                    if (plhi.name.Equals(name2.Text, StringComparison.OrdinalIgnoreCase))
                    {
                        if (sort.IndexOf(obj.score2[obj.gameno]) == 0)
                            plhi.King = plhi.King + 1;
                        if (sort.IndexOf(obj.score2[obj.gameno]) == 1)
                            plhi.subking = plhi.subking + 1;
                        if (sort.IndexOf(obj.score2[obj.gameno]) == 2)
                            plhi.subkooz = plhi.subkooz + 1;
                        if (sort.IndexOf(obj.score2[obj.gameno]) == 3)
                            plhi.kooz = plhi.kooz + 1;
                        p2added = true;
                    }
                    if (plhi.name.Equals(name3.Text, StringComparison.OrdinalIgnoreCase))
                    {
                        if (sort.IndexOf(obj.score3[obj.gameno]) == 0)
                            plhi.King = plhi.King + 1;
                        if (sort.IndexOf(obj.score3[obj.gameno]) == 1)
                            plhi.subking = plhi.subking + 1;
                        if (sort.IndexOf(obj.score3[obj.gameno]) == 2)
                            plhi.subkooz = plhi.subkooz + 1;
                        if (sort.IndexOf(obj.score3[obj.gameno]) == 3)
                            plhi.kooz = plhi.kooz + 1;
                        p3added = true;
                    }
                    if (plhi.name.Equals(name4.Text, StringComparison.OrdinalIgnoreCase))
                    {
                        if (sort.IndexOf(obj.score4[obj.gameno]) == 0)
                            plhi.King = plhi.King + 1;
                        if (sort.IndexOf(obj.score4[obj.gameno]) == 1)
                            plhi.subking = plhi.subking + 1;
                        if (sort.IndexOf(obj.score4[obj.gameno]) == 2)
                            plhi.subkooz = plhi.subkooz + 1;
                        if (sort.IndexOf(obj.score4[obj.gameno]) == 3)
                            plhi.kooz = plhi.kooz + 1;
                        p4added = true;
                    }



                }
                if (!p1added)
                {
                    if (sort.IndexOf(obj.score1[obj.gameno]) == 0)
                        plhilist.Add(new Player_history(name1.Text, 1, 0, 0, 0));
                    if (sort.IndexOf(obj.score1[obj.gameno]) == 1)
                        plhilist.Add(new Player_history(name1.Text, 0, 1, 0, 0));
                    if (sort.IndexOf(obj.score1[obj.gameno]) == 2)
                        plhilist.Add(new Player_history(name1.Text, 0, 0, 1, 0));
                    if (sort.IndexOf(obj.score1[obj.gameno]) == 3)
                        plhilist.Add(new Player_history(name1.Text, 0, 0, 0, 1));
                }
                if (!p2added)
                {
                    if (sort.IndexOf(obj.score2[obj.gameno]) == 0)
                        plhilist.Add(new Player_history(name2.Text, 1, 0, 0, 0));
                    if (sort.IndexOf(obj.score2[obj.gameno]) == 1)
                        plhilist.Add(new Player_history(name2.Text, 0, 1, 0, 0));
                    if (sort.IndexOf(obj.score2[obj.gameno]) == 2)
                        plhilist.Add(new Player_history(name2.Text, 0, 0, 1, 0));
                    if (sort.IndexOf(obj.score2[obj.gameno]) == 3)
                        plhilist.Add(new Player_history(name2.Text, 0, 0, 0, 1));
                }
                if (!p3added)
                {
                    if (sort.IndexOf(obj.score3[obj.gameno]) == 0)
                        plhilist.Add(new Player_history(name3.Text, 1, 0, 0, 0));
                    if (sort.IndexOf(obj.score3[obj.gameno]) == 1)
                        plhilist.Add(new Player_history(name3.Text, 0, 1, 0, 0));
                    if (sort.IndexOf(obj.score3[obj.gameno]) == 2)
                        plhilist.Add(new Player_history(name3.Text, 0, 0, 1, 0));
                    if (sort.IndexOf(obj.score3[obj.gameno]) == 3)
                        plhilist.Add(new Player_history(name3.Text, 0, 0, 0, 1));
                }
                if (!p4added)
                {
                    if (sort.IndexOf(obj.score4[obj.gameno]) == 0)
                        plhilist.Add(new Player_history(name4.Text, 1, 0, 0, 0));
                    if (sort.IndexOf(obj.score4[obj.gameno]) == 1)
                        plhilist.Add(new Player_history(name4.Text, 0, 1, 0, 0));
                    if (sort.IndexOf(obj.score4[obj.gameno]) == 2)
                        plhilist.Add(new Player_history(name4.Text, 0, 0, 1, 0));
                    if (sort.IndexOf(obj.score4[obj.gameno]) == 3)
                        plhilist.Add(new Player_history(name4.Text, 0, 0, 0, 1));
                }
            try {
                await savehistorylist(plhilist);
            }
            catch(UnauthorizedAccessException)
            {
                MessageDialog error = new MessageDialog("UnauthorizedAccess for saving a file");
                    await error.ShowAsync();
            }
        }
        private async Task savehistorylist(List<Player_history> plhilist)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<Player_history>));

            using (var stream = await ApplicationData.Current.LocalFolder.OpenStreamForWriteAsync(Jsonfile, CreationCollisionOption.ReplaceExisting))
            {
                serializer.WriteObject(stream, plhilist);

            }
            Frame.Navigate(typeof(MainMenu));

        }
        private async Task<List<Player_history>> gethistorylist()
        {
            await ApplicationData.Current.LocalFolder.CreateFileAsync(Jsonfile, CreationCollisionOption.OpenIfExists);
            var stream = await ApplicationData.Current.LocalFolder.OpenStreamForReadAsync(Jsonfile);
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<Player_history>));
            List<Player_history> plhi = (List<Player_history>)serializer.ReadObject(stream);
            return plhi == null ? new List<Player_history>() : plhi;
        }

        private void image_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            if (Frame.CanGoBack)
                Frame.GoBack();
        }
    }


   
         
}
