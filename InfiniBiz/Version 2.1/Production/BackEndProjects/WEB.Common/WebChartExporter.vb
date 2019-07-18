#Region "......................Imports "

Imports OWC11
Imports System.Reflection
Imports System.IO
Imports System.Text
Imports System.Drawing
Imports System.Drawing.Imaging
Imports Infinilogic.BusinessPlan.Common
Imports Infinilogic.BusinessPlan.BLL
Imports Infinilogic.BusinessPlan.DAL
Imports Infinilogic.BusinessPlan.BLLRules
Imports System.Windows.Forms
Imports System.Runtime.InteropServices

#End Region

Public Class WebChartExporter

#Region "................... Private Members"

    Private _connData As ConnectionData
    Private _currentPlan As Infinilogic.BusinessPlan.BLL.BusinessPlan

#End Region

#Region "......................Constants"

    Private Const _chartStartString = "\pard\nowidctlpar\qc\par{\pict\picscalex100\picscaley100\piccropl0\piccropr0\piccropt0\piccropb0" _
                                 & "\picw8043\pich4868\picwgoal4560\pichgoal2760\pngblip "
    Private Const _chartEndString = "}\par\par\par\pard"

    'Private Const _gifChartStartString = "{\*\shppict{\pict{\*\picprop\shplid1025{\sp{\sn shapeType}{\sv 75}}{\sp{\sn fFlipH}{\sv 0}}{\sp{\sn fFlipV}{\sv 0}}{\sp{\sn pibFlags}{\sv 2}}{\sp{\sn fLine}{\sv 0}}{\sp{\sn fLayoutInCell}{\sv 1}}}\picscalex96\picscaley96\piccropl0\piccropr0\piccropt0\piccropb0" _
    '                                   & "\picw8043\pich4868\picwgoal4560\pichgoal2760\pngblip "

    Private _bmpHeight As Integer = 400 * 567
    Private _bmpWidth As Integer = 600 * 567

#End Region

#Region ".......................Constructors"

    Public Sub New(ByVal connData As ConnectionData, ByVal currentPlan As Infinilogic.BusinessPlan.BLL.BusinessPlan)
        _connData = connData
        _currentPlan = currentPlan
    End Sub

#End Region

#Region "..........................Public Methods"

    Public Function ExportChart(ByVal chartFileName As String, ByVal chartName As String) As String

        '~~~~~~~~~ Export Algo ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        ' 1. Generate the chart 
        ' 2. Get the exported Chart filename 
        ' 3. Convert it to Byte Array 
        ' 4. Make its RTF 
        ' 5. Return that RTF to the calling Function


        '~~~~~~~~~~~~~~~~~~~ based on chart name and a Default Type , we will create a chart 

        ProcessChart(chartFileName, chartName)

        ' then we will make its RTF        
        Dim startString As New StringBuilder(_chartStartString)
        startString.Replace("picw8043", "picw" & _bmpWidth)
        startString.Replace("pich4868", "pich" & _bmpHeight)
        startString.Replace("picwgoal4560", "picwgoal" & _bmpWidth)
        startString.Replace("pichgoal2760", "pichgoal" & _bmpHeight)
        Dim chartRTF As New StringBuilder(1000)
        chartRTF.Append(startString)
        Dim x As String = GetRtfImage(New Bitmap(chartFileName))
        chartRTF.Append(x)
        chartRTF.Append(_chartEndString)


        Return chartRTF.ToString

    End Function

#End Region

