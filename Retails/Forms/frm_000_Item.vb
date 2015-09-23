Imports Retails.clsPublic
Imports System.Data.SqlClient
Imports System.IO

Public Class frm_000_Item

#Region "variable"
    Public myParent As frm_000_ItemList
    Public bolFormState As clsPublic.FormState
    Public itemCode As String
    Public speficificCode As String
    Dim oldCategory As String
    Dim item As New tbl_000_Item
    Dim ErrProvider As New ErrorProviderExtended
    Dim strImagePath As String


    Public _Picbox As Bitmap
#End Region


   
#Region "Procedure"

    Private Sub BrowsePhoto(ByVal pic As PictureBox)
        Try

            Dim dlg As New OpenFileDialog()
            dlg.Title = "Browse Photo"
            dlg.Filter = "All Picture Files)|*.jpg;*.bmp;*.jpeg;*.gif;*.png"
            Dim dlgRes As DialogResult = dlg.ShowDialog()

            'Ask user to select file.
            If dlgRes <> DialogResult.Cancel Then
                'Set image in picture box
                pic.ImageLocation = dlg.FileName
                strImagePath = dlg.FileName
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "BrowsePhoto")
        End Try

    End Sub

    Sub fillcombo()

        FillCombobox(cboActualUOM, "SELECT Unit FROM tbl_UOM", "tbl_UOM", "Unit", "Unit")
        FillCombobox(cboInventoryUOM, "SELECT Unit FROM tbl_UOM", "tbl_UOM", "Unit", "Unit")
        FillCombobox(cboWarehouse, "SELECT WHCode, WarehouseName FROM tbl_000_Warehouse", "tbl_000_Warehouse", "WarehouseName", "WHCode")
        FillCombobox(cboRack, "SELECt RackNo FROM  tbl_000_Rack ORDER BY dbo.AlphaNum(rackno)", "tbl_000_rack", "RackNo", "RackNo")

    End Sub

    Sub ActivateCommands(ByVal frmState As clsPublic.FormState)
        bolFormState = frmState

        With MainForm
            Select Case frmState
                Case FormState.AddState
                    .tsNew.Enabled = False
                    .tsEdit.Enabled = False
                    .tsDelete.Enabled = False
                    .tsSave.Enabled = True
                    .tsCancel.Enabled = True
                    .tsRefresh.Enabled = False
                    .tsClose.Enabled = False
                Case FormState.EditState
                    .tsNew.Enabled = False
                    .tsEdit.Enabled = False
                    .tsDelete.Enabled = False
                    .tsSave.Enabled = True
                    .tsCancel.Enabled = True
                    .tsRefresh.Enabled = False
                    .tsClose.Enabled = False
                Case FormState.ViewState
                    .tsNew.Enabled = True
                    .tsEdit.Enabled = True
                    .tsDelete.Enabled = True
                    .tsSave.Enabled = False
                    .tsCancel.Enabled = False
                    .tsRefresh.Enabled = True
                    .tsClose.Enabled = True
                Case FormState.LoadState
                    .tsNew.Enabled = True
                    .tsEdit.Enabled = False
                    .tsDelete.Enabled = False
                    .tsSave.Enabled = False
                    .tsCancel.Enabled = False
                    .tsRefresh.Enabled = True
                    .tsClose.Enabled = True
            End Select

        End With
    End Sub

    Private Sub LoadComboBox_SubCategory()
        Dim sqlConn As New SqlConnection(cnString)
        Dim sqlReader As SqlDataReader
        Dim sqlCommand As New SqlCommand("GetCategorySub '" & cboCategory.SelectedValue & "'", sqlConn)
        Dim dtLoading As New DataTable("tbl_000_SubCategory")

        Try
            sqlConn.Open()
            sqlReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection)
            dtLoading.Load(sqlReader)

            With cboSubCategory
                .ColumnNum = 2
                .ColumnWidth = "100;250"
                .GridLineHorizontal = True
                .GridLineVertical = True
                ''.SelectedIndex = -1
                .Items.Clear()
                .LoadingType = MTGCComboBox.CaricamentoCombo.DataTable
                .SourceDataString = New String(1) {"SubCategoryCode", "SubCategoryName"}
                .SourceDataTable = dtLoading
            End With

            ''cboSubCategory.SelectedValue = String.Empty
            cboSubCategory.Text = String.Empty
            txtSubCategory.Text = String.Empty
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "ERROR")
        End Try

    End Sub

    Private Sub LoadComboBox_DataTable()
        Dim sqlConn As New SqlConnection(cnString)
        Dim sqlReader As SqlDataReader
        Dim sqlCommand As New SqlCommand("GetItemCodes", sqlConn)
        Dim dtLoading As New DataTable("tbl_000_Item")

        Try



            sqlConn.Open()
            sqlReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection)
            dtLoading.Load(sqlReader)

            With cboItemCode
                .ColumnNum = 4
                .ColumnWidth = "100;250;0;0"
                .GridLineHorizontal = True
                .GridLineVertical = True
                ''.SelectedIndex = -1
                .Items.Clear()
                .LoadingType = MTGCComboBox.CaricamentoCombo.DataTable
                .SourceDataString = New String(3) {"ItemCode", "ItemName", "Category", "SubCategory"}
                .SourceDataTable = dtLoading
            End With

            sqlCommand = New SqlCommand("SELECT CategoryCode, CategoryName FROM tbl_000_Category", sqlConn)
            dtLoading = New DataTable("tbl_000_Category")
            sqlConn.Open()
            sqlReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection)
            dtLoading.Load(sqlReader)

            With cboCategory
                .ColumnNum = 2
                .ColumnWidth = "100;250"
                .GridLineHorizontal = True
                .GridLineVertical = True
                ''.SelectedIndex = -1
                .Items.Clear()
                .LoadingType = MTGCComboBox.CaricamentoCombo.DataTable
                .SourceDataString = New String(1) {"CategoryCode", "CategoryName"}
                .SourceDataTable = dtLoading
            End With

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "ERROR - Load")
        End Try
    End Sub

    Sub FillTextBox()
        If Not cboItemCode.SelectedValue Is Nothing Then
            txtItemName.Text = cboItemCode.SelectedItem.Col2
            cboCategory.SelectedValue = Split(cboItemCode.SelectedItem.Col3, " - ")(0)
            cboSubCategory.SelectedValue = Split(cboItemCode.SelectedItem.Col4, " - ")(0)
        Else
            txtItemName.Text = String.Empty
        End If
    End Sub

    Sub FillCategory()
        If Not cboCategory.SelectedValue Is Nothing Then
            txtCategory.Text = cboCategory.SelectedItem.Col2
        Else
            txtCategory.Text = String.Empty
        End If
        If oldCategory <> cboCategory.Text Then
            LoadComboBox_SubCategory()
        End If
    End Sub

    Sub FillSubCategory()
        If Not cboSubCategory.SelectedValue Is Nothing Then
            txtSubCategory.Text = cboSubCategory.SelectedItem.Col2
        Else
            txtSubCategory.Text = String.Empty
        End If
    End Sub

    Private Function GetCurrencCode(ByVal itemcode As String, ByVal category As String, ByVal subcategory As String) As Boolean
        Dim xConn As New SqlConnection
        xConn.ConnectionString = cnString
        xConn.Open()
        Dim xCommand As New SqlCommand("Select * from tbl_000_item", xConn)
        Dim xReader As SqlDataReader
        xReader = xCommand.ExecuteReader
        While xReader.Read
            If xReader("itemcode").ToString = itemcode Then
                If xReader("CategoryCode").ToString <> category Then
                    ErrProvider.SetError(txtCategory, "invalid to change category")
                    GetCurrencCode = False
                    Exit Function
                ElseIf xReader("SubCategoryCode").ToString <> subcategory Then
                    ErrProvider.SetError(txtSubCategory, "invalid to change sub category")
                    GetCurrencCode = False
                    Exit Function
                End If
                GetCurrencCode = True
            End If
        End While
        xConn.Close()
    End Function

    Sub SaveRecord()
        Try
            Dim param As New ArrayList
            param.Clear()
            If ErrProvider.CheckAndShowSummaryErrorMessage = False Then

            ElseIf bolFormState = FormState.AddState And isRecordExist("SELECT SpecificCode FROM tbl_000_Item_Sub WHERE SpecificCode='" & txtSpecificCode.Text.Trim & "'") Then
                ''MsgBox("Specific Code already exist.", MsgBoxStyle.Exclamation, "Duplicate")
                ErrProvider.SetError(txtSpecificCode, "Existing Specific Code")
            ElseIf bolFormState = FormState.AddState And isRecordExist("sp_Filter_TOC '" & txtTOCCode.Text & "'") Then
                ''MsgBox("Specific Code already exist.", MsgBoxStyle.Exclamation, "Duplicate")
                ErrProvider.SetError(txtTOCCode, "Existing TOC Code")
                'ElseIf bolFormState= FormState.AddState and 

            Else

                If cboItemCode.Text.Length <> 9 Then
                    ErrProvider.SetError(cboItemCode, "Item code must length of 9")
                    Exit Sub
                ElseIf txtSpecificCode.Text.Length <> 14 Then
                    ErrProvider.SetError(txtSpecificCode, "Specific code must length of 14")
                    Exit Sub
                End If



                If bolFormState = FormState.EditState Then
                    param = FetchData(param, "Select * from tbl_000_Item where ItemCode='" & cboItemCode.Text & "'", CommandType.Text)
                    If param Is Nothing Or param.Count = 0 Then
                    Else
                        If cboItemCode.Text = param(0).ToString Then
                            If cboCategory.Text <> param(2).ToString Then
                                ErrProvider.SetError(txtCategory, "invalid to change category")
                                Exit Sub
                            ElseIf cboSubCategory.Text <> param(3).ToString Then
                                ErrProvider.SetError(txtSubCategory, "invalid to change sub category")
                                Exit Sub
                            End If
                        End If
                    End If
                Else

                    If isRecordExist("select itemcode from tbl_000_item where itemcode='" & cboItemCode.Text & "'") Then
                        If GetCurrencCode(cboItemCode.Text, cboCategory.Text, cboSubCategory.Text) = False Then
                            Exit Sub
                        End If


                End If



                End If



                With item
                    .ItemCode = cboItemCode.Text
                    .ItemName = txtItemName.Text.Trim
                    .CategoryCode = cboCategory.SelectedValue
                    .SubCategoryCode = cboSubCategory.SelectedValue
                    .SpecificCode = txtSpecificCode.Text.Trim
                    .SpecificDescription = txtDescription.Text.Trim
                    .TOCCode = txtTOCCode.Text.Trim
                    .Usage = txtUsage.Text.Trim
                    .BrandType = txtBrandType.Text.Trim
                    .ProductCode = txtProductCode.Text.Trim
                    .ActualUOM = cboActualUOM.Text
                    .InventoryUOM = cboInventoryUOM.Text
                    .StockLevelQTY = IIf(txtStockLevelQTY.Text = String.Empty, 0, txtStockLevelQTY.Text)
                    .isActive = chkIsActive.Checked
                    .RackNo = cboRack.Text
                    .WHCode = cboWarehouse.SelectedValue

                    .isDefault = chckDefault.Checked

                    _OpenTransaction()
                    _Result = .Save(bolFormState = clsPublic.FormState.EditState, picPhoto)
                    _CloseTransaction(_Result)

                End With

                If _Result Then
                    MsgBox("Successfully Saved", MsgBoxStyle.Information, "Prompt")
                    With myParent
                        If .FillFindON = True Then
                            .ViewFilterBack()
                        Else
                            If MainForm.tsSearch.Text <> String.Empty Then
                                .RefreshRecord("GetItemSub '" & MainForm.tsSearch.Text & "'")
                            Else
                                .LoadComboBox_DataTable()
                                .cboItemCode.SelectedValue = cboItemCode.Text
                                .FillTextBox()
                                .RefreshRecord("GetItemSub '" & myParent.cboItemCode.Text & "'")
                                SelectDataGridViewRow(.dgList, 0, txtSpecificCode.Text.Trim)
                            End If

                        End If
                    End With

                    Me.Close()
                End If

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub ClearFields()
        txtSpecificCode.Text = String.Empty
        txtDescription.Text = String.Empty
        txtTOCCode.Text = String.Empty
        txtBrandType.Text = String.Empty
        txtUsage.Text = String.Empty
        txtStockLevelQTY.Text = String.Empty
        txtProductCode.Text = String.Empty
        cboActualUOM.SelectedIndex = -1
        cboInventoryUOM.SelectedIndex = -1
        chkIsActive.Checked = True
        picPhoto.Image = MainForm.picDefault.Image
        cboRack.SelectedIndex = -1
        cboWarehouse.SelectedIndex = -1
        cboCategory.SelectedIndex = -1
        cboSubCategory.SelectedIndex = -1

        ''dgWarehouse.Rows.Clear()
    End Sub

    Sub SetEditValue()

        Try
            With item
                .FetchRecord(itemCode, speficificCode)
                txtSpecificCode.Text = .SpecificCode
                txtDescription.Text = .SpecificDescription
                txtTOCCode.Text = .TOCCode
                txtBrandType.Text = .BrandType
                txtUsage.Text = .Usage
                txtStockLevelQTY.Text = .StockLevelQTY
                txtProductCode.Text = .ProductCode
                cboActualUOM.Text = .ActualUOM
                cboInventoryUOM.Text = .InventoryUOM
                chkIsActive.Checked = .isActive
                cboCategory.Text = .CategoryCode
                cboSubCategory.Text = .SubCategoryCode
                cboRack.Text = .RackNo
                chckDefault.Checked = .isDefault
                picPhoto.Image = _Picbox



            End With
            ''FillDataGrid(dgWarehouse, "SELECT WHCode,RackNo,isDefault FROM tbl_000_Item_Warehouse WHERE SpecificCode='" & speficificCode & "'", 0, 2)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


