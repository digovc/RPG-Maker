using System.Drawing;

namespace Rpg.Controle.Editor
{
    public class GridGrafico : GraficoBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private SolidBrush _objBrush;
        private Pen _pen;
        private Pen _penBorda;

        private SolidBrush objBrush
        {
            get
            {
                if (_objBrush != null)
                {
                    return _objBrush;
                }

                _objBrush = new SolidBrush(Color.LightGray);

                return _objBrush;
            }
        }

        private Pen penBorda
        {
            get
            {
                if (_penBorda != null)
                {
                    return _penBorda;
                }

                _penBorda = new Pen(new SolidBrush(Color.Gray));

                return _penBorda;
            }
        }

        private Pen penBordaTile
        {
            get
            {
                if (_pen != null)
                {
                    return _pen;
                }

                _pen = new Pen(this.objBrush);

                return _pen;
            }
        }

        #endregion Atributos

        #region Construtores

        public GridGrafico(DisplayBase objDisplay) : base(objDisplay)
        {
        }

        #endregion Construtores

        #region Métodos

        internal override void renderizar(Graphics gpc)
        {
            base.renderizar(gpc);

            this.renderizarTile(gpc);
            this.renderizarBorda(gpc);
        }

        protected override void inicializar()
        {
            base.inicializar();

            this.penBordaTile.DashPattern = new float[] { 5, 10 };
        }

        private void renderizarBorda(Graphics gpc)
        {
            int w = (this.objDisplay.intQuantidadeX * (this.objDisplay.intTileTamanho + (this.objDisplay.intZoom * DisplayBase.INT_ZOOM_INCREMENTO)));
            int h = (this.objDisplay.intQuantidadeY * (this.objDisplay.intTileTamanho + (this.objDisplay.intZoom * DisplayBase.INT_ZOOM_INCREMENTO)));

            gpc.DrawRectangle(this.penBorda, new Rectangle(this.objDisplay.intMoveX, this.objDisplay.intMoveY, w, h));
        }

        private void renderizarTile(Graphics gpc)
        {
            for (int x = 0; x < this.objDisplay.intQuantidadeX; x++)
            {
                for (int y = 0; y < this.objDisplay.intQuantidadeY; y++)
                {
                    this.renderizarBordaTile(gpc, x, y);
                }
            }
        }

        private void renderizarBordaTile(Graphics gpc, int x, int y)
        {
            x = (x * this.objDisplay.intTileTamanho + this.objDisplay.intMoveX + (x * this.objDisplay.intZoom * DisplayBase.INT_ZOOM_INCREMENTO));
            y = (y * this.objDisplay.intTileTamanho + this.objDisplay.intMoveY + (y * this.objDisplay.intZoom * DisplayBase.INT_ZOOM_INCREMENTO));

            int w = (this.objDisplay.intTileTamanho + (this.objDisplay.intZoom * DisplayBase.INT_ZOOM_INCREMENTO));
            int h = (this.objDisplay.intTileTamanho + (this.objDisplay.intZoom * DisplayBase.INT_ZOOM_INCREMENTO));

            gpc.DrawRectangle(this.penBordaTile, new Rectangle(x, y, w, h));
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}