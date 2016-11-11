using System;
using System.Drawing;
using Rpg.Dominio;

namespace Rpg.Controle.Editor.Grafico
{
    public class TileGrafico : GraficoBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private bool _booSelecionado;
        private TileDominio _objTile;
        private Rectangle _rtgDestino;

        public bool booSelecionado
        {
            get
            {
                return _booSelecionado;
            }

            set
            {
                _booSelecionado = value;
            }
        }

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

        #endregion Atributos

        #region Construtores

        public TileGrafico(DisplayBase objDisplay, TileDominio objTile) : base(objDisplay)
        {
            this.objTile = objTile;
        }

        #endregion Construtores

        #region Métodos

        public override void renderizar(Graphics gpc)
        {
            if (this.objTile == null)
            {
                return;
            }

            gpc.DrawImage(AppRpg.i.getBmpCache(this.objTile.dirImg), this.rtgDestino, this.objTile.rtgImg, GraphicsUnit.Pixel);
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

            return this.objTile.rtgMapa;
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