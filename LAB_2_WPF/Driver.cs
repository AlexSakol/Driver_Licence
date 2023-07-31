using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LAB_2_WPF
{
    public enum GENDER {male, female, variant};
    public enum EYES { blue, green, brown, gray}
    public class Driver: INotifyPropertyChanged, IDataErrorInfo
    {
        int number;
        char license_class;
        double hgt;
        string name;
        string adress;
        GENDER gender;
        EYES eyes;
        DateTime dob, iss, exp;
        bool donor;
        string urlimage;

        public Driver()
        {
        }

        public string this[string columnName]
        {
            get 
            {
                string error = string.Empty;
                switch (columnName)
                {
                    case "License_class":
                        if (License_class < 'A' || License_class > 'E')
                            error = "Неверная категория";
                        break;
                    case "Exp":
                        if (Exp < DateTime.Now)
                            error = "Закончен срок действия";
                            break;
                    case "Number":
                        if (!Regex.IsMatch(Number.ToString(), "[A-Z][a-z][1-9]"))
                            error = "Номер должен содержать только английские буквы и цифры";
                        break;
                    case "Dob":
                        if (Dob < new DateTime(1900,01,01) || Dob >= DateTime.Now.AddYears(-16))
                            error = "Некорректная дата рождения";
                        break;
                    case "Iss":
                        if (Iss <= DateTime.Now.AddYears(-16) || Iss > DateTime.Now)
                            error = "Некорректная дата выдачи";
                        break;                    
                }
                return error;
            }
        }

        public int Number
        {
            get => number;
            set
            {
                number = value;
                OnPropertyChanged("Number");
            }
        }
        public char License_class 
        { 
            get => license_class;
            set
            {
                license_class = value;
                OnPropertyChanged("License_class");
            }
        }
        public double Hgt
        {
            get => hgt; set
            {
                hgt = value;
                OnPropertyChanged("Hgt");
            }
        }
        public string Name
        {
            get => name; set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        public string Adress
        {
            get => adress; set
            {
                adress = value;
                OnPropertyChanged("Adress");
            }
        }
        public GENDER Gender
        {
            get => gender; set
            {
                gender = value;
                OnPropertyChanged("Gender");
            }
        }
        public EYES Eyes
        {
            get => eyes; set
            {
                eyes = value;
                OnPropertyChanged("Eyes");
            }
        }
        public DateTime Dob
        {
            get => dob; set
            {
                dob = value;
                OnPropertyChanged("Dob");
            }
        }
        public DateTime Iss
        {
            get => iss; set
            {
                iss = value;
                OnPropertyChanged("Iss");
            }
        }
        public DateTime Exp
        {
            get => exp; set
            {
                exp = value;
                OnPropertyChanged("Exp");
            }
        }
        public bool Donor
        {
            get => donor; set
            {
                donor = value;
                OnPropertyChanged("Donor");
            }
        }
        public string Urlimage
        {
            get => urlimage; set
            {
                urlimage = value;
                OnPropertyChanged("Urlimage");
            }
        }

        public string Error => throw new NotImplementedException();

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        public override string? ToString() => $"№{Number} {License_class} from {Iss} to {Exp}. {Name} DOB({Dob}). " +
            $"{Adress} Height {Hgt} {Gender} Color of eyes {Eyes} {(Donor ? "Donor" : "Not donor")}"
            +$" {Urlimage}";
    
    }
}
