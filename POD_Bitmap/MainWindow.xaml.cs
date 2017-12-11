using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using Microsoft.Win32;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;

namespace POD_Bitmap
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private byte[] fileToHide;
        private Bitmap inputFile;
        private Bitmap result;
        private bool saveFileSize = false;
        private bool twoBits = false;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                InputImage.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                inputFile = new Bitmap(openFileDialog.FileName);

                LoadBMPLabel.Content = "Załadowano plik BMP";
            }
            else
            {
                MessageBox.Show("Nie można otworzyć pliku");
                return;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                fileToHide = File.ReadAllBytes(openFileDialog.FileName);
                LoadHfileLabel.Content = "Załadowano plik";
            }
            else
            {
                MessageBox.Show("Nie można otworzyć pliku");
                return;
            }

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if(FileRadioButton.IsChecked==true)
            {
                LSBAlghoritmEncrypter encypter = new LSBAlghoritmEncrypter();

                byte[] result;

                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == true)
                {

                    if(ComboBox.SelectedIndex==0)
                    {
                        result = encypter.GetHiddenFileColumnMode(System.Drawing.Image.FromFile(openFileDialog.FileName) as Bitmap,
                                    Convert.ToInt32(FindFileTextBox.Text), twoBits);
                    }


                    else
                    {
                        result = encypter.GetHiddenFile(System.Drawing.Image.FromFile(openFileDialog.FileName) as Bitmap,
                                    Convert.ToInt32(FindFileTextBox.Text), twoBits);
                    }


                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    if (saveFileDialog.ShowDialog() == true)
                        File.WriteAllBytes(saveFileDialog.FileName, result);
                }
            }
            else if(ConsoleRadioButton.IsChecked==true)
            {
                LSBAlghoritmEncrypter encypter = new LSBAlghoritmEncrypter();

                byte[] result;

                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == true)
                {
                    try
                    {
                        result = encypter.GetHiddenFile(System.Drawing.Image.FromFile(openFileDialog.FileName) as Bitmap,
                        Convert.ToInt32(FindFileTextBox.Text),twoBits);

                        OutputConsole.Text = Encoding.ASCII.GetString(result);
                    }catch(Exception)
                    {
                        MessageBox.Show("Nie podano długości pliku");
                        return;
                    }

                }
            }
                
            

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            LSBAlghoritm lsbAlg;

            if (inputFile!=null)
            {
                lsbAlg = new LSBAlghoritm(inputFile);
            }
            else
            {
                MessageBox.Show("Nie załadowano pliku bmp!");
                return;
            }     

            if (FileRadioButton.IsChecked == true)
            {          
                if (fileToHide != null)
                {
                    try
                    {
                        if(ComboBox.SelectedIndex==0)
                        {
                            result = lsbAlg.HideMessageColumnMode(fileToHide, twoBits);
                        }
                        else
                        {
                            result = lsbAlg.HideMessage(fileToHide, twoBits);
                        }

                        


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Nie załadowano pliku do ukrycia.");
                }

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                if (saveFileDialog.ShowDialog() == true)
                    result.Save(saveFileDialog.FileName);
            }
            else if (ConsoleRadioButton.IsChecked == true)
            {         
                try
                {
                    if (ComboBox.SelectedIndex == 0)
                    {
                        result = lsbAlg.HideMessageColumnMode(Encoding.ASCII.GetBytes(InputConsole.Text), twoBits);
                    }
                    else
                    {
                        result = lsbAlg.HideMessage(Encoding.ASCII.GetBytes(InputConsole.Text), twoBits);
                    }

                        
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.StackTrace);
                }

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                if (saveFileDialog.ShowDialog() == true)
                    result.Save(saveFileDialog.FileName);
            }



        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            twoBits = true;
            //FindFileTextBox.Visibility = Visibility.Hidden;

                
        }

        private void CheckBoxChanged(object sender, RoutedEventArgs e)
        {
            twoBits = false;
            //FindFileTextBox.Visibility = Visibility.Visible;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
