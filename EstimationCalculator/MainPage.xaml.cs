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
using Windows.UI.Popups;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace EstimationCalculator
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            scorei1[0] = 0;
            scorei2[0] = 0;
            scorei3[0] = 0;
            scorei4[0] = 0;
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;

        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.


            var obj = App.Current as App;

                obj.started = true;
        }
        
        private int i;
        private int gameno;
        private int[] scorei1 = new int[20];
        private int[] scorei2 = new int[20];
        private int[] scorei3 = new int[20];
        private int[] scorei4 = new int[20];
        private int[] calli1 = new int[20];
        private int[] calli2 = new int[20];
        private int[] calli3 = new int[20];
        private int[] calli4 = new int[20];
        private int[] lammati1 = new int[20];
        private int[] lammati2 = new int[20];
        private int[] lammati3 = new int[20];
        private int[] lammati4 = new int[20];
        private int gamestate;
        private Majorcal mc;
        private bool sa3ayda2=false;
        private bool dashcall1 = false;
        private bool dashcall2 = false;
        private bool dashcall3 = false;
        private bool dashcall4 = false;
        private bool iscall1 = true;
        private bool namesadded = false;
        BlankPage1 p = new BlankPage1();
        private int sa3ayda = 1;
        bool sa3ydaholder = false;
        private bool sa3ayda3=false;
        private void button_Click(object sender, RoutedEventArgs e)
        {
            i++;
            if (i == 1)
            {
                if (textBox.Text.Equals(""))
                {
                    i--;
                }
                else {
                    name1.Text = textBox.Text;
                    textBox.Text = "";
                }

            }
            if (i == 2)
            {
                if (textBox.Text.Equals(""))
                {
                    i--;
                }
                else {
                    name2.Text = textBox.Text;
                    textBox.Text = "";


                }
            }
            if (i == 3)
            {
                if (textBox.Text.Equals(""))
                {
                    i--;
                }
                else {
                    name3.Text = textBox.Text;
                    textBox.Text = "";


                }
            }
            if (i == 4)
            {
                if (textBox.Text.Equals(""))
                {
                    i--;
                }
                else {
                    name4.Text = textBox.Text;
                    textBox.Text = "";
                }


            }
            if (i >= 4)
            {
                namesadded = true;
                i = 0;
                addname.Visibility = Visibility.Collapsed;
                textBox.Visibility = Visibility.Collapsed;
                gamenumber.Visibility = Visibility.Visible;
                gamenumber.Text = "Games played=" + gameno.ToString();
            }
        }

        private async void button2_Click(object sender, RoutedEventArgs e)
        {
            if (namesadded)
            { var obj = App.Current as App;
                
                i++;
                if (i % 2 == 0)
                {
                    if (lammat1.Text == "Lammat")
                    {
                        i--; MessageDialog msgbox = new MessageDialog("you didn't enter a lammat for player 1");//,,,,,,,,,,,,,//
                        await msgbox.ShowAsync();
                        return;
                    }
                    if (lammat2.Text == "Lammat")
                    {
                        i--; MessageDialog msgbox = new MessageDialog("you didn't enter a lammat for player 2");//,,,,,,,,,,,,,//
                        await msgbox.ShowAsync();
                        return;
                    }
                    if (lammat3.Text == "Lammat")
                    {
                        i--; MessageDialog msgbox = new MessageDialog("you didn't enter a lammat for player 3");//,,,,,,,,,,,,,//
                        await msgbox.ShowAsync();
                        return;
                    }
                    if (lammat4.Text == "Lammat")
                    {
                        i--;
                        MessageDialog msgbox = new MessageDialog("you didn't enter a lammat for player 4");
                        await msgbox.ShowAsync();
                        return;
                    }
                    gameno++;
                    if (call1.Text == "DC")
                    {
                        dashcall1 = true;
                        call1.Text = "0";
                    }
                    else dashcall1 = false;
                    if (call2.Text == "DC")
                    { dashcall2 = true; call2.Text = "0"; }
                    else dashcall2 = false;
                    if (call3.Text == "DC")
                    { dashcall3 = true; call3.Text = "0"; }
                    else dashcall3 = false;
                    if (call4.Text == "DC")
                    { dashcall4 = true; call4.Text = "0"; }
                    else dashcall4 = false;
                    if (sa3ayda2)
                    {
                        sa3ayda3 = true;
                        mc = new Majorcal(int.Parse(call1.Text), int.Parse(lammat1.Text), dashcall1, int.Parse(call2.Text), int.Parse(lammat2.Text), dashcall2, int.Parse(call3.Text), int.Parse(lammat3.Text), dashcall3, int.Parse(call4.Text), int.Parse(lammat4.Text), dashcall4, gameno);
                        if (mc.isError())
                        {
                            MessageDialog msgbox = new MessageDialog("Lammat msh mazpota ");//,,,,,,,,,,,,,//
                            await msgbox.ShowAsync();
                          
                            i--;
                            sa3ayda2 = true;
                            return;
                        }
                       
                        sa3ayda2 = mc.isSa3ayda();
                      
                        mc.setiscall();
                        if (image_call1.Visibility == Visibility.Visible)
                        {
                            mc.iscall1 = true;
                            mc.iswith1 = false;
                            mc.iscall2 = false;
                            mc.iscall3 = false;
                            mc.iscall4 = false;
                        }
                        if (image_call2.Visibility == Visibility.Visible)
                        {
                            mc.iscall2 = true;
                            mc.iswith2 = false;
                            mc.iscall1 = false;
                            mc.iscall3 = false;
                            mc.iscall4 = false;
                        }
                        if (image_call3.Visibility == Visibility.Visible)
                        {
                            mc.iscall3 = true;
                            mc.iswith3 = false;
                            mc.iscall2 = false;
                            mc.iscall1 = false;
                            mc.iscall4 = false;
                        }
                        if (image_call4.Visibility == Visibility.Visible)
                        {
                            mc.iscall4 = true;
                            mc.iswith4 = false;
                            mc.iscall2 = false;
                            mc.iscall3 = false;
                            mc.iscall1 = false;
                        }
                        mc.setrisk();
                        mc.setonlywinner();
                       
                        gameno--;
                        scorei1[gameno - 1] = int.Parse(score1.Text);
                        scorei1[gameno] = mc.getscore1(scorei1[gameno - 1]);
                        scorei1[gameno] = scorei1[gameno] - scorei1[gameno - 1];
                        scorei1[gameno] = scorei1[gameno - 1] + (scorei1[gameno] * 2 ^ sa3ayda);
                        if (mc.isDoubled()&&obj.doubled)
                        {
                            scorei1[gameno] = scorei1[gameno] - scorei1[gameno - 1];
                            scorei1[gameno] = scorei1[gameno - 1] + (scorei1[gameno] * 2);
                        }
                        if (!mc.isSa3ayda())
                            score1.Text = scorei1[gameno].ToString();
                        scorei2[gameno - 1] = int.Parse(score2.Text);
                        scorei2[gameno] = mc.getscore2(scorei2[gameno - 1]);
                        scorei2[gameno] = scorei2[gameno] - scorei2[gameno - 1];
                        scorei2[gameno] = scorei2[gameno - 1] + (scorei2[gameno] * 2 ^ sa3ayda);
                        if (mc.isDoubled() && obj.doubled)
                        {
                            scorei2[gameno] = scorei2[gameno] - scorei2[gameno - 1];
                            scorei2[gameno] = scorei2[gameno - 1] + (scorei2[gameno] * 2);
                        }
                        if (!mc.isSa3ayda())
                            score2.Text = scorei2[gameno].ToString();
                        scorei3[gameno - 1] = int.Parse(score3.Text);
                        scorei3[gameno] = mc.getscore3(scorei3[gameno - 1]);
                        scorei3[gameno] = scorei3[gameno] - scorei3[gameno - 1];
                        scorei3[gameno] = scorei3[gameno - 1] + (scorei3[gameno] * 2 ^ sa3ayda);
                        if (mc.isDoubled() && obj.doubled)
                        {
                            scorei3[gameno] = scorei3[gameno] - scorei3[gameno - 1];
                            scorei3[gameno] = scorei3[gameno - 1] + (scorei3[gameno] * 2);
                        }
                        if (!mc.isSa3ayda())
                            score3.Text = scorei3[gameno].ToString();
                        scorei4[gameno - 1] = int.Parse(score4.Text);
                        scorei4[gameno] = mc.getscore4(scorei4[gameno - 1]);
                        scorei4[gameno] = scorei4[gameno] - scorei4[gameno - 1];
                        scorei4[gameno] = scorei4[gameno - 1] + (scorei4[gameno] * 2^ sa3ayda);
                        if (mc.isDoubled() && obj.doubled)
                        {
                            scorei4[gameno] = scorei4[gameno] - scorei4[gameno - 1];
                            scorei4[gameno] = scorei4[gameno - 1] + (scorei4[gameno] * 2);
                        }
                        if (!mc.isSa3ayda())
                            score4.Text = scorei4[gameno].ToString();
                        sa3ayda++;
                        sa3ydaholder = true;

                    }
                    mc = new Majorcal(int.Parse(call1.Text), int.Parse(lammat1.Text), dashcall1, int.Parse(call2.Text), int.Parse(lammat2.Text), dashcall2, int.Parse(call3.Text), int.Parse(lammat3.Text), dashcall3, int.Parse(call4.Text), int.Parse(lammat4.Text), dashcall4, gameno);
                    if (mc.isError())
                    {
                        MessageDialog msgbox = new MessageDialog("Lammat msh mazpota ");//,,,,,,,,,,,,,//
                        await msgbox.ShowAsync();
                        gameno--;
                        i--;
                        return;
                    }
                    mc.setiscall();
                    if (image_call1.Visibility == Visibility.Visible)
                    {
                        mc.iscall1 = true;
                        mc.iswith1 = false;
                        mc.iscall2 = false;
                        mc.iscall3 = false;
                        mc.iscall4 = false;
                    }
                    if (image_call2.Visibility == Visibility.Visible)
                    {
                        mc.iscall2 = true;
                        mc.iswith2 = false;
                        mc.iscall1 = false;
                        mc.iscall3 = false;
                        mc.iscall4 = false;
                    }
                    if (image_call3.Visibility == Visibility.Visible)
                    {
                        mc.iscall3 = true;
                        mc.iswith3 = false;
                        mc.iscall2 = false;
                        mc.iscall1 = false;
                        mc.iscall4 = false;
                    }
                    if (image_call4.Visibility == Visibility.Visible)
                    {
                        mc.iscall4 = true;
                        mc.iswith4 = false;
                        mc.iscall2 = false;
                        mc.iscall3 = false;
                        mc.iscall1 = false;
                    }
                    mc.setrisk();
                    mc.setonlywinner();
                    mc.gamestate = gamestate;
                    sa3ayda2 = mc.isSa3ayda();
                    if (!sa3ayda2 && !sa3ydaholder)
                    {
                        sa3ayda = 1;
                        scorei1[gameno - 1] = int.Parse(score1.Text);
                        scorei1[gameno] = mc.getscore1(scorei1[gameno - 1]);
                        if (mc.isDoubled() && obj.doubled)
                        {
                            scorei1[gameno] = scorei1[gameno] - scorei1[gameno - 1];
                            scorei1[gameno] = scorei1[gameno - 1] + (scorei1[gameno] * 2);
                        }
                        score1.Text = scorei1[gameno].ToString();
                        scorei2[gameno - 1] = int.Parse(score2.Text);
                        scorei2[gameno] = mc.getscore2(scorei2[gameno - 1]);
                        if (mc.isDoubled() && obj.doubled)
                        {
                            scorei2[gameno] = scorei2[gameno] - scorei2[gameno - 1];
                            scorei2[gameno] = scorei2[gameno - 1] + (scorei2[gameno] * 2);
                        }
                        score2.Text = scorei2[gameno].ToString();
                        scorei3[gameno - 1] = int.Parse(score3.Text);
                        scorei3[gameno] = mc.getscore3(scorei3[gameno - 1]);
                        if (mc.isDoubled() && obj.doubled)
                        {
                            scorei3[gameno] = scorei3[gameno] - scorei3[gameno - 1];
                            scorei3[gameno] = scorei3[gameno - 1] + (scorei3[gameno] * 2);
                        }
                        score3.Text = scorei3[gameno].ToString();
                        scorei4[gameno - 1] = int.Parse(score4.Text);
                        scorei4[gameno] = mc.getscore4(scorei4[gameno - 1]);
                        if (mc.isDoubled() && obj.doubled)
                        {
                            scorei4[gameno] = scorei4[gameno] - scorei4[gameno - 1];
                            scorei4[gameno] = scorei4[gameno - 1] + (scorei4[gameno] * 2);
                        }
                        score4.Text = scorei4[gameno].ToString();
                    }
                    button2.Content = "Start Round";
                    lammati1[gameno] = int.Parse(lammat1.Text);
                    lammati2[gameno] = int.Parse(lammat2.Text);
                    lammati3[gameno] = int.Parse(lammat3.Text);
                    lammati4[gameno] = int.Parse(lammat4.Text);
                    lammat1.Visibility = Visibility.Collapsed;
                    lammat2.Visibility = Visibility.Collapsed;
                    lammat3.Visibility = Visibility.Collapsed;
                    lammat4.Visibility = Visibility.Collapsed;
                    image_Lammat1.Visibility = Visibility.Collapsed;
                    image_Lammat2.Visibility = Visibility.Collapsed;
                    image_Lammat3.Visibility = Visibility.Collapsed;
                    image_Lammat4.Visibility = Visibility.Collapsed;
                    image_Call1.Visibility = Visibility.Visible;
                    image_Call2.Visibility = Visibility.Visible;
                    image_Call3.Visibility = Visibility.Visible;
                    image_Call4.Visibility = Visibility.Visible;
                    image_call1.Visibility = Visibility.Collapsed;
                    image_call2.Visibility = Visibility.Collapsed;
                    image_call3.Visibility = Visibility.Collapsed;
                    image_call4.Visibility = Visibility.Collapsed;
                    call1.Text = "Choose Call";
                    call2.Text = "Choose Call";
                    call3.Text = "Choose Call";
                    call4.Text = "Choose Call";
                    gamest.Visibility = Visibility.Collapsed;
                    gamenumber.Visibility = Visibility.Visible;
                    gamenumber.Text = "Games played=" + gameno.ToString();
                    sa3ydaholder = false;
                    if (dashcall1)
                        dashcall1 = false;
                    if (dashcall2)
                        dashcall2 = false;
                    if (dashcall3)
                        dashcall3 = false;
                    if (dashcall4)
                        dashcall4 = false;
                    iscall1 = true;
                }
                else
                {
                    if (call1.Text == "Choose Call")
                    {
                        i--; MessageDialog msgbox = new MessageDialog("you didn't enter a call for player 1");//,,,,,,,,,,,,,//
                        await msgbox.ShowAsync();
                        return;
                    }
                    if (call2.Text == "Choose Call")
                    {
                        i--; MessageDialog msgbox = new MessageDialog("you didn't enter a call for player 2");//,,,,,,,,,,,,,//
                        await msgbox.ShowAsync();
                        return;
                    }
                    if (call3.Text == "Choose Call")
                    {
                        i--; MessageDialog msgbox = new MessageDialog("you didn't enter a call for player 3");//,,,,,,,,,,,,,//
                        await msgbox.ShowAsync();
                        return;
                    }
                    if (call4.Text == "Choose Call")
                    {
                        i--;
                        MessageDialog msgbox = new MessageDialog("you didn't enter a call for player 4");
                        await msgbox.ShowAsync();
                        return;
                    }
                    if (call1.Text == "DC")
                    { calli1[gameno + 1] = 0; }
                    else
                        calli1[gameno + 1] = int.Parse(call1.Text);
                    if (call2.Text == "DC")
                    { calli2[gameno + 1] = 0; }
                    else
                        calli2[gameno + 1] = int.Parse(call2.Text);

                    if (call3.Text == "DC")
                    { calli3[gameno + 1] = 0; }
                    else
                        calli3[gameno + 1] = int.Parse(call3.Text);
                    if (call4.Text == "DC")
                    { calli4[gameno + 1] = 0; }
                    else
                        calli4[gameno + 1] = int.Parse(call4.Text);
                    gamestate = calli1[gameno + 1] + calli2[gameno + 1] + calli3[gameno + 1] + calli4[gameno + 1] - 13;
                    if (gamestate == 0)
                    {
                        i--;
                        MessageDialog msgbox = new MessageDialog("Sum of CAlls can't be equal 13");
                        await msgbox.ShowAsync();
                        return;
                    }
                    mc = new Majorcal(calli1[gameno + 1], calli2[gameno + 1], calli3[gameno + 1], calli4[gameno + 1]);
                    mc.setiscall();
                    if (mc.iscall2 && mc.iswith2 && flipView2.Visibility == Visibility.Collapsed)
                    {

                        if (!mc.iswith1)
                        {
                            wh_Call1.Visibility = Visibility.Collapsed;
                        }
                        else
                        { wh_Call1.Content = name1.Text; }
                        if (!mc.iswith3)
                        {
                            wh_Call3.Visibility = Visibility.Collapsed;
                        }
                        else
                        { wh_Call3.Content = name3.Text; }
                        if (!mc.iswith4)
                        {
                            wh_Call4.Visibility = Visibility.Collapsed;
                        }
                        else
                        { wh_Call4.Content = name4.Text; }

                        wh_Call2.Content = name2.Text;
                        wh_Call.Visibility = Visibility.Visible;



                    }
                    if (mc.iscall1 && mc.iswith1 && flipView.Visibility == Visibility.Collapsed)
                    {


                        if (!mc.iswith2)
                        {
                            wh_Call2.Visibility = Visibility.Collapsed;
                        }
                        else
                        { wh_Call2.Content = name2.Text; }
                        if (!mc.iswith3)
                        {
                            wh_Call3.Visibility = Visibility.Collapsed;
                        }
                        else
                        { wh_Call3.Content = name3.Text; }
                        if (!mc.iswith4)
                        {
                            wh_Call4.Visibility = Visibility.Collapsed;
                        }
                        else
                        { wh_Call4.Content = name4.Text; }

                        wh_Call1.Content = name1.Text;
                        wh_Call.Visibility = Visibility.Visible;

                    }
                    if (mc.iscall3 && mc.iswith3 && flipView3.Visibility == Visibility.Collapsed)
                    {

                        if (!mc.iswith1)
                        {
                            wh_Call1.Visibility = Visibility.Collapsed;
                        }
                        else
                        { wh_Call1.Content = name1.Text; }
                        if (!mc.iswith2)
                        {
                            wh_Call2.Visibility = Visibility.Collapsed;
                        }
                        else
                        { wh_Call2.Content = name2.Text; }
                        if (!mc.iswith4)
                        {
                            wh_Call4.Visibility = Visibility.Collapsed;
                        }
                        else
                        { wh_Call4.Content = name4.Text; }

                        wh_Call3.Content = name3.Text;
                        wh_Call.Visibility = Visibility.Visible;

                    }
                    if (mc.iscall4 && mc.iswith4 && flipView4.Visibility == Visibility.Collapsed)
                    {
                        if (!mc.iswith1)
                        {
                            wh_Call1.Visibility = Visibility.Collapsed;
                        }
                        else
                        { wh_Call1.Content = name1.Text; }
                        if (!mc.iswith3)
                        {
                            wh_Call3.Visibility = Visibility.Collapsed;
                        }
                        else
                        { wh_Call3.Content = name3.Text; }
                        if (!mc.iswith2)
                        {
                            wh_Call2.Visibility = Visibility.Collapsed;
                        }
                        else
                        { wh_Call2.Content = name2.Text; }

                        wh_Call4.Content = name4.Text;
                        wh_Call.Visibility = Visibility.Visible;


                    }
                    if (flipView.Visibility == Visibility.Visible)
                    {
                        image_call1.Visibility = Visibility.Visible;
                        shape[gameno + 1] = flipView.SelectedIndex;
                    }
                    if (flipView2.Visibility == Visibility.Visible)
                    {
                        image_call2.Visibility = Visibility.Visible;
                        shape[gameno + 1] = flipView.SelectedIndex;
                    }
                    if (flipView3.Visibility == Visibility.Visible)
                    {
                        image_call3.Visibility = Visibility.Visible;
                        shape[gameno + 1] = flipView.SelectedIndex;
                    }
                    if (flipView4.Visibility == Visibility.Visible)
                    {
                        image_call4.Visibility = Visibility.Visible;
                        shape[gameno + 1] = flipView.SelectedIndex;
                    }



                    button2.Content = "Calculate score";


                    lammat1.Visibility = Visibility.Visible;
                    lammat2.Visibility = Visibility.Visible;
                    lammat3.Visibility = Visibility.Visible;
                    lammat4.Visibility = Visibility.Visible;
                    image_Call1.Visibility = Visibility.Collapsed;
                    image_Call2.Visibility = Visibility.Collapsed;
                    image_Call3.Visibility = Visibility.Collapsed;
                    image_Call4.Visibility = Visibility.Collapsed;
                    image_Lammat1.Visibility = Visibility.Visible;
                    image_Lammat2.Visibility = Visibility.Visible;
                    image_Lammat3.Visibility = Visibility.Visible;
                    image_Lammat4.Visibility = Visibility.Visible;
                    lammat1.Text = "Lammat";
                    lammat2.Text = "Lammat";
                    lammat3.Text = "Lammat";
                    lammat4.Text = "Lammat";
                    gamest.Visibility = Visibility.Visible;
                    if (gamestate > 0)
                        gamest.Text = "Game is over    " + gamestate.ToString();
                    if (gamestate < 0)
                        gamest.Text = "Game is under   " + (gamestate * -1).ToString();

                    iscall1 = false;
                }
                listBox_1.Visibility = Visibility.Collapsed;
                listBox_2.Visibility = Visibility.Collapsed;
                listBox_3.Visibility = Visibility.Collapsed;
                listBox_4.Visibility = Visibility.Collapsed;
            }
            else
            {
                MessageDialog msgbox = new MessageDialog("you have to add 4 names");
                await msgbox.ShowAsync();
            }



        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (iscall1)
                call4.Text = "DC";
            else {
                lammat4.Text = "Dc";
            }
            listBox_4.Visibility = Visibility.Collapsed;
        }


        private void i2_Click(object sender, RoutedEventArgs e)
        {
            if (iscall1)
                call4.Text = "0";
            else
                lammat4.Text = "0";
            listBox_4.Visibility = Visibility.Collapsed;
        }

        private void i3_Click(object sender, RoutedEventArgs e)
        {
            if (iscall1)
                call4.Text = "1";
            else
                lammat4.Text = "1";
            listBox_4.Visibility = Visibility.Collapsed;
        }

        private void i4_Click(object sender, RoutedEventArgs e)
        {
            if (iscall1)
                call4.Text = "2";
            else
                lammat4.Text = "2";
            listBox_4.Visibility = Visibility.Collapsed;
        }

        private void i5_Click(object sender, RoutedEventArgs e)
        {
            if (iscall1)
                call4.Text = "3";
            else
                lammat4.Text = "3";
            listBox_4.Visibility = Visibility.Collapsed;
        }

        private void i6_Click(object sender, RoutedEventArgs e)
        {
            if (iscall1)
                call4.Text = "4";
            else
                lammat4.Text = "4";
            listBox_4.Visibility = Visibility.Collapsed;
        }

        private void i7_Click_1(object sender, RoutedEventArgs e)
        {
            if (iscall1)
                call4.Text = "5";
            else
                lammat4.Text = "5";
            listBox_4.Visibility = Visibility.Collapsed;
        }

        private void i8_Click(object sender, RoutedEventArgs e)
        {
            if (iscall1)
                call4.Text = "6";
            else
                lammat4.Text = "6";
            listBox_4.Visibility = Visibility.Collapsed;
        }

        private void i9_Click(object sender, RoutedEventArgs e)
        {
            if (iscall1)
                call4.Text = "7";
            else
                lammat4.Text = "7";
            listBox_4.Visibility = Visibility.Collapsed;
        }

        private void i10_Click(object sender, RoutedEventArgs e)
        {
            if (iscall1)
                call4.Text = "8";
            else
                lammat4.Text = "8";
            listBox_4.Visibility = Visibility.Collapsed;
        }

        private void i11_Click(object sender, RoutedEventArgs e)
        {
            if (iscall1)
                call4.Text = "9";
            else
                lammat4.Text = "9";
            listBox_4.Visibility = Visibility.Collapsed;
        }

        private void i12_Click(object sender, RoutedEventArgs e)
        {
            if (iscall1)
                call4.Text = "10";
            else
                lammat4.Text = "10";
            listBox_4.Visibility = Visibility.Collapsed;
        }

        private void i13_Click(object sender, RoutedEventArgs e)
        {
            if (iscall1)
                call4.Text = "11";
            else
                lammat4.Text = "11";
            listBox_4.Visibility = Visibility.Collapsed;

        }

        private void i14_Click(object sender, RoutedEventArgs e)
        {
            if (iscall1)
                call4.Text = "12";
            else
                lammat4.Text = "12";
            listBox_4.Visibility = Visibility.Collapsed;

        }

        private void i15_Click(object sender, RoutedEventArgs e)
        {
            if (iscall1)
                call4.Text = "13";
            else
                lammat4.Text = "13";
            listBox_4.Visibility = Visibility.Collapsed;

        }

        private void i16_Click(object sender, RoutedEventArgs e)
        {
            if (iscall1)
                call3.Text = "DC";

            else
                lammat3.Text = "DC";
            listBox_3.Visibility = Visibility.Collapsed;
        }

        private void i17_Click(object sender, RoutedEventArgs e)
        {
            if (iscall1)
                call3.Text = "0";
            else
                lammat3.Text = "0";
            listBox_3.Visibility = Visibility.Collapsed;

        }

        private void i18_Click(object sender, RoutedEventArgs e)
        {
            if (iscall1)
                call3.Text = "1";
            else
                lammat3.Text = "1";
            listBox_3.Visibility = Visibility.Collapsed;

        }

        private void i19_Click(object sender, RoutedEventArgs e)
        {
            if (iscall1)
                call3.Text = "2";
            else
                lammat3.Text = "2";
            listBox_3.Visibility = Visibility.Collapsed;

        }

        private void i20_Click(object sender, RoutedEventArgs e)
        {
            if (iscall1)
                call3.Text = "3";
            else
                lammat3.Text = "3";
            listBox_3.Visibility = Visibility.Collapsed;

        }

        private void i21_Click(object sender, RoutedEventArgs e)
        {
            if (iscall1)
                call3.Text = "4";
            else
                lammat3.Text = "4";
            listBox_3.Visibility = Visibility.Collapsed;

        }

        private void i22_Click(object sender, RoutedEventArgs e)
        {
            if (iscall1)
                call3.Text = "5";
            else
                lammat3.Text = "5";
            listBox_3.Visibility = Visibility.Collapsed;

        }

        private void i23_Click(object sender, RoutedEventArgs e)
        {
            if (iscall1)
                call3.Text = "6";
            else
                lammat3.Text = "6";
            listBox_3.Visibility = Visibility.Collapsed;

        }

        private void i24_Click(object sender, RoutedEventArgs e)
        {
            if (iscall1)
                call3.Text = "7";
            else
                lammat3.Text = "7";
            listBox_3.Visibility = Visibility.Collapsed;

        }

        private void i25_Click(object sender, RoutedEventArgs e)
        {
            if (iscall1)
                call3.Text = "8";
            else
                lammat3.Text = "8";
            listBox_3.Visibility = Visibility.Collapsed;

        }

        private void i26_Click(object sender, RoutedEventArgs e)
        {
            if (iscall1)
                call3.Text = "9";
            else
                lammat3.Text = "9";
            listBox_3.Visibility = Visibility.Collapsed;

        }


        private void i27_Click(object sender, RoutedEventArgs e)
        {
            if (iscall1)
                call3.Text = "10";
            else
                lammat3.Text = "10";
            listBox_3.Visibility = Visibility.Collapsed;

        }

        private void i28_Click(object sender, RoutedEventArgs e)
        {
            if (iscall1)
                call3.Text = "11";
            else
                lammat3.Text = "11";
            listBox_3.Visibility = Visibility.Collapsed;

        }

        private void i29_Click(object sender, RoutedEventArgs e)
        {
            if (iscall1)
                call3.Text = "12";
            else
                lammat3.Text = "12";
            listBox_3.Visibility = Visibility.Collapsed;

        }

        private void i30_Click(object sender, RoutedEventArgs e)
        {
            if (iscall1)
                call3.Text = "13";
            else
                lammat3.Text = "13";
            listBox_3.Visibility = Visibility.Collapsed;

        }

        private void i31_Click(object sender, RoutedEventArgs e)
        {
            if (iscall1)
                call2.Text = "DC";
            else
                lammat2.Text = "DC";
            listBox_2.Visibility = Visibility.Collapsed;

        }

        private void i32_Click(object sender, RoutedEventArgs e)
        {
            if (iscall1)
                call2.Text = "0";
            else
                lammat2.Text = "0";
            listBox_2.Visibility = Visibility.Collapsed;

        }

        private void i33_Click(object sender, RoutedEventArgs e)
        {
            if (iscall1)
                call2.Text = "1";
            else
                lammat2.Text = "1";
            listBox_2.Visibility = Visibility.Collapsed;

        }

        private void i34_Click(object sender, RoutedEventArgs e)
        {
            if (iscall1)
                call2.Text = "2";
            else
                lammat2.Text = "2";
            listBox_2.Visibility = Visibility.Collapsed;

        }

        private void i35_Click(object sender, RoutedEventArgs e)
        {
            if (iscall1)
                call2.Text = "3";
            else
                lammat2.Text = "3";
            listBox_2.Visibility = Visibility.Collapsed;

        }

        private void i36_Click(object sender, RoutedEventArgs e)
        {
            if (iscall1)
                call2.Text = "4";
            else
                lammat2.Text = "4";
            listBox_2.Visibility = Visibility.Collapsed;

        }

        private void i37_Click(object sender, RoutedEventArgs e)
        {
            if (iscall1)
                call2.Text = "5";
            else
                lammat2.Text = "5";
            listBox_2.Visibility = Visibility.Collapsed;

        }

        private void i38_Click(object sender, RoutedEventArgs e)
        {
            if (iscall1)
                call2.Text = "6";
            else
                lammat2.Text = "6";
            listBox_2.Visibility = Visibility.Collapsed;

        }

        private void i39_Click(object sender, RoutedEventArgs e)
        {
            if (iscall1)
                call2.Text = "7";
            else
                lammat2.Text = "7";
            listBox_2.Visibility = Visibility.Collapsed;

        }

        private void i40_Click(object sender, RoutedEventArgs e)
        {
            if (iscall1)
                call2.Text = "8";
            else
                lammat2.Text = "8";

            listBox_2.Visibility = Visibility.Collapsed;

        }

        private void i41_Click(object sender, RoutedEventArgs e)
        {
            if (iscall1)
                call2.Text = "9";
            else
                lammat2.Text = "9";
            listBox_2.Visibility = Visibility.Collapsed;

        }

        private void i42_Click(object sender, RoutedEventArgs e)
        {
            if (iscall1)
                call2.Text = "10";
            else
                lammat2.Text = "10";
            listBox_2.Visibility = Visibility.Collapsed;

        }

        private void i43_Click(object sender, RoutedEventArgs e)
        {
            if (iscall1)
                call2.Text = "11";
            else
                lammat2.Text = "11";
            listBox_2.Visibility = Visibility.Collapsed;

        }

        private void i44_Click(object sender, RoutedEventArgs e)
        {
            if (iscall1)
                call2.Text = "12";
            else
                lammat2.Text = "12";
            listBox_2.Visibility = Visibility.Collapsed;

        }

        private void i45_Click(object sender, RoutedEventArgs e)
        {
            if (iscall1)
                call2.Text = "13";
            else
                lammat2.Text = "13";
            listBox_2.Visibility = Visibility.Collapsed;


        }

        private void i46_Click(object sender, RoutedEventArgs e)
        {
            if (iscall1)
                call1.Text = "DC";
            else
                lammat1.Text = "DC";
            listBox_1.Visibility = Visibility.Collapsed;

        }

        private void i47_Click(object sender, RoutedEventArgs e)
        {
            if (iscall1)
                call1.Text = "0";
            else
                lammat1.Text = "0";
            listBox_1.Visibility = Visibility.Collapsed;

        }

        private void i48_Click(object sender, RoutedEventArgs e)
        {
            if (iscall1)
                call1.Text = "1";
            else
                lammat1.Text = "1";
            listBox_1.Visibility = Visibility.Collapsed;

        }

        private void i49_Click(object sender, RoutedEventArgs e)
        {
            if (iscall1)
                call1.Text = "2";
            else
                lammat1.Text = "2";
            listBox_1.Visibility = Visibility.Collapsed;

        }

        private void i50_Click(object sender, RoutedEventArgs e)
        {
            if (iscall1)
                call1.Text = "3";
            else
                lammat1.Text = "3";
            listBox_1.Visibility = Visibility.Collapsed;

        }

        private void i51_Click(object sender, RoutedEventArgs e)
        {
            if (iscall1)
                call1.Text = "4";
            else
                lammat1.Text = "4";
            listBox_1.Visibility = Visibility.Collapsed;

        }

        private void i52_Click(object sender, RoutedEventArgs e)
        {
            if (iscall1)
                call1.Text = "5";
            else
                lammat1.Text = "5";
            listBox_1.Visibility = Visibility.Collapsed;

        }

        private void i53_Click(object sender, RoutedEventArgs e)
        {
            if (iscall1)
                call1.Text = "6";
            else
                lammat1.Text = "6";
            listBox_1.Visibility = Visibility.Collapsed;

        }

        private void i54_Click(object sender, RoutedEventArgs e)
        {
            if (iscall1)
                call1.Text = "7";
            else
                lammat1.Text = "7";
            listBox_1.Visibility = Visibility.Collapsed;

        }

        private void i55_Click(object sender, RoutedEventArgs e)
        {
            if (iscall1)
                call1.Text = "8";
            else
                lammat1.Text = "8";
            listBox_1.Visibility = Visibility.Collapsed;

        }

        private void i56_Click(object sender, RoutedEventArgs e)
        {
            if (iscall1)
                call1.Text = "9";
            else
                lammat1.Text = "9";
            listBox_1.Visibility = Visibility.Collapsed;

        }

        private void i57_Click(object sender, RoutedEventArgs e)
        {
            if (iscall1)
                call1.Text = "10";
            else
                lammat1.Text = "10";
            listBox_1.Visibility = Visibility.Collapsed;

        }

        private void i58_Click(object sender, RoutedEventArgs e)
        {
            if (iscall1)
                call1.Text = "11";
            else
                lammat1.Text = "11";
            listBox_1.Visibility = Visibility.Collapsed;

        }

        private void i59_Click(object sender, RoutedEventArgs e)
        {
            if (iscall1)
                call1.Text = "12";
            else
                lammat1.Text = "12";
            listBox_1.Visibility = Visibility.Collapsed;

        }

        private void i60_Click(object sender, RoutedEventArgs e)
        {
            if (iscall1)
                call1.Text = "13";
            else
                lammat1.Text = "13";
            listBox_1.Visibility = Visibility.Collapsed;


        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            var obj = App.Current as App;
            obj.gameno = gameno;
            obj.score1 = scorei1;
            obj.score2 = scorei2;
            obj.score3 = scorei3;
            obj.score4 = scorei4;
            obj.call1 = calli1;
            obj.call2 = calli2;
            obj.call3 = calli3;
            obj.call4 = calli4;
            obj.lammat1 = lammati1;
            obj.lammat2 = lammati2;
            obj.lammat3 = lammati3;
            obj.lammat4 = lammati4;
            obj.name1 = name1.Text;
            obj.name2 = name2.Text;
            obj.name3 = name3.Text;
            obj.name4 = name4.Text;
            obj.shape = shape;
            Frame.Navigate(typeof(BlankPage1));




        }



        private void image_Copy_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            listBox_1.Visibility = Visibility.Visible;
            if (!iscall1)
                i46.Visibility = Visibility.Collapsed;
            else
                i46.Visibility = Visibility.Visible;
        }

        private void image_Copy_1PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            listBox_2.Visibility = Visibility.Visible;
            if (!iscall1)
                i31.Visibility = Visibility.Collapsed;
            else
                i31.Visibility = Visibility.Visible;

        }
        private void image_Copy_2PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            listBox_3.Visibility = Visibility.Visible;
            if (!iscall1)
                i16.Visibility = Visibility.Collapsed;
            else
                i16.Visibility = Visibility.Visible;
        }
        private void image_Copy_3PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            listBox_4.Visibility = Visibility.Visible;
            if (!iscall1)
                i1.Visibility = Visibility.Collapsed;
            else
                i1.Visibility = Visibility.Visible;
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            if (i >= 0 && gameno >= 0)
            {
                if (i > 0)
                    i--;

                if (i % 2 != 0)
                {
                    iscall1 = false;
                    gameno--;
                    score1.Text = scorei1[gameno].ToString();
                    score2.Text = scorei2[gameno].ToString();
                    score3.Text = scorei3[gameno].ToString();
                    score4.Text = scorei4[gameno].ToString();
                    call1.Text = calli1[gameno + 1].ToString();
                    call2.Text = calli2[gameno + 1].ToString();
                    call3.Text = calli3[gameno + 1].ToString();
                    call4.Text = calli4[gameno + 1].ToString();
                    if (shape[20] == -1&& calli1[gameno + 1]==0)
                        call1.Text = "DC";
                    if (shape[21] == -1 && calli2[gameno + 1] == 0)
                        call2.Text = "DC";
                    if (shape[22] == -1 && calli3[gameno + 1] == 0)
                        call3.Text = "DC";
                    if (shape[23] == -1 && calli4[gameno + 1] == 0)
                        call4.Text = "DC";
                    if (flipView.Visibility == Visibility.Visible)
                        image_call1.Visibility = Visibility.Visible;
                    if (flipView2.Visibility == Visibility.Visible)
                        image_call2.Visibility = Visibility.Visible;
                    if (flipView3.Visibility == Visibility.Visible)
                        image_call3.Visibility = Visibility.Visible;
                    if (flipView4.Visibility == Visibility.Visible)
                        image_call4.Visibility = Visibility.Visible;
                    image_Call1.Visibility = Visibility.Collapsed;
                    image_Call2.Visibility = Visibility.Collapsed;
                    image_Call3.Visibility = Visibility.Collapsed;
                    image_Call4.Visibility = Visibility.Collapsed;
                    lammat1.Visibility = Visibility.Visible;
                    lammat2.Visibility = Visibility.Visible;
                    lammat3.Visibility = Visibility.Visible;
                    lammat4.Visibility = Visibility.Visible;
                    image_Lammat1.Visibility = Visibility.Visible;
                    image_Lammat2.Visibility = Visibility.Visible;
                    image_Lammat3.Visibility = Visibility.Visible;
                    image_Lammat4.Visibility = Visibility.Visible;
                    lammat1.Text = "Lammat";
                    lammat2.Text = "Lammat";
                    lammat3.Text = "Lammat";
                    lammat4.Text = "Lammat";
                    button2.Content = "Calculate Score";
                    sa3ayda2 = sa3ayda3;

                }
                else
                {
                    iscall1 = true;
                    call1.Visibility = Visibility.Visible;
                    call2.Visibility = Visibility.Visible;
                    call3.Visibility = Visibility.Visible;
                    call4.Visibility = Visibility.Visible;
                    image_call1.Visibility = Visibility.Collapsed;
                    image_call2.Visibility = Visibility.Collapsed;
                    image_call3.Visibility = Visibility.Collapsed;
                    image_call4.Visibility = Visibility.Collapsed;
                    image_Call1.Visibility = Visibility.Visible;
                    image_Call2.Visibility = Visibility.Visible;
                    image_Call3.Visibility = Visibility.Visible;
                    image_Call4.Visibility = Visibility.Visible;
                    lammat1.Visibility = Visibility.Collapsed;
                    lammat2.Visibility = Visibility.Collapsed;
                    lammat3.Visibility = Visibility.Collapsed;
                    lammat4.Visibility = Visibility.Collapsed;
                    image_Lammat1.Visibility = Visibility.Collapsed;
                    image_Lammat2.Visibility = Visibility.Collapsed;
                    image_Lammat3.Visibility = Visibility.Collapsed;
                    image_Lammat4.Visibility = Visibility.Collapsed;
                    call1.Text = "Choose Call";
                    call2.Text = "Choose Call";
                    call3.Text = "Choose Call";
                    call4.Text = "Choose Call";
                    button2.Content = "Start Round";

                }
            }
        }

        private void textBox_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            textBox.Text = "";
        }



        private void wh_Call_done_Click(object sender, RoutedEventArgs e)
        {
            if (wh_Call1.IsChecked.GetValueOrDefault() == true)
            {

                mc.iscall1 = true;
                mc.iswith1 = false;
                if (mc.iscall2)
                {
                    mc.iscall2 = false;
                    mc.iswith2 = true;
                }
                if (mc.iscall3)
                {
                    mc.iscall3 = false;
                    mc.iswith3 = true;
                }
                if (mc.iscall4)
                {
                    mc.iscall4 = false;
                    mc.iswith4 = true;
                }
            }
            if (wh_Call2.IsChecked.GetValueOrDefault() == true)
            {

                mc.iscall2 = true;
                mc.iswith2 = false;
                if (mc.iscall1)
                {
                    mc.iscall1 = false;
                    mc.iswith1 = true;
                }
                if (mc.iscall3)
                {
                    mc.iscall3 = false;
                    mc.iswith3 = true;
                }
                if (mc.iscall4)
                {
                    mc.iscall4 = false;
                    mc.iswith4 = true;
                }
            }
            if (wh_Call3.IsChecked.GetValueOrDefault() == true)
            {

                mc.iscall3 = true;
                mc.iswith3 = false;
                if (mc.iscall2)
                {
                    mc.iscall2 = false;
                    mc.iswith2 = true;
                }
                if (mc.iscall1)
                {
                    mc.iscall1 = false;
                    mc.iswith1 = true;
                }
                if (mc.iscall4)
                {
                    mc.iscall4 = false;
                    mc.iswith4 = true;
                }
            }
            if (wh_Call4.IsChecked.GetValueOrDefault() == true)
            {

                mc.iscall4 = true;
                mc.iswith4 = false;
                if (mc.iscall2)
                {
                    mc.iscall2 = false;
                    mc.iswith2 = true;
                }
                if (mc.iscall3)
                {
                    mc.iscall3 = false;
                    mc.iswith3 = true;
                }
                if (mc.iscall1)
                {
                    mc.iscall1 = false;
                    mc.iswith1 = true;
                }
            }

            if (mc.iscall1)
            { image_call1.Visibility = Visibility.Visible; }
            if (mc.iscall2)
            { image_call2.Visibility = Visibility.Visible; }
            if (mc.iscall3)
            { image_call3.Visibility = Visibility.Visible; }
            if (mc.iscall4)
            { image_call4.Visibility = Visibility.Visible; }
            wh_Call.Visibility = Visibility.Collapsed;
        }
        private int[] shape = new int[24];
        

        private void call1_LayoutUpdated(object sender, object e)
        {

            if (call1.Visibility == Visibility.Visible)
            {

                if (call1.Text != "Choose Call" && call1.Text != "DC")
                {
                    shape[20] = int.Parse(call1.Text);
                }
                else
                    shape[20] = -1;

                if (call2.Text != "Choose Call" && call2.Text != "DC")
                {
                    shape[21] = int.Parse(call2.Text);
                }
                else
                    shape[21] = -1;
                if (call3.Text != "Choose Call" && call3.Text != "DC")
                {
                    shape[22] = int.Parse(call3.Text);
                }
                else
                    shape[22] = -1;

                if (call4.Text != "Choose Call" && call4.Text != "DC")
                {
                    shape[23] = int.Parse(call4.Text);
                }
                else
                    shape[23] = -1;
                if (shape[20] > shape[21] && shape[20] > shape[22] && shape[20] > shape[23])
                {
                    flipView.Visibility = Visibility.Visible;
                    flipView2.Visibility = Visibility.Collapsed;
                    flipView3.Visibility = Visibility.Collapsed;
                    flipView4.Visibility = Visibility.Collapsed;
                }

                if (shape[21] > shape[20] && shape[21] > shape[22] && shape[21] > shape[23])
                {
                    flipView2.Visibility = Visibility.Visible;
                    flipView4.Visibility = Visibility.Collapsed;
                    flipView3.Visibility = Visibility.Collapsed;
                    flipView.Visibility = Visibility.Collapsed;
                }

                if (shape[22] > shape[21] && shape[22] > shape[20] && shape[22] > shape[23])
                {
                    flipView3.Visibility = Visibility.Visible;
                    flipView2.Visibility = Visibility.Collapsed;
                    flipView4.Visibility = Visibility.Collapsed;
                    flipView.Visibility = Visibility.Collapsed;
                }

                if (shape[23] > shape[20] && shape[23] > shape[22] && shape[23] > shape[21])
                {
                    flipView4.Visibility = Visibility.Visible;
                    flipView3.Visibility = Visibility.Collapsed;
                    flipView2.Visibility = Visibility.Collapsed;
                    flipView.Visibility = Visibility.Collapsed;
                }
                if (flipView.Visibility == Visibility.Visible && (shape[20] < shape[21] || shape[20] < shape[22] || shape[20] < shape[23]))
                {
                    flipView.Visibility = Visibility.Collapsed;
                }
                if (flipView2.Visibility == Visibility.Visible && (shape[21] < shape[20] || shape[21] < shape[22] || shape[21] < shape[23]))
                {
                    flipView2.Visibility = Visibility.Collapsed;
                }
                if (flipView3.Visibility == Visibility.Visible && (shape[22] < shape[21] || shape[22] < shape[20] || shape[22] < shape[23]))
                {
                    flipView3.Visibility = Visibility.Collapsed;
                }
                if (flipView4.Visibility == Visibility.Visible && (shape[23] < shape[21] || shape[23] < shape[22] || shape[23] < shape[20]))
                {
                    flipView4.Visibility = Visibility.Collapsed;
                }

            }

        }

        
        
    }

}
