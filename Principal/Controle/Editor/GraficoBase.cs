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

        private void iniciar()
        {
            this.inicializar();
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}