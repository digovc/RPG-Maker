using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using DigoFramework;
using Rpg.Dominio;

namespace Rpg.Controle.TabDock
{
    public partial class TabDockExplorer : TabDockRpgBase
    {
        #region Constantes

        private const string STR_MENU_CONTEXTO_NODE_ADD_MAPA = "Adicionar ao mapa";

        #endregion Constantes

        #region Atributos

        private List<string> _lstStrExtensaoSuportadaAudio;
        private List<string> _lstStrExtensaoSuportadaImagem;

        private List<string> lstStrExtensaoSuportadaAudio
        {
            get
            {
                if (_lstStrExtensaoSuportadaAudio != null)
                {
                    return _lstStrExtensaoSuportadaAudio;
                }

                _lstStrExtensaoSuportadaAudio = this.getLstStrExtensaoSuportadaAudio();

                return _lstStrExtensaoSuportadaAudio;
            }
        }

        private List<string> lstStrExtensaoSuportadaImagem
        {
            get
            {
                if (_lstStrExtensaoSuportadaImagem != null)
                {
                    return _lstStrExtensaoSuportadaImagem;
                }

                _lstStrExtensaoSuportadaImagem = this.getLstStrExtensaoSuportadaImagem();

                return _lstStrExtensaoSuportadaImagem;
            }
        }

        #endregion Atributos

        #region Construtores

        public TabDockExplorer()
        {
            this.InitializeComponent();
        }

        #endregion Construtores

        #region Métodos

        internal void abrirJogo()
        {
            if (AppRpg.i.objJogo == null)
            {
                return;
            }

            this.trv.Nodes.Clear();

            if (!File.Exists(AppRpg.i.objJogo.attDirCompleto.strValor))
            {
                return;
            }

            TreeNodeRpg trnJogo = new TreeNodeRpg(AppRpg.i.objJogo);

            this.trv.Nodes.Add(trnJogo);

            this.abrirJogo(trnJogo, Path.GetDirectoryName(AppRpg.i.objJogo.attDirCompleto.strValor));
        }

        internal ArquivoRefDominio getObjArquivoRef(string dirArquivo)
        {
            if (string.IsNullOrEmpty(dirArquivo))
            {
                return null;
            }

            foreach (TreeNode tnr in this.trv.Nodes)
            {
                ArquivoRefDominio objResultado = (tnr as TreeNodeRpg).getObjArquivoRef(dirArquivo);

                if (objResultado != null)
                {
                    return objResultado;
                }
            }

            return null;
        }

        private void abrirArquivoRef(TreeNodeRpg tnr, ArquivoRefDominio arqRef)
        {
            if (arqRef.objArquivo == null)
            {
                return;
            }

            if (arqRef.objArquivo is AudioDominio)
            {
                this.abrirAudio(arqRef.objArquivo as AudioDominio);
                return;
            }

            if (arqRef.objArquivo is ImagemDominio)
            {
                this.abrirImagem(arqRef.objArquivo as ImagemDominio);
                return;
            }

            if (arqRef.objArquivo is MapaDominio)
            {
                this.abrirMapa(tnr, arqRef.objArquivo as MapaDominio);
                return;
            }

            if (arqRef.objArquivo is PersonagemDominio)
            {
                this.abrirPersonagem(tnr, arqRef.objArquivo as PersonagemDominio);
                return;
            }
        }

        private void abrirAudio(AudioDominio objAudio)
        {
            AppRpg.i.frmPrincipal.tabDockMixer.abrirAudio(objAudio);
        }

        private void abrirImagem(ImagemDominio objImg)
        {
            AppRpg.i.frmPrincipal.abrirImagem(objImg);
        }

        private void abrirJogo(TreeNodeRpg trnPai, string dirPai)
        {
            trnPai.Nodes.Clear();

            if (!Directory.Exists(dirPai))
            {
                return;
            }

            foreach (string dirFilho in Directory.GetDirectories(dirPai))
            {
                PastaDominio objPasta = new PastaDominio();

                objPasta.attDirCompleto.strValor = dirFilho;
                objPasta.attStrNome.strValor = Path.GetFileName(dirFilho);

                objPasta.iniciar(true);

                TreeNodeRpg trnItem = new TreeNodeRpg(objPasta);

                trnPai.Nodes.Add(trnItem);

                this.abrirJogo(trnItem, dirFilho);
            }

            foreach (string dirArquivo in Directory.GetFiles(dirPai))
            {
                this.abrirJogoArquivo(trnPai, dirArquivo);
            }
        }

