using System;
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

        internal void carregarMapa(MapaDominio objMapa)
        {
            if (objMapa == null)
            {
                return;
            }

            foreach (RpgDominioBase objDominio in objMapa.lstObjFilho)
            {
                if (objDominio == null)
                {
                    continue;
                }

                if (!(objDominio is CamadaDominio))
                {
                    return;
                }

                this.addCamada(objDominio as CamadaDominio);
            }
        }

        private void addCamada()
        {
            if (AppRpg.i.frmPrincipal.tabDockMapaSelecionado == null)
            {
                return;
            }

            CamadaDominio objCamada = new CamadaDominio();

            objCamada.attNome.strValor = "Camada desconhecida";

            AppRpg.i.frmPrincipal.tabDockMapaSelecionado.objMapa.addFilho(objCamada);

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