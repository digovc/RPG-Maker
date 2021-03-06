﻿using System;
using System.Drawing;
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
            REDIMENSIONAR,
            SELECIONAR,
        }

        #endregion Constantes

        #region Atributos

        private EnmFerramenta _enmFerramenta = EnmFerramenta.LAPIS;
        private CamadaDominio _objCamadaSelecionada;
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

        public CamadaDominio objCamadaSelecionada
        {
            get
            {
                return _objCamadaSelecionada;
            }

            private set
            {
                if (_objCamadaSelecionada == value)
                {
                    return;
                }

                _objCamadaSelecionada = value;

                this.setObjCamadaSelecionada(_objCamadaSelecionada);
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

        internal void addPersonagem(PersonagemDominio objPersonagem)
        {
            if (objPersonagem == null)
            {
                return;
            }

            if (this.objMapa == null)
            {
                return;
            }

            this.ctrMapa.addPersonagem(objPersonagem);
        }

        protected override void inicializar()
        {
            base.inicializar();

            this.ctrMapa.tabDockMapa = this;
        }

        protected override void setEventos()
        {
            base.setEventos();

            AppRpg.i.frmPrincipal.onObjSelecionadoChanged += this.frmPrincipal_onObjSelecionadoChanged;
        }

        private void addBackground()
        {
            if (this.objMapa == null)
            {
                return;
            }

            if (AppRpg.i.frmPrincipal.tabDockImagemSelecionada == null)
            {
                return;
            }

            this.addBackground(AppRpg.i.frmPrincipal.tabDockImagemSelecionada);
        }

        private void addBackground(TabDockImagem tabDockImagem)
        {
            TileDominio objTileBackground = new TileDominio();

            objTileBackground.dirImagem = tabDockImagem.objImagem.attDirCompleto.strValor;
            objTileBackground.rtgImg = this.addBackgroundSelecao(tabDockImagem);

            this.objMapa.objTileBackground = objTileBackground;
        }

        private Rectangle addBackgroundSelecao(TabDockImagem tabDockImagem)
        {
            if (tabDockImagem.ctrImagem.objSelecao.rtg.Equals(default(Rectangle)))
            {
                return this.addBackgroundSelecaoTudo(tabDockImagem.objImagem);
            }

            return tabDockImagem.ctrImagem.objSelecao.rtg;
        }

        private Rectangle addBackgroundSelecaoTudo(ImagemDominio objImagem)
        {
            int h = AppRpg.i.getBmpCache(objImagem.attDirCompleto.strValor).Height;
            int w = AppRpg.i.getBmpCache(objImagem.attDirCompleto.strValor).Width;

            return new Rectangle(0, 0, w, h);
        }

        private void atualizarObjSelecionado(RpgDominioBase objSelecionado)
        {
            if (objSelecionado == null)
            {
                return;
            }

            if (objSelecionado is CamadaDominio)
            {
                this.atualizarObjSelecionadoCamada(objSelecionado as CamadaDominio);
            }
        }

        private void atualizarObjSelecionadoCamada(CamadaDominio objCamada)
        {
            if (this.objMapa == null)
            {
                return;
            }

            if (!this.objMapa.lstObjCamada.Contains(objCamada))
            {
                return;
            }

            this.objCamadaSelecionada = objCamada;
        }

        private void carregarMapa()
        {
            this.ctrMapa.objMapa = this.objMapa;
        }

        private void removerBackground()
        {
            if (this.objMapa == null)
            {
                return;
            }

            this.objMapa.objTileBackground = null;
        }

        private void setObjCamadaSelecionada(CamadaDominio objCamadaSelecionada)
        {
            this.Text = this.objMapa.attStrNome.strValor;

            if (objCamadaSelecionada == null)
            {
                return;
            }

            this.Text = string.Format("{0} (camada: {1})", this.objMapa.attStrNome.strValor, objCamadaSelecionada.attStrNome.strValor);
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

        private void btnAddBackground_Click(object sender, EventArgs e)
        {
            try
            {
                this.addBackground();
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

        private void btnRedimensionar_Click(object sender, EventArgs e)
        {
            try
            {
                this.enmFerramenta = EnmFerramenta.REDIMENSIONAR;
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex);
            }
        }

        private void btnRemoverBackground_Click(object sender, EventArgs e)
        {
            try
            {
                this.removerBackground();
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

        private void frmPrincipal_onObjSelecionadoChanged(object sender, RpgDominioBase objSelecionado)
        {
            this.atualizarObjSelecionado(objSelecionado);
        }

        #endregion Eventos
    }
}