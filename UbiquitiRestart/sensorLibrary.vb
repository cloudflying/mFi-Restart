Public Class sensorLibrary
    Public Property sensors As New List(Of sensorLibrarySensors)
    Public Property status As String
End Class
Public Class sensorLibrarySensors
    Public Property port As Integer
    Public Property output As Integer
    Public Property power As Double
    Public Property energy As Double
    Public Property enabled As Integer
    Public Property current As Double
    Public Property voltage As Double
    Public Property powerfactor As Double
    Public Property relay As Integer
    Public Property lock As Integer
    Public Property id As String
    Public Property label As String
    Public Property model As String
End Class