using System.Collections.Generic;
using System.Drawing;
using System.IO;
using DigoFramework;
using Rpg.Dominio;
using Rpg.Frm;

namespace Rpg
{
    public class AppRpg : AppBase
    {
        #region Constantes

        internal static string STR_EXTENSAO = ".rpgjson";

        #endregion Constantes

        #region Atributos

        private static AppRpg _i;

        private FrmPrincipal _frmPrincipal;
        private List<Bitmap> _lstBmpCache;
        private JogoDominio _objJogo;

        public new static AppRpg i
        {
            get
            {
                if (_i != null)
                {
                    return _i;
                }

                _i = new AppRpg();

                return _i;
            }
        }

        public new FrmPrincipal frmPrincipal
        {
            get
            {
                return _frmPrincipal;
            }

            set
            {
                if (_frmPrincipal == value)
                {
                    return;
                }

                _frmPrincipal = value;

                this.setFrmPrincipal(_frmPrincipal);
            }
        }

        public List<Bitmap> lstBmpCache
        {
            get
            {
                if (_lstBmpCache != null)
                {
                    return _lstBmpCache;
                }

                _lstBmpCache = new List<Bitmap>();

                return _lstBmpCache;
            }
        }

        public JogoDominio objJogo
        {
            get
            {
                return _objJogo;
            }

            private set
            {
                _objJogo = value;
            }
        }

        #endregion Atributos

        #region Construtores

        private AppRpg()
        {
        }

        #endregion Construtores

        #region Métodos

        public Bitmap getBmpCache(string dirImg)
        {
            if (string.IsNullOrEmpty(dirImg))
            {
                return null;
            }

            foreach (Bitmap bmp in this.lstBmpCache)
            {
                if (!dirImg.Equals(bmp.Tag))
                {
                    continue;
                }

                return bmp;
            }

            if (!File.Exists(dirImg))
            {
                return null;
            }

            Bitmap bmpNovo = new Bitmap(dirImg);

            bmpNovo.Tag = dirImg;

            this.lstBmpCache.Add(bmpNovo);

            return bmpNovo;
        }

        public void salvarJogo()
        {
            if (this.objJogo == null)
            {
                return;
            }

            this.objJogo.salvar();
        }

        internal void abrirJogo(string dirJogo)
        {
            if (string.IsNullOrEmpty(dirJogo))
            {
                return;
            }

            if (!File.Exists(dirJogo))
            {
                return;
            }

            this.objJogo = JsonRpg.i.fromJson<JogoDominio>(File.ReadAllText(dirJogo));

            if (objJogo == null)
            {
                return;
            }

            objJogo.iniciar(false);
        }

        internal void criarJogo(string dirJogo)
        {
            if (string.IsNullOrEmpty(dirJogo))
            {
                return;
            }

            this.objJogo = JogoDominio.criar(dirJogo);

            this.salvarJogo();
        }

        protected override string getStrAppNome()
        {
            return "RPG Maker (Tabletop)";
        }

        private void setFrmPrincipal(FrmPrincipal frmPrincipal)
        {
            base.frmPrincipal = frmPrincipal;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}