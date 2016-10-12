using System;
using System.Windows.Forms;
using DigoFramework;
using Rpg.Controle.TabDock;
using Rpg.Dominio;

namespace Rpg.Frm
{
    public partial class FrmPrincipal : FrmRpgBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private RpgDominioBase _objDominioSelecionado;
        private TabDockJogoExplorer _tabDockJogoExplorer;

        private TabDockPropriedade _tabDockPropriedade;

        public RpgDominioBase objDominioSelecionado
        {
            get
            {
                return _objDominioSelecionado;
            }

            set
            {
                if (_objDominioSelecionado == value)
                {
                    return;
                }

                _objDominioSelecionado = value;

                this.setObjDominioSelecionado(_objDominioSelecionado);
            }
        }

        private TabDockJogoExplorer tabDockJogoExplorer
        {
            get
            {
                if (_tabDockJogoExplorer != null)
                {
                    return _tabDockJogoExplorer;
                }

                _tabDockJogoExplorer = new TabDockJogoExplorer();

                return _tabDockJogoExplorer;
            }
        }

        private TabDockPropriedade tabDockPropriedade
        {
            get
            {
                if (_tabDockPropriedade != null)
                {
                    return _tabDockPropriedade;
                }

                _tabDockPropriedade = new TabDockPropriedade();

                return _tabDockPropriedade;
            }
        }

        #endregion Atributos

        #region Construtores

        public FrmPrincipal()
        {
            this.InitializeComponent();
        }

        #endregion Construtores

        #region Métodos

        protected override void inicializar()
        {
            base.inicializar();

            AppRpg.i.frmPrincipal = this;

            this.WindowState = FormWindowState.Maximized;
        }

        private void abrirJogo(JogoDominio objJogo)
        {
            if (objJogo == null)
            {
                return;
            }

            this.tabDockJogoExplorer.Show(this.dcp, WeifenLuo.WinFormsUI.Docking.DockState.DockLeft);

            this.tabDockJogoExplorer.carregarJogo();
        }

        private void abrirJogo()
        {
            if (!DialogResult.OK.Equals(this.ofdJogo.ShowDialog()))
            {
                return;
            }

            AppRpg.i.abrirJogo(this.ofdJogo.FileName);

            this.abrirJogo(AppRpg.i.objJogo);
        }

        private void criarJogo()
        {
            if (!DialogResult.OK.Equals(this.sfdJogo.ShowDialog()))
            {
                return;
            }

            AppRpg.i.criarJogo(this.sfdJogo.FileName);

            this.abrirJogo(AppRpg.i.objJogo);
        }

        private void salvarJogo()
        {
            AppRpg.i.salvarJogo();
        }

        private void setObjDominioSelecionado(RpgDominioBase objDominioSelecionado)
        {
            if (objDominioSelecionado == null)
            {
                return;
            }

            if (!this.tabDockPropriedade.Visible)
            {
                return;
            }

            this.tabDockPropriedade.objDominio = objDominioSelecionado;
        }

        #endregion Métodos

        #region Eventos

        private void tsmExibirPropriedade_Click(object sender, EventArgs e)
        {
            try
            {
                this.tabDockPropriedade.Show(this.dcp, WeifenLuo.WinFormsUI.Docking.DockState.DockRight);
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex);
            }
        }

        private void tsmJogoAbrir_Click(object sender, EventArgs e)
        {
            try
            {
                this.abrirJogo();
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex);
            }
        }

        private void tsmJogoCriar_Click(object sender, EventArgs e)
        {
            try
            {
                this.criarJogo();
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex);
            }
        }

        private void tsmJogoSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                this.salvarJogo();
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex);
            }
        }

        #endregion Eventos
    }
}