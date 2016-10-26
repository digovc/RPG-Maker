using System;
using DigoFramework;
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

        private bool _booBloqueado;
        private bool _booJogadorBloqueado = true;
        private bool _booJogadorVisivel = true;
        private bool _booSomenteLeitura;
        private bool _booValor;
        private decimal _decValor;
        private EnmTipo _enmTipo = EnmTipo.TEXTO;
        private int _intValor;
        private int _intValorMaximo;
        private RpgDominioBase _objDominio;
        private string _strDescricao;
        private string _strGrupo;
        private string _strNome;
        private string _strValor;

        public bool booBloqueado
        {
            get
            {
                return _booBloqueado;
            }

            set
            {
                _booBloqueado = value;
            }
        }

        public bool booJogadorBloqueado
        {
            get
            {
                return _booJogadorBloqueado;
            }

            set
            {
                _booJogadorBloqueado = value;
            }
        }

        public bool booJogadorVisivel
        {
            get
            {
                return _booJogadorVisivel;
            }

            set
            {
                _booJogadorVisivel = value;
            }
        }

        [JsonIgnore]
        public bool booSomenteLeitura
        {
            get
            {
                return _booSomenteLeitura;
            }

            set
            {
                _booSomenteLeitura = value;
            }
        }

        [JsonIgnore]
        public bool booValor
        {
            get
            {
                return _booValor = Utils.getBoo(this.strValor);
            }

            set
            {
                _booValor = value;

                this.strValor = _booValor.ToString();
            }
        }

        [JsonIgnore]
        public decimal decValor
        {
            get
            {
                return _decValor = (Convert.ToDecimal(this.strValor));
            }

            set
            {
                _decValor = value;

                this.strValor = _decValor.ToString();
            }
        }

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

        [JsonIgnore]
        public int intValor
        {
            get
            {
                return _intValor = (int)this.decValor;
            }

            set
            {
                _intValor = value;

                this.decValor = _intValor;
            }
        }

        public int intValorMaximo
        {
            get
            {
                return _intValorMaximo;
            }

            set
            {
                _intValorMaximo = value;
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