using System;
using System.IO;
using DigoFramework;
using Newtonsoft.Json;

namespace Rpg.Dominio
{
    public class ArquivoDominio : ContainerDominioBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private Atributo _attDirCompleto;

        [JsonIgnore]
        public Atributo attDirCompleto
        {
            get
            {
                if (_attDirCompleto != null)
                {
                    return _attDirCompleto;
                }

                _attDirCompleto = this.getAtt("Diretório");

                return _attDirCompleto;
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override void inicializar(bool booCriacao)
        {
            base.inicializar(booCriacao);

            this.attDirCompleto.booSomenteLeitura = true;
        }

        protected override void setEventos()
        {
            base.setEventos();

            this.attStrNome.onStrValorAlterado += this.attStrNome_onStrValorAlterado;
        }

        private void atualizarNome()
        {
            if (!File.Exists(this.attDirCompleto.strValor))
            {
                return;
            }

            if (string.IsNullOrEmpty(this.attStrNome.strValor))
            {
                return;
            }

            string dirNovo = Path.Combine(Path.GetDirectoryName(this.attDirCompleto.strValor), (this.attStrNome.strValor + AppRpg.STR_EXTENSAO));

            File.Move(this.attDirCompleto.strValor, dirNovo);

            this.attDirCompleto.strValor = dirNovo;
        }

        #endregion Métodos

        #region Eventos

        private void attStrNome_onStrValorAlterado(object sender, EventArgs e)
        {
            try
            {
                this.atualizarNome();
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex);
            }
        }

        #endregion Eventos
    }
}