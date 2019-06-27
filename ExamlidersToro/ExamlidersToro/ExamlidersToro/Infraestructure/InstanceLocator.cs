

namespace ExamlidersToro.Infraestructure
{
    using ExamlidersToro.ViewModels;
    class InstanceLocator
    {
        #region Propiedades
        public MainViewModels Main
        {
            get;
          set;
        }
        #endregion
        #region Constructor
        public InstanceLocator()
        {
            this.Main = new MainViewModels();
        }
        #endregion
    }
}
