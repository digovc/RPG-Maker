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

        private TileDominio _objTile;
        private Pen _penSelecao;
        private Rectangle _rtgDestino;

        public TileDominio objTile
        {
            get
            {
                return _objTile;
            }

            set
            {
                if (_objTile == value)
                {
                    return;
                }

                _objTile = value;

                this.setObjTile(_objTile);
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

            this.renderizarSelecionado(gpc);
        }

        protected virtual Rectangle getRtgDestino()
        {
            if (this.objTile == null)
            {
                return default(Rectangle);
            }

            return this.objTile.rtgMapa;
        }

        public override void invalidar()
        {
            base.invalidar();

            this.rtgDestino = default(Rectangle);
        }

        protected override void setEventos()
        {
            base.setEventos();

            this.objDisplay.onZooming += this.objDisplay_onZooming;
        }

        private void renderizarSelecionado(Graphics gpc)
        {
            if (!this.objTile.booSelecionado)
            {
                return;
            }

            gpc.DrawRectangle(this.penSelecao, this.rtgDestino);
        }

        private void setObjTile(TileDominio objTile)
        {
            if (objTile == null)
            {
                return;
            }

            objTile.onBooSelecionadoChanged += this.objTile_onBooSelecionadoChanged;
        }

        #endregion Métodos

        #region Eventos

        private void objDisplay_onZooming(object sender, EventArgs e)
        {
            this.invalidar();
        }

        private void objTile_onBooSelecionadoChanged(object sender, bool booSelecionado)
        {
            this.invalidar();
        }

        #endregion Eventos
    }
}