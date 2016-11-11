using System;
using System.Windows.Forms;
using CSCore.CoreAudioAPI;
using DigoFramework;
using Rpg.Dominio;

namespace Rpg.Controle.TabDock
{
    public partial class TabDockMixer : TabDockRpgBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private MMDevice _objDevice;

        public MMDevice objDevice
        {
            get
            {
                if (_objDevice != null)
                {
                    return _objDevice;
                }

                _objDevice = this.getObjDevice();

                return _objDevice;
            }
        }

        #endregion Atributos

        #region Construtores

        public TabDockMixer()
        {
            this.InitializeComponent();
        }

        #endregion Construtores

        #region Métodos

        internal void fecharAplicacao()
        {
            foreach (Control ctrCanal in this.pnlMixer.Controls)
            {
                ((CanalMixer)ctrCanal).fecharAplicacao();
            }
        }

        internal void abrirAudio(AudioDominio objAudio)
        {
            if (objAudio == null)
            {
                return;
            }

            if (!this.Visible)
            {
                AppRpg.i.frmPrincipal.abrirMixer();
            }

            AppRpg.i.objJogo.addObjAudio(objAudio);

            this.addObjAdudio(objAudio);
        }

        private void addObjAdudio(AudioDominio objAudio)
        {
            if (objAudio == null)
            {
                return;
            }

            foreach (Control ctrCanal in this.pnlMixer.Controls)
            {
                if ((ctrCanal as CanalMixer).objAudio.attDirCompleto.strValor.Equals(objAudio.attDirCompleto.strValor))
                {
                    return;
                }
            }

            CanalMixer ctrCanalNovo = new CanalMixer(this);

            ctrCanalNovo.Dock = DockStyle.Top;
            ctrCanalNovo.objAudio = objAudio;

            this.pnlMixer.Controls.Add(ctrCanalNovo);
            this.pnlMixer.Controls.SetChildIndex(ctrCanalNovo, 0);
        }

        private void carregarAudio()
        {
            if (AppRpg.i.objJogo == null)
            {
                return;
            }

            foreach (AudioDominio objAudio in AppRpg.i.objJogo.lstObjAudio)
            {
                this.addObjAdudio(objAudio);
            }
        }

        private MMDevice getObjDevice()
        {
            // TODO: Permitir que o usuário possa escolher o device.

            using (var objMMDeviceEnumerator = new MMDeviceEnumerator())
            using (var objMMDeviceCollection = objMMDeviceEnumerator.EnumAudioEndpoints(DataFlow.Render, DeviceState.Active))
            {
                foreach (var objDevice in objMMDeviceCollection)
                {
                    if (!objDevice.FriendlyName.Contains("Real"))
                    {
                        continue;
                    }

                    return objDevice;
                }
            }

            return null;
        }

        #endregion Métodos

        #region Eventos

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            try
            {
                this.carregarAudio();
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex);
            }
        }

        #endregion Eventos
    }
}