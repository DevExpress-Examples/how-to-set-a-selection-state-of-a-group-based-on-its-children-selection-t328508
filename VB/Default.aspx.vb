Imports DevExpress.Web
Imports System
Imports System.Data

Partial Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
    End Sub

    Protected Sub ASPxGridView1_CustomCallback(ByVal sender As Object, ByVal e As ASPxGridViewCustomCallbackEventArgs)
        Dim parameters() As String = e.Parameters.Split(";"c)
        Dim index As Integer = Integer.Parse(parameters(0))
        Dim isGroupRowSelected As Boolean = False
        Dim currentState As CheckState = DirectCast(System.Enum.Parse(GetType(CheckState), parameters(1)), CheckState)
        Select Case currentState
            Case CheckState.Indeterminate, CheckState.Checked
                isGroupRowSelected = True
            Case CheckState.Unchecked
                isGroupRowSelected = False
        End Select
        For i As Integer = 0 To ASPxGridView1.GetChildRowCount(index) - 1
            Dim row As DataRow = ASPxGridView1.GetChildDataRow(index, i)
            ASPxGridView1.Selection.SetSelectionByKey(row("ProductID"), isGroupRowSelected)
        Next i
    End Sub

    Protected Sub cb_Init(ByVal sender As Object, ByVal e As EventArgs)
        Dim checkBox As ASPxCheckBox = TryCast(sender, ASPxCheckBox)
        Dim container As GridViewGroupRowTemplateContainer = TryCast(checkBox.NamingContainer, GridViewGroupRowTemplateContainer)
        checkBox.ClientSideEvents.CheckedChanged = String.Format("function(s, e){{ grid.PerformCallback('{0};' + s.GetCheckState()); }}", container.VisibleIndex)
    End Sub

    Protected Sub cb_Load(ByVal sender As Object, ByVal e As EventArgs)
        Dim checkBox As ASPxCheckBox = TryCast(sender, ASPxCheckBox)
        Dim container As GridViewGroupRowTemplateContainer = TryCast(checkBox.NamingContainer, GridViewGroupRowTemplateContainer)
        If ASPxGridView1.Selection.Count <> 0 Then
            Dim rowInGroupCount As Integer = ASPxGridView1.GetChildRowCount(container.VisibleIndex)
            Dim countToCompare As Integer = 0
            For j As Integer = 0 To rowInGroupCount - 1
                Dim row As DataRow = ASPxGridView1.GetChildDataRow(container.VisibleIndex, j)
                Dim key = row("ProductID")
                If ASPxGridView1.Selection.IsRowSelectedByKey(key) Then
                    countToCompare += 1
                End If
            Next j
            If rowInGroupCount = countToCompare Then
                checkBox.CheckState = CheckState.Checked
            ElseIf rowInGroupCount > countToCompare AndAlso countToCompare <> 0 Then
                checkBox.CheckState = CheckState.Indeterminate
            ElseIf countToCompare = 0 Then
                checkBox.CheckState = CheckState.Unchecked
            End If
        Else
            checkBox.CheckState = CheckState.Unchecked
        End If
    End Sub
End Class