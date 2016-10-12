using System;
using Newtonsoft.Json;

namespace Rpg.Dominio
{
    public class Atributo
    {
        #region Constantes

        public enum EnmTipo
        {
            ALCANCE,
            BOOLEAN,
            NUMERICO,
            TEXTO,
        }

        #endregion Constantes

        #region Atributos

        private EnmTipo _enmTipo = EnmTipo.TEXTO;
        private RpgDominioBase _objDominio;
        private string _strDescricao;
        private string _strGrupo;
        private string _strNome;
        private string _strValor;

        public EnmTipo enmTipo
        {
            get
            {
                return _enmTipo;
            }

            set
            {
                _enmTipo = value;
            }
        }

        public string strDescricao
        {
            get
            {
                return _strDescricao;
            }

            set
            {
                _strDescricao = value;
            }
        }

        public string strGrupo
        {
            get
            {
                return _strGrupo;
            }

            set
            {
                _strGrupo = value;
            }
        }

        public string strNome
        {
            get
            {
                return _strNome;
            }

            set
            {
                _strNome = value;
            }
        }

        public string strValor
        {
            get
            {
                return _strValor;
            }

            set
            {
                if (_strValor == value)
                {
                    return;
                }

                _strValor = value;

                this.setStrValor(_strValor);
            }
        }

        [JsonIgnore]
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

        public Atributo(RpgDominioBase objDominio, string strNome, string strValor = null)
        {
            this.strNome = strNome;
            this.strValor = strValor;

            this.objDominio = objDominio;
        }

        #endregion Construtores

        #region Métodos

        private void setObjDominio(RpgDominioBase objDominio)
        {
            if (objDominio == null)
            {
                return;
            }

            objDominio.addAtt(this);
        }

        private void setStrValor(string strValor)
        {
            this.onStrValorAlterado?.Invoke(this, EventArgs.Empty);
        }

        #endregion Métodos

        #region Eventos

        public event EventHandler onStrValorAlterado;

        #endregion Eventos
    }
}