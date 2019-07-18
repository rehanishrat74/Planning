#Region "Imports Libraries"

Imports System
Imports System.Data
Imports System.Configuration


#End Region


Public Class Cryptography

    Public Function EncryptKey() As String

        ' THIS FUNCTION HAS BEEN REMARKED BECAUSE WE WILL NO LONGER
        ' USE THE RSA DLL IN ACCOUNTS CENTRE. 
        ''***********************************************************
        '' ENCRYPTED KEY GENERATION

        'Dim strGKeyLocation, strCustomerKey, strGKey, strCipherText As String

        'Dim strGKeyLen As Integer = 1024

        'strCustomerKey = KeyGeN(strGKeyLen)
        'strGKey = strCustomerKey

        'Dim RSA As New RSADLL.Crypt()

        'strCipherText = RSA.Encrypt(strGKey, "11", "16637")

        'RSA = Nothing

        'Return strCipherText

    End Function

    Public Function KeyGen(ByVal iKeyLength As Integer)

        Dim i, s, k, iCount, strMyKey
        Dim lowerbound, upperbound As Long
        lowerbound = 123 '58 ' 35
        upperbound = 254 '122 ' 96
        Randomize()    ' Initialize random-number generator.
        For i = 1 To iKeyLength
            s = 255
            k = Int(((upperbound - lowerbound) + 1) * Rnd() + lowerbound)
            strMyKey = strMyKey & Chr(k) & ""
        Next
        KeyGen = strMyKey

    End Function

    Function EnCrypt(ByVal pstrPassword As String, ByVal pstrG_Key As String)

        Dim strChar, iKeyChar, iStringChar, iCryptChar, strEncrypted As String
        Dim i As Integer

        For i = 1 To Len(pstrPassword)

            iKeyChar = Asc(Mid(pstrG_Key, i, 1))
            iStringChar = Asc(Mid(pstrPassword, i, 1))
            iCryptChar = iKeyChar Xor iStringChar
            strEncrypted = strEncrypted & Chr(iCryptChar)

        Next

        Return strEncrypted

    End Function

    Function DeCrypt(ByVal strEncrypted As String, ByVal pstrG_Key As String)

        Dim strChar, iKeyChar, iStringChar, iDeCryptChar, strDecrypted As String
        Dim i As Integer

        For i = 1 To Len(strEncrypted)

            If (Mid(pstrG_Key, i, 1) <> "") Then
                iKeyChar = (Asc(Mid(pstrG_Key, i, 1)))
            End If

            iStringChar = Asc(Mid(strEncrypted, i, 1))

            iDeCryptChar = iKeyChar Xor iStringChar
            strDecrypted = strDecrypted & Chr(iDeCryptChar)

        Next

        DeCrypt = strDecrypted

    End Function



 

End Class
