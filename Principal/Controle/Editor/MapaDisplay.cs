using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Rpg.Dominio;

namespace Rpg.Controle.Editor
{
    public partial class MapaDisplay : DisplayBase
    {
        #region Constantes

        public const int INT_TILE_TAMANHO = 50;

        #endregion Constantes

        #region Atributos

        private List<CamadaGrafico> _lstGfcCamada;
        private CamadaDominio _objCamadaSelecionada;
        private MapaDominio _objMapa;

        public CamadaDominio objCamadaSelecionada
        {
            get
            {
                return _objCamadaSelecionada;
            }

            set
            {
                _objCamadaSelecionada = value;
            }
        }

        public MapaDominio objMapa
        {
            get
            {
                return _objMapa;
            }

            set
            {
                _objMapa = value;
            }
        }

        private List<CamadaGrafico> lstGfcCamada
        {
            get
            {
                if (_lstGfcCamada != null)
                {
                    return _lstGfcCamada;
                }

                _lstGfcCamada = new List<CamadaGrafico>();

                return _lstGfcCamada;
            }
        }

        #endregion Atributos

        #region Construtores

        public MapaDisplay()
        {
            this.InitializeComponent();
        }

        #endregion Construtores

        #region Métodos

        protected override int getIntQuantidadeX()
        {
            if (this.objMapa == null)
            {
                return 0;
            }

            return this.objMapa.attIntQuantidadeX.intValor;
        }

        protected override int getIntQuantidadeY()
        {
            if (this.objMapa == null)
            {
                return 0;
            }

            return this.objMapa.attIntQuantidadeY.intValor;
        }

        protected override int getIntTileTamanho()
        {
            return INT_TILE_TAMANHO;
        }

        protected override void processarClick(MouseEventArgs arg)
        {
            base.processarClick(arg);

            this.desenhar(arg.X, arg.Y);
        }

        protected override void renderizar(PaintEventArgs arg)
        {
            base.renderizar(arg);

            this.renderizarLstObjCamada(arg.Graphics);
        }

        protected override bool validarRenderizar()
        {
            if (!base.validarRenderizar())
            {
                return false;
            }

            if (this.objMapa == null)
            {
                return false;
            }

            return true;
        }

        private void desenhar(int x, int y)
        {
            if (this.objCamadaSelecionada == null)
            {
                return;
            }

            if (!this.objMapa.lstObjCamada.Contains(this.objCamadaSelecionada))
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

            TileDominio objTile = null;

            if (string.IsNullOrEmpty(AppRpg.i.frmPrincipal.tabDockImagemSelecionada.txtTileTamanho.Text))
            {
                objTile = this.desenharLivre(x, y);
            }
            else
            {
                objTile = this.desenharGrid(x, y);
            }

            this.objCamadaSelecionada.addTile(objTile);

            this.Invalidate();
        }

        private TileDominio desenharGrid(int x, int y)
        {
            TileDominio objTileResultado = new TileDominio();

            objTileResultado.booFixo = !string.IsNullOrEmpty(AppRpg.i.frmPrincipal.tabDockImagemSelecionada.txtTileTamanho.Text);
            objTileResultado.dirImg = AppRpg.i.frmPrincipal.tabDockImagemSelecionada.objImagem.attDirCompleto.strValor;
            objTileResultado.rtgImg = this.desenharGridRtgImg(x, y);
            objTileResultado.rtgMapa = this.desenharGridRtgMapa(x, y);

            return objTileResultado;
        }

