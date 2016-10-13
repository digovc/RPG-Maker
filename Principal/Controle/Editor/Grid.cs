using System.Drawing;

namespace Rpg.Controle.Editor
{
    public class Grid : ElementoGraficoBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private SolidBrush _objBrush;
        private Display _objDisplay;

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

        private Display objDisplay
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

        public Grid(Display objDisplay)
        {
            this.objDisplay = objDisplay;
        }

        #endregion Construtores

        #region Métodos

        internal void renderizar(Graphics gpc)
        {
            this.renderizarBordaTile(gpc);
            this.renderizarBorda(gpc);
        }

        protected override void inicializar()
        {
            base.inicializar();

            this.penBordaTile.DashPattern = new float[] { 5, 10 };
        }

        private void renderizarBorda(Graphics gpc)
        {
            int w = (this.objDisplay.objMapa.attTamanhoX.intValor * (Display.INT_TILE_TAMANHO + (this.objDisplay.intZoom * Display.INT_ZOOM)));
            int h = (this.objDisplay.objMapa.attTamanhoY.intValor * (Display.INT_TILE_TAMANHO + (this.objDisplay.intZoom * Display.INT_ZOOM)));

            gpc.DrawRectangle(this.penBorda, new Rectangle(this.objDisplay.intMoveX, this.objDisplay.intMoveY, w, h));
        }

        private void renderizarBordaTile(Graphics gpc)
        {
            for (int x = 0; x < this.objDisplay.objMapa.attTamanhoX.intValor; x++)
            {
                for (int y = 0; y < this.objDisplay.objMapa.attTamanhoY.intValor; y++)
                {
                    this.renderizarBordaTile(gpc, x, y);
                }
            }
        }

        private void renderizarBordaTile(Graphics gpc, int x, int y)
        {
            x = (x * Display.INT_TILE_TAMANHO + this.objDisplay.intMoveX + (x * this.objDisplay.intZoom * Display.INT_ZOOM));
            y = (y * Display.INT_TILE_TAMANHO + this.objDisplay.intMoveY + (y * this.objDisplay.intZoom * Display.INT_ZOOM));

            int w = (Display.INT_TILE_TAMANHO + (this.objDisplay.intZoom * Display.INT_ZOOM));
            int h = (Display.INT_TILE_TAMANHO + (this.objDisplay.intZoom * Display.INT_ZOOM));

            gpc.DrawRectangle(this.penBordaTile, new Rectangle(x, y, w, h));
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}