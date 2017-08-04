using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace XamarinDivisas.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        #region Attributes
        private decimal dollars;
        private decimal pounds;
        private decimal euros;
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Properties
        public decimal Pesos { get; set; }
        public decimal Dollars
        {
            get
            {
                return dollars;
            }

            set
            {
                if (dollars != value) {
                    dollars = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Dollars"));
                }
            }
        }
        public decimal Pounds
        {
            get
            {
                return pounds;
            }

            set
            {
                if (pounds != value)
                {
                    pounds = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Pounds"));
                }                
            }
        }
        public decimal Euros
        {
            get
            {
                return euros;
            }

            set
            {
                if (euros != value)
                {
                    euros = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Euros"));
                }
            }
        }
        #endregion

        #region Cmmands
        public ICommand ConvertCommand { get { return new RelayCommand(ConvertMoney); } }

        private async void ConvertMoney()
        {
            if (this.Pesos < 0)
                await App.Current.MainPage.DisplayAlert("Error", "Debe ingresar un valor mayor a cero", "Aceptar");
            else
            {
                this.Dollars = Pesos / 2849.00285M;
                this.Pounds = Pesos / 3557.26496M;
                this.Euros = Pesos / 3072.79202M;
            }
            return;
        } 
        #endregion
    }
}