#End Region


#Region "GUI"

    Private Sub frm_000_Item_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        ErrProvider.ClearAllErrorMessages()
    End Sub

    Private Sub frm_000_Item_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            ProcessTabKey(True)
        ElseIf e.Control And e.KeyCode = Keys.S Then
            SaveRecord()
        End If
    End Sub

    Private Sub frm_000_Item_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With ErrProvider
            .Controls.Clear()
            .Controls.Add(cboItemCode, "Item Code")
            .Controls.Add(txtItemName, "Item Name")
            .Controls.Add(txtCategory, "Category")
            .Controls.Add(txtSubCategory, "Sub Category")
            .Controls.Add(txtSpecificCode, "Specific Code")
            .Controls.Add(txtDescription, "Description")
            .Controls.Add(txtUsage, "Usage")
            .Controls.Add(cboActualUOM, "Actual UOM")
            .Controls.Add(cboInventoryUOM, "Converted UOM")
            .Controls.Add(cboRack, "Rack No.")
            .Controls.Add(cboWarehouse, "Warehouse")
        End With

        LoadComboBox_DataTable()
        cboItemCode.SelectedValue = DBLookUp("Select ITemCode from tbl_000_Item_Sub where  SpecificCode='" & myParent.dgList.Item(1, myParent.dgList.CurrentRow.Index).Value & "'", "ItemCode")

        If bolFormState = clsPublic.FormState.AddState Then
            Call ClearFields()
            Call fillcombo()
            txtSpecificCode.ReadOnly = False
            txtStockLevelQTY.Text = 0
        Else
            Call ClearFields()
            cboItemCode.Show()
            Call fillcombo()
            itemCode = DBLookUp("Select ITemCode from tbl_000_Item_Sub where  SpecificCode='" & myParent.dgList.Item("colSpecificCode", myParent.dgList.CurrentRow.Index).Value & "'", "ItemCode")
            speficificCode = myParent.dgList.Item("colSpecificCode", myParent.dgList.CurrentRow.Index).Value
            Call SetEditValue()
            txtSpecificCode.ReadOnly = True
            txtItemName.Enabled = True
            cboItemCode.Text = itemCode
            txtSpecificCode.Text = speficificCode
        End If

    End Sub

    Private Sub cboItemCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboItemCode.SelectedIndexChanged
        Call FillTextBox()
    End Sub

    Private Sub cboItemCode_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboItemCode.Validated
        Call FillTextBox()
    End Sub

    Private Sub cboCategory_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCategory.Enter
        oldCategory = cboCategory.Text
    End Sub

    Private Sub cboCategory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCategory.SelectedIndexChanged
        FillCategory()
    End Sub

    Private Sub cboCategory_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCategory.Validated
        FillCategory()
    End Sub

    Private Sub cboSubCategory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSubCategory.SelectedIndexChanged
        Call FillSubCategory()
    End Sub

    Private Sub cboSubCategory_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSubCategory.Validated
        Call FillSubCategory()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Call SaveRecord()
    End Sub

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        Call BrowsePhoto(picPhoto)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
      
        Call fillcombo()
        Me.Refresh()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
      
        Call fillcombo()
        Me.Refresh()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
      
        FillCombobox(cboRack, "SELECt RackNo FROM  tbl_000_Rack ORDER BY dbo.AlphaNum(rackno)", "tbl_000_rack", "RackNo", "RackNo")
        Me.Refresh()
    End Sub

    Private Sub chckDefault_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chckDefault.CheckedChanged
        If chckDefault.Checked = True Then
            txtdefault.Visible = True
        Else
            txtdefault.Visible = False
        End If
    End Sub

    Private Sub chckDefault_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles chckDefault.Validated
        If chckDefault.Checked = True Then
            txtdefault.Visible = True
        Else
            txtdefault.Visible = False
        End If
    End Sub

#End Region
End Class