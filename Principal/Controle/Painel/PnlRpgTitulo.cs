using System;
using System.Windows.Forms;
using DigoFramework;

namespace Rpg.Controle.Painel
{
    public partial class PnlRpgTitulo : UserControl
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private bool _booTituloFixo = true;
        private string _strTitulo;

        public bool booTituloFixo
        {
            get
            {
                return _booTituloFixo;
            }

            set
            {
                _booTituloFixo = value;
            }
        }

        public string strTitulo
        {
            get
            {
                return _strTitulo = this.lblTitulo.Text;
            }

            set
            {
                if (_strTitulo == value)
                {
                    return;
                }

                _strTitulo = value;

                this.setStrTitulo(_strTitulo);
            }
        }

        #endregion Atributos

        #region Construtores

        public PnlRpgTitulo()
        {
            this.InitializeComponent();
        }

        #endregion Construtores

        #region Métodos

        private void alterarNome()
        {
            if (!this.booTituloFixo)
            {
                return;
            }

            this.lblTitulo.Visible = false;

            this.txtTitulo.Text = this.lblTitulo.Text;

            this.txtTitulo.Visible = true;

            this.txtTitulo.SelectAll();
            this.txtTitulo.Focus();
        }

        private void salvarTitulo(KeyEventArgs arg)
        {
            if (!Keys.Enter.Equals(arg.KeyCode))
            {
                return;
            }

            this.salvarTitulo();
        }

        private void salvarTitulo()
        {
            if (!string.IsNullOrEmpty(this.txtTitulo.Text))
            {
                this.strTitulo = this.txtTitulo.Text;
            }

            this.lblTitulo.Visible = true;
            this.txtTitulo.Visible = false;
        }

        private void setStrTitulo(string strTitulo)
        {
            this.lblTitulo.Text = strTitulo;

            this.onStrTituloAlterado?.Invoke(this, EventArgs.Empty);
        }

        #endregion Métodos

        #region Eventos

        private void lblTitulo_Click(object sender, EventArgs e)
        {
            try
            {
                this.alterarNome();
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex);
            }
        }

        private void txtTitulo_Click(object sender, EventArgs e)
        {
            try
            {
                this.salvarTitulo();
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex);
            }
        }

        private void txtTitulo_KeyUp(object sender, KeyEventArgs arg)
        {
            try
            {
                this.salvarTitulo(arg);
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex);
            }
        }

        private void txtTitulo_Leave(object sender, EventArgs e)
        {
            try
            {
                this.salvarTitulo();
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex);
            }
        }

        public event EventHandler onStrTituloAlterado;

        #endregion Eventos
    }
}