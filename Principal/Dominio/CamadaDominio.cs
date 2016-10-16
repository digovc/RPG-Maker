using System.Collections.Generic;

namespace Rpg.Dominio
{
    public class CamadaDominio : RpgDominioBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private List<TileDominio> _lstObjTile;

        public List<TileDominio> lstObjTile
        {
            get
            {
                if (_lstObjTile != null)
                {
                    return _lstObjTile;
                }

                _lstObjTile = new List<TileDominio>();

                return _lstObjTile;
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        internal void addTile(TileDominio objTile)
        {
            if (objTile == null)
            {
                return;
            }

            if (this.lstObjTile.Contains(objTile))
            {
                return;
            }

            this.lstObjTile.Add(objTile);
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}