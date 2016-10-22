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

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        internal static MapaDominio criar(int intIndex)
        {
            MapaDominio objMapaResultado = new MapaDominio();

            objMapaResultado.attStrNome.strValor = string.Format("Mapa {0}", intIndex);

            objMapaResultado.iniciar(true);

            return objMapaResultado;
        }

        internal override bool validarItem(RpgDominioBase objDominio)
        {
            if (!base.validarItem(objDominio))
            {
                return false;
            }

            if (objDominio is CamadaDominio)
            {
                return true;
            }

            return false;
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