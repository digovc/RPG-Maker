using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DigoFramework;
using Rpg.Controle.Painel;
using Rpg.Dominio;

namespace Rpg.Controle.EditAtributo
{
    public partial class EditAtributoBase : UserControlRpgBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private Atributo _att;
        private PnlAtributoGrupo _pnlGrupo;

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

        public PnlAtributoGrupo pnlGrupo
        {
            get
            {
                return _pnlGrupo;
            }

            set
            {
                _pnlGrupo = value;
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

        internal void destruir()
        {
            this.att = null;
            this.Dispose();
        }

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
        }

        protected virtual void setAtt(Atributo att)
        {
            if (att == null)
            {
                return;
            }

            this.pnlTitulo.booTituloFixo = att.booFixo;
            this.pnlTitulo.strTitulo = att.strNome;

            att.onStrValorAlterado += this.att_onStrValorAlterado;
        }

        protected override void setEventos()
        {
            base.setEventos();

            this.pnlTitulo.onStrTituloAlterado += this.pnlTitulo_onStrTituloAlterado;
        }

        private void alterarTipo(Atributo.EnmTipo enmTipo)
        {
            if (this.att == null)
            {
                return;
            }

            if (this.att.booFixo)
            {
                throw new Exception("Atributo fixo não pode ser alterado.");
            }

            this.att.enmTipo = enmTipo;

            this.pnlGrupo.atualizarAtributo(this);
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

        private void att_onStrValorAlterado(object sender, string strValor)
        {
            try
            {
                this.atualizarCtrValor(strValor);
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex);
            }
        }

        private void btnAlterarNome_Click(object sender, EventArgs e)
        {
            try
            {
                this.pnlTitulo.alterarNome();
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex);
            }
        }

        private void btnAlterarTipo_Click(object sender, EventArgs e)
        {
            try
            {
                this.cmsAlterarTipo.Show(Cursor.Position.X, Cursor.Position.Y);
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

        private void tsmTipoAlfanumerico_Click(object sender, EventArgs e)
        {
            try
            {
                this.alterarTipo(Atributo.EnmTipo.ALFANUMERICO);
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex);
            }
        }

        private void tsmTipoBoolean_Click(object sender, EventArgs e)
        {
            try
            {
                this.alterarTipo(Atributo.EnmTipo.BOOLEAN);
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex);
            }
        }

        private void tsmTipoFaixa_Click(object sender, EventArgs e)
        {
            try
            {
                this.alterarTipo(Atributo.EnmTipo.FAIXA);
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex);
            }
        }

        private void tsmTipoNumerico_Click(object sender, EventArgs e)
        {
            try
            {
                this.alterarTipo(Atributo.EnmTipo.NUMERICO);
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex);
            }
        }

        #endregion Eventos
    }
}