﻿using System;
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

namespace App2
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

        }
        private int i;
        private int gameno;
        private int[] scorei1 = new int[20];
        private int[] scorei2 = new int[20];
        private int[] scorei3 = new int[20];
        private int[] scorei4 = new int[20];
        private Majorcal mc;
        private bool dashcall1;
        private bool dashcall2;
        private bool dashcall3;
        private bool dashcall4;
        private bool iscall1=true;






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
                    name2_Copy.Text = textBox.Text;
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
            { if (textBox.Text.Equals(""))
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
                i = 0;
                addname.Visibility = Visibility.Collapsed;
                textBox.Visibility = Visibility.Collapsed;
            }
        }

        private async void button2_Click(object sender, RoutedEventArgs e)
        {
            
            i++;
            if (i % 2 == 0)
            {
                if (call1.Text == "Choose Call")
                {
                    i--; MessageDialog msgbox = new MessageDialog("you didn't enter a lammat for player 1");//,,,,,,,,,,,,,//
                    await msgbox.ShowAsync();
                    return;
                }
                if (call2.Text == "Choose Call")
                {
                    i--; MessageDialog msgbox = new MessageDialog("you didn't enter a lammat for player 2");//,,,,,,,,,,,,,//
                    await msgbox.ShowAsync();
                    return;
                }
                if (call3.Text == "Choose Call")
                {
                    i--; MessageDialog msgbox = new MessageDialog("you didn't enter a lammat for player 3");//,,,,,,,,,,,,,//
                    await msgbox.ShowAsync();
                    return;
                }
                if (call4.Text == "Choose Call")
                {
                    i--;
                    MessageDialog msgbox = new MessageDialog("you didn't enter a lammat for player 4");
                    await msgbox.ShowAsync();   
                    return;
                }
                gameno++;
                if (call1.Text == "DC")
                { dashcall1 = true;
                    call1.Text = "0";
                }
                else dashcall1 = false; 
                if (call2.Text == "DC")
                {  dashcall2 = true; call2.Text = "0"; }
            else dashcall2 = false;
                if (call3.Text == "DC")
                {  dashcall3 = true; call3.Text = "0"; }
            else dashcall3 = false;
                if (call4.Text == "DC")
                { dashcall4 = true; call4.Text = "0"; }
                else dashcall4 = false;
                mc = new Majorcal(int.Parse(call1.Text), int.Parse(lammat1.Text), dashcall1, int.Parse(call2.Text), int.Parse(lammat2.Text), dashcall2, int.Parse(call3.Text), int.Parse(lammat3.Text), dashcall3, int.Parse(call4.Text), int.Parse(lammat4.Text), dashcall4);
                if (mc.isError())
                {
                    MessageDialog msgbox = new MessageDialog("Lammat msh mazpota ");//,,,,,,,,,,,,,//
                    await msgbox.ShowAsync();
                    gameno--;
                    i--;
                    return;
                }
                
                mc.setiscall();
                mc.setrisk();
                mc.setonlywinner();
                scorei1[gameno - 1] = int.Parse(score1.Text);
                scorei1[gameno] = mc.getscore1(scorei1[gameno - 1]);
                score1.Text = "score=" + scorei1[gameno];
                scorei2[gameno - 1] = int.Parse(score2.Text);
                scorei2[gameno] = mc.getscore2(scorei2[gameno - 1]);
                score2.Text = "score=" + scorei2[gameno];
                scorei3[gameno - 1] = int.Parse(score3.Text);
                scorei3[gameno] = mc.getscore3(scorei3[gameno - 1]);
                score3.Text = "score=" + scorei3[gameno];
                scorei4[gameno - 1] = int.Parse(score4.Text);
                scorei4[gameno] = mc.getscore1(scorei4[gameno - 1]);
                score4.Text = "score=" + scorei4[gameno];
              
            }
            else
            {
                if(call1.Text== "Choose Call" )
                {
                    i--; MessageDialog msgbox = new MessageDialog("you didn't enter a call for player 1");//,,,,,,,,,,,,,//
                    await msgbox.ShowAsync();
                    return;
                }
                if ( call2.Text == "Choose Call" )
                {
                    i--; MessageDialog msgbox = new MessageDialog("you didn't enter a call for player 2");//,,,,,,,,,,,,,//
                    await msgbox.ShowAsync();
                    return;
                }
                if ( call3.Text == "Choose Call" )
                {
                    i--; MessageDialog msgbox = new MessageDialog("you didn't enter a call for player 3");//,,,,,,,,,,,,,//
                    await msgbox.ShowAsync();
                    return;
                }
                if ( call4.Text == "Choose Call")
                {
                    i--;
                    MessageDialog msgbox = new MessageDialog("you didn't enter a call for player 4");
                    await msgbox.ShowAsync();
                    return;
                }
                button2.Content = "Calculate score";

                iscall1 = false;

            }



                    }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {if(iscall1)
                call4.Text = "DC";
            else { 
            lammat4.Text = "Dc"; }
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
        {if(iscall1)
            call2.Text = "13";
            else
                lammat2.Text = "13";
            listBox_2.Visibility = Visibility.Collapsed;


        }

        private void i46_Click(object sender, RoutedEventArgs e)
        {
            call1.Text = "DC";
            listBox_1.Visibility = Visibility.Collapsed;

        }

        private void i47_Click(object sender, RoutedEventArgs e)
        {
            call1.Text = "0";
            listBox_1.Visibility = Visibility.Collapsed;

        }

        private void i48_Click(object sender, RoutedEventArgs e)
        {
            call1.Text = "1";
            listBox_1.Visibility = Visibility.Collapsed;

        }

        private void i49_Click(object sender, RoutedEventArgs e)
        {
            call1.Text = "2";
            listBox_1.Visibility = Visibility.Collapsed;

        }

        private void i50_Click(object sender, RoutedEventArgs e)
        {
            call1.Text = "3";
            listBox_1.Visibility = Visibility.Collapsed;

        }

        private void i51_Click(object sender, RoutedEventArgs e)
        {
            call1.Text = "4";
            listBox_1.Visibility = Visibility.Collapsed;

        }

        private void i52_Click(object sender, RoutedEventArgs e)
        {
            call1.Text = "5";
            listBox_1.Visibility = Visibility.Collapsed;

        }

        private void i53_Click(object sender, RoutedEventArgs e)
        {
            call1.Text = "6";
            listBox_1.Visibility = Visibility.Collapsed;

        }

        private void i54_Click(object sender, RoutedEventArgs e)
        {
            call1.Text = "7";
            listBox_1.Visibility = Visibility.Collapsed;

        }

        private void i55_Click(object sender, RoutedEventArgs e)
        {
            call1.Text = "8";
            listBox_1.Visibility = Visibility.Collapsed;

        }

        private void i56_Click(object sender, RoutedEventArgs e)
        {
            call1.Text = "9";
            listBox_1.Visibility = Visibility.Collapsed;

        }

        private void i57_Click(object sender, RoutedEventArgs e)
        {
            call1.Text = "10";
            listBox_1.Visibility = Visibility.Collapsed;

        }

        private void i58_Click(object sender, RoutedEventArgs e)
        {
            call1.Text = "11";
            listBox_1.Visibility = Visibility.Collapsed;

        }

        private void i59_Click(object sender, RoutedEventArgs e)
        {
            call1.Text = "12";
            listBox_1.Visibility = Visibility.Collapsed;

        }

        private void i60_Click(object sender, RoutedEventArgs e)
        {
            call1.Text = "13";
            listBox_1.Visibility = Visibility.Collapsed;


        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(BlankPage1));
        }

        private void image_Copy_PointerPressed(object sender, PointerRoutedEventArgs e)
        {

            listBox_1.Visibility= Visibility.Visible;
        }

        private void image_Copy_1PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            listBox_2.Visibility = Visibility.Visible;
        }
        private void image_Copy_2PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            listBox_3.Visibility = Visibility.Visible;
        }
        private void image_Copy_3PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            listBox_4.Visibility = Visibility.Visible;
        }

    }

}
