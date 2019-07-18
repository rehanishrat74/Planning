Sub DrawChart(xmlDoc, chartSpace)

    set c = chartSpace.Constants
	chartSpace.XMLData = xmlDoc.xml
	chartSpace.Charts(0).HasLegend = true
    chartSpace.Charts(0).Legend.Position = c.chLegendPositionTop
     
End sub


'Sub DSCInit(dsc, ChartID)
    'if len(dsc.ConnectionString) = 0 then
      '  dsc.ConnectionString = "provider=mspersist"
     '   dsc.RecordsetDefs.AddNew "http://localhost/BizPlanWeb/Services/Charts/XMLChartData.aspx?chartID=" & ChartID, _
    '    dsc.Constants.dscCommandFile, "ChartData"
   ' else
  '      Window.status = "DSC ConnectionString is already set!"
 '   end if
'End Sub

'Sub DrawChart(cspace, dsc)
 '   Dim c           'Constants object
  '  Dim cht         'Temp WCChart object
   ' Dim ser         'Temp WCSeries object
    'Dim ax          'Temp WCAxis object

    'Set c = cspace.Constants'

    ' Clear the Chartspace
    'cspace.Clear

    ' Load the chart data sources
    'Dim cds         'Temp WCChartDataSource object

	' Add a DataSource to the Chart and set it to be the dsc
    'Set cds = cspace.ChartDataSources.Add()
    'Set cds.DataSource = dsc

    ' Set the Data Member to be the RecordsetDef
    'cds.DataMember = "ChartData"
    'cds.CacheSize = 400

    ' Draw the Chart
    'set cht = cspace.Charts.Add()
    'cht.Type = c.chChartTypeLineMarkers
    'cht.HasLegend = False
    'cht.Legend.Position = c.chLegendPositionTop
   ' cht.HasTitle = True
    'cht.Title.Caption = cspace.Caption

    ' Add a series
    'set ser = cht.SeriesCollection.Add()
    'ser.Name = "Utilization(%)"
    'ser.Caption = ser.Name
    'ser.Marker.Size = 4


    ' Set the Categories to the first field (YValues)in the
    ' RecordSetDef of the DataSource - dsc
    'ser.SetData c.chDimCategories, 0, 0

    ' Set the Values to the second field (XValues)in the
    ' RecordSetDef of the DataSource - dsc
    'ser.SetData c.chDimValues, 0, 1
    ' Add a series
'    set ser = cht.SeriesCollection.Add()
'    ser.Name = "n(%)"
'    ser.Caption = ser.Name & "2"
'    ser.Marker.Size = 4
'    ser.SetData c.chDimValues, 0, 2

'    set ser = cht.SeriesCollection.Add()
'    ser.Name = "n(%)"
'    ser.Caption = ser.Name & "3"
'    ser.Marker.Size = 4
'    ser.SetData c.chDimValues, 0, 3

    ' Set the tick label spacing depending on the number of points plotted
'    Set ax = cht.Axes(c.chAxisPositionBottom)
'    ax.TickLabelSpacing = cht.SeriesCollection(0).Points.Count / 10
'End Sub