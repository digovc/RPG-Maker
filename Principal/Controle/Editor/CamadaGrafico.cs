using System.Collections.Generic;
using System.Drawing;
using Rpg.Dominio;

namespace Rpg.Controle.Editor
{
    public class CamadaGrafico : GraficoBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private List<TileGrafico> _lstGfcTile;
        private CamadaDominio _objCamada;

        public CamadaDominio objCamada
        {
            get
            {
                return _objCamada;
            }

            private set
            {
                _objCamada = value;
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

        #endregion Atributos

        #region Construtores

        public CamadaGrafico(DisplayBase objDisplay, CamadaDominio objCamada) : base(objDisplay)
        {
            this.objCamada = objCamada;
        }

        #endregion Construtores

        #region Métodos

        internal override void renderizar(Graphics gpc)
        {
            base.renderizar(gpc);

            if (this.objCamada == null)
            {
                return;
            }

            if (!this.objCamada.attBooVisivel.booValor)
            {
                return;
            }

            foreach (TileDominio objTile in this.objCamada.lstObjTile)
            {
                this.getGfcTile(objTile).renderizar(gpc);
            }
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

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}