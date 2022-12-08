using Async1.FileOperations;

string currentDirectory = Directory.GetCurrentDirectory(),
    pathHello = currentDirectory + "\\Hello.txt",
    pathWorld = currentDirectory + "\\World.txt";
var fileOperator = new FileOperator();
fileOperator.WriteTextInFile("Hello", pathHello);
fileOperator.WriteTextInFile("World", pathWorld);
Console.WriteLine(await fileOperator.ReadHelloWorldFromFile(pathHello, pathWorld));