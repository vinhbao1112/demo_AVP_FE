/*
 * This code is provided under the Code Project Open Licence (CPOL)
 * See http://www.codeproject.com/info/cpol10.aspx for details
 */

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace System.Windows.Forms
{
    [System.ComponentModel.ToolboxItem(false)]
    public abstract class TabStyleProvider : Component
    {
        #region Constructor

        protected TabStyleProvider(CustomTabControl tabControl)
        {
            this._TabControl = tabControl;

            this._BorderColor = Color.Empty;
            this._BorderColorSelected = Color.Empty;
            this._FocusColor = Color.Orange;
            this._ImageAlign = ContentAlignment.MiddleLeft;
            this.HotTrack = true;

            //	Must set after the _Overlap as this is used in the calculations of the actual padding
            this.Padding = new Point(6, 3);
            this._TabControl.FontChanged += new EventHandler(TabControl_FontChanged);
        }

        #endregion

        #region Factory Methods

        public static TabStyleProvider CreateProvider(CustomTabControl tabControl)
        {
            TabStyleProvider provider;

            //	Depending on the display style of the tabControl generate an appropriate provider.
            switch (tabControl.DisplayStyle)
            {
                case TabStyle.None:
                    provider = new TabStyleNoneProvider(tabControl);
                    break;

                case TabStyle.Default:
                    provider = new TabStyleDefaultProvider(tabControl);
                    break;

                case TabStyle.Angled:
                    provider = new TabStyleAngledProvider(tabControl);
                    break;

                case TabStyle.Rounded:
                    provider = new TabStyleRoundedProvider(tabControl);
                    break;

                case TabStyle.VisualStudio:
                    provider = new TabStyleVisualStudioProvider(tabControl);
                    break;

                case TabStyle.Chrome:
                    provider = new TabStyleChromeProvider(tabControl);
                    break;

                case TabStyle.IE8:
                    provider = new TabStyleIE8Provider(tabControl);
                    break;

                case TabStyle.SingleLoader:
                    provider = new TabStyleSingleLoaderProvider(tabControl);
                    break;

                default:
                    provider = new TabStyleDefaultProvider(tabControl);
                    break;
            }

            provider._Style = tabControl.DisplayStyle;
            return provider;
        }

        #endregion

        #region	Protected variables

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        protected CustomTabControl _TabControl;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        protected Point _Padding;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        protected bool _HotTrack;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        protected TabStyle _Style = TabStyle.Default;


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        protected ContentAlignment _ImageAlign;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        protected int _Radius = 1;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        protected int _Overlap;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        protected bool _FocusTrack;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        protected float _Opacity = 1;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        protected bool _ShowTabCloser;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        protected Color _BorderColorSelected = Color.Empty;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        protected Color _BorderColor = Color.Empty;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        protected Color _CloserColorActive = Color.Black;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        protected Color _CloserColor = Color.DarkGray;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        protected Color _FocusColor = Color.Empty;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        protected int _tabItemIndent = 0;
        private string _tabItemIndentText = string.Empty;
        private int _originHeightFirstTab = 0;
        private bool _isMargin = false;

        #endregion

        #region overridable Methods

        public abstract void AddTabBorder(GraphicsPath path, Rectangle tabBounds);

        public virtual Rectangle GetTabRect(int index)
        {

            if (index < 0)
            {
                return new Rectangle();
            }

            bool isFristLoad = false;
            bool isMargin = false;

            if (!this._TabControl.TabPages[0].Text.StartsWith(_tabItemIndentText) )
            {
                isFristLoad = true;
            }

            if (!DesignMode && index == 0 && _tabItemIndent > 0
                && _TabControl.TabPages.Count > 0 && !this._TabControl.TabPages[0].Text.StartsWith(_tabItemIndentText))
            {
                _isMargin = true;
                _originHeightFirstTab = this._TabControl.GetTabRect(index).Height;
                this._TabControl.TabPages[0].Text = _tabItemIndentText + this._TabControl.TabPages[0].Text;
                this._TabControl.ResumeLayout(true);
            }

            Rectangle tabBounds = this._TabControl.GetTabRect(index);
            bool firstTabinRow = this._TabControl.IsFirstTabInRow(index);
            int indent = 0;
            if (index == 0 || isFristLoad)
            {
                indent = _tabItemIndent;
            }

            //	Expand to overlap the tabpage
            switch (this._TabControl.Alignment)
            {
                case TabAlignment.Top:
                    tabBounds.Height += 2;
                    tabBounds.X += indent;
                    break;
                case TabAlignment.Bottom:
                    tabBounds.Height += 2;
                    tabBounds.Y -= 2;
                    tabBounds.X += indent;
                    break;
                case TabAlignment.Left:                
                        tabBounds.Width += 2;
                        tabBounds.Y += indent;
                        //tabBounds.Height -= indent;
                        if (index == 0 && _isMargin)
                        {
                            if (isFristLoad)
                            {
                                tabBounds.Height = _originHeightFirstTab;
                            }
                            else
                            {
                                tabBounds.Height = _originHeightFirstTab - 6;
                            }
                        }
                    break;
                case TabAlignment.Right:
                    tabBounds.X -= 0;
                    tabBounds.Width += 2;
                    tabBounds.Y += indent;
                    break;
            }

            //	Adjust first tab in the row to align with tabpage
            if (firstTabinRow)
            {
                if (this._TabControl.Alignment <= TabAlignment.Bottom)
                {
                    tabBounds.X += 1;
                    tabBounds.Width -= 1;
                }
                else
                {
                    tabBounds.Y += 1;
                    tabBounds.Height -= 1;
                }
            }


            //	Greate Overlap unless first tab in the row to align with tabpage
            if (!firstTabinRow && this._Overlap > 0)
            {
                if (this._TabControl.Alignment <= TabAlignment.Bottom)
                {
                    tabBounds.X -= this._Overlap;
                    tabBounds.Width += this._Overlap;
                }
                else
                {
                    tabBounds.Y -= this._Overlap;
                    tabBounds.Height += this._Overlap;
                }
            }

            return tabBounds;
        }

        protected virtual Brush GetTabBackgroundBrush(int index, bool bSupportSingleLoader)
        {
            LinearGradientBrush fillBrush = null;

            //Capture the colours dependant on selection state of the tab
            Color dark = _TabControl.DisplayTabColor;
            //Color dark = Color.FromArgb(83, 125, 168);//(207, 207, 207);
            //Color light = Color.FromArgb(82, 153, 193);//(242, 242, 242);
            Color light = dark;
            if (bSupportSingleLoader)
            {
                dark = Color.FromArgb(9, 247, 82);
                light = Color.FromArgb(150, 251, 181);
            }

            if (this._TabControl.SelectedIndex == index)
            {
                dark = SystemColors.ControlLight;
                light = this._TabControl.DisplaySelectedTabColor;
            }
            else if (!this._TabControl.TabPages[index].Enabled)
            {
                light = dark;
            }
            else if (this._HotTrack && index == this._TabControl.ActiveIndex)
            {
                //	Enable hot tracking
                if (bSupportSingleLoader)
                {
                    light = Color.FromArgb(220, 237, 225);
                    dark = Color.FromArgb(246, 253, 248);
                }
                else
                {
                    light = Color.FromArgb(234, 246, 253);
                    dark = Color.FromArgb(167, 217, 245);
                }
            }

            //	Get the correctly aligned gradient
            Rectangle tabBounds = this.GetTabRect(index);
            tabBounds.Inflate(3, 3);
            tabBounds.X -= 1;
            tabBounds.Y -= 1;
            switch (this._TabControl.Alignment)
            {
                case TabAlignment.Top:
                    if (this._TabControl.SelectedIndex == index)
                    {
                        dark = light;
                    }
                    fillBrush = new LinearGradientBrush(tabBounds, light, dark, LinearGradientMode.Vertical);
                    break;
                case TabAlignment.Bottom:
                    fillBrush = new LinearGradientBrush(tabBounds, light, dark, LinearGradientMode.Vertical);
                    break;
                case TabAlignment.Left:
                    fillBrush = new LinearGradientBrush(tabBounds, dark, light, LinearGradientMode.Horizontal);
                    break;
                case TabAlignment.Right:
                    fillBrush = new LinearGradientBrush(tabBounds, light, dark, LinearGradientMode.Horizontal);
                    break;
            }

            //	Add the blend
            fillBrush.Blend = this.GetBackgroundBlend();

            return fillBrush;
        }

        #endregion

        #region	Base Properties

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TabStyle DisplayStyle
        {
            get { return this._Style; }
            set { this._Style = value; }
        }

        [Category("Appearance")]
        public ContentAlignment ImageAlign
        {
            get { return this._ImageAlign; }
            set
            {
                this._ImageAlign = value;
                this._TabControl.Invalidate();
            }
        }

        [Category("Appearance")]
        public Point Padding
        {
            get { return this._Padding; }
            set
            {
                this._Padding = value;
                //	This line will trigger the handle to recreate, therefore invalidating the control
                if (this._ShowTabCloser)
                {
                    if (value.X + (int)(this._Radius / 2) < -6)
                    {
                        ((TabControl)this._TabControl).Padding = new Point(0, value.Y);
                    }
                    else
                    {
                        ((TabControl)this._TabControl).Padding = new Point(value.X + (int)(this._Radius / 2) + 6, value.Y);
                    }
                }
                else
                {
                    if (value.X + (int)(this._Radius / 2) < 1)
                    {
                        ((TabControl)this._TabControl).Padding = new Point(0, value.Y);
                    }
                    else
                    {
                        ((TabControl)this._TabControl).Padding = new Point(value.X + (int)(this._Radius / 2) - 1, value.Y);
                    }
                }
            }
        }


        [Category("Appearance"), DefaultValue(1), Browsable(true)]
        public int Radius
        {
            get { return this._Radius; }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentException("The radius must be greater than 1", "value");
                }
                this._Radius = value;
                //	Adjust padding
                this.Padding = this._Padding;
            }
        }

        [Category("Appearance")]
        public int Overlap
        {
            get { return this._Overlap; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The tabs cannot have a negative overlap", "value");
                }
                this._Overlap = value;

            }
        }


        [Category("Appearance")]
        public bool FocusTrack
        {
            get { return this._FocusTrack; }
            set
            {
                this._FocusTrack = value;
                this._TabControl.Invalidate();
            }
        }

        [Category("Appearance")]
        public bool HotTrack
        {
            get { return this._HotTrack; }
            set
            {
                this._HotTrack = value;
                ((TabControl)this._TabControl).HotTrack = value;
            }
        }

        [Category("Appearance")]
        public bool ShowTabCloser
        {
            get { return this._ShowTabCloser; }
            set
            {
                this._ShowTabCloser = value;
                //	Adjust padding
                this.Padding = this._Padding;
            }
        }

        [Category("Appearance")]
        public float Opacity
        {
            get { return this._Opacity; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The opacity must be between 0 and 1", "value");
                }
                if (value > 1)
                {
                    throw new ArgumentException("The opacity must be between 0 and 1", "value");
                }
                this._Opacity = value;
                this._TabControl.Invalidate();
            }
        }

        [Category("Appearance"), DefaultValue(typeof(Color), "")]
        public Color BorderColorSelected
        {
            get
            {
                if (this._BorderColorSelected.IsEmpty)
                {
                    return ThemedColors.ToolBorder;
                }
                else
                {
                    return this._BorderColorSelected;
                }
            }
            set
            {
                if (value.Equals(ThemedColors.ToolBorder))
                {
                    this._BorderColorSelected = Color.Empty;
                }
                else
                {
                    this._BorderColorSelected = value;
                }
                this._TabControl.Invalidate();
            }
        }

        [Category("Appearance"), DefaultValue(typeof(Color), "")]
        public Color BorderColor
        {
            get
            {
                if (this._BorderColor.IsEmpty)
                {
                    return SystemColors.ControlDark;
                }
                else
                {
                    return this._BorderColor;
                }
            }
            set
            {
                if (value.Equals(SystemColors.ControlDark))
                {
                    this._BorderColor = Color.Empty;
                }
                else
                {
                    this._BorderColor = value;
                }
                this._TabControl.Invalidate();
            }
        }

        [Category("Appearance"), DefaultValue(typeof(Color), "Orange")]
        public Color FocusColor
        {
            get { return this._FocusColor; }
            set
            {
                this._FocusColor = value;
                this._TabControl.Invalidate();
            }
        }

        [Category("Appearance"), DefaultValue(typeof(Color), "Black")]
        public Color CloserColorActive
        {
            get { return this._CloserColorActive; }
            set
            {
                this._CloserColorActive = value;
                this._TabControl.Invalidate();
            }
        }

        [Category("Appearance"), DefaultValue(typeof(Color), "DarkGrey")]
        public Color CloserColor
        {
            get { return this._CloserColor; }
            set
            {
                this._CloserColor = value;
                this._TabControl.Invalidate();
            }
        }

        /// <author>Hai Tran</author>
        /// <date>2018-03-27</date>
        /// <summary>
        /// Gets or sets margin of tab items.
        /// </summary>
        [Category("Appearance"), DefaultValue(0)]
        public int TabItemIndent
        {
            get { return this._tabItemIndent; }
            set
            {
                if (this._tabItemIndent != value && value >= 0)
                {
                    this._tabItemIndent = value;

                    UpdateTabItemIndexText();

                    this._TabControl.Invalidate();
                }
            }
        }

        /// <author>Hai Tran</author>
        /// <date>2018-06-08</date>
        /// <summary>
        /// Gets indent text.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public string TabItemIndentText
        {
            get
            {
                return _tabItemIndentText;
            }
        }

        #endregion

        #region Painting

        public void PaintTab(int index, Graphics graphics, bool bSupportSingleLoader)
        {
            using (GraphicsPath tabpath = this.GetTabBorder(index))
            {
                using (Brush fillBrush = this.GetTabBackgroundBrush(index, bSupportSingleLoader))
                {
                    //	Paint the background
                    graphics.FillPath(fillBrush, tabpath);

                    //	Paint a focus indication
                    if (this._TabControl.Focused)
                    {
                        this.DrawTabFocusIndicator(tabpath, index, graphics);
                    }

                    //	Paint the closer
                    this.DrawTabCloser(index, graphics);

                }
            }
        }

        protected virtual void DrawTabCloser(int index, Graphics graphics)
        {
            if (this._ShowTabCloser)
            {
                Rectangle closerRect = this._TabControl.GetTabCloserRect(index);
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (GraphicsPath closerPath = TabStyleProvider.GetCloserPath(closerRect))
                {
                    if (this._TabControl.RectangleToScreen(closerRect).Contains(Control.MousePosition))
                    {
                        using (Pen closerPen = new Pen(this._CloserColorActive))
                        {
                            graphics.DrawPath(closerPen, closerPath);
                        }
                    }
                    else
                    {
                        using (Pen closerPen = new Pen(this._CloserColor))
                        {
                            graphics.DrawPath(closerPen, closerPath);
                        }
                    }

                }
            }
        }

        protected static GraphicsPath GetCloserPath(Rectangle closerRect)
        {
            GraphicsPath closerPath = new GraphicsPath();
            closerPath.AddLine(closerRect.X, closerRect.Y, closerRect.Right, closerRect.Bottom);
            closerPath.CloseFigure();
            closerPath.AddLine(closerRect.Right, closerRect.Y, closerRect.X, closerRect.Bottom);
            closerPath.CloseFigure();

            return closerPath;
        }

        private void DrawTabFocusIndicator(GraphicsPath tabpath, int index, Graphics graphics)
        {
            if (this._FocusTrack && this._TabControl.Focused && index == this._TabControl.SelectedIndex)
            {
                Brush focusBrush = null;
                RectangleF pathRect = tabpath.GetBounds();
                Rectangle focusRect = Rectangle.Empty;
                switch (this._TabControl.Alignment)
                {
                    case TabAlignment.Top:
                        focusRect = new Rectangle((int)pathRect.X, (int)pathRect.Y, (int)pathRect.Width, 4);
                        focusBrush = new LinearGradientBrush(focusRect, this._FocusColor, SystemColors.Window, LinearGradientMode.Vertical);
                        break;
                    case TabAlignment.Bottom:
                        focusRect = new Rectangle((int)pathRect.X, (int)pathRect.Bottom - 4, (int)pathRect.Width, 4);
                        focusBrush = new LinearGradientBrush(focusRect, SystemColors.ControlLight, this._FocusColor, LinearGradientMode.Vertical);
                        break;
                    case TabAlignment.Left:
                        focusRect = new Rectangle((int)pathRect.X, (int)pathRect.Y, 4, (int)pathRect.Height);
                        focusBrush = new LinearGradientBrush(focusRect, this._FocusColor, SystemColors.ControlLight, LinearGradientMode.Horizontal);
                        break;
                    case TabAlignment.Right:
                        focusRect = new Rectangle((int)pathRect.Right - 4, (int)pathRect.Y, 4, (int)pathRect.Height);
                        focusBrush = new LinearGradientBrush(focusRect, SystemColors.ControlLight, this._FocusColor, LinearGradientMode.Horizontal);
                        break;
                }

                //	Ensure the focus stip does not go outside the tab
                Region focusRegion = new Region(focusRect);
                focusRegion.Intersect(tabpath);
                graphics.FillRegion(focusBrush, focusRegion);
                focusRegion.Dispose();
                focusBrush.Dispose();
            }
        }

        #endregion

        #region Background brushes

        private Blend GetBackgroundBlend()
        {
            float[] relativeIntensities = new float[] { 0f, 0.7f, 1f };
            float[] relativePositions = new float[] { 0f, 0.6f, 1f };

            //	Glass look to top aligned tabs
            if (this._TabControl.Alignment == TabAlignment.Top)
            {
                relativeIntensities = new float[] { 0f, 0.3f, 0.8f, 1f };
                relativePositions = new float[] { 0f, 0.5f, 0.51f, 1f };
            }

            Blend blend = new Blend();
            blend.Factors = relativeIntensities;
            blend.Positions = relativePositions;

            return blend;
        }

        public Brush GetPageBackgroundBrush(int index)
        {

            //	Capture the colours dependant on selection state of the tab
            Color light = Color.FromArgb(242, 242, 242);

            if (this._TabControl.SelectedIndex == index)
            {
                light = SystemColors.Window;
            }
            else if (!this._TabControl.TabPages[index].Enabled)
            {
                light = Color.FromArgb(207, 207, 207);
            }
            else if (this._HotTrack && index == this._TabControl.ActiveIndex)
            {
                //	Enable hot tracking
                light = Color.FromArgb(234, 246, 253);
            }

            return new SolidBrush(light);
        }

        #endregion

        #region Tab border and rect

        public GraphicsPath GetTabBorder(int index)
        {

            GraphicsPath path = new GraphicsPath();
            Rectangle tabBounds = this.GetTabRect(index);

            this.AddTabBorder(path, tabBounds);

            path.CloseFigure();
            return path;
        }

        /// <author>Hai Tran</author>
        /// <date>2018-06-08</date>
        /// <summary>
        /// Update indent text.
        /// </summary>
        private void UpdateTabItemIndexText()
        {
            const string SeparatorChar = " ";

            try
            {
                string indentText = string.Empty;
                if (_tabItemIndent > 0)
                {
                    using (Graphics g = this._TabControl.CreateGraphics())
                    {
                        SizeF charSize = g.MeasureString(SeparatorChar, this._TabControl.Font);
                        int numChar = (int)(_tabItemIndent / Math.Floor(charSize.Width)) + 3;
                        for (int i = 0; i < numChar; i++)
                        {
                            indentText += SeparatorChar;
                        }
                    }
                }

                if (indentText != _tabItemIndentText)
                {
                    if (!DesignMode && this._TabControl.TabPages.Count > 0)
                    {
                        if (this._TabControl.TabPages[0].Text.StartsWith(_tabItemIndentText))
                        {
                            this._TabControl.TabPages[0].Text = this._TabControl.TabPages[0].Text.Substring(_tabItemIndentText.Length);
                        }

                        this._TabControl.TabPages[0].Text = indentText + this._TabControl.TabPages[0].Text;
                    }

                    _tabItemIndentText = indentText;
                }
            }
            catch
            {
                _tabItemIndentText = string.Empty;
            }
        }

        /// <author>Hai Tran</author>
        /// <date>2018-06-08</date>
        /// <summary>
        /// Update indent text when font changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabControl_FontChanged(object sender, EventArgs e)
        {
            UpdateTabItemIndexText();
        }

        #endregion

    }
}
