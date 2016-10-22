using System;
using System.Drawing;
using DigoFramework;
using Rpg.Dominio;

namespace Rpg.Controle.EditAtributo
{
    public partial class EditAtributoAlcance : EditAtributoBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        #endregion Atributos

        #region Construtores

        public EditAtributoAlcance()
        {
            this.InitializeComponent();
        }

        #endregion Construtores

        #region Métodos

        private void atualizarLayout()
        {
            if (string.IsNullOrEmpty(this.att.strValor))
            {
                return;
            }

            if (this.att.strValor.Contains(";"))
            {
                return;
            }

            string[] arrStrTermo = this.att.strValor.Split(';');

            if (arrStrTermo == null)
            {
                return;
            }

            if (arrStrTermo.Length < 2)
            {
                return;
            }

            if (!Utils.getBooNumerico(arrStrTermo[0]))
            {
                arrStrTermo[0] = "0";
            }

            if (!Utils.getBooNumerico(arrStrTermo[1]))
            {
                arrStrTermo[0] = "10";
            }

            int intValor = Convert.ToInt32(arrStrTermo[0]);
            int intValorMaximo = Convert.ToInt32(arrStrTermo[0]);

            this.atualizarLayout(intValor, intValorMaximo);
        }

        private void atualizarLayout(int intValor, int intValorMaximo)
        {
            if (intValor > intValorMaximo)
            {
                intValor = 0;
                intValorMaximo = 100;
            }

            int r = (int)(this.pnlProgressBar.Width - this.pnlProgressBar.Width * ((decimal)intValor / (decimal)intValorMaximo));

            this.pnlProgressBar.Padding = new System.Windows.Forms.Padding(0, 0, r, 0);
            this.pnlProgressBarValor.BackColor = this.getCorProgresso(intValor, intValorMaximo);
        }

        private void atualizarStrValor()
        {
            if (!Utils.getBooNumerico(this.txtStrValor.Text))
            {
                this.txtStrValor.Text = null;
                return;
            }

            if (!Utils.getBooNumerico(this.txtStrValorMaximo.Text))
            {
                this.txtStrValorMaximo.Text = null;
                return;
            }

            int intValor = Convert.ToInt32(this.txtStrValor.Text);
            int intValorMaximo = Convert.ToInt32(this.txtStrValorMaximo.Text);

            this.atualizarStrValor(string.Format("{0};{1}", intValor, intValorMaximo));

            this.atualizarLayout(intValor, intValorMaximo);
        }

        private Color getCorProgresso(int intValor, int intValorMaximo)
        {
            double x = ((double)intValor / (double)intValorMaximo);

            return Color.FromArgb((int)(255 * (1 - x)), (int)(255 * x), 0);
        }

        protected override void setAtt(Atributo att)
        {
            base.setAtt(att);

            if (att == null)
            {
                return;
            }

            this.atualizarLayout();
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

        private void txtStrValorMaximo_TextChanged(object sender, System.EventArgs e)
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