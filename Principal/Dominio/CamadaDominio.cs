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

        internal static CamadaDominio criar(int intIndex)
        {
            CamadaDominio objCamada = new CamadaDominio();

            objCamada.attStrNome.strValor = string.Format("Camada {0}", intIndex);

            objCamada.iniciar();

            return objCamada;
        }

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

            this.onAddTile?.Invoke(objTile, EventArgs.Empty);
        }

        internal bool removerTile(int x, int y)
        {
            foreach (TileDominio objTile in this.lstObjTile)
            {
                if (this.removerTile(x, y, objTile))
                {
                    return true;
                }
            }

            return false;
        }

        protected override void inicializar()
        {
            base.inicializar();

            this.attBooVisivel.booValor = this.attBooVisivel.booValor;
            this.attBooVisivel.enmTipo = Atributo.EnmTipo.BOOLEAN;
        }

        private bool removerTile(int x, int y, TileDominio objTile)
        {
            if (objTile == null)
            {
                return false;
            }

            if (!objTile.rtgMapa.Contains(x, y))
            {
                return false;
            }

            this.lstObjTile.Remove(objTile);

            this.onRemoverTile?.Invoke(objTile, EventArgs.Empty);
            return true;
        }

        #endregion Métodos

        #region Eventos

        public event EventHandler onAddTile;

        public event EventHandler onRemoverTile;

        #endregion Eventos
    }
}