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
    public sealed partial class Injuries : Page
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


        public Injuries()
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

        private void SpAnk(object sender, TappedRoutedEventArgs e)
        {
            injLoad(6);
            this.Frame.Navigate(typeof(Injury));
        }

        private void Ham(object sender, TappedRoutedEventArgs e)
        {
            injLoad(2);
            this.Frame.Navigate(typeof(Injury));
        }

        private void Shin(object sender, TappedRoutedEventArgs e)
        {
            injLoad(5);
            this.Frame.Navigate(typeof(Injury));
        }

        private void acl(object sender, TappedRoutedEventArgs e)
        {
            injLoad(3);
            this.Frame.Navigate(typeof(Injury));
        }

        private void patel(object sender, TappedRoutedEventArgs e)
        {
            injLoad(4);
            this.Frame.Navigate(typeof(Injury));
        }

        private void tennis(object sender, TappedRoutedEventArgs e)
        {
            injLoad(1);
            this.Frame.Navigate(typeof(Injury));
        }
        private void injLoad(int flag)
        {
            if (flag == 1)
            {
                Globals.injury = "Tennis Elbow";
                Globals.injSym = "\n>Pain slowly increasing around the outside of the elbow. Less often, pain may develop suddenly.\n>Pain is worse when shaking hands or squeezing objects.\n>Pain is made worse by stabilizing or moving the wrist with force.\n\nExamples include lifting, using tools, opening jars, or even handling simple utensils such as a toothbrush or knife and fork.";
                Globals.injT = "\n>Icing the elbow to reduce pain and swelling. Experts recommend doing it for 20 to 30 minutes every 3 to 4 hours for 2 to 3 days or until the pain is gone.\n>Using an elbow strap to protect the injured tendon from further strain.\n>Taking nonsteroidal anti-inflammatory (NSAIDs), such as ibuprofen, naproxen, or aspirin, to help with pain and swelling. However, these drugs can cause side effects, such as bleeding and ulcers. You should only use them occasionally, unless your doctor says otherwise, since they may delay healing.\n>Performing range of motion exercises to reduce stiffness and increase flexibility. Your doctor may recommend that you do them three to five times a day.\n>Getting physical therapy to strengthen and stretch the muscles.\n>Having injections of steroids or painkillers to temporarily ease some of the swelling and pain around the joint. Studies suggest that steroid injections don't help in the long term.";
                Globals.injImage = "/Assets/elbow.png";
            }
            if (flag == 2)
            {
                Globals.injury = "Hamstring Sprain";
                Globals.injSym = "\n>Sudden and severe pain during exercise, along with a snapping or popping feeling.\n>Pain in the back of the thigh and lower buttock when walking, straightening the leg, or bending over.\n>Tenderness.\n>Bruising";
                Globals.injT = "\n>Rest the leg. Avoid putting weight on the leg as best you can. If the pain is severe, you may need crutches until it goes away. Ask your doctor or physical therapist if they're needed.\n>Ice your leg to reduce pain and swelling. Do it for 20-30 minutes every three to four hours for two to three days, or until the pain is gone.\n>Compress your leg. Use an elastic bandage around the leg to keep down swelling.\n>Elevate your leg on a pillow when you're sitting or lying down.\n>Take anti-inflammatory painkillers. Non-steroidal anti-inflammatory drugs (NSAIDs), like ibuprofen (Advil, Motrin) or naproxen (Aleve, Naprosyn) will help with pain and swelling. However, these drugs may have side effects, such as an increased risk of bleeding and ulcers. They should be used only short term, unless your doctor specifically says otherwise.\n>Practice stretching and strengthening exercises if your doctor recommends them. Strengthening your hamstrings is the best protection against hamstring strain.";
                Globals.injImage = "/Assets/ham.png";
            }
            if (flag == 3)
            {
                Globals.injury = "Knee injury: ACL tear";
                Globals.injSym = "\n>Pain, often sudden and severe.\n>A loud pop or snap during the injury.\n>Swelling.\n>A feeling of looseness in the joint.\n>Inability to put weight on the point without pain";
                Globals.injT = "\n>Rest the knee. Avoid putting excess weight on your knee if it's painful to do so. You may need to use crutches for a time.\n>Ice your knee to reduce pain and swelling. Do it for 20-30 minutes every 3-4 hours for 2-3 days, or until the pain and swelling is gone.\n>Compress your knee. Use an elastic bandage, straps, or sleeves on your knee to control swelling.\n>Elevate your knee on a pillow when you're sitting or lying down.\n>Wear a knee brace to stabilize the knee and protect it from further injury.\n>Take anti-inflammatory painkillers. Non-steroidal anti-inflammatory drugs (NSAIDs), like Advil, Aleve, or Motrin, will help with pain and swelling. However, these drugs can have side effects and they should be used only occasionally, unless your doctor specifically says otherwise.\n>Practice stretching and strengthening exercises if your doctor recommends them. Stretching and strengthening exercises can help reduce stress to the knee if performed in a pain-free manner. Ask your doctor to recommend a physical therapist for guidance.";
                Globals.injImage = "/Assets/knee.png";
            }
            if (flag == 4)
            {
                Globals.injury = "Knee injury: Patellofemoral syndrome";
                Globals.injSym = "\n>Pain around the knee. The pain is felt at the front of the knee, around or behind the kneecap. Often, the exact site of the pain cannot be pinpointed; instead the pain is felt vaguely at the front of the knee.\n>The pain comes and goes. It is typically worse when going up or down stairs or with certain sports. Also, it may be brought on by sitting still for long periods. For example, after going to the cinema or a long drive.\n>There may be a grating or grinding feeling or noise when the knee moves. This is called crepitus.\n>Sometimes there is fullness or swelling around the patella.";
                Globals.injT = "\n>Avoid strenuous use of the knee - until the pain eases. Symptoms usually improve in time if the knee is not overused. Aim to keep fit, but to reduce the activities which cause the pain.\n>Painkillers - paracetamol and/or anti-inflammatory painkillers such as ibuprofen. Anti-inflammatory painkillers are often helpful for this type of pain.\n>In the longer term, treatment aims to treat some of the underlying causes - for example, by strengthening muscles and helping with foot problems:\n>Physiotherapy - improving the strength of the muscles around the knee will ease the stress on the knee. Also, specific exercises may help to correct problems with alignment and muscle balance around the knee. For example, you may be taught to do exercises which strengthen the inner side of the quadriceps muscle. You may also be taught exercises to stretch tight ligaments. The physiotherapist can give advice tailored to your individual situation.\n>Suitable footwear - for example, arch supports if you have flat feet; suitable shoes if you are running; springy soles which reduce strain when walking.";
                Globals.injImage = "/Assets/knee2.png";
            }
            if (flag == 5)
            {
                Globals.injury = "Shin Splints";
                Globals.injSym = "\n>Pain along the inner part of the lower leg.\n>Tenderness or soreness along the inner part of the lower leg.\n>Moderate swelling in the lower leg.\n>Feet may feel numb and weak, because swollen muscles irritate the nerves.";
                Globals.injT = "\n>Rest your body. It needs time to heal.\n>Ice your shin to ease pain and swelling. Do it for 20-30 minutes every 3 to 4 hours for 2 to 3 days, or until the pain is gone.\n>Take anti-inflammatory painkillers. Nonsteroidal anti-inflammatory drugs (NSAIDs), like ibuprofen, naproxen, or aspirin, will help with pain and swelling. These drugs can have side effects, though, like a greater chance of bleeding and ulcers. They should be used only occasionally unless your doctor says otherwise.\n>Use orthotics for your shoes. Shoe inserts -- which can be custom-made or bought off the shelf -- may help with arches that collapse or flatten when you stand up.\n>Do range-of-motion exercises, if your doctor recommends them.\n>Use a neoprene sleeve to support and warm your leg.\n>Go to physical therapy to identify and treat issues in your legs or running mechanics that may be causing shin splints. A therapist can also help ease the pain and guide your return to sport.";
                Globals.injImage = "/Assets/shin.png";
            }
            if (flag == 6)
            {
                Globals.injury = "Ankle Sprain";
                Globals.injSym = "\n>Ankle pain, which can be mild to severe.\n>Swelling.\n>A popping sound during the injury.\n>Difficulty moving the ankle.\n>Bruising.\n>Instability of the ankle (in severe sprains).\n\nAnkle sprains are divided into three grades. People with Grade I sprains may be able to walk without pain or a limp. But those with Grade III sprains are often in such pain that they can’t walk at all.";
                Globals.injT = "\n>Rest the ankle. Avoid putting weight on your ankle as best you can. If the pain is severe, you may need crutches until it goes away.\n>Ice your ankle to reduce pain and swelling. Do it for 15-20 minutes every two to three hours for two days, or until the swelling is improved. After that, ice it once a day until you have no other symptoms.\n>Compress your ankle. Use an elastic bandage to keep down swelling. Start wrapping at your toes and work back towards your leg.\n>Elevate your ankle on a pillow when you’re sitting or lying down.\n>Use braces or ankle stirrups to give your ankle support.\n>Take anti-inflammatory painkillers. Nonsteroidal anti-inflammatory drugs (NSAIDs), like ibuprofen, naproxen, or aspirin will help with pain and swelling. However, these drugs have side effects, like stomach upset and an increased risk of bleeding and ulcers. They are best taken with food, and they should be used only occasionally, unless your doctor specifically says otherwise.\n>Practice stretching and strengthening exercises if your doctor recommends them.";
                Globals.injImage = "/Assets/ankle.png";
            }
        }
    }
}
