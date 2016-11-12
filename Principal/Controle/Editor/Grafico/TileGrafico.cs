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

        private CamadaGrafico _gfcCamada;
        private int _intMoveXTemp;
        private int _intMoveYTemp;
        private TileDominio _objTile;
        private Pen _penSelecao;
        private Rectangle _rtgDestino;

        private Rectangle _rtgRedimensionar;

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

        private Rectangle rtgRedimensionar
        {
            get
            {
                if (_rtgRedimensionar != default(Rectangle))
                {
                    return _rtgRedimensionar;
                }

                _rtgRedimensionar = this.getRtgRedimensionar();

                return _rtgRedimensionar;
            }

            set
            {
                _rtgRedimensionar = value;
            }
        }

        private int _intRedimensionarXTemp ;

        private int intRedimensionarXTemp
        {
            get
            {
                return _intRedimensionarXTemp;
            }
            set
            {
                _intRedimensionarXTemp = value;
            }
        }

        private int _intRedimensionarYTemp ;

        private int intRedimensionarYTemp
        {
            get
            {
                return _intRedimensionarYTemp;
            }
            set
            {
                _intRedimensionarYTemp = value;
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

        public void redimensionarMover(MouseEventArgs arg)
        {
            if (this.objTile == null)
            {
                return;
            }

            if (!this.objTile.booSelecionado)
            {
                return;
            }

            int x = this.normalizarX(arg.X);
            int y = this.normalizarY(arg.Y);

            if (this.rtgRedimensionar.Contains(x, y))
            {
                this.redimensionar(x, y);
                return;
            }

            this.mover(x, y);
        }

        public override void renderizar(Graphics gpc)
        {
            if (this.objTile == null)
            {
                return;
            }

            gpc.DrawImage(AppRpg.i.getBmpCache(this.objTile.dirImg), this.rtgDestino, this.objTile.rtgImg, GraphicsUnit.Pixel);

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

            if (!this.objTile.booSelecionado)
            {
                return;
            }

            this.objTile.booSelecionado = false;

            this.invalidar();
        }

        internal override void invalidar()
        {
            base.invalidar();

            this.rtgDestino = default(Rectangle);
            this.rtgRedimensionar = default(Rectangle);

            this.gfcCamada?.invalidar();
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

            this.intMoveXTemp = (x - this.rtgDestino.X);
            this.intMoveYTemp = (y - this.rtgDestino.Y);
            this.intRedimensionarXTemp = this.rtgDestino.Width;
            this.intRedimensionarYTemp = this.rtgDestino.Height;

            this.objTile.booSelecionado = true;

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

        protected override void setEventos()
        {
            base.setEventos();

            this.objDisplay.onZooming += this.objDisplay_onZooming;
        }

        private Rectangle getRtgRedimensionar()
        {
            int h = (int)(25 * this.objDisplay.fltZoom);

            int w = h;

            int x = (this.rtgDestino.X + this.rtgDestino.Width - w);
            int y = (this.rtgDestino.Y + this.rtgDestino.Height - h);

            return new Rectangle(x, y, w, h);
        }

        private void mover(int x, int y)
        {
            x = (x - this.intMoveXTemp);
            y = (y - this.intMoveYTemp);

            this.objTile.rtgMapa = new Rectangle(x, y, this.objTile.rtgMapa.Width, this.objTile.rtgMapa.Height);
        }

        private void redimensionar(int x, int y)
        {
            int h = (this.intRedimensionarYTemp + y - this.intMoveYTemp - this.rtgDestino.Y);
            int w = (this.intRedimensionarXTemp + x - this.intMoveXTemp - this.rtgDestino.X);

            this.objTile.rtgMapa = new Rectangle(this.rtgDestino.X, this.rtgDestino.Y, w, h);
        }

        private void renderizarSelecionado(Graphics gpc)
        {
            if (!this.objTile.booSelecionado)
            {
                return;
            }

            gpc.DrawRectangle(this.penSelecao, this.rtgDestino);
            gpc.DrawRectangle(this.penSelecao, this.rtgRedimensionar);
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