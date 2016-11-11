using Newtonsoft.Json;

namespace Rpg.Dominio
{
    public class PersonagemTileDominio : TileDominio
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private PersonagemDominio _objPersonagem;

        [JsonIgnore]
        public PersonagemDominio objPersonagem
        {
            get
            {
                return _objPersonagem;
            }

            set
            {
                _objPersonagem = value;
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}