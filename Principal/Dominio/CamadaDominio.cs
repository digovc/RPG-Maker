using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Rpg.Dominio
{
    public class CamadaDominio : RpgDominioBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private Atributo _attBooVisivel;
        private List<TileDominio> _lstObjTile;

        [JsonIgnore]
        public Atributo attBooVisivel
        {
            get
            {
                if (_attBooVisivel != null)
                {
                    return _attBooVisivel;
                }

                _attBooVisivel = this.getAtt("Visível", true);

                return _attBooVisivel;
            }
        }

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

            this.onAddTile?.Invoke(this, EventArgs.Empty);
        }

        protected override void inicializar()
        {
            base.inicializar();

            this.attBooVisivel.booValor = this.attBooVisivel.booValor;
        }

        #endregion Métodos

        #region Eventos

        public event EventHandler onAddTile;

        #endregion Eventos
    }
}