using Newtonsoft.Json;

namespace Rpg.Dominio
{
    public class AudioDominio : ArquivoDominio
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private Atributo _attIntVolume;

        [JsonIgnore]
        public Atributo attIntVolume
        {
            get
            {
                if (_attIntVolume != null)
                {
                    return _attIntVolume;
                }

                _attIntVolume = new Atributo(this, "Volume");

                return _attIntVolume;
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override void inicializar(bool booCriacao)
        {
            base.inicializar(booCriacao);

            if (booCriacao)
            {
                this.attIntVolume.objDominio = this;
            }
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}