#Region "..........................Private Helper Methods"

    'Private Function ConvertChartToHex(ByVal chartFileName As String) As String

    '    Dim objfileinfo As New FileInfo(chartFileName)

    '    Dim bytFile(objfileinfo.Length - 1) As Byte
    '    Dim fs As New FileStream(chartFileName, FileMode.Open, FileAccess.Read)
    '    fs.Read(bytFile, 0, objfileinfo.Length - 1)
    '    fs.Close()
    '    'Kill(chart & "." & ImageFormat.Wmf.ToString)
    '    Dim i As Integer
    '    Dim j As String
    '    Dim chartRTF As New StringBuilder(1000)

    '    For i = 0 To bytFile.Length - 1
    '        j = Hex(bytFile(i))
    '        If j.Length < 2 Then
    '            chartRTF.Append("0" & j)
    '        Else
    '            chartRTF.Append(j)
    '        End If
    '    Next
    '    Return chartRTF.ToString
    'End Function

    Private Sub ProcessChart(ByVal chartFileName As String, ByVal chartName As String)
        Try
            'Dim assemName As String = "Infinilogic.BusinessPlan.Web.Charts"
            'Dim typeName As String = assemName & "." & chartName & "Chart"
            'Dim asmbly As [Assembly] = [Assembly].Load(assemName)
            'Dim chartClass As IChartGenerator = CType(asmbly.CreateInstance(typeName), IChartGenerator)
            'chartClass.GenerateChart(_connData, _currentPlan, chartFileName, chartType)
            BusinessChart.CreateChart(_connData, _currentPlan, chartName, chartFileName)
        Catch ex As Exception
            Throw New Exception("Chart Cannot be processed." & ex.Message)
        End Try
    End Sub


    Private Function GetRtfImage(ByVal chartImage As Image) As String


        Dim sb As New StringBuilder
        Dim g As Graphics
        Dim mFile As Metafile
        Dim hdcRef As IntPtr
        Dim hDCEmf As IntPtr
        Dim hEmf As IntPtr
        Dim rc As API.RECT
        Dim sizeBuff As UInt32
        Dim intSizeBuff As Int32
        Dim rtBox As New RichTextBox

        Try

            g = rtBox.CreateGraphics
            rc.Right = _bmpWidth   '(chartImage.Width / g.DpiX) * 597
            rc.Bottom = _bmpHeight  '(chartImage.Height / g.DpiY) * 597
            hdcRef = g.GetHdc()
            hDCEmf = API.CreateEnhMetaFile(hdcRef, vbNullString, rc, "")
            g.ReleaseHdc(hdcRef)
            g.Dispose()


            g = Graphics.FromHdc(hDCEmf)
            g.DrawImage(chartImage, New Rectangle(0, 0, chartImage.Width, chartImage.Height))
            hEmf = API.CloseEnhMetaFile(hDCEmf)

            sizeBuff = API.GdipEmfToWmfBits(hEmf, sizeBuff, Nothing, API.MM_ANISOTROPIC, API.EmfToWmfBitsFlags.EmfToWmfBitsFlagsDefault)
            intSizeBuff = Convert.ToInt32(sizeBuff)

            Dim buff(intSizeBuff - 1) As Byte
            sizeBuff = API.GdipEmfToWmfBits(hEmf, sizeBuff, buff, API.MM_ANISOTROPIC, API.EmfToWmfBitsFlags.EmfToWmfBitsFlagsDefault)
            intSizeBuff = Convert.ToInt32(sizeBuff)

            Dim index As Integer
            For index = 0 To intSizeBuff - 1
                sb.Append(buff(index).ToString("X2"))

            Next

            g.Dispose()
            Return sb.ToString
        Catch ex As Exception
            Debug.Write(ex.Message)
        End Try

    End Function 'GetRtfImage



#End Region

End Class


#Region "................... Class API"

Public Class API

    Public Declare Function CreateEnhMetaFile Lib "gdi32" Alias "CreateEnhMetaFileA" ( _
        ByVal hdcRef As IntPtr, _
        ByVal lpFileName As String, _
        ByVal lpRect As RECT, _
        ByVal lpDescription As String) As IntPtr

    Public Structure RECT
        Public Left As Integer
        Public Top As Integer
        Public Right As Integer
        Public Bottom As Integer
    End Structure

    Public Declare Function CloseEnhMetaFile Lib "gdi32" ( _
      ByVal hdc As IntPtr) As IntPtr

    Public Enum EmfToWmfBitsFlags
        '// Use the default conversion
        EmfToWmfBitsFlagsDefault = 0

        '// Embedded the source of the EMF metafiel within the resulting WMF
        '// metafile
        EmfToWmfBitsFlagsEmbedEmf = 1

        '// Place a 22-byte header in the resulting WMF file.  The header is
        '// required for the metafile to be considered placeable.
        EmfToWmfBitsFlagsIncludePlaceable = 2

        '// Don't simulate clipping by using the XOR operator.
        EmfToWmfBitsFlagsNoXORClip = 4
    End Enum

    ''// Ensures that the metafile maintains a 1:1 aspect ratio
    'Public Const MM_ISOTROPIC% = 7

    ''// Allows the x-coordinates and y-coordinates of the metafile to be adjusted
    ''// independently
    Public Const MM_ANISOTROPIC% = 8

    <DllImport("gdiplus.dll")> Public Shared Function GdipEmfToWmfBits(ByVal hEmf As IntPtr, ByVal bufferSize As UInt32, ByVal buffer As Byte(), ByVal mappingMode As Integer, ByVal flags As EmfToWmfBitsFlags) As UInt32
    End Function


End Class

#End Region

