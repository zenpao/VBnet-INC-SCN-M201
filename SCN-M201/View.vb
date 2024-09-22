Imports System.Data.OleDb

Public Class frmView

    Dim objConn As OleDbConnection = New OleDbConnection(" Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\dbM201.mdb")
    Dim objComm As OleDbCommand
    Dim objAdap As OleDbDataAdapter
    Dim objDt As DataTable

    Private Sub frmView_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Reload()
        frmMod.Clear()

    End Sub

    Private Sub btn_SEARCH_Click(sender As Object, e As EventArgs) Handles btn_SEARCH.Click

        Try
            objConn.Open()
            objComm = New OleDbCommand("SELECT [STATUS], [NAME_LAST], [NAME_FIRST], [NAME_MIDDLE], [NICKNAME], [BIRTH_DATE], [BIRTH_PLACE], [GENDER], [CITIZENSHIP], [CIVIL_STATUS], [BLOOD_TYPE], [ADDRESS_RESIDENTIAL], [ADDRESS_PROVINCIAL], [NUMBER_MOBILE], [NUMBER_TELEPHONE], [EMAIL], [CODE_DISTRICT], [CODE_LOCAL], [DATE_BAPTISM], [CURRENT_CHURCH], [INTERNAL_SIGN], [SCAN_DESIGNATION], [MEMBER_SINCE], [RADIO_LICENSE], [COMM_EQUIPMENT], [AMATEUR_SIGN], [WORK_COMPANY], [WORK_ADDRESS], [WORK_DESIGNATION], [WORK_NUMBER], [HIGHEST_EDUCATION], [COURSES], [YEAR_GRADUATED], [ORG_AFFILIATIONS], [DATE_FILED], [DB_ID] FROM tblMemberInfo WHERE NAME_LAST LIKE '" & NAME_LAST.Text & "%'", objConn)
            objAdap = New OleDbDataAdapter(objComm)
            objDt = New DataTable
            objAdap.Fill(objDt)

            If objDt.Rows.Count > 0 Then
                DataGridView1.DataSource = objDt
            Else
                MsgBox("No records found.", MsgBoxStyle.OkOnly, "Empty")
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox("Fill-in the correct filter", MsgBoxStyle.Exclamation, "Something went wrong")
        Finally
            If objConn.State = ConnectionState.Open Then
                objConn.Close()
                NAME_LAST.Clear()
            End If
        End Try


    End Sub

    Private Sub btn_RELOAD_Click(sender As Object, e As EventArgs) Handles btn_RELOAD.Click

        Reload()

    End Sub

    Private Sub btn_UPDATE_Click(sender As Object, e As EventArgs) Handles btn_UPDATE.Click

        Try
            For Each r As DataGridViewRow In DataGridView1.Rows
                If (r.Cells.Item("Box").Value) = True Then
                    frmMod.DB_IDmod = r.Cells.Item("DB_ID").Value
                    frmMod.GENDERmod = r.Cells.Item("GENDER").Value.ToString
                    frmMod.CIVIL_STATUSmod = r.Cells.Item("CIVIL_STATUS").Value.ToString
                    frmMod.HIGHEST_EDUCATIONmod = r.Cells.Item("HIGHEST_EDUCATION").Value.ToString
                    frmMod.IMAGEmod = r.Cells.Item("IMAGE").Value
                    frmMod.NAME_LAST.Text = r.Cells.Item("NAME_LAST").Value.ToString
                    frmMod.NAME_FIRST.Text = r.Cells.Item("NAME_FIRST").Value.ToString
                    frmMod.NAME_MIDDLE.Text = r.Cells.Item("NAME_MIDDLE").Value.ToString
                    frmMod.NICKNAME.Text = r.Cells.Item("NICKNAME").Value.ToString
                    frmMod.DateTimePicker1.Text = r.Cells.Item("BIRTH_DATE").Value
                    frmMod.BIRTH_PLACE.Text = r.Cells.Item("BIRTH_PLACE").Value.ToString
                    frmMod.CITIZENSHIP.Text = r.Cells.Item("CITIZENSHIP").Value
                    frmMod.BLOOD_TYPE.Text = r.Cells.Item("BLOOD_TYPE").Value
                    frmMod.ADDRESS_RESIDENTIAL.Text = r.Cells.Item("ADDRESS_RESIDENTIAL").Value.ToString
                    frmMod.ADDRESS_PROVINCIAL.Text = r.Cells.Item("ADDRESS_PROVINCIAL").Value.ToString
                    frmMod.NUMBER_MOBILE.Text = r.Cells.Item("NUMBER_MOBILE").Value
                    frmMod.NUMBER_TELEPHONE.Text = r.Cells.Item("NUMBER_MOBILE").Value
                    frmMod.EMAIL.Text = r.Cells.Item("EMAIL").Value
                    frmMod.CODE_DISTRICT.Text = r.Cells.Item("CODE_DISTRICT").Value
                    frmMod.CODE_LOCAL.Text = r.Cells.Item("CODE_LOCAL").Value
                    frmMod.DateTimePicker2.Text = r.Cells.Item("DATE_BAPTISM").Value
                    frmMod.CURRENT_CHURCH.Text = r.Cells.Item("CURRENT_CHURCH").Value.ToString
                    frmMod.INTERNAL_SIGN.Text = r.Cells.Item("INTERNAL_SIGN").Value
                    frmMod.SCAN_DESIGNATION.Text = r.Cells.Item("SCAN_DESIGNATION").Value.ToString
                    frmMod.MEMBER_SINCE.Text = r.Cells.Item("MEMBER_SINCE").Value
                    frmMod.RADIO_LICENSE.Text = r.Cells.Item("RADIO_LICENSE").Value
                    frmMod.COMM_EQUIPMENT.Text = r.Cells.Item("COMM_EQUIPMENT").Value.ToString
                    frmMod.AMATEUR_SIGN.Text = r.Cells.Item("AMATEUR_SIGN").Value
                    frmMod.WORK_COMPANY.Text = r.Cells.Item("WORK_COMPANY").Value.ToString
                    frmMod.WORK_ADDRESS.Text = r.Cells.Item("WORK_ADDRESS").Value.ToString
                    frmMod.WORK_DESIGNATION.Text = r.Cells.Item("WORK_DESIGNATION").Value.ToString
                    frmMod.WORK_NUMBER.Text = r.Cells.Item("WORK_NUMBER").Value
                    frmMod.COURSES.Text = r.Cells.Item("COURSES").Value.ToString
                    frmMod.YEAR_GRADUATED.Text = r.Cells.Item("YEAR_GRADUATED").Value
                    frmMod.ORG_AFFILIATIONS.Text = r.Cells.Item("ORG_AFFILIATIONS").Value.ToString
                    frmMod.TRAININGS_SEMINARS.Text = r.Cells.Item("TRAININGS_SEMINARS").Value
                    frmMod.SPECIAL_SKILLS.Text = r.Cells.Item("SPECIAL_SKILLS").Value.ToString
                    frmMod.DateTimePicker3.Text = r.Cells.Item("DATE_FILED").Value
                    frmMod.STATUS.Text = r.Cells.Item("STATUS").Value.ToString

                    If (frmMod.GENDERmod = "M") Then
                        frmMod.GENDER.SelectedIndex() = 0
                    Else
                        frmMod.GENDER.SelectedIndex() = 1
                    End If

                    If (frmMod.CIVIL_STATUSmod = "Single") Then
                        frmMod.CIVIL_STATUS.SelectedIndex() = 0
                    ElseIf (frmMod.CIVIL_STATUSmod = "Married") Then
                        frmMod.CIVIL_STATUS.SelectedIndex() = 1
                    ElseIf (frmMod.CIVIL_STATUSmod = "Widowed") Then
                        frmMod.CIVIL_STATUS.SelectedIndex() = 2
                    Else
                        frmMod.CIVIL_STATUS.SelectedIndex() = 3
                    End If

                    If (frmMod.HIGHEST_EDUCATIONmod = "None") Then
                        frmMod.HIGHEST_EDUCATION.SelectedIndex() = 0
                    ElseIf (frmMod.HIGHEST_EDUCATIONmod = "Elementary") Then
                        frmMod.HIGHEST_EDUCATION.SelectedIndex() = 1
                    ElseIf (frmMod.HIGHEST_EDUCATIONmod = "Some Elementary") Then
                        frmMod.HIGHEST_EDUCATION.SelectedIndex() = 2
                    ElseIf (frmMod.HIGHEST_EDUCATIONmod = "Some High School") Then
                        frmMod.HIGHEST_EDUCATION.SelectedIndex() = 3
                    ElseIf (frmMod.HIGHEST_EDUCATIONmod = "High School degree") Then
                        frmMod.HIGHEST_EDUCATION.SelectedIndex() = 4
                    ElseIf (frmMod.HIGHEST_EDUCATIONmod = "Some College, no degree") Then
                        frmMod.HIGHEST_EDUCATION.SelectedIndex() = 5
                    ElseIf (frmMod.HIGHEST_EDUCATIONmod = "Associate degree") Then
                        frmMod.HIGHEST_EDUCATION.SelectedIndex() = 6
                    ElseIf (frmMod.HIGHEST_EDUCATIONmod = "Bachelorʼs degree") Then
                        frmMod.HIGHEST_EDUCATION.SelectedIndex() = 7
                    ElseIf (frmMod.HIGHEST_EDUCATIONmod = "Masterʼs degree") Then
                        frmMod.HIGHEST_EDUCATION.SelectedIndex() = 8
                    ElseIf (frmMod.HIGHEST_EDUCATIONmod = "Professional degree") Then
                        frmMod.HIGHEST_EDUCATION.SelectedIndex() = 9
                    Else
                        frmMod.HIGHEST_EDUCATION.SelectedIndex() = 10
                    End If

                    If (frmMod.IMAGEmod <> "\res\blank-profile.jpg") Then
                        frmMod.imgFIN = frmMod.IMAGEmod
                        frmMod.PictureBox1.BackgroundImage = Image.FromFile(frmMod.IMAGEmod)
                        frmMod.PictureBox1.BackgroundImageLayout = ImageLayout.Zoom
                    End If

                    frmMod.ShowDialog()
                    'UpdateDataGrid(False) 'TRIGGER TRUE/UNCOMMENT ONLY IF THIS HAS IMPORTANT CHANGED THAT NEEDS TO BE SEEN RIGHT AWAY AFTER CLOSING NEXT FORM. ELSE THIS PRODUCES AN ERROR IN VALUE!!
                    Return
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox("Select one at a time.")
        End Try

    End Sub

    Public Sub Reload()

        NAME_LAST.Clear()

        Try
            objConn.Open()
            objComm = New OleDbCommand("SELECT [STATUS], [NAME_LAST], [NAME_FIRST], [NAME_MIDDLE], [NICKNAME], [BIRTH_DATE], [BIRTH_PLACE], [GENDER], [CITIZENSHIP], [CIVIL_STATUS], [BLOOD_TYPE], [ADDRESS_RESIDENTIAL], [ADDRESS_PROVINCIAL], [NUMBER_MOBILE], [NUMBER_TELEPHONE], [EMAIL], [CODE_DISTRICT], [CODE_LOCAL], [DATE_BAPTISM], [CURRENT_CHURCH], [INTERNAL_SIGN], [SCAN_DESIGNATION], [MEMBER_SINCE], [RADIO_LICENSE], [COMM_EQUIPMENT], [AMATEUR_SIGN], [WORK_COMPANY], [WORK_ADDRESS], [WORK_DESIGNATION], [WORK_NUMBER], [HIGHEST_EDUCATION], [COURSES], [YEAR_GRADUATED], [ORG_AFFILIATIONS], [TRAININGS_SEMINARS], [SPECIAL_SKILLS], [DATE_FILED], [IMAGE], [DB_ID] FROM tblMemberInfo", objConn)
            objAdap = New OleDbDataAdapter(objComm)
            objDt = New DataTable
            objAdap.Fill(objDt)

            If objDt.Rows.Count > 0 Then
                DataGridView1.DataSource = objDt
            Else
                MsgBox("No records found.", MsgBoxStyle.OkOnly, "Empty")
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

            If objConn.State = ConnectionState.Open Then
                objConn.Close()
            End If
        End Try

    End Sub

    Private Sub frmView_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        DataGridView1.EndEdit()

    End Sub

End Class