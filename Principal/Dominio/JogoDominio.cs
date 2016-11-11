using System.Collections.Generic;
using System.IO;

namespace Rpg.Dominio
{
    public class JogoDominio : ArquivoDominio
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private List<AudioDominio> _lstObjAudio;

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

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}