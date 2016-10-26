using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DigoFramework;
using Rpg.Dominio;

namespace Rpg.Controle.EditAtributo
{
    public partial class EditAtributoBase : UserControlRpgBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private Atributo _att;

        public Atributo att
        {
            get
            {
                return _att;
            }

            set
            {
                if (_att == value)
                {
                    return;
                }

                _att = value;

                this.setAtt(_att);
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Size Size
        {
            get
            {
                return base.Size;
            }

            private set
            {
                base.Size = value;
            }
        }

        #endregion Atributos

        #region Construtores

        public EditAtributoBase()
        {
            this.InitializeComponent();
        }

        #endregion Construtores

        #region Métodos

        protected virtual void atualizarCtrValor(string strValor)
        {
        }

        protected void atualizarStrValor(string strValor)
        {
            if (this.att == null)
            {
                return;
            }

            this.att.strValor = strValor;
        }

        protected override void inicializar()
        {
            this.Dock = DockStyle.Top;
            this.Size = new Size(350, 60);
        }

        protected virtual void setAtt(Atributo att)
        {
            if (att == null)
            {
                return;
            }

            this.lblTitulo.Text = att.strNome;

            att.onStrValorAlterado += this.att_onStrValorAlterado;
        }

        private void alterarNome()
        {
            if (this.att == null)
            {
                return;
            }

            if (this.att.booNomeFixo)
            {
                return;
            }

            this.lblTitulo.Visible = false;

            this.txtTitulo.Text = this.lblTitulo.Text;

            this.txtTitulo.Visible = true;

            this.txtTitulo.SelectAll();
            this.txtTitulo.Focus();
        }

        private void bloquear()
        {
            if (this.att == null)
            {
                return;
            }

            this.att.booBloqueado = !this.att.booBloqueado;
        }

        private void jogadorBloquear()
        {
            if (this.att == null)
            {
                return;
            }

            this.att.booJogadorBloqueado = !this.att.booJogadorBloqueado;
        }

        private void jogadorVisivel()
        {
            if (this.att == null)
            {
                return;
            }

            this.att.booJogadorVisivel = !this.att.booJogadorVisivel;
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
            if (this.att == null)
            {
                return;
            }

            if (!string.IsNullOrEmpty(this.txtTitulo.Text))
            {
                this.att.strNome = this.txtTitulo.Text;
            }

            this.lblTitulo.Text = this.att.strNome;
            this.lblTitulo.Visible = true;

            this.txtTitulo.Visible = false;
        }

        #endregion Métodos

        #region Eventos

        private void att_onStrValorAlterado(object sender, EventArgs e)
        {
            try
            {
                this.atualizarCtrValor(att.strValor);
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex);
            }
        }

        private void btnBloquear_Click(object sender, EventArgs e)
        {
            try
            {
                this.bloquear();
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex);
            }
        }

        private void btnJogadorBloquear_Click(object sender, EventArgs e)
        {
            try
            {
                this.jogadorBloquear();
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex);
            }
        }

        private void btnJogadorVisivel_Click(object sender, EventArgs e)
        {
            try
            {
                this.jogadorVisivel();
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

        #endregion Eventos
    }
}