Imports System.ComponentModel
Imports System.ComponentModel.Design

Public Class StatusBoard
#Region "Public Properties"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-08-25</date>
    ''' </author>
    ''' <summary>
    ''' Get or set text of this control
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Browsable(True), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)> _
    Public Overrides Property Text() As String
        Get
            Return lblHeader.Text
        End Get
		Set(ByVal value As String)
			lblHeader.Text = value
        End Set
    End Property


    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-08-25</date>
    ''' </author>
    ''' <summary>
    ''' Get or set Font of this control
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides Property Font() As Font
        Get
            Font = MyBase.Font
        End Get
		Set(ByVal value As Font)
			Try
				MyBase.Font = value
				lblHeader.Font = MyBase.Font
			Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
			End Try

		End Set
    End Property

    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-08-25</date>
    ''' </author>
    ''' <summary>
    ''' Get or set header backcolor of this control
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property HeaderBackColor() As Color
        Get
            HeaderBackColor = lblHeader.BackColor
        End Get
		Set(ByVal value As Color)
			Try
				lblHeader.BackColor = value
			Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Set
    End Property

    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-08-25</date>
    ''' </author>
    ''' <summary>
    ''' Get or set visible header of this control
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Property HeaderVisible() As Boolean
        Get
            HeaderVisible = lblHeader.Visible
        End Get
        Set(ByVal value As Boolean)
            Try
                lblHeader.Visible = value
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Set
    End Property
#End Region

End Class
