Imports Microsoft.VisualBasic
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media.Animation

Namespace AgWindow_CustomAnimation
	Partial Public Class MainPage
		Inherits UserControl
		Public Sub New()
			InitializeComponent()
			popupWindow.ShowAnimation = CreateAnimation(True)
			popupWindow.HideAnimation = CreateAnimation(False)
		End Sub
		Private Sub showPopup(ByVal sender As Object, ByVal e As RoutedEventArgs)
			popupWindow.Show()
		End Sub
		Private Sub popupWindow_Closed(ByVal sender As Object, ByVal e As EventArgs)
			popupWindow.ShowAnimation.Stop()
			popupWindow.HideAnimation.Stop()
		End Sub
		Private Sub closePopup(ByVal sender As Object, ByVal e As RoutedEventArgs)
			popupWindow.Hide()
		End Sub
		Private Function CreateAnimation(ByVal isShow As Boolean) As Storyboard
			Dim daAngle As New DoubleAnimation()
			Dim daOpacity As New DoubleAnimation()
			Dim sb As New Storyboard()
			sb.Children.Add(daAngle)
			sb.Children.Add(daOpacity)
			Storyboard.SetTargetProperty(daAngle, _
				New PropertyPath("Grid.RenderTransform.Children[1].Angle"))
			Storyboard.SetTargetProperty(daOpacity, New PropertyPath("Opacity"))
			daAngle.Duration = New Duration(TimeSpan.FromSeconds(1))
			If isShow Then
				daAngle.From = 0
				daAngle.To = 360
				daOpacity.From = 0
				daOpacity.To = 1
			Else
				daAngle.From = 360
				daAngle.To = 0
				daOpacity.From = 1
				daOpacity.To = 0
			End If
			Return sb
		End Function
	End Class
End Namespace
