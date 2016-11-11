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

        private PersonagemGrafico _gfcPersonagemSelecionado;
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

        private PersonagemGrafico gfcPersonagemSelecionado
        {
            get
            {
                return _gfcPersonagemSelecionado;
            }

            set
            {
                if (_gfcPersonagemSelecionado == value)
                {
                    return;
                }

                if (_gfcPersonagemSelecionado != null)
                {
                    _gfcPersonagemSelecionado.booSelecionado = false;
                }

                _gfcPersonagemSelecionado = value;

                this.setEventosGfcPersonagemSelecionado(_gfcPersonagemSelecionado);
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

                case TabDockMapa.EnmFerramenta.SELECIONAR:
                    this.selecionar(arg.X, arg.Y);
                    return;
            }
        }

        protected override void renderizar(PaintEventArgs arg)
        {
            base.renderizar(arg);

            this.renderizarCamada(arg);
            this.renderizarPersonagem(arg);
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
            if (AppRpg.i.frmPrincipal.objSelecionado == null)
            {
                return;
            }

            if (!(AppRpg.i.frmPrincipal.objSelecionado is CamadaDominio))
            {
                return;
            }

            this.apagar(x, y, (AppRpg.i.frmPrincipal.objSelecionado as CamadaDominio));
        }

        private void apagar(int x, int y, CamadaDominio objCamada)
        {
            if (!this.objMapa.lstObjCamada.Contains(objCamada))
            {
                return;
            }

            x = this.normalizarX(x);

            y = this.normalizarY(y);

            if (!objCamada.removerTile(x, y))
            {
                return;
            }

            this.Invalidate();
        }

        private void desenhar(int x, int y)
        {
            if (AppRpg.i.frmPrincipal.objSelecionado == null)
            {
                return;
            }

            if (!(AppRpg.i.frmPrincipal.objSelecionado is CamadaDominio))
            {
                return;
            }

            this.desenhar(x, y, (AppRpg.i.frmPrincipal.objSelecionado as CamadaDominio));
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

            if (AppRpg.i.frmPrincipal.tabDockImagemSelecionada.imgDisplay.objSelecao.rtg == default(Rectangle))
            {
                return;
            }

            TileDominio objTile = null;

            if (AppRpg.i.frmPrincipal.tabDockImagemSelecionada.imgDisplay.intTileTamanho < 10)
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
            int h = AppRpg.i.frmPrincipal.tabDockImagemSelecionada.imgDisplay.objSelecao.rtg.Height;
            int w = AppRpg.i.frmPrincipal.tabDockImagemSelecionada.imgDisplay.objSelecao.rtg.Width;

            x = AppRpg.i.frmPrincipal.tabDockImagemSelecionada.imgDisplay.objSelecao.rtg.X;
            y = AppRpg.i.frmPrincipal.tabDockImagemSelecionada.imgDisplay.objSelecao.rtg.Y;

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
            int hw = AppRpg.i.frmPrincipal.tabDockImagemSelecionada.imgDisplay.intTileTamanho;
            x = AppRpg.i.frmPrincipal.tabDockImagemSelecionada.imgDisplay.objSelecao.rtg.X;
            y = AppRpg.i.frmPrincipal.tabDockImagemSelecionada.imgDisplay.objSelecao.rtg.Y;

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

        private void renderizarPersonagem(PaintEventArgs arg)
        {
            if (this.objMapa == null)
            {
                return;
            }

            foreach (PersonagemTileDominio objPersonagemTile in this.objMapa.lstObjPersonagemTile)
            {
                this.getGfcPersonagem(objPersonagemTile).renderizar(arg);
            }
        }

        private void selecionar(int x, int y)
        {
            if (this.objMapa == null)
            {
                return;
            }

            x = this.normalizarX(x);
            y = this.normalizarY(y);

            if (this.selecionarPersonagem(x, y))
            {
                return;
            }

            this.selecionarTile(x, y);
        }

        private bool selecionarPersonagem(int x, int y)
        {
            if (this.lstGfcPersonagem.Count < 1)
            {
                return false;
            }

            foreach (PersonagemGrafico gfcPersonagem in this.lstGfcPersonagem)
            {
                if (this.selecionarPersonagem(x, y, gfcPersonagem))
                {
                    return true;
                }
            }

            return false;
        }

        private bool selecionarPersonagem(int x, int y, PersonagemGrafico gfcPersonagem)
        {
            if (gfcPersonagem.objTile == null)
            {
                return false;
            }

            if (!gfcPersonagem.objTile.rtgMapa.Contains(x, y))
            {
                return false;
            }

            this.selecionarPersonagem(gfcPersonagem);
            return true;
        }

        private void selecionarPersonagem(PersonagemGrafico gfcPersonagem)
        {
            this.gfcPersonagemSelecionado = gfcPersonagem;
        }

        private void selecionarTile(int x, int y)
        {
            throw new NotImplementedException();
        }

        private void setEventosGfcPersonagemSelecionado(PersonagemGrafico gfcPersonagemSelecionado)
        {
            if (gfcPersonagemSelecionado == null)
            {
                return;
            }

            gfcPersonagemSelecionado.booSelecionado = true;
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