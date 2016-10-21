using System;
using DigoFramework;
using Rpg.Dominio;

namespace Rpg.Controle.Painel
{
    public partial class PnlItemCamada : PnlItemBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        #endregion Atributos

        #region Construtores

        public PnlItemCamada()
        {
            this.InitializeComponent();
        }

        #endregion Construtores

        #region Métodos

        private void processarClick()
        {
            if (this.objDominio == null)
            {
                return;
            }

            AppRpg.i.frmPrincipal.tabDockCamada.limparCamadaSelecao();

            this.booSelecionado = true;

            AppRpg.i.frmPrincipal.objDominioSelecionado = this.objDominio;

            this.processarClickMapaSelecionado();
        }

        private void processarClickMapaSelecionado()
        {
            if (AppRpg.i.frmPrincipal.tabDockMapaSelecionado == null)
            {
                return;
            }

            if (AppRpg.i.frmPrincipal.tabDockMapaSelecionado.objMapa == null)
            {
                return;
            }

            AppRpg.i.frmPrincipal.tabDockMapaSelecionado.objCamadaSelecioanda = (CamadaDominio)this.objDominio;
        }

        #endregion Métodos

        #region Eventos

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);

            try
            {
                this.processarClick();
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex);
            }
        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {
            try
            {
                this.processarClick();
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex);
            }
        }

        #endregion Eventos
    }
}