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

        [JsonIgnore]
        private Atributo attTamanhoX
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
        private Atributo attTamanhoY
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

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos
        protected override void inicializar()
        {
            base.inicializar();

            this.attTamanhoX.decValor = 25;
            this.attTamanhoY.decValor = 25;
        }
        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}