using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using DigoFramework;
using Rpg.Dominio;

namespace Rpg.Controle.TabDock
{
    public partial class TabDockArte : TabDockRpgBase
    {
        #region Constantes

        public const string DIR_ARTE_ROOT = "Arte";
        public const string DIR_AUDIO = "Audio";
        public const string DIR_IMAGEM = "Imagem";

        #endregion Constantes

        #region Atributos

        private string _dirArteRoot;

        private List<string> _lstStrExtensaoSuportadaAudio;
        private List<string> _lstStrExtensaoSuportadaImagem;

        private string dirArteRoot
        {
            get
            {
                if (_dirArteRoot != null)
                {
                    return _dirArteRoot;
                }

                _dirArteRoot = this.getDirArteRoot();

                return _dirArteRoot;
            }
        }

        private List<string> lstStrExtensaoSuportadaAudio
        {
            get
            {
                if (_lstStrExtensaoSuportadaAudio != null)
                {
                    return _lstStrExtensaoSuportadaAudio;
                }

                _lstStrExtensaoSuportadaAudio = new List<string>();

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

                _lstStrExtensaoSuportadaImagem = new List<string>();

                return _lstStrExtensaoSuportadaImagem;
            }
        }

        #endregion Atributos

        #region Construtores

        public TabDockArte()
        {
            this.InitializeComponent();
        }

        #endregion Construtores

        #region Métodos

        protected override void inicializar()
        {
            base.inicializar();

            this.inicializarLstExtensaoSuportada();

            this.carregarArte();
        }

        private void abrirImagem(ImagemDominio objImg)
        {
            if (objImg == null)
            {
                return;
            }

            if (string.IsNullOrEmpty(objImg.attDirCompleto.strValor))
            {
                return;
            }

            if (!File.Exists(objImg.attDirCompleto.strValor))
            {
                return;
            }

            AppRpg.i.frmPrincipal.abrirImagem(objImg);
        }

        private void carregarArte()
        {
            this.trv.Nodes.Clear();

            if (AppRpg.i.objJogo == null)
            {
                return;
            }

            if (string.IsNullOrEmpty(this.dirArteRoot))
            {
                return;
            }

            ArquivoDominio arqDirRoot = new ArquivoDominio();

            arqDirRoot.attDirCompleto.strValor = this.dirArteRoot;
            arqDirRoot.attStrNome.strValor = Path.GetFileName(this.dirArteRoot);

            TreeNodeRpg trnDirRoot = new TreeNodeRpg(arqDirRoot);

            this.trv.Nodes.Add(trnDirRoot);

            this.carregarArteDir(this.dirArteRoot, trnDirRoot);
        }

        private void carregarArteArq(string dirArqItem, TreeNodeRpg trn)
        {
            string strExtencao = Path.GetExtension(dirArqItem);

            if (string.IsNullOrEmpty(strExtencao))
            {
                return;
            }

            strExtencao = strExtencao.ToLower();

            if (this.lstStrExtensaoSuportadaAudio.Contains(strExtencao))
            {
                this.carregarArteArq(dirArqItem, trn, typeof(AudioDominio));
                return;
            }

            if (this.lstStrExtensaoSuportadaImagem.Contains(strExtencao))
            {
                this.carregarArteArq(dirArqItem, trn, typeof(ImagemDominio));
                return;
            }
        }

        private void carregarArteArq(string dirArqItem, TreeNodeRpg trn, Type clsArq)
        {
            ArquivoDominio arq = (ArquivoDominio)Activator.CreateInstance(clsArq);

            arq.attDirCompleto.strValor = dirArqItem;
            arq.attStrNome.strValor = Path.GetFileName(dirArqItem);

            TreeNodeRpg trnAudio = new TreeNodeRpg(arq);

            trn.Nodes.Add(trnAudio);
        }

        private void carregarArteArqImagem(string dirArqItem, TreeNodeRpg trn)
        {
            ImagemDominio arqImagem = new ImagemDominio();

            arqImagem.attDirCompleto.strValor = dirArqItem;
            arqImagem.attStrNome.strValor = Path.GetFileName(dirArqItem);

            TreeNodeRpg trnAudio = new TreeNodeRpg(arqImagem);

            trn.Nodes.Add(trnAudio);
        }

        private void carregarArteDir(string dir, TreeNodeRpg trn)
        {
            if (!Directory.Exists(dir))
            {
                return;
            }

            foreach (string dirItem in Directory.GetDirectories(dir))
            {
                ArquivoDominio arqDirItem = new ArquivoDominio();

                arqDirItem.attDirCompleto.strValor = dirItem;
                arqDirItem.attStrNome.strValor = Path.GetFileName(dirItem);

                TreeNodeRpg trnItem = new TreeNodeRpg(arqDirItem);

                trn.Nodes.Add(trnItem);

                this.carregarArteDir(dirItem, trnItem);
            }

            foreach (string dirArqItem in Directory.GetFiles(dir))
            {
                this.carregarArteArq(dirArqItem, trn);
            }
        }

        private string getDirArteRoot()
        {
            if (AppRpg.i.objJogo == null)
            {
                return null;
            }

            if (string.IsNullOrEmpty(AppRpg.i.objJogo.attDirCompleto.strValor))
            {
                return null;
            }

            string dirResultado = Path.Combine(Path.GetDirectoryName(AppRpg.i.objJogo.attDirCompleto.strValor), DIR_ARTE_ROOT);

            if (Directory.Exists(dirResultado))
            {
                return dirResultado;
            }

            Directory.CreateDirectory(dirResultado);
            Directory.CreateDirectory(Path.Combine(dirResultado, DIR_AUDIO));
            Directory.CreateDirectory(Path.Combine(dirResultado, DIR_IMAGEM));

            return dirResultado;
        }

        private void inicializarLstExtensaoSuportada()
        {
            // Áudio:
            this.lstStrExtensaoSuportadaAudio.Add(".mp3");
            this.lstStrExtensaoSuportadaAudio.Add(".wav");
            this.lstStrExtensaoSuportadaAudio.Add(".wma");

            // Imagem:
            this.lstStrExtensaoSuportadaImagem.Add(".bmp");
            this.lstStrExtensaoSuportadaImagem.Add(".jpg");
            this.lstStrExtensaoSuportadaImagem.Add(".png");
        }

        private void processarNodeDoubleClick(TreeNodeRpg trnArq)
        {
            if (trnArq == null)
            {
                return;
            }

            if (trnArq.objDominio == null)
            {
                return;
            }

            if (trnArq.objDominio is ImagemDominio)
            {
                this.abrirImagem((ImagemDominio)trnArq.objDominio);
                return;
            }
        }

        #endregion Métodos

        #region Eventos

        private void trv_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs arg)
        {
            try
            {
                this.processarNodeDoubleClick((TreeNodeRpg)arg.Node);
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex);
            }
        }

        #endregion Eventos
    }
}