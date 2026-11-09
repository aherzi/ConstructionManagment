# ConstructionApp

Construction management application with an ASP.NET Core server, a Windows Forms client, and shared models.

## Open the solution

Open `ConstructionApp/ConstructionApp.slnx` in Visual Studio with the ASP.NET and web development and .NET desktop development workloads. The server targets .NET 10, the client targets .NET Framework 4.8, and shared models target .NET Standard 2.0.

Restore NuGet packages before building. The client expects packages under `ConstructionApp/packages`; use that folder as the package restore destination for `ConstructionAppClient/packages.config`.

## Database

The server uses Microsoft Access through the Microsoft.ACE.OLEDB.16.0 provider and expects `Construction_Management_DB.accdb` in its working directory. Supply your local database and install the matching Access Database Engine provider. Database files are excluded from Git because they can contain user accounts and application data.

## Run

Start the server and the Windows Forms client from Visual Studio. Configure their startup projects as needed.
