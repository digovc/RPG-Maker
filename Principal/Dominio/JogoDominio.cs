using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Rpg.Dominio
{
    public class JogoDominio : ArquivoDominio
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private Atributo _attIntAudioFade;
        private List<AudioDominio> _lstObjAudio;

        [JsonIgnore]
        public Atributo attIntAudioFade
        {
            get
            {
                if (_attIntAudioFade != null)
                {
                    return _attIntAudioFade;
                }

                _attIntAudioFade = this.getAtt("Fade dos canais de áudio", null);

                return _attIntAudioFade;
            }
        }

        public List<AudioDominio> lstObjAudio
        {
            get
            {
                if (_lstObjAudio != null)
                {
                    return _lstObjAudio;
                }

                _lstObjAudio = new List<AudioDominio>();

                return _lstObjAudio;
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        internal static JogoDominio criar(string dirJogo)
        {
            if (string.IsNullOrEmpty(dirJogo))
            {
                return null;
            }

            JogoDominio objJogoResultado = new JogoDominio();

            objJogoResultado.attDirCompleto.strValor = dirJogo;
            objJogoResultado.attStrNome.strValor = Path.GetFileNameWithoutExtension(dirJogo);

            objJogoResultado.iniciar(true);

            return objJogoResultado;
        }

        internal void addObjAudio(AudioDominio objAudio)
        {
            if (objAudio == null)
            {
                return;
            }

            if (this.lstObjAudio.Contains(objAudio))
            {
                return;
            }

            foreach (AudioDominio objAudio2 in this.lstObjAudio)
            {
                if (objAudio2.attDirCompleto.strValor.Equals(objAudio.attDirCompleto.strValor))
                {
                    return;
                }
            }

            this.lstObjAudio.Add(objAudio);
        }

        protected override void inicializar(bool booCriacao)
        {
            base.inicializar(booCriacao);

            this.attIntAudioFade.intValor = (!booCriacao) ? this.attIntAudioFade.intValor : 1500;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}