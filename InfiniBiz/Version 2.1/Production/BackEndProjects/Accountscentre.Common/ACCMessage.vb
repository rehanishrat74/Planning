Imports System.IO
Imports System.Globalization
Imports System.Threading

Public Class ACCMessage
    '*****************************************************************************************************
    '                               Muhammad Ubaid
    '*****************************************************************************************************
    '   Date: 14-Dec-2006
    '   This class has Message(s).
    '*****************************************************************************************************
#Region "::::::::::::::Multilangual::::::::::::::::"
    Public Shared currentCulture As New CultureInfo("en")
    Shared obj As ACCMessage
    Dim ResMgr As Resource
    Private Function getResString(ByVal key As String, ByVal DefaultValue As String) As String
        Dim rStr As String
        ResMgr = New Resource
        'DebugWrite("***************************************************************************************")
        'DebugWrite("--------------Start GetResString-------------")
        'DebugWrite("***************************************************************************************")
        'DebugWrite("------------me.currentCultur-->" + Me.currentCulture.ToString)
        Try
            If Me.currentCulture Is Nothing Then
                Dim objCul As New CultureInfo("en")
                Me.currentCulture = objCul
            End If
            '      Me.DebugWrite("----ResMgr----is object----" + ResMgr.GetType.ToString)
            '    Me.DebugWrite("----key----" + key)
            'comStr = ResMgr.GetString(key.Trim, Me.currentCulture)
            rStr = ResMgr.GetString(key.Trim, Me.currentCulture)
            'Me.DebugWrite("----romStr----" + rStr)
            'Me.DebugWrite("----Me.currentCulture----" + Me.currentCulture.ToString)
            '  DebugWrite("***************************************************************************************")
            Return IIf(rStr = String.Empty, DefaultValue, rStr)
        Catch ex As Exception
            DebugWrite("********************************************Exception**********************************", "AccError.txt")
            DebugWrite("-------Key--->" + key, "AccError.txt")
            DebugWrite("-------Return DefaultValue--->" + DefaultValue, "AccError.txt")
            DebugWrite("-------Culture--->" + Me.currentCulture.ToString, "AccError.txt")
            DebugWrite("***************************************************************************************", "AccError.txt")
            Return DefaultValue
        End Try
    End Function
    Private Function DebugWrite(ByVal str As String, Optional ByVal filename As String = "AccMessages.txt")
        Dim sw As StreamWriter
        Dim objio As IO.Directory

        If Not objio.Exists("D:\AccountsCenter_Debug") Then
            objio.CreateDirectory("D:\AccountsCenter_Debug")
        End If
        sw = File.AppendText("D:\AccountsCenter_Debug\" + filename)
        sw.WriteLine(str + " " + "------->" + Now())
        sw.Close()
    End Function
#End Region
#Region "::::::::::::::::::::::Account Centres Messages Properties::::::::::::::::::::::"

    ' Account (customer, employer) related messages.
    '---------------------------------------------------------
    'Public Const Account_SignInAttemptFailed As String = "ERROR : Invalid User ID / Password. Please try again."
    Public Shared ReadOnly Property Account_SignInAttemptFailed()
        Get
            obj = New ACCMessage
            Return obj.getResString("acc_msg_Account_SignInAttemptFailed", "ERROR : Invalid User ID / Password. Please try again.")
        End Get
    End Property
    'Public Const Account_NewCustomerCreated As String = "We welcome you as our customer. Your registration process in now completed. You will recieve an email " _
    '                                                      & "along with the status of your UserID and Password." & vbCrLf & vbCrLf & "You can use the same UserID and Password to log on to Formationhouse and Graphics4Less " _
    '                                                     & "websites, and take full advantage of our competitive prices." & vbCrLf & vbCrLf & "If you do not recieve any email within next 24 hours, " _
    '                                                    & "please feel free to write us on support@infinibiz.com "
    Public Shared ReadOnly Property Account_NewCustomerCreated()
        Get
            Dim str As String
            obj = New ACCMessage
            str = obj.getResString("acc_msg_Account_NewCustomerCreated1", "We welcome you as our customer. " + _
            "Your registration process in now completed. You will recieve an email along with the status of " + _
            "your UserID and Password.") + vbCrLf + vbCrLf + obj.getResString("acc_msg_Account_NewCustomerCreated2", + _
            "You can use the same UserID and Password to log on to Formationhouse and Graphics4Lesswebsites," + _
            "and take full advantage of our competitive prices.") + vbCrLf + vbCrLf + obj.getResString("acc_msg_Account_NewCustomerCreated3", "If you do not recieve any email within next 24 hours, " + _
            "please feel free to write us on") + " support@infinibiz.com "
            Return str
            'obj.getResString("acc_msg_Account_NewCustomerCreated")
        End Get
    End Property
    'Public Const Account_NewEmployerCreated As String = "Your information has been saved."
    Public Shared ReadOnly Property Account_NewEmployerCreated()
        Get
            obj = New ACCMessage
            Return obj.getResString("acc_msg_Account_NewEmployerCreated", "Your information has been saved.")
        End Get
    End Property

    'Public Const Account_NewEmployerRegistrationStatus As String = "Your are already registered as a Payroll Employer."
    Public Shared ReadOnly Property Account_NewEmployerRegistrationStatus()
        Get
            obj = New ACCMessage
            Return obj.getResString("acc_msg_Account_NewEmployerRegistrationStatus", "Your are already registered as a Payroll Employer.")
        End Get
    End Property

    'Public Const Account_UpdateEmployerDetails As String = "Your record has been updated."
    Public Shared ReadOnly Property Account_UpdateEmployerDetails()
        Get
            obj = New ACCMessage
            Return obj.getResString("acc_msg_Account_UpdateEmployerDetails", "Your record has been updated.")
        End Get
    End Property
    'Public Const Account_UpdateCustomerServices As String = "Thank you for adding more valuable sevices. Your request is in process, you will be informed through your specific email address on confirmation of payment."
    Public Shared ReadOnly Property Account_UpdateCustomerServices()
        Get
            obj = New ACCMessage
            Return obj.getResString("acc_msg_Account_UpdateCustomerServices As String", "Thank you for adding more valuable sevices. Your request is in process, you will be informed through your specific email address on confirmation of payment.")
        End Get
    End Property
    'Public Const Account_MatchPassword As String = "New Password and Confirm New Password values are not same. Please enter the same value."
    Public Shared ReadOnly Property Account_MatchPassword()
        Get
            obj = New ACCMessage
            Return obj.getResString("acc_msg_Account_MatchPassword", "New Password and Confirm New Password values are not same. Please enter the same value.")
        End Get
    End Property
    'Public Const Account_UpdatePassword As String = "Your password has been updated."
    Public Shared ReadOnly Property Account_UpdatePassword()
        Get
            obj = New ACCMessage
            Return obj.getResString("acc_msg_Account_UpdatePassword", "Your password has been updated.")
        End Get
    End Property
    'Public Const Account_IncorrectPassword As String = "Please enter a correct password."
    Public Shared ReadOnly Property Account_IncorrectPassword()
        Get
            obj = New ACCMessage
            Return obj.getResString("acc_msg_Account_IncorrectPassword", "Please enter a correct password.")
        End Get
    End Property
    'Public Const Account_ForgotPassword As String = "Your entered email address did not match with our record. Please enter a correct email."
    Public Shared ReadOnly Property Account_ForgotPassword()
        Get
            obj = New ACCMessage
            Return obj.getResString("acc_msg_Account_ForgotPassword", "Your entered email address did not match with our record. Please enter a correct email.")
        End Get
    End Property
    'Public Const Account_PasswordMatching As String = "Password and Confirm Password fields must be identical."
    Public Shared ReadOnly Property Account_PasswordMatching()
        Get
            obj = New ACCMessage
            Return obj.getResString("acc_msg_Account_PasswordMatching", "Password and Confirm Password fields must be identical.")
        End Get
    End Property
    ' Public Const Account_CrCardExpiryDate As String = "Please enter a valid expiry date."
    Public Shared ReadOnly Property Account_CrCardExpiryDate()
        Get
            obj = New ACCMessage
            Return obj.getResString("acc_msg_Account_CrCardExpiryDate", "Please enter a valid expiry date.")
        End Get
    End Property
    'Public Const Account_AXCardSTDate As String = "Please enter a valid start date."
    Public Shared ReadOnly Property Account_AXCardSTDate()
        Get
            obj = New ACCMessage
            Return obj.getResString("acc_msg_Account_AXCardSTDate", "Please enter a valid start date.")
        End Get
    End Property
    'Public Const Account_AXCardENDate As String = "Please enter a valid end date."
    Public Shared ReadOnly Property Account_AXCardENDate()
        Get
            obj = New ACCMessage
            Return obj.getResString("acc_msg_Account_AXCardENDate", "Please enter a valid end date.")
        End Get
    End Property
    'Public Const Account_DrCardDate As String = "Please enter a valid issue date."
    Public Shared ReadOnly Property Account_DrCardDate()
        Get
            obj = New ACCMessage
            Return obj.getResString("acc_msg_Account_DrCardDate", "Please enter a valid issue date.")
        End Get
    End Property

    'Public Const Account_Select_Product As String = "Atleast one product must be selected."
    Public Shared ReadOnly Property Account_Select_Product()
        Get
            obj = New ACCMessage
            Return obj.getResString("acc_msg_Account_Select_Product", "Atleast one product must be selected.")
        End Get
    End Property
    '  Public Const Account_Valid_Password As String = "You must enter a valid password"
    Public Shared ReadOnly Property Account_Valid_Password()
        Get
            obj = New ACCMessage
            Return obj.getResString("acc_msg_Account_Valid_Password", "You must enter a valid password")
        End Get
    End Property

    'Public Const Account_Valid_Data_Following As String = "Please enter valid data in the following field(s): "
    Public Shared ReadOnly Property Account_Valid_Data_Following()
        Get
            obj = New ACCMessage
            Return obj.getResString("acc_msg_Account_Valid_Data_Following", "Please enter valid data in the following field(s): ")
        End Get
    End Property

    'Public Const Account_Credit_No_Required As String = "Credit card number is required."
    Public Shared ReadOnly Property Account_Credit_No_Required()
        Get
            obj = New ACCMessage
            Return obj.getResString("acc_msg_Account_Credit_No_Required", "Credit card number is required.")
        End Get
    End Property
    'Public Const Account_Valid_UserID As String = "You must enter a valid userid"
    Public Shared ReadOnly Property Account_Valid_UserID()
        Get
            obj = New ACCMessage
            Return obj.getResString("acc_msg_Account_Valid_UserID", "You must enter a valid userid")
        End Get
    End Property
    'Public Const Account_Order_Payment As String = "Order payment successfull.<br>PLEASE DO NOT RETRY."
    Public Shared ReadOnly Property Account_Order_Payment()
        Get
            obj = New ACCMessage
            Return obj.getResString("acc_msg_Account_Order_Payment", "Order payment successfull.<br>PLEASE DO NOT RETRY.")
        End Get
    End Property

    'Public Const Account_Order_Process As String = "Order is under process. Please contact with administration."
    Public Shared ReadOnly Property Account_Order_Process()
        Get
            obj = New ACCMessage
            Return obj.getResString("acc_msg_Account_Order_Process", "Order is under process. Please contact with administration.")
        End Get
    End Property
    'Public Const Account_Product As String = "Following Packages/Products have same Services."
    Public Shared ReadOnly Property Account_Product()
        Get
            obj = New ACCMessage
            Return obj.getResString("acc_msg_Account_Product", "Following Packages/Products have same Services.")
        End Get
    End Property
    'Public Const Account_Company_Select As String = "Please select the company from the list below."
    Public Shared ReadOnly Property Account_Company_Select()
        Get
            obj = New ACCMessage
            Return obj.getResString("acc_msg_Account_Company_Select", "Please select the company from the list below.")
        End Get
    End Property

    'Public Const Account_Select_imgFile As String = "ERROR: Please select image file."
    Public Shared ReadOnly Property Account_Select_imgFile()
        Get
            obj = New ACCMessage
            Return obj.getResString("acc_msg_Account_Select_imgFile", "ERROR: Please select image file.")
        End Get
    End Property

    '  Public Const Account_CustomerId_Dosenot_Exit As String = "The CustomerId you entered , Does not Exist.Try again!"
    Public Shared ReadOnly Property Account_CustomerId_Dosenot_Exit()
        Get
            obj = New ACCMessage
            Return obj.getResString("acc_msg_Account_CustomerId_Dosenot_Exit", "The CustomerId you entered , Does not Exist.Try again!")
        End Get
    End Property

    'Public Const Account_Customerid_Fill As String = "Please Fill In the CustomerId."
    Public Shared ReadOnly Property Account_Customerid_Fill()
        Get
            obj = New ACCMessage
            Return obj.getResString("acc_msg_Account_Customerid_Fill", "Please Fill In the CustomerId.")
        End Get
    End Property

    'Public Const Account_Fill_data As String = "File with no data can not be saved."
    Public Shared ReadOnly Property Account_Fill_data()
        Get
            obj = New ACCMessage
            Return obj.getResString("acc_msg_Account_Fill_data", "File with no data can not be saved.")
        End Get
    End Property

    'Public Const Account_Upload_File As String = "You must select the file to upload"
    Public Shared ReadOnly Property Account_Upload_File()
        Get
            obj = New ACCMessage
            Return obj.getResString("acc_msg_Account_Upload_File", "You must select the file to upload")
        End Get
    End Property

    'Public Const Account_GlobalView As String = "Global View"
    Public Shared ReadOnly Property Account_GlobalView()
        Get
            obj = New ACCMessage
            Return obj.getResString("acc_msg_Account_GlobalView", "Global View")
        End Get
    End Property

    'Public Const Account_GlobalView_created_successfully As String = "Created successfully."
    Public Shared ReadOnly Property Account_GlobalView_created_successfully()
        Get
            obj = New ACCMessage
            Return obj.getResString("acc_msg_Account_GlobalView_created_successfully", "Created successfully.")
        End Get
    End Property

    'Public Const Account_GlobalView_Detail As String = "is already created. Try Signing in again to have updated "
    Public Shared ReadOnly Property Account_GlobalView_Detail()
        Get
            obj = New ACCMessage
            Return obj.getResString("acc_msg_Account_GlobalView_Detail", "is already created. Try Signing in again to have updated ")
        End Get
    End Property

    '    Public Const Account_Invoice_Name As String = "Invoice Name"
    Public Shared ReadOnly Property Account_Invoice_Name()
        Get
            obj = New ACCMessage
            Return obj.getResString("acc_msg_Account_Invoice_Name", "Invoice Name")
        End Get
    End Property
    'Public Const Account_Password As String = "Password"
    Public Shared ReadOnly Property Account_Password()
        Get
            obj = New ACCMessage
            Return obj.getResString("acc_msg_Account_Password", "Password")
        End Get
    End Property
    'Public Const Account_confirm_Password As String = "Confirm Password"
    Public Shared ReadOnly Property Account_confirm_Password()
        Get
            obj = New ACCMessage
            Return obj.getResString("acc_msg_Account_confirm_Password", "Confirm Password")
        End Get
    End Property
    'Public Const Account_Street As String = "Street"
    Public Shared ReadOnly Property Account_Street()
        Get
            obj = New ACCMessage
            Return obj.getResString("acc_msg_Account_Street", "Street")
        End Get
    End Property
    'Public Const Account_Town As String = "Town"
    Public Shared ReadOnly Property Account_Town()
        Get
            obj = New ACCMessage
            Return obj.getResString("acc_msg_Account_Town", "Town")
        End Get
    End Property
    'Public Const Account_State As String = "State"
    Public Shared ReadOnly Property Account_State()
        Get
            obj = New ACCMessage
            Return obj.getResString("acc_msg_Account_State", "State")
        End Get
    End Property
    'Public Const Account_contact_Name As String = "Contact Name"
    Public Shared ReadOnly Property Account_contact_Name()
        Get
            obj = New ACCMessage
            Return obj.getResString("acc_msg_Account_Contact_Name", "Contact Name")
        End Get
    End Property
    'Public Const Account_Telephone As String = "Telephone"
    Public Shared ReadOnly Property Account_Telephone()
        Get
            obj = New ACCMessage
            Return obj.getResString("acc_msg_Account_Telephone", "Telephone")
        End Get
    End Property
    'Public Const Account_Fax As String = "Fax"
    Public Shared ReadOnly Property Account_Fax()
        Get
            obj = New ACCMessage
            Return obj.getResString("acc_msg_Account_Fax", "Fax")
        End Get
    End Property
    'Public Const Account_Email_Address As String = "Email"
    Public Shared ReadOnly Property Account_Email_Address()
        Get
            obj = New ACCMessage
            Return obj.getResString("acc_msg_Account_Email_Address", "Email")
        End Get
    End Property
    'Public Const Account_Notes As String = "Notes"
    Public Shared ReadOnly Property Account_Notes()
        Get
            obj = New ACCMessage
            Return obj.getResString("acc_msg_Account_Notes", "Notes")
        End Get
    End Property

    'Public Const Account_Renewable_Package As String = "Renewable Package(s)/Product(s)."
    Public Shared ReadOnly Property Account_Renewable_Package()
        Get
            obj = New ACCMessage
            Return obj.getResString("acc_msg_Account_Renewable_Package", "Renewable Package(s)/Product(s).")
        End Get
    End Property
    'Public Const Account_Upgraded_Package As String = "Upgraded Package(s)/Product(s)."
    Public Shared ReadOnly Property Account_Upgraded_Package()
        Get
            obj = New ACCMessage
            Return obj.getResString("acc_msg_Account_Upgraded_Package", "Upgraded Package(s)/Product(s).")
        End Get
    End Property

    'Public Const Account_Visit_InfiniPlan As String = "In order to access the InfiniPlan user manual, kindly visit:"
    Public Shared ReadOnly Property Account_Visit_InfiniPlan()
        Get
            obj = New ACCMessage
            Return obj.getResString("acc_msg_Account_Visit_InfiniPlan", "In order to access the InfiniPlan user manual, kindly visit:")
        End Get
    End Property
    'Public Const Account_Start_Date_Greater As String = "Start date' can't be greater than 'Expiry date"
    Public Shared ReadOnly Property Account_Start_Date_Greater()
        Get
            obj = New ACCMessage
            Return obj.getResString("acc_msg_Account_Start_Date_Greater", "Start date' can't be greater than 'Expiry date")
        End Get
    End Property

    'Public Const Account_Valid_Date_Greater As String = "Valid From date can't be greater than Expiry date"
    Public Shared ReadOnly Property Account_Valid_Date_Greater()
        Get
            obj = New ACCMessage
            Return obj.getResString("acc_msg_Account_Valid_Date_Greater", "Valid From date can't be greater than Expiry date")
        End Get
    End Property
    'Public Const Account_Pre_Requisites As String = "Pre-requisites :"
    Public Shared ReadOnly Property Account_Pre_Requisites()
        Get
            obj = New ACCMessage
            Return obj.getResString("acc_msg_Account_Pre_Requisites", "Pre-requisites :")
        End Get
    End Property
    'Public Const Account_Update_Services As String = "Update Services"
    Public Shared ReadOnly Property Account_Update_Services()
        Get
            obj = New ACCMessage
            Return obj.getResString("acc_msg_Account_Update_Services", "Update Services")
        End Get
    End Property
    'Public Const Account_Delivery_Address As String = "Delivery Address"
    Public Shared ReadOnly Property Account_Delivery_Address()
        Get
            obj = New ACCMessage
            Return obj.getResString("acc_msg_Account_Delivery_Address", "Delivery Address")
        End Get
    End Property

    'Public Const Account_Card_Holder_Name As String = "Card Holder Name"
    Public Shared ReadOnly Property Account_Card_Holder_Name()
        Get
            obj = New ACCMessage
            Return obj.getResString("acc_msg_Account_Card_Holder_Name", "Card Holder Name")
        End Get
    End Property

    'Public Const Account_Card_Number As String = "Card Number"
    Public Shared ReadOnly Property Account_Card_Number()
        Get
            obj = New ACCMessage
            Return obj.getResString("acc_msg_Account_Card_Number", "Card Number")
        End Get
    End Property

    'Public Const Account_Card_Address As String = "Card Address"
    Public Shared ReadOnly Property Account_Card_Address()
        Get
            obj = New ACCMessage
            Return obj.getResString("acc_msg_Account_Card_Address", "Card Address")
        End Get
    End Property
    'Public Const Account_Security_Code As String = "Security Code"
    Public Shared ReadOnly Property Account_Security_Code()
        Get
            obj = New ACCMessage
            Return obj.getResString("acc_msg_Account_Security_Code", "Security Code")
        End Get
    End Property

    'Public Const Account_Issue_No_Msg As String = "Issue number at most two digits long."
    Public Shared ReadOnly Property Account_Issue_No_Msg()
        Get
            obj = New ACCMessage
            Return obj.getResString("acc_msg_Account_Issue_No_Msg", "Issue number at most two digits long.")
        End Get
    End Property
    'Public Const Account_Issue_No As String = "Issue No."
    Public Shared ReadOnly Property Account_Issue_No()
        Get
            obj = New ACCMessage
            Return obj.getResString("acc_msg_Account_Issue_No", "Issue No.")
        End Get
    End Property

    'Public Const Account_Bank_Name As String = "Bank Name"
    Public Shared ReadOnly Property Account_Bank_Name()
        Get
            obj = New ACCMessage
            Return obj.getResString("acc_msg_Account_Bank_Name", "Bank Name")
        End Get
    End Property
    'Public Const Account_Cheque_No As String = "Cheque No."
    Public Shared ReadOnly Property Account_Cheque_No()
        Get
            obj = New ACCMessage
            Return obj.getResString("acc_msg_Account_Cheque_No", "Cheque No.")
        End Get
    End Property

    'Public Const Account_Sort_Code As String = "Sort Code"
    Public Shared ReadOnly Property Account_Sort_Code()
        Get
            obj = New ACCMessage
            Return obj.getResString("acc_msg_Account_Sort_Code", "Sort Code")
        End Get
    End Property
    'Public Const Account_Transaction_Reference_No As String = "Transaction Reference No."
    Public Shared ReadOnly Property Account_Transaction_Reference_No()
        Get
            obj = New ACCMessage
            Return obj.getResString("acc_msg_Account_Transaction_Reference_No", "Transaction Reference No.")
        End Get
    End Property
    'Public Const Account_Service_Name As String = "Service Name"
    Public Shared ReadOnly Property Account_Service_Name()
        Get
            obj = New ACCMessage
            Return obj.getResString("acc_msg_Account_Service_Name", "Service Name")
        End Get
    End Property

    'Public Const Account_Description As String = "Description"
    Public Shared ReadOnly Property Account_Description()
        Get
            obj = New ACCMessage
            Return obj.getResString("acc_msg_Account_Description", "Description")
        End Get
    End Property

    'Public Const Account_Register_User As String = "Dear valued customer," & vbCrLf & vbCrLf & _
    '                "We have received your account information provided by you through " & vbCrLf & _
    '                "http://www.infinibiz.com" & vbCrLf & vbCrLf & _
    '                "Your request of account activation is under process and you will receive a " & _
    '                "user id and password for login purposes via another email within 24 hours. " & vbCrLf & vbCrLf & _
    '                "For further information and assistance regarding our services, " & vbCrLf & vbCrLf & _
    '                "Email:   support@infinibiz.com" & vbCrLf & _
    '                "Phone:   +44 (0)207 016 2729 (9am - 1pm on weekdays)"
    Public Shared ReadOnly Property Account_Register_User()
        Get
            Dim str As String
            obj = New ACCMessage
            str = obj.getResString("Account_Register_User1", "Dear valued customer,") + "," + vbCrLf + vbCrLf + obj.getResString("Account_Register_User2", "We have received your account" + _
            " information provided by you through ") + vbCrLf + "http://www.infinibiz.com" + vbCrLf + vbCrLf + _
            obj.getResString("Account_Register_User3", "Your request of account activation is under process and you will receive a " + _
            "user id and password for login purposes via another email within 24 hours.") + vbCrLf + vbCrLf + obj.getResString("Account_Register_User4", "For further information and assistance regarding our services,") + vbCrLf + vbCrLf
            str += obj.getResString("acc_msg_Account_Email_Address", "Email:") + "support@infinibiz.com" + vbCrLf
            str += obj.getResString("acc_msg_Account_Telephone", "Phone:") + "+44 (0)207 016 2729 (9am - 1pm on weekdays)"
            Return str
        End Get
    End Property

    'NEW PROPERTY CREATED BY ADNAN 15-JAN-2007
    Public Shared ReadOnly Property ACC_Email_Messages()
        Get
            Dim str As String
            obj = New ACCMessage
            str = "<style> .user-data   { font-family: Verdana; font-size: 10pt; text-decoration: none }</style><p>"
            str += obj.getResString("acc_msg_welcome", "Thank you for registering with InfiniBiz." + "<br>" + _
             " You can log in to your account at <a href=""https://services.infinibiz.com"">https://services.infinibiz.com</a> with the following credentials:") + "<br><br>" + _
            "<table class=""user-data""><tr><td>" + _
             obj.getResString("acc_msg_name", "Name") + "<b>:[Name]</b><br></td></tr><tr><td>" + _
            obj.getResString("acc_msg_loginid", "Login ID") + "<b>:[LoginID]</b><br></td></tr><tr><td>" + _
             obj.getResString("acc_msg_Account_Password", "Password") + "<b>:[Password]</b><br></td></tr><tr><td>" + _
            obj.getResString("acc_msg_address", "Address") + "<b>:[Address]</b><br></td></tr></table><br>" + _
             obj.getResString("acc_msg_welcomeservice", "You have applied for the following service(s):") + "<br><br><p>" + _
              "<b>[ServicesInformation]</b> <br>" + _
             obj.getResString("acc_msg_welcomeend", "You will receive an email informing you of confirmation of receipt, along with activation of subscribed services, generally within 24 working hours.") + "<br><br>" + _
             obj.getResString("acc_msg_regards", "Regards,") + "<br>" + _
             obj.getResString("acc_msg_Account_Register_User4", "For further information and assistance regarding our services,") + "<br><br>" + _
             obj.getResString("acc_lblemail", "Email") + "<b>:support@infinibiz.com</b><br>" + _
            obj.getResString("acc_msg_Account_Telephone", "TelePhone") + ":+44 (0)207 016 2729 (9am - 1pm on weekdays)" + "</p></span>"
            Return str
        End Get
    End Property
#End Region
#Region ":::::::::::::Employee related messages::::::::::::::::::::::::::::::::"
    ' Employee related messages.
    '---------------------------------
    ' Public Const Employee_EmployeeRecordNotFound As String = "No employee record (s) found. Please first add your employee detail and then proceed further. "
    Public Shared ReadOnly Property Employee_EmployeeRecordNotFound()
        Get
            obj = New ACCMessage
            Return obj.getResString("acc_msg_Employee_EmployeeRecordNotFound", "No employee record (s) found. Please first add your employee detail and then proceed further. ")
        End Get
    End Property
    ' Public Const Employee_NewEmployeeCreated As String = "New employee information has been saved."
    Public Shared ReadOnly Property Employee_NewEmployeeCreated()
        Get
            obj = New ACCMessage
            Return obj.getResString("acc_msg_Employee_NewEmployeeCreated", "New employee information has been saved.")
        End Get
    End Property
#End Region
#Region ":::::::::::::::Taxation related messages::::::::::::::::::::::"
    ' Taxation related messages.
    '---------------------------------

    ' P11 Tax messages.
    'Public Const Taxation_P11Tax_ErrorInCalculation As String = "There are some error in calculations"
    Public Shared ReadOnly Property Taxation_P11Tax_ErrorInCalculation()
        Get
            obj = New ACCMessage
            Return obj.getResString("acc_msg_Taxation_P11Tax_ErrorInCalculation", "There are some error in calculations")
        End Get
    End Property
    'Public Const Taxation_P11Tax_ErrorInDate As String = "Enter the Correct Date Format"
    Public Shared ReadOnly Property Taxation_P11Tax_ErrorInDate()
        Get
            obj = New ACCMessage
            Return obj.getResString("acc_msg_Taxation_P11Tax_ErrorInDate", "Enter the Correct Date Format")
        End Get
    End Property
#End Region
#Region ":::::::::::::P11 NIC messages / PAYE scheme forms related messages::::::::::::::::::::::::"
    ' P11 NIC messages.
    'Public Const Taxation_P11NIC_EarningDetailsNotFound As String = "Earning details are not found to calculate NIC"
    Public Shared ReadOnly Property Taxation_P11NIC_EarningDetailsNotFound()
        Get
            obj = New ACCMessage
            Return obj.getResString("acc_msg_Taxation_P11NIC_EarningDetailsNotFound", "Earning details are not found to calculate NIC")
        End Get
    End Property


    ' PAYE scheme forms related messages.
    '----------------------------------------------
    'Public Const PAYE_InYearForm_NewFormCreated As String = "Information has been saved."
    Public Shared ReadOnly Property PAYE_InYearForm_NewFormCreated()
        Get
            obj = New ACCMessage
            Return obj.getResString("acc_msg_PAYE_InYearForm_NewFormCreated", "Information has been saved.")
        End Get
    End Property
#End Region
#Region "::::::::::::::::General messages:::::::::::::::::::::"
    'General messages.
    '---------------------
    'Public Const General_ThankYou As String = "Thank you."
    Public Shared ReadOnly Property General_ThankYou()
        Get
            obj = New ACCMessage
            Return obj.getResString("acc_msg_General_ThankYou", "Thank you.")
        End Get
    End Property
    'Public Const General_Update As String = "Thank you. The record has been successfully updated."
    Public Shared ReadOnly Property General_Update()
        Get
            obj = New ACCMessage
            Return obj.getResString("acc_msg_General_Update", "Thank you. The record has been successfully updated.")
        End Get
    End Property
    'Public Const General_Add As String = "Thank you. The record has been successfully added."
    Public Shared ReadOnly Property General_Add()
        Get
            obj = New ACCMessage
            Return obj.getResString("acc_msg_General_Add", "Thank you. The record has been successfully added.")
        End Get
    End Property
    'Public Const General_Save As String = "Thank you. The record has been successfully saved."
    Public Shared ReadOnly Property General_Save()
        Get
            obj = New ACCMessage
            Return obj.getResString("acc_msg_General_Save", "Thank you. The record has been successfully saved.")
        End Get
    End Property
#End Region
#Region "::::::::::::::::'Error messages::::::::::::::::::::::"
    'Error messages:
    '-------------------
    'Public Const Error_RequiredFields As String = "Please enter the value in the required field(s)."
    Public Shared ReadOnly Property Error_RequiredFields()
        Get
            obj = New ACCMessage
            Return obj.getResString("acc_msg_Error_RequiredFields", "Please enter the value in the required field(s).")
        End Get
    End Property
    '   Public Const Error_RegularExpression As String = "Please enter the appropriate value in the given field(s)."
    Public Shared ReadOnly Property Error_RegularExpression()
        Get
            obj = New ACCMessage
            Return obj.getResString("acc_msg_Error_RegularExpression", "Please enter the appropriate value in the given field(s).")
        End Get
    End Property
#End Region
#Region "::::::::::::::::For Email , PDF Forms , Dates Message(s) :::::::::::::::::::::"
    'For Email
    '-----------
    '    Public Const Email_AccountRegistration As String = "Registration at Account Centre"
    Public Shared ReadOnly Property Email_AccountRegistration()
        Get
            obj = New ACCMessage
            Return obj.getResString("acc_msg_Email_AccountRegistration", "Registration at Account Centre")
        End Get
    End Property
    '  Public Const Email_UpdateServices As String = "Services Updation at Account Centre"
    Public Shared ReadOnly Property Email_UpdateServices()
        Get
            obj = New ACCMessage
            Return obj.getResString("acc_msg_Email_UpdateServices", "Services Updation at Account Centre")
        End Get
    End Property
    'Public Const Email_ResendPassword As String = "Sign-in information at Account Centre"
    Public Shared ReadOnly Property Email_ResendPassword()
        Get
            obj = New ACCMessage
            Return obj.getResString("acc_msg_Email_ResendPassword", "Sign-in information at Account Centre")
        End Get
    End Property
    '  Public Const Email_DefaultEmailAddress As String = "support@infinibiz.com"
    Public Shared ReadOnly Property Email_DefaultEmailAddress()
        Get
            obj = New ACCMessage
            Return obj.getResString("acc_msg_Email_DefaultEmailAddress", "support@infinibiz.com")
        End Get
    End Property
    'Public Const Email_ForgotPassword As String = "Your Sign-in information has been sent to your email address."
    Public Shared ReadOnly Property Email_ForgotPassword()
        Get
            obj = New ACCMessage
            Return obj.getResString("acc_msg_Email_ForgotPassword", "Your Sign-in information has been sent to your email address.")
        End Get
    End Property

    'For PDF Forms 
    '---------------
    ' Public Const PDF_NOTEXISTS As String = "PDF data for this user does not exists!"
    Public Shared ReadOnly Property PDF_NOTEXISTS()
        Get
            obj = New ACCMessage
            Return obj.getResString("acc_msg_PDF_NOTEXISTS", "PDF data for this user does not exists!")
        End Get
    End Property


    'Public Const Date_IncorrectDay As String = "Please enter the correct day of month."
    Public Shared ReadOnly Property Date_IncorrectDay()
        Get
            obj = New ACCMessage
            Return obj.getResString("acc_msg_Date_IncorrectDay", "Please enter the correct day of month.")
        End Get
    End Property
    'Public Const Date_GreaterDate As String = "Date can't be greater than current date."
    Public Shared ReadOnly Property Date_GreaterDate()
        Get
            obj = New ACCMessage
            Return obj.getResString("acc_msg_Date_GreaterDate", "Date can't be greater than current date.")
        End Get
    End Property
#End Region
End Class
