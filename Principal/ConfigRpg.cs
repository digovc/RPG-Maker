using NetZ.Web;

namespace Rpg
{
    public class ConfigRpg : ConfigWebBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private static ConfigRpg _i;

        public new static ConfigRpg i
        {
            get
            {
                if (_i != null)
                {
                    return _i;
                }

                _i = new ConfigRpg();

                return _i;
            }
        }

        #endregion Atributos

        #region Construtores

        private ConfigRpg()
        {
        }

        #endregion Construtores

        #region Métodos

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}