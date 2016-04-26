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

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Sokkelopeli
{
    public sealed partial class Player : UserControl
    {
        // location
        public double LocationX { get; set; }
        public double LocationY { get; set; }
      
        //Speed
        private readonly double MaxSpeed = 100;
        private readonly double Accelerate = 10;
        private double speed;

        public Player()
        {
            this.InitializeComponent();

            Width = 20;
            Height = 20;
           
        }

        //Player movement
        public void moveUp()
            {
            speed += Accelerate;
            if (speed > MaxSpeed) speed = MaxSpeed;
            LocationY--;
        }

        public void moveLeft()
        {
            speed += Accelerate;
            if (speed > MaxSpeed) speed = MaxSpeed;
            LocationX--;
        }

        public void moveRight()
        {
            speed += Accelerate;
            if (speed > MaxSpeed) speed = MaxSpeed;
            LocationX++;
        }

        public void moveDown()
        {
            speed += Accelerate;
            if (speed > MaxSpeed) speed = MaxSpeed;
            LocationY++;
        }



        /// <summary>
        /// Update player position
        /// </summary>
        public void UpdateLocation()
        {
            SetValue(Canvas.LeftProperty, LocationX);
            SetValue(Canvas.TopProperty, LocationY);
        }
    }
}

