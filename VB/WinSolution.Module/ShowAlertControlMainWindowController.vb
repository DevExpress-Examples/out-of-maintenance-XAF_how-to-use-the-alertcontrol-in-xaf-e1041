Imports System
Imports System.Windows.Forms
Imports DevExpress.ExpressApp
Imports DevExpress.XtraBars.Alerter
Imports DevExpress.ExpressApp.Utils

Namespace WinSolution.Module
	Public Class ShowAlertControlMainWindowController
		Inherits WindowController
		Private alertControlCore As AlertControl
		Private alertTimerCore As Timer
		Public Sub New()
			TargetWindowType = WindowType.Main
		End Sub
		Protected Overrides Sub OnActivated()
			MyBase.OnActivated()
			InitAlertControlCore()
			InitAlertTimerCore()
		End Sub
		Protected Overridable Sub InitAlertControlCore()
			alertControlCore = New AlertControl()
		End Sub
		Protected Overridable Sub InitAlertTimerCore()
			alertTimerCore = New Timer()
			AddHandler alertTimerCore.Tick, AddressOf alertTimerCore_Tick
			alertTimerCore.Interval = 2000
			alertTimerCore.Start()
		End Sub
		Private Sub alertTimerCore_Tick(ByVal sender As Object, ByVal e As EventArgs)
			ShowAlertInfo()
		End Sub
		Protected Overrides Sub OnDeactivating()
			If alertTimerCore IsNot Nothing Then
				alertTimerCore.Stop()
			End If
			MyBase.OnDeactivating()
		End Sub
		Protected Overridable Sub ShowAlertInfo()
			Dim mainForm As Form = CType(Application.MainWindow.Template, Form)
			Dim info As New AlertInfo("Frohe Weihnachten! (Merry Christmas!)", DateTime.Now.ToString(), ImageLoader.Instance.GetImageInfo("Attention").Image)
			AlertControl.Show(mainForm, info)
		End Sub
		Public ReadOnly Property AlertControl() As AlertControl
			Get
				Return alertControlCore
			End Get
		End Property
		Public ReadOnly Property AlertTimer() As Timer
			Get
				Return alertTimerCore
			End Get
		End Property
	End Class
End Namespace