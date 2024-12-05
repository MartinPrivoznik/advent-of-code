using aoc._2024;

const string sessionKey = "53616c7465645f5f7dad2f6361259592b2dabe4a9bc4019b28b52402aa79fe2d67a321490f5f6193bbe16c5ed96077bba3c28610cfc110a2e295bd80aaa9bc6e";

var day1 = new Day1(sessionKey);
await day1.LoadInput();
var day1Solution = day1.Solve();
Console.WriteLine("Day 1 - 1: " + day1Solution.Solution1);
Console.WriteLine("Day 1 - 2: " + day1Solution.Solution2);

var day2 = new Day2(sessionKey);
await day2.LoadInput();
Console.WriteLine("Day 2 - 1: " + day2.SolveTask1());