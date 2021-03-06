﻿using System.Windows.Forms;
using Rpg.Dominio;

namespace Rpg.Controle.Painel
{
    public partial class PnlItemBase : UserControlRpgBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private bool _booSelecionado;
        private RpgDominioBase _objDominio;

        public bool booSelecionado
        {
            get
            {
                return _booSelecionado;
            }

            set
            {
                if (_booSelecionado == value)
                {
                    return;
                }

                _booSelecionado = value;

                this.setBooSelecionado(_booSelecionado);
            }
        }

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

        public PnlItemBase()
        {
            this.InitializeComponent();
        }

        #endregion Construtores

        #region Métodos

        protected override void inicializar()
        {
            this.Dock = DockStyle.Top;
        }

        private void setBooSelecionado(bool booSelecionado)
        {
            this.lblTitulo.Font = new System.Drawing.Font(this.lblTitulo.Font, booSelecionado ? System.Drawing.FontStyle.Bold : System.Drawing.FontStyle.Regular);
        }

        private void setObjDominio(RpgDominioBase objDominio)
        {
            if (objDominio == null)
            {
                return;
            }

            this.lblTitulo.Text = objDominio.attStrNome.strValor;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}