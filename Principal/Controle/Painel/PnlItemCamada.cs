using System;
using DigoFramework;

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

            AppRpg.i.frmPrincipal.objDominioSelecionado = this.objDominio;
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