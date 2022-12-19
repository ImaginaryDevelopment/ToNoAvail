namespace XOrSize;

using System.IO;

public record HUser (int Id, string Name, string ICompany, int Version);

public static class HealthCsv {
    public static HUser CreateHUser(IReadOnlyList<string> fields){
        return new HUser(int.Parse(fields[0]),fields[1], fields[2],
            // allow empty last field
            fields.Count > 3 ? int.Parse(fields[3]) : 0);
    }
    public static IEnumerable<HUser> ReadHealthCsv(string path, bool includesHeader){
        return ReadCsv(path,includesHeader).Select(CreateHUser);
    }
    public static IEnumerable<string[]> ReadCsv(string path,bool includesHeader){
        var lines = File.ReadAllLines(path);
        if(includesHeader) lines = lines.Skip(1).ToArray();
        return lines.Select(StringHelpers.SplitCsvLine).Select(x => x.ToArray());
    }
    public static IEnumerable<HUser> Sanitize(IEnumerable<HUser> users) =>
        users.GroupBy(x => x.Id).SelectMany(g => g.OrderByDescending(h => h.Version).Take(1));
}