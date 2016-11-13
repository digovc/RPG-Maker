using Rpg.Dominio;

namespace Rpg.Controle.Editor.Grafico
{
    public class PersonagemTileGrafico : TileGrafico
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private PersonagemTileDominio _objPersonagemTile;

        private PersonagemTileDominio objPersonagemTile
        {
            get
            {
                return _objPersonagemTile;
            }

            set
            {
                _objPersonagemTile = value;
            }
        }

        #endregion Atributos

        #region Construtores

        public PersonagemTileGrafico(DisplayBase objDisplay, PersonagemTileDominio objPersonagemTile) : base(objDisplay, objPersonagemTile)
        {
        }

        #endregion Construtores

        #region Métodos

        protected override void setBooSelecionado(bool booSelecionado)
        {
            base.setBooSelecionado(booSelecionado);

            if (this.objPersonagemTile == null)
            {
                return;
            }

            AppRpg.i.frmPrincipal.objSelecionado = booSelecionado ? this.objPersonagemTile.objPersonagem : null;
        }

        protected override void setObjTile(TileDominio objTile)
        {
            base.setObjTile(objTile);

            if (objTile == null)
            {
                return;
            }

            if (!(objTile is PersonagemTileDominio))
            {
                return;
            }

            this.objPersonagemTile = (objTile as PersonagemTileDominio);
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}