using System;
using System.Drawing;
using DigoFramework;

namespace Rpg.Controle.Editor
{
    public class SelecaoGrafico : GraficoBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private Pen _penSelecao;
        private Rectangle _rtg;
        private Rectangle _rtgFinal;

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

        private Rectangle rtgFinal
        {
            get
            {
                if (_rtgFinal != default(Rectangle))
                {
                    return _rtgFinal;
                }

                _rtgFinal = this.getRtgFinal();

                return _rtgFinal;
            }

            set
            {
                _rtgFinal = value;
            }
        }

        #endregion Atributos

        #region Construtores

        public SelecaoGrafico(DisplayBase objDisplay) : base(objDisplay)
        {
        }

        #endregion Construtores

        #region Métodos

        internal override void renderizar(Graphics gpc)
        {
            base.renderizar(gpc);

            if (this.rtg == default(Rectangle))
            {
                return;
            }

            gpc.DrawRectangle(this.penSelecao, this.rtgFinal);
        }

        internal void selecionarTile(int x, int y)
        {
            if (x < this.objDisplay.intMoveX)
            {
                return;
            }

            if (y < this.objDisplay.intMoveY)
            {
                return;
            }

            int h = (this.objDisplay.intTileTamanho + this.objDisplay.intZoom * DisplayBase.INT_ZOOM_INCREMENTO);

            int w = h;

            x -= this.objDisplay.intMoveX;
            x -= (x % h);

            y -= this.objDisplay.intMoveY;
            y -= (y % w);

            this.rtg = new Rectangle(x, y, w, h);
        }

        protected override void invalidar()
        {
            base.invalidar();

            this.rtgFinal = default(Rectangle);
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