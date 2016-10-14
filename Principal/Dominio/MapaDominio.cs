using System.Collections.Generic;
using Newtonsoft.Json;

namespace Rpg.Dominio
{
    public class MapaDominio : ArquivoDominio
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private Atributo _attQuantidadeX;
        private Atributo _attQuantidadeY;
        private List<CamadaDominio> _lstObjCamada;

        [JsonIgnore]
        public Atributo attQuantidadeX
        {
            get
            {
                if (_attQuantidadeX != null)
                {
                    return _attQuantidadeX;
                }

                _attQuantidadeX = this.getAtt("Quantidade X");

                return _attQuantidadeX;
            }
        }

        [JsonIgnore]
        public Atributo attQuantidadeY
        {
            get
            {
                if (_attQuantidadeY != null)
                {
                    return _attQuantidadeY;
                }

                _attQuantidadeY = this.getAtt("Quantidade Y");

                return _attQuantidadeY;
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

        internal static MapaDominio criar(int intIndex)
        {
            MapaDominio objMapaResultado = new MapaDominio();

            objMapaResultado.attNome.strValor = string.Format("Mapa {0}", intIndex);

            objMapaResultado.iniciar();

            return objMapaResultado;
        }

        protected override void inicializar()
        {
            base.inicializar();

            this.inicializarAttQuantidadeX();
            this.inicializarAttQuantidadeY();
        }

        private void inicializarAttQuantidadeX()
        {
            if (this.attQuantidadeX.intValor > 0)
            {
                return;
            }

            this.attQuantidadeX.intValor = 25;
        }

        private void inicializarAttQuantidadeY()
        {
            if (this.attQuantidadeY.intValor > 0)
            {
                return;
            }

            this.attQuantidadeY.intValor = 25;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}