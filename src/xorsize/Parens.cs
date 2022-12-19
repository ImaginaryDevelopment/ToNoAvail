namespace XOrSize;

using System.Linq;

public static class Parens {

    public static string? IsValidStr(string text){
        var balanced = 0;
        foreach(var c in text){
            if(c == ')' && balanced < 1) return "Too many closes";
            if(c == '(') balanced += 1;
            if(c == ')') balanced -= 1;
        }
        if(balanced != 0) return $"Parents Imbalance {balanced}";
        return null;

    }

    public static (string,bool)[] TestCases = new []{
        ("()", true),
        ("(()", false),
        ("(())", true),
        ("(()())", true),
        ("()((()()))", true),
        ("())", false)
    };
    public static void RunTest(){
        foreach(var x in TestCases){
            var pretty = (IsValidStr(x.Item1), x.Item2, x.Item1);
            Console.WriteLine(pretty);

        }
    }
}