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
    public sealed partial class StopWatch : Page
    {

        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();
        int lapCounter = 0;
        DispatcherTimer dispatch;
        private TimeSpan SpanTime;
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


        public StopWatch()
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


        private void start(object sender, RoutedEventArgs e)
        {
            dispatch = new DispatcherTimer();
            if (!dispatch.IsEnabled)
            {
                startBtn.Visibility = Visibility.Collapsed;
                stopBtn.Visibility = Visibility.Visible;
                lapBtn.IsEnabled = true;
                resetBtn.IsEnabled = false;
                dispatch.Tick += dispatch_tick;
                dispatch.Interval = new TimeSpan(0, 0, 1);
                dispatch.Start();
            }
        }
        void dispatch_tick(object sender, object e)
        {
            SpanTime = SpanTime.Add(dispatch.Interval);
            timeText.DataContext = SpanTime;
        }


        private void stop(object sender, RoutedEventArgs e)
        {
            dispatch.Stop();
            startBtn.Visibility = Visibility.Visible;
            stopBtn.Visibility = Visibility.Collapsed;
            resetBtn.IsEnabled = true;
            stText.Text = "Resume";
           
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

        private void reset(object sender, TappedRoutedEventArgs e)
        {
            //time = 1;
            resetBtn.IsEnabled = false;
            timeText.DataContext = "00:00:00";
            SpanTime = new TimeSpan();
            stText.Text = "Start";
            lapBtn.IsEnabled = false;
            tb1.Text = "";
            tb2.Text = "";
            tb3.Text = "";
            tb4.Text = "";
            tb5.Text = "";
            lapCounter = 0;
        }

        private void lap(object sender, TappedRoutedEventArgs e)
        {
            lapCounter++;
            if (lapCounter == 1)
            {
                tb1.Text = "Lap 1: " + SpanTime.ToString();
            }
            if (lapCounter == 2)
            {
                tb2.Text = "Lap 2: " + SpanTime.ToString();
            }
            if (lapCounter == 3)
            {
                tb3.Text = "Lap 3: " + SpanTime.ToString();
            }
            if (lapCounter == 4)
            {
                tb4.Text = "Lap 4: " + SpanTime.ToString();
            }
            if (lapCounter == 5)
            {
                tb5.Text = "Lap 5: " + SpanTime.ToString();
            }

        }

        
    }
}
