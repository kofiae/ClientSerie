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
    public class AjoutSerieViewModel : ObservableObject, INotifyPropertyChanged
    {
        #region properties
        public event PropertyChangedEventHandler PropertyChanged;
        private Serie serieToAdd;
        public IRelayCommand BtnAddSerie { get; }


        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        public Serie SerieToAdd
        {
            get
            {
                return serieToAdd;
            }

            set
            {
                serieToAdd = value;
                OnPropertyChanged(nameof(SerieToAdd));
            }
        }
        #endregion

        public AjoutSerieViewModel()
        {
            serieToAdd = new Serie();

            //Boutons
            BtnAddSerie = new RelayCommand(ActionAddSerie);
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

        public async void AddSerieAsync()
        {
            WSService service = new WSService("https://apiseriesodu.azurewebsites.net/api/");
            bool result = await service.PostSerieAsync("series", SerieToAdd);
            if (result == false)
                DisplayDialog("Erreur", "La série n'a pas pu être ajouté");
            else
                DisplayDialog("Série ajouté", "La série a été ajouté");
        }

        public void ActionAddSerie()
        {
                AddSerieAsync();
        }
    }
}
