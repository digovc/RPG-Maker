using System.Collections.Generic;
using Rpg.Controle.EditAtributo;
using Rpg.Dominio;

namespace Rpg.Controle.Painel
{
    public partial class PnlAttGrupo : UserControlRpgBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        #endregion Atributos

        #region Construtores

        public PnlAttGrupo()
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

            this.Height = 15;

            this.lblTitulo.Text = strGrupo;
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

        #endregion Eventos
    }
}