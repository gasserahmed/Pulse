using Pulse.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace Pulse
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class Workout : Page
    {

        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        /// <summary>
        /// This can be changed to a strongly typed view model.
        /// </summary>
        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        /// <summary>
        /// NavigationHelper is used on each page to aid in navigation and 
        /// process lifetime management
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }


        public Workout()
        {
            this.InitializeComponent();
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += navigationHelper_LoadState;
            this.navigationHelper.SaveState += navigationHelper_SaveState;
        }

        /// <summary>
        /// Populates the page with content passed during navigation. Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="sender">
        /// The source of the event; typically <see cref="NavigationHelper"/>
        /// </param>
        /// <param name="e">Event data that provides both the navigation parameter passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested and
        /// a dictionary of state preserved by this page during an earlier
        /// session. The state will be null the first time a page is visited.</param>
        private void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="sender">The source of the event; typically <see cref="NavigationHelper"/></param>
        /// <param name="e">Event data that provides an empty dictionary to be populated with
        /// serializable state.</param>
        private void navigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
        }

        #region NavigationHelper registration

        /// The methods provided in this section are simply used to allow
        /// NavigationHelper to respond to the page's navigation methods.
        /// 
        /// Page specific logic should be placed in event handlers for the  
        /// <see cref="GridCS.Common.NavigationHelper.LoadState"/>
        /// and <see cref="GridCS.Common.NavigationHelper.SaveState"/>.
        /// The navigation parameter is available in the LoadState method 
        /// in addition to page state preserved during an earlier session.

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedFrom(e);
        }

        #endregion

        private void one(object sender, TappedRoutedEventArgs e)
        {
            workoutLoad(6);
            this.Frame.Navigate(typeof(WorkoutPage));
        }

        private void wakeup(object sender, TappedRoutedEventArgs e)
        {
            workoutLoad(2);
            this.Frame.Navigate(typeof(WorkoutPage));
        }

        private void wolverine(object sender, TappedRoutedEventArgs e)
        {
            workoutLoad(5);
            this.Frame.Navigate(typeof(WorkoutPage));
        }

        private void twoMin(object sender, TappedRoutedEventArgs e)
        {
            workoutLoad(4);
            this.Frame.Navigate(typeof(WorkoutPage));
        }

        private void woman(object sender, TappedRoutedEventArgs e)
        {
            workoutLoad(3);
            this.Frame.Navigate(typeof(WorkoutPage));
        }

        private void three(object sender, TappedRoutedEventArgs e)
        {
            workoutLoad(1);
            this.Frame.Navigate(typeof(WorkoutPage));
        }
        private void workoutLoad(int flag)
        {
            if (flag == 1)
            {
                Globals.workout = "300 Workout";
                Globals.workoutImage = "/Assets/300W.png";
            }
            if (flag == 2)
            {
                Globals.workout = "Wake Up Workout";
                Globals.workoutImage = "/Assets/WU.png";
            }
            if (flag == 3)
            {
                Globals.workout = "Wonder Woman Workout";
                Globals.workoutImage = "/Assets/WW.png";
            }
            if (flag == 4)
            {
                Globals.workout = "2 Minute Workout";
                Globals.workoutImage = "/Assets/2min.png";
            }
            if (flag == 5)
            {
                Globals.workout = "Wolverine Workout";
                Globals.workoutImage = "/Assets/wolvW.png";
            }
            if (flag == 6)
            {
                Globals.workout = "1 & 1 Workout";
                Globals.workoutImage = "/Assets/11.png";
            }
        }
    }
}
