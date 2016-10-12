using System.Windows.Forms;
using Rpg.Dominio;

namespace Rpg.Controle.EditAtributo
{
    public partial class EditAtributoBase : UserControl
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

            this.iniciar();
        }

        #endregion Construtores

        #region Métodos

        protected void atualizarStrValor(string strValor)
        {
            if (this.att == null)
            {
                return;
            }

            this.att.strValor = strValor;
        }

        protected virtual void finalizar()
        {
        }

        protected virtual void inicializar()
        {
            this.Dock = DockStyle.Top;
            this.Size = new System.Drawing.Size(350, 50);
        }

        protected virtual void montarLayout()
        {
        }

        protected virtual void setEventos()
        {
        }

        private void iniciar()
        {
            this.inicializar();
            this.montarLayout();
            this.setEventos();
            this.finalizar();
        }

        protected virtual void setAtt(Atributo att)
        {
            if (att == null)
            {
                return;
            }

            this.lblTitulo.Text = att.strNome;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}