using System;
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
            this.Size = new System.Drawing.Size(350, 50);
        }

        protected virtual void setAtt(Atributo att)
        {
            if (att == null)
            {
                return;
            }

            this.lblTitulo.Text = att.strNome;

            att.onStrValorAlterado += att_onStrValorAlterado;
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

        #endregion Eventos
    }
}