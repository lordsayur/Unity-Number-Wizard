using UnityEngine;

public class BinarySearchEngine : MonoBehaviour, IGuessEngine
{
    public int MakeAGuess(NumberWizardData numberWizardData)
    {
        return (numberWizardData.Max + numberWizardData.Min) / 2;
    }
}
