using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace AgWindow_CustomAnimation {
    public partial class MainPage : UserControl {
        public MainPage() {
            InitializeComponent();
            popupWindow.ShowAnimation = CreateAnimation(true);
            popupWindow.HideAnimation = CreateAnimation(false);
        }
        private void showPopup(object sender, RoutedEventArgs e) {
            popupWindow.Show();
        }
        private void popupWindow_Closed(object sender, EventArgs e) {
            popupWindow.ShowAnimation.Stop();
            popupWindow.HideAnimation.Stop();
        }
        private void closePopup(object sender, RoutedEventArgs e) {
            popupWindow.Hide();
        }
        Storyboard CreateAnimation(bool isShow) {
            DoubleAnimation daAngle = new DoubleAnimation();
            DoubleAnimation daOpacity = new DoubleAnimation();
            Storyboard sb = new Storyboard();
            sb.Children.Add(daAngle);
            sb.Children.Add(daOpacity);
            Storyboard.SetTargetProperty(daAngle, 
                new PropertyPath("Grid.RenderTransform.Children[1].Angle"));
            Storyboard.SetTargetProperty(daOpacity,
                new PropertyPath("Opacity"));
            daAngle.Duration = new Duration(TimeSpan.FromSeconds(1));
            if (isShow) {
                daAngle.From = 0;
                daAngle.To = 360;
                daOpacity.From = 0;
                daOpacity.To = 1;
            }
            else {
                daAngle.From = 360;
                daAngle.To = 0;
                daOpacity.From = 1;
                daOpacity.To = 0;
            }
            return sb;
        }
    }
}
