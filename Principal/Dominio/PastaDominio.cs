namespace Rpg.Dominio
{
    public class PastaDominio : ArquivoDominio
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        internal static PastaDominio criar(int intIndex)
        {
            PastaDominio objPastaResultado = new PastaDominio();

            objPastaResultado.attStrNome.strValor = string.Format("Pasta {0}", intIndex);

            objPastaResultado.iniciar(true);

            return objPastaResultado;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}