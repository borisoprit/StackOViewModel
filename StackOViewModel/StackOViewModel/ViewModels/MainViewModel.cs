using Firebase.Database;
using StackOViewModel.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace StackOViewModel.ViewModels
{
    public class MainViewModel
    {

        FirebaseClient firebaseClient = new FirebaseClient("https://stackotest-default-rtdb.europe-west1.firebasedatabase.app/");
        public ObservableCollection<Fotos> Foto { get; set; } = new ObservableCollection<Fotos>();


        public ICommand LoadDataCommand { get; }


        public object AllFotos { get; private set; }

        private ObservableCollection<Fotos> _items;
        public ObservableCollection<Fotos> Items
        {
            get { return _items; }
            set { SetProperty(ref _items, value); }
        }
    

    public async Task<List<Fotos>> GetAllFotos()
        {
            return (await firebaseClient
              .Child("Foto/")
              .OnceAsync<Fotos>()).Select(item => new Fotos
              {
                  BalId = item.Object.BalId,
                  RollNo = item.Object.RollNo,
                  Foto = item.Object.Foto,
                  Titel = item.Object.Titel,
                  Fototekst = item.Object.Fototekst
              }).ToList();
        }
        private async Task LoadData()
        {
          ////  AllFotos = await firebaseClient.GetAllFotos(); /////   Error with GetAllFotos 
        }


        public MainViewModel()
        {
            LoadDataCommand = new Command(async () => await LoadData());
          
        }
        private void SetProperty(ref ObservableCollection<Fotos> items, ObservableCollection<Fotos> value)
        {
            throw new NotImplementedException();
        }


    }
}
