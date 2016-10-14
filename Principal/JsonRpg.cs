using DigoFramework.Json;
using Newtonsoft.Json;

namespace Rpg
{
    public class JsonRpg : Json
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private static JsonRpg _i;

        public new static JsonRpg i
        {
            get
            {
                if (_i != null)
                {
                    return _i;
                }

                _i = new JsonRpg();

                return _i;
            }
        }

        #endregion Atributos

        #region Construtores

        private JsonRpg()
        {
        }

        #endregion Construtores

        #region Métodos

        protected override JsonSerializerSettings getCfg()
        {
            JsonSerializerSettings cfgResultado = new JsonSerializerSettings();

            cfgResultado.TypeNameHandling = TypeNameHandling.All;

            return cfgResultado;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}