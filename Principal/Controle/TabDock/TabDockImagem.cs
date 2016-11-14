using System;
using DigoFramework;
using Rpg.Dominio;

namespace Rpg.Controle.TabDock
{
    public partial class TabDockImagem : TabDockRpgBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private ImagemDominio _objImagem;

        public ImagemDominio objImagem
        {
            get
            {
                return _objImagem;
            }

            set
            {
                if (_objImagem == value)
                {
                    return;
                }

                _objImagem = value;

                this.setObjImagem(_objImagem);
            }
        }

        #endregion Atributos

        #region Construtores

        public TabDockImagem()
        {
            this.InitializeComponent();
        }

        #endregion Construtores

        #region Métodos

        private void ativarDesativarGrid()
        {
            this.txtTileTamanho.Enabled = !this.txtTileTamanho.Enabled;
            this.txtTileTamanho.Text = (!string.IsNullOrEmpty(this.txtTileTamanho.Text) ? this.txtTileTamanho.Text : "10");

            this.ctrImagem.intTileTamanho = this.txtTileTamanho.Enabled ? Convert.ToInt16(this.txtTileTamanho.Text) : 0;
        }

        private void atualizarTileTamanho()
        {
            if (string.IsNullOrEmpty(this.txtTileTamanho.Text))
            {
                return;
            }

            if (!Utils.getBooNumerico(this.txtTileTamanho.Text))
            {
                this.txtTileTamanho.Text = null;
                return;
            }

            this.ctrImagem.intTileTamanho = Convert.ToInt16(this.txtTileTamanho.Text);
        }

        private void selecinarTudo()
        {
            this.ctrImagem.selecionarTudo();
        }

        private void setObjImagem(ImagemDominio objImagem)
        {
            this.ctrImagem.objImagem = objImagem;

            if (objImagem == null)
            {
                return;
            }

            this.Text = objImagem.attStrNome.strValor;
        }

        #endregion Métodos

        #region Eventos

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);

            try
            {
                AppRpg.i.frmPrincipal.tabDockImagemSelecionada = this;
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex);
            }
        }

        private void btnAtivarGrid_Click(object sender, EventArgs e)
        {
            try
            {
                this.ativarDesativarGrid();
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex);
            }
        }

        private void btnSelecionarTudo_Click(object sender, EventArgs e)
        {
            try
            {
                this.selecinarTudo();
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex);
            }
        }

        private void txtTileTamanho_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.atualizarTileTamanho();
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex);
            }
        }

        #endregion Eventos
    }
}