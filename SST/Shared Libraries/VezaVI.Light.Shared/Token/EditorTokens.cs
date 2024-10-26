using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace VezaVI.Light.Shared
{

    public class ModelOneValues : INotifyPropertyChanged
    {
        private string _valueA = null;
        public string ValueA
        {
            get
            {
                return _valueA;
            }
            set
            {
                if (value != this._valueA)
                {
                    this._valueA = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string _guidA = null;
        public string GuidA
        {
            get
            {
                return _guidA;
            }
            set
            {
                if (value != this._guidA)
                {
                    this._guidA = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    public class ModelTwoValues : INotifyPropertyChanged
    {
        private string _valueA = null;
        public string ValueA 
        {
            get { 
                return _valueA;
            }
            set 
            {
                if (value != this._valueA)
                {
                    this._valueA = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string _guidA = null;
        public string GuidA
        {
            get
            {
                return _guidA;
            }
            set
            {
                if (value != this._guidA)
                {
                    this._guidA = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string _valueB = null;
        public string ValueB
        {
            get
            {
                return _valueB;
            }
            set
            {
                if (value != this._valueB)
                {
                    this._valueB = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string _guidB = null;
        public string GuidB
        {
            get
            {
                return _guidB;
            }
            set
            {
                if (value != this._guidB)
                {
                    this._guidB = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    public class ModelThreeValues : INotifyPropertyChanged
    {
        private string _valueA = null;
        public string ValueA
        {
            get
            {
                return _valueA;
            }
            set
            {
                if (value != this._valueA)
                {
                    this._valueA = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string _guidA = null;
        public string GuidA
        {
            get
            {
                return _guidA;
            }
            set
            {
                if (value != this._guidA)
                {
                    this._guidA = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string _valueB = null;
        public string ValueB
        {
            get
            {
                return _valueB;
            }
            set
            {
                if (value != this._valueB)
                {
                    this._valueB = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string _guidB = null;
        public string GuidB
        {
            get
            {
                return _guidB;
            }
            set
            {
                if (value != this._guidB)
                {
                    this._guidB = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string _valueC = null;
        public string ValueC
        {
            get
            {
                return _valueC;
            }
            set
            {
                if (value != this._valueC)
                {
                    this._valueC = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string _guidC = null;
        public string GuidC
        {
            get
            {
                return _guidC;
            }
            set
            {
                if (value != this._guidC)
                {
                    this._guidC = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
