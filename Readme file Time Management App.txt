 Time Management Application README File

-Table of Contents
1. Introduction
2. Project Structure
3. Requirements
4. Compilation and Execution
5. Usage
6. Additional Notes

1. Introduction
Welcome to the Time Management Application README! In this document, there are instructions on hoe to compile, run, and to use the Time Management Application. The Time Management Application helps with managing your study hours for various modules during the semester. 

2. Project Structure
The project consists of two main components:
- **TimeManagementApp**: The Windows Presentation Foundation (WPF) application.
- **TimeManagementLibrary**: The class library that contains the core logic and data structures.

3. Requirements 
Before you begin, these are the rewuirements that must be installed:
- Visual Studio (Recommended: Visual Studio 2019 or later) with C# and WPF support.
- .NET Framework (Target Framework: .NET Framework 4.7.2).

4. Compilation and Execution
Follow these steps to compile and run the Time Management Application:

1. Open the solution file `TimeManagementApp.sln` in Visual Studio.

2. Build the solution by clicking `Build` in the menu.

3. Set the `TimeManagementApp` project as the startup project:
   - Right-click on `TimeManagementApp` in the Solution Explorer.
   - Select "Set as Startup Project."

4. Click the "Start Debugging" button to run the application.

5. Usage
Once the application is running, you can perform the following tasks:
- Add modules for the semester by filling in the module details and clicking the "Add Module" button.
- Set the number of weeks in the semester and the start date for the first week.
- Record the number of hours you spend working on a specific module on a certain date.
- View the list of modules and their self-study hours for the current week.

6. Additional Notes
- This application does not persist user data between runs. Data is stored in memory while the application is running.
- Feel free to enhance the application further, such as improving the UI, adding error handling, and implementing more features.

Thank you for using the Time Management Application! If you encounter any issues or have any questions, please refer to the project's documentation or contact the developer.
