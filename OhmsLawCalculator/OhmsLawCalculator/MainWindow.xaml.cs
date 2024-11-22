using System;
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

namespace OhmsLawCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ComboBox.SelectedIndex = 0;
        }
        public delegate int ohmsLawDelegate(int val1, int val2);

        /*calculate voltage:
         Voltage= Current * Resistance*/
        public int Voltage(int current, int resistance) => current * resistance;

        /*Calculate current:
         Current= voltage / resistance*/
        public int Current(int voltage, int resistance) => voltage / resistance;

        /*calculate Resistance:
         Resistance= voltage / current*/
        public int Resistance(int voltage, int current) => voltage / current;

        
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch(ComboBox.SelectedIndex)
            {
                case 0:
                    ComboBox.SelectedItem = "Current";
                    LabelFirst.Content = "Voltage";
                    //LabelSecond.Content = "Resistance";
                    break;
                case 1:
                    ComboBox.SelectedItem = "Voltage";
                    LabelFirst.Content = "Current";
                    LabelSecond.Content = "Resistance";
                    break;
                case 2:
                    ComboBox.SelectedItem = "Resistance";
                    LabelFirst.Content = "Voltage";
                    LabelSecond.Content = "Current";
                    break;
                default:
                    ComboBox.SelectedItem = "";
                    break;
            }

           /* if(ComboBox.SelectedIndex==0)
            {
                LabelSecond.Content = "Vice Prince";
            }*/
           
        }

        private void TextBox1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox3_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            TextBox1.Clear();
            TextBox2.Clear();
            TextBox3.Clear();
        }

        private void ButtonCalculate_Click(object sender, RoutedEventArgs e)
        {
            int option = 10;
            int userValue1 = 0;
            int userValue2 = 0;
            //bool valid = false;
            int result = 0;

            ohmsLawDelegate ohmsLawDel = null;


            option = ComboBox.SelectedIndex;


            switch (option)
            {
                case 0:
                    userValue1 = Convert.ToInt32(TextBox1.Text);
                    userValue2 = Convert.ToInt32(TextBox2.Text);
                    ohmsLawDel = new ohmsLawDelegate(Current);
                    //valid = true;
                    break;
                case 1:
                    userValue1 = Convert.ToInt32(TextBox1.Text);
                    userValue2 = Convert.ToInt32(TextBox2.Text);
                    ohmsLawDel = new ohmsLawDelegate(Voltage);
                    //valid = true;
                    break;
                case 2:
                    userValue1 = Convert.ToInt32(TextBox1.Text);
                    userValue2 = Convert.ToInt32(TextBox2.Text);
                    ohmsLawDel = new ohmsLawDelegate(Resistance);
                    //valid = true;
                    break;
                default:
                    break;

            } // end switch
            result = ohmsLawDel(userValue1, userValue2);
            TextBox3.Text = result+ "";

            if(option==0)
            {
                LabelThird.Content = "The Current is: ";
            }
            else if(option==1)
            {
                LabelThird.Content = "The Voltage is: ";
            }
            else
            {
                LabelThird.Content = "The Resistance is: ";
            }
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        //Command execution pass
        private void CommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {

        }

        private void CommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {

        }



    }
}
