using Rpg.Controle.EditAtributo;
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

            this.objDominio = AppRpg.i.frmPrincipal.objDominioSelecionado;
        }

        private EditAtributoBase getEdtAtt(Atributo.EnmTipo enmTipo)
        {
            switch (enmTipo)
            {
                case Atributo.EnmTipo.ALCANCE:
                    return new EditAtributoAlcance();

                case Atributo.EnmTipo.BOOLEAN:
                    return new EditAtributoBoolen();

                case Atributo.EnmTipo.NUMERICO:
                    return new EditAtributoTexto();

                default:
                    return new EditAtributoTexto();
            }
        }

        private void setObjDominio(RpgDominioBase objDominio)
        {
            if (objDominio == null)
            {
                return;
            }

            this.pnlConteudo.Controls.Clear();

            if (objDominio is ArquivoRefDominio)
            {
                this.setObjDominioArqRef((ArquivoRefDominio)objDominio);
                return;
            }

            if (objDominio.lstAtt == null)
            {
                return;
            }

            foreach (Atributo att in objDominio.lstAtt)
            {
                this.setObjDominio(att);
            }

            Atributo attTest = new Atributo(null, "Alcance", "5;10");

            attTest.enmTipo = Atributo.EnmTipo.ALCANCE;

            this.setObjDominio(attTest);
        }

        private void setObjDominio(Atributo att)
        {
            if (att == null)
            {
                return;
            }

            EditAtributoBase edtAtt = this.getEdtAtt(att.enmTipo);

            edtAtt.att = att;

            this.pnlConteudo.Controls.Add(edtAtt);
        }

        private void setObjDominioArqRef(ArquivoRefDominio objArqRef)
        {
            if (objArqRef == null)
            {
                return;
            }

            if (objArqRef.objArquivo == null)
            {
                return;
            }

            this.objDominio = objArqRef.objArquivo;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}