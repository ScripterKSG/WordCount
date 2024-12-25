using System.Text.RegularExpressions;

class Program {
    public static void Main(string[] args)
    {
        Dictionary<string, int> counts = new Dictionary<string, int>();
        // put directory of txt file here
        using (var reader = new StreamReader(@"tests\test1.txt")) {
            string line;
            while ((line = reader.ReadLine()) != null) {
                string cleanLine = Regex.Replace(line.ToLower(), @"[^\w\s]", "");
                string[] words = cleanLine.Split(new[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string word in words) {
                    if (counts.ContainsKey(word)) counts[word]++;
                    else counts[word] = 1;
                }
            }
        }
        Console.WriteLine("All Word Counts:");
        foreach (var pair in counts.OrderByDescending(p => p.Value)) {
            Console.WriteLine($"{pair.Key}: {pair.Value}");
        }        
    }
}