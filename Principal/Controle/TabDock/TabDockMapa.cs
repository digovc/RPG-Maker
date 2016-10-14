using System;
using DigoFramework;
using Rpg.Dominio;

namespace Rpg.Controle.TabDock
{
    public partial class TabDockMapa : TabDockRpgBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private MapaDominio _objMapa;

        public MapaDominio objMapa
        {
            get
            {
                return _objMapa;
            }

            set
            {
                if (_objMapa == value)
                {
                    return;
                }

                _objMapa = value;

                this.setObjMapa(_objMapa);
            }
        }

        #endregion Atributos

        #region Construtores

        public TabDockMapa()
        {
            this.InitializeComponent();
        }

        #endregion Construtores

        #region Métodos

        private void carregarMapa()
        {
            this.ctrDisplay.objMapa = this.objMapa;
        }

        private void processarEnter()
        {
            AppRpg.i.frmPrincipal.tabDockMapaSelecionado = this;
        }

        private void setObjMapa(MapaDominio objMapa)
        {
            if (objMapa == null)
            {
                return;
            }

            this.Text = this.objMapa.attNome.strValor;

            this.carregarMapa();
        }

        #endregion Métodos

        #region Eventos

        private void TabDockMapa_Enter(object sender, EventArgs e)
        {
            try
            {
                this.processarEnter();
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex);
            }
        }

        #endregion Eventos
    }
}