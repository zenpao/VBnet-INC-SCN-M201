Imports System.Data.OleDb
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.IO

Public Class frmExport

    Dim objConn As OleDbConnection = New OleDbConnection(" Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\dbM201.mdb")
    Dim objComm As OleDbCommand
    Dim objAdap As OleDbDataAdapter
    Dim objDt As DataTable

    Dim objDt2 As New System.Data.DataTable
    Dim connString As String = " Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\dbM201.mdb"
    Dim excelLocation As String
    Dim path As String
    Dim MyConn As System.Data.OleDb.OleDbConnection
    Dim ds As DataSet
    Dim tables As DataTableCollection
    Dim source1 As New BindingSource
    Dim APP As New Excel.Application
    Dim xlWorksheet As Excel.Worksheet
    Dim xlWorkbook As Excel.Workbook

    Private Sub frmExport_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        frmHome.UpdateDataGrid(True)

    End Sub


    Private Sub btn_EXPORT_Click(sender As Object, e As EventArgs) Handles btn_EXPORT.Click

        Export2Excel()

    End Sub

    Public Sub Export2Excel()

        frmView.DataGridView1.EndEdit()
        DataGridView1.EndEdit()

        '*****************GET DIRECTORY FOR WHICH THE USER WANTS TO EXPORT THE EXCEL FILE.

        Dim result As Integer = MessageBox.Show("Specify directory for saving?", "Set Directory", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If (result = DialogResult.Yes) Then
            FolderBrowserDialog1.ShowDialog()
            path = CStr(FolderBrowserDialog1.SelectedPath.ToString)
        ElseIf (result = DialogResult.No) Then
            path = CStr(Environment.GetFolderPath(Environment.SpecialFolder.Desktop))
        End If

        '*****************TRANSFER EXCEL FILE IN THE CHOSEN DIRECTORY

        Dim source As String = My.Application.Info.DirectoryPath & "\EXPORTED.xlsx" 'get directory of original file

        Dim buildDir As String
        Dim buildDir1 As New System.Text.StringBuilder()
        buildDir = buildDir1.Append("" + path).Append("\").Append("SCN-M201-FULL").Append(".xlsx").ToString


        'If Not System.IO.File.Exists(excelLocation) Then
        '    System.IO.File.Create(excelLocation).Dispose()
        'End If

        'File.Create(excelLocation).Dispose() 'automatically creates and overwrites it while closing the reference afterwards.

        File.Copy(source, buildDir, True)

        excelLocation = buildDir

        '******************EXPORTS THE EXCEL FILE

        APP = New Excel.Application
        xlWorkbook = APP.Workbooks.Open(excelLocation)
        xlWorkbook.Application.Visible = False

        'xlWorkbook = APP.Workbooks.Open(excelLocation)
        xlWorksheet = xlWorkbook.Worksheets("sheet1")
        MyConn = New System.Data.OleDb.OleDbConnection
        MyConn.ConnectionString = connString
        ds = New DataSet
        tables = ds.Tables
        objAdap = New OleDbDataAdapter("SELECT [STATUS], [NAME_LAST], [NAME_FIRST], [NAME_MIDDLE], [NICKNAME], [BIRTH_DATE], [BIRTH_PLACE], [GENDER], [CITIZENSHIP], [CIVIL_STATUS], [BLOOD_TYPE], [ADDRESS_RESIDENTIAL], [ADDRESS_PROVINCIAL], [NUMBER_MOBILE], [NUMBER_TELEPHONE], [EMAIL], [CODE_DISTRICT], [CODE_LOCAL], [DATE_BAPTISM], [CURRENT_CHURCH], [INTERNAL_SIGN], [SCAN_DESIGNATION], [MEMBER_SINCE], [RADIO_LICENSE], [COMM_EQUIPMENT], [AMATEUR_SIGN], [WORK_COMPANY], [WORK_ADDRESS], [WORK_DESIGNATION], [WORK_NUMBER], [HIGHEST_EDUCATION], [COURSES], [YEAR_GRADUATED], [ORG_AFFILIATIONS], [TRAININGS_SEMINARS], [SPECIAL_SKILLS], [DATE_FILED], [IMAGE], [DB_ID] FROM tblMemberInfo", MyConn) 'Change items to your database name
        objAdap.Fill(ds, "tblMemberInfo") 'Change items to your database name
        Dim view As New DataView(tables(0))
        source1.DataSource = view
        DataGridView1.DataSource = view
        DataGridView1.AllowUserToAddRows = False

        Dim columnsCount As Integer = DataGridView1.Columns.Count
        For Each column In DataGridView1.Columns
            xlWorksheet.Cells(1, column.Index + 1).Value = column.Name
        Next
        'Export Header Name End

        'Export Each Row Start
        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            Dim columnIndex As Integer = 0
            Do Until columnIndex = columnsCount
                xlWorksheet.Cells(i + 2, columnIndex + 1).Value = DataGridView1.Item(columnIndex, i).Value.ToString
                columnIndex += 1
            Loop
        Next
        'Export Each Row End

        Clipboard.SetText(buildDir)

        MsgBox("↓ File path sent to clipboard → " & buildDir)
        'MsgBox("Successfully saved at: " & excelLocation)

        xlWorkbook.Save()
        xlWorkbook.Close()
        APP.Quit()

    End Sub

End Class