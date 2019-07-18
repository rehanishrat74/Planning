#Region "Libraries"
Imports Infinilogic.AccountsCentre
Imports InfiniLogic.AccountsCentre.Common

#End Region

Public Class DoLogin
    Inherits PageTemplate

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Put user code to initialize the page here
        Dim strUserID, strPassword As String
        Dim detail As String
        Try
            Dim strQueryString As String = Request("q")
            Trace.Warn("strQueryString = " & strQueryString)
            Dim objSecureQueryString As New SecureQueryString(strQueryString)

            With objSecureQueryString
                strUserID = .Item("UserID")
                strPassword = .Item("Password")
                'Session.Abandon()

                If Not BLL.Validation.IsUserAllowed(strUserID) Then
                    Response.Write("User authentication failed!")
                    Exit Sub

                End If
                Session(ACC_SessionID) = .Item(ACC_SessionID)
                Session(PageTemplate.Session_ServiceID) = .Item("serviceid")
                Session(PageTemplate.Session_ParentUID) = strUserID
                Session(PageTemplate.Session_ParentPassword) = strPassword
                '**********************************************************************
                BLL.PageBase.isEmployee = IIf(.Item("isEmployee") = String.Empty, "False", .Item("isEmployee"))
                If BLL.PageBase.isEmployee Then
                    BLL.PageBase.merchantEmployeeID = .Item("EmployeeID")
                    Session(PageTemplate.session_IsEmployee) = .Item("isEmployee")
                    Session(PageTemplate.session_EmployeeID) = .Item("EmployeeID")
                    Session("MerchantProUserID") = .Item("merchantuserid")
                End If
                '*************************************************************************
                Trace.Write("strUserID = .Item(""UserID"")=" & strUserID = .Item("UserID"))
                Trace.Write("Session(PageTemplate.Session_ServiceID)=" & Session(PageTemplate.Session_ServiceID))
                Dim CustomerID As String = (New InfiniLogic.AccountsCentre.BLL.User).GetCustomerID(strUserID)

                'Trace.Warn("session(PageTemplate.Session_ResellerID)=" & Session(PageTemplate.Session_ResellerID))
                Try
                    detail = .Item("detail")
                    Dim LongOrderID As String = System.Configuration.ConfigurationSettings.AppSettings("LongOrderID")
                    Trace.Write("LongOrderID=" & LongOrderID)
                    If LongOrderID = "1" Then
                        Dim ResellerID As String = .Item("ResellerID")
                        Trace.Write("ResellerID=" & ResellerID)
                        Session(PageTemplate.Session_ResellerID) = ResellerID
                    End If
                Catch ex As Exception
                    Trace.Warn("detail not found!")
                End Try
            End With
        Catch ee As Exception
            Trace.Warn("DoLogin.aspx->TimeStamp:" & Now)
            Trace.Warn("Exception:")
            Trace.Warn("Message: " & ee.Message)
            Trace.Warn("StackTrace:" & ee.StackTrace)
            Trace.Warn("Request(q):" & Request("q"))
            RedirectTo(BLL.ACC_Redirection.SIGNIN)
        End Try
        Try
            If detail Is Nothing Then detail = ""
            Trace.Warn("detail= " & detail)
            If Not detail = "" Then
                Trace.Warn("New function is calling")
                SignInAccountsCentreUSer(strUserID, strPassword, True, True)
                Trace.Warn("ok!")

                Dim secureDetail As New SecureQueryString
                secureDetail.Add("detail", detail)

                'Response.Redirect("../Members/ProductActivation.aspx?detail=" & secureDetail.ToString)
                Response.Redirect("/Members/Activation.aspx?detail=" & secureDetail.ToString)
            Else
                Trace.Warn("old function is calling")
                SignInAccountsCentreUSer(strUserID, strPassword)
            End If
        Catch ex As Threading.ThreadAbortException
            Trace.Warn("Threading.ThreadAbortException Raised!")
        Catch ex As Exception
            Trace.Warn("EXCEPTION: ")
            Trace.Warn("Message: " & ex.Message)
            Trace.Warn("StackTrace: " & ex.StackTrace)
        End Try
        
    End Sub

    'Private Sub WriteDebugInfo(ByVal sText As String)
    '    If System.Configuration.ConfigurationSettings.AppSettings("IOTraceEnable").Equals("1") Then
    '        If Not System.IO.Directory.Exists("d:\CustomerProcessing Trace") Then
    '            System.IO.Directory.CreateDirectory("d:\CustomerProcessing Trace")
    '        End If
    '        Dim sw As System.IO.StreamWriter
    '        sw = System.IO.File.AppendText("d:\CustomerProcessing Trace\DoLogin.aspx.vb Trace.txt")
    '        sw.WriteLine(Now & " -- " & sText)
    '        sw.Close()
    '    End If
    'End Sub
End Class
