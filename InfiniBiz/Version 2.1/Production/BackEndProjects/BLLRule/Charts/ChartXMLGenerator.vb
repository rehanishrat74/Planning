Public Class ChartXMLGenerator
    Private _XMLData As String
    Public ReadOnly Property XMLData() As String
        Get
            Return _XMLData
        End Get
    End Property
    Public Sub BeginChartSpace(ByVal Name As String)
        _XMLData += "<ChartSpace"
        _XMLData += " Title=" & Chr(34) & Name & Chr(34)
        _XMLData += ">"
    End Sub
    Public Sub EndChartSpace()
        _XMLData += "</ChartSpace>"
    End Sub
    Public Sub BeginChart(ByVal Name As String, ByVal XAxisCaption As String, ByVal YAxisCaption As String, ByVal HasLegend As Boolean)
        _XMLData += "<Chart"
        _XMLData += " Title=" & Chr(34) & Name & Chr(34)
        _XMLData += " XAxisCaption=" & Chr(34) & XAxisCaption & Chr(34)
        _XMLData += " YAxisCaption=" & Chr(34) & YAxisCaption & Chr(34)
        _XMLData += " HasLegend=" & Chr(34) & HasLegend & Chr(34)
        _XMLData += ">"
    End Sub
    Public Sub EndChart()
        _XMLData += "</Chart>"
    End Sub
    Public Sub AddSeries(ByVal Name As String, ByVal Caption As String)
        _XMLData += "<Series Name=" & Chr(34) & Name & Chr(34)
        _XMLData += " Caption=" & Chr(34) & Caption & Chr(34)
        _XMLData += " />"
    End Sub
    Public Sub BeginSeriesInfo()
        _XMLData += "<SeriesInfo>"
    End Sub
    Public Sub EndSeriesInfo()
        _XMLData += "</SeriesInfo>"
    End Sub
    Public Sub BeginData()
        _XMLData += "<Data>"
    End Sub
    Public Sub EndData()
        _XMLData += "</Data>"
    End Sub
    Public Sub AddValue(ByVal Name As String, ByVal Value As Single)
        _XMLData += "<" & Name.Replace(" ", "")
        _XMLData += " Value=" & Chr(34) & Value & Chr(34)
        _XMLData += " />"
    End Sub
    Public Sub BeginCategory(ByVal Name As String)
        Dim i As Integer
        _XMLData += "<Category"
        _XMLData += " Name=" & Chr(34) & Name.Replace(" ", "") & Chr(34) & ">"
    End Sub
    Public Sub EndCategory()
        _XMLData += "</Category>"
    End Sub
End Class
