using System;
using System.IO;
using DigoFramework;
using Rpg.Controle.TabDock;

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

            Directory.CreateDirectory(Path.Combine(Path.GetFileName(dirJogo), TabDockArte.DIR_ARTE_ROOT));
            Directory.CreateDirectory(Path.Combine(Path.GetFileName(dirJogo), TabDockArte.DIR_ARTE_ROOT, TabDockArte.DIR_AUDIO));
            Directory.CreateDirectory(Path.Combine(Path.GetFileName(dirJogo), TabDockArte.DIR_ARTE_ROOT, TabDockArte.DIR_IMAGEM));

            return objJogoResultado;
        }

        internal void salvar()
        {
            if (string.IsNullOrEmpty(this.attDirCompleto.strValor))
            {
                return;
            }

            File.WriteAllText(this.attDirCompleto.strValor, JsonRpg.i.toJson(this));

            this.salvarJogoArqRef(this);
        }

        private void salvarJogoArqRef(RpgDominioBase objDominio)
        {
            if (objDominio == null)
            {
                return;
            }

            if ((objDominio is ArquivoRefDominio))
            {
                (objDominio as ArquivoRefDominio).salvarArqRef();
            }

            if ((objDominio is ContainerDominioBase))
            {
                foreach (RpgDominioBase objDominiofilho in (objDominio as ContainerDominioBase).lstObjFilho)
                {
                    this.salvarJogoArqRef(objDominiofilho);
                }
            }
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}