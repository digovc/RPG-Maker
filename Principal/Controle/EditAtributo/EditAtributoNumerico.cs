using System;
using DigoFramework;
using Rpg.Dominio;

namespace Rpg.Controle.EditAtributo
{
    public partial class EditAtributoNumerico : EditAtributoBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        #endregion Atributos

        #region Construtores

        public EditAtributoNumerico()
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

        private void atualizarStrValor()
        {
            if (this.att == null)
            {
                return;
            }

            if (string.IsNullOrEmpty(this.txtStrValor.Text))
            {
                this.txtStrValor.Text = null;
                return;
            }

            if (!Utils.getBooNumerico(this.txtStrValor.Text))
            {
                this.txtStrValor.Text = null;
                return;
            }

            if (this.att.intValorMaximo > 0 && (this.att.intValorMaximo < Convert.ToInt32(this.txtStrValor.Text)))
            {
                this.txtStrValor.Text = null;

                throw new Exception(string.Format("Valor inválido. O valor máximo permitido é de {0}", this.att.intValorMaximo));
            }

            this.atualizarStrValor(this.txtStrValor.Text);
        }

        #endregion Métodos

        #region Eventos

        private void txtStrValor_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.atualizarStrValor();
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex);
            }
        }

        #endregion Eventos
    }
}