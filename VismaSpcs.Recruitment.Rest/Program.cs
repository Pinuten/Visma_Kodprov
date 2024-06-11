using VismaSpcs.Recruitment.Rest;

var apiClient = new ApiClient();

var objectList = apiClient.GetObjects<object>(); //object should be replaced with a defined type
PrettyPrinter.Print<object>(objectList); //object should be replaced with a defined type

Console.ReadLine();
