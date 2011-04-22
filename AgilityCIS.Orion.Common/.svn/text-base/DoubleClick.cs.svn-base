using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interactivity;
using System.Windows.Threading;

namespace AgilityCIS.Orion.Common
{
    public class DoubleClickTrigger : TriggerBase<UIElement>
    {


		#region?Fields?(1)?

        private readonly DispatcherTimer timer;

		#endregion?Fields?


		#region?Constructors?(1)?

        public DoubleClickTrigger()
        {

            timer = new DispatcherTimer

            {

                Interval = new TimeSpan(0, 0, 0, 0, 300)

            };



            timer.Tick += OnTimerTick;

        }

		#endregion?Constructors?


		#region?Methods?(4)?

		//?Protected?Methods?(2)?

        protected override void OnAttached()
        {

            base.OnAttached();



            AssociatedObject.MouseLeftButtonDown += OnMouseButtonDown;

        }

        protected override void OnDetaching()
        {

            base.OnDetaching();



            AssociatedObject.MouseLeftButtonDown -= OnMouseButtonDown;



            if (timer.IsEnabled)

                timer.Stop();

        }
		//?Private?Methods?(2)?

        private void OnMouseButtonDown(object sender, MouseButtonEventArgs e)
        {

            if (!timer.IsEnabled)
            {

                timer.Start();

                return;

            }



            timer.Stop();



            InvokeActions(null);

        }

        private void OnTimerTick(object sender, EventArgs e)
        {

            timer.Stop();

        }

		#endregion?Methods?
    }

}
