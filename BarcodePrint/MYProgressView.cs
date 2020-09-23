using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Runtime;
using System.Drawing;

namespace BarcodePrinter
{
    class MYProgressView : Control
    {
        // Summary:
        //     Initializes a new instance of the System.Windows.Forms.Control class with
        //     default settings.
        public MYProgressView()
        {
        }
        //
        // Summary:
        //     Initializes a new instance of the System.Windows.Forms.Control class with
        //     specific text.
        //
        // Parameters:
        //   text:
        //     The text displayed by the control.
        public MYProgressView(string text)
            : base(text) { }
        //
        // Summary:
        //     Initializes a new instance of the System.Windows.Forms.Control class as a
        //     child control, with specific text.
        //
        // Parameters:
        //   parent:
        //     The System.Windows.Forms.Control to be the parent of the control.
        //
        //   text:
        //     The text displayed by the control.
        public MYProgressView(Control parent, string text)
            : base(parent, text) { }
        //
        // Summary:
        //     Initializes a new instance of the System.Windows.Forms.Control class with
        //     specific text, size, and location.
        //
        // Parameters:
        //   text:
        //     The text displayed by the control.
        //
        //   left:
        //     The System.Drawing.Point.X position of the control, in pixels, from the left
        //     edge of the control's container. The value is assigned to the System.Windows.Forms.Control.Left
        //     property.
        //
        //   top:
        //     The System.Drawing.Point.Y position of the control, in pixels, from the top
        //     edge of the control's container. The value is assigned to the System.Windows.Forms.Control.Top
        //     property.
        //
        //   width:
        //     The width of the control, in pixels. The value is assigned to the System.Windows.Forms.Control.Width
        //     property.
        //
        //   height:
        //     The height of the control, in pixels. The value is assigned to the System.Windows.Forms.Control.Height
        //     property.
        public MYProgressView(string text, int left, int top, int width, int height)
            : base(text, left, top, width, height) { }
        //
        // Summary:
        //     Initializes a new instance of the System.Windows.Forms.Control class as a
        //     child control, with specific text, size, and location.
        //
        // Parameters:
        //   parent:
        //     The System.Windows.Forms.Control to be the parent of the control.
        //
        //   text:
        //     The text displayed by the control.
        //
        //   left:
        //     The System.Drawing.Point.X position of the control, in pixels, from the left
        //     edge of the control's container. The value is assigned to the System.Windows.Forms.Control.Left
        //     property.
        //
        //   top:
        //     The System.Drawing.Point.Y position of the control, in pixels, from the top
        //     edge of the control's container. The value is assigned to the System.Windows.Forms.Control.Top
        //     property.
        //
        //   width:
        //     The width of the control, in pixels. The value is assigned to the System.Windows.Forms.Control.Width
        //     property.
        //
        //   height:
        //     The height of the control, in pixels. The value is assigned to the System.Windows.Forms.Control.Height
        //     property.
        public MYProgressView(Control parent, string text, int left, int top, int width, int height)
            : base(parent, text, left, top, width, height) { }

        private bool _IsProcessRunning;
        public bool IsProcessRunning
        {
            get
            {
                return _IsProcessRunning;
            }
            set
            {
                _IsProcessRunning = value;
                if (_IsProcessRunning)
                {
                    timer = new Timer();
                    timer.Interval = 100;
                    timer.Tick += new EventHandler(timer_Tick);
                    timer.Start();
                }
                else
                {
                    try
                    {
                        if (timer != null)
                            timer.Stop();
                    }
                    catch (Exception ex)
                    { }
                }
                this.Invalidate();
            }
        }

        private static int _progress;
        private static int Progress
        {
            get
            {
                if (_progress < 255) ++_progress;
                else _progress = 0;
                return _progress;
            }
        }

        private Brush MYBrush
        {
            get
            {
                return new SolidBrush(Color.FromArgb(Progress, Progress, Progress));
            }
        }
        private Timer timer;
        protected override void OnPaint(PaintEventArgs e)
        {
            float i;
            //base.OnPaint(e);
            if (_IsProcessRunning)
            {

                int cx = e.ClipRectangle.Top + (e.ClipRectangle.Width / 2);
                int cy = e.ClipRectangle.Top + (e.ClipRectangle.Height / 2);
                int r = (int)(e.ClipRectangle.Height * 0.4);
                int t = (int)(e.ClipRectangle.Height * 0.1);
                i = (float)Progress;
                e.Graphics.Clear(this.BackColor);
                try
                {
                    this.AppearRectangle(e.Graphics, e.ClipRectangle, TickCount);
                    //e.Graphics.FillPie(MYBrush, e.ClipRectangle, 0, i);
                }
                catch (Exception) { }
                //e.Graphics.FillRectangle(MYBrush, e.ClipRectangle);
            }
            else
            {
                base.OnPaint(e);
            }
        }
        int TickCountBoundry { get { return this.Width < this.Height ? this.Width : this.Height; } }

        int _TickCount;
        int TickCount
        {
            get
            {
                return _TickCount;
            }
            set
            {
                _TickCount = value;
                if (_TickCount > TickCountBoundry) TickCount = 0;
            }
        }

        void timer_Tick(object sender, EventArgs e)
        {
            TickCount++;
            this.Invalidate();
        }

        void AppearRectangle(Graphics g, Rectangle Squre, int i)
        {
            int wN;
            int hN;
            wN = Squre.Width / 2;
            hN = Squre.Height / 2;
            Point top;
            Rectangle drawRect;
            Size drawSize;
            if (wN == hN)
            {
                top = new Point((wN - i), (hN - i));
                drawSize = new Size(2 * i, 2 * i);
                drawRect = new Rectangle(top, drawSize);
                g.FillRectangle(MYBrush, drawRect);
            }
        }
    }
}
