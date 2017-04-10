using NetZ.Web.Server;
using Rpg.Web.Html.Pagina;

namespace Rpg.Web.Server
{
    public class ServerHttpRpg : ServerHttpBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        #endregion Atributos

        #region Construtores

        public ServerHttpRpg() : base("Server HTTP RPG")
        {
        }

        #endregion Construtores

        #region Métodos

        public override Resposta responder(Solicitacao objSolicitacao)
        {
            return base.responder(objSolicitacao) ?? this.responderLocal(objSolicitacao);
        }

        private Resposta responderLocal(Solicitacao objSolicitacao)
        {
            return new Resposta(objSolicitacao).addHtml(new PagRpgPrincipal());
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}