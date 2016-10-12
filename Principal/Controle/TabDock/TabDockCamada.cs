using System;
using DigoFramework;

namespace Rpg.Controle.TabDock
{
    public partial class TabDockCamada : TabDockRpgBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private TabDockMapa _tabDockMapa;

        public TabDockMapa tabDockMapa
        {
            get
            {
                return _tabDockMapa;
            }

            set
            {
                _tabDockMapa = value;
            }
        }

        #endregion Atributos

        #region Construtores

        public TabDockCamada()
        {
            this.InitializeComponent();
        }

        #endregion Construtores

        #region Métodos

        private void addCamada()
        {
        }

        #endregion Métodos

        #region Eventos

        private void btnAddCamada_Click(object sender, EventArgs e)
        {
            try
            {
                this.addCamada();
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex);
            }
        }

        #endregion Eventos
    }
}