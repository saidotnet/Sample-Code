using System.Windows.Input;
using System.Windows.Interactivity;
using System.Windows.Controls.Primitives;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows;

namespace AgilityCIS.Orion.Common
{
    public class DefaultEnterButtonTrigger : TargetedTriggerAction<ButtonBase>
    {
		#region Properties (2) 

        /// <summary>
        /// Gets or sets the peer.
        /// </summary>
        /// <value>The peer.</value>
        private AutomationPeer _peer { get; set; }

        /// <summary>
        /// Gets or sets the target button
        /// </summary>
        private ButtonBase _targetedButton { get; set; }

		#endregion Properties 

		#region Methods (3) 

		// Protected Methods (3) 

        /// <summary>
        /// Invokes the targeted Button when Enter key is pressed inside Control.
        /// </summary>
        /// <param name="parameter">KeyEventArgs with Enter key</param>
        protected override void Invoke(object parameter)
        {           
            KeyEventArgs keyEventArgs = parameter as KeyEventArgs;
            if (null != keyEventArgs && keyEventArgs.Key == Key.Enter)
            {
                if (_targetedButton != null)
                {
                    _targetedButton.Focus();
                }

                if (null != _peer && _peer.IsEnabled())
                {

                    IInvokeProvider invokeProvider = _peer.GetPattern(PatternInterface.Invoke) as IInvokeProvider;

                    invokeProvider.Invoke();

                }
            }
        }

        /// <summary>
        /// Called after the TargetedTriggerAction is attached to an AssociatedObject.
        /// </summary>
        /// <remarks>Override this to hook up functionality to the AssociatedObject.</remarks>
        protected override void OnAttached()
        {

            base.OnAttached();

            _targetedButton = this.Target;           

            if (null == _targetedButton)
            {

                return;

            }



            // set peer

            this._peer = FrameworkElementAutomationPeer.FromElement(_targetedButton);

            if (this._peer == null)
            {

                this._peer = FrameworkElementAutomationPeer.CreatePeerForElement(_targetedButton);

            }

        }

        /// <summary>
        /// Called after targeted Button change.
        /// </summary>
        /// <remarks>Override this to hook up functionality to the new targeted Button.</remarks>
        protected override void OnTargetChanged(ButtonBase oldTarget, ButtonBase newTarget)
        {

            base.OnTargetChanged(oldTarget, newTarget);

            _targetedButton = newTarget;

            if (null == _targetedButton)
            {

                return;

            }



            // set peer

            this._peer = FrameworkElementAutomationPeer.FromElement(_targetedButton);

            if (this._peer == null)
            {

                this._peer = FrameworkElementAutomationPeer.CreatePeerForElement(_targetedButton);

            }

        }

		#endregion Methods 
    }
}
