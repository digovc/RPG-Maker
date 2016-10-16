using System;
using System.Drawing;

namespace Rpg.Controle.Editor
{
    public abstract class GraficoBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private DisplayBase _objDisplay;

        protected DisplayBase objDisplay
        {
            get
            {
                return _objDisplay;
            }

            set
            {
                _objDisplay = value;
            }
        }

        #endregion Atributos

        #region Construtores

        public GraficoBase(DisplayBase objDisplay)
        {
            this.objDisplay = objDisplay;

            this.iniciar();
        }

        #endregion Construtores

        #region Métodos

        internal virtual void renderizar(Graphics gpc)
        {
        }

        protected virtual void inicializar()
        {
        }

        protected virtual void invalidar()
        {
        }

        protected virtual void setEventos()
        {
            this.objDisplay.onMoveX += this.objDisplay_onMoveX;
            this.objDisplay.onMoveY += this.objDisplay_onMoveY;
        }

        private void iniciar()
        {
            this.inicializar();
            this.setEventos();
        }

        #endregion Métodos

        #region Eventos

        private void objDisplay_onMoveX(object sender, EventArgs e)
        {
            this.invalidar();
        }

        private void objDisplay_onMoveY(object sender, EventArgs e)
        {
            this.invalidar();
        }

        #endregion Eventos
    }
}