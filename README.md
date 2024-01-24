# Hi, I'm Ivan Verges! 👋


## 🔗 Links
[![Personal Page](https://img.shields.io/badge/Personal_Page-000?style=for-the-badge)](https://ivanverges.com/)


# Test Results Analyzer
This project is as a demosntration on how we can use the results from automated tests executions, parse the data from JSON to actual C# objects, do some analysis and generate a resume based on the data, and even export a summary to CSV.

This solution contains 4 projects:
 - TestResultsAnalyzer.Client => A simple Blazor WASM web app to demonstrate Analysis Data.
 - TestResultsAnalyzer.CommandLine: => A simple CLI app to demonstrate functionalities.
 - TestResultsAnalyzer.Server => A simple Web API to consume interact with the analyzer.
 - TestResultsAnalyzer.Shared => Common project with Analyzer logic and Data Models.


## Tech Stack

**IDE:** Visual Studio 2022

**TestResultsAnalyzer.Client:** .NET 7.0, Blazor, WASM, MudBlazor, Radzen.Blazor

**TestResultsAnalyzer.CommandLine:** .NET 7.0

**TestResultsAnalyzer.Server:** .NET 7.0, Web API

**TestResultsAnalyzer.Shared:** .NET 7.0


## Json Structure
This is the JSON structure assumed for this project, which is an array of Test Executions (TE) where each TE has an Id, a Name and an array of Test Suites (TS), and each TS has an Id, a Name and an array of Test Cases (TC). Each TC has an Id, a Name, a Start Time (TimeStamp), EndTime (TimeStamp), and a Result ("Failed", "Passed", "Pending", "Skipped").

```json
[
  {
    "Id": 1,
    "Name": "Test Execution Name",
    "TestSuites": [
      {
        "Id": 1,
        "Name": "Test Suite Name",
        "TestCases": [
          {
            "Id": 1,
            "Name": "Test Case Name",
            "StartTime": "2024-01-24T16:54:21.6917313-04:00",
            "EndTime": "2024-01-24T16:54:26.3242674-04:00",
            "Result": "Failed"
          },
          {
            "Id": 2,
            "Name": "Test Case Name",
            "StartTime": "2024-01-24T16:54:21.6917313-04:00",
            "EndTime": "2024-01-24T16:54:26.3242674-04:00",
            "Result": "Failed"
          }
        ]
      },
      {
        "Id": 2,
        "Name": "Test Suite Name",
        "TestCases": [
          {
            "Id": 1,
            "Name": "Test Case Name",
            "StartTime": "2024-01-24T16:54:21.6917313-04:00",
            "EndTime": "2024-01-24T16:54:26.3242674-04:00",
            "Result": "Failed"
          },
          {
            "Id": 2,
            "Name": "Test Case Name",
            "StartTime": "2024-01-24T16:54:21.6917313-04:00",
            "EndTime": "2024-01-24T16:54:26.3242674-04:00",
            "Result": "Failed"
          }
        ]
      }
    ]
  },
  {
    "Id": 2,
    "Name": "Test Execution Name",
    "TestSuites": [
      {
        "Id": 1,
        "Name": "Test Suite Name",
        "TestCases": [
          {
            "Id": 1,
            "Name": "Test Case Name",
            "StartTime": "2024-01-24T16:54:21.6917313-04:00",
            "EndTime": "2024-01-24T16:54:26.3242674-04:00",
            "Result": "Failed"
          },
          {
            "Id": 2,
            "Name": "Test Case Name",
            "StartTime": "2024-01-24T16:54:21.6917313-04:00",
            "EndTime": "2024-01-24T16:54:26.3242674-04:00",
            "Result": "Failed"
          }
        ]
      },
      {
        "Id": 2,
        "Name": "Test Suite Name",
        "TestCases": [
          {
            "Id": 1,
            "Name": "Test Case Name",
            "StartTime": "2024-01-24T16:54:21.6917313-04:00",
            "EndTime": "2024-01-24T16:54:26.3242674-04:00",
            "Result": "Failed"
          },
          {
            "Id": 2,
            "Name": "Test Case Name",
            "StartTime": "2024-01-24T16:54:21.6917313-04:00",
            "EndTime": "2024-01-24T16:54:26.3242674-04:00",
            "Result": "Failed"
          }
        ]
      }
    ]
  }
]
```


## Dependencies
To run this project you need to install the .NET 7.0 SDK, which you can download from here: https://dotnet.microsoft.com/en-us/download/visual-studio-sdks


## How to run this project
- To run this project as a Console Application, it's recommended to open it with Visual Studio 2022, select (or set as default) the project "TestResultsAnalyzer.CommandLine", and execute it by pressing keys "Ctrl" + "F5".
- To run this project as a Web App, it's recommended to open it with Visual Studio 2022, select (or set as default) the project "TestResultsAnalyzer.Server", and execute it by pressing keys "Ctrl" + "F5".


## Screenshots (Console App)
- App Menu
![App Menu](https://github.com/ivan-verges/TestResultsAnalizer/blob/master/Screenshots/CLI01.png?raw=true)

- Generating JSON Data
![Generating JSON Data](https://github.com/ivan-verges/TestResultsAnalizer/blob/master/Screenshots/CLI02.png?raw=true)

- View Generated JSON File
![View Generated JSON File](https://github.com/ivan-verges/TestResultsAnalizer/blob/master/Screenshots/CLI03.png?raw=true)

- Generating CSV Data
![Generating CSV Data](https://github.com/ivan-verges/TestResultsAnalizer/blob/master/Screenshots/CLI04.png?raw=true)

- View Generated CSV File
![View Generated CSV File](https://github.com/ivan-verges/TestResultsAnalizer/blob/master/Screenshots/CLI05.png?raw=true)

- Analyzing JSON Data From Console
![Analyzing JSON Data From Console](https://github.com/ivan-verges/TestResultsAnalizer/blob/master/Screenshots/CLI06.png?raw=true)

- Showing Analysis Data
![Showing Analysis Data](https://github.com/ivan-verges/TestResultsAnalizer/blob/master/Screenshots/CLI07.png?raw=true)

- Analyzing Data From JSON File
![Analyzing Data From JSON File](https://github.com/ivan-verges/TestResultsAnalizer/blob/master/Screenshots/CLI08.png?raw=true)

- Showing Analysis Data
![Showing Analysis Data](https://github.com/ivan-verges/TestResultsAnalizer/blob/master/Screenshots/CLI09.png?raw=true)

- Exporting Data From JSON to CSV File
![Exporting Data From JSON to CSV File](https://github.com/ivan-verges/TestResultsAnalizer/blob/master/Screenshots/CLI10.png?raw=true)

- View Exported CSV File
![View Exported CSV File](https://github.com/ivan-verges/TestResultsAnalizer/blob/master/Screenshots/CLI11.png?raw=true)

- Exporting Data From JSON File to CSV File
![Exporting Data From JSON File to CSV File](https://github.com/ivan-verges/TestResultsAnalizer/blob/master/Screenshots/CLI12.png?raw=true)

- View Exported CSV File
![View Exported CSV File](https://github.com/ivan-verges/TestResultsAnalizer/blob/master/Screenshots/CLI13.png?raw=true)


## Screenshots (Web App)
- Generate Demo JSON Data
![Generate Demo JSON Data](https://github.com/ivan-verges/TestResultsAnalizer/blob/master/Screenshots/Web01.png?raw=true)

- View Analysis Graphs 1
![View Analysis Graphs 1](https://github.com/ivan-verges/TestResultsAnalizer/blob/master/Screenshots/Web02.png?raw=true)

- View Analysis Graphs 2
![View Analysis Graphs 2](https://github.com/ivan-verges/TestResultsAnalizer/blob/master/Screenshots/Web03.png?raw=true)

- View Analysis Graphs 3
![View Analysis Graphs 3](https://github.com/ivan-verges/TestResultsAnalizer/blob/master/Screenshots/Web04.png?raw=true)

- View Analysis Data 1
![View Analysis Data 1](https://github.com/ivan-verges/TestResultsAnalizer/blob/master/Screenshots/Web05.png?raw=true)

- View Analysis Data 2
![View Analysis Data 2](https://github.com/ivan-verges/TestResultsAnalizer/blob/master/Screenshots/Web06.png?raw=true)

- View CSV File Download
![View CSV File Download](https://github.com/ivan-verges/TestResultsAnalizer/blob/master/Screenshots/Web07.png?raw=true)

- View CSV File Content in Excel
![View CSV File Content in Excel](https://github.com/ivan-verges/TestResultsAnalizer/blob/master/Screenshots/Web08.png?raw=true)

- View CSV File Content in Notepad++
![View CSV File Content in Notepad++](https://github.com/ivan-verges/TestResultsAnalizer/blob/master/Screenshots/Web09.png?raw=true)


## Authors
- [@ivan-verges](https://github.com/ivan-verges/)