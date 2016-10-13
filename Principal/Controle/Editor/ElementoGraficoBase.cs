namespace Rpg.Controle.Editor
{
    public abstract class ElementoGraficoBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        #endregion Atributos

        #region Construtores

        public ElementoGraficoBase()
        {
            this.iniciar();
        }

        #endregion Construtores

        #region Métodos

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