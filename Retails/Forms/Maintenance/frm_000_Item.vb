Imports RetailPoint.clsPublic
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
    Public ItemId As Integer

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

        FillCombobox(cboLocation, "SELECT Id, (location +'-'+ description) as locName FROM tbl_000_Location", "tbl_000_Location", "locName", "Id")
        FillCombobox(cboCategory, "SELECT Id,itemCategory FROM tbl_000_ItemCategory", "tbl_000_ItemCategory", "itemCategory", "Id")
        
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



  


    Sub SaveRecord()
        Try
            Dim param As New ArrayList
            param.Clear()
            If ErrProvider.CheckAndShowSummaryErrorMessage = False Then

            ElseIf bolFormState = FormState.AddState And isRecordExist("SELECT ItemCode FROM tbl_000_Item WHERE ItemCode='" & txtcode.Text.Trim & "'") Then
                ''MsgBox("Specific Code already exist.", MsgBoxStyle.Exclamation, "Duplicate")
                ErrProvider.SetError(txtcode, "Existing Item Code")
          
            Else

                With item
                    .ItemId = ItemId
                    .ItemCode = txtcode.Text
                    .ItemName = txtName.Text.Trim
                    .ItemDescription = txtDesc.Text
                    .LocationId = cboLocation.SelectedValue
                    .ItemCategoryId = cboCategory.SelectedValue
                    .BrandType = txtBrand.Text.Trim
                    .UOM = txtUom.Text
                    .StockLevelQTY = txtSLQ.Text
                    .isActive = chkIsActive.Checked
                    .ItemImg = ImageToByte(picPhoto.Image)
                    .CreateBy = CurrUser.USER_FULLNAME
                    .CreateDte = Date.Today
                    .StackOH = 0
                    .IsConverted = chkboxConvert.Checked
                    .CostPrice = txtCost.Text
                    .SellingPrice = txtSellingPrice.Text

                    _OpenTransaction()
                    _Result = .Save(bolFormState = FormState.EditState)
                    _CloseTransaction(_Result)

                End With

                If _Result Then
                    MsgBox("Successfully Saved", MsgBoxStyle.Information, "Prompt")
                    With myParent
                        If .FillFindON = True Then
                            .ViewFilterBack()
                        Else
                            .RefreshRecord("sproc_000_item_list '" & MainForm.tsSearch.Text & "'")

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
        txtName.Text = String.Empty
        txtcode.Text = String.Empty
        txtDesc.Text = String.Empty
        txtBrand.Text = String.Empty
        txtUom.Text = String.Empty
        txtSLQ.Text = 0
        txtCost.Text = 0
        txtSellingPrice.Text = 0
        chkboxConvert.Checked = False
        chkIsActive.Checked = True
        picPhoto.Image = MainForm.picDefault.Image
        cboLocation.SelectedIndex = -1
        cboCategory.SelectedIndex = -1

        ''dgWarehouse.Rows.Clear()
    End Sub

    Sub SetEditValue()

        Try
            With item
                .FetchRecord(itemCode)
                ItemId = .ItemId
                txtcode.Text = .ItemCode
                txtName.Text = .ItemName
                txtDesc.Text = .ItemDescription
                txtBrand.Text = .BrandType
                cboCategory.SelectedValue = .ItemCategoryId
                cboLocation.SelectedValue = .LocationId
                txtUom.Text = .UOM
                txtSLQ.Text = .StockLevelQTY
                chkIsActive.Checked = .isActive
                picPhoto.Image = BytesToImage(.ItemImg)
                txtCost.Text = .CostPrice
                txtSellingPrice.Text = .SellingPrice
                chkboxConvert.Checked = .IsConverted

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
            .Controls.Add(txtcode, "Item Code")
            .Controls.Add(txtName, "Item Name")
            .Controls.Add(cboCategory, "Category")
            .Controls.Add(cboLocation, "Location")
            .Controls.Add(txtUom, "Unit Of Measure")
            .Controls.Add(txtSLQ, "Stock Level Quantity")
            .Controls.Add(txtCost, "Cost Price")
            .Controls.Add(txtSellingPrice, "Selling Price")

        End With

        
        If bolFormState = clsPublic.FormState.AddState Then
            Call ClearFields()
            Call fillcombo()
            txtcode.ReadOnly = False
            cboLocation.SelectedIndex = -1
            cboCategory.SelectedIndex = -1
            Me.Text = "New Item Entry Form"
            ItemId = 0


        Else
            Me.Text = "Update Item Entry Form"
            Call ClearFields()
            txtcode.ReadOnly = True

            Call fillcombo()
            itemCode = myParent.dgList.Item("colitemcode", myParent.dgList.CurrentRow.Index).Value
            'speficificCode = myParent.dgList.Item("colSpecificCode", myParent.dgList.CurrentRow.Index).Value
            Call SetEditValue()
   
        End If

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Call SaveRecord()
    End Sub

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        Call BrowsePhoto(picPhoto)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Call fillcombo()
        Me.Refresh()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Call fillcombo()
        Me.Refresh()
    End Sub

    

#End Region
End Class