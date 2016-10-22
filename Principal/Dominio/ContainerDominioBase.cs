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

        protected override void inicializar(bool booCriacao)
        {
            base.inicializar(booCriacao);

            this.inicializarLstObjFilho(booCriacao);
        }

        private void inicializarLstObjFilho(bool booCriacao)
        {
            if (this.lstObjFilho == null)
            {
                return;
            }

            foreach (RpgDominioBase objFilho in this.lstObjFilho)
            {
                this.inicializarLstObjFilho(booCriacao, objFilho);
            }
        }

        private void inicializarLstObjFilho(bool booCriacao, RpgDominioBase objFilho)
        {
            if (objFilho == null)
            {
                return;
            }

            if (objFilho is ArquivoRefDominio)
            {
                this.inicializarLstObjFilho(booCriacao, (objFilho as ArquivoRefDominio).objArquivo);
            }

            objFilho.iniciar(booCriacao);
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}