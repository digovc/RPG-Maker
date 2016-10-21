using System;
using System.Windows.Forms;
using DigoFramework;
using Rpg.Controle.Painel;
using Rpg.Dominio;

namespace Rpg.Controle.TabDock
{
    public partial class TabDockCamada : TabDockRpgBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private MapaDominio _objMapa;

        internal MapaDominio objMapa
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

        public TabDockCamada()
        {
            this.InitializeComponent();
        }

        #endregion Construtores

        #region Métodos

        internal void limparCamadaSelecao()
        {
            if (this.pnlConteudo.Controls == null)
            {
                return;
            }

            foreach (Control ctr in this.pnlConteudo.Controls)
            {
                if (!(ctr is PnlItemCamada))
                {
                    continue;
                }

                (ctr as PnlItemCamada).booSelecionado = false;
            }
        }

        private void addCamada()
        {
            if (AppRpg.i.frmPrincipal.tabDockMapaSelecionado == null)
            {
                return;
            }

            if (AppRpg.i.frmPrincipal.tabDockMapaSelecionado.objMapa == null)
            {
                return;
            }

            CamadaDominio objCamada = CamadaDominio.criar(AppRpg.i.frmPrincipal.tabDockMapaSelecionado.objMapa.lstObjCamada.Count);

            AppRpg.i.frmPrincipal.tabDockMapaSelecionado.objMapa.addCamada(objCamada);

            this.addCamada(objCamada);
        }

        private void addCamada(CamadaDominio objCamada)
        {
            if (objCamada == null)
            {
                return;
            }

            PnlItemCamada pnlItemCamada = new PnlItemCamada();

            pnlItemCamada.objDominio = objCamada;

            this.pnlConteudo.Controls.Add(pnlItemCamada);
        }

        private void setObjMapa(MapaDominio objMapa)
        {
            this.pnlConteudo.Controls.Clear();

            if (objMapa == null)
            {
                return;
            }

            foreach (CamadaDominio objCamada in objMapa.lstObjCamada)
            {
                this.setObjMapa(objMapa, objCamada);
            }
        }

        private void setObjMapa(MapaDominio objMapa, CamadaDominio objCamada)
        {
            if (objCamada == null)
            {
                return;
            }

            this.addCamada(objCamada);
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