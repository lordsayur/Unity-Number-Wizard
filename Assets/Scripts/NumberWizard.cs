using UnityEngine;

public class NumberWizard : MonoBehaviour
{
    [SerializeField]
    private int _max = 1000;
    [SerializeField]
    private int _min = 1;
    [SerializeField]
    private int _ourGuess = 500;

    private NumberWizardData _numberWizardData;

    void Awake()
    {
        InitWizardNumberData(_max, _min, _ourGuess);
    }

    void Start()
    {
        Debug.Log("Selamat datang ke Setau Gaban.");
        Debug.Log("Cuba pilih numbur lapas tu jangan bagi tau...");
        Debug.Log($"Numbur paling basar: {_numberWizardData.Max}");
        Debug.Log($"Numbur paling damit: {_numberWizardData.Min}");
        Debug.Log($"Bagi tau kalau numbur mu lagi basar atau damit dari {_numberWizardData.OurGuess}");
        Debug.Log("Takan arrow atas = lagi basar. Takan arrow bawah = lagi damit. Takan enter = enggam!");
        _numberWizardData.Max += 1;
    }

    void Update()
    {
        GetPlayerInput();
    }

    public void InitWizardNumberData(int max, int min, int ourGuess)
    {
        _numberWizardData = new NumberWizardData()
        {
            Max = max,
            Min = min,
            OurGuess = ourGuess
        };
    }

    public void PlayerRespond(string respond)
    {
        Debug.Log(respond);
        if (respond == "Enggam!") return;

        RespondToPlayer(respond);
    }

    public int GetOurGuess()
    {
        return _numberWizardData.OurGuess;
    }

    private void GetPlayerInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            PlayerRespond("Lagi Basar");
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            PlayerRespond("Lagi Damit");
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            PlayerRespond("Enggam!");
        }
    }

    private void RespondToPlayer(string tresholdValue)
    {
        switch (tresholdValue)
        {
            case "Lagi Basar":
                _numberWizardData.Min = _numberWizardData.OurGuess;
                break;
            case "Lagi Damit":
                _numberWizardData.Max = _numberWizardData.OurGuess;
                break;
            default:
                break;
        }

        _numberWizardData.OurGuess = (_numberWizardData.Max + _numberWizardData.Min) / 2;
        Debug.Log($"Okay, lagi basar atau damit dari {_numberWizardData.OurGuess}");
    }
}
