using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Sokkelopeli
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Wall wall;

        private Floor floor;

        private Skull skull;

        private Player player;

        private End end;

        private double GridWidth;
        private double GridHeight;

        private bool UpPressed;
        private bool LeftPressed;
        private bool RightPressed;
        private bool DownPressed;

        private DispatcherTimer timer;
        public MainPage()
        {
            this.InitializeComponent();

            // change the default startup mode
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
            // specify the size width:800, height:600 window size
            ApplicationView.PreferredLaunchViewSize = new Size(800, 600);



            // key listeners
            Window.Current.CoreWindow.KeyDown += CoreWindow_KeyDown;
            Window.Current.CoreWindow.KeyUp += CoreWindow_KeyUp;

            // game loop 
            timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1000 / 60);
            timer.Start();


            GridWidth = myGrid.Width;
            GridHeight = myGrid.Height;

            // add butterfly
            player = new Player
            {
                LocationX = 242.5,
                LocationY = 480
            };
            MyCanvas.Children.Add(player);

        }

        private void CoreWindow_KeyDown(CoreWindow sender, Windows.UI.Core.KeyEventArgs args)
        {
            switch (args.VirtualKey)
            {
                case VirtualKey.Up:
                    UpPressed = true;
                    break;
                case VirtualKey.Left:
                    LeftPressed = true;
                    break;
                case VirtualKey.Right:
                    RightPressed = true;
                    break;
                case VirtualKey.Down:
                    DownPressed = true;
                    break;
                default:
                    break;
            }
        }

        private void CoreWindow_KeyUp(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.KeyEventArgs args)
        {
            switch (args.VirtualKey)
            {
                case VirtualKey.Up:
                    UpPressed = false;
                    break;
                case VirtualKey.Left:
                    LeftPressed = false;
                    break;
                case VirtualKey.Right:
                    RightPressed = false;
                    break;
                case VirtualKey.Down:
                    DownPressed = false;
                    break;
                default:
                    break;
            }
        }



        private void Timer_Tick(object sender, object e)
        {

            if (UpPressed) player.moveUp();
            if (LeftPressed) player.moveLeft();
            if (RightPressed) player.moveRight();
            if (DownPressed) player.moveDown();
            player.UpdateLocation();

            /* CheckCollision(); */

           

        }
        /*   private void CheckCollision()          En Saanut Collisioneita toimimaan.
           {
               // get butterfly and flower rects
               Rect r1 = new Rect(player.LocationX, player.LocationY, player.ActualWidth, player.ActualHeight);
               Rect r2 = new Rect(wall.Width, wall.ActualHeight);
               Rect r3 = new Rect(skull)
               // does thoes intersects
               r1.Intersect(r2); */

        private void resetPosition()
        {
            player.LocationX = 242.5;
            player.LocationY = 480;
        }

        }
    }

