public class NumberWizardData
{
    public int Max { get; set; }
    public int Min { get; set; }
    public int OurGuess { get; set; }

    public void InitData(int max, int min, int ourGuess)
    {
        Max = max;
        Min = min;
        OurGuess = ourGuess;
    }
}
