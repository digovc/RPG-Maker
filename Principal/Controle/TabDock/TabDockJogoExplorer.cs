using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DigoFramework;
using Rpg.Dominio;

namespace Rpg.Controle.TabDock
{
    public partial class TabDockJogoExplorer : TabDockRpgBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        #endregion Atributos

        #region Construtores

        public TabDockJogoExplorer()
        {
            this.InitializeComponent();
        }

        #endregion Construtores

        #region Métodos

        private void atualizarNodeSelecionado(TreeNode trn)
        {
            if (trn == null)
            {
                return;
            }

            if (!(trn is TreeNodeRpg))
            {
                return;
            }

            AppRpg.i.frmPrincipal.objDominioSelecionado = (trn as TreeNodeRpg).objDominio;
        }

        internal void carregarJogo()
        {
            if (AppRpg.i.objJogo == null)
            {
                return;
            }

            this.trv.Nodes.Clear();

            TreeNodeRpg trnJogo = new TreeNodeRpg(AppRpg.i.objJogo);

            this.trv.Nodes.Add(trnJogo);

            foreach (RpgDominioBase objDominio in AppRpg.i.objJogo.lstObjFilho)
            {
                this.carregarJogo(objDominio, trnJogo);
            }
        }

        private void addItem()
        {
            if (AppRpg.i.objJogo == null)
            {
                return;
            }

            if (this.trv.SelectedNode == null)
            {
                return;
            }

            this.cmsAddItem.Show(Cursor.Position.X, Cursor.Position.Y);
        }

        private void addItem(Type clsDominio)
        {
            if (clsDominio == null)
            {
                return;
            }

            if (clsDominio.IsAssignableFrom(typeof(RpgDominioBase)))
            {
                return;
            }

            if (this.trv.SelectedNode == null)
            {
                return;
            }

            if (!(this.trv.SelectedNode is TreeNodeRpg))
            {
                return;
            }

            if ((this.trv.SelectedNode as TreeNodeRpg).objDominio == null)
            {
                return;
            }

            if (!((this.trv.SelectedNode as TreeNodeRpg).objDominio is ContainerDominioBase))
            {
                return;
            }

            ContainerDominioBase objContainer = ((this.trv.SelectedNode as TreeNodeRpg).objDominio as ContainerDominioBase);

            if (!objContainer.validarItem(clsDominio))
            {
                return;
            }

            RpgDominioBase objDominio = (RpgDominioBase)Activator.CreateInstance(clsDominio);

            objContainer.addFilho(objDominio);

            this.addTrn(new TreeNodeRpg(objDominio));
        }

        private void addItemGrupo()
        {
            if (AppRpg.i.objJogo == null)
            {
                return;
            }

            this.addItem(typeof(GrupoDominio));
        }

        private void addTrn(TreeNodeRpg trn)
        {
            if (this.trv.SelectedNode == null)
            {
                return;
            }

            this.trv.SelectedNode.Nodes.Add(trn);

            this.trv.SelectedNode = trn;
        }

        private void carregarJogo(RpgDominioBase objDominio, TreeNodeRpg trn)
        {
            if (objDominio == null)
            {
                return;
            }

            TreeNodeRpg trnFilho = new TreeNodeRpg(objDominio);

            trn.Nodes.Add(trnFilho);

            if (!(typeof(ContainerDominioBase).IsAssignableFrom(objDominio.GetType())))
            {
                return;
            }

            foreach (RpgDominioBase objDominioFilho in (objDominio as ContainerDominioBase).lstObjFilho)
            {
                this.carregarJogo(objDominioFilho, trnFilho);
            }
        }

        #endregion Métodos

        #region Eventos

        private void trv_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                this.atualizarNodeSelecionado(e.Node);
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex);
            }
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.addItem();
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex);
            }
        }

        private void tsmAddItemGrupo_Click(object sender, EventArgs e)
        {
            try
            {
                this.addItemGrupo();
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex);
            }
        }

        #endregion Eventos

    }
}