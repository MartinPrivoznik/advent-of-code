using aoc._2024;
using Microsoft.Extensions.Configuration;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

var sessionKey = configuration["SessionKey"] ?? "";

var day1 = new Day1(sessionKey);
await day1.LoadInput();
var day1Solution = day1.Solve();
Console.WriteLine("Day 1 - 1: " + day1Solution.Solution1);
Console.WriteLine("Day 1 - 2: " + day1Solution.Solution2);

var day2 = new Day2(sessionKey);
await day2.LoadInput();
var day2Solution = day2.Solve();
Console.WriteLine("Day 2 - 1: " + day2Solution.Solution1);
Console.WriteLine("Day 2 - 2: " + day2Solution.Solution2);

