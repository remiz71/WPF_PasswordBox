﻿using System;
using System.Collections.Generic;
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

namespace WPF_PasswordBox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            CB.Items.Add('$');
            CB.Items.Add('#');
            CB.Items.Add('*');
            CB.Items.Add('.');
            CB.Items.Add('@');
            LabelMax.Content = "Current Max : Unlimited";
        }
        int Change = 0;
        private void PB_PasswordChanged(object sender, RoutedEventArgs e)
        {
            Change++;
            LabelChange.Content = Change;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PB.PasswordChar = (char)CB.SelectedItem;
        }

        private void textBoxControl_PreviewKeyUp(object sender, KeyEventArgs e)
        {

            if (textBoxControl.Text == "")
            {
                PB.MaxLength = 999;
                TB.MaxLength = 999;
                LabelMax.Content = "Current Max : Unlimited";
            }
            else
            {
                LabelMax.Content = "Current Max :" + textBoxControl.Text;
                PB.MaxLength = Convert.ToInt32(textBoxControl.Text);
                TB.MaxLength = Convert.ToInt32(textBoxControl.Text);
            }


        }
        private void button_Clear_Click(object sender, RoutedEventArgs e)
        {
            PB.Password = "";
        }

        private void button_Content_Copy_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.Clear();
            Clipboard.SetText(TB.Text);
        }

        private void button_Into_Click(object sender, RoutedEventArgs e)
        {
            PB.Password = Clipboard.GetText();
        }
    }
}
