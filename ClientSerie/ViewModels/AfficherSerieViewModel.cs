using ClientConvertisseurV2.Services;
using ClientSerie.Models.EntityFramework;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml.Controls;
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
        public IRelayCommand BtnUpdateSerie { get; }
        public IRelayCommand BtnDeleteSerie { get; }
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
            BtnUpdateSerie = new RelayCommand(ActionUpdateSerie);
            BtnDeleteSerie = new RelayCommand(ActionDeleteSerie);
        }
        private async void DisplayDialog(string title, string content)
        {
            ContentDialog dialog = new ContentDialog
            {
                Title = title,
                Content = content,
                CloseButtonText = "Ok"
            };
            dialog.XamlRoot = App.MainRoot.XamlRoot;
            ContentDialogResult result = await dialog.ShowAsync();
        }

        public async void GetSerieAsync()
        {
            WSService service = new WSService("https://apiseriesodu.azurewebsites.net/api/");
            Serie result = await service.GetSerieAsync("series", IdToFind);
            if (result == null)
                DisplayDialog("Erreur", "La série n'existe pas !");
            else
                SerieSelected = result;
        }
        public async void DeleteSerieAsync()
        {
            WSService service = new WSService("https://apiseriesodu.azurewebsites.net/api/");
            bool result = await service.DeleteSerieAsync("series", SerieSelected.Serieid);
            if (result == false)
                DisplayDialog("Erreur", "La série n'a pas été supprimé !");
            else
                DisplayDialog("Suppression effectué", "La série a été supprimé !");

        }
        public async void UpdateSerieAsync()
        {
            WSService service = new WSService("https://apiseriesodu.azurewebsites.net/api/");
            bool result = await service.PutSerieAsync("series/"+SerieSelected.Serieid, SerieSelected);
            if (result == false)
                DisplayDialog("Erreur", "Les données de la série n'ont pas été modifié !");
            else
                DisplayDialog("Modification effectué", "Les données de la série ont été modifié !");
        }


        public void ActionViewSerie()
        {
            if (IdToFind == 0)
            {
                DisplayDialog("Erreur", "Entrer l'id de la serie que vous souhaitez visualiser");
            }
            else
                GetSerieAsync();
        }
        public void ActionUpdateSerie()
        {
            if (IdToFind == 0)
            {
                DisplayDialog("Erreur", "Entrer l'id de la serie que vous souhaitez modifier");
            }
            else
                UpdateSerieAsync();
        }
        public void ActionDeleteSerie()
        {
            if (IdToFind == 0)
            {
                DisplayDialog("Erreur", "Entrer l'id de la serie que vous souhaitez supprimer");
            }
            else
                DeleteSerieAsync();
        }
    }
}
