using Rpg.Dominio;

namespace Rpg.Controle.TabDock
{
    public partial class TabDockPersonagem : TabDockRpgBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private PersonagemDominio _objPersonagem;

        public PersonagemDominio objPersonagem
        {
            get
            {
                return _objPersonagem;
            }

            set
            {
                _objPersonagem = value;
            }
        }

        #endregion Atributos

        #region Construtores

        public TabDockPersonagem()
        {
            this.InitializeComponent();
        }

        #endregion Construtores

        #region Métodos

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}