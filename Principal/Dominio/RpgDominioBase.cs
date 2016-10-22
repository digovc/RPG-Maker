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
        }

        protected Atributo getAtt(string strattStrNome, string strValor = null)
        {
            if (string.IsNullOrEmpty(strattStrNome))
            {
                return null;
            }

            foreach (Atributo att in this.lstAtt)
            {
                if (att == null)
                {
                    continue;
                }

                if (!strattStrNome.Equals(att.strNome))
                {
                    continue;
                }

                return att;
            }

            return new Atributo(this, strattStrNome, strValor);
        }

        protected virtual void inicializar(bool booCriacao)
        {
        }

        protected virtual void setEventos()
        {
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}