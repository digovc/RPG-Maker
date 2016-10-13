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

        private Pen pen
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
            for (int x = 0; x < this.objDisplay.objMapa.attTamanhoX.intValor; x++)
            {
                for (int y = 0; y < this.objDisplay.objMapa.attTamanhoY.intValor; y++)
                {
                    this.renderizar(gpc, x, y);
                }
            }
        }

        protected override void inicializar()
        {
            base.inicializar();

            this.pen.DashPattern = new float[] { 5, 10 };
        }

        private void renderizar(Graphics gpc, int x, int y)
        {
            x = (x * Display.INT_TILE_TAMANHO + this.objDisplay.intMoveX + (x * this.objDisplay.intZoom * Display.INT_ZOOM));
            y = (y * Display.INT_TILE_TAMANHO + this.objDisplay.intMoveY + (y * this.objDisplay.intZoom * Display.INT_ZOOM));

            int w = (Display.INT_TILE_TAMANHO + (this.objDisplay.intZoom * Display.INT_ZOOM));
            int h = (Display.INT_TILE_TAMANHO + (this.objDisplay.intZoom * Display.INT_ZOOM));

            gpc.DrawRectangle(this.pen, new Rectangle(x, y, w, h));
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}