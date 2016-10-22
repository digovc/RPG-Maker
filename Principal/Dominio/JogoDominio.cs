using System.IO;

namespace Rpg.Dominio
{
    public class JogoDominio : ArquivoDominio
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        internal static JogoDominio criar(string dirJogo)
        {
            if (string.IsNullOrEmpty(dirJogo))
            {
                return null;
            }

            JogoDominio objJogoResultado = new JogoDominio();

            objJogoResultado.attDirCompleto.strValor = dirJogo;
            objJogoResultado.attStrNome.strValor = Path.GetFileNameWithoutExtension(dirJogo);

            return objJogoResultado;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}