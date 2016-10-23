using System;
using System.IO;
using DigoFramework;
using Newtonsoft.Json;

namespace Rpg.Dominio
{
    public class ArquivoDominio : RpgDominioBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private Atributo _attDirCompleto;

        private ArquivoRefDominio _objArqRef;

        [JsonIgnore]
        public Atributo attDirCompleto
        {
            get
            {
                if (_attDirCompleto != null)
                {
                    return _attDirCompleto;
                }

                _attDirCompleto = this.getAtt("Diretório");

                return _attDirCompleto;
            }
        }

        public ArquivoRefDominio objArqRef
        {
            get
            {
                return _objArqRef;
            }

            set
            {
                if (_objArqRef == value)
                {
                    return;
                }

                _objArqRef = value;

                this.setObjArqRef(_objArqRef);
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        public void salvar()
        {
            if (string.IsNullOrEmpty(this.attDirCompleto.strValor))
            {
                return;
            }

            File.WriteAllText(this.attDirCompleto.strValor, JsonRpg.i.toJson(this));
        }

        protected virtual void atualizarNome()
        {
            if (!File.Exists(this.attDirCompleto.strValor))
            {
                return;
            }

            if (string.IsNullOrEmpty(this.attStrNome.strValor))
            {
                return;
            }

            string dirNovo = Path.Combine(Path.GetDirectoryName(this.attDirCompleto.strValor), (this.attStrNome.strValor + Path.GetExtension(this.attDirCompleto.strValor)));

            if (dirNovo.Equals(this.attDirCompleto.strValor))
            {
                return;
            }

            File.Move(this.attDirCompleto.strValor, dirNovo);

            this.attDirCompleto.strValor = dirNovo;
        }

        protected override void inicializar(bool booCriacao)
        {
            base.inicializar(booCriacao);

            this.attDirCompleto.booSomenteLeitura = true;
        }

        protected override void setEventos()
        {
            base.setEventos();

            this.attStrNome.onStrValorAlterado += this.attStrNome_onStrValorAlterado;
        }

        private void setObjArqRef(ArquivoRefDominio objArqRef)
        {
            if (objArqRef == null)
            {
                return;
            }

            objArqRef.objArquivo = this;

            objArqRef.attDirArquivo.onStrValorAlterado += this.objArqRef_attDirArquivo_onStrValorAlterado;

            if (string.IsNullOrEmpty(objArqRef.attStrNome.strValor))
            {
                return;
            }

            this.attDirCompleto.strValor = objArqRef.attDirArquivo.strValor;
            this.attStrNome.strValor = objArqRef.attStrNome.strValor;
        }

        #endregion Métodos

        #region Eventos

        private void attStrNome_onStrValorAlterado(object sender, EventArgs e)
        {
            try
            {
                this.atualizarNome();
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex);
            }
        }

        private void objArqRef_attDirArquivo_onStrValorAlterado(object sender, EventArgs e)
        {
            try
            {
                this.attDirCompleto.strValor = this.objArqRef.attDirArquivo.strValor;
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex);
            }
        }

        #endregion Eventos
    }
}