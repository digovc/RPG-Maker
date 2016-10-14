namespace Rpg.Dominio
{
    public class GrupoDominio : ContainerDominioBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        internal static GrupoDominio criar(int intIndex)
        {
            GrupoDominio objGrupoResultado = new GrupoDominio();

            objGrupoResultado.attNome.strValor = string.Format("Grupo {0}", intIndex);

            return objGrupoResultado;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}