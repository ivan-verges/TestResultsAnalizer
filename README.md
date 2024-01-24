
# Test Results Analyzer

This project is as a demosntration on how we can use the results from automated tests executions, parse the data from JSON to actual C# objects, do some analysis and generate a resume based on the data, and even export a summary to CSV.

This solution contains 4 projects:
 - TestResultsAnalyzer.Client => A simple Blazor WASM web app to demonstrate Analysis Data.
 - TestResultsAnalyzer.CommandLine: => A simple CLI app to demonstrate functionalities.
 - TestResultsAnalyzer.Server => A simple Web API to consume interact with the analyzer.
 - TestResultsAnalyzer.Shared => Common project with Analyzer logic and Data Models.


## Tech Stack

 - Visual Studio 2022
 - .NET V7.0
 - Blazor
 - WASM

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
          }
        ]
      }
    ]
  }
]
```

## Dependencies

To run this project you need to install the .NET 7.0 SDK, which you can download from here:('https://dotnet.microsoft.com/en-us/download/visual-studio-sdks')

## How to run this project

To run this project as a Web App, it's recommended to open it with Visual Studio 2022, select (or set as default) the project "TestResultsAnalyzer.Server", and execute it by pressing keys "Ctrl" + "F5".

To run this project as a Console Application, it's recommended to open it with Visual Studio 2022, select (or set as default) the project "TestResultsAnalyzer.CommandLine", and execute it by pressing keys "Ctrl" + "F5".


## Screenshots (Web App)

![App Screenshot](https://via.placeholder.com/468x300?text=App+Screenshot+Here)

## Screenshots (Console App)

![App Screenshot](https://via.placeholder.com/468x300?text=App+Screenshot+Here)

