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

        private BackgroundGrafico _gfcBackground;
        private TileGrafico _gfcTileSelecionado;
        private List<CamadaGrafico> _lstGfcCamada;
        private List<PersonagemGrafico> _lstGfcPersonagem;
        private MapaDominio _objMapa;
        private TabDockMapa _tabDockMapa;

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

        private BackgroundGrafico gfcBackground
        {
            get
            {
                if (_gfcBackground != null)
                {
                    return _gfcBackground;
                }

                _gfcBackground = new BackgroundGrafico(this, this.objMapa.objTileBackground);

                return _gfcBackground;
            }
        }

        private TileGrafico gfcTileSelecionado
        {
            get
            {
                return _gfcTileSelecionado;
            }

            set
            {
                if (_gfcTileSelecionado == value)
                {
                    return;
                }

                if (_gfcTileSelecionado != null)
                {
                    _gfcTileSelecionado.desselecionar();
                }

                _gfcTileSelecionado = value;
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

        private List<PersonagemGrafico> lstGfcPersonagem
        {
            get
            {
                if (_lstGfcPersonagem != null)
                {
                    return _lstGfcPersonagem;
                }

                _lstGfcPersonagem = new List<PersonagemGrafico>();

                return _lstGfcPersonagem;
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

        internal void addPersonagem(PersonagemDominio objPersonagem)
        {
            if (objPersonagem == null)
            {
                return;
            }

            if (this.tabDockMapa.objCamadaSelecionada == null)
            {
                return;
            }

            this.addPersonagem(objPersonagem, this.tabDockMapa.objCamadaSelecionada);
        }

        protected override int getIntTileTamanho()
        {
            return INT_TILE_TAMANHO;
        }

        protected override void processarClickLeft(MouseEventArgs arg)
        {
            base.processarClickLeft(arg);

            switch (this.tabDockMapa.enmFerramenta)
            {
                case TabDockMapa.EnmFerramenta.BORRACHA:
                    this.apagar(arg.X, arg.Y);
                    return;

                case TabDockMapa.EnmFerramenta.LAPIS:
                    this.desenhar(arg.X, arg.Y);
                    return;

                case TabDockMapa.EnmFerramenta.REDIMENSIONAR:
                case TabDockMapa.EnmFerramenta.SELECIONAR:
                    this.selecionar(arg.X, arg.Y);
                    return;
            }
        }

        protected override void processarMouseMove(MouseEventArgs arg)
        {
            base.processarMouseMove(arg);

            if (MouseButtons.Left.Equals(arg.Button))
            {
                this.processarMouseMoveLeft(arg);
            }
        }

        protected override void renderizar(PaintEventArgs arg)
        {
            base.renderizar(arg);

            this.renderizarBackground(arg);
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

        private void addPersonagem(PersonagemDominio objPersonagem, CamadaDominio objCamada)
        {
            foreach (CamadaGrafico gfcCamada in this.lstGfcCamada)
            {
                if (gfcCamada.addPersonagem(objPersonagem, objCamada))
                {
                    return;
                }
            }
        }

        private void apagar(int x, int y)
        {
            if (this.tabDockMapa.objCamadaSelecionada == null)
            {
                return;
            }

            this.apagar(x, y, this.tabDockMapa.objCamadaSelecionada);
        }

        private void apagar(int x, int y, CamadaDominio objCamada)
        {
            if (!this.objMapa.lstObjCamada.Contains(objCamada))
            {
                return;
            }

            foreach (CamadaGrafico gfcCamada in this.lstGfcCamada)
            {
                if (gfcCamada.apagar(x, y, objCamada))
                {
                    return;
                }
            }
        }

        private void atualizarBackground(TileDominio objTileBackground)
        {
            this.gfcBackground.objTile = objTileBackground;

            this.gfcBackground.invalidar();
        }

        private void desenhar(int x, int y)
        {
            if (this.tabDockMapa.objCamadaSelecionada == null)
            {
                return;
            }

            this.desenhar(x, y, this.tabDockMapa.objCamadaSelecionada);
        }

        private void desenhar(int x, int y, CamadaDominio objCamada)
        {
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

            if (AppRpg.i.frmPrincipal.tabDockImagemSelecionada.ctrImagem.objSelecao.rtg == default(Rectangle))
            {
                return;
            }

            TileDominio objTile = null;

            if (AppRpg.i.frmPrincipal.tabDockImagemSelecionada.ctrImagem.intTileTamanho < 10)
            {
                objTile = this.desenharLivre(x, y);
            }
            else
            {
                objTile = this.desenharTile(x, y);
            }

            objCamada.addTile(objTile);

            this.Invalidate();
        }

        private TileDominio desenharLivre(int x, int y)
        {
            TileDominio objTileResultado = new TileDominio();

            objTileResultado.booFixo = false;
            objTileResultado.dirImg = AppRpg.i.frmPrincipal.tabDockImagemSelecionada.objImagem.attDirCompleto.strValor;
            objTileResultado.rtgImg = this.desenharLivreRtgImg(x, y);
            objTileResultado.rtgMapa = this.desenharLivreRtgMapa(x, y, objTileResultado);

            return objTileResultado;
        }

        private Rectangle desenharLivreRtgImg(int x, int y)
        {
            int h = AppRpg.i.frmPrincipal.tabDockImagemSelecionada.ctrImagem.objSelecao.rtg.Height;
            int w = AppRpg.i.frmPrincipal.tabDockImagemSelecionada.ctrImagem.objSelecao.rtg.Width;

            x = AppRpg.i.frmPrincipal.tabDockImagemSelecionada.ctrImagem.objSelecao.rtg.X;
            y = AppRpg.i.frmPrincipal.tabDockImagemSelecionada.ctrImagem.objSelecao.rtg.Y;

            return new Rectangle(x, y, w, h);
        }

        private Rectangle desenharLivreRtgMapa(int x, int y, TileDominio objTile)
        {
            x = this.normalizarX(x);

            y = this.normalizarY(y);

            return new Rectangle(x, y, objTile.rtgImg.Width, objTile.rtgImg.Height);
        }

        private TileDominio desenharTile(int x, int y)
        {
            TileDominio objTileResultado = new TileDominio();

            objTileResultado.booFixo = true;
            objTileResultado.dirImg = AppRpg.i.frmPrincipal.tabDockImagemSelecionada.objImagem.attDirCompleto.strValor;
            objTileResultado.rtgImg = this.desenharTileRtgImg(x, y);
            objTileResultado.rtgMapa = this.desenharTileRtgMapa(x, y);

            return objTileResultado;
        }

        private Rectangle desenharTileRtgImg(int x, int y)
        {
            int hw = AppRpg.i.frmPrincipal.tabDockImagemSelecionada.ctrImagem.intTileTamanho;
            x = AppRpg.i.frmPrincipal.tabDockImagemSelecionada.ctrImagem.objSelecao.rtg.X;
            y = AppRpg.i.frmPrincipal.tabDockImagemSelecionada.ctrImagem.objSelecao.rtg.Y;

            return new Rectangle(x, y, hw, hw);
        }

        private Rectangle desenharTileRtgMapa(int x, int y)
        {
            x = this.normalizarX(x);

            y = this.normalizarY(y);
            y = (y - (y % INT_TILE_TAMANHO));

            return new Rectangle(x, y, INT_TILE_TAMANHO, INT_TILE_TAMANHO);
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

        private PersonagemGrafico getGfcPersonagem(PersonagemTileDominio objPersonagemTile)
        {
            if (objPersonagemTile == null)
            {
                return null;
            }

            foreach (PersonagemGrafico gfcPersonagem in this.lstGfcPersonagem)
            {
                if (!objPersonagemTile.Equals(gfcPersonagem.objTile))
                {
                    continue;
                }

                return gfcPersonagem;
            }

            PersonagemGrafico gfcPersonagemNova = new PersonagemGrafico(this, objPersonagemTile);

            this.lstGfcPersonagem.Add(gfcPersonagemNova);

            return gfcPersonagemNova;
        }

        private int normalizarX(int x)
        {
            x = (x - this.intMoveX);
            x = (int)(x / this.fltZoom + 1);

            return x;
        }

        private int normalizarY(int y)
        {
            y = (y - this.intMoveY);
            y = (int)(y / this.fltZoom + 1);

            return y;
        }

        private void processarMouseMoveLeft(MouseEventArgs arg)
        {
            if (this.gfcTileSelecionado == null)
            {
                return;
            }

            switch (this.tabDockMapa.enmFerramenta)
            {
                case TabDockMapa.EnmFerramenta.REDIMENSIONAR:
                    this.gfcTileSelecionado.redimensionar(arg);
                    return;

                case TabDockMapa.EnmFerramenta.SELECIONAR:
                    this.gfcTileSelecionado.mover(arg);
                    return;
            }
        }

        private void redimensionarMoverSelecionado(MouseEventArgs arg)
        {
            if (this.gfcTileSelecionado == null)
            {
                return;
            }

            if (TabDockMapa.EnmFerramenta.SELECIONAR.Equals(this.tabDockMapa.enmFerramenta))
            {
                this.gfcTileSelecionado.redimensionar(arg);
                return;
            }

            this.gfcTileSelecionado.redimensionar(arg);
        }

        private void renderizarBackground(PaintEventArgs arg)
        {
            this.gfcBackground.renderizar(arg);
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

        private void selecionar(int x, int y)
        {
            if (this.gfcTileSelecionado != null)
            {
                this.gfcTileSelecionado = null;
            }

            if (this.objMapa == null)
            {
                return;
            }

            this.selecionarTile(x, y);
        }

        private void selecionarTile(int x, int y)
        {
            if (this.tabDockMapa.objCamadaSelecionada == null)
            {
                return;
            }

            this.selecionarTile(x, y, this.tabDockMapa.objCamadaSelecionada);
        }

        private void selecionarTile(int x, int y, CamadaDominio objCamada)
        {
            if (!this.objMapa.lstObjCamada.Contains(objCamada))
            {
                return;
            }

            foreach (CamadaGrafico gfcCamada in this.lstGfcCamada)
            {
                TileGrafico gfcTileSelecionado = gfcCamada.selecionarTile(x, y, objCamada);

                if (gfcTileSelecionado == null)
                {
                    continue;
                }

                this.gfcTileSelecionado = gfcTileSelecionado;
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

            this.objMapa.onObjTileBackgroundChanged += this.objMapa_onObjTileBackgroundChanged;
        }

        #endregion Métodos

        #region Eventos

        private void objMapa_onObjTileBackgroundChanged(object sender, TileDominio objTileBackground)
        {
            this.atualizarBackground(objTileBackground);
        }

        #endregion Eventos
    }
}