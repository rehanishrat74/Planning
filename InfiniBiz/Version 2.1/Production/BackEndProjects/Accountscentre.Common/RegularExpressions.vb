Imports System.Web.UI
Imports System.Text.RegularExpressions
Imports System.IO
Imports System.Web.UI.WebControls
'************************************************************************************

' NameSpace: InfiniLogic.Text
' Class: RegularExpressions
' Description: This class provides the routines and properties to handle the data
' and expressions.
' 

'************************************************************************************

Public Class RegularExpressions
    'Private Shared regexp As New RegExpLib()
    Private regexp As New RegExpLib

    ' Main Regular Expression Librry

    ' User's Control Collection
    Private _colControlsCollection As New Collection

    Public Sub New()

    End Sub ' New

    ' Procedure: Add
    ' Description: To add the control list provided by the user to the _colControlsCollection
    ' Parameters::  controlName: will be used as the key for collection of controls
    '               configurationString: 010010020 where 01 is the category, 0001 is the type of expression, 002 is the length of data and 0 will be used for optional field
    '               returnValue: to store the return value for individual controls
    Public Function Add(ByVal controlName As String, ByVal configurationString As String, ByVal returnValue As String) As Boolean
        Dim configurationArray(2) As String                         ' Configuration Array to be passed to the collection
        configurationArray(0) = returnValue                         ' index 0: return value
        configurationArray(1) = configurationString                 ' index 1: configuration string 00010020
        configurationArray(2) = controlName                 ' index 1: configuration string 00010020
        Try
            _colControlsCollection.Add(configurationArray, controlName) ' add the array to the collection
            Add = True
        Catch
            Add = False
        End Try
    End Function

    ' Procedure: Remove
    ' Description: To remove the control from _colControlsCollection
    ' Parameters::  controlName: will be used as the key for collection of controls
    Public Function Remove(ByVal controlName As String) As Boolean
        Try
            _colControlsCollection.Remove(controlName)   ' Remove from the collection
            Remove = True
        Catch
            Remove = False
        End Try
    End Function

    ' Procedure: Initialize
    ' Description: To initialize the _colControlsCollection
    Public Sub Initialize()
        _colControlsCollection = New Collection    ' Initialize the collection
    End Sub

    ' Function: ScanPage
    ' Description: To scan the controls array of the page or panel, scanPanel parameter can be used to navigate the inner panels of the page or the panel object
    ' Parameters::  page: will be used to hold the object of the page or panel
    '               scanPanel: optional value to check if user want the class to scan the panel in the page collection or not (used for recursion)
    Public Function ScanPage(ByRef page As System.Web.UI.Page) As String ', Optional ByVal scanPanel As Boolean = True) As String
        ' Variables Declaration/Definition
        ' returnErrorIndex: will hold the comma separated return values associated with the controls (through the collection object)
        ' getConfigurationString: to get the configuration string from the collection object (through getConfigurationString variable)
        ' getValues: to hold the object from the collection object against the control on the page
        ' getExpressionType: to get the Expression Type from the getConfigurationString variable
        ' getFieldLength: to get the Length of the field from the getConfigurationString variable
        ' getOptionalValue: to get the Optional value from the getConfigurationString variable
        ' getObject: to hold the object from the page or panel
        ' isValid: to hold the validity of the input
        Dim returnErrorIndex As String, getConfigurationString As String, getValues As Object
        Dim getExpressionCategory As String, getExpressionType As Short, getFieldLength As Short, getOptionalValue As Boolean
        Dim getObject As Object, isValid As Boolean, control As Object

        ' For the line name "Error Reference #1", to check for NULL values -----------------------------------------+
        'On Error Resume Next                                                                                       ¦
        '                                                                                                           ¦
        With page '                                                                                                 ¦
            ' For loop to fetch the controls from the page or panel object                                          ¦
            For Each control In _colControlsCollection
                Try
                    getObject = Nothing
                    getObject = page.FindControl(control(2))
                Catch

                End Try
                ' check the type of the object, please note that only text boxes will be validted in this class     ¦
                If TypeOf getObject Is TextBox Then '                                                               ¦
                    ' get the array from the collection object against the control                                  ¦
                    Try '      
                        getValues = Nothing '                                                                       ¦
                        getValues = _colControlsCollection.Item(getObject.id) ' Error Reference #1 <----------------+
                    Catch
                    End Try
                    If getValues Is Nothing Then
                        ' this condition will hold for the controls which are not used for validation
                        '       "control not found in the collection object"
                    Else
                        isValid = ScanControl(getObject.text, getValues(1))

                        ' Update error index
                        If Not isValid Then
                            If Len(returnErrorIndex) = 0 Then
                                ' if not validate and returnErrorIndex is empty
                                returnErrorIndex = getValues(0)
                            Else
                                ' if not validate and returnErrorIndex is not empty (append)
                                returnErrorIndex = returnErrorIndex & "," & getValues(0)
                            End If
                        End If
                    End If
                    'ElseIf scanPanel And TypeOf getObject Is Panel Then ' to check for inner panels
                    '    ' ScanPanel
                    '    ' call scanPage for the panel and get the error indexes array
                    '    Dim getPanelErrorIndex As String = ScanPage(getObject)
                    '    If Len(returnErrorIndex) = 0 And Len(getPanelErrorIndex) > 0 Then
                    '        ' if there are no previous errors
                    '        returnErrorIndex = getPanelErrorIndex
                    '    ElseIf Len(getPanelErrorIndex) > 0 Then
                    '        ' if there are previous values of error indexes (append)
                    '        returnErrorIndex = returnErrorIndex & "," & getPanelErrorIndex
                    '    End If
                End If
            Next
        End With
        ScanPage = returnErrorIndex ' return error index string
    End Function

    ' Function: ScanControl
    ' Description: To validate the value of the control(TextBox)
    ' Parameters::  control: will be used to hold the object of the control
    '               configurationString: optional value to check if user want the class to scan the panel in the page collection or not (used for recursion)
    Public Function ScanControl(ByRef controlText As String, ByVal configurationString As String) As Boolean
        ' Variables Declaration/Definition
        ' getValues: to hold the object from the collection object against the control on the page
        ' getExpressionType: to get the Expression Type from the getConfigurationString variable
        ' getFieldLength: to get the Length of the field from the getConfigurationString variable
        ' getOptionalValue: to get the Optional value from the getConfigurationString variable
        Dim getValues As Object
        Dim getExpressionCategory As String, getExpressionType As Short, getFieldLength As Short, getOptionalValue As Boolean

        ' get the expression type (index of our own regular expression library)
        getExpressionCategory = Mid(configurationString, 1, 5)

        ' get the expression type (index of our own regular expression library)
        'getExpressionType = Mid(configurationString, 3, 3)

        ' get the field length to be used for LEFT function
        getFieldLength = Mid(configurationString, 6, 4)

        ' required for empty textboxes against the optional or NULL fields in databases.
        getOptionalValue = Mid(configurationString, 10, 1)
        ' validate the textbox

        ' Len(getObject.text) > getFieldLength
        '    - Check whether the input is greater than the field length
        ' getFieldLength > 0
        '    - getFieldLength could be zero for numeric values,
        '      numeric's length can be handled by the regular expression itself.
        If Len(controlText) > getFieldLength And getFieldLength > 0 Then
            ScanControl = False
        ElseIf getOptionalValue And Len(controlText) = 0 Then ' If input is optional and nothing is input
            ScanControl = True
        ElseIf Not getOptionalValue And Len(controlText) = 0 Then ' if input is not optional and nothing is input
            ScanControl = False
        ElseIf IsExpressionValid(regexp.GetExpression(getExpressionCategory), controlText) Then  ' Check for validity
            'regexp.GetExpression(getExpressionType)
            ScanControl = True
        Else ' invalid input
            ScanControl = False
        End If
    End Function

    ' Procedure: isExpressionValid
    ' Description: To check whether the inputString is valid against the regularExpression
    ' Parameters::  regularExpression: will hold the regular expression to be applied on the inputString
    '               inputString: will hold the String to validate
    Public Function IsExpressionValid(ByVal regularExpression As String, ByVal inputString As String) As Boolean
        Dim validateExpression As Regex ' Regular Expression Object

        validateExpression = New Regex(regularExpression) ' Initialization of the Regular Expression Object

        If Not validateExpression.IsMatch(inputString, regularExpression) Then ' calling IsMatch function for validation
            IsExpressionValid = False ' return if validate false
        Else
            IsExpressionValid = True ' return if  validate true
        End If
        validateExpression = Nothing ' destroy the Regular Expression Object
    End Function

End Class
