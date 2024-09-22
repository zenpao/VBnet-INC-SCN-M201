Imports System.Data.OleDb

Public Class frmMod

    Dim objConn As OleDbConnection = New OleDbConnection(" Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\dbM201.mdb")
    Dim objComm As OleDbCommand
    Dim objAdap As OleDbDataAdapter
    Dim objDt As DataTable

    Friend DB_IDmod As String
    Friend GENDERmod As String
    Friend CIVIL_STATUSmod As String
    Friend HIGHEST_EDUCATIONmod As String
    Friend IMAGEmod As String

    Dim zero As String = "null"
    Dim defPATH As String = My.Application.Info.DirectoryPath
    Dim imgDEF As String = IO.Path.Combine(defPATH, "\res\blank-profile.jpg")
    Friend imgFIN As String

    Private Sub frmMod_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        frmView.NAME_LAST.Clear()
        GroupBox1.Text = DB_IDmod

    End Sub

    Private Sub lnk_DEFAULT_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnk_DEFAULT.LinkClicked

        PictureBox1.BackgroundImage = Nothing
        PictureBox1.BackColor = Color.Goldenrod
        PictureBox1.Invalidate()

        imgFIN = imgDEF

    End Sub

    Private Sub lnk_UNDO_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnk_UNDO.LinkClicked

        imgFIN = IMAGEmod
        PictureBox1.BackgroundImage = Image.FromFile(IMAGEmod)
        PictureBox1.BackgroundImageLayout = ImageLayout.Zoom

    End Sub

    Private Sub lnk_UPLOAD_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnk_UPLOAD.LinkClicked

        Dim result As DialogResult = OpenFileDialog1.ShowDialog
        If result = Windows.Forms.DialogResult.OK Then
            If (OpenFileDialog1.FileName IsNot Nothing) Or (OpenFileDialog1.FileName <> String.Empty) Then

                imgFIN = OpenFileDialog1.FileName.ToString
                PictureBox1.BackgroundImage = Image.FromFile(OpenFileDialog1.FileName)
                PictureBox1.BackgroundImageLayout = ImageLayout.Zoom

            End If
        End If

        Clipboard.SetText(OpenFileDialog1.FileName.ToString)

        MsgBox("↓ Image path sent to clipboard → " & imgFIN)

    End Sub

    Private Sub btn_UPDATE_Click(sender As Object, e As EventArgs) Handles btn_UPDATE.Click

        Modify()

    End Sub

    Public Sub Clear()

        NAME_LAST.Clear()
        NAME_FIRST.Clear()
        NAME_MIDDLE.Clear()
        NICKNAME.Clear()
        BIRTH_PLACE.Clear()
        GENDER.SelectedIndex() = -1
        CITIZENSHIP.SelectedIndex() = 0
        CIVIL_STATUS.SelectedIndex() = -1
        BLOOD_TYPE.SelectedIndex() = 0
        ADDRESS_RESIDENTIAL.Clear()
        ADDRESS_PROVINCIAL.Clear()
        NUMBER_MOBILE.Clear()
        NUMBER_TELEPHONE.Clear()
        EMAIL.Clear()
        CODE_DISTRICT.Text = "01010"
        CODE_LOCAL.Clear()
        CURRENT_CHURCH.Clear()
        INTERNAL_SIGN.Clear()
        SCAN_DESIGNATION.Clear()
        MEMBER_SINCE.Clear()
        RADIO_LICENSE.Clear()
        COMM_EQUIPMENT.Clear()
        AMATEUR_SIGN.Clear()
        WORK_COMPANY.Clear()
        WORK_ADDRESS.Clear()
        WORK_DESIGNATION.Clear()
        WORK_NUMBER.Clear()
        HIGHEST_EDUCATION.SelectedIndex() = -1
        COURSES.Clear()
        YEAR_GRADUATED.Clear()
        ORG_AFFILIATIONS.Clear()
        TRAININGS_SEMINARS.Clear()
        SPECIAL_SKILLS.Clear()
        STATUS.SelectedIndex() = 0

        PictureBox1.BackgroundImage = Nothing
        PictureBox1.BackColor = Color.Goldenrod
        PictureBox1.Invalidate()

        imgFIN = imgDEF

    End Sub

    Public Sub Modify()

        Dim ctr As String
        Dim result As Integer = MessageBox.Show("Confirm to save? ", "Modification", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If (result = DialogResult.Yes) Then

            Try
                objConn.Open()
                objComm = New OleDbCommand("UPDATE [tblMemberInfo] SET " & "[STATUS]='" & STATUS.SelectedItem.ToString & "', [NAME_LAST]='" & CStr(NAME_LAST.Text) & "', [NAME_FIRST] ='" & CStr(NAME_FIRST.Text) & "', [NAME_MIDDLE]='" & CStr(NAME_MIDDLE.Text) & "', [NICKNAME]='" & CStr(NICKNAME.Text) & "', [BIRTH_DATE]='" & DateTimePicker1.Value.Date.ToString("MM/dd/yyyy") & "', [BIRTH_PLACE]='" & CStr(BIRTH_PLACE.Text) & "', [GENDER]='" & GENDER.SelectedItem.ToString & "', [CITIZENSHIP]='" & CITIZENSHIP.SelectedItem.ToString & "', [CIVIL_STATUS]='" & CIVIL_STATUS.SelectedItem.ToString & "', [BLOOD_TYPE]='" & BLOOD_TYPE.SelectedItem.ToString & "', [ADDRESS_RESIDENTIAL]='" & CStr(ADDRESS_RESIDENTIAL.Text) & "', [ADDRESS_PROVINCIAL]='" & CStr(ADDRESS_PROVINCIAL.Text) & "', [NUMBER_MOBILE]='" & CStr(NUMBER_MOBILE.Text) & "', [NUMBER_TELEPHONE]='" & CStr(NUMBER_TELEPHONE.Text) & "', [EMAIL]='" & CStr(EMAIL.Text) & "', [CODE_DISTRICT]='" & CStr(CODE_DISTRICT.Text) & "', [CODE_LOCAL]='" & CStr(CODE_LOCAL.Text) & "', [DATE_BAPTISM]='" & DateTimePicker2.Value.Date.ToString("MM/dd/yyyy") & "', [CURRENT_CHURCH]='" & CStr(CURRENT_CHURCH.Text) & "', [INTERNAL_SIGN]='" & CStr(INTERNAL_SIGN.Text) & "', [SCAN_DESIGNATION]='" & CStr(SCAN_DESIGNATION.Text) & "', [MEMBER_SINCE]='" & CStr(MEMBER_SINCE.Text) & "', [RADIO_LICENSE]='" & CStr(RADIO_LICENSE.Text) & "', [COMM_EQUIPMENT]='" & CStr(COMM_EQUIPMENT.Text) & "', [AMATEUR_SIGN]='" & CStr(AMATEUR_SIGN.Text) & "', [WORK_COMPANY]='" & CStr(WORK_COMPANY.Text) & "', [WORK_ADDRESS]='" & CStr(WORK_ADDRESS.Text) & "', [WORK_DESIGNATION]='" & CStr(WORK_DESIGNATION.Text) & "', [WORK_NUMBER]='" & CStr(WORK_NUMBER.Text) & "', [HIGHEST_EDUCATION]='" & HIGHEST_EDUCATION.SelectedItem.ToString & "', [COURSES]='" & CStr(COURSES.Text) & "', [YEAR_GRADUATED]='" & CStr(YEAR_GRADUATED.Text) & "', [ORG_AFFILIATIONS]='" & CStr(ORG_AFFILIATIONS.Text) & "', [TRAININGS_SEMINARS]='" & CStr(TRAININGS_SEMINARS.Text) & "', [SPECIAL_SKILLS]='" & CStr(SPECIAL_SKILLS.Text) & "', [DATE_FILED]='" & DateTimePicker3.Value.Date.ToString("MM/dd/yyyy") & "', [IMAGE]='" & CStr(imgFIN) & "', [ID_OLD]='" & zero & "' WHERE [DB_ID] =" & GroupBox1.Text, objConn)
                objAdap = New OleDbDataAdapter(objComm)
                objDt = New DataTable
                objAdap.Fill(objDt)

                'Dim sql2 As String = "UPDATE tblMemberInfo SET tblMemberInfo.STATUS = @STATUS, tblMemberInfo.NAME_LAST = @NAME_LAST, tblMemberInfo.NAME_FIRST = @NAME_FIRST, tblMemberInfo.NAME_MIDDLE = @NAME_MIDDLE, tblMemberInfo.NICKNAME = @NICKNAME, tblMemberInfo.BIRTH_DATE = @BIRTH_DATE, tblMemberInfo.BIRTH_PLACE = @BIRTH_PLACE, tblMemberInfo.GENDER = @GENDER, tblMemberInfo.CITIZENSHIP = @CITIZENSHIP, tblMemberInfo.CIVIL_STATUS = @CIVIL_STATUS, tblMemberInfo.BLOOD_TYPE = BLOOD_TYPE, tblMemberInfo.ADDRESS_RESIDENTIAL = @ADDRESS_RESIDENTIAL, tblMemberInfo.ADDRESS_PROVINCIAL = @ADDRESS_PROVINCIAL, tblMemberInfo.NUMBER_MOBILE = @NUMBER_MOBILE, tblMemberInfo.NUMBER_TELEPHONE = @NUMBER_TELEPHONE, tblMemberInfo.EMAIL = @EMAIL, tblMemberInfo.CODE_DISTRICT = @CODE_DISTRICT, tblMemberInfo.CODE_LOCAL = @CODE_LOCAL, tblMemberInfo.DATE_BAPTISM = @DATE_BAPTISM, tblMemberInfo.CURRENT_CHURCH = @CURRENT_CHURCH, tblMemberInfo.INTERNAL_SIGN = @INTERNAL_SIGN, tblMemberInfo.SCAN_DESIGNATION = @SCAN_DESIGNATION, tblMemberInfo.MEMBER_SINCE = @MEMBER_SINCE, tblMemberInfo.RADIO_LICENSE = @RADIO_LICENSE, tblMemberInfo.COMM_EQUIPMENT = @COMM_EQUIPMENT, tblMemberInfo.AMATEUR_SIGN = @AMATEUR_SIGN, tblMemberInfo.WORK_COMPANY = @WORK_COMPANY, tblMemberInfo.WORK_ADDRESS = @WORK_ADDRESS, tblMemberInfo.WORK_DESIGNATION = @WORK_DESIGNATION, tblMemberInfo.WORK_NUMBER = @WORK_NUMBER, tblMemberInfo.HIGHEST_EDUCATION = @HIGHEST_EDUCATION, tblMemberInfo.COURSES = @COURSES, tblMemberInfo.YEAR_GRADUATED = @YEAR_GRADUATED, tblMemberInfo.ORG_AFFILIATIONS = @ORG_AFFILIATIONS, tblMemberInfo.TRAININGS_SEMINARS = @TRAININGS_SEMINARS, tblMemberInfo.SPECIAL_SKILLS = @SPECIAL_SKILLS, tblMemberInfo.DATE_FILED = @DATE_FILED, tblMemberInfo.IMAGE = @IMAGE, tblMemberInfo.ID_OLD = @ID_OLD WHERE tblMemberInfo.DB_ID = @DB_ID"
                'Using cmd2 As New OleDbCommand(sql2, objConn)
                '    cmd2.Parameters.AddWithValue("@DB_ID", GroupBox1.Text)
                '    cmd2.Parameters.AddWithValue("@STATUS", STATUS.SelectedItem.ToString)
                '    cmd2.Parameters.AddWithValue("@NAME_LAST", NAME_LAST.Text)
                '    cmd2.Parameters.AddWithValue("@NAME_FIRST", NAME_FIRST.Text)
                '    cmd2.Parameters.AddWithValue("@NAME_MIDDLE", NAME_MIDDLE.Text)
                '    cmd2.Parameters.AddWithValue("@NICKNAME", NICKNAME.Text)
                '    cmd2.Parameters.AddWithValue("@BIRTH_DATE", DateTimePicker1.Value.Date.ToString("MM/dd/yyyy"))
                '    cmd2.Parameters.AddWithValue("@BIRTH_PLACE", BIRTH_PLACE.Text)
                '    cmd2.Parameters.AddWithValue("@GENDER", GENDER.SelectedItem.ToString)
                '    cmd2.Parameters.AddWithValue("@CITIZENSHIP", CITIZENSHIP.SelectedItem.ToString)
                '    cmd2.Parameters.AddWithValue("@CIVIL_STATUS", CIVIL_STATUS.SelectedItem.ToString)
                '    cmd2.Parameters.AddWithValue("@BLOOD_TYPE", BLOOD_TYPE.SelectedItem.ToString)
                '    cmd2.Parameters.AddWithValue("@ADDRESS_RESIDENTIAL", ADDRESS_RESIDENTIAL.Text)
                '    cmd2.Parameters.AddWithValue("@ADDRESS_PROVINCIAL", ADDRESS_PROVINCIAL.Text)
                '    cmd2.Parameters.AddWithValue("@NUMBER_MOBILE", NUMBER_MOBILE.Text)
                '    cmd2.Parameters.AddWithValue("@NUMBER_TELEPHONE", NUMBER_TELEPHONE.Text)
                '    cmd2.Parameters.AddWithValue("@EMAIL", EMAIL.Text)
                '    cmd2.Parameters.AddWithValue("@CODE_DISTRICT", CODE_DISTRICT.Text)
                '    cmd2.Parameters.AddWithValue("@CODE_LOCAL", CODE_LOCAL.Text)
                '    cmd2.Parameters.AddWithValue("@DATE_BAPTISM", DateTimePicker2.Value.Date.ToString("MM/dd/yyyy"))
                '    cmd2.Parameters.AddWithValue("@CURRENT_CHURCH", CURRENT_CHURCH.Text)
                '    cmd2.Parameters.AddWithValue("@INTERNAL_SIGN", INTERNAL_SIGN.Text)
                '    cmd2.Parameters.AddWithValue("@SCAN_DESIGNATION", SCAN_DESIGNATION.Text)
                '    cmd2.Parameters.AddWithValue("@MEMBER_SINCE", MEMBER_SINCE.Text)
                '    cmd2.Parameters.AddWithValue("@RADIO_LICENSE", RADIO_LICENSE.Text)
                '    cmd2.Parameters.AddWithValue("@COMM_EQUIPMENT", COMM_EQUIPMENT.Text)
                '    cmd2.Parameters.AddWithValue("@AMATEUR_SIGN", AMATEUR_SIGN.Text)
                '    cmd2.Parameters.AddWithValue("@WORK_COMPANY", WORK_COMPANY.Text)
                '    cmd2.Parameters.AddWithValue("@WORK_ADDRESS", WORK_ADDRESS.Text)
                '    cmd2.Parameters.AddWithValue("@WORK_DESIGNATION", WORK_DESIGNATION.Text)
                '    cmd2.Parameters.AddWithValue("@WORK_NUMBER", WORK_NUMBER.Text)
                '    cmd2.Parameters.AddWithValue("@HIGHEST_EDUCATION", HIGHEST_EDUCATION.Text)
                '    cmd2.Parameters.AddWithValue("@COURSES", COURSES.Text)
                '    cmd2.Parameters.AddWithValue("@YEAR_GRADUATED", YEAR_GRADUATED.Text)
                '    cmd2.Parameters.AddWithValue("@ORG_AFFILIATIONS", ORG_AFFILIATIONS.Text)
                '    cmd2.Parameters.AddWithValue("@TRAININGS_SEMINARS", TRAININGS_SEMINARS.Text)
                '    cmd2.Parameters.AddWithValue("@SPECIAL_SKILLS", SPECIAL_SKILLS.Text)
                '    cmd2.Parameters.AddWithValue("@DATE_FILED", DateTimePicker3.Value.Date.ToString("MM/dd/yyyy"))
                '    cmd2.Parameters.AddWithValue("@IMAGE", imgFIN)
                '    cmd2.Parameters.AddWithValue("@ID_OLD", zero)
                '    ctr = cmd2.ExecuteNonQuery()
                '    cmd2.ExecuteNonQuery()
                '    MsgBox("Row changes: " & ctr)
                'End Using

                MsgBox("Operation successful", MsgBoxStyle.Information, "User")
                'Clear()

            Catch ex As Exception
                MsgBox(ex.Message)
                MsgBox("Fill-in the fields with their proper formats.", MsgBoxStyle.Exclamation, "Something went wrong")
            End Try

        Else
            MsgBox("Operation cancelled", MsgBoxStyle.Exclamation, "User")

        End If

        If objConn.State = ConnectionState.Open Then
            objConn.Close()
        End If

    End Sub

    Private Sub frmMod_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        frmHome.UpdateDataGrid(True)

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
End Class