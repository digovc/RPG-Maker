using System;
using DigoFramework;
using Rpg.Dominio;

namespace Rpg.Controle.EditAtributo
{
    public partial class EditAtributoTexto : EditAtributoBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        #endregion Atributos

        #region Construtores

        public EditAtributoTexto()
        {
            this.InitializeComponent();
        }

        #endregion Construtores

        #region Métodos

        protected override void setAtt(Atributo att)
        {
            base.setAtt(att);

            if (att == null)
            {
                return;
            }

            this.txtStrValor.ReadOnly = att.booSomenteLeitura;
            this.txtStrValor.Text = att.strValor;
        }

        #endregion Métodos

        #region Eventos

        private void txtStrValor_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.atualizarStrValor(this.txtStrValor.Text);
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex);
            }
        }

        #endregion Eventos
    }
}