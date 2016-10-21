using System.Drawing;

namespace Rpg.Controle.Editor.Grafico
{
    public class GridGrafico : GraficoBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private SolidBrush _objBrush;
        private Pen _penBorda;
        private Pen _penTile;

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

        private Pen penTile
        {
            get
            {
                if (_penTile != null)
                {
                    return _penTile;
                }

                _penTile = new Pen(this.objBrush);

                return _penTile;
            }
        }

        #endregion Atributos

        #region Construtores

        public GridGrafico(DisplayBase objDisplay) : base(objDisplay)
        {
        }

        #endregion Construtores

        #region Métodos

        public override void renderizar(Graphics gpc)
        {
            this.renderizarTile(gpc);
            this.renderizarBorda(gpc);
        }

        protected override void inicializar()
        {
            base.inicializar();

            this.penTile.DashPattern = new float[] { 5, 10 };
        }

        protected override void setEventos()
        {
            base.setEventos();

            this.objDisplay.onIntTileTamanhoChanged += ((o, e) => this.invalidar());
        }

        private void renderizarBorda(Graphics gpc)
        {
            gpc.DrawRectangle(this.penBorda, 0, 0, (this.objDisplay.intTamanhoX - 1), (this.objDisplay.intTamanhoY - 1));
        }

        private void renderizarTile(Graphics gpc, int x, int y)
        {
            x = (x * this.objDisplay.intTileTamanho);
            y = (y * this.objDisplay.intTileTamanho);

            gpc.DrawRectangle(this.penTile, new Rectangle(x, y, this.objDisplay.intTileTamanho, this.objDisplay.intTileTamanho));
        }

        private void renderizarTile(Graphics gpc)
        {
            if (this.objDisplay.intTileTamanho < 10)
            {
                return;
            }

            int intQuantidadeX = (this.objDisplay.intTamanhoX / this.objDisplay.intTileTamanho);
            int intQuantidadeY = (this.objDisplay.intTamanhoY / this.objDisplay.intTileTamanho);

            for (int x = 0; x < intQuantidadeX; x++)
            {
                for (int y = 0; y < intQuantidadeY; y++)
                {
                    this.renderizarTile(gpc, x, y);
                }
            }
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}