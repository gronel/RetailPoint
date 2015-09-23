Imports System.Data.SqlClient
Imports TOPCInventorySales.clsPublic
Public Class frmActUnit
#Region "Variable"

    Dim myCon As SqlConnection = New SqlConnection(cnString)
    Public mysender As String
    Dim clsutility As New clsUtility
    Dim bolFormState As clsPublic.FormState
    Dim UpdatePending As Boolean = False

    ''for Unit Only
    Dim Uda As SqlDataAdapter = New SqlDataAdapter("Select Unit from  tbl_UOM ORDER BY dbo.AlphaNum(Unit)", myCon)
    Dim Ucb As SqlCommandBuilder = New SqlCommandBuilder(Uda)
    Dim Uds As DataSet = New DataSet()

    ''For RackNo Only
    Dim Rda As SqlDataAdapter = New SqlDataAdapter("SELECT RackNo FROM  tbl_000_Rack ORDER BY dbo.AlphaNum(rackno)", myCon)
    Dim Rcb As SqlCommandBuilder = New SqlCommandBuilder(Rda)
    Dim Rds As DataSet = New DataSet()

    ''For Product Unit 
    Dim Pda As SqlDataAdapter = New SqlDataAdapter("SELECT Unit FROM tbl_Product_UOM ORDER BY dbo.AlphaNum(Unit)", myCon)
    Dim Pcd As SqlCommandBuilder = New SqlCommandBuilder(Pda)
    Dim Pds As DataSet = New DataSet

#End Region

#Region "Procedure"

    '-->product unit
    Private Sub FillProductUnit(ByVal dg As DataGridView)
        Pds.Clear()
        Pda.Fill(Pds, "tbl_Product_UOM")
        dg.DataSource = Pds.Tables(0)

    End Sub

    '--> Rack
    Private Sub fillRack(ByVal dg As DataGridView)
        Rds.Clear()
        Rda.Fill(Rds, "tbl_000_Rack")
        dg.DataSource = Rds.Tables(0)
    End Sub

    '--> item unit
    Private Sub fillUnit(ByVal dg As DataGridView)
        Uds.Clear()
        Uda.Fill(Uds, "tbl_UOM")
        dg.DataSource = Uds.Tables(0)
    End Sub

    Private Function UpdateRack() As Boolean

        Try
            Rda.Update(Rds, "tbl_000_Rack")

            Return True
        Catch ex As Exception
            MsgBox("Saving unsuccessful" & "   " & ex.Message, MsgBoxStyle.Exclamation, "Error")
            Return False
        End Try

    End Function

    Private Function UpdateUnit() As Boolean
        Try
            Uda.Update(Uds, "tbl_UOM")

            Return True
        Catch ex As Exception
            MsgBox("Saving unsuccessful" & "   " & ex.Message, MsgBoxStyle.Exclamation, "Error")
            Return False
        End Try

    End Function

    Private Function UpdateProductUnit() As Boolean
        Try
            Pda.Update(Pds, "tbl_Product_UOM")

            Return True

        Catch ex As Exception
            MsgBox("Saving unsuccessful" & "   " & ex.Message, MsgBoxStyle.Exclamation, "Error")
            Return False
        End Try

    End Function

    Sub RefreshRecord()

        If mysender = "Rack" Then
            fillRack(dgrack)
            lblcategory.Text = CountGridRows(dgrack)
        ElseIf mysender = "Item" Then
            fillUnit(dgUnit)
            lblcategory.Text = CountGridRows(dgUnit)
        ElseIf mysender = "Product" Then
            FillProductUnit(dgProductUnit)
            lblcategory.Text = CountGridRows(dgUnit)
        End If

    End Sub


#End Region

#Region "GUI"

    Private Sub frmActUnit_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        mysender = String.Empty
        frm_000_Item.fillcombo()
        Me.Text = String.Empty
    End Sub

    Private Sub frmActUnit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If mysender = "Rack" Then
            dgUnit.Visible = False
            dgrack.Visible = True
            dgProductUnit.Visible = False
        ElseIf mysender = "Item" Then
            dgUnit.Visible = True
            dgrack.Visible = False
            dgProductUnit.Visible = False
            Me.Text = "Item-Unit"
        ElseIf mysender = "Product" Then
            dgUnit.Visible = False
            dgrack.Visible = False
            Me.Text = "Product-Unit"
            dgProductUnit.Visible = True
        End If

        bolFormState = FormState.ViewState
        Call RefreshRecord()
    End Sub


    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click

        If mysender = "Rack" Then

        ElseIf mysender = "Item" Then
            frm_000_Item.fillcombo()
        ElseIf mysender = "Product" Then
            frm_000_Product.FillAllCombo()
        End If

        Me.Close()

    End Sub


    Private Sub dgUnit_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles dgUnit.CellValidating
        If dgUnit.CurrentCell.ColumnIndex = 1 Then
            If CheckCodeFromDatagridView(dgUnit, 1, e.FormattedValue.ToString, e.RowIndex, False) = True Then
                dgUnit.CancelEdit()
                MsgBox("Unit Name is already exists in the list.", MsgBoxStyle.Exclamation, "Existing Warehouse")

            End If
        ElseIf dgUnit.CurrentCell.ColumnIndex = 0 Then
            If CheckCodeFromDatagridView(dgUnit, 0, e.FormattedValue.ToString, e.RowIndex, False) = True Then
                dgUnit.CancelEdit()
                MsgBox("Unit ID is already exists in the list.", MsgBoxStyle.Exclamation, "Existing Warehouse")

            End If
        End If
    End Sub


    Private Sub dgrack_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles dgrack.CellValidating
        If dgrack.CurrentCell.ColumnIndex = 0 Then
            If CheckCodeFromDatagridView(dgrack, 0, e.FormattedValue.ToString, e.RowIndex, False) = True Then
                dgrack.CancelEdit()
                MsgBox("Rack No. is already exists in the list.", MsgBoxStyle.Exclamation, "Existing Warehouse")
            End If
        End If
    End Sub

    Private Sub dgrack_RowValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgrack.RowValidated
        UpdateRack()
        If mysender = "Rack" Then
            lblcategory.Text = CountGridRows(dgrack)
        Else

        End If

    End Sub

    Private Sub dgUnit_RowValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgUnit.RowValidated

        If mysender = "Item" Then
            Call UpdateUnit()
            lblcategory.Text = CountGridRows(dgUnit)
        Else

        End If

    End Sub

#End Region









    Private Sub dgProductUnit_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgProductUnit.CellContentClick

    End Sub

    Private Sub dgProductUnit_RowValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgProductUnit.RowValidated
        Call UpdateProductUnit()
        lblcategory.Text = CountGridRows(dgProductUnit)
    End Sub
End Class