namespace MorphShared.Services
{
    public class FrequencyRankService
    {
        public string GetFrequencyRankSuffix(int frequencyRank)
        {
            var lastFreqNumeral = (int)frequencyRank.ToString().Last();

            if (frequencyRank < 10 || frequencyRank > 20)
            {
                if (lastFreqNumeral == 1)
                {
                    return "st";
                }
                else if (lastFreqNumeral == 2)
                {
                    return "nd";
                }
                else if (lastFreqNumeral == 3)
                {
                    return "rd";
                }
            }

            return "th";
        }
    }
}
