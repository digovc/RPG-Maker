using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DigoFramework;
using Rpg.Controle.EditAtributo;
using Rpg.Dominio;

namespace Rpg.Controle.Painel
{
    public partial class PnlAtributoGrupo : UserControlRpgBase
    {
        #region Constantes

        private const int INT_HEIGHT_DEFAUL = 20;

        #endregion Constantes

        #region Atributos

        private List<Atributo> _lstAttGrupo;

        private List<Atributo> lstAttGrupo
        {
            get
            {
                return _lstAttGrupo;
            }

            set
            {
                _lstAttGrupo = value;
            }
        }

        #endregion Atributos

        #region Construtores

        public PnlAtributoGrupo()
        {
            this.InitializeComponent();
        }

        #endregion Construtores

        #region Métodos

        internal void atualizarAtributo(EditAtributoBase edtAtt)
        {
            if (edtAtt == null)
            {
                return;
            }

            if (!this.pnlConteudo.Controls.Contains(edtAtt))
            {
                return;
            }

            EditAtributoBase edtAttNovo = this.atualizarLayout(edtAtt.att);

            int intIndex = this.pnlConteudo.Controls.IndexOf(edtAtt);

            try
            {
                this.SuspendLayout();

                this.pnlConteudo.Controls.Remove(edtAtt);

                this.pnlConteudo.Controls.SetChildIndex(edtAttNovo, intIndex);
            }
            finally
            {
                this.ResumeLayout();
            }

            edtAtt.Dispose();
        }

        internal void atualizarLayout(string strGrupo, List<Atributo> lstAttGrupo)
        {
            this.SuspendLayout();

            if (string.IsNullOrEmpty(strGrupo))
            {
                return;
            }

            if (lstAttGrupo == null)
            {
                return;
            }

            this.lstAttGrupo = lstAttGrupo;

            this.pnlTitulo.strTitulo = strGrupo;

            foreach (Atributo att in lstAttGrupo)
            {
                this.atualizarLayout(att);
            }

            this.ResumeLayout();
        }

        protected override void inicializar()
        {
            base.inicializar();

            this.Dock = DockStyle.Top;
        }

        protected override void setEventos()
        {
            base.setEventos();

            this.pnlTitulo.onStrTituloAlterado += this.pnlTitulo_onStrTituloAlterado;
        }

        private void abrirFecharGrupo()
        {
            this.pnlConteudo.Visible = !this.pnlConteudo.Visible;
        }

        private void addEdtAtt(EditAtributoBase edtAtt)
        {
            if (edtAtt == null)
            {
                return;
            }

            if (this.Controls.Contains(edtAtt))
            {
                return;
            }

            this.pnlConteudo.Controls.Add(edtAtt);
            this.pnlConteudo.Controls.SetChildIndex(edtAtt, 0);
        }

        private EditAtributoBase atualizarLayout(Atributo att)
        {
            if (att == null)
            {
                return null;
            }

            EditAtributoBase edtAtt = this.getEdtAtt(att.enmTipo);

            edtAtt.att = att;
            edtAtt.pnlGrupo = this;

            this.addEdtAtt(edtAtt);

            return edtAtt;
        }

        private void atualizarStrGrupo()
        {
            if (string.IsNullOrEmpty(this.pnlTitulo.strTitulo))
            {
                return;
            }

            if (this.lstAttGrupo == null)
            {
                return;
            }

            this.lstAttGrupo.ForEach((att) => att.strGrupo = this.pnlTitulo.strTitulo);
        }

        private EditAtributoBase getEdtAtt(Atributo.EnmTipo enmTipo)
        {
            switch (enmTipo)
            {
                case Atributo.EnmTipo.FAIXA:
                    return new EditAtributoAlcance();

                case Atributo.EnmTipo.BOOLEAN:
                    return new EditAtributoBoolen();

                case Atributo.EnmTipo.NUMERICO:
                    return new EditAtributoNumerico();

                default:
                    return new EditAtributoAlfanumerico();
            }
        }

        private int getIntPnlConteudoHeight()
        {
            int intResultado = 0;

            foreach (Control edtAtt in this.pnlConteudo.Controls)
            {
                intResultado += edtAtt.Size.Height;
            }

            return intResultado;
        }

        #endregion Métodos

        #region Eventos

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

        private void btnVisivel_Click(object sender, EventArgs e)
        {
            try
            {
                this.abrirFecharGrupo();
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
                this.atualizarStrGrupo();
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex);
            }
        }

        #endregion Eventos
    }
}