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
            base.inicializar();

            this.Dock = DockStyle.Top;
            this.Size = new Size(350, 60);
        }

        protected virtual void setAtt(Atributo att)
        {
            if (att == null)
            {
                return;
            }

            this.pnlTitulo.booTituloFixo = att.booNomeFixo;
            this.pnlTitulo.strTitulo = att.strNome;

            att.onStrValorAlterado += this.att_onStrValorAlterado;
        }

        protected override void setEventos()
        {
            base.setEventos();

            this.pnlTitulo.onStrTituloAlterado += this.pnlTitulo_onStrTituloAlterado;
        }

        private void atualizarAttStrNome()
        {
            if (this.att == null)
            {
                return;
            }

            this.att.strNome = this.pnlTitulo.strTitulo;
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

        private void pnlTitulo_onStrTituloAlterado(object sender, EventArgs e)
        {
            try
            {
                this.atualizarAttStrNome();
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex);
            }
        }

        #endregion Eventos
    }
}