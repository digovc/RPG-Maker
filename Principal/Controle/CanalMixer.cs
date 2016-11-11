using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
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

        private const string STR_TIME_FORMAT = "mm':'ss";

        #endregion Constantes

        #region Atributos

        private bool _booLoop;
        private AudioDominio _objAudio;
        private ISoundOut _objSoundOut;
        private IWaveSource _objWave;
        private TabDockMixer _tabDockMixer;
        private Thread _trdTime;

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

        private bool booLoop
        {
            get
            {
                return _booLoop;
            }

            set
            {
                _booLoop = value;
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

        private Thread trdTime
        {
            get
            {
                if (_trdTime != null)
                {
                    return _trdTime;
                }

                _trdTime = this.getTrdTime();

                return _trdTime;
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

        private void atualizarLoop()
        {
            this.booLoop = !this.booLoop;
        }

        private void atualizarPosicao()
        {
            this.objWave.SetPosition(TimeSpan.FromSeconds(this.tcbTime.Value));
        }

        private void atualizarTime()
        {
            if (this.objWave == null)
            {
                return;
            }

            while (true)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    this.atualizarTimeThreadSafe();
                });

                Thread.Sleep(1000);
            }
        }

        private void atualizarTimeThreadSafe()
        {
            if (Math.Round(this.objWave.GetPosition().TotalSeconds) == Math.Round(this.objWave.GetLength().TotalSeconds))
            {
                this.atualizarTimeThreadSafeReiniciar();
            }

            this.tcbTime.Value = (int)this.objWave.GetPosition().TotalSeconds;

            this.lblTimeIn.Text = this.objWave.GetPosition().ToString(STR_TIME_FORMAT);
            this.lblTimeOut.Text = (this.objWave.GetLength() - this.objWave.GetPosition()).ToString(STR_TIME_FORMAT);
        }

        private void atualizarTimeThreadSafeReiniciar()
        {
            this.objWave.Position = 0;

            if (this.booLoop)
            {
                this.objSoundOut.Play();
                return;
            }

            this.objSoundOut.Stop();
        }

        private void atualizarVolume()
        {
            if (this.objSoundOut == null)
            {
                return;
            }

            this.objSoundOut.Volume = ((float)this.tcbVolume.Value / this.tcbVolume.Maximum);
        }

        private void fadeOut()
        {
            try
            {
                if (ConfigRpg.i.intAudioFade <= 0)
                {
                    return;
                }

                float fltVolumeParte = this.objSoundOut.Volume / ConfigRpg.i.intAudioFade;

                if (fltVolumeParte <= 0)
                {
                    return;
                }

                for (int i = 0; i < ConfigRpg.i.intAudioFade; i++)
                {
                    if ((this.objSoundOut.Volume - fltVolumeParte) <= 0)
                    {
                        return;
                    }

                    this.objSoundOut.Volume = (this.objSoundOut.Volume - fltVolumeParte);
                    Thread.Sleep(1);
                }
            }
            finally
            {
                this.objSoundOut.Pause();
            }
        }

        private Thread getTrdTime()
        {
            Thread trdResultado = new Thread(this.atualizarTime);

            trdResultado.IsBackground = true;
            trdResultado.Priority = ThreadPriority.Lowest;

            return trdResultado;
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
                this.reproduzirPause();
                return;
            }

            this.reproduzirPlay();
        }

        private void reproduzirPause()
        {
            Task.Run(() => this.fadeOut());
        }

        private void reproduzirPlay()
        {
            this.objSoundOut.Volume = ((float)this.tcbVolume.Value / this.tcbVolume.Maximum);
            this.objSoundOut.Play();

            if (!this.trdTime.IsAlive)
            {
                this.trdTime.Start();
            }
        }

        private void setObjAudio(AudioDominio objAudio)
        {
            if (objAudio == null)
            {
                return;
            }

            this.lblTitulo.Text = Path.GetFileNameWithoutExtension(objAudio.attDirCompleto.strValor);

            if (this.objWave == null)
            {
                return;
            }

            this.tcbTime.Value = 0;
            this.tcbTime.Maximum = (int)this.objWave.GetLength().TotalSeconds;

            this.lblTimeIn.Text = "00:00";
            this.lblTimeOut.Text = this.objWave.GetLength().ToString(STR_TIME_FORMAT);

            this.tcbVolume.Value = objAudio.attIntVolume.intValor;
        }

        #endregion Métodos

        #region Eventos

        private void btnLoop_Click(object sender, EventArgs e)
        {
            try
            {
                this.atualizarLoop();
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex);
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            try
            {
                this.reproduzir();
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

        private void tcbTime_Scroll(object sender, EventArgs e)
        {
            try
            {
                this.atualizarPosicao();
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex);
            }
        }

        private void tcbVolume_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.atualizarVolume();
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex);
            }
        }

        #endregion Eventos
    }
}