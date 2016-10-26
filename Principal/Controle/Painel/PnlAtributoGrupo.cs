using System;
using System.Collections.Generic;
using DigoFramework;
using Rpg.Controle.EditAtributo;
using Rpg.Dominio;

namespace Rpg.Controle.Painel
{
    public partial class PnlAtributoGrupo : UserControlRpgBase
    {
        #region Constantes

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

        internal void atualizarLayout(string strGrupo, List<Atributo> lstAttGrupo)
        {
            if (string.IsNullOrEmpty(strGrupo))
            {
                return;
            }

            if (lstAttGrupo == null)
            {
                return;
            }

            this.lstAttGrupo = lstAttGrupo;

            this.Height = 15;

            this.pnlTitulo.strTitulo = strGrupo;
            this.pnlConteudo.Height = 0;

            foreach (Atributo att in lstAttGrupo)
            {
                this.atualizarLayout(att);
            }
        }

        protected override void inicializar()
        {
            base.inicializar();

            this.Dock = System.Windows.Forms.DockStyle.Top;
        }

        protected override void setEventos()
        {
            base.setEventos();

            this.pnlTitulo.onStrTituloAlterado += this.pnlTitulo_onStrTituloAlterado;
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

            this.Controls.Add(edtAtt);
            this.Controls.SetChildIndex(edtAtt, 0);

            this.Height += edtAtt.Height;

            this.pnlConteudo.Height += edtAtt.Height;
        }

        private void atualizarLayout(Atributo att)
        {
            if (att == null)
            {
                return;
            }

            EditAtributoBase edtAtt = this.getEdtAtt(att.enmTipo);

            edtAtt.att = att;

            this.addEdtAtt(edtAtt);
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
                case Atributo.EnmTipo.ALCANCE:
                    return new EditAtributoAlcance();

                case Atributo.EnmTipo.BOOLEAN:
                    return new EditAtributoBoolen();

                case Atributo.EnmTipo.NUMERICO:
                    return new EditAtributoNumerico();

                default:
                    return new EditAtributoTexto();
            }
        }

        #endregion Métodos

        #region Eventos

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