using System;
using System.IO;
using System.Windows.Forms;
using DigoFramework;
using Rpg.Dominio;

namespace Rpg.Controle.TabDock
{
    public partial class TabDockExplorer : TabDockRpgBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        #endregion Atributos

        #region Construtores

        public TabDockExplorer()
        {
            this.InitializeComponent();
        }

        #endregion Construtores

        #region Métodos

        internal void carregarJogo()
        {
            if (AppRpg.i.objJogo == null)
            {
                return;
            }

            this.trv.Nodes.Clear();

            TreeNodeRpg trnJogo = new TreeNodeRpg(AppRpg.i.objJogo);

            this.trv.Nodes.Add(trnJogo);

            foreach (RpgDominioBase objFilho in AppRpg.i.objJogo.lstObjFilho)
            {
                if (objFilho == null)
                {
                    continue;
                }

                objFilho.objPai = AppRpg.i.objJogo;

                this.carregarJogo(objFilho, trnJogo);
            }
        }

        private void abrirMapa(MapaDominio objMapa)
        {
            AppRpg.i.frmPrincipal.abrirMapa(objMapa);
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

        private void addItem(RpgDominioBase objDominio)
        {
            if (objDominio == null)
            {
                return;
            }

            if (this.trv.SelectedNode == null)
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

            ContainerDominioBase objPaiContainer = ((this.trv.SelectedNode as TreeNodeRpg).objDominio as ContainerDominioBase);

            if (!objPaiContainer.validarItem(objDominio))
            {
                return;
            }

            objPaiContainer.addFilho(objDominio);

            if (objDominio is ArquivoRefDominio)
            {
                objDominio = (objDominio as ArquivoRefDominio).objArquivo;
            }

            this.addTrn(new TreeNodeRpg(objDominio));
        }

        private void addItemCamada()
        {
            if (AppRpg.i.objJogo == null)
            {
                return;
            }

            if (this.trv.SelectedNode == null)
            {
                return;
            }

            this.addItem(CamadaDominio.criar(this.trv.SelectedNode.Nodes.Count));
        }

        private void addItemGrupo()
        {
            if (AppRpg.i.objJogo == null)
            {
                return;
            }

            if (this.trv.SelectedNode == null)
            {
                return;
            }

            this.addItem(GrupoDominio.criar(this.trv.SelectedNode.Nodes.Count));
        }

        private void addItemMapa()
        {
            if (AppRpg.i.objJogo == null)
            {
                return;
            }

            if (this.trv.SelectedNode == null)
            {
                return;
            }

            MapaDominio objMapa = MapaDominio.criar(this.trv.SelectedNode.Nodes.Count);

            ArquivoRefDominio objArqRef = new ArquivoRefDominio();

            objArqRef.objArquivo = objMapa;

            this.addItem(objArqRef);

            Directory.CreateDirectory(Path.GetDirectoryName(objArqRef.attDirArquivo.strValor));

            File.WriteAllText(objArqRef.attDirArquivo.strValor, JsonRpg.i.toJson(objMapa));
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

        private void carregarJogo(RpgDominioBase objPai, TreeNodeRpg trnPai)
        {
            if (objPai == null)
            {
                return;
            }

            if (objPai is ArquivoRefDominio)
            {
                objPai = (objPai as ArquivoRefDominio).objArquivo;
            }

            TreeNodeRpg trnFilho = new TreeNodeRpg(objPai);

            trnPai.Nodes.Add(trnFilho);

            if (!(typeof(ContainerDominioBase).IsAssignableFrom(objPai.GetType())))
            {
                return;
            }

            foreach (RpgDominioBase objFilho in (objPai as ContainerDominioBase).lstObjFilho)
            {
                if (objFilho == null)
                {
                    continue;
                }

                objFilho.objPai = objPai;

                this.carregarJogo(objFilho, trnFilho);
            }
        }

        private void processarNodeClick(TreeNodeRpg trn)
        {
            if (trn == null)
            {
                return;
            }

            AppRpg.i.frmPrincipal.objSelecionado = trn.objDominio;
        }

        private void processarNodeDoubleClick(TreeNodeRpg trn)
        {
            if (trn == null)
            {
                return;
            }

            if (trn.objDominio == null)
            {
                return;
            }

            if (trn.objDominio is MapaDominio)
            {
                this.abrirMapa(trn.objDominio as MapaDominio);
                return;
            }
        }

        #endregion Métodos

        #region Eventos

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
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

        private void trv_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                this.processarNodeClick((TreeNodeRpg)e.Node);
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex);
            }
        }

        private void trv_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                this.processarNodeDoubleClick((TreeNodeRpg)e.Node);
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex);
            }
        }

        private void tsmAddItemCAmada_Click(object sender, EventArgs e)
        {
            try
            {
                this.addItemCamada();
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

        private void tsmAddItemMapa_Click(object sender, EventArgs e)
        {
            try
            {
                this.addItemMapa();
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex);
            }
        }

        #endregion Eventos
    }
}