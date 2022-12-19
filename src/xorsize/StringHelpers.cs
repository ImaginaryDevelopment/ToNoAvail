namespace XOrSize;

public static class StringHelpers {
    public static string Before(this string value, string delimiter) {
        var i = value.IndexOf(delimiter);
        if(i < 0) {
            Console.Error.WriteLine("value length was {0}", value.Length);
            Console.Error.WriteLine("'{0}' -> '{1}'", delimiter, value);
            throw new ArgumentOutOfRangeException();
        }
        return value.Substring(0,i);
    }
    public static string After(this string value, string delimiter){
        var i = value.IndexOf(delimiter);
        if(i < 0) throw new ArgumentOutOfRangeException();
        return value.Substring(i + delimiter.Length);

    }
    public static (string,string) SplitOn(this string value, string delimiter){
        return (value.Before(delimiter), value.After(delimiter));
    }

    public static IEnumerable<string> SplitCsvLine(string line){
        var rem = line;
        while(rem != ""){
            // Console.Error.WriteLine("Rem is '{0}'", rem);
            if(rem.StartsWith("\"")){
                // Console.WriteLine("rem is '{0}' in '{1}'", rem, line);
                var (value,aft) = rem.Substring(1).SplitOn("\"");
                // Console.WriteLine("value is '{0}' in '{1}'", value,rem);
                // skip the opening "
                yield return value;
                // skip the trailing comma
                if(aft.Length > 0 && aft.StartsWith(",")){
                    rem = aft.Substring(1);
                } else {
                    rem = aft;
                }
                continue;
            }
            switch(rem.IndexOf(",")){
                case int i when i < 0:
                    yield return rem;
                    rem = "";
                    break;
                case int i when i == 0: // empty field
                    rem = rem.Substring(1);
                    yield return "";
                    break;
                default:
                    var (value,aft) = rem.SplitOn(",");
                    yield return value;
                    rem = aft;
                    break;
            }
        }
    }
}