Option Strict On
Option Explicit On 

#Region " Import Libraries "
Imports System
Imports System.Web
Imports System.Text
Imports System.Collections.Specialized
Imports System.Security.Cryptography

#End Region

Public Class SecureQueryString
    Inherits NameValueCollection

    Private Const cryptoKey As String = "poijwaefjkasfkjqwekg"
    Private IV As Byte() = New Byte(7) {240, 45, 78, 0, 12, 36, 99, 122}
    Private Const TimeStampKey As String = "lkjashdfkjhasdjfh"

    Dim _expireTime As DateTime = Now.MaxValue

#Region " Convstructors () "

    Public Sub New()
        MyBase.New()
    End Sub

#End Region

    Public Sub New(ByRef strEncryptedString As String)
        deserialize(decrypt(strEncryptedString))
        'Compare the Expiration Time with the current Time to ensure
        'that the queryString has not expired.
        If (DateTime.Compare(ExpireTime, Date.Now()) < 0) Then
            Throw New ExpiredQueryStringException
        End If

    End Sub

    Public Overrides Function ToString() As String
        Return EncryptedString
    End Function

    Private Function encrypt(ByRef strSerializedQueryString As String) As String

        Dim buffer As Byte() = Encoding.ASCII.GetBytes(strSerializedQueryString)
        Dim des As New TripleDESCryptoServiceProvider
        Dim MD5 As New MD5CryptoServiceProvider
        des.Key = MD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(cryptoKey))
        des.IV = IV
        Return Convert.ToBase64String( _
    des.CreateEncryptor().TransformFinalBlock( _
    buffer, _
    0, _
    buffer.Length))

    End Function

    Private Function decrypt(ByRef strEncryptedQueryString As String) As String
        Try
            Dim buffer As Byte() = Convert.FromBase64String(strEncryptedQueryString)
            Dim des As New TripleDESCryptoServiceProvider
            Dim MD5 As New MD5CryptoServiceProvider
            des.Key = MD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(cryptoKey))
            des.IV = IV
            Return Encoding.ASCII.GetString(des.CreateDecryptor().TransformFinalBlock( _
            buffer, _
            0, _
            buffer.Length))

        Catch cryptoExc As CryptographicException
            Throw New InvalidQueryStringException

        Catch fe As FormatException
            Throw New InvalidQueryStringException
        End Try
    End Function

    Private Function deserialize(ByRef strDecryptedQueryString As String) As String
        Dim nameValuePairs As String() = strDecryptedQueryString.Split("&"c)
        Dim i As Int32
        For i = 0 To nameValuePairs.Length - 1
            Dim namevalue As String() = nameValuePairs(i).Split("="c)
            If (namevalue.Length = 2) Then MyBase.Add(namevalue(0), namevalue(1))
        Next

        If MyBase.Item(timestampkey) <> "" Then _expireTime = DateTime.Parse(MyBase.Item(TimeStampKey))

    End Function

    Private Function serialize() As String
        Dim sb As New StringBuilder
        Dim strKey As String
        With sb

            For Each strKey In MyBase.AllKeys
                .Append(strKey)
                .Append("="c)
                .Append(MyBase.Item(strKey))
                .Append("&"c)
            Next
            .Append(timeStampKey)
            .Append("="c)
            .Append(_expireTime)
            Return .ToString
        End With

    End Function

#Region " Public Properties "

    Public ReadOnly Property EncryptedString() As String
        Get
            Return HttpUtility.UrlEncode(encrypt(serialize()))
        End Get
    End Property

    Public Property ExpireTime() As DateTime
        Get
            Return _expireTime
        End Get
        Set(ByVal Value As DateTime)
            _expireTime = Value
        End Set
    End Property

#End Region

End Class

Public Class ExpiredQueryStringException
    Inherits Exception

    Public Sub New()
        MyBase.New()
    End Sub
End Class

Public Class InvalidQueryStringException
    Inherits Exception

    Public Sub New()
        MyBase.New()
    End Sub
End Class

