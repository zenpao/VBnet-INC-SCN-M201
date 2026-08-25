# VBnet-INC-SCN-M201

A Windows Forms desktop app (VB.NET) for digitizing and managing **M201 member information forms** for the Iglesia Ni Cristo (INC) SCAN Department, backed by a local Microsoft Access database. M201 is the standard personal information form used by the SCAN Department.

## Description

The app provides a form for entering a member's personal, contact, church, work, and educational information (matching the fields of the M201 form), saving each entry to a local database. Saved records can be searched, viewed, edited, and exported to Excel.

## Features

- **Data entry form** covering:
  - Personal info: name, nickname, birth date/place, gender, citizenship, civil status, blood type
  - Contact info: residential/provincial address, mobile/telephone number, email
  - Church-related info: district/local code, baptism date, current church, internal sign, SCAN designation, member-since year, radio license, communication equipment, amateur sign
  - Work info: company, address, designation, contact number
  - Education info: highest education level, courses, year graduated
  - Other: organizational affiliations, trainings/seminars, special skills, photo upload, status, date filed
- **Save** a new member record to the database
- **Clear** the form back to defaults, with confirmation
- **Test-fill** button to populate the form with sample data for testing
- **Database connectivity check**
- **Search/View records** by last name, with a data grid of results
- **Modify records** — select a record from the view to edit and update its saved details
- **Export to Excel (`.xlsx`)** — exports the full record set (or the current view) to a spreadsheet, saved to a chosen folder or the Desktop by default
- **About dialog**

## Tech Stack

- **VB.NET** (Visual Basic .NET)
- **Windows Forms** (WinForms)
- **.NET Framework**
- **Microsoft Access (`.mdb`)** database via `System.Data.OleDb` (Jet OLEDB 4.0 provider)
- **Microsoft.Office.Interop.Excel** — for exporting records to `.xlsx`

## Prerequisites

- Windows OS
- .NET Framework (matching the project's target version) — for running the built app
- Microsoft Access Database Engine / Jet OLEDB 4.0 provider (to connect to the `.mdb` database) — typically requires the 32-bit Access Database Engine redistributable, since Jet OLEDB 4.0 is 32-bit only
- Microsoft Excel installed (required for the Excel export feature, via Office Interop)
- Visual Studio (for building/editing the project)

## Installation

Clone the repository:

```bash
git clone https://github.com/paoradox/VBnet-INC-SCN-M201.git
cd VBnet-INC-SCN-M201
```

Open `SCN-M201.sln` in Visual Studio and build the solution.

## Usage

Build the solution in Visual Studio, then run the generated `SCN-M201.exe` (or run/debug directly from Visual Studio).

### Workflow

1. **Fill out the M201 form** — enter the member's personal, contact, church, work, and education details, and optionally upload a photo.
2. **Save** — confirms and inserts the record into the database.
3. **View/Search** — open the View screen to search saved records by last name, or reload the full list.
4. **Modify** — select a record in the View screen to open it for editing, then save the changes.
5. **Export** — export the current record set to an Excel file, choosing a save location or defaulting to the Desktop.

## Configuration

- The database connection string points to `dbM201.mdb` in the application's `|DataDirectory|` — this `.mdb` file must be present alongside the built executable, with a `tblMemberInfo` table matching the form's fields.
- A default placeholder photo is expected at `res\blank-profile.jpg` relative to the application directory.

## Troubleshooting

- **Database connection errors:** ensure the Microsoft Access Database Engine (Jet OLEDB 4.0, 32-bit) is installed, and that `dbM201.mdb` exists in the expected data directory. Use the Database Connection State menu option to verify connectivity.
- **Save fails / "Fill-in the fields with their proper formats":** double-check required fields (especially dates and dropdown selections) are filled in correctly before saving.
- **Excel export fails:** ensure Microsoft Excel is installed, since export uses Office Interop.

## Project Structure

```
VBnet-INC-SCN-M201/
├── SCN-M201/
│   ├── Home.vb / Home.Designer.vb / Home.resx       # Main data-entry form
│   ├── View.vb / View.Designer.vb / View.resx       # Search/view records
│   ├── Modify.vb / Modify.Designer.vb / Modify.resx # Edit an existing record
│   ├── Export.vb / Export.Designer.vb / Export.resx # Export records to Excel
│   ├── About.vb / About.Designer.vb / About.resx    # About dialog
│   ├── ApplicationEvents.vb
│   ├── My Project/                                  # VB.NET project settings, assembly info
│   ├── App.config
│   ├── SCN-M201.vbproj                               # Project file
│   ├── bin/                                         # Build output
│   └── obj/                                         # Build intermediates
├── SCN-M201.sln          # Visual Studio solution file
└── SCN-M201.exe.lnk       # Shortcut to the built executable
```

## License

Not specified.
