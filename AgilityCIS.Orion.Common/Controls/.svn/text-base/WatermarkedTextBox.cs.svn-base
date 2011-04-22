// This code is released under the Creative Commons license
// visit http://creativecommons.org/licenses/by/3.0/us for more information
// Feel free to use this code in your own projects with propert attribution
namespace AgilityCIS.Orion.Common
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Data;
    using System.ComponentModel;
    using System.Windows.Interactivity;
    using AgilityCIS.Orion.CustomBehaviors;

    /// <summary>
    /// A TextBox control with a watermark
    /// </summary>
    [StyleTypedProperty(Property = "TextRemoverStyle", StyleTargetType = typeof(Button)),
     StyleTypedProperty(Property = "WatermarkStyle", StyleTargetType = typeof(TextBlock)),
     TemplatePart(Name = "TextRemover", Type = typeof(Button)),
     TemplatePart(Name = "Watermark", Type = typeof(TextBlock)),
     TemplateVisualState(Name = "WatermarkVisible", GroupName = "WatermarkStates"),
     TemplateVisualState(Name = "WatermarkHidden", GroupName = "WatermarkStates"),
     TemplateVisualState(Name = "TextRemoverVisible", GroupName = "TextRemoverStates"),
     TemplateVisualState(Name = "TextRemoverHidden", GroupName = "TextRemoverStates")]
    public class WatermarkedTextBox : TextBox
    {
		#region Fields (8) 

        private bool isFocused;
        /// <summary>
        /// Immediate text update dependency property
        /// </summary>
        public static readonly DependencyProperty IsUpdateImmediateProperty = DependencyProperty.Register(
            "IsUpdateImmediate",
            typeof(bool),
            typeof(WatermarkedTextBox),
            new PropertyMetadata(false));
        private Button textRemoverButton;
        /// <summary>
        /// Text remover style
        /// </summary>
        public static readonly DependencyProperty TextRemoverStyleProperty = DependencyProperty.Register(
            "TextRemoverStyle",
            typeof(Style),
            typeof(WatermarkedTextBox),
            new PropertyMetadata(null));
        /// <summary>
        /// Text remover tool tip dependency property
        /// </summary>
        public static readonly DependencyProperty TextRemoverToolTipProperty = DependencyProperty.Register(
            "TextRemoverToolTip",
            typeof(string),
            typeof(WatermarkedTextBox),
            new PropertyMetadata("Clear the text"));
        /// <summary>
        /// Watermark foreground dependency property
        /// </summary>
        public static readonly DependencyProperty WatermarkForegroundProperty = DependencyProperty.Register(
            "WatermarkForeground",
            typeof(Brush),
            typeof(WatermarkedTextBox),
            new PropertyMetadata(new SolidColorBrush(Color.FromArgb(255, 134, 134, 134))));
        /// <summary>
        /// Watermark text dependency property
        /// </summary>
        public static readonly DependencyProperty WatermarkProperty = DependencyProperty.Register(
            "Watermark",
            typeof(string),
            typeof(WatermarkedTextBox),
            new PropertyMetadata("Enter text here"));
        /// <summary>
        /// Watermark style
        /// </summary>
        public static readonly DependencyProperty WatermarkStyleProperty = DependencyProperty.Register(
            "WatermarkStyle",
            typeof(Style),
            typeof(WatermarkedTextBox),
            new PropertyMetadata(null));

		#endregion Fields 

		#region Constructors (1) 

        /// <summary>
        /// Initializes a new instance of the <see cref="WatermarkedTextBox"/> class.
        /// </summary>
        public WatermarkedTextBox()
        {
            DefaultStyleKey = typeof(WatermarkedTextBox);
            this.GotFocus += this.TextBoxGotFocus;
            this.LostFocus += this.TextBoxLostFocus;
            this.TextChanged += this.TextBoxTextChanged;
           // var behaviors = Interaction.GetBehaviors(button2);
            //behaviors.Add(new OnHoverSlideDownBehavior());
           // button2.SetValue(Interaction.BehaviorsProperty, behaviors);
            var behaviors = Interaction.GetBehaviors(this);
            behaviors.Add(new RightClickTrigger());
            this.SetValue(Interaction.BehaviorsProperty, behaviors);
        }

		#endregion Constructors 

		#region Properties (6) 

        /// <summary>
        /// Gets or sets a value indicating whether bindings on the Text property updates
        /// as soon as the text change.
        /// </summary>
        /// <value>If true then TextChanges fires whenever the text changes, else only on LostFocus</value>
        [Category("Watermark")]
        [Description("Gets or sets a value indicating whether the binding source is updated immediately as text changes, or on LostFocus")]
        public bool IsUpdateImmediate
        {
            get { return (bool)GetValue(IsUpdateImmediateProperty); }
            set { SetValue(IsUpdateImmediateProperty, value); }
        }

        /// <summary>
        /// Gets or sets the text remover style.
        /// </summary>
        /// <value>The text remover style.</value>
        [Category("Watermark")]
        [Description("Gets or sets the style for the remove-text button")]
        public Style TextRemoverStyle
        {
            get { return (Style)GetValue(TextRemoverStyleProperty); }
            set { SetValue(TextRemoverStyleProperty, value); }
        }

        /// <summary>
        /// Gets or sets the text remover tool tip.
        /// </summary>
        /// <value>The text remover tool tip.</value>
        [Category("Watermark")]
        [Description("Gets or sets the text for the watermark")]
        public string TextRemoverToolTip
        {
            get { return (string) GetValue(TextRemoverToolTipProperty); }
            set { SetValue(TextRemoverToolTipProperty, value); }
        }

        /// <summary>
        /// Gets or sets the watermark.
        /// </summary>
        /// <value>The watermark.</value>
        [Description("Gets or sets the watermark")]
        [Category("Watermark")]
        public string Watermark
        {
            get { return (string)GetValue(WatermarkProperty); }
            set { SetValue(WatermarkProperty, value); }
        }

        /// <summary>
        /// Gets or sets the watermark foreground.
        /// </summary>
        /// <value>The watermark foreground.</value>
        [Description("Gets or sets the foreground brush for the watermark")]
        public Brush WatermarkForeground
        {
            get { return (Brush) GetValue(WatermarkForegroundProperty); }
            set { SetValue(WatermarkForegroundProperty, value); }
        }

        /// <summary>
        /// Gets or sets the watermark style.
        /// </summary>
        /// <value>The watermark style.</value>
        [Description("Gets or sets the watermark style")]
        [Category("Watermark")]
        public Style WatermarkStyle
        {
            get { return (Style)GetValue(WatermarkStyleProperty); }
            set { SetValue(WatermarkStyleProperty, value); }
        }

		#endregion Properties 

		#region Methods (6) 

		// Public Methods (1) 

        /// <summary>
        /// When overridden in a derived class, is invoked whenever application code or internal processes (such as a rebuilding layout pass) call <see cref="M:System.Windows.Controls.Control.ApplyTemplate"/>.
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            
            // remove old button handler
            if (null != this.textRemoverButton)
            {
                this.textRemoverButton.Click -= this.TextRemoverClick;
            }

            // add new button handler
            this.textRemoverButton = GetTemplateChild("TextRemover") as Button;
            if (null != this.textRemoverButton)
            {
                this.textRemoverButton.Click += this.TextRemoverClick;
            }

            this.UpdateState();
        }
		// Private Methods (5) 

        private void TextBoxGotFocus(object sender, RoutedEventArgs e)
        {
            VisualStateManager.GoToState(this, "WatermarkHidden", false);

            this.isFocused = true;
            this.UpdateState();
        }

        private void TextBoxLostFocus(object sender, RoutedEventArgs e)
        {
            this.isFocused = false;
            this.UpdateState();
        }

        private void TextBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            this.UpdateState();

            if (!this.IsUpdateImmediate)
            {
                return;
            }

            BindingExpression binding = this.GetBindingExpression(TextBox.TextProperty);
            if (null != binding)
            {
                binding.UpdateSource();
            }
        }

        private void TextRemoverClick(object sender, RoutedEventArgs e)
        {
            this.Text = string.Empty;
            this.Focus();
        }

        private void UpdateState()
        {
            if (string.IsNullOrEmpty(this.Text))
            {
                VisualStateManager.GoToState(this, "TextRemoverHidden", true);
                if (!this.isFocused)
                {
                    VisualStateManager.GoToState(this, "WatermarkVisible", true);
                }
            }
            else
            {
                VisualStateManager.GoToState(this, "TextRemoverVisible", true);
                VisualStateManager.GoToState(this, "WatermarkHidden", false);
            }
        }

		#endregion Methods 
    }
}
