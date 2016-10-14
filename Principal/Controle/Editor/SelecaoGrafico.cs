using System;
using System.Drawing;

namespace Rpg.Controle.Editor
{
    internal class SelecaoGrafico : GraficoBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private Rectangle _rtgSelecao;

        private Rectangle rtgSelecao
        {
            get
            {
                return _rtgSelecao;
            }

            set
            {
                if (_rtgSelecao == value)
                {
                    return;
                }

                _rtgSelecao = value;

                this.setRtgSelecao(_rtgSelecao);
            }
        }

        private Pen _penSelecao;

        private Pen penSelecao
        {
            get
            {
                if (_penSelecao != null)
                {
                    return _penSelecao;
                }

                _penSelecao = new Pen(new SolidBrush(Color.Blue));

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

        internal override void renderizar(Graphics gpc)
        {
            base.renderizar(gpc);

            if (this.rtgSelecao == null)
            {
                return;
            }

            int w = (this.objDisplay.intQuantidadeX * (this.objDisplay.intTileTamanho + (this.objDisplay.intZoom * DisplayBase.INT_ZOOM_INCREMENTO)));
            int h = (this.objDisplay.intQuantidadeY * (this.objDisplay.intTileTamanho + (this.objDisplay.intZoom * DisplayBase.INT_ZOOM_INCREMENTO)));

            gpc.DrawRectangle(this.penSelecao, this.rtgSelecao); 

            // TODO: Parei aqui.
        }

        internal void selecionar(int x, int y)
        {
            if (x < this.objDisplay.intMoveX)
            {
                return;
            }

            if (y < this.objDisplay.intMoveY)
            {
                return;
            }

            int w = this.objDisplay.intTileTamanho;
            int h = this.objDisplay.intTileTamanho;

            this.rtgSelecao = new Rectangle(x, y, w, h);
        }

        private void setRtgSelecao(Rectangle rtgSelecao)
        {
            this.objDisplay.Invalidate();
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}