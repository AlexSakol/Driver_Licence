using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;


namespace LAB_2_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Driver driver = new();
        public MainWindow()
        {
            InitializeComponent();
            foreach (EYES color in Enum.GetValues(typeof(EYES)))
            {
                comboBoxEyes.Items.Add(color);
            }
            NewDriver();
            grid.DataContext = driver;
        }

        private void Button_Save_Click(object sender, RoutedEventArgs e)
        {           
            MessageBox.Show(driver.ToString());
        }

        private void NewDriver()
        {
            driver.Number = 2;
            driver.License_class = 'A';
            driver.Hgt = 170;
            driver.Name = "Петр";
            driver.Adress = "Могилев";
            driver.Gender = GENDER.male;
            driver.Eyes = EYES.green;
            driver.Dob = new DateTime(1970, 10, 3);
            driver.Iss = new DateTime(2015, 5, 20);
            driver.Exp = new DateTime(2025, 5, 20);
            driver.Donor = false;
            driver.Urlimage = @"/images/Petya.jpg";            
        }
        private void Button_Load_Click(object sender, RoutedEventArgs e)
        {
            driver.Number = 1;
            driver.License_class = 'B';
            driver.Hgt = 180;
            driver.Name = "Федя";
            driver.Adress = "Минск";
            driver.Gender = GENDER.variant;
            driver.Eyes = EYES.blue;
            driver.Dob = new DateTime(2000, 1, 10);
            driver.Iss = new DateTime(2020, 3, 26);
            driver.Exp = new DateTime(2030, 3, 26);
            driver.Donor = true;
            driver.Urlimage = @"/images/Photo.jpg";
        }

        private void Button_Clear_Click(object sender, RoutedEventArgs e)
        {
            NewDriver();
            textBoxName.Text = driver.Name;
            textBoxNumber.Text = driver.Number.ToString();
            textBoxAddress.Text = driver.Adress;
            textBoxClass.Text = driver.License_class.ToString();
            datePickerDOB.SelectedDate = driver.Dob;
            datePickerISS.SelectedDate = driver.Iss;
            datePickerEXP.SelectedDate = driver.Exp;
            sliderHGT.Value = driver.Hgt;
            checkBoxDonor.IsChecked = driver.Donor;
            if (driver.Gender == GENDER.male) radioButtonMale.IsChecked = true;
            if (driver.Gender == GENDER.female) radioButtonFemale.IsChecked = true;
            if (driver.Gender == GENDER.variant) radioButtonVariant.IsChecked = true;
            comboBoxEyes.SelectedValue = driver.Eyes;
            image.Source = new BitmapImage(new Uri("images/None.jpg", UriKind.RelativeOrAbsolute));
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog dialog = new();
            dialog.Filter = "Файлы (jpg)|*.jpg|Все файлы|*.*";
            if (dialog.ShowDialog() == true)
            {
                driver.Urlimage = dialog.FileName;
                image.Source = new BitmapImage(new Uri(driver.Urlimage, UriKind.RelativeOrAbsolute));
            }

        }
    }
}
