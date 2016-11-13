using System.Collections.Generic;
using System.Linq;
using Rpg.Controle.Painel;
using Rpg.Dominio;

namespace Rpg.Controle.TabDock
{
    public partial class TabDockPropriedade : TabDockRpgBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private RpgDominioBase _objSelecionado;

        public RpgDominioBase objSelecionado
        {
            get
            {
                return _objSelecionado;
            }

            set
            {
                if (_objSelecionado == value)
                {
                    return;
                }

                _objSelecionado = value;

                this.setObjSelecionado(_objSelecionado);
            }
        }

        #endregion Atributos

        #region Construtores

        public TabDockPropriedade()
        {
            this.InitializeComponent();
        }

        #endregion Construtores

        #region Métodos

        protected override void inicializar()
        {
            base.inicializar();

            this.objSelecionado = AppRpg.i.frmPrincipal.objSelecionado;
        }

        protected override void setEventos()
        {
            base.setEventos();

            AppRpg.i.frmPrincipal.onObjSelecionadoChanged += this.frmPrincipal_onObjSelecionadoChanged;
        }

        private void atualizarLayout()
        {
            // TODO: Chamar o dispose para todos os componentes em vez de apenas limpar a lista.
            this.pnlConteudo.Controls.Clear();

            if (objSelecionado.lstAtt == null)
            {
                return;
            }

            foreach (string strGrupo in this.objSelecionado.lstStrGrupo)
            {
                this.atualizarLayout(strGrupo);
            }
        }

        private void atualizarLayout(string strGrupo)
        {
            if (string.IsNullOrEmpty(strGrupo))
            {
                return;
            }

            List<Atributo> lstAttGrupo = this.objSelecionado.lstAtt.Where((att) => strGrupo.Equals(att.strGrupo)).ToList();

            if (lstAttGrupo == null)
            {
                return;
            }

            PnlAtributoGrupo pnlAttGrupo = new PnlAtributoGrupo();

            pnlAttGrupo.atualizarLayout(strGrupo, lstAttGrupo);

            this.pnlConteudo.Controls.Add(pnlAttGrupo);
            this.pnlConteudo.Controls.SetChildIndex(pnlAttGrupo, 0);
        }

        private void setObjSelecionado(RpgDominioBase objSelecionado)
        {
            if (!this.Visible)
            {
                return;
            }

            if (objSelecionado == null)
            {
                return;
            }

            if (objSelecionado is ArquivoRefDominio)
            {
                this.setobjSelecionadoArqRef((ArquivoRefDominio)objSelecionado);
                return;
            }

            this.atualizarLayout();
        }

        private void setobjSelecionadoArqRef(ArquivoRefDominio objArquivoRef)
        {
            if (objArquivoRef == null)
            {
                return;
            }

            if (objArquivoRef.objArquivo == null)
            {
                return;
            }

            this.objSelecionado = objArquivoRef.objArquivo;
        }

        #endregion Métodos

        #region Eventos

        private void frmPrincipal_onObjSelecionadoChanged(object sender, RpgDominioBase objSelecionado)
        {
            this.objSelecionado = objSelecionado;
        }

        #endregion Eventos
    }
}