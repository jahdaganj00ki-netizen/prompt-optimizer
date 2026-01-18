using System;
using System.Linq;

namespace PromptOptimizer.Engine
{
    public class AnalysisScores
    {
        public double Clarity { get; set; }
        public double Specificity { get; set; }
        public double Completeness { get; set; }
        public double Overall => (Clarity + Specificity + Completeness) / 3;
    }

    public class PromptAnalyzer
    {
        public AnalysisScores Analyze(string prompt)
        {
            if (string.IsNullOrWhiteSpace(prompt))
                return new AnalysisScores { Clarity = 0, Specificity = 0, Completeness = 0 };

            var scores = new AnalysisScores
            {
                Clarity = CalculateClarity(prompt),
                Specificity = CalculateSpecificity(prompt),
                Completeness = CalculateCompleteness(prompt)
            };

            return scores;
        }

        private double CalculateClarity(string prompt)
        {
            double score = 50;

            // Penalize for excessive length
            if (prompt.Length > 500)
                score -= 10;
            else if (prompt.Length < 20)
                score -= 15;

            // Reward for punctuation
            int punctuationCount = prompt.Count(c => ".!?".Contains(c));
            score += Math.Min(punctuationCount * 5, 20);

            // Penalize for unclear words
            string[] unclearWords = { "maybe", "probably", "somehow", "something", "anything" };
            int unclearCount = unclearWords.Count(word => prompt.ToLower().Contains(word));
            score -= unclearCount * 5;

            return Math.Max(0, Math.Min(100, score));
        }

        private double CalculateSpecificity(string prompt)
        {
            double score = 50;

            // Reward for specific keywords
            string[] specificKeywords = { "specific", "exactly", "precisely", "detailed", "concrete", "example", "particular" };
            int specificCount = specificKeywords.Count(keyword => prompt.ToLower().Contains(keyword));
            score += specificCount * 8;

            // Penalize for vague language
            string[] vagueWords = { "good", "bad", "nice", "interesting", "important" };
            int vagueCount = vagueWords.Count(word => prompt.ToLower().Contains(word));
            score -= vagueCount * 3;

            // Reward for numbers and metrics
            int numberCount = prompt.Count(char.IsDigit);
            score += Math.Min(numberCount * 2, 15);

            return Math.Max(0, Math.Min(100, score));
        }

        private double CalculateCompleteness(string prompt)
        {
            double score = 50;

            // Check for key components
            string[] keyComponents = { "what", "how", "why", "when", "where", "who" };
            int componentCount = keyComponents.Count(component => prompt.ToLower().Contains(component));
            score += componentCount * 5;

            // Reward for context
            if (prompt.Length > 100)
                score += 10;

            // Penalize for incomplete sentences
            int sentenceCount = prompt.Count(c => ".!?".Contains(c));
            if (sentenceCount == 0)
                score -= 20;

            return Math.Max(0, Math.Min(100, score));
        }
    }
}
