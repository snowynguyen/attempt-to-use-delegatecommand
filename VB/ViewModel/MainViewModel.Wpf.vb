Imports DevExpress.Mvvm
Imports System.Windows

Namespace Example.ViewModel
    Public Class MainViewModel
        Inherits ViewModelBase

        Private privateAutoUpdateCommand As DelegateCommand
        Public Property AutoUpdateCommand() As DelegateCommand
            Get
                Return privateAutoUpdateCommand
            End Get
            Private Set(ByVal value As DelegateCommand)
                privateAutoUpdateCommand = value
            End Set
        End Property
        Public Property IsAutoUpdateCommandEnabled() As Boolean
            Get
                Return GetProperty(Function() IsAutoUpdateCommandEnabled)
            End Get
            Set(ByVal value As Boolean)
                SetProperty(Function() IsAutoUpdateCommandEnabled, value)
            End Set
        End Property
        Private Sub AutoUpdateCommandExecute()
            MessageBox.Show("Hello")
        End Sub
        Private Function AutoUpdateCommandCanExecute() As Boolean
            Return IsAutoUpdateCommandEnabled
        End Function

        Private privateManualUpdateCommand As DelegateCommand
        Public Property ManualUpdateCommand() As DelegateCommand
            Get
                Return privateManualUpdateCommand
            End Get
            Private Set(ByVal value As DelegateCommand)
                privateManualUpdateCommand = value
            End Set
        End Property
        Public Property IsManualUpdateCommandEnabled() As Boolean
            Get
                Return GetProperty(Function() IsManualUpdateCommandEnabled)
            End Get
            Set(ByVal value As Boolean)
                SetProperty(Function() IsManualUpdateCommandEnabled, value)
            End Set
        End Property
        Private Sub ManualUpdateCommandExecute()
            MessageBox.Show("Hello")
        End Sub
        Private Function ManualUpdateCommandCanExecute() As Boolean
            Return IsManualUpdateCommandEnabled
        End Function
        Private privateForceUpdateManualUpdateCommand As DelegateCommand
        Public Property ForceUpdateManualUpdateCommand() As DelegateCommand
            Get
                Return privateForceUpdateManualUpdateCommand
            End Get
            Private Set(ByVal value As DelegateCommand)
                privateForceUpdateManualUpdateCommand = value
            End Set
        End Property
        Private Sub ForceUpdateManualUpdateCommandExecute()
            ManualUpdateCommand.RaiseCanExecuteChanged()
        End Sub

        Private privateCommandWithParameter As DelegateCommand(Of String)
        Public Property CommandWithParameter() As DelegateCommand(Of String)
            Get
                Return privateCommandWithParameter
            End Get
            Private Set(ByVal value As DelegateCommand(Of String))
                privateCommandWithParameter = value
            End Set
        End Property
        Private Sub CommandWithParameterExecute(ByVal parameter As String)
            MessageBox.Show(parameter)
        End Sub
        Private Function CommandWithParameterCanExecute(ByVal parameter As String) As Boolean
            Return Not String.IsNullOrEmpty(parameter)
        End Function

        Public Sub New()
            AutoUpdateCommand = New DelegateCommand(AddressOf AutoUpdateCommandExecute, AddressOf AutoUpdateCommandCanExecute)
            ManualUpdateCommand = New DelegateCommand(AddressOf ManualUpdateCommandExecute, AddressOf ManualUpdateCommandCanExecute, False)
            ForceUpdateManualUpdateCommand = New DelegateCommand(AddressOf ForceUpdateManualUpdateCommandExecute)
            CommandWithParameter = New DelegateCommand(Of String)(AddressOf CommandWithParameterExecute, AddressOf CommandWithParameterCanExecute)
        End Sub
    End Class
End Namespace
