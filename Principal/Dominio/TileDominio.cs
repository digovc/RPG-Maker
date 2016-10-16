using System.Drawing;

namespace Rpg.Dominio
{
    public class TileDominio : RpgDominioBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private bool _booFixo;
        private string _dirImg;
        private Rectangle _rtgImg;
        private Rectangle _rtgMapa;

        public bool booFixo
        {
            get
            {
                return _booFixo;
            }

            set
            {
                _booFixo = value;
            }
        }

        public string dirImg
        {
            get
            {
                return _dirImg;
            }

            set
            {
                _dirImg = value;
            }
        }

        public Rectangle rtgImg
        {
            get
            {
                return _rtgImg;
            }

            set
            {
                _rtgImg = value;
            }
        }

        public Rectangle rtgMapa
        {
            get
            {
                return _rtgMapa;
            }

            set
            {
                _rtgMapa = value;
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