using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAvtoPark.Models
{
    public class RentalInfo : INotifyPropertyChanged
    {


        private int _carId;
        public int CarId
        {
            get { return _carId; }
            set { _carId = value; OnPropertyChanged("CarId"); }
        }


        private int _ArendaId;
        public int ArendaId
        {
            get { return _ArendaId; }
            set { _ArendaId = value; OnPropertyChanged("ArendaId"); }
        }


        private string _carNumber;
        public string CarNumber
        {
            get { return _carNumber; }
            set { _carNumber = value; OnPropertyChanged("CarNumber"); }
        }

        private string _carName;
        public string CarName
        {
            get { return _carName; }
            set { _carNumber = value; OnPropertyChanged("CardName"); }
        }

        private int? _modelId;

        public int? ModelId
        {
            get { return _modelId; }
            set { _modelId = value; OnPropertyChanged("ModelId"); }
        }

        private bool? _carStatus;
        public bool? CarStatus
        {
            get { return _carStatus; }
            set { _carStatus = value; OnPropertyChanged("CarStatus"); }
        }

        private int _rentId;
        public int RentId
        {
            get { return _rentId; }
            set { _rentId = value; OnPropertyChanged("RentId"); }
        }

        private int? _userId;
        public int? UserId
        {
            get { return _userId; }
            set { _userId = value; OnPropertyChanged("UserId"); }
        }

        private int? _tariffId;
        public int? TariffId
        {
            get { return _tariffId; }
            set { _tariffId = value; OnPropertyChanged("TariffId"); }
        }

        private int? _cost;
        public int? Cost
        {
            get { return _cost; }
            set
            {
                _cost = value;
                OnPropertyChanged("Cost");
            }
        }

        private int? _kolvo;
        public int? Kolvo
        {
            get { return _kolvo; }
            set
            {
                _kolvo = value;
                OnPropertyChanged("Kolvo");
            }
        }

        private int? _kolvonearend;
        public int? Kolvonearend
        {
            get { return _kolvonearend; }
            set
            {
                _kolvonearend = value;
                OnPropertyChanged("Kolvonearend");
           
           }
        }

        private int? _k;
        public int? k
        {
            get { return _k; }
            set
            {
                _k = value;
                OnPropertyChanged("k");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
