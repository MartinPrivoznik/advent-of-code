using aoc_lib.Base;

namespace aoc._2024;

public class Day5(string sessionKey) : AocBase<int>(2024, 5, sessionKey, true)
{
    private class Rule(string ruleRow)
    {
        public int Before { get; } = Convert.ToInt32(ruleRow.Split('|')[0]);
        public int After { get; } = Convert.ToInt32(ruleRow.Split('|')[1]);
    }
    
    private class Update(string updateRow)
    {
        public List<int> Sequence { get; } = updateRow
            .Split(',')
            .Where(val => !string.IsNullOrEmpty(val))
            .Select(val => Convert.ToInt32(val))
            .ToList();
    }
    
    public override object SolveTask1()
    {
        var x = Input.RawData;
        var rules = x.Split("\n\n")[0]
            .Split("\n")
            .Select(row => new Rule(row))
            .ToList();
        
        var updates = x.Split("\n\n")[1]
            .Split("\n")
            .Where(row => !string.IsNullOrWhiteSpace(row))
            .Select(row => new Update(row))
            .ToList();

        var sum = 0;
        
        foreach (var update in updates)
        {
            var isValid = true;
            
            foreach (var page in update.Sequence)
            {
                //Check rules for each page. If a rule is violated, the sequence is invalid
                var pageRules = rules.Where(r => r.After == page).ToList();
                var pageIndex = update.Sequence.IndexOf(page);
                var followingPages = update.Sequence.Skip(pageIndex + 1).ToList();
                
                if (pageRules.Any(rule => followingPages.Contains(rule.Before)))
                    isValid = false;
            }

            if (isValid)
                sum += update.Sequence[update.Sequence.Count / 2];
        }

        return sum;
    }

    public override object SolveTask2()
    {
        throw new NotImplementedException();
    }
}