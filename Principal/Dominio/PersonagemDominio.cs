namespace Rpg.Dominio
{
    public class PersonagemDominio : ArquivoDominio
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        internal static PersonagemDominio criar(int intIndex)
        {
            PersonagemDominio objPersonagemResultado = new PersonagemDominio();

            objPersonagemResultado.attStrNome.strValor = string.Format("Personagem {0}", intIndex);

            objPersonagemResultado.iniciar(true);

            return objPersonagemResultado;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}