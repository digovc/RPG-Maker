using System;
using DigoFramework;
using Rpg.Dominio;

namespace Rpg.Controle.TabDock
{
    public partial class TabDockMapa : TabDockRpgBase
    {
        #region Constantes

        public enum EnmFerramenta
        {
            BORRACHA,
            LAPIS,
            SELECIONAR,
        }

        #endregion Constantes

        #region Atributos

        private EnmFerramenta _enmFerramenta = EnmFerramenta.LAPIS;
        private MapaDominio _objMapa;

        public EnmFerramenta enmFerramenta
        {
            get
            {
                return _enmFerramenta;
            }

            set
            {
                _enmFerramenta = value;
            }
        }

        public MapaDominio objMapa
        {
            get
            {
                return _objMapa;
            }

            set
            {
                if (_objMapa == value)
                {
                    return;
                }

                _objMapa = value;

                this.setObjMapa(_objMapa);
            }
        }

        #endregion Atributos

        #region Construtores

        public TabDockMapa()
        {
            this.InitializeComponent();
        }

        #endregion Construtores

        #region Métodos

        protected override void inicializar()
        {
            base.inicializar();

            this.ctrMapa.tabDockMapa = this;
        }

        private void carregarMapa()
        {
            this.ctrMapa.objMapa = this.objMapa;
        }

        private void setObjMapa(MapaDominio objMapa)
        {
            if (objMapa == null)
            {
                return;
            }

            this.Text = this.objMapa.attStrNome.strValor;

            this.carregarMapa();
        }

        #endregion Métodos

        #region Eventos

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);

            try
            {
                AppRpg.i.frmPrincipal.tabDockMapaSelecionado = this;
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex);
            }
        }

        private void btnBorracha_Click(object sender, EventArgs e)
        {
            try
            {
                this.enmFerramenta = EnmFerramenta.BORRACHA;
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex);
            }
        }

        private void btnLapis_Click(object sender, EventArgs e)
        {
            try
            {
                this.enmFerramenta = EnmFerramenta.LAPIS;
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex);
            }
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            try
            {
                this.enmFerramenta = EnmFerramenta.SELECIONAR;
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex);
            }
        }

        #endregion Eventos
    }
}