using System.Collections.Generic;

namespace Rpg.Dominio
{
    public abstract class ContainerDominioBase : RpgDominioBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private List<RpgDominioBase> _lstObjFilho;

        public List<RpgDominioBase> lstObjFilho
        {
            get
            {
                if (_lstObjFilho != null)
                {
                    return _lstObjFilho;
                }

                _lstObjFilho = new List<RpgDominioBase>();

                return _lstObjFilho;
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        internal virtual void addFilho(RpgDominioBase objDominio)
        {
            if (objDominio == null)
            {
                return;
            }

            objDominio.objPai = this;

            if (this.lstObjFilho.Contains(objDominio))
            {
                return;
            }

            this.lstObjFilho.Add(objDominio);
        }

        internal virtual bool validarItem(RpgDominioBase objDominio)
        {
            return true;
        }

        protected override void inicializar()
        {
            base.inicializar();

            this.inicializarLstObjFilho();
        }

        private void inicializarLstObjFilho()
        {
            if (this.lstObjFilho == null)
            {
                return;
            }

            foreach (RpgDominioBase objFilho in this.lstObjFilho)
            {
                objFilho?.iniciar();
            }
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}