        private void abrirJogoArquivo(TreeNodeRpg trnPai, string dirArquivo)
        {
            string strExtencao = Path.GetExtension(dirArquivo);

            if (string.IsNullOrEmpty(strExtencao))
            {
                return;
            }

            strExtencao = strExtencao.ToLower();

            if (this.lstStrExtensaoSuportadaAudio.Contains(strExtencao))
            {
                this.abrirJogoArquivo(trnPai, dirArquivo, new AudioDominio());
                return;
            }

            if (this.lstStrExtensaoSuportadaImagem.Contains(strExtencao))
            {
                this.abrirJogoArquivo(trnPai, dirArquivo, new ImagemDominio());
                return;
            }

            if (AppRpg.STR_EXTENSAO_MAPA.Equals(strExtencao))
            {
                this.abrirJogoArquivo(trnPai, dirArquivo, typeof(MapaDominio));
            }

            if (AppRpg.STR_EXTENSAO_PERSONAGEM.Equals(strExtencao))
            {
                this.abrirJogoArquivo(trnPai, dirArquivo, typeof(PersonagemDominio));
            }
        }

        private void abrirJogoArquivo(TreeNodeRpg trnPai, string dirArquivo, ArquivoDominio objArquivo)
        {
            ArquivoRefDominio arqRef = new ArquivoRefDominio();

            arqRef.objArquivo = objArquivo;

            objArquivo.attDirCompleto.strValor = dirArquivo;
            objArquivo.attStrNome.strValor = Path.GetFileNameWithoutExtension(dirArquivo);

            trnPai.Nodes.Add(new TreeNodeRpg(arqRef));
        }

        private void abrirJogoArquivo(TreeNodeRpg trnPai, string dirArquivo, Type clsArquivo)
        {
            ArquivoRefDominio arqRef = new ArquivoRefDominio();

            arqRef.attDirArquivo.strValor = dirArquivo;

            arqRef.attStrNome.strValor = Path.GetFileNameWithoutExtension(dirArquivo);

            trnPai.Nodes.Add(new TreeNodeRpg(arqRef));
        }

        private void abrirMapa(TreeNodeRpg tnr, MapaDominio objMapa)
        {
            if (!AppRpg.i.frmPrincipal.abrirMapa(objMapa))
            {
                return;
            }

            foreach (CamadaDominio objCamada in objMapa.lstObjCamada)
            {
                this.abrirMapa(tnr, objMapa, objCamada);
            }
        }

        private void abrirMapa(TreeNodeRpg tnrMapa, MapaDominio objMapa, CamadaDominio objCamada)
        {
            if (objCamada == null)
            {
                return;
            }

            tnrMapa.Nodes.Add(new TreeNodeRpg(objCamada));
        }

        private void abrirMenuContexto(TreeNodeRpg tnr)
        {
            ContextMenuStrip cmsNode = new ContextMenuStrip();

            if (tnr.objDominio == null)
            {
                return;
            }

            if (tnr.objDominio is ArquivoRefDominio)
            {
                this.abrirMenuContexto(cmsNode, (tnr.objDominio as ArquivoRefDominio));
            }

            if (cmsNode.Items.Count < 1)
            {
                return;
            }

            cmsNode.Show(Cursor.Position.X, Cursor.Position.Y);
        }

        private void abrirMenuContexto(ContextMenuStrip cmsNode, ArquivoRefDominio objArqRef)
        {
            if (objArqRef.objArquivo == null)
            {
                return;
            }

            if (objArqRef.objArquivo is PersonagemDominio)
            {
                this.abrirMenuContexto(cmsNode, objArqRef.objArquivo as PersonagemDominio);
                return;
            }
        }

        private void abrirMenuContexto(ContextMenuStrip cmsNode, PersonagemDominio objPersonagem)
        {
            ToolStripItem tsmAddPersonagemMapa = cmsNode.Items.Add(STR_MENU_CONTEXTO_NODE_ADD_MAPA);

            tsmAddPersonagemMapa.Click += this.tsmAddPersonagemMapa_Click;
        }

