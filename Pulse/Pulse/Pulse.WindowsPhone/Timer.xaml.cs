using Pulse.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace Pulse
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Timer : Page
    {
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();
        int sec = 0, min = 0, hr = 0;
        bool err = false;
        DispatcherTimer dispatch;
        private TimeSpan SpanTime;
        
        public Timer()
        {
            this.InitializeComponent();

            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += this.NavigationHelper_LoadState;
            this.navigationHelper.SaveState += this.NavigationHelper_SaveState;
            dispatch = new DispatcherTimer();
        }

        private void start(object sender, RoutedEventArgs e)
        {
            stopBtn.IsEnabled = false;
            if (err.Equals(true))
            {
                Error.Visibility = Visibility.Collapsed;
                time.Visibility = Visibility.Visible;
                stText.Text = "Start";
                err = false;
                hh.Text = "00";
                mm.Text = "00";
                ss.Text = "00";
                enableTimerInput(false);
            }
            else
            {
                enableTimerInput(true);
                dispatch = new DispatcherTimer();
                int n;
                bool isNumericH = int.TryParse(hh.Text.ToString(), out n);
                bool isNumericM = int.TryParse(mm.Text.ToString(), out n);
                bool isNumericS = int.TryParse(ss.Text.ToString(), out n);
                if (isNumericH == false || isNumericM == false || isNumericS == false)
                {
                    Error.Visibility = Visibility.Visible;
                    time.Visibility = Visibility.Collapsed;
                    stText.Text = "Ok";
                    err = true;
                }

                else
                {
                    if (!dispatch.IsEnabled)
                    {
                        if (!(Int32.Parse(hh.Text.ToString()) <= 0))
                            hr = Int32.Parse(hh.Text.ToString());
                        if (!(Int32.Parse(mm.Text.ToString()) <= 0))
                            min = Int32.Parse(mm.Text.ToString());
                        if (!(Int32.Parse(ss.Text.ToString()) <= 0))
                            sec = Int32.Parse(ss.Text.ToString());

                        dispatch.Tick += dispatch_tick;
                        dispatch.Interval = new TimeSpan(0, 0, 1);
                        dispatch.Start();
                        pauseBtn.Visibility = Visibility.Visible;
                        startBtn.Visibility = Visibility.Collapsed;
                    }
                }
            }
        }
        void dispatch_tick(object sender, object e)
        {
            sec--;
            if (sec <= 0)
            {
                {
                    if (!(min <= 0))
                    {
                        sec = 59;
                        min--;
                    }
                }
                if (min <= 0)
                {
                    if (!(hr <= 0))
                    {
                        min = 59;
                        hr--;
                    }
                }


            }
            if (hr <= 0 && min <= 0 && sec <= 0)
            {
                alarm.Play();
                finish.Visibility = Visibility.Visible;
                dispatch.Stop();
                pauseBtn.Visibility = Visibility.Collapsed;
                startBtn.Visibility = Visibility.Visible;
                stopBtn.IsEnabled = true;
                startBtn.IsEnabled = false;
                time.Visibility = Visibility.Collapsed;
                sec = 0;

            }
            SpanTime = SpanTime.Add(dispatch.Interval);
            if (sec.ToString().Length > 1)
                ss.Text = sec.ToString();
            else
                ss.Text = "0" + sec.ToString();
            if (min.ToString().Length > 1)
                mm.Text = min.ToString();
            else
                mm.Text = "0" + min.ToString();
            if (hr.ToString().Length > 1)
                hh.Text = hr.ToString();
            else
                hh.Text = "0" + hr.ToString();

        }

        private void stop(object sender, RoutedEventArgs e)
        {
            dispatch.Stop();
            alarm.Stop();
            SpanTime = new TimeSpan();
            stopBtn.IsEnabled = false;
            startBtn.Visibility = Visibility.Visible;
            startBtn.IsEnabled = true;
            pauseBtn.Visibility = Visibility.Collapsed;
            finish.Visibility = Visibility.Collapsed;
            time.Visibility = Visibility.Visible;
            stText.Text = "Start";
            hh.Text = "00";
            mm.Text = "00";
            ss.Text = "00";
            sec = 0;
            hr = 0;
            min = 0;
            enableTimerInput(false);
        }
        private void pause(object sender, TappedRoutedEventArgs e)
        {
            dispatch.Stop();
            stopBtn.IsEnabled = true;
            pauseBtn.Visibility = Visibility.Collapsed;
            startBtn.Visibility = Visibility.Visible;
            stText.Text = "Resume";
        }
        private void enableTimerInput(bool b)
        {
            hh.IsReadOnly = b;
            mm.IsReadOnly = b;
            ss.IsReadOnly = b;
        }


        /// <summary>
        /// Gets the <see cref="NavigationHelper"/> associated with this <see cref="Page"/>.
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }

        /// <summary>
        /// Gets the view model for this <see cref="Page"/>.
        /// This can be changed to a strongly typed view model.
        /// </summary>
        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="sender">
        /// The source of the event; typically <see cref="NavigationHelper"/>
        /// </param>
        /// <param name="e">Event data that provides both the navigation parameter passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested and
        /// a dictionary of state preserved by this page during an earlier
        /// session.  The state will be null the first time a page is visited.</param>
        private void NavigationHelper_LoadState(object sender, LoadStateEventArgs e)
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
        private void NavigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
        }

        #region NavigationHelper registration

        /// <summary>
        /// The methods provided in this section are simply used to allow
        /// NavigationHelper to respond to the page's navigation methods.
        /// <para>
        /// Page specific logic should be placed in event handlers for the  
        /// <see cref="NavigationHelper.LoadState"/>
        /// and <see cref="NavigationHelper.SaveState"/>.
        /// The navigation parameter is available in the LoadState method 
        /// in addition to page state preserved during an earlier session.
        /// </para>
        /// </summary>
        /// <param name="e">Provides data for navigation methods and event
        /// handlers that cannot cancel the navigation request.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedFrom(e);
        }

        #endregion
    }
}
