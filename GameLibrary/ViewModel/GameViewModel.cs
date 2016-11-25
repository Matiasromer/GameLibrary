using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Newtonsoft.Json;
using Windows.Storage;
using Windows.UI.Popups;

namespace GameLibrary.ViewModel
{
    class GameViewModel : INotifyPropertyChanged
    {
        public Model.obsGamesList Gameliste { get; set; }

        private Model.Game selectedGame;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }  
        }

        public Model.Game SelectedGame
        {
            get { return selectedGame; }
            set
            {
                selectedGame = value;
                OnPropertyChanged(nameof(SelectedGame));
            }
        }

        public AddGameCommand AddGameCommand { get; set; }

        public DeleteGameCommand DeleteGameCommand { get; set; }

        public Model.Game NewGame { get; set; }

        public SaveGameCommand SaveGameCommand  { get; set; }

        public HentDataCommand HentDataCommand { get; set; }
        //public string GetGamelistAsJson()
        //{
        //    string jsonText = JsonConvert.SerializeObject(Gameliste);
        //    return jsonText;
        //}

        StorageFolder localfolder = null;

        private readonly string filnavn = "Jsontext.json";

        public GameViewModel()
        {
            Gameliste = new Model.obsGamesList();
            AddGameCommand = new AddGameCommand(AddNewGame);
            NewGame = new Model.Game();
            DeleteGameCommand = new DeleteGameCommand(DeleteGame);
            SaveGameCommand = new SaveGameCommand(GemDataTilDiskAsnc);

            HentDataCommand = new HentDataCommand(HentdataFraDiscAsync);

            localfolder = ApplicationData.Current.LocalFolder;

            //AddGameCommand = new RelayCommand(AddNewGame,null);          


        }

        public async void HentdataFraDiscAsync()
        {
           
        try
            {
                this.Gameliste.Clear();
                StorageFile file = await localfolder.GetFileAsync(filnavn);
                string jsonText = await FileIO.ReadTextAsync(file);
                Gameliste.indsætJson(jsonText);
            }

        catch
            {
                MessageDialog messageDialog = new MessageDialog("Filnavn højst sandsynligt ændret eller der ikke er gemt");
                await messageDialog.ShowAsync();
            }
            
        }


        public async void GemDataTilDiskAsnc()
        {
            string JsonText = this.Gameliste.GetJson();
            StorageFile file = await localfolder.CreateFileAsync(filnavn, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(file, JsonText);
        }        

        public void AddNewGame()
        {
            Gameliste.Add(NewGame);
        }

        public void DeleteGame()
        {
            Gameliste.Remove(selectedGame);
        }

        //public RelayCommand AddGameCommand { get; set; }

    }
}
