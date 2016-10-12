using Newtonsoft.Json;

namespace Rpg.Dominio
{
    public class ArquivoDominio : ContainerDominioBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private Atributo _attDirCompleto;

        [JsonIgnore]
        public Atributo attDirCompleto
        {
            get
            {
                if (_attDirCompleto != null)
                {
                    return _attDirCompleto;
                }

                _attDirCompleto = this.getAtt("Diretório");

                return _attDirCompleto;
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}