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

            this.lstGfcTile.Add(gfcTileNovo);

            return gfcTileNovo;
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