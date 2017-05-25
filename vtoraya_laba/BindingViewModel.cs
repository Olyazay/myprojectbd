using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using System.Runtime.CompilerServices; 

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
        private Int64 _oneIpf; 
        public Int64 OneIpf
        {
            get { return _oneIpf;}
            set
            {
                _oneIpf = value;
                OnPropertyChange("OneIpf");     
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
        private Int64 _kolvoIpf;
        public Int64 KolvoIpf
        {
            get { return _kolvoIpf; }
            set
            {
                _kolvoIpf = value;
                PriceIpf = _kolvoIpf *_oneIpf ;
                OnPropertyChange("KolvoIpf");
                OnPropertyChange("PriceIpf");
                OnPropertyChange("OneIpf");
            }
        }
        private relaymycontrol _addIpf;
        public relaymycontrol AddIpf
        {
            get
            {
                return _addIpf ?? (_addIpf = new relaymycontrol(obj =>
                {
                    KolvoIpf++;
                }
                ));
            }
        }
        private relaymycontrol _reduceIpf;
        public relaymycontrol ReduceIpf
        {
            get
            {
                return _reduceIpf ?? (_reduceIpf = new relaymycontrol(obj=>
                {
                    if (KolvoIpf>0)
                    {
                        KolvoIpf--;
                    }
                }
                ));
            }
        }
        private Int64 _allprductprice; 
        public Int64 Allproductprice
        {
            get { return _allprductprice; }
            set
            {
                _allprductprice = value;

                OnPropertyChange("Allproductprice"); 
            }
        }
        public BindingViewModel()
        {
            MyCommand = new RelayRadioButton(executemethod, canexecutemethod);
            _kolvoIpf = 2;
            _oneIpf = 49000;
            _allprductprice = _oneIpf * _kolvoIpf;
            _priceIpf = _oneIpf * _kolvoIpf;
        }
    }
}
 