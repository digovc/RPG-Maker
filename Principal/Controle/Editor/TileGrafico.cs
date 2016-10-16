using System;
using System.Drawing;
using Rpg.Dominio;

namespace Rpg.Controle.Editor
{
    public class TileGrafico : GraficoBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private TileDominio _objTile;
        private Rectangle _rtgDestino;
        private Rectangle _rtgOrigem;

        public TileDominio objTile
        {
            get
            {
                return _objTile;
            }

            private set
            {
                _objTile = value;
            }
        }

        private Rectangle rtgDestino
        {
            get
            {
                if (_rtgDestino != default(Rectangle))
                {
                    return _rtgDestino;
                }

                _rtgDestino = this.getRtgDestino();

                return _rtgDestino;
            }

            set
            {
                _rtgDestino = value;
            }
        }

        private Rectangle rtgOrigem
        {
            get
            {
                if (_rtgOrigem != default(Rectangle))
                {
                    return _rtgOrigem;
                }

                _rtgOrigem = this.getRtgOrigem();

                return _rtgOrigem;
            }
        }

        #endregion Atributos

        #region Construtores

        public TileGrafico(DisplayBase objDisplay, TileDominio objTile) : base(objDisplay)
        {
            this.objTile = objTile;
        }

        #endregion Construtores

        #region Métodos

        internal override void renderizar(Graphics gpc)
        {
            base.renderizar(gpc);

            if (this.objTile == null)
            {
                return;
            }

            gpc.DrawImage(AppRpg.i.getBmpCache(this.objTile.dirImg), this.rtgDestino, this.rtgOrigem, GraphicsUnit.Pixel);
        }

        protected override void invalidar()
        {
            base.invalidar();

            this.rtgDestino = default(Rectangle);
        }

        protected override void setEventos()
        {
            base.setEventos();

            this.objDisplay.onZooming += this.objDisplay_onZooming;
        }

        private Rectangle getRtgDestino()
        {
            if (this.objTile == null)
            {
                return default(Rectangle);
            }

            int h = (this.objDisplay.intTileTamanho + (this.objDisplay.intZoom * DisplayBase.INT_ZOOM_INCREMENTO));

            int w = h;

            int x = ((this.objTile.rtgMapa.X / MapaDisplay.INT_TILE_TAMANHO) * h + this.objDisplay.intMoveX);
            int y = ((this.objTile.rtgMapa.Y / MapaDisplay.INT_TILE_TAMANHO) * w + this.objDisplay.intMoveY);

            return new Rectangle(x, y, (w + 2), h);
        }

        private Rectangle getRtgOrigem()
        {
            if (this.objTile == null)
            {
                return default(Rectangle);
            }

            int h = this.objTile.rtgImg.Height;

            int w = this.objTile.rtgImg.Width;

            int x = this.objTile.rtgImg.X;
            int y = (this.objTile.rtgImg.Y);

            return new Rectangle(x, y, w, h);
        }

        #endregion Métodos

        #region Eventos

        private void objDisplay_onZooming(object sender, EventArgs e)
        {
            this.invalidar();
        }


        #endregion Eventos
    }
}