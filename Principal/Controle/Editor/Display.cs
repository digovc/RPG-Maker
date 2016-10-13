using System;
using System.Drawing;
using System.Windows.Forms;
using DigoFramework;
using Rpg.Dominio;

namespace Rpg.Controle.Editor
{
    public partial class Display : UserControl
    {
        #region Constantes

        internal const int INT_TILE_TAMANHO = 50;
        internal const int INT_ZOOM = 2;

        private const int INT_ZOOM_MAXIMO = 25;
        private const int INT_ZOOM_MINIMO = -15;

        #endregion Constantes

        #region Atributos

        private bool _booClick;
        private bool _booRenderizar = true;
        private int _intMoveX;
        private int _intMoveXTemp;
        private int _intMoveY;
        private int _intMoveYTemp;
        private int _intZoom;
        private Grid _objGrid;

        private MapaDominio _objMapa;

        public MapaDominio objMapa
        {
            get
            {
                return _objMapa;
            }

            set
            {
                _objMapa = value;
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

        private bool booClick
        {
            get
            {
                return _booClick;
            }

            set
            {
                _booClick = value;
            }
        }

        private bool booRenderizar
        {
            get
            {
                return _booRenderizar;
            }

            set
            {
                _booRenderizar = value;
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

        private Grid objGrid
        {
            get
            {
                if (_objGrid != null)
                {
                    return _objGrid;
                }

                _objGrid = new Grid(this);

                return _objGrid;
            }
        }

        #endregion Atributos

        #region Construtores

        public Display()
        {
            this.InitializeComponent();

            this.iniciar();
        }

        #endregion Construtores

        #region Métodos

        private void inicializar()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        private void iniciar()
        {
            this.inicializar();
        }

        private void processarMouseDown(MouseEventArgs arg)
        {
            if (!MouseButtons.Left.Equals(arg.Button))
            {
                return;
            }

            this.intMoveXTemp = (arg.X - this.intMoveX);
            this.intMoveYTemp = (arg.Y - this.intMoveY);
        }

        private void processarMouseMove(MouseEventArgs arg)
        {
            if (!MouseButtons.Left.Equals(arg.Button))
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

        private void renderizar(PaintEventArgs arg)
        {
            if (this.objMapa == null)
            {
                return;
            }

            this.renderizarGrid(arg.Graphics);
        }

        private void renderizarGrid(Graphics gpc)
        {
            this.objGrid.renderizar(gpc);
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

            this.processarMouseDown(arg);
        }

        protected override void OnMouseMove(MouseEventArgs arg)
        {
            base.OnMouseMove(arg);

            this.processarMouseMove(arg);
        }

        protected override void OnMouseWheel(MouseEventArgs arg)
        {
            base.OnMouseWheel(arg);

            try
            {
                this.processarZoom(arg);
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex);
            }
        }

        protected override void OnPaint(PaintEventArgs arg)
        {
            this.renderizar(arg);

            //base.OnPaint(arg);
        }

        #endregion Eventos
    }
}