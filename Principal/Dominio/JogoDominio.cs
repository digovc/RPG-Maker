using System;
using Newtonsoft.Json;

namespace Rpg.Dominio
{
    public class JogoDominio : ContainerDominioBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private Atributo _attDirCompleto;

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

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override string getStrNomeDefault()
        {
            return "RPG desconhecido";
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}