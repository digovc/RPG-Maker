using System;
using System.Collections.Generic;
using System.Linq;
using Rpg.Controle.EditAtributo;
using Rpg.Controle.Painel;
using Rpg.Dominio;

namespace Rpg.Controle.TabDock
{
    public partial class TabDockPropriedade : TabDockRpgBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private RpgDominioBase _objDominio;

        public RpgDominioBase objDominio
        {
            get
            {
                return _objDominio;
            }

            set
            {
                if (_objDominio == value)
                {
                    return;
                }

                _objDominio = value;

                this.setObjDominio(_objDominio);
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

            this.objDominio = AppRpg.i.frmPrincipal.objSelecionado;
        }

        private void setObjDominio(RpgDominioBase objDominio)
        {
            if (objDominio == null)
            {
                return;
            }

            if (objDominio is ArquivoRefDominio)
            {
                this.setObjDominioArqRef((ArquivoRefDominio)objDominio);
                return;
            }

            this.atualizarLayout();
        }

        private void atualizarLayout()
        {
            // TODO: Chamar o dispose para todos os componentes em vez de apenas limpar a lista.
            this.pnlConteudo.Controls.Clear();

            if (objDominio.lstAtt == null)
            {
                return;
            }

            foreach (string strGrupo in this.objDominio.lstStrGrupo)
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

            List<Atributo> lstAttGrupo = this.objDominio.lstAtt.Where((att) => strGrupo.Equals(att.strGrupo)).ToList();

            if (lstAttGrupo == null)
            {
                return;
            }

            PnlAtributoGrupo pnlAttGrupo = new PnlAtributoGrupo();

            pnlAttGrupo.atualizarLayout(strGrupo, lstAttGrupo);

            this.pnlConteudo.Controls.Add(pnlAttGrupo);
            this.pnlConteudo.Controls.SetChildIndex(pnlAttGrupo, 0);
        }

        private void setObjDominioArqRef(ArquivoRefDominio objArquivoRef)
        {
            if (objArquivoRef == null)
            {
                return;
            }

            if (objArquivoRef.objArquivo == null)
            {
                return;
            }

            this.objDominio = objArquivoRef.objArquivo;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}