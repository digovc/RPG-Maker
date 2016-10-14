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

        private Atributo _attNome;
        private List<Atributo> _lstAtt;
        private RpgDominioBase _objDominioPai;

        [JsonIgnore]
        public Atributo attNome
        {
            get
            {
                if (_attNome != null)
                {
                    return _attNome;
                }

                _attNome = this.getAtt("Nome", null);

                return _attNome;
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
        public RpgDominioBase objDominioPai
        {
            get
            {
                return _objDominioPai;
            }

            set
            {
                _objDominioPai = value;
            }
        }

        #endregion Atributos

        #region Construtores

        public RpgDominioBase()
        {
        }

        #endregion Construtores

        #region Métodos

        public void iniciar()
        {
            this.inicializar();
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

        public Atributo getAtt(string strAttNome, decimal decValor)
        {
            return this.getAtt(strAttNome, decValor.ToString());
        }

        protected Atributo getAtt(string strAttNome, string strValor = null)
        {
            if (string.IsNullOrEmpty(strAttNome))
            {
                return null;
            }

            foreach (Atributo att in this.lstAtt)
            {
                if (att == null)
                {
                    continue;
                }

                if (!strAttNome.Equals(att.strNome))
                {
                    continue;
                }

                return att;
            }

            return new Atributo(this, strAttNome, strValor);
        }

        protected virtual void inicializar()
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