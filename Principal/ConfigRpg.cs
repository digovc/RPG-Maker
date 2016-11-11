using DigoFramework;

namespace Rpg
{
    public class ConfigRpg : ConfigBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private static ConfigRpg _i;

        private int _intAudioFade = 1500;

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

        public int intAudioFade
        {
            get
            {
                return _intAudioFade;
            }

            set
            {
                _intAudioFade = value;
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