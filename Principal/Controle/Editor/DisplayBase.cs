using System;
using System.Windows.Forms;
using DigoFramework;
using Rpg.Controle.Editor.Grafico;

namespace Rpg.Controle.Editor
{
    public partial class DisplayBase : UserControlRpgBase
    {
        #region Constantes

        internal const int INT_ZOOM_INCREMENTO = 2;

        private const float INT_ZOOM_MAXIMO = 5;
        private const float INT_ZOOM_MINIMO = 1;

        #endregion Constantes

        #region Atributos

        private float _fltZoom = 1;
        private int _intMoveX;
        private int _intMoveXTemp;
        private int _intMoveY;
        private int _intMoveYTemp;
        private int _intTamanhoX;
        private int _intTamanhoY;
        private int _intTileTamanho;
        private GridGrafico _objGrid;
        private SelecaoGrafico _objSelecao;

        public int intTamanhoX
        {
            get
            {
                return _intTamanhoX;
            }

            set
            {
                _intTamanhoX = value;
            }
        }

        public int intTamanhoY
        {
            get
            {
                return _intTamanhoY;
            }

            set
            {
                _intTamanhoY = value;
            }
        }

        public int intTileTamanho
        {
            get
            {
                if (_intTileTamanho != 0)
                {
                    return _intTileTamanho;
                }

                _intTileTamanho = this.getIntTileTamanho();

                return _intTileTamanho;
            }

            set
            {
                if (_intTileTamanho == value)
                {
                    return;
                }

                _intTileTamanho = value;

                this.setIntTileTamanho(_intTileTamanho);
            }
        }

        public SelecaoGrafico objSelecao
        {
            get
            {
                if (_objSelecao != null)
                {
                    return _objSelecao;
                }

                _objSelecao = new SelecaoGrafico(this);

                return _objSelecao;
            }
        }

        internal float fltZoom
        {
            get
            {
                return _fltZoom;
            }

            set
            {
                if (_fltZoom == value)
                {
                    return;
                }

                _fltZoom = value;

                this.setfltZoom(_fltZoom);
            }
        }

        internal int intMoveX
        {
            get
            {
                return _intMoveX;
            }

            set
            {
                if (_intMoveX == value)
                {
                    return;
                }

                _intMoveX = value;

                this.setIntMoveX(_intMoveX);
            }
        }

        internal int intMoveY
        {
            get
            {
                return _intMoveY;
            }

            set
            {
                if (_intMoveY == value)
                {
                    return;
                }

                _intMoveY = value;

                this.setIntMoveY(_intMoveY);
            }
        }

        protected GridGrafico objGrid
        {
            get
            {
                if (_objGrid != null)
                {
                    return _objGrid;
                }

                _objGrid = new GridGrafico(this);

                return _objGrid;
            }
        }

        private int intMoveXTemp
        {
            get
            {
                return _intMoveXTemp;
            }

            set
            {
                _intMoveXTemp = value;
            }
        }

        private int intMoveYTemp
        {
            get
            {
                return _intMoveYTemp;
            }

            set
            {
                _intMoveYTemp = value;
            }
        }

        #endregion Atributos

        #region Construtores

        public DisplayBase()
        {
            this.InitializeComponent();
        }

        #endregion Construtores

        #region Métodos

        protected virtual int getIntTileTamanho()
        {
            return 0;
        }

        protected override void inicializar()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        protected virtual void processarClick(MouseEventArgs arg)
        {
        }

        protected virtual void renderizar(PaintEventArgs arg)
        {
            // TODO: Desenhar apenas o que é visto na tela.
            this.renderizarGrid(arg);
            this.renderizarSelecao(arg);
        }

        protected virtual void renderizarGrid(PaintEventArgs arg)
        {
            this.objGrid.renderizar(arg);
        }

        protected virtual void setIntTileTamanho(int intTileTamanho)
        {
            this.Invalidate();

            this.onIntTileTamanhoChanged?.Invoke(this, EventArgs.Empty);
        }

        protected virtual bool validarRenderizar()
        {
            return true;
        }

        private void processarMouseDown(MouseEventArgs arg)
        {
            if (this.processarMouseDownMover(arg))
            {
                return;
            }

            if (this.processarMouseDownClick(arg))
            {
                return;
            }
        }

        private bool processarMouseDownClick(MouseEventArgs arg)
        {
            if (!MouseButtons.Left.Equals(arg.Button))
            {
                return false;
            }

            this.processarClick(arg);

            return true;
        }

        private bool processarMouseDownMover(MouseEventArgs arg)
        {
            if (!MouseButtons.Middle.Equals(arg.Button))
            {
                return false;
            }

            this.intMoveXTemp = (arg.X - this.intMoveX);
            this.intMoveYTemp = (arg.Y - this.intMoveY);

            return true;
        }

        private void processarMouseMove(MouseEventArgs arg)
        {
            if (!MouseButtons.Middle.Equals(arg.Button))
            {
                return;
            }

            this.intMoveX = (arg.X - this.intMoveXTemp);
            this.intMoveY = (arg.Y - this.intMoveYTemp);

            this.Invalidate();
        }

        private void processarZoom(MouseEventArgs arg)
        {
            this.fltZoom += (arg.Delta > 0) ? 0.1f : -0.1f;

            (arg as HandledMouseEventArgs).Handled = true;
        }

        private void renderizarLocal(PaintEventArgs arg)
        {
            if (!this.validarRenderizar())
            {
                return;
            }

            this.renderizar(arg);
        }

        private void renderizarSelecao(PaintEventArgs arg)
        {
            this.objSelecao.renderizar(arg);
        }

        private void setfltZoom(float fltZoom)
        {
            if (fltZoom < INT_ZOOM_MINIMO)
            {
                this.fltZoom = INT_ZOOM_MINIMO;
                return;
            }

            if (fltZoom > INT_ZOOM_MAXIMO)
            {
                this.fltZoom = INT_ZOOM_MAXIMO;
                return;
            }

            this.onZooming?.Invoke(this, EventArgs.Empty);

            this.Invalidate();
        }

        private void setIntMoveX(int intMoveX)
        {
            this.onMovingX?.Invoke(this, EventArgs.Empty);
        }

        private void setIntMoveY(int intMoveY)
        {
            this.onMovingY?.Invoke(this, EventArgs.Empty);
        }

        #endregion Métodos

        #region Eventos

        protected override void OnMouseDown(MouseEventArgs arg)
        {
            base.OnMouseDown(arg);

            try
            {
                this.processarMouseDown(arg);
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex);
            }
        }

        protected override void OnMouseMove(MouseEventArgs arg)
        {
            base.OnMouseMove(arg);

            this.processarMouseMove(arg);
        }

        protected override void OnMouseWheel(MouseEventArgs arg)
        {
            base.OnMouseWheel(arg);

            this.processarZoom(arg);
        }

        protected override void OnPaint(PaintEventArgs arg)
        {
            //base.OnPaint(arg);

            this.renderizarLocal(arg);
        }

        public event EventHandler onIntTileTamanhoChanged;

        public event EventHandler onMovingX;

        public event EventHandler onMovingY;

        public event EventHandler onZooming;

        #endregion Eventos
    }
}