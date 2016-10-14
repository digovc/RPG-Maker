using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Rpg.Dominio;

namespace Rpg.Controle.Editor
{
    public partial class ImagemDisplay : DisplayBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private Bitmap _bmp;
        private ImagemDominio _ogjImagem;

        public ImagemDominio objImagem
        {
            get
            {
                return _ogjImagem;
            }

            set
            {
                _ogjImagem = value;
            }
        }

        private Bitmap bmp
        {
            get
            {
                if (_bmp != null)
                {
                    return _bmp;
                }

                _bmp = this.getBmp();

                return _bmp;
            }
        }

        #endregion Atributos

        #region Construtores

        public ImagemDisplay()
        {
            this.InitializeComponent();
        }

        #endregion Construtores

        #region Métodos

        protected override int getIntQuantidadeX()
        {
            if (this.bmp == null)
            {
                return 0;
            }

            if (this.intTileTamanho < 1)
            {
                return 0;
            }

            return (this.bmp.Width / this.intTileTamanho);
        }

        protected override int getIntQuantidadeY()
        {
            if (this.bmp == null)
            {
                return 0;
            }

            if (this.intTileTamanho < 1)
            {
                return 0;
            }

            return (this.bmp.Height / this.intTileTamanho);
        }

        protected override void renderizar(PaintEventArgs arg)
        {
            this.renderizarBmp(arg.Graphics);

            base.renderizar(arg);
        }

        protected override void renderizarGrid(Graphics gpc)
        {
            if (this.intTileTamanho < 1)
            {
                return;
            }

            base.renderizarGrid(gpc);
        }

        protected override void setIntTileTamanho(int intTileTamanho)
        {
            this.intQuantidadeX = 0;
            this.intQuantidadeY = 0;

            base.setIntTileTamanho(intTileTamanho);
        }

        protected override bool validarRenderizar()
        {
            if (!base.validarRenderizar())
            {
                return false;
            }

            if (this.bmp == null)
            {
                return false;
            }

            return true;
        }

        private Bitmap getBmp()
        {
            if (this.objImagem == null)
            {
                return null;
            }

            if (string.IsNullOrEmpty(this.objImagem.attDirCompleto.strValor))
            {
                return null;
            }

            if (!File.Exists(this.objImagem.attDirCompleto.strValor))
            {
                return null;
            }

            return new Bitmap(this.objImagem.attDirCompleto.strValor);
        }

        private void renderizarBmp(Graphics gpc)
        {
            int w = (this.bmp.Width + (this.intQuantidadeX * this.intZoom * INT_ZOOM_INCREMENTO));
            int h = (this.bmp.Height + (this.intQuantidadeY * this.intZoom * INT_ZOOM_INCREMENTO));

            gpc.DrawImage(this.bmp, this.intMoveX, this.intMoveY, w, h);
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}