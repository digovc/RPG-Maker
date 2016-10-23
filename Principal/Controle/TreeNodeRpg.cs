using System;
using System.IO;
using System.Windows.Forms;
using DigoFramework;
using Rpg.Dominio;

namespace Rpg.Controle
{
    public class TreeNodeRpg : TreeNode
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private RpgDominioBase _objDominio;

        public RpgDominioBase objDominio
        {
            get
            {
                return _objDominio;
            }

            set
            {
                if (_objDominio == value)
                {
                    return;
                }

                _objDominio = value;

                this.setObjDominio(_objDominio);
            }
        }

        #endregion Atributos

        #region Construtores

        public TreeNodeRpg(RpgDominioBase objDominio)
        {
            this.objDominio = objDominio;
        }

        #endregion Construtores

        #region Métodos

        private void atualizarText()
        {
            if (this.objDominio == null)
            {
                return;
            }

            if (this.objDominio.attStrNome == null)
            {
                return;
            }

            if (this.Text == this.objDominio.attStrNome.strValor)
            {
                return;
            }

            this.Text = this.objDominio.attStrNome.strValor;

            this.atualizarTextPasta();
        }

        private void atualizarTextPasta()
        {
            if (this.objDominio == null)
            {
                return;
            }

            if (!(this.objDominio is PastaDominio))
            {
                return;
            }

            foreach (TreeNode tnr in this.Nodes)
            {
                this.atualizarTextPasta((this.objDominio as PastaDominio), tnr as TreeNodeRpg);
            }
        }

        private void atualizarTextPasta(PastaDominio objPastaPai, TreeNodeRpg tnrFilho)
        {
            if (tnrFilho.objDominio == null)
            {
                return;
            }

            if (tnrFilho.objDominio is ArquivoRefDominio)
            {
                this.atualizarTextPasta(objPastaPai, (tnrFilho.objDominio as ArquivoRefDominio));
            }

            if (!(tnrFilho.objDominio is PastaDominio))
            {
                return;
            }

            foreach (TreeNode tnrFilhoFilho in tnrFilho.Nodes)
            {
                this.atualizarTextPasta((tnrFilho.objDominio as PastaDominio), (tnrFilhoFilho as TreeNodeRpg));
            }
        }

        private void atualizarTextPasta(PastaDominio objPastaPai, ArquivoRefDominio objArqRef)
        {
            objArqRef.attDirArquivo.strValor = Path.Combine(objPastaPai.attDirCompleto.strValor, (objArqRef.attStrNome.strValor + Path.GetExtension(objArqRef.attDirArquivo.strValor)));
        }

        private void setObjDominio(RpgDominioBase objDominio)
        {
            if (objDominio == null)
            {
                return;
            }

            this.Text = objDominio.attStrNome.strValor;

            objDominio.attStrNome.onStrValorAlterado += this.objDominio_onNomeAlterado;
        }

        #endregion Métodos

        #region Eventos

        private void objDominio_onNomeAlterado(object sender, EventArgs arg)
        {
            try
            {
                this.atualizarText();
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex);
            }
        }

        #endregion Eventos
    }
}