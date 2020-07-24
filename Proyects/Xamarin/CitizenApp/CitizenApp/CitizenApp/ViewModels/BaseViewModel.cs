using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

using CitizenApp.Models;
using CitizenApp.Services.Interfaces;
using CitizenApp.Services.Services;
using CitizenApp.Services.DataStores;
using CitizenApp.Helper;

namespace CitizenApp.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        internal LocalidadService LocalidadService = new LocalidadService();
        internal IncidenciaService IncidenciaService => DependencyService.Get<IncidenciaService>() ?? new IncidenciaService();
        internal IPageService PageService => DependencyService.Get<MasterDetailPageService>() ?? new MasterDetailPageService();
        internal EntidadesMunicipalesService EntidadesMunicipalesService => DependencyService.Get<EntidadesMunicipalesService>() ?? new EntidadesMunicipalesService();

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        public double PageWidth
        {
            get { return Application.Current.MainPage.Width - 10; }
        }

        public double PageHeight
        {
            get { return Application.Current.MainPage.Height - 10; }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
