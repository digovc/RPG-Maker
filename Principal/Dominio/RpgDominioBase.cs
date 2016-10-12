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

        [JsonIgnore]
        public Atributo attNome
        {
            get
            {
                if (_attNome != null)
                {
                    return _attNome;
                }

                _attNome = this.getAtt("Nome", this.getStrNomeDefault());

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

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

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

        protected virtual string getStrNomeDefault()
        {
            return "Domínio desconhecido";
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}