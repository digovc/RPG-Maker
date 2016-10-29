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

        private int _intInicialX ;

        private int intInicialX
        {
            get
            {
                return _intInicialX;
            }
            set
            {
                _intInicialX = value;
            }
        }

        private int _intInicialY ;

        private int intInicialY
        {
            get
            {
                return _intInicialY;
            }
            set
            {
                _intInicialY = value;
            }
        }

        #endregion Atributos

        #region Construtores

        public SelecaoGrafico(DisplayBase objDisplay) : base(objDisplay)
        {
        }

        #endregion Construtores

        #region Métodos

        public override void renderizar(Graphics gpc)
        {
            if (this.rtg == default(Rectangle))
            {
                return;
            }

            gpc.DrawRectangle(this.penSelecao, this.rtg);
        }

        internal void addSelecao(int x, int y)
        {
            x = (x - this.objDisplay.intMoveX);
            x = (int)(x / this.objDisplay.fltZoom);

            y = (y - this.objDisplay.intMoveY);
            y = (int)(y / this.objDisplay.fltZoom);

            int w = (x - this.intInicialX);
            int h = (y - this.intInicialY);

            x = this.intInicialX;
            y = this.intInicialY;

            if (w < 0)
            {
                x = (x + w);
                w = Math.Abs(w);
            }

            if (h < 0)
            {
                y = (y + h);
                h = Math.Abs(h);
            }

            this.rtg = new Rectangle(x, y, w, h);
        }

        internal void comecarSelecao(int x, int y)
        {
            this.limparSelecao();

            if (x < this.objDisplay.intMoveX)
            {
                return;
            }

            if (y < this.objDisplay.intMoveY)
            {
                return;
            }

            x = (x - this.objDisplay.intMoveX);
            x = (int)(x / this.objDisplay.fltZoom);

            y = (y - this.objDisplay.intMoveY);
            y = (int)(y / this.objDisplay.fltZoom);

            this.rtg = new Rectangle(x, y, 1, 1);

            this.intInicialX = x;
            this.intInicialY = y;
        }

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

            x = (x - this.objDisplay.intMoveX);
            x = (int)(x - (x % (this.objDisplay.intTileTamanho * this.objDisplay.fltZoom)));
            x = (int)(x / this.objDisplay.fltZoom);

            y = (y - this.objDisplay.intMoveY);
            y = (int)(y - (y % (this.objDisplay.intTileTamanho * this.objDisplay.fltZoom)));
            y = (int)(y / this.objDisplay.fltZoom);

            this.rtg = new Rectangle(x, y, this.objDisplay.intTileTamanho, this.objDisplay.intTileTamanho);
        }

        protected override void setEventos()
        {
            base.setEventos();

            this.objDisplay.onZooming += this.objDisplay_onZooming;
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