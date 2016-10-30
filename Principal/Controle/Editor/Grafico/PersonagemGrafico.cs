using System.Drawing;
using Rpg.Dominio;

namespace Rpg.Controle.Editor.Grafico
{
    public class PersonagemGrafico : GraficoSelecionavelBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private RelMapaPersonagemDominio _objRelMapaPersonagem;

        public RelMapaPersonagemDominio objRelMapaPersonagem
        {
            get
            {
                return _objRelMapaPersonagem;
            }

            private set
            {
                _objRelMapaPersonagem = value;
            }
        }

        #endregion Atributos

        #region Construtores

        public PersonagemGrafico(DisplayBase objDisplay, RelMapaPersonagemDominio objRelMapaPersonagem) : base(objDisplay)
        {
            this.objRelMapaPersonagem = objRelMapaPersonagem;
        }

        #endregion Construtores

        #region Métodos

        public override void renderizar(Graphics gpc)
        {
            gpc.DrawImage(AppRpg.i.getBmpCache(this.objRelMapaPersonagem.objPersonagem.objTile.dirImg), 0, 0);
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}