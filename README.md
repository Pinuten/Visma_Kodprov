# VismaSpcs Recruitment Assignment

Code test for Visma where I was tasked to retrieve data from a REST API. I chose SMHI’s API (Swedish Meteorological and Hydrological Institute).

Clone the repo, cd into `VismaSpcs.Recruitment.Rest`, and run:

```bash
dotnet run
```
To run the tests, cd into Visma.Tests and run:

```bash
dotnet test
```

## Task Description

ApiClient: Used to retrieve objects from a REST API.
PrettyPrinter: Used to format and print the fetched objects.

## Implementation

### ApiClient.cs
This class fetches weather data from the SMHI API, filters it based on a parameter, and limits the results to the first 10 records.

### PrettyPrinter.cs
This class formats and prints the fetched weather data, displaying the time, temperature, and wind speed.

### Program.cs
The Main method initializes the ApiClient and PrettyPrinter, fetches the data based on user input, and prints the results.

### Visma.Tests

Tests where added for both the ApiClient and PrettyPrinter to ensure functionality and correct output. 
