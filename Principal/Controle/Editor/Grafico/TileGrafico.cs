using System;
using System.Drawing;
using System.Windows.Forms;
using Rpg.Dominio;

namespace Rpg.Controle.Editor.Grafico
{
    public class TileGrafico : GraficoBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private bool _booSelecionado;
        private CamadaGrafico _gfcCamada;
        private int _intMoveXTemp;
        private int _intMoveYTemp;
        private TileDominio _objTile;
        private Pen _penSelecao;
        private Rectangle _rtgDestino;
        private Rectangle _rtgTemp;

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

        internal CamadaGrafico gfcCamada
        {
            get
            {
                return _gfcCamada;
            }

            set
            {
                _gfcCamada = value;
            }
        }

        private bool booSelecionado
        {
            get
            {
                return _booSelecionado;
            }

            set
            {
                if (_booSelecionado == value)
                {
                    return;
                }

                _booSelecionado = value;

                this.setBooSelecionado(_booSelecionado);
            }
        }

        private int intMoveXTemp
        {
            get
            {
                return _intMoveXTemp;
            }

            set
            {
                _intMoveXTemp = value;
            }
        }

        private int intMoveYTemp
        {
            get
            {
                return _intMoveYTemp;
            }

            set
            {
                _intMoveYTemp = value;
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

        private Rectangle rtgTemp
        {
            get
            {
                return _rtgTemp;
            }

            set
            {
                _rtgTemp = value;
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

        public void redimensionar(MouseEventArgs arg)
        {
            if (this.objTile == null)
            {
                return;
            }

            if (this.objTile.booFixo)
            {
                return;
            }

            if (!this.booSelecionado)
            {
                return;
            }

            int h = (rtgTemp.Height - (this.intMoveYTemp - this.normalizarY(arg.Y)));
            int w = (rtgTemp.Width - (this.intMoveXTemp - this.normalizarX(arg.X)));

            this.objTile.rtgMapa = new Rectangle(this.rtgDestino.X, this.rtgDestino.Y, w, h);

            this.invalidar();
        }

        public override void renderizar(Graphics gpc)
        {
            if (this.objTile == null)
            {
                return;
            }

            Bitmap bmpCache = AppRpg.i.getBmpCache(this.objTile.dirImagem);

            if (bmpCache == null)
            {
                return;
            }

            gpc.DrawImage(bmpCache, this.rtgDestino, this.objTile.rtgImg, GraphicsUnit.Pixel);

            this.renderizarSelecionado(gpc);
        }

        internal bool apagar(int x, int y)
        {
            if (this.objTile == null)
            {
                return false;
            }

            x = this.normalizarX(x);

            y = this.normalizarY(y);

            if (!this.rtgDestino.Contains(x, y))
            {
                return false;
            }

            this.invalidar();

            return true;
        }

        internal void desselecionar()
        {
            if (this.objTile == null)
            {
                return;
            }

            if (!this.booSelecionado)
            {
                return;
            }

            this.booSelecionado = false;

            this.invalidar();
        }

        internal override void invalidar()
        {
            base.invalidar();

            this.rtgDestino = default(Rectangle);

            this.gfcCamada?.invalidar();
        }

        internal void mover(MouseEventArgs arg)
        {
            if (this.objTile == null)
            {
                return;
            }

            if (this.objTile.booFixo)
            {
                return;
            }

            if (!this.booSelecionado)
            {
                return;
            }

            int x = (rtgTemp.X - (this.intMoveXTemp - this.normalizarX(arg.X)));
            int y = (rtgTemp.Y - (this.intMoveYTemp - this.normalizarY(arg.Y)));

            this.objTile.rtgMapa = new Rectangle(x, y, this.objTile.rtgMapa.Width, this.objTile.rtgMapa.Height);

            this.invalidar();
        }

        internal TileGrafico selecionar(int x, int y)
        {
            if (this.objTile == null)
            {
                return null;
            }

            if (this.objTile.booFixo)
            {
                return null;
            }

            x = this.normalizarX(x);
            y = this.normalizarY(y);

            if (!this.rtgDestino.Contains(x, y))
            {
                return null;
            }

            this.intMoveXTemp = x;
            this.intMoveYTemp = y;
            this.rtgTemp = this.rtgDestino;

            this.booSelecionado = true;

            this.invalidar();

            return this;
        }

        protected virtual Rectangle getRtgDestino()
        {
            if (this.objTile == null)
            {
                return default(Rectangle);
            }

            return this.objTile.rtgMapa;
        }

        protected virtual void setBooSelecionado(bool booSelecionado)
        {
        }

        protected override void setEventos()
        {
            base.setEventos();

            this.objDisplay.onZooming += this.objDisplay_onZooming;
        }

        private void renderizarSelecionado(Graphics gpc)
        {
            if (!this.booSelecionado)
            {
                return;
            }

            if (this.objTile.booFixo)
            {
                return;
            }

            gpc.DrawRectangle(this.penSelecao, this.rtgDestino);
        }

        protected virtual void setObjTile(TileDominio objTile)
        {
            if (objTile == null)
            {
                return;
            }

            objTile.gfcTile = this;

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