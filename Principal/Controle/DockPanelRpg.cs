using DigoFramework.Controle.DockPanel;

namespace Rpg.Controle
{
    public partial class DockPanelRpg : DockPanelBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        #endregion Atributos

        #region Construtores

        public DockPanelRpg()
        {
            this.InitializeComponent();
        }

        #endregion Construtores

        #region Métodos

        protected override void inicializar()
        {
            base.inicializar();

            this.Theme = new WeifenLuo.WinFormsUI.Docking.VS2013BlueTheme();
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}