using System;
using System.Collections.Generic;

namespace PromptOptimizer.Engine
{
    public class Metrics
    {
        private List<AnalysisScores> history = new List<AnalysisScores>();

        public void RecordAnalysis(AnalysisScores scores)
        {
            history.Add(scores);
        }

        public double GetAverageClarityScore()
        {
            if (history.Count == 0) return 0;
            double sum = 0;
            foreach (var score in history)
                sum += score.Clarity;
            return sum / history.Count;
        }

        public double GetAverageSpecificityScore()
        {
            if (history.Count == 0) return 0;
            double sum = 0;
            foreach (var score in history)
                sum += score.Specificity;
            return sum / history.Count;
        }

        public double GetAverageCompletenessScore()
        {
            if (history.Count == 0) return 0;
            double sum = 0;
            foreach (var score in history)
                sum += score.Completeness;
            return sum / history.Count;
        }

        public double GetAverageOverallScore()
        {
            if (history.Count == 0) return 0;
            double sum = 0;
            foreach (var score in history)
                sum += score.Overall;
            return sum / history.Count;
        }

        public int GetTotalAnalyses()
        {
            return history.Count;
        }

        public void ClearHistory()
        {
            history.Clear();
        }
    }
}
