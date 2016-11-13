using Newtonsoft.Json;

namespace Rpg.Dominio
{
    public class PersonagemTileDominio : TileDominio
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private string _dirPersonagem;
        private PersonagemDominio _objPersonagem;

        public string dirPersonagem
        {
            get
            {
                return _dirPersonagem;
            }

            set
            {
                _dirPersonagem = value;
            }
        }

        [JsonIgnore]
        public PersonagemDominio objPersonagem
        {
            get
            {
                if (_objPersonagem != null)
                {
                    return _objPersonagem;
                }

                _objPersonagem = this.getObjPersonagem();

                return _objPersonagem;
            }

            set
            {
                if (_objPersonagem == value)
                {
                    return;
                }

                _objPersonagem = value;

                this.setObjPersonagem(_objPersonagem);
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override void inicializar(bool booCriacao)
        {
            base.inicializar(booCriacao);

            this.inicializarObjPersonagem(booCriacao);
        }

        private PersonagemDominio getObjPersonagem()
        {
            if (string.IsNullOrEmpty(this.dirPersonagem))
            {
                return null;
            }

            ArquivoDominio objResultado = AppRpg.i.getArquivoCache(this.dirPersonagem);

            if (objResultado == null)
            {
                return null;
            }

            objResultado.objArqRef = AppRpg.i.frmPrincipal.tabDockExplorer.getObjArquivoRef(dirPersonagem);

            return (objResultado as PersonagemDominio);
        }

        private void inicializarObjPersonagem(bool booCriacao)
        {
            if (booCriacao)
            {
                return;
            }

            if (this.objPersonagem == null)
            {
                return;
            }

            this.dirImagem = this.objPersonagem.objTile.dirImagem;
            this.rtgImg = this.objPersonagem.objTile.rtgImg;
        }

        private void setObjPersonagem(PersonagemDominio objPersonagem)
        {
            if (objPersonagem == null)
            {
                return;
            }

            this.dirPersonagem = objPersonagem.attDirCompleto.strValor;

            objPersonagem.attDirCompleto.onStrValorAlterado += this.objPersonagem_attDirCompleto_onStrValorAlterado;
        }

        #endregion Métodos

        #region Eventos

        private void objPersonagem_attDirCompleto_onStrValorAlterado(object sender, string strValor)
        {
            this.dirPersonagem = strValor;
        }

        #endregion Eventos
    }
}