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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Pulse
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        private void StopWatch(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(StopWatch));
        }
        private void Timer(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Timer));
        }
        private void Injuries(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Injuries));
        }

        private void Workout(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Workout));
        }
    }
}
