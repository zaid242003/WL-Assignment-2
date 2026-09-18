ASP.NET Core MVC - Recruitment Form
=====================================

How to run:
1. Requires the .NET 8 SDK (dotnet.microsoft.com/download).
2. From this folder, run:
       dotnet run
3. Open the URL shown in the console (e.g. https://localhost:5001) -
   it will load the Recruitment/Create form directly (default route).

Or open the folder in Visual Studio / Visual Studio Code as an existing
ASP.NET Core project (RecruitmentCoreMVC.csproj) and press F5.

Architecture: Model (Models/Candidate.cs) -> Controller
(Controllers/RecruitmentController.cs) -> View
(Views/Recruitment/Create.cshtml / Success.cshtml), using modern Tag
Helpers (asp-for, asp-validation-for) instead of classic Html helpers,
dependency-injected IWebHostEnvironment, async file handling
(IFormFile + CopyToAsync), and the minimal hosting model in Program.cs
(no ViewState, no Global.asax). Uploaded CVs are saved to
wwwroot/Uploads at runtime.
