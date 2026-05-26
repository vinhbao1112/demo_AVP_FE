Public Class SingleLoaderPJ
    Inherits AVPJob

    Public Sub New(ByVal jobId As String)
        MyBase.New(jobId, JobTypeEnum.ProcessJob)
    End Sub

End Class
