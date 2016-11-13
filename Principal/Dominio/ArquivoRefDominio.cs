using System;
using System.IO;
using DigoFramework;

namespace Rpg.Dominio
{
    public class ArquivoRefDominio : RpgDominioBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private Atributo _attDirArquivo;
        private ArquivoDominio _objArquivo;

        public Atributo attDirArquivo
        {
            get
            {
                if (_attDirArquivo != null)
                {
                    return _attDirArquivo;
                }

                _attDirArquivo = this.getAtt("Diretório");

                return _attDirArquivo;
            }
        }

        public ArquivoDominio objArquivo
        {
            get
            {
                if (_objArquivo != null)
                {
                    return _objArquivo;
                }

                _objArquivo = this.getObjArquivo();

                return _objArquivo;
            }

            set
            {
                if (_objArquivo == value)
                {
                    return;
                }

                _objArquivo = value;

                this.setObjArquivo(_objArquivo);
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        internal void salvarArqRef()
        {
            if (this.objArquivo == null)
            {
                return;
            }

            if (string.IsNullOrEmpty(this.attDirArquivo.strValor))
            {
                return;
            }

            File.WriteAllText(this.attDirArquivo.strValor, JsonRpg.i.toJson(this.objArquivo));
        }

        private ArquivoDominio getObjArquivo()
        {
            ArquivoDominio objResultado = AppRpg.i.getArquivoCache(this.attDirArquivo.strValor);

            objResultado.objArqRef = this;

            return objResultado;
        }

        private void setObjArquivo(ArquivoDominio objArquivo)
        {
            if (objArquivo == null)
            {
                return;
            }

            objArquivo.objArqRef = this;

            objArquivo.attDirCompleto.onStrValorAlterado += this.objArquivo_attDirCompleto_onStrValorAlterado;
            objArquivo.attStrNome.onStrValorAlterado += this.objArquivo_attStrNome_onStrValorAlterado;
        }

        #endregion Métodos

        #region Eventos

        private void objArquivo_attDirCompleto_onStrValorAlterado(object sender, string strValor)
        {
            try
            {
                this.attDirArquivo.strValor = strValor;
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex);
            }
        }

        private void objArquivo_attStrNome_onStrValorAlterado(object sender, string strValor)
        {
            try
            {
                this.attStrNome.strValor = strValor;
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex);
            }
        }

        #endregion Eventos
    }
}