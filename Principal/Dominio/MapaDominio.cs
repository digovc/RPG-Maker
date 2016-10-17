using System.Collections.Generic;
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

            objMapaResultado.iniciar();

            return objMapaResultado;
        }

        protected override void inicializar()
        {
            base.inicializar();

            this.inicializarattIntQuantidadeX();
            this.inicializarattIntQuantidadeY();
        }

        private void inicializarattIntQuantidadeX()
        {
            if (this.attIntQuantidadeX.intValor > 0)
            {
                return;
            }

            this.attIntQuantidadeX.intValor = 25;
        }

        private void inicializarattIntQuantidadeY()
        {
            if (this.attIntQuantidadeY.intValor > 0)
            {
                return;
            }

            this.attIntQuantidadeY.intValor = 25;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}