using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vtoraya_laba
{
    class Phone: INotifyPropertyChanged
    {
        private Int64 _number; 
        public Int64 Number
        {
            get { return _number;}
            set
            {
                _number = value;
                OnPropertyChanged("Number"); 
            }
        }
        private String _name;
        public String Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }
        private Int64 _oneprice; 
        public Int64 OnePrice
        {
            get { return _oneprice; }
            set
            {
                _oneprice = value;
                OnPropertyChanged("OnePrice"); 
            }
        }
        public void OnPropertyChanged(string PropertyName)
        {
            if (PropertyChanged!=null)
            {
                PropertyChanged(this,new PropertyChangedEventArgs(PropertyName)); 
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
