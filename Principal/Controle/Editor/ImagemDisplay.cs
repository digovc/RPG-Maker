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
        private bool _booSelecionando;
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

        private bool booSelecionando
        {
            get
            {
                return _booSelecionando;
            }

            set
            {
                _booSelecionando = value;
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

        protected override void processarClickLeft(MouseEventArgs arg)
        {
            base.processarClickLeft(arg);

            if (this.intTileTamanho > 0)
            {
                this.objSelecao.selecionarTile(arg.X, arg.Y);
                return;
            }

            this.comecarSelecao(arg);
        }

        protected override void processarMouseMove(MouseEventArgs arg)
        {
            base.processarMouseMove(arg);

            if (MouseButtons.Left.Equals(arg.Button))
            {
                this.addSelecao(arg);
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

        private void comecarSelecao(MouseEventArgs arg)
        {
            this.booSelecionando = true;
            this.objSelecao.comecarSelecao(arg.X, arg.Y);
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

        private void addSelecao(MouseEventArgs arg)
        {
            this.objSelecao.addSelecao(arg.X, arg.Y);
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