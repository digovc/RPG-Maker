using System.Drawing;
using Rpg.Dominio;

namespace Rpg.Controle.Editor.Grafico
{
    public class BackgroundGrafico : TileGrafico
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        #endregion Atributos

        #region Construtores

        public BackgroundGrafico(DisplayBase objDisplay, TileDominio objTile) : base(objDisplay, objTile)
        {
        }

        #endregion Construtores

        #region Métodos

        internal override void invalidar()
        {
            base.invalidar();

            this.objDisplay.Invalidate();
        }

        protected override Rectangle getRtgDestino()
        {
            return new Rectangle(0, 0, this.objDisplay.intTamanhoX, this.objDisplay.intTamanhoY);
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}