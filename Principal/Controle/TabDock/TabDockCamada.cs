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

        private void setObjMapa(MapaDominio objMapa)
        {
            if (objMapa == null)
            {
                return;
            }

            foreach (RpgDominioBase objDominio in objMapa.lstObjFilho)
            {
                this.setObjMapa(objMapa, objDominio);
            }
        }

        private void setObjMapa(MapaDominio objMapa, RpgDominioBase objDominio)
        {
            if (objDominio == null)
            {
                return;
            }

            if (!(objDominio is CamadaDominio))
            {
                return;
            }

            this.addCamada(objDominio as CamadaDominio);
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