        private void abrirPasta(PastaDominio objPasta)
        {
            if (!Directory.Exists(objPasta.attDirCompleto.strValor))
            {
                return;
            }

            Process.Start(objPasta.attDirCompleto.strValor);
        }

        private void abrirPersonagem(TreeNodeRpg tnr, PersonagemDominio objPersonagem)
        {
            AppRpg.i.frmPrincipal.abrirPersonagem(objPersonagem);
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

            this.addItemCamada(this.trv.SelectedNode as TreeNodeRpg);
        }

        private void addItemCamada(TreeNodeRpg tnr)
        {
            if (tnr.objDominio == null)
            {
                return;
            }

            if (!(tnr.objDominio is ArquivoRefDominio))
            {
                return;
            }

            if ((tnr.objDominio as ArquivoRefDominio).objArquivo == null)
            {
                return;
            }

            if (!((tnr.objDominio as ArquivoRefDominio).objArquivo is MapaDominio))
            {
                return;
            }

            this.addItemCamada(tnr, ((tnr.objDominio as ArquivoRefDominio).objArquivo as MapaDominio));
        }

        private void addItemCamada(TreeNodeRpg tnrPai, MapaDominio objMapa)
        {
            CamadaDominio objCamada = CamadaDominio.criar(tnrPai.Nodes.Count);

            objMapa.addCamada(objCamada);

            tnrPai.Nodes.Add(new TreeNodeRpg(objCamada));
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

            this.addItemMapa(this.trv.SelectedNode as TreeNodeRpg);
        }

        private void addItemMapa(TreeNodeRpg tnrPai)
        {
            if (tnrPai.objDominio == null)
            {
                return;
            }

            if (!(tnrPai.objDominio is PastaDominio))
            {
                return;
            }

            this.addItemMapa(tnrPai, (tnrPai.objDominio as PastaDominio));
        }

        private void addItemMapa(TreeNodeRpg tnrPai, PastaDominio objPasta)
        {
            MapaDominio objMapa = MapaDominio.criar(tnrPai.Nodes.Count);

            objMapa.attDirCompleto.strValor = Path.Combine(objPasta.attDirCompleto.strValor, (objMapa.attStrNome.strValor + AppRpg.STR_EXTENSAO_MAPA));
            objMapa.attStrNome.strValor = Path.GetFileNameWithoutExtension(objMapa.attDirCompleto.strValor);

            File.WriteAllText(objMapa.attDirCompleto.strValor, JsonRpg.i.toJson(objMapa));

            ArquivoRefDominio arqRef = new ArquivoRefDominio();

            arqRef.objArquivo = objMapa;

            tnrPai.Nodes.Add(new TreeNodeRpg(arqRef));
        }

        private void addItemPasta()
        {
            if (AppRpg.i.objJogo == null)
            {
                return;
            }

            if (this.trv.SelectedNode == null)
            {
                return;
            }

            this.addItemPasta(this.trv.SelectedNode as TreeNodeRpg);
        }

        private void addItemPasta(TreeNodeRpg tnrPai)
        {
            if (tnrPai.objDominio == null)
            {
                return;
            }

            if (!(tnrPai.objDominio is JogoDominio) && (tnrPai.objDominio is PastaDominio))
            {
                return;
            }

            string dirPai = Path.GetDirectoryName((tnrPai.objDominio as ArquivoDominio).attDirCompleto.strValor);

            PastaDominio objPasta = PastaDominio.criar(tnrPai.Nodes.Count);

            objPasta.attDirCompleto.strValor = Path.Combine(dirPai, objPasta.attStrNome.strValor);

            Directory.CreateDirectory(objPasta.attDirCompleto.strValor);

            tnrPai.Nodes.Add(new TreeNodeRpg(objPasta));
        }

        private void addItemPersonagem()
        {
            if (AppRpg.i.objJogo == null)
            {
                return;
            }

            if (this.trv.SelectedNode == null)
            {
                return;
            }

            this.addItemPersonagem(this.trv.SelectedNode as TreeNodeRpg);
        }

        private void addItemPersonagem(TreeNodeRpg tnrPai)
        {
            if (tnrPai.objDominio == null)
            {
                return;
            }

            if (!(tnrPai.objDominio is PastaDominio))
            {
                return;
            }

            this.addItemPersonagem(tnrPai, (tnrPai.objDominio as PastaDominio));
        }

