using System;
using DigoFramework;

namespace Rpg.Controle.EditAtributo
{
    public partial class EditAtributoBoolen : EditAtributoBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        #endregion Atributos

        #region Construtores

        public EditAtributoBoolen()
        {
            this.InitializeComponent();
        }

        #endregion Construtores

        #region Métodos

        #endregion Métodos

        #region Eventos

        private void ckbBooValor_CheckedChanged(object sender, System.EventArgs e)
        {
            try
            {
                this.atualizarStrValor(this.ckbBooValor.Checked.ToString());
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex);
            }
        }

        #endregion Eventos
    }
}