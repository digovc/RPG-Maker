using Newtonsoft.Json;

namespace Rpg.Dominio
{
    public class RelMapaPersonagemDominio : RpgDominioBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private Atributo _attDirPersonagem;

        private PersonagemDominio _objPersonagem;

        [JsonIgnore]
        public Atributo attDirPersonagem
        {
            get
            {
                if (_attDirPersonagem != null)
                {
                    return _attDirPersonagem;
                }

                _attDirPersonagem = this.getAtt("Diretório do personagem");

                return _attDirPersonagem;
            }
        }

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