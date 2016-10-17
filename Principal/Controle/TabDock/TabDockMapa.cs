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

        private CamadaDominio _objCamadaSelecioanda;
        private MapaDominio _objMapa;

        public CamadaDominio objCamadaSelecioanda
        {
            get
            {
                return _objCamadaSelecioanda;
            }

            set
            {
                if (_objCamadaSelecioanda == value)
                {
                    return;
                }

                _objCamadaSelecioanda = value;

                this.setObjCamadaSelecioanda(_objCamadaSelecioanda);
            }
        }

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

        private void setObjCamadaSelecioanda(CamadaDominio objCamadaSelecioanda)
        {
            this.ctrDisplay.objCamadaSelecionada = objCamadaSelecioanda;
        }

        private void setObjMapa(MapaDominio objMapa)
        {
            if (objMapa == null)
            {
                return;
            }

            this.Text = this.objMapa.attStrNome.strValor;

            this.carregarMapa();
        }

        #endregion Métodos

        #region Eventos

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);

            try
            {
                AppRpg.i.frmPrincipal.tabDockMapaSelecionado = this;
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex);
            }
        }

        #endregion Eventos
    }
}