using System.Text.RegularExpressions;

namespace AutoAwaken
{
    /// <summary>
    /// The answer from StatChecker: should we stop rolling, and if so why
    /// and which stats should be highlighted in the log.
    /// </summary>
    record CheckResult(bool IsGoodRoll, string Message, List<string> MatchedStats)
    {
        public static readonly CheckResult KeepRolling = new(false, "", new List<string>());
    }

    /// <summary>
    /// Decides whether the stats read from the screen are good enough to stop.
    /// </summary>
    static class StatChecker
    {
        /// <summary>Stats that are added to the wanted list when "With Semi Perfect" is checked.</summary>
        public static readonly string[] SemiPerfectStats =
        {
            "INT +25",
            "STA +25",
            "Increased Critical Damage +17%",
            "MP +450",
        };

        /// <param name="text">The text read from the screen.</param>
        /// <param name="wantedStats">The stats checked in the Option box.</param>
        /// <param name="mode">"Strict", "Mix" or "Hybrid".</param>
        /// <param name="statCount">The "Stat Count" number.</param>
        /// <param name="withSemiPerfect">Whether "With Semi Perfect" is checked.</param>
        public static CheckResult Check(string text, List<string> wantedStats, string? mode, int statCount, bool withSemiPerfect)
        {
            switch (mode)
            {
                case "Strict" when withSemiPerfect:
                    return CheckStrictWithSemiPerfect(text, wantedStats, statCount);
                case "Strict":
                    return CheckStrict(text, wantedStats, statCount);
                case "Mix":
                    return CheckMix(text, AddSemiPerfect(wantedStats, withSemiPerfect), statCount);
                case "Hybrid":
                    return CheckHybrid(text, AddSemiPerfect(wantedStats, withSemiPerfect));
                default:
                    return CheckResult.KeepRolling;
            }
        }

        /// <summary>Strict: one single stat must show up at least "Stat Count" times.</summary>
        private static CheckResult CheckStrict(string text, List<string> stats, int statCount)
        {
            foreach (string stat in stats)
            {
                int count = CountInText(text, stat);
                if (count >= statCount)
                {
                    return new CheckResult(true,
                        $"Strict mode: found {count}x '{stat}' (need {statCount}).",
                        new List<string> { stat });
                }
            }
            return CheckResult.KeepRolling;
        }

        /// <summary>Strict + Semi Perfect: all wanted stats together must show up at least "Stat Count" times.</summary>
        private static CheckResult CheckStrictWithSemiPerfect(string text, List<string> stats, int statCount)
        {
            List<string> allStats = stats.Concat(SemiPerfectStats).Distinct().ToList();
            int total = allStats.Sum(stat => CountInText(text, stat));

            if (total >= statCount)
            {
                return new CheckResult(true,
                    $"Strict + SemiPerf: total matches={total} (need {statCount}).",
                    allStats);
            }
            return CheckResult.KeepRolling;
        }

        /// <summary>Mix: any wanted stats together must show up at least "Stat Count" times.</summary>
        private static CheckResult CheckMix(string text, List<string> stats, int statCount)
        {
            int total = stats.Sum(stat => CountInText(text, stat));

            if (total >= statCount)
            {
                return new CheckResult(true,
                    $"Mix mode: total matches={total} (need {statCount}).",
                    stats);
            }
            return CheckResult.KeepRolling;
        }

        /// <summary>
        /// Hybrid: at least 3 wanted stats must show up, and they must be either
        /// 3 of the same stat, or 2 of the same stat plus a different one.
        /// </summary>
        private static CheckResult CheckHybrid(string text, List<string> stats)
        {
            var countPerStat = new Dictionary<string, int>();
            int total = 0;

            foreach (string stat in stats)
            {
                int count = CountInText(text, stat);
                if (count > 0)
                {
                    countPerStat[stat] = count;
                    total += count;
                }
            }

            if (total < 3)
            {
                Console.WriteLine("[Hybrid] Waiting for 3 stats...");
                return CheckResult.KeepRolling;
            }

            int mostOfOneStat = countPerStat.Values.Max();
            int differentStats = countPerStat.Count;

            bool threeSame = mostOfOneStat >= 3;
            bool twoSamePlusOther = mostOfOneStat == 2 && differentStats >= 2;

            if (threeSame || twoSamePlusOther)
            {
                return new CheckResult(true, "Hybrid: Valid stat combination.", countPerStat.Keys.ToList());
            }

            Console.WriteLine("[Hybrid] Not valid → continue");
            return CheckResult.KeepRolling;
        }

        private static List<string> AddSemiPerfect(List<string> stats, bool withSemiPerfect)
        {
            var result = new List<string>(stats);
            if (withSemiPerfect)
            {
                result.AddRange(SemiPerfectStats);
            }
            return result;
        }

        /// <summary>
        /// Counts how many times a stat appears in the text. Case and spaces are
        /// ignored, so "INT +28" also matches "int+28".
        /// </summary>
        public static int CountInText(string text, string stat)
        {
            string cleanStat = Regex.Replace(stat, @"\s+", " ").Trim();
            string pattern = Regex.Escape(cleanStat).Replace(@"\ ", @"\s*");
            return Regex.Matches(text, pattern, RegexOptions.IgnoreCase).Count;
        }
    }
}
