Imports System.Data.OleDb

Public Class frmHome

    Dim objConn As OleDbConnection = New OleDbConnection(" Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\dbM201.mdb")
    Dim objComm As OleDbCommand
    Dim objAdap As OleDbDataAdapter
    Dim objDt As DataTable

    Dim zero As String = "null"
    Dim defPATH As String = My.Application.Info.DirectoryPath
    Dim imgPATH As String = IO.Path.Combine(defPATH, "\res\blank-profile.jpg")

    Private Sub Home_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Clear()

    End Sub

    Private Sub ClearToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearToolStripMenuItem.Click

        Clear()

    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click

        Save()

    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click

        Me.Close()

    End Sub

    Private Sub DatabaseConnectionStateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DatabaseConnectionStateToolStripMenuItem.Click

        DBConnectionStatus()

    End Sub

    Private Sub RefreshRecordsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshRecordsToolStripMenuItem.Click

        UpdateDataGrid(True)
        DBConnectionStatus()
        MsgBox("Done", MsgBoxStyle.Information, "Operation")

    End Sub

    Private Sub ViewSearchToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewSearchToolStripMenuItem.Click

        UpdateDataGrid(True)
        frmView.ShowDialog()

    End Sub

    Private Sub ExportToMSExcelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportToMSExcelToolStripMenuItem.Click

        UpdateDataGrid(True)
        frmView.DataGridView1.EndEdit()
        frmExport.DataGridView1.EndEdit()
        frmExport.ShowDialog()

    End Sub

    Private Sub AboutToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem1.Click

        'UpdateDataGrid(True)
        frmView.DataGridView1.EndEdit()
        frmExport.DataGridView1.EndEdit()
        frmAbout.ShowDialog()

    End Sub

    Private Sub lnk_DEFAULT_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnk_DEFAULT.LinkClicked

        PictureBox1.BackgroundImage = Nothing
        PictureBox1.BackColor = Color.DarkGray
        PictureBox1.Invalidate()

        imgPATH = IO.Path.Combine(defPATH, "\res\blank-profile.jpg")

    End Sub

    Private Sub lnk_UPLOAD_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnk_UPLOAD.LinkClicked

        Dim result As DialogResult = OpenFileDialog1.ShowDialog
        If result = Windows.Forms.DialogResult.OK Then
            If (OpenFileDialog1.FileName IsNot Nothing) Or (OpenFileDialog1.FileName <> String.Empty) Then

                imgPATH = OpenFileDialog1.FileName.ToString
                PictureBox1.BackgroundImage = Image.FromFile(OpenFileDialog1.FileName)
                PictureBox1.BackgroundImageLayout = ImageLayout.Zoom

            End If
        End If

        Clipboard.SetText(OpenFileDialog1.FileName.ToString)

        MsgBox("↓ Image path sent to clipboard → " & imgPATH)

    End Sub

    Private Sub btn_SAVE_Click(sender As Object, e As EventArgs) Handles btn_SAVE.Click

        Save()

    End Sub

    Private Sub lnk_CLEAR_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnk_CLEAR.LinkClicked

        Dim result As Integer = MessageBox.Show("Confirm to clear? ", "Reset to default", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If (result = DialogResult.Yes) Then
            Clear()
        Else
            MsgBox("Cancelled", MsgBoxStyle.Exclamation, "Reminder")
        End If

    End Sub

    Private Sub btn_TEST_Click(sender As Object, e As EventArgs) Handles btn_TEST.Click

        'Clear()

        NAME_LAST.Text = "ROJO"
        NAME_FIRST.Text = "MIGUEL"
        NAME_MIDDLE.Text = "CABALLERO"
        NICKNAME.Text = "MIGUEL"
        DateTimePicker1.Text = "08/04/1990"
        BIRTH_PLACE.Text = "GUADALAJARA, JALISCO, MEXICO, 45110"
        GENDER.SelectedIndex() = 0
        CITIZENSHIP.SelectedIndex() = 16
        CIVIL_STATUS.SelectedIndex() = 2
        BLOOD_TYPE.SelectedIndex() = 6
        ADDRESS_RESIDENTIAL.Text = "GUADALAJARA, JALISCO, MEXICO, 45110"
        ADDRESS_PROVINCIAL.Text = "GUADALAJARA, JALISCO, MEXICO, 45110"
        NUMBER_MOBILE.Text = "12345678911"
        NUMBER_TELEPHONE.Text = "12345678911"
        EMAIL.Text = "support.steampowered@tekken.com"
        CODE_DISTRICT.Text = "01010"
        CODE_LOCAL.Text = "01010"
        DateTimePicker2.Text = "10/04/2010"
        CURRENT_CHURCH.Text = "LOCALE OF MEXICO CITY"
        INTERNAL_SIGN.Text = "700"
        SCAN_DESIGNATION.Text = "LOCALE OF MEXICO CITY"
        MEMBER_SINCE.Text = "2013"
        RADIO_LICENSE.Text = "SOB12345678911 10/10/2019"
        COMM_EQUIPMENT.Text = "GMDSS SIMPLEX HF RADIOTELEPHONE"
        AMATEUR_SIGN.Text = "007"
        WORK_COMPANY.Text = "VALVE CORPORATION"
        WORK_ADDRESS.Text = "KIRKLAND, WASHINGTON, UNITED STATES"
        WORK_DESIGNATION.Text = "BELLEVUE, WASHINGTON, UNITED STATES"
        WORK_NUMBER.Text = "123456789"
        HIGHEST_EDUCATION.SelectedIndex() = 6
        COURSES.Text = "INFORMATION TECHNOLOGY - MAJOR IN SOFTWARE DEVELOPMENT"
        YEAR_GRADUATED.Text = "2016"
        ORG_AFFILIATIONS.Text = "CHRISTIAN BROTHERHOOD INTERNATIONAL 2012-2016"
        TRAININGS_SEMINARS.Text = "MICROSOFT VIRTUAL ACADEMY 10/10/2015"
        SPECIAL_SKILLS.Text = "FRENCH KICKBOXING"
        DateTimePicker3.Text = "08/04/2017"
        STATUS.SelectedIndex() = 0

    End Sub

    Private Function DBConnectionStatus() As Boolean
        Try
            Using mdbConn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\dbM201.mdb")
                mdbConn.Open()
                Return MsgBox("State: " & (mdbConn.State = ConnectionState.Open) & ". Database is connected.", MsgBoxStyle.Information, "ACTIVE")
            End Using
        Catch e1 As OleDbException
            Return MsgBox("State: " & False & ". Database disconnected. Some functions will not work.", MsgBoxStyle.Critical, "INACTIVE")
        Catch e2 As Exception
            Return MsgBox("State: " & False & ". Database disconnected. Some functions will not work.", MsgBoxStyle.Critical, "INACTIVE")
        End Try
    End Function

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
        PictureBox1.BackColor = Color.DarkGray
        PictureBox1.Invalidate()

        imgPATH = IO.Path.Combine(defPATH, "\res\blank-profile.jpg")

    End Sub

    Public Sub Save()

        Dim result As Integer = MessageBox.Show("Confirm to save? ", "Registration", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If (result = DialogResult.Yes) Then

            Try
                objConn.Open()
                objComm = New OleDbCommand("INSERT INTO tblMemberInfo ( [STATUS], [NAME_LAST], [NAME_FIRST], [NAME_MIDDLE], [NICKNAME], [BIRTH_DATE], [BIRTH_PLACE], [GENDER], [CITIZENSHIP], [CIVIL_STATUS], [BLOOD_TYPE], [ADDRESS_RESIDENTIAL], [ADDRESS_PROVINCIAL], [NUMBER_MOBILE], [NUMBER_TELEPHONE], [EMAIL], [CODE_DISTRICT], [CODE_LOCAL], [DATE_BAPTISM], [CURRENT_CHURCH], [INTERNAL_SIGN], [SCAN_DESIGNATION], [MEMBER_SINCE], [RADIO_LICENSE], [COMM_EQUIPMENT], [AMATEUR_SIGN], [WORK_COMPANY], [WORK_ADDRESS], [WORK_DESIGNATION], [WORK_NUMBER], [HIGHEST_EDUCATION], [COURSES], [YEAR_GRADUATED], [ORG_AFFILIATIONS], [TRAININGS_SEMINARS], [SPECIAL_SKILLS], [DATE_FILED], [IMAGE], [ID_OLD]) VALUES ('" & STATUS.SelectedItem.ToString & "','" & CStr(NAME_LAST.Text) & "','" & CStr(NAME_FIRST.Text) & "','" & CStr(NAME_MIDDLE.Text) & "','" & CStr(NICKNAME.Text) & "','" & DateTimePicker1.Value.Date.ToString("MM/dd/yyyy") & "','" & CStr(BIRTH_PLACE.Text) & "','" & GENDER.SelectedItem.ToString & "','" & CITIZENSHIP.SelectedItem.ToString & "','" & CIVIL_STATUS.SelectedItem.ToString & "','" & BLOOD_TYPE.SelectedItem.ToString & "','" & CStr(ADDRESS_RESIDENTIAL.Text) & "','" & CStr(ADDRESS_PROVINCIAL.Text) & "','" & CStr(NUMBER_MOBILE.Text) & "','" & CStr(NUMBER_TELEPHONE.Text) & "','" & CStr(EMAIL.Text) & "','" & CStr(CODE_DISTRICT.Text) & "','" & CStr(CODE_LOCAL.Text) & "','" & DateTimePicker2.Value.Date.ToString("MM/dd/yyyy") & "','" & CStr(CURRENT_CHURCH.Text) & "','" & CStr(INTERNAL_SIGN.Text) & "','" & CStr(SCAN_DESIGNATION.Text) & "','" & CStr(MEMBER_SINCE.Text) & "','" & CStr(RADIO_LICENSE.Text) & "','" & CStr(COMM_EQUIPMENT.Text) & "','" & CStr(AMATEUR_SIGN.Text) & "','" & CStr(WORK_COMPANY.Text) & "','" & CStr(WORK_ADDRESS.Text) & "','" & CStr(WORK_DESIGNATION.Text) & "','" & CStr(WORK_NUMBER.Text) & "','" & HIGHEST_EDUCATION.SelectedItem.ToString & "','" & CStr(COURSES.Text) & "','" & CStr(YEAR_GRADUATED.Text) & "','" & CStr(ORG_AFFILIATIONS.Text) & "','" & CStr(TRAININGS_SEMINARS.Text) & "','" & CStr(SPECIAL_SKILLS.Text) & "','" & DateTimePicker3.Value.Date.ToString("MM/dd/yyyy") & "','" & CStr(imgPATH) & "','" & zero & "')", objConn)
                objAdap = New OleDbDataAdapter(objComm)
                objDt = New DataTable
                objAdap.Fill(objDt)

                MsgBox("Operation successful", MsgBoxStyle.Information, "User")
                Clear()

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

    Sub UpdateDataGrid(ByVal DisplayDialog As Boolean)

        objDt = New DataTable
        objComm = New OleDbCommand("SELECT [STATUS], [NAME_LAST], [NAME_FIRST], [NAME_MIDDLE], [NICKNAME], [BIRTH_DATE], [BIRTH_PLACE], [GENDER], [CITIZENSHIP], [CIVIL_STATUS], [BLOOD_TYPE], [ADDRESS_RESIDENTIAL], [ADDRESS_PROVINCIAL], [NUMBER_MOBILE], [NUMBER_TELEPHONE], [EMAIL], [CODE_DISTRICT], [CODE_LOCAL], [DATE_BAPTISM], [CURRENT_CHURCH], [INTERNAL_SIGN], [SCAN_DESIGNATION], [MEMBER_SINCE], [RADIO_LICENSE], [COMM_EQUIPMENT], [AMATEUR_SIGN], [WORK_COMPANY], [WORK_ADDRESS], [WORK_DESIGNATION], [WORK_NUMBER], [HIGHEST_EDUCATION], [COURSES], [YEAR_GRADUATED], [ORG_AFFILIATIONS], [TRAININGS_SEMINARS], [SPECIAL_SKILLS], [DATE_FILED], [IMAGE], [DB_ID] FROM tblMemberInfo", objConn)
        objAdap = New OleDbDataAdapter(objComm)
        SetDataGrid(DisplayDialog)

    End Sub

    Sub SetDataGrid(ByVal DisplayDialog As Boolean)

        Try
            objAdap.Fill(objDt)
            If objDt.Rows.Count > 0 Then
                frmView.DataGridView1.DataSource = objDt
                frmExport.DataGridView1.DataSource = objDt
            ElseIf DisplayDialog Then
                MsgBox("No records found.", MsgBoxStyle.OkOnly, "Empty")
            Else
                frmView.DataGridView1.DataSource = vbNull
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If objConn.State = ConnectionState.Open Then
                objConn.Close()
            End If
        End Try
    End Sub

End Class
