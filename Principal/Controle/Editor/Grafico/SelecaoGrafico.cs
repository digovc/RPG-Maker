using System;
using System.Drawing;

namespace Rpg.Controle.Editor.Grafico
{
    public class SelecaoGrafico : GraficoBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private Pen _penSelecao;
        private Rectangle _rtg;

        public Rectangle rtg
        {
            get
            {
                return _rtg;
            }

            set
            {
                if (_rtg == value)
                {
                    return;
                }

                _rtg = value;

                this.setrtg(_rtg);
            }
        }

        private Pen penSelecao
        {
            get
            {
                if (_penSelecao != null)
                {
                    return _penSelecao;
                }

                _penSelecao = new Pen(new SolidBrush(Color.DeepSkyBlue));

                return _penSelecao;
            }
        }

        #endregion Atributos

        #region Construtores

        public SelecaoGrafico(DisplayBase objDisplay) : base(objDisplay)
        {
        }

        #endregion Construtores

        #region Métodos

        internal void selecionarTile(int x, int y)
        {
            this.limparSelecao();

            if (this.objDisplay.intTileTamanho < 10)
            {
                return;
            }

            if (x < this.objDisplay.intMoveX)
            {
                return;
            }

            if (y < this.objDisplay.intMoveY)
            {
                return;
            }

            x -= this.objDisplay.intMoveX;
            x -= (int)(x % (this.objDisplay.intTileTamanho * this.objDisplay.fltZoom));
            x = (int)(x / this.objDisplay.fltZoom);

            y -= this.objDisplay.intMoveY;
            y -= (int)(y % (this.objDisplay.intTileTamanho * this.objDisplay.fltZoom));
            y = (int)(y / this.objDisplay.fltZoom);

            this.rtg = new Rectangle(x, y, this.objDisplay.intTileTamanho, this.objDisplay.intTileTamanho);
        }

        protected override void invalidar()
        {
            base.invalidar();

           
        }

        public override void renderizar(Graphics gpc)
        {
            if (this.rtg == default(Rectangle))
            {
                return;
            }

            gpc.DrawRectangle(this.penSelecao, this.rtg);
        }

        protected override void setEventos()
        {
            base.setEventos();

            this.objDisplay.onZooming += this.objDisplay_onZooming;
        }

        private Rectangle getRtgFinal()
        {
            int x = (this.rtg.X + this.objDisplay.intMoveX);
            int y = (this.rtg.Y + this.objDisplay.intMoveY);
            int w = (this.rtg.Width);
            int h = (this.rtg.Height);

            return new Rectangle(x, y, w, h);
        }

        private void limparSelecao()
        {
            this.rtg = default(Rectangle);
        }

        private void setrtg(Rectangle rtg)
        {
            this.invalidar();
            this.objDisplay.Invalidate();
        }

        #endregion Métodos

        #region Eventos

        private void objDisplay_onZooming(object sender, EventArgs e)
        {
            this.limparSelecao();
        }

        #endregion Eventos
    }
}