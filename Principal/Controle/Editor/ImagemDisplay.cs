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
        private ImagemDominio _objImagem;

        public Bitmap bmp
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

        public ImagemDominio objImagem
        {
            get
            {
                return _objImagem;
            }

            set
            {
                if (_objImagem == value)
                {
                    return;
                }

                _objImagem = value;

                this.setObjImagem(_objImagem);
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

        protected override void processarClick(MouseEventArgs arg)
        {
            base.processarClick(arg);

            if (this.intTileTamanho > 0)
            {
                this.objSelecao.selecionarTile(arg.X, arg.Y);
                return;
            }
        }

        protected override void renderizar(PaintEventArgs arg)
        {
            this.renderizarBmp(arg.Graphics);

            base.renderizar(arg);
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

            return AppRpg.i.getBmpCache(this.objImagem.attDirCompleto.strValor);
        }

        private void renderizarBmp(Graphics gpc)
        {
            int h = (int)(this.intTamanhoY * this.fltZoom);
            int w = (int)(this.intTamanhoX * this.fltZoom);

            gpc.DrawImage(this.bmp, this.intMoveX, this.intMoveY, w, h);
        }

        private void setObjImagem(ImagemDominio objImagem)
        {
            if (objImagem == null)
            {
                return;
            }

            if (this.bmp == null)
            {
                return;
            }

            this.intTamanhoX = this.bmp.Width;
            this.intTamanhoY = this.bmp.Height;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}