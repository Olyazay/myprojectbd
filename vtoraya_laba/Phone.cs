using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Data.SqlClient;

namespace vtoraya_laba
{
    public class Phone: INotifyPropertyChanged
    {
        private int _number;
        public int Number
        {
            get { return _number; }
            set
            {
                _number = value;
                OnPropertyChange("Number");
            }
        }
        private int _index; 
        public int Index
        {
            get { return _index; }
            set
            {
                _index = value;
                OnPropertyChange("Index"); 
            }
        }
        private String _namePhone;
        public String NamePhone
        {
            get
            {
                return _namePhone;
            }
            set
            {
                _namePhone = value;
                OnPropertyChange("NamePhone");
            }
        }
        private int _oneIpf;
        public int OneIpf
        {
            get { return _oneIpf; }
            set
            {
                _oneIpf = value;
                OnPropertyChange("OneIpf");
            }

        }
        private Int64 _kolvoIpf;
        public Int64 KolvoIpf
        {
            get { return _kolvoIpf; }
            set
            {
                _kolvoIpf = value;
                PriceIpf = _kolvoIpf * _oneIpf;
                OnPropertyChange("KolvoIpf");
            }
        }
        private Int64 _priceIpf;
        public Int64 PriceIpf
        {
            get { return _priceIpf; }
            set
            {
                _priceIpf = value;
                OnPropertyChange("PriceIpf");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChange(String propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
        public static List<Phone> GetPhoneFromDataBase()
        {
            List<Phone> result = new List<Phone>();
            using (SqlConnection ch = new SqlConnection("Server=DESKTOP-HKC6SOD;Database=PhonesDataBase;Trusted_Connection=True;"))
            {
                ch.Open(); 
                SqlCommand cmd = new SqlCommand("SELECT * FROM Phones",ch);

                var phonesReader =cmd.ExecuteReader();
                while(phonesReader.Read())
                {
                    Phone a = new Phone(); 
                    a.Number = (int)phonesReader["ID"];
                    a.NamePhone = (string)phonesReader["Name"];
                    a.OneIpf = (int)phonesReader["Price"];
                    a.KolvoIpf = (int)phonesReader["Count"];
                    a.PriceIpf = (int)phonesReader["Cost"];
                    a.Index = (int)phonesReader["Index"]; 
                    result.Add(a); 
                }
            }
            return result;
        }
        public ICommand MyCommand { get; set; }
        public Phone(/*int number, String namePhone, int oneIpf, Int64 kolvoIpf*/)
        {
            //_number = number;
            //_namePhone = namePhone;
            //_oneIpf = oneIpf;
            //_kolvoIpf = kolvoIpf;
            //_priceIpf = _oneIpf * _kolvoIpf;
            //_index = _number - 1; 
        }
    }
}
