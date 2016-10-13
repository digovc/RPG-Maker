using System.Collections.Generic;
using Newtonsoft.Json;

namespace Rpg.Dominio
{
    public class MapaDominio : ArquivoDominio
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private Atributo _attTamanhoX;
        private Atributo _attTamanhoY;
        private List<CamadaDominio> _lstObjCamada;

        [JsonIgnore]
        public Atributo attTamanhoX
        {
            get
            {
                if (_attTamanhoX != null)
                {
                    return _attTamanhoX;
                }

                _attTamanhoX = this.getAtt("Tamanho X");

                return _attTamanhoX;
            }
        }

        [JsonIgnore]
        public Atributo attTamanhoY
        {
            get
            {
                if (_attTamanhoY != null)
                {
                    return _attTamanhoY;
                }

                _attTamanhoY = this.getAtt("Tamanho Y");

                return _attTamanhoY;
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

        protected override void inicializar()
        {
            base.inicializar();

            this.attTamanhoX.intValor = 25;
            this.attTamanhoY.intValor = 25;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}