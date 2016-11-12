using System.Collections.Generic;
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
            foreach (TileDominio objTile in this.objCamada.lstObjTile)
            {
                this.getGfcTile(objTile).renderizar(gpc);
            }
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
            if (!objCamada.lstObjTile.Contains(gfcTile.objTile))
            {
                return;
            }

            objCamada.removerTile(gfcTile.objTile);

            this.removerGfcTile(gfcTile);

            this.invalidar();
        }

        private TileGrafico getGfcTile(TileDominio objTile)
        {
            if (objTile == null)
            {
                return null;
            }

            foreach (TileGrafico gfcTile in this.lstGfcTile)
            {
                if (!objTile.Equals(gfcTile.objTile))
                {
                    continue;
                }

                return gfcTile;
            }

            TileGrafico gfcTileNovo = new TileGrafico(this.objDisplay, objTile);

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
            objCamada.onRemoverTile += ((o, e) => this.invalidar());
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}