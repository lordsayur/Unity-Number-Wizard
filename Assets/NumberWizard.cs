using UnityEngine;

public class NumberWizard : MonoBehaviour
{
    [SerializeField]
    private int max = 1000;
    [SerializeField]
    private int min = 1;

    void Start()
    {
        Debug.Log("Selamat datang ke Setau Gaban.");
        Debug.Log("Cuba pilih numbur lapas tu jangan bagi tau...");
        Debug.Log($"Numbur paling basar: {max}");
        Debug.Log($"Numbur paling damit: {min}");
    }
}
