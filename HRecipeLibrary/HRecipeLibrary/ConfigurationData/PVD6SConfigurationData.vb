Public Class PVD6SConfigurationData
    Inherits GeneralConfigurationData

    ''' <author>
    '''    	<name> Dy Do </name>
    '''    	<date> 2021-01-13 </date>
    ''' </author>
    ''' <summary>
    ''' Number Of Target
    ''' </summary>
    Private _numberOfTarget As String = "6"
    Public Property NumberOfTarget() As String
        Get
            Return _numberOfTarget
        End Get
        Set(ByVal value As String)
            _numberOfTarget = value
        End Set
    End Property

End Class
