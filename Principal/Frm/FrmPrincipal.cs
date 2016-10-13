using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DigoFramework;
using Rpg.Controle.TabDock;
using Rpg.Dominio;
using WeifenLuo.WinFormsUI.Docking;

namespace Rpg.Frm
{
    public partial class FrmPrincipal : FrmRpgBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private List<MapaDominio> _lstObjMapaAberto;
        private RpgDominioBase _objDominioSelecionado;
        private TabDockCamada _tabDockCamada;
        private TabDockExplorer _tabDockExplorer;
        private TabDockMapa _tabDockMapa;
        private TabDockMapa _tabDockMapaSelecionado;
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

        public TabDockMapa tabDockMapaSelecionado
        {
            get
            {
                return _tabDockMapaSelecionado;
            }

            set
            {
                if (_tabDockMapaSelecionado == value)
                {
                    return;
                }

                _tabDockMapaSelecionado = value;

                this.setTabDockMapaSelecionado(_tabDockMapaSelecionado);
            }
        }


        private List<MapaDominio> lstObjMapaAberto
        {
            get
            {
                if (_lstObjMapaAberto != null)
                {
                    return _lstObjMapaAberto;
                }

                _lstObjMapaAberto = new List<MapaDominio>();

                return _lstObjMapaAberto;
            }
        }

        private TabDockCamada tabDockCamada
        {
            get
            {
                if (_tabDockCamada != null)
                {
                    return _tabDockCamada;
                }

                _tabDockCamada = new TabDockCamada();

                return _tabDockCamada;
            }
        }

        private TabDockExplorer tabDockExplorer
        {
            get
            {
                if (_tabDockExplorer != null)
                {
                    return _tabDockExplorer;
                }

                _tabDockExplorer = new TabDockExplorer();

                return _tabDockExplorer;
            }
        }

        private TabDockMapa tabDockMapa
        {
            get
            {
                if (_tabDockMapa != null)
                {
                    return _tabDockMapa;
                }

                _tabDockMapa = new TabDockMapa();

                return _tabDockMapa;
            }
        }

        public TabDockPropriedade tabDockPropriedade
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

        private void setTabDockMapaSelecionado(TabDockMapa tabDockMapaSelecionado)
        {
            if (tabDockMapaSelecionado == null)
            {
                return;
            }

            this.tabDockCamada.carregarMapa(tabDockMapaSelecionado.objMapa);
        }

        internal void abrirMapa(MapaDominio objMapa)
        {
            if (objMapa == null)
            {
                return;
            }

            if (this.lstObjMapaAberto.Contains(objMapa))
            {
                return;
            }

            TabDockMapa tabMapa = new TabDockMapa();

            tabMapa.objMapa = objMapa;

            tabMapa.Show(this.dcp, DockState.Document);
        }

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

            this.tabDockExplorer.Show(this.dcp, WeifenLuo.WinFormsUI.Docking.DockState.DockLeft);

            this.tabDockExplorer.carregarJogo();
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

        private void tsmCamada_Click(object sender, EventArgs e)
        {
            try
            {
                this.tabDockCamada.Show(this.dcp, WeifenLuo.WinFormsUI.Docking.DockState.DockRight);
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex);
            }
        }

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

        private void tsmMapa_Click(object sender, EventArgs e)
        {
            try
            {
                this.tabDockMapa.Show(this.dcp, WeifenLuo.WinFormsUI.Docking.DockState.DockTop);
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex);
            }
        }

        #endregion Eventos
    }
}