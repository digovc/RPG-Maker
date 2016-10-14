using System.IO;
using DigoFramework;
using Rpg.Dominio;
using Rpg.Frm;

namespace Rpg
{
    public class AppRpg : AppBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private static AppRpg _i;
        private FrmPrincipal _frmPrincipal;
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
        }

        internal void criarJogo(string digJogo)
        {
            if (string.IsNullOrEmpty(digJogo))
            {
                return;
            }

            this.objJogo = new JogoDominio();

            this.objJogo.attDirCompleto.strValor = digJogo;

            this.salvarJogo();
        }

        protected override string getStrAppNome()
        {
            return "RPG Maker";
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