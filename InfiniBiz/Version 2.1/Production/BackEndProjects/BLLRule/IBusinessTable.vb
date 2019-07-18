Public Interface IBusinessTable
    Inherits Infinilogic.Data.ISpreadTable
    ReadOnly Property IsEditable() As Boolean
    ReadOnly Property NeedsToBeSaved() As Boolean
    Function GetRowNumber(ByVal RowTitle As String) As Integer
    Function GetRowNumberFromFullName(ByVal RowName As String) As Integer
    Function InsertRow(ByVal Position As Integer, ByVal RowName As String) As Boolean
     Function DeleteRow(ByVal RowNumber As Integer) As Boolean


    Function RenameRow(ByVal RowNumber As Integer, ByVal NewName As String) As Boolean
    Sub Save()
    Function ApplyCellChanges(ByVal ChangedCells As Collection) As Boolean

    ' InfiniPlan 
    '< ProWeb>
    Function InsertProductWithPro(ByVal Position As Integer, ByVal RowName As String, ByVal Goods As Infinilogic.BusinessPlan.BLL.BusinessGoodsType) As Boolean
    Function DeleteProductWithPro(ByVal RowNumber As Integer) As Boolean
    Function RenameProductWithPro(ByVal RowNumber As Integer, ByVal NewName As String) As Boolean
    Function RowNum(ByVal RowNumber As Integer) As Object
End Interface


 
    