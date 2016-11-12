using System;
using System.Drawing;
using System.Windows.Forms;

namespace Rpg.Controle.Editor.Grafico
{
    public abstract class GraficoBase : IDisposable
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private Bitmap _bmpCache;
        private DisplayBase _objDisplay;

        protected DisplayBase objDisplay
        {
            get
            {
                return _objDisplay;
            }

            set
            {
                _objDisplay = value;
            }
        }

        private Bitmap bmpCache
        {
            get
            {
                if (_bmpCache != null)
                {
                    return _bmpCache;
                }

                _bmpCache = this.getBmpCache();

                return _bmpCache;
            }
        }

        #endregion Atributos

        #region Construtores

        public GraficoBase(DisplayBase objDisplay)
        {
            this.objDisplay = objDisplay;

            this.iniciar();
        }

        #endregion Construtores

        #region Métodos

        public virtual void Dispose()
        {
            this.bmpCache?.Dispose();
        }

        public void renderizar(PaintEventArgs arg)
        {
            if (this.bmpCache == null)
            {
                return;
            }

            int w = (int)(this.objDisplay.intTamanhoX * this.objDisplay.fltZoom);
            int h = (int)(this.objDisplay.intTamanhoY * this.objDisplay.fltZoom);

            Rectangle rtgSorce = new Rectangle(0, 0, this.bmpCache.Width, this.bmpCache.Height);
            Rectangle rtgDest = new Rectangle(this.objDisplay.intMoveX, this.objDisplay.intMoveY, w, h);

            arg.Graphics.DrawImage(this.bmpCache, rtgDest, rtgSorce, GraphicsUnit.Pixel);
        }

        public abstract void renderizar(Graphics gpc);

        internal virtual void invalidar()
        {
            if (_bmpCache != null)
            {
                _bmpCache.Dispose();
            }

            _bmpCache = null;
        }

        protected virtual void inicializar()
        {
        }

        protected int normalizarX(int x)
        {
            x = (x - this.objDisplay.intMoveX);
            x = (int)(x / this.objDisplay.fltZoom + 1);

            return x;
        }

        protected int normalizarY(int y)
        {
            y = (y - this.objDisplay.intMoveY);
            y = (int)(y / this.objDisplay.fltZoom + 1);

            return y;
        }

        protected virtual void setEventos()
        {
        }

        protected virtual bool validarRenderizar()
        {
            return true;
        }

        private Bitmap getBmpCache()
        {
            if (!this.validarRenderizar())
            {
                return null;
            }

            Bitmap bmpCacheResultado = new Bitmap(this.objDisplay.intTamanhoX, this.objDisplay.intTamanhoY);

            using (Graphics gpc = Graphics.FromImage(bmpCacheResultado))
            {
                this.renderizar(gpc);
            }

            return bmpCacheResultado;
        }

        private void iniciar()
        {
            this.inicializar();
            this.setEventos();
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}