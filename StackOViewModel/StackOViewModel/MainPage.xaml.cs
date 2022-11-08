using Firebase.Database;
using Firebase.Database.Query;
using StackOViewModel.Models;
using StackOViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace StackOViewModel
{
    public partial class MainPage : ContentPage
    {
     
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
       
        }

       
        }
      
        
    }

