using System;
using System.IO;
using System.Threading.Tasks;
using CSCore;
using CSCore.Codecs;
using CSCore.SoundOut;
using DigoFramework;
using Rpg.Controle.TabDock;
using Rpg.Dominio;

namespace Rpg.Controle
{
    public partial class CanalMixer : UserControlRpgBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private AudioDominio _objAudio;

        private ISoundOut _objSoundOut;
        private IWaveSource _objWave;
        private TabDockMixer _tabDockMixer;

        public AudioDominio objAudio
        {
            get
            {
                return _objAudio;
            }

            set
            {
                if (_objAudio == value)
                {
                    return;
                }

                _objAudio = value;

                this.setObjAudio(_objAudio);
            }
        }

        private ISoundOut objSoundOut
        {
            get
            {
                if (_objSoundOut != null)
                {
                    return _objSoundOut;
                }

                _objSoundOut = this.getObjSoundOut();

                return _objSoundOut;
            }

            set
            {
                _objSoundOut = value;
            }
        }

        private IWaveSource objWave
        {
            get
            {
                if (_objWave != null)
                {
                    return _objWave;
                }

                _objWave = this.getObjWave();

                return _objWave;
            }

            set
            {
                _objWave = value;
            }
        }

        private TabDockMixer tabDockMixer
        {
            get
            {
                return _tabDockMixer;
            }

            set
            {
                _tabDockMixer = value;
            }
        }

        #endregion Atributos

        #region Construtores

        public CanalMixer(TabDockMixer tabDockMixer)
        {
            this.InitializeComponent();

            this.tabDockMixer = tabDockMixer;
        }

        #endregion Construtores

        #region Métodos

        internal void fecharAplicacao()
        {
            if (this.objWave == null)
            {
                return;
            }

            this.objSoundOut.Stop();

            this.objSoundOut.Dispose();
            this.objWave.Dispose();
        }

        private void reproduzir()
        {
            if (this.objAudio == null)
            {
                return;
            }

            if (this.objSoundOut == null)
            {
                return;
            }

            if (PlaybackState.Playing.Equals(this.objSoundOut.PlaybackState))
            {
                this.objSoundOut.Pause();
                return;
            }

            this.objSoundOut.Play();
        }

        private void setObjAudio(AudioDominio objAudio)
        {
            if (objAudio == null)
            {
                return;
            }

            this.lblTitulo.Text = Path.GetFileNameWithoutExtension(objAudio.attDirCompleto.strValor);

            this.tcbTime.Value = 0;
            this.tcbVolume.Value = objAudio.attIntVolume.intValor;
        }

        #endregion Métodos

        #region Eventos

        private void btnPlay_Click(object sender, EventArgs e)
        {
            try
            {
                Task.Run(() => this.reproduzir());
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex);
            }
        }

        private ISoundOut getObjSoundOut()
        {
            if (this.tabDockMixer.objDevice == null)
            {
                return null;
            }

            if (this.objWave == null)
            {
                return null;
            }

            ISoundOut objSoundOutResultado = new WasapiOut() { Latency = 100, Device = this.tabDockMixer.objDevice };

            objSoundOutResultado.Initialize(this.objWave);

            return objSoundOutResultado;
        }

        private IWaveSource getObjWave()
        {
            IWaveSource objWaveResultado = CodecFactory.Instance.GetCodec(this.objAudio.attDirCompleto.strValor)
                .ToSampleSource()
                .ToStereo()
                .ToWaveSource();

            return objWaveResultado;
        }

        #endregion Eventos
    }
}