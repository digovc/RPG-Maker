using System;
using System.Drawing;
using DigoFramework;
using Rpg.Dominio;

namespace Rpg.Controle.TabDock
{
    public partial class TabDockPersonagem : TabDockRpgBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private PersonagemDominio _objPersonagem;

        public PersonagemDominio objPersonagem
        {
            get
            {
                return _objPersonagem;
            }

            set
            {
                _objPersonagem = value;
            }
        }

        #endregion Atributos

        #region Construtores

        public TabDockPersonagem()
        {
            this.InitializeComponent();
        }

        #endregion Construtores

        #region Métodos

        private void montarLayoutPersonagem()
        {
            if (this.imgPersonagem.BackgroundImage != null)
            {
                this.imgPersonagem.BackgroundImage.Dispose();
            }

            this.imgPersonagem.BackgroundImage = null;

            if (this.objPersonagem == null)
            {
                return;
            }

            if (this.objPersonagem.objTile == null)
            {
                return;
            }

            Bitmap bmpPersonagem = new Bitmap(this.objPersonagem.objTile.rtgImg.Width, this.objPersonagem.objTile.rtgImg.Height);

            using (Graphics gpc = Graphics.FromImage(bmpPersonagem))
            {
                Bitmap bmpArte = AppRpg.i.getBmpCache(this.objPersonagem.objTile.dirImg);

                gpc.DrawImage(bmpArte, this.getRtgDestino(), this.objPersonagem.objTile.rtgImg, GraphicsUnit.Pixel);
            }

            this.imgPersonagem.BackgroundImage = bmpPersonagem;
        }

        private Rectangle getRtgDestino()
        {
            int h = this.objPersonagem.objTile.rtgImg.Height;
            int w = this.objPersonagem.objTile.rtgImg.Width;

            return new Rectangle(0, 0, w, h);
        }

        private void selecionarPersonagem()
        {
            if (this.objPersonagem == null)
            {
                return;
            }

            if (AppRpg.i.frmPrincipal.tabDockImagemSelecionada == null)
            {
                return;
            }

            if (AppRpg.i.frmPrincipal.tabDockImagemSelecionada.objImagem == null)
            {
                return;
            }

            if (string.IsNullOrEmpty(AppRpg.i.frmPrincipal.tabDockImagemSelecionada.objImagem.attDirCompleto.strValor))
            {
                return;
            }

            if (AppRpg.i.frmPrincipal.tabDockImagemSelecionada.imgDisplay.objSelecao.rtg == default(Rectangle))
            {
                return;
            }

            TileDominio objTilePersonagem = new TileDominio();

            objTilePersonagem.booFixo = true;
            objTilePersonagem.dirImg = AppRpg.i.frmPrincipal.tabDockImagemSelecionada.objImagem.attDirCompleto.strValor;
            objTilePersonagem.rtgImg = this.selecionarPersonagemRtgImg();

            this.objPersonagem.objTile = objTilePersonagem;

            this.montarLayoutPersonagem();
        }

        private Rectangle selecionarPersonagemRtgImg()
        {
            int h = AppRpg.i.frmPrincipal.tabDockImagemSelecionada.imgDisplay.objSelecao.rtg.Height;
            int w = AppRpg.i.frmPrincipal.tabDockImagemSelecionada.imgDisplay.objSelecao.rtg.Width;

            int x = AppRpg.i.frmPrincipal.tabDockImagemSelecionada.imgDisplay.objSelecao.rtg.X;
            int y = AppRpg.i.frmPrincipal.tabDockImagemSelecionada.imgDisplay.objSelecao.rtg.Y;

            return new Rectangle(x, y, w, h);
        }

        protected override void montarLayout()
        {
            base.montarLayout();

            this.montarLayoutPersonagem();
        }

        #endregion Métodos

        #region Eventos


        private void imgPersonagem_Click(object sender, System.EventArgs e)
        {
            try
            {
                this.selecionarPersonagem();
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex);
            }
        }

        #endregion Eventos
    }
}