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
        private List<PersonagemTileDominio> _lstObjPersonagemTile;
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

        public List<PersonagemTileDominio> lstObjPersonagemTile
        {
            get
            {
                if (_lstObjPersonagemTile != null)
                {
                    return _lstObjPersonagemTile;
                }

                _lstObjPersonagemTile = new List<PersonagemTileDominio>();

                return _lstObjPersonagemTile;
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

            objCamada.iniciar(true);

            return objCamada;
        }

        internal void addPersonagemTile(PersonagemTileDominio objPersonagemTile)
        {
            if (objPersonagemTile == null)
            {
                return;
            }

            if (this.lstObjPersonagemTile.Contains(objPersonagemTile))
            {
                return;
            }

            this.lstObjPersonagemTile.Add(objPersonagemTile);

            this.onAddTile?.Invoke(objPersonagemTile, EventArgs.Empty);
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

        internal bool removerTile(TileDominio objTile)
        {
            if (objTile == null)
            {
                return false;
            }

            if (objTile is PersonagemTileDominio)
            {
                return this.lstObjPersonagemTile.Remove(objTile as PersonagemTileDominio);
            }

            return this.lstObjTile.Remove(objTile);
        }

        protected override void inicializar(bool booCriacao)
        {
            base.inicializar(booCriacao);

            if (booCriacao)
            {
                this.inicializarCriacao();
                return;
            }

            this.inicializarAbertura();
        }

        private void inicializarAbertura()
        {
            this.attBooVisivel.enmTipo = Atributo.EnmTipo.BOOLEAN;

            this.inicializarAberturaLstObjTile();
            this.inicializarAberturaLstObjPersonagemTile();
        }

        private void inicializarAberturaLstObjPersonagemTile()
        {
            foreach (PersonagemTileDominio objPersonagemTile in this.lstObjPersonagemTile)
            {
                objPersonagemTile?.iniciar(false);
            }
        }

        private void inicializarAberturaLstObjTile()
        {
            foreach (TileDominio objTile in this.lstObjTile)
            {
                objTile?.iniciar(false);
            }
        }

        private void inicializarCriacao()
        {
            this.attBooVisivel.booValor = true;
        }

        #endregion Métodos

        #region Eventos

        public event EventHandler onAddTile;

        #endregion Eventos
    }
}