using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Rpg.Controle.Editor.Grafico;
using Rpg.Controle.TabDock;
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

        private TabDockMapa _tabDockMapa;

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
                if (_objMapa == value)
                {
                    return;
                }

                _objMapa = value;

                this.setObjMapa(_objMapa);
            }
        }

        public TabDockMapa tabDockMapa
        {
            get
            {
                return _tabDockMapa;
            }

            set
            {
                _tabDockMapa = value;
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

        protected override int getIntTileTamanho()
        {
            return INT_TILE_TAMANHO;
        }

        protected override void processarClick(MouseEventArgs arg)
        {
            base.processarClick(arg);

            switch (this.tabDockMapa.enmFerramenta)
            {
                case TabDockMapa.EnmFerramenta.BORRACHA:
                    this.apagar(arg.X, arg.Y);
                    return;

                case TabDockMapa.EnmFerramenta.LAPIS:
                    this.desenhar(arg.X, arg.Y);
                    return;

                case TabDockMapa.EnmFerramenta.SELECIONAR:
                    return;
            }
        }

        protected override void renderizar(PaintEventArgs arg)
        {
            base.renderizar(arg);

            this.renderizarCamada(arg);
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

        private void apagar(int x, int y)
        {
            if (this.objCamadaSelecionada == null)
            {
                return;
            }

            if (!this.objMapa.lstObjCamada.Contains(this.objCamadaSelecionada))
            {
                return;
            }

            x = this.normalizarTileX(x);

            y = this.normalizarTileY(y);

            if (!this.objCamadaSelecionada.removerTile(x, y))
            {
                return;
            }

            this.Invalidate();
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
                objTile = this.desenharTile(x, y);
            }

            this.objCamadaSelecionada.addTile(objTile);

            this.Invalidate();
        }

        private Rectangle desenharGridRtgMapa(int x, int y)
        {
            x = this.normalizarTileX(x);

            y = this.normalizarTileY(y);

            return new Rectangle(x, y, INT_TILE_TAMANHO, INT_TILE_TAMANHO);
        }

        private TileDominio desenharLivre(int intClickX, int intClickY)
        {
            throw new NotImplementedException();
        }

        private TileDominio desenharTile(int x, int y)
        {
            TileDominio objTileResultado = new TileDominio();

            objTileResultado.booFixo = true;
            objTileResultado.dirImg = AppRpg.i.frmPrincipal.tabDockImagemSelecionada.objImagem.attDirCompleto.strValor;
            objTileResultado.rtgImg = this.desenharTileRtgImg(x, y);
            objTileResultado.rtgMapa = this.desenharGridRtgMapa(x, y);

            return objTileResultado;
        }

        private Rectangle desenharTileRtgImg(int x, int y)
        {
            int hw = AppRpg.i.frmPrincipal.tabDockImagemSelecionada.imgDisplay.intTileTamanho;
            x = AppRpg.i.frmPrincipal.tabDockImagemSelecionada.imgDisplay.objSelecao.rtg.X;
            y = AppRpg.i.frmPrincipal.tabDockImagemSelecionada.imgDisplay.objSelecao.rtg.Y;

            return new Rectangle(x, y, hw, hw);
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

        private int normalizarTileX(int x)
        {
            x = (x - this.intMoveX);
            x = (int)(x - (x % (INT_TILE_TAMANHO * this.fltZoom)));
            x = (int)(x / this.fltZoom + 1);

            return x;
        }

        private int normalizarTileY(int y)
        {
            y = (y - this.intMoveY);
            y = (int)(y - (y % (INT_TILE_TAMANHO * this.fltZoom)));
            y = (int)(y / this.fltZoom + 1);

            return y;
        }

        private void renderizarCamada(PaintEventArgs arg)
        {
            if (this.objMapa == null)
            {
                return;
            }

            foreach (CamadaDominio objCamada in this.objMapa.lstObjCamada)
            {
                this.getGfcCamada(objCamada).renderizar(arg);
            }
        }

        private void setObjMapa(MapaDominio objMapa)
        {
            if (objMapa == null)
            {
                return;
            }

            // TODO: Quando alterar o tamanho do mapa, atualizar seu display.
            this.intTamanhoX = (objMapa.attIntQuantidadeX.intValor * INT_TILE_TAMANHO);
            this.intTamanhoY = (objMapa.attIntQuantidadeY.intValor * INT_TILE_TAMANHO);
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}