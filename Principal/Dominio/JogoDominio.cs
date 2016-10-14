using System.IO;
using DigoFramework.Json;

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

        internal void salvar()
        {
            if (string.IsNullOrEmpty(this.attDirCompleto.strValor))
            {
                return;
            }

            File.WriteAllText(this.attDirCompleto.strValor, JsonRpg.i.toJson(this));

            this.salvarJogoArqRef(this);
        }

        protected override string getStrNomeDefault()
        {
            return "RPG desconhecido";
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