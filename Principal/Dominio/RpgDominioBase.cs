using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Rpg.Dominio
{
    public abstract class RpgDominioBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private Atributo _attStrNome;
        private List<Atributo> _lstAtt;
        private List<string> _lstStrGrupo;
        private RpgDominioBase _objPai;

        [JsonIgnore]
        public Atributo attStrNome
        {
            get
            {
                if (_attStrNome != null)
                {
                    return _attStrNome;
                }

                _attStrNome = this.getAtt("Nome", null);

                return _attStrNome;
            }
        }

        public List<Atributo> lstAtt
        {
            get
            {
                if (_lstAtt != null)
                {
                    return _lstAtt;
                }

                _lstAtt = new List<Atributo>();

                return _lstAtt;
            }
        }

        public List<string> lstStrGrupo
        {
            get
            {
                return _lstStrGrupo;
            }

            set
            {
                _lstStrGrupo = value;
            }
        }

        [JsonIgnore]
        public RpgDominioBase objPai
        {
            get
            {
                return _objPai;
            }

            set
            {
                _objPai = value;
            }
        }

        #endregion Atributos

        #region Construtores

        public RpgDominioBase()
        {
        }

        #endregion Construtores

        #region Métodos

        public Atributo getAtt(string strattStrNome, decimal decValor)
        {
            return this.getAtt(strattStrNome, decValor.ToString());
        }

        public Atributo getAtt(string strattStrNome, bool booValor)
        {
            return this.getAtt(strattStrNome, booValor.ToString());
        }

        public void iniciar(bool booCriacao)
        {
            this.inicializar(booCriacao);
            this.setEventos();
        }

        internal void addAtt(Atributo att)
        {
            if (att == null)
            {
                return;
            }

            if (this.lstAtt.Contains(att))
            {
                return;
            }

            if (this.lstAtt.Where((a) => (a.strNome == att.strNome)).Count() > 0)
            {
                return;
            }

            this.lstAtt.Add(att);

            this.addStrGrupo(att.strGrupo);
        }

        protected Atributo getAtt(string strAttStrNome, string strValor = null)
        {
            if (string.IsNullOrEmpty(strAttStrNome))
            {
                return null;
            }

            foreach (Atributo att in this.lstAtt)
            {
                if (att == null)
                {
                    continue;
                }

                if (!strAttStrNome.Equals(att.strNome))
                {
                    continue;
                }

                return att;
            }

            return new Atributo(this, strAttStrNome, strValor);
        }

        protected virtual void inicializar(bool booCriacao)
        {
            this.attStrNome.booFixo = true;

            foreach (Atributo att in this.lstAtt)
            {
                this.inicializar(att);
            }
        }

        protected virtual void setEventos()
        {
        }

        private void addStrGrupo(string strGrupo)
        {
            if (string.IsNullOrEmpty(strGrupo))
            {
                return;
            }

            if (this.lstStrGrupo == null)
            {
                this.lstStrGrupo = new List<string>();
            }

            if (this.lstStrGrupo.Contains(strGrupo))
            {
                return;
            }

            this.lstStrGrupo.Add(strGrupo);
        }

        private void inicializar(Atributo att)
        {
            att.objDominio = this;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}