using Rpg.Dominio;

namespace Rpg.Controle.Editor
{
    public partial class MapaDisplay : DisplayBase
    {
        #region Constantes

        private const int INT_TILE_TAMANHO = 50;

        #endregion Constantes

        #region Atributos

        private MapaDominio _objMapa;

        public MapaDominio objMapa
        {
            get
            {
                return _objMapa;
            }

            set
            {
                _objMapa = value;
            }
        }

        #endregion Atributos

        #region Construtores

        public MapaDisplay()
        {
            this.InitializeComponent();
        }

        #endregion Construtores

        #region Métodos

        protected override int getIntQuantidadeX()
        {
            if (this.objMapa == null)
            {
                return 0;
            }

            return this.objMapa.attQuantidadeX.intValor;
        }

        protected override int getIntQuantidadeY()
        {
            if (this.objMapa == null)
            {
                return 0;
            }

            return this.objMapa.attQuantidadeY.intValor;
        }

        protected override int getIntTileTamanho()
        {
            return INT_TILE_TAMANHO;
        }

        protected override bool validarRenderizar()
        {
            if (!base.validarRenderizar())
            {
                return false;
            }

            if (this.objMapa == null)
            {
                return false;
            }

            return true;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}