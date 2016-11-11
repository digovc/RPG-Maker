﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace Rpg.Dominio
{
    public class MapaDominio : ArquivoDominio
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private Atributo _attIntQuantidadeX;
        private Atributo _attIntQuantidadeY;
        private List<CamadaDominio> _lstObjCamada;

        private List<PersonagemTileDominio> _lstObjPersonagemTile;

        [JsonIgnore]
        public Atributo attIntQuantidadeX
        {
            get
            {
                if (_attIntQuantidadeX != null)
                {
                    return _attIntQuantidadeX;
                }

                _attIntQuantidadeX = this.getAtt("Quantidade X");

                return _attIntQuantidadeX;
            }
        }

        [JsonIgnore]
        public Atributo attIntQuantidadeY
        {
            get
            {
                if (_attIntQuantidadeY != null)
                {
                    return _attIntQuantidadeY;
                }

                _attIntQuantidadeY = this.getAtt("Quantidade Y");

                return _attIntQuantidadeY;
            }
        }

        public List<CamadaDominio> lstObjCamada
        {
            get
            {
                if (_lstObjCamada != null)
                {
                    return _lstObjCamada;
                }

                _lstObjCamada = new List<CamadaDominio>();

                return _lstObjCamada;
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

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        public void addCamada(CamadaDominio objCamada)
        {
            if (objCamada == null)
            {
                return;
            }

            if (this.lstObjCamada.Contains(objCamada))
            {
                return;
            }

            this.lstObjCamada.Add(objCamada);
        }

        internal static MapaDominio criar(int intIndex)
        {
            MapaDominio objMapaResultado = new MapaDominio();

            objMapaResultado.attStrNome.strValor = string.Format("Mapa {0}", intIndex);

            objMapaResultado.iniciar(true);

            return objMapaResultado;
        }

        internal void addPersonagem(PersonagemDominio objPersonagem)
        {
            if (objPersonagem == null)
            {
                return;
            }

            PersonagemTileDominio objPersonagemTile = new PersonagemTileDominio();

            objPersonagemTile.dirImg = objPersonagem.attDirCompleto.strValor;
            objPersonagemTile.objPersonagem = objPersonagem;

            this.lstObjPersonagemTile.Add(objPersonagemTile);
        }

        protected override void inicializar(bool booCriacao)
        {
            base.inicializar(booCriacao);

            this.inicializarAttIntQuantidadeX(booCriacao);
            this.inicializarAttIntQuantidadeY(booCriacao);
        }

        private void inicializarAttIntQuantidadeX(bool booCriacao)
        {
            this.attIntQuantidadeX.enmTipo = Atributo.EnmTipo.NUMERICO;
            this.attIntQuantidadeX.intValorMaximo = 250;

            if (booCriacao)
            {
                this.attIntQuantidadeX.intValor = 25;
            }
        }

        private void inicializarAttIntQuantidadeY(bool booCriacao)
        {
            this.attIntQuantidadeY.enmTipo = Atributo.EnmTipo.NUMERICO;
            this.attIntQuantidadeY.intValorMaximo = 250;

            if (booCriacao)
            {
                this.attIntQuantidadeY.intValor = 25;
            }
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}