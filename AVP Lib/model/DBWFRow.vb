Imports System

Public Class DBWFRow
    '''this class should keep the order of property -> it will be store in arraylist and show in Grid in Sequence Dialog
    '''anyone change the order, please check the Grid on runtime.
    Private m_strSelected As Boolean = False
    Private m_Image As System.Drawing.Image = Nothing
    Private m_strSlotNo As String = String.Empty
    Private m_strFlowOrChamber As String = String.Empty
    Private m_strRecipe As String = String.Empty
    Private m_strOrderInfo As String = String.Empty
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2008-07-24</date>
    ''' </author>
    ''' <summary>
    ''' Img
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Img() As System.Drawing.Image
        Get
            Return m_Image
        End Get
        Set(ByVal value As System.Drawing.Image)
            m_Image = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2008-07-24</date>
    ''' </author>
    ''' <summary>
    ''' Slot
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Slot() As String
        Get
            Return m_strSlotNo
        End Get
        Set(ByVal value As String)
            m_strSlotNo = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2008-07-24</date>
    ''' </author>
    ''' <summary>
    ''' Selected
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Selected() As Boolean
        Get
            Return m_strSelected
        End Get
        Set(ByVal value As Boolean)
            m_strSelected = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2008-07-24</date>
    ''' </author>
    ''' <summary>
    ''' WaferFlow
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property WaferFlow() As String
        Get
            Return m_strFlowOrChamber
        End Get
        Set(ByVal value As String)
            m_strFlowOrChamber = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2008-07-24</date>
    ''' </author>
    ''' <summary>
    ''' Recipe
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Recipe() As String
        Get
            Return m_strRecipe
        End Get
        Set(ByVal value As String)
            m_strRecipe = value
        End Set
    End Property
    '''' <author>
    ''''    	<name> Le Hieu Truc </name>
    ''''    	<date> 2008-07-24</date>
    '''' </author>
    '''' <summary>
    '''' Recipe
    '''' </summary>
    '''' <returns></returns>
    '''' <remarks></remarks>
    Public Property OrderInfo() As String
        Get
            Return m_strOrderInfo
        End Get
        Set(ByVal value As String)
            m_strOrderInfo = value
        End Set
    End Property

End Class