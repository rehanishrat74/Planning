#Region " Import Libraries "
Imports System
Imports System.Collections.Specialized
Imports System.Security.Cryptography
Imports System.Text
Imports System.Web

#End Region

Public Class Encryptor

#Region " Shared Variables "

    Public Shared strCryptoKey As String '= "ChangeThis!" ' String.Empty
    Public Shared IV As Byte()
    Public Shared Key As Byte()
#End Region

#Region " Public Methods "


    Public Shared Function encrypt(ByVal strDataToEncrypt As String) As String
        SetParameters()
        Dim buffer As Byte() = Encoding.ASCII.GetBytes(strDataToEncrypt)
        Dim objDES As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider
        Dim md5 As MD5CryptoServiceProvider = New MD5CryptoServiceProvider
        Key = md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(strCryptoKey))
        objDES.Key = Key
        objDES.IV = IV
        Return Convert.ToBase64String(objDES.CreateEncryptor.TransformFinalBlock(buffer, 0, buffer.Length))

    End Function

    Public Shared Function decrypt(ByVal strEncryptedString As String) As String
        Try
            SetParameters()
            Dim buffer As Byte() = Convert.FromBase64String(strEncryptedString)
            Dim objDES As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider
            'Dim md5 As MD5CryptoServiceProvider = New MD5CryptoServiceProvider()
            'Key = md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(strCryptoKey))
            objDES.Key = Key
            objDES.IV = IV
            Return Encoding.ASCII.GetString(objDES.CreateDecryptor().TransformFinalBlock(buffer, 0, buffer.Length))
        Catch e As CryptographicException
            Throw New InvalidDataException
        Catch fe As FormatException
            Throw New InvalidDataException

        End Try

    End Function

    Public Shared Function decrypt(ByVal strEncryptedString As String, ByVal byteKeys As Byte()) As String
        Try
            Key = byteKeys
            SetParameters()
            Dim buffer As Byte() = Convert.FromBase64String(strEncryptedString)
            Dim objDES As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider
            ' Dim md5 As MD5CryptoServiceProvider = New MD5CryptoServiceProvider()
            objDES.Key = Key 'md5.ComputeHash(Key)
            objDES.IV = IV
            Return Encoding.ASCII.GetString(objDES.CreateDecryptor().TransformFinalBlock(buffer, 0, buffer.Length))
        Catch e As CryptographicException
            Throw New InvalidDataException
        Catch fe As FormatException
            Throw New InvalidDataException

        End Try

    End Function


#End Region

#Region " Private Functions "

    Shared Sub SetParameters()
        'strCryptoKey = "ChangeThis!__ndmt5cr4ptoke7lengthb84kr09fk49dk349dkt"
        ' Key = New Byte() {226, 252, 113, 76, 71, 39, 238, 147, 149, 243, 36, 205, 46, 127, 51, 31}
        IV = New Byte(7) {240, 3, 45, 219, 0, 176, 173, 59}

    End Sub
#End Region

#Region " public variables "

    Public Shared Property CryptoKey() As String
        Get
            Return strCryptoKey

        End Get
        Set(ByVal Value As String)
            strCryptoKey = Value
        End Set
    End Property
#End Region


End Class


Public Class InvalidDataException
    Inherits Exception

    Public Sub New()
        MyBase.New()
    End Sub

End Class

