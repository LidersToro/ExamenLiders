

namespace practica2.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    class MainViewModels
    {
        #region ViewModels
        public LoginViewModels Login
        {
            get;
            set;
        }
        public LandsViewModels Lands
        {
            get;
            set;
        }

        #endregion
        #region Constructores
        public MainViewModels()
        {
            this.Login = new LoginViewModels();
        }
        #endregion
        #region Singleton
        private static MainViewModels instance;
        public static MainViewModels GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModels();

            }
            return instance;
        }
        #endregion
    }
}
