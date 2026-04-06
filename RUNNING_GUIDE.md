# Running Your ASP.NET Project

Your project **"Conventional Festive Frolics"** is built using **ASP.NET Web Forms (.NET 4.0)** and legacy SQL Server Express. To make it "runnable" and "executable" on your Windows system without modifying any of your original source code, I have added the following entry points:

## 🚀 How to Run the Project

### Option 1: Visual Studio (Recommended)
This is the standard and most reliable way to run this type of project.
1. Double-click the file **ConventionalFestiveFrolics.sln** to open it in Visual Studio.
2. Ensure you have the **"ASP.NET and web development"** workload installed in Visual Studio.
3. Press **F5** or the **Start** button in Visual Studio to launch the project in your browser.

### Option 2: Standalone Execution (One-Click)
If you don't want to open an IDE, use the batch file I created:
1. Run **run_project.bat**.
2. This script will attempt to find **IIS Express** (standard with Windows development) and host the project on `http://localhost:5000`.
3. Your browser will automatically open to the **Homepage.aspx**.

### Option 3: Modern Command Line
Since I detected `npm` on your machine, you can also use:
```powershell
npm start
```
This will trigger the local launch sequence.

---

## 🛠 Prerequisites
For the project to function correctly (including the database for login and bookings), you need:
- **.NET Framework 4.0** (Built-in to Windows).
- **IIS Express** (Standalone or with Visual Studio).
- **SQL Server Express** (Required for the `.mdf` database files in `App_Data` mentioned in your `web.config`).

> [!IMPORTANT]
> Since this is a legacy .NET 4.0 project, it is **not executable as a single EXE file** by nature; it must be hosted by a Web Server (IIS). The provided scripts turn your project folder into a local app service.

## 📁 New Files Added
I have added the following management files **without changing any of your source code**:
- `ConventionalFestiveFrolics.sln`: Visual Studio solution.
- `run_project.bat`: Automated launch script.
- `package.json`: Modern tool integration.

Your original `.aspx`, `.aspx.cs`, and `web.config` files remain EXACTLY as they were.
