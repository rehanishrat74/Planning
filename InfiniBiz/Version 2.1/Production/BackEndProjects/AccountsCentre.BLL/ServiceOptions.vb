#Region "Data Related to field Infinishopmaindb.AccountscentrePackage.PackageOptions"
'''ServiceOptions Enum is used only for Individual Products
Public Enum ServiceOptions As Long
    EnableSale = 1   'Product is enable for Sale
    'Next = 4
End Enum

'''ServiceOptions Enum is used only for Packages

Public Enum PackageOptions As Long
    EnableSale = 1  'Package is Avaiable for Sale

End Enum

#End Region

#Region "Data Related to field Infinishopmaindb.Service.Status"
Public Enum ACC_ServiceOptions As Long
    EnabledForCustomers = 1 'Enable/Disable Service for all customers
    DesktopApplication = 2   'Desktop/Web Application Type
    Downloadable = 4 'Service is available for Download
End Enum

#End Region
