using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Rpg.Controle.TabDock
{
    public partial class TabDockArte : TabDockRpgBase
    {
        #region Constantes

        private const string DIR_ARTE_ROOT = "Arte";
        private const string DIR_AUDIO = "Audio";
        private const string DIR_IMAGEM = "Imagem";

        #endregion Constantes

        #region Atributos

        private string _dirArteRoot;

        private List<string> _lstStrExtensaoSuportada;

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

        private List<string> lstStrExtensaoSuportada
        {
            get
            {
                if (_lstStrExtensaoSuportada != null)
                {
                    return _lstStrExtensaoSuportada;
                }

                _lstStrExtensaoSuportada = new List<string>();

                return _lstStrExtensaoSuportada;
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

            TreeNode trn = this.trv.Nodes.Add(DIR_ARTE_ROOT);

            this.carregarArteDir(this.dirArteRoot, trn);
        }

        private void carregarArteArq(string dirArqItem, TreeNode trn)
        {
            string strExtencao = Path.GetExtension(dirArqItem);

            if (string.IsNullOrEmpty(strExtencao))
            {
                return;
            }

            strExtencao = strExtencao.ToLower();

            if (!this.lstStrExtensaoSuportada.Contains(strExtencao))
            {
                return;
            }

            trn.Nodes.Add(Path.GetFileName(dirArqItem));
        }

        private void carregarArteDir(string dir, TreeNode trn)
        {
            if (!Directory.Exists(dir))
            {
                return;
            }

            foreach (string dirItem in Directory.GetDirectories(dir))
            {
                TreeNode trnItem = trn.Nodes.Add(Path.GetFileName(dirItem));

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
            this.lstStrExtensaoSuportada.Add(".mp3");
            this.lstStrExtensaoSuportada.Add(".wav");
            this.lstStrExtensaoSuportada.Add(".wma");

            // Imagem:
            this.lstStrExtensaoSuportada.Add(".bmp");
            this.lstStrExtensaoSuportada.Add(".jpg");
            this.lstStrExtensaoSuportada.Add(".png");
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}