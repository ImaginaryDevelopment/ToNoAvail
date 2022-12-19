using XOrSize;

var settings = new {
    sayHello = false,
    runParensTest = false,
    runSplitTest = false,
    readCsv = false,
    dumpSerializedCsv = false,
    dumpFinalHealthData = new {
        truncate = true,
        show = true
    },
};

if(settings.sayHello){
    Console.WriteLine("Hello, World!");
}

if(settings.runParensTest){
    Parens.RunTest();
}

if(settings.runSplitTest){
    Console.WriteLine("Split test:");
    foreach(var field in StringHelpers.SplitCsvLine("10,Aurore Backhurst,\"Bottomline Technologies, Inc.\",2").ToArray()){
        Console.Write("\"{0}\",",field); // yes there is a trailing slash in output, I'm ok with that.
    }
    Console.WriteLine();
}

var hCsvPath = @"..\..\data\health.csv";
if(settings.readCsv){
    HealthCsv.ReadCsv(hCsvPath,true).ToArray();
}
var healthData = new Lazy<IReadOnlyList<HUser>>(() => HealthCsv.ReadHealthCsv(hCsvPath,true).ToArray());

if(settings.dumpSerializedCsv){
    Console.WriteLine("Helth:");
    foreach(var h in healthData.Value){
        Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(h));
    }
}

if(settings.dumpFinalHealthData.show){
    Console.WriteLine("All your helth are belong to us:");
    foreach(var h in HealthCsv.Sanitize(healthData.Value.Take(10))){
        Console.WriteLine("\t{0}", System.Text.Json.JsonSerializer.Serialize(h));
    }

}
