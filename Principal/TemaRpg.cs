using DigoFramework;

namespace Rpg
{
    public class TemaRpg : TemaBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private static TemaRpg _i;

        public static TemaRpg i
        {
            get
            {
                if (_i != null)
                {
                    return _i;
                }

                _i = new TemaRpg();

                return _i;
            }
        }

        #endregion Atributos

        #region Construtores

        private TemaRpg()
        {
        }

        #endregion Construtores

        #region Métodos

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}