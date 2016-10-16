using System;
using System.Collections.Generic;
using System.IO;
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

        private List<ImagemDominio> _lstObjImg;
        private List<MapaDominio> _lstObjMapa;
        private RpgDominioBase _objDominioSelecionado;
        private TabDockArte _tabDockArte;
        private TabDockCamada _tabDockCamada;
        private TabDockDados _tabDockDados;
        private TabDockExplorer _tabDockExplorer;
        private TabDockImagem _tabDockImagemSelecionada;
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

        public TabDockImagem tabDockImagemSelecionada
        {
            get
            {
                return _tabDockImagemSelecionada;
            }

            set
            {
                _tabDockImagemSelecionada = value;
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

        private List<ImagemDominio> lstObjImg
        {
            get
            {
                if (_lstObjImg != null)
                {
                    return _lstObjImg;
                }

                _lstObjImg = new List<ImagemDominio>();

                return _lstObjImg;
            }
        }

        private List<MapaDominio> lstObjMapa
        {
            get
            {
                if (_lstObjMapa != null)
                {
                    return _lstObjMapa;
                }

                _lstObjMapa = new List<MapaDominio>();

                return _lstObjMapa;
            }
        }

        private TabDockArte tabDockArte
        {
            get
            {
                if (_tabDockArte != null)
                {
                    return _tabDockArte;
                }

                _tabDockArte = new TabDockArte();

                return _tabDockArte;
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

        private TabDockDados tabDockDados
        {
            get
            {
                if (_tabDockDados != null)
                {
                    return _tabDockDados;
                }

                _tabDockDados = new TabDockDados();

                return _tabDockDados;
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

        #endregion Atributos

        #region Construtores

        public FrmPrincipal()
        {
            this.InitializeComponent();
        }

        #endregion Construtores

        #region Métodos

        internal void abrirImagem(ImagemDominio objImg)
        {
            if (objImg == null)
            {
                return;
            }

            if (this.lstObjImg.Contains(objImg))
            {
                return;
            }

            TabDockImagem tabImagem = new TabDockImagem();

            tabImagem.objImagem = objImg;

            tabImagem.Show(this.pnlDockRpg, DockState.DockRight);

            this.lstObjImg.Add(objImg);
        }

        internal void abrirMapa(MapaDominio objMapa)
        {
            if (objMapa == null)
            {
                return;
            }

            if (this.lstObjMapa.Contains(objMapa))
            {
                return;
            }

            TabDockMapa tabMapa = new TabDockMapa();

            tabMapa.objMapa = objMapa;

            tabMapa.Show(this.pnlDockRpg, DockState.Document);

            this.lstObjMapa.Add(objMapa);
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

            this.tabDockExplorer.Show(this.pnlDockRpg, DockState.DockLeft);

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

        private void exibirTabDockArte()
        {
            if (AppRpg.i.objJogo == null)
            {
                return;
            }

            if (string.IsNullOrEmpty(AppRpg.i.objJogo.attDirCompleto.strValor))
            {
                return;
            }

            if (!File.Exists(AppRpg.i.objJogo.attDirCompleto.strValor))
            {
                return;
            }

            this.tabDockArte.Show(this.pnlDockRpg, DockState.DockLeft);
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

        private void setTabDockMapaSelecionado(TabDockMapa tabDockMapaSelecionado)
        {
            if (tabDockMapaSelecionado == null)
            {
                return;
            }

            this.tabDockCamada.objMapa = tabDockMapaSelecionado.objMapa;
        }

        #endregion Métodos

        #region Eventos

        private void tsmExibirArte_Click(object sender, EventArgs e)
        {
            try
            {
                this.exibirTabDockArte();
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex);
            }
        }

        private void tsmExibirCamada_Click(object sender, EventArgs e)
        {
            try
            {
                this.tabDockCamada.Show(this.pnlDockRpg, DockState.DockRight);
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex);
            }
        }

        private void tsmExibirDados_Click(object sender, EventArgs e)
        {
            try
            {
                this.tabDockDados.Show(this.pnlDockRpg, DockState.DockBottom);
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
                this.tabDockPropriedade.Show(this.pnlDockRpg, DockState.DockRight);
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
                this.tabDockMapa.Show(this.pnlDockRpg, DockState.DockTop);
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex);
            }
        }

        #endregion Eventos
    }
}