namespace practica2.ViewModels

{
    
    using Models;
    using Services;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Xamarin.Forms;

    class LandsViewModels : BaseViewModel
    {
        #region ApiServices
        private ApiService apiService;
        #endregion
        #region Atributos
        private ObservableCollection<Land> lands;
        private bool isRefreshing;
        #endregion
        #region Propiedades
        public ObservableCollection<Land> Lands
        {
            get { return this.lands; }
            set { SetValue(ref this.lands, value); }
        }
        public bool IsRefreshing { 
            get { return this.isRefreshing; }
            set { SetValue(ref this.isRefreshing, value); }
        }
        #endregion
        #region Constructors
        public LandsViewModels()
        {
            this.apiService = new ApiService();
            this.LoadLands();
        }
        #endregion
        #region Methods
        private  async void LoadLands()
        {
            this.IsRefreshing = true;
            var connetion = await this.apiService.CheckConnection();

            if (!connetion.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    connetion.Message,
                    "Aceptar");
                await Application.Current.MainPage.Navigation.PopAsync();
                return;
            }
            var response = await this.apiService.GetList<Land>(
                "https://restcountries.eu",
                "/rest",
                "/v2/all");
            if (response.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Mensaje",
                    response.Message,
                    "Aceptar");
                return;
            }

            var list = (List<Land>)response.Result;
            this.Lands = new  ObservableCollection<Land>(list);
            this.IsRefreshing = false;
        }
        #endregion

    }
}
