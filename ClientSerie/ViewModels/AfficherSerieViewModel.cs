using ClientConvertisseurV2.Services;
using ClientSerie.Models.EntityFramework;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientSerie.ViewModels
{
    public class AfficherSerieViewModel : ObservableObject, INotifyPropertyChanged
    {
        #region properties
        private ObservableCollection<Serie> series;
        public event PropertyChangedEventHandler PropertyChanged;
        private Serie serieSelected;
        private int idToFind;

        public IRelayCommand BtnViewSerie { get; }


        public ObservableCollection<Serie> Series
        {
            get
            {
                return series;
            }

            set
            {
                series = value;
            }
        }

        public Serie SerieSelected
        {
            get
            {
                return serieSelected;
            }

            set
            {
                serieSelected = value;
                OnPropertyChanged(nameof(SerieSelected));
            }
        }

        public int IdToFind
        {
            get
            {
                return idToFind;
            }

            set
            {
                idToFind = value;
            }
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion

        public AfficherSerieViewModel()
        {
            //Boutons
            BtnViewSerie = new RelayCommand(ActionViewSerie);
        }

        public async void GetSerieAsync()
        {
            WSService service = new WSService("https://apiseriesodu.azurewebsites.net/api/");
            Serie result = await service.GetSerieAsync("series", IdToFind);
            if (result == null)
                throw new Exception();
            //DisplayDialog("Erreur", "API non disponible !");
            else
                SerieSelected = result;
        }


        public void ActionViewSerie()
        {
            if (IdToFind == null)
            {
                throw new Exception();
                //DisplayDialog("Erreur", "Vous devez selectionner une devise !");
            }
            else
                GetSerieAsync();
        }
    }
}
