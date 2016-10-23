using System.IO;

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

        protected override void atualizarNome()
        {
            //base.atualizarNome();

            if (!Directory.Exists(this.attDirCompleto.strValor))
            {
                return;
            }

            if (string.IsNullOrEmpty(this.attStrNome.strValor))
            {
                return;
            }

            string dirNovo = Path.Combine(Path.GetDirectoryName(this.attDirCompleto.strValor), (this.attStrNome.strValor + Path.GetExtension(this.attDirCompleto.strValor)));

            if (dirNovo.Equals(this.attDirCompleto.strValor))
            {
                return;
            }

            Directory.Move(this.attDirCompleto.strValor, dirNovo);

            this.attDirCompleto.strValor = dirNovo;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}