        private void addItemPersonagem(TreeNodeRpg tnrPai, PastaDominio objPasta)
        {
            PersonagemDominio objPersonagem = PersonagemDominio.criar(tnrPai.Nodes.Count);

            objPersonagem.attDirCompleto.strValor = Path.Combine(objPasta.attDirCompleto.strValor, (objPersonagem.attStrNome.strValor + AppRpg.STR_EXTENSAO_PERSONAGEM));

            File.WriteAllText(objPersonagem.attDirCompleto.strValor, JsonRpg.i.toJson(objPersonagem));

            ArquivoRefDominio arqRef = new ArquivoRefDominio();

            arqRef.objArquivo = objPersonagem;

            tnrPai.Nodes.Add(new TreeNodeRpg(arqRef));
        }

        private void addPersonagemMapa()
        {
            if (AppRpg.i.frmPrincipal.tabDockMapaSelecionado == null)
            {
                return;
            }

            if (this.trv.SelectedNode == null)
            {
                return;
            }

            this.addPersonagemMapa(trv.SelectedNode as TreeNodeRpg);
        }

        private void addPersonagemMapa(TreeNodeRpg tnr)
        {
            if (tnr.objDominio == null)
            {
                return;
            }

            if (!(tnr.objDominio is ArquivoRefDominio))
            {
                return;
            }

            this.addPersonagemMapa(tnr.objDominio as ArquivoRefDominio);
        }

        private void addPersonagemMapa(ArquivoRefDominio objArqRef)
        {
            if (objArqRef.objArquivo == null)
            {
                return;
            }

            if (!(objArqRef.objArquivo is PersonagemDominio))
            {
                return;
            }

            this.addPersonagemMapa(objArqRef.objArquivo as PersonagemDominio);
        }

        private void addPersonagemMapa(PersonagemDominio objPersonagem)
        {
            if (objPersonagem == null)
            {
                return;
            }

            AppRpg.i.frmPrincipal.tabDockMapaSelecionado.addPersonagem(objPersonagem);
        }

        private List<string> getLstStrExtensaoSuportadaAudio()
        {
            List<string> lstStrResultado = new List<string>();

            lstStrResultado.Add(".mp3");
            lstStrResultado.Add(".wav");
            lstStrResultado.Add(".wma");

            return lstStrResultado;
        }

        private List<string> getLstStrExtensaoSuportadaImagem()
        {
            List<string> lstStrResultado = new List<string>();

            lstStrResultado.Add(".bmp");
            lstStrResultado.Add(".jpg");
            lstStrResultado.Add(".png");

            return lstStrResultado;
        }

        private void processarNodeClick(TreeNodeMouseClickEventArgs arg)
        {
            this.selecionarItem(arg.Node as TreeNodeRpg);

            if (MouseButtons.Right.Equals(arg.Button))
            {
                this.abrirMenuContexto(arg.Node as TreeNodeRpg);
            }
        }

        private void processarNodeDoubleClick(TreeNodeRpg tnr)
        {
            if (tnr == null)
            {
                return;
            }

            if (tnr.objDominio == null)
            {
                return;
            }

            if (tnr.objDominio is PastaDominio)
            {
                //this.abrirPasta(tnr.objDominio as PastaDominio);
                return;
            }

            if (tnr.objDominio is ArquivoRefDominio)
            {
                this.abrirArquivoRef(tnr, (tnr.objDominio as ArquivoRefDominio));
                return;
            }
        }

        private void selecionarItem(TreeNodeRpg tnr)
        {
            if (tnr == null)
            {
                return;
            }

            AppRpg.i.frmPrincipal.objSelecionado = tnr.objDominio;
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

        private void trv_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs arg)
        {
            try
            {
                this.processarNodeClick(arg);
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

        private void tsmAddItemCamada_Click(object sender, EventArgs e)
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

        private void tsmAddItemPasta_Click(object sender, EventArgs e)
        {
            try
            {
                this.addItemPasta();
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex);
            }
        }

        private void tsmAddItemPersonagem_Click(object sender, EventArgs e)
        {
            try
            {
                this.addItemPersonagem();
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex);
            }
        }

        private void tsmAddPersonagemMapa_Click(object sender, EventArgs e)
        {
            try
            {
                this.addPersonagemMapa();
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex);
            }
        }

        #endregion Eventos
    }
}