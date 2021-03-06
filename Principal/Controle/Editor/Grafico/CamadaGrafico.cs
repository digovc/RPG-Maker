﻿using System.Collections.Generic;
using System.Drawing;
using Rpg.Dominio;

namespace Rpg.Controle.Editor.Grafico
{
    public class CamadaGrafico : GraficoBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private List<TileGrafico> _lstGfcTile;
        private CamadaDominio _objCamada;
        private MapaDisplay _objMapaDisplay;

        public CamadaDominio objCamada
        {
            get
            {
                return _objCamada;
            }

            private set
            {
                if (_objCamada == value)
                {
                    return;
                }

                _objCamada = value;

                this.setObjCamada(_objCamada);
            }
        }

        private List<TileGrafico> lstGfcTile
        {
            get
            {
                if (_lstGfcTile != null)
                {
                    return _lstGfcTile;
                }

                _lstGfcTile = new List<TileGrafico>();

                return _lstGfcTile;
            }
        }

        private MapaDisplay objMapaDisplay
        {
            get
            {
                if (_objMapaDisplay != null)
                {
                    return _objMapaDisplay;
                }

                _objMapaDisplay = (this.objDisplay as MapaDisplay);

                return _objMapaDisplay;
            }
        }

        #endregion Atributos

        #region Construtores

        public CamadaGrafico(DisplayBase objDisplay, CamadaDominio objCamada) : base(objDisplay)
        {
            this.objCamada = objCamada;
        }

        #endregion Construtores

        #region Métodos

        public override void renderizar(Graphics gpc)
        {
            this.renderizarTile(gpc);
            this.renderizarPersonagemTile(gpc);
        }

        internal bool addPersonagem(PersonagemDominio objPersonagem, CamadaDominio objCamada)
        {
            if (objCamada == null)
            {
                return false;
            }

            if (!objCamada.Equals(this.objCamada))
            {
                return false;
            }

            PersonagemTileDominio objPersonagemTile = new PersonagemTileDominio();

            objPersonagemTile.dirImagem = objPersonagem.objTile.dirImagem;
            objPersonagemTile.objPersonagem = objPersonagem;
            objPersonagemTile.rtgImg = objPersonagem.objTile.rtgImg;
            objPersonagemTile.rtgMapa = new Rectangle(0, 0, objPersonagem.objTile.rtgImg.Width, objPersonagem.objTile.rtgImg.Height);

            objPersonagemTile.iniciar(true);

            PersonagemTileGrafico gfcPersonagemTile = new PersonagemTileGrafico(this.objDisplay, objPersonagemTile);

            gfcPersonagemTile.gfcCamada = this;
            gfcPersonagemTile.objTile = objPersonagemTile;

            this.lstGfcTile.Add(gfcPersonagemTile);

            this.objCamada.addPersonagemTile(objPersonagemTile);

            this.invalidar();

            return true;
        }

        internal bool apagar(int x, int y, CamadaDominio objCamada)
        {
            if (objCamada == null)
            {
                return false;
            }

            if (!objCamada.Equals(this.objCamada))
            {
                return false;
            }

            List<TileGrafico> lstGfcTileTemp = new List<TileGrafico>(this.lstGfcTile);

            lstGfcTileTemp.Reverse();

            foreach (TileGrafico gfcTile in lstGfcTileTemp)
            {
                if (gfcTile.apagar(x, y))
                {
                    this.apagar(objCamada, gfcTile);
                    return true;
                }
            }

            return false;
        }

        internal override void invalidar()
        {
            base.invalidar();

            this.objMapaDisplay.Invalidate();
        }

        internal TileGrafico selecionarTile(int x, int y, CamadaDominio objCamada)
        {
            if (objCamada == null)
            {
                return null;
            }

            if (!objCamada.Equals(this.objCamada))
            {
                return null;
            }

            List<TileGrafico> lstGfcTileTemp = new List<TileGrafico>(this.lstGfcTile);

            lstGfcTileTemp.Reverse();

            foreach (TileGrafico gfcTile in lstGfcTileTemp)
            {
                TileGrafico gfcResultado = gfcTile.selecionar(x, y);

                if (gfcResultado != null)
                {
                    this.invalidar();

                    return gfcResultado;
                }
            }

            return null;
        }

        protected override bool validarRenderizar()
        {
            if (!base.validarRenderizar())
            {
                return false;
            }

            if (this.objCamada == null)
            {
                return false;
            }

            if (!this.objCamada.attBooVisivel.booValor)
            {
                return false;
            }

            return true;
        }

        private void apagar(CamadaDominio objCamada, TileGrafico gfcTile)
        {
            if (!objCamada.removerTile(gfcTile.objTile))
            {
                return;
            }

            this.removerGfcTile(gfcTile);

            this.invalidar();
        }

        private TileGrafico getGfcTile(TileDominio objTile)
        {
            if (objTile == null)
            {
                return null;
            }

            if (objTile.gfcTile != null)
            {
                return objTile.gfcTile;
            }

            foreach (TileGrafico gfcTile in this.lstGfcTile)
            {
                if (!objTile.Equals(gfcTile.objTile))
                {
                    continue;
                }

                objTile.gfcTile = gfcTile;

                return gfcTile;
            }

            TileGrafico gfcTileNovo = null;

            if (objTile is PersonagemTileDominio)
            {
                gfcTileNovo = new PersonagemTileGrafico(this.objDisplay, (objTile as PersonagemTileDominio));
            }
            else
            {
                gfcTileNovo = new TileGrafico(this.objDisplay, objTile);
            }

            gfcTileNovo.gfcCamada = this;

            this.lstGfcTile.Add(gfcTileNovo);

            return gfcTileNovo;
        }

        private void removerGfcTile(TileGrafico gfcTile)
        {
            if (gfcTile == null)
            {
                return;
            }

            if (!this.lstGfcTile.Contains(gfcTile))
            {
                return;
            }

            this.lstGfcTile.Remove(gfcTile);

            gfcTile.Dispose();
        }

        private void renderizarPersonagemTile(Graphics gpc)
        {
            foreach (PersonagemTileDominio objTile in this.objCamada.lstObjPersonagemTile)
            {
                this.getGfcTile(objTile).renderizar(gpc);
            }
        }

        private void renderizarTile(Graphics gpc)
        {
            foreach (TileDominio objTile in this.objCamada.lstObjTile)
            {
                this.getGfcTile(objTile).renderizar(gpc);
            }
        }

        private void setObjCamada(CamadaDominio objCamada)
        {
            if (objCamada == null)
            {
                return;
            }

            objCamada.attBooVisivel.onStrValorAlterado += ((o, e) =>
            {
                this.invalidar();
                this.objDisplay.Invalidate();
            });

            objCamada.onAddTile += ((o, e) => this.invalidar());
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}