        private Rectangle desenharGridRtgImg(int x, int y)
        {
            int h = (AppRpg.i.frmPrincipal.tabDockImagemSelecionada.imgDisplay.objSelecao.rtg.Height - (AppRpg.i.frmPrincipal.tabDockImagemSelecionada.imgDisplay.intZoom * INT_ZOOM_INCREMENTO));
            int w = (AppRpg.i.frmPrincipal.tabDockImagemSelecionada.imgDisplay.objSelecao.rtg.Width - (AppRpg.i.frmPrincipal.tabDockImagemSelecionada.imgDisplay.intZoom * INT_ZOOM_INCREMENTO));

            x = (AppRpg.i.frmPrincipal.tabDockImagemSelecionada.imgDisplay.objSelecao.rtg.X - (AppRpg.i.frmPrincipal.tabDockImagemSelecionada.imgDisplay.objSelecao.rtg.X % (AppRpg.i.frmPrincipal.tabDockImagemSelecionada.imgDisplay.intTileTamanho + AppRpg.i.frmPrincipal.tabDockImagemSelecionada.imgDisplay.intZoom * INT_ZOOM_INCREMENTO)));

            x = (x / (AppRpg.i.frmPrincipal.tabDockImagemSelecionada.imgDisplay.intTileTamanho + AppRpg.i.frmPrincipal.tabDockImagemSelecionada.imgDisplay.intZoom * INT_ZOOM_INCREMENTO));
            x = (x * AppRpg.i.frmPrincipal.tabDockImagemSelecionada.imgDisplay.intTileTamanho);

            y = (AppRpg.i.frmPrincipal.tabDockImagemSelecionada.imgDisplay.objSelecao.rtg.Y - (AppRpg.i.frmPrincipal.tabDockImagemSelecionada.imgDisplay.objSelecao.rtg.Y % (AppRpg.i.frmPrincipal.tabDockImagemSelecionada.imgDisplay.intTileTamanho + AppRpg.i.frmPrincipal.tabDockImagemSelecionada.imgDisplay.intZoom * INT_ZOOM_INCREMENTO)));

            y = (y / (AppRpg.i.frmPrincipal.tabDockImagemSelecionada.imgDisplay.intTileTamanho + AppRpg.i.frmPrincipal.tabDockImagemSelecionada.imgDisplay.intZoom * INT_ZOOM_INCREMENTO));
            y = (y * AppRpg.i.frmPrincipal.tabDockImagemSelecionada.imgDisplay.intTileTamanho);

            return new Rectangle(x, y, w, h);
        }

        private Rectangle desenharGridRtgMapa(int x, int y)
        {
            x -= this.intMoveX;
            x -= (x % (INT_TILE_TAMANHO + this.intZoom * INT_ZOOM_INCREMENTO));
            x = (x / (INT_TILE_TAMANHO + this.intZoom * INT_ZOOM_INCREMENTO));
            x = (x * INT_TILE_TAMANHO);

            y -= this.intMoveY;
            y -= (y % (INT_TILE_TAMANHO + this.intZoom * INT_ZOOM_INCREMENTO));
            y = (y / (INT_TILE_TAMANHO + this.intZoom * INT_ZOOM_INCREMENTO));
            y = (y * INT_TILE_TAMANHO);

            return new Rectangle(x, y, INT_TILE_TAMANHO, INT_TILE_TAMANHO);
        }

        private TileDominio desenharLivre(int intClickX, int intClickY)
        {
            throw new NotImplementedException();
        }

        private CamadaGrafico getGfcCamada(CamadaDominio objCamada)
        {
            if (objCamada == null)
            {
                return null;
            }

            foreach (CamadaGrafico gfcCamada in this.lstGfcCamada)
            {
                if (!objCamada.Equals(gfcCamada.objCamada))
                {
                    continue;
                }

                return gfcCamada;
            }

            CamadaGrafico gfcCamadaNova = new CamadaGrafico(this, objCamada);

            this.lstGfcCamada.Add(gfcCamadaNova);

            return gfcCamadaNova;
        }

        private void renderizarLstObjCamada(Graphics gpc)
        {
            if (this.objMapa == null)
            {
                return;
            }

            foreach (CamadaDominio objCamada in this.objMapa.lstObjCamada)
            {
                this.getGfcCamada(objCamada).renderizar(gpc);
            }
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}