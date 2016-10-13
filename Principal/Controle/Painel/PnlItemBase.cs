using System.Windows.Forms;
using Rpg.Dominio;

namespace Rpg.Controle.Painel
{
    public partial class PnlItemBase : UserControl
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private RpgDominioBase _objDominio;

        public RpgDominioBase objDominio
        {
            get
            {
                return _objDominio;
            }

            set
            {
                if (_objDominio == value)
                {
                    return;
                }

                _objDominio = value;

                this.setObjDominio(_objDominio);
            }
        }

        #endregion Atributos

        #region Construtores

        public PnlItemBase()
        {
            this.InitializeComponent();

            this.iniciar();
        }

        #endregion Construtores

        #region Métodos

        protected virtual void finalizar()
        {
        }

        protected virtual void inicializar()
        {
            this.Dock = DockStyle.Top;
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

        private void setObjDominio(RpgDominioBase objDominio)
        {
            if (objDominio == null)
            {
                return;
            }

            this.lblTitulo.Text = objDominio.attNome.strValor;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}