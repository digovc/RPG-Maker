using System;
using System.Drawing;
using System.Windows.Forms;
using DigoFramework;

namespace Rpg.Controle.Editor
{
    public partial class DisplayBase : UserControlRpgBase
    {
        #region Constantes

        internal const int INT_ZOOM_INCREMENTO = 2;
        private const int INT_ZOOM_MAXIMO = 25;
        private const int INT_ZOOM_MINIMO = -15;

        #endregion Constantes

        #region Atributos

        private int _intMoveX;
        private int _intMoveXTemp;
        private int _intMoveY;
        private int _intMoveYTemp;
        private int _intQuantidadeX;
        private int _intQuantidadeY;
        private int _intTileTamanho;
        private int _intZoom;
        private GridGrafico _objGrid;
        private SelecaoGrafico _objSelecao;

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

        internal int intMoveX
        {
            get
            {
                return _intMoveX;
            }

            set
            {
                _intMoveX = value;
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
                _intMoveY = value;
            }
        }

        internal int intQuantidadeX
        {
            get
            {
                if (_intQuantidadeX != 0)
                {
                    return _intQuantidadeX;
                }

                _intQuantidadeX = this.getIntQuantidadeX();

                return _intQuantidadeX;
            }

            set
            {
                _intQuantidadeX = value;
            }
        }

        internal int intQuantidadeY
        {
            get
            {
                if (_intQuantidadeY != 0)
                {
                    return _intQuantidadeY;
                }

                _intQuantidadeY = this.getIntQuantidadeY();

                return _intQuantidadeY;
            }

            set
            {
                _intQuantidadeY = value;
            }
        }

        internal int intZoom
        {
            get
            {
                return _intZoom;
            }

            set
            {
                if (_intZoom == value)
                {
                    return;
                }

                _intZoom = value;

                this.setIntZoom(_intZoom);
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

        private GridGrafico objGrid
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

        private SelecaoGrafico objSelecao
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

        #endregion Atributos

        #region Construtores

        public DisplayBase()
        {
            this.InitializeComponent();
        }

        #endregion Construtores

        #region Métodos

        protected virtual int getIntQuantidadeX()
        {
            return 0;
        }

        protected virtual int getIntQuantidadeY()
        {
            return 0;
        }

        protected virtual int getIntTileTamanho()
        {
            return 0;
        }

        protected override void inicializar()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        protected virtual void renderizar(PaintEventArgs arg)
        {
            // TODO: Desenhar apenas o que é visto na tela.
            this.renderizarGrid(arg.Graphics);
            this.renderizarSelecao(arg.Graphics);
        }

        protected virtual void renderizarGrid(Graphics gpc)
        {
            this.objGrid.renderizar(gpc);
        }

        protected virtual void setIntTileTamanho(int intTileTamanho)
        {
            this.Invalidate();
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

            if (this.processarMouseDownSelecionar(arg))
            {
                return;
            }
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

        private bool processarMouseDownSelecionar(MouseEventArgs arg)
        {
            if (!MouseButtons.Left.Equals(arg.Button))
            {
                return false;
            }

            if (this.intTileTamanho > 0)
            {
                this.selecionarTile(arg);
                return true;
            }

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
            this.intZoom += (arg.Delta > 0) ? 1 : -1;

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

        private void renderizarSelecao(Graphics grp)
        {
            this.objSelecao.renderizar(grp);
        }

        private void selecionarTile(MouseEventArgs arg)
        {
            this.objSelecao.selecionarTile(arg.X, arg.Y);
        }

        private void setIntZoom(int intZoom)
        {
            if (intZoom < INT_ZOOM_MINIMO)
            {
                this.intZoom = INT_ZOOM_MINIMO;
                return;
            }

            if (intZoom > INT_ZOOM_MAXIMO)
            {
                this.intZoom = INT_ZOOM_MAXIMO;
                return;
            }

            this.Invalidate();
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

        #endregion Eventos
    }
}