using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace vtoraya_laba
{
    class BindingViewModel: INotifyPropertyChanged
    {
        private String _name;
        public String Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChange("Name");
            }
        }
        private Int64 _summa; 
        public Int64 Summa
        {
            get { return _summa; }
            set
            {
                _summa = value;
                OnPropertyChange("Summa"); 
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChange (String propertyname)
        {           
            if (PropertyChanged!=null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
        public ICommand MyCommand { get; set; }
        private bool canexecutemethod(object parameter)
        {
            if (parameter!=null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void executemethod(object parameter)
        {
            Name = (String)parameter; 
        }
        public ObservableCollection<Phone> Phones { get; set; }
        public BindingViewModel()
        {
            MyCommand = new RelayRadioButton(executemethod, canexecutemethod);
            Phones = new ObservableCollection<Phone>();
            var phones = Phone.GetPhoneFromDataBase();
            //{
            //    new Phone(1,"Iphone 7", 54000,0),
            //    new Phone(2,"Samsung S8", 64000,0),
            //    new Phone(3,"Meizu mx", 42000,0), 
            //    new Phone(4,"Xiaomi",8000,0)
            //};
            foreach (var p in phones)
            {
                Phones.Add(new Phone()
                {
                    Number = p.Number,
                    NamePhone = p.NamePhone,
                    OneIpf = p.OneIpf,
                    KolvoIpf = p.KolvoIpf,
                    PriceIpf = p.PriceIpf,
                    Index = p.Index
                }                   
                    );
                    
            }

        }
        private relaymycontrol _deletephone;
        public relaymycontrol DeletePhone
        {
            get
            {
                return _deletephone ?? (_deletephone = new relaymycontrol(obj =>
                {
                    Phone phone = obj as Phone; 
                    if(phone!=null)
                    {
                        Phones.Remove(phone);
                        for (int i = phone.Index; i < Phones.Count; i++)
                        {
                            Phones[i].Number = Phones[i].Index;
                            Phones[i].Index = Phones[i].Index - 1;
                        }
                        Summa -= phone.PriceIpf;
                    }
            },
               (obj) => Phones.Count > 0));
            }
        }
        private relaymycontrol _addIpf;
        public relaymycontrol AddIpf
        {
            get
            {
                return _addIpf ?? (_addIpf = new relaymycontrol(obj =>
                {
                    Phone phone = obj as Phone;
                    if (phone!=null)
                    {
                        Phones[phone.Index].KolvoIpf++;
                        Summa += phone.OneIpf;
                    }
                }
                ));
            }
        }
        private relaymycontrol _reduceIpf;
        public relaymycontrol ReduceIpf
        {
            get
            {
                return _reduceIpf ?? (_reduceIpf = new relaymycontrol(obj =>
                {
                    Phone phone = obj as Phone;
                    if (phone != null)
                    {
                        Phones[phone.Index].KolvoIpf--;
                        Summa -= phone.OneIpf;
                    }
                }
                ));
            }
        }
    }
}
 