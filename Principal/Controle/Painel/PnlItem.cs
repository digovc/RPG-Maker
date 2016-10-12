using System;
using System.Windows.Forms;

namespace Rpg.Controle.Painel
{
    public partial class PnlItem : UserControl
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        #endregion Atributos

        #region Construtores

        public PnlItem()
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

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}