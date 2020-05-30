using System;
using UnityEngine;

public class NumberWizard : MonoBehaviour
{
    [SerializeField]
    private int _max = 1000;
    [SerializeField]
    private int _min = 1;
    [SerializeField]
    private int _ourGuess = 500;

    private IGuessEngine guessEngine;
    private NumberWizardData _numberWizardData;

    void Awake()
    {
        _numberWizardData = new NumberWizardData();
        guessEngine = GetComponent<IGuessEngine>();
    }

    void Start()
    {
        StartGame();
    }

    void Update()
    {
        GetPlayerInput();
    }

    public void SetData(int max, int min, int ourGuess)
    {
        _max = max;
        _min = min;
        _ourGuess = ourGuess;
    }

    public int GetOurGuess()
    {
        return _numberWizardData.OurGuess;
    }

    private void StartGame()
    {
        _numberWizardData.InitData(_max, _min, _ourGuess);
        Debug.Log("Selamat datang ke Setau Gaban.");
        Debug.Log("Cuba pilih numbur lapas tu jangan bagi tau...");
        Debug.Log($"Numbur paling basar: {_numberWizardData.Max}");
        Debug.Log($"Numbur paling damit: {_numberWizardData.Min}");
        Debug.Log($"Bagi tau kalau numbur mu lagi basar atau damit dari {_numberWizardData.OurGuess}");
        Debug.Log("Takan arrow atas = lagi basar. Takan arrow bawah = lagi damit. Takan enter = enggam!");
        _numberWizardData.Max += 1;
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

    public void PlayerRespond(string respond)
    {
        Debug.Log(respond);
        RespondToPlayer(respond);
    }

    private void RespondToPlayer(string tresholdValue)
    {
        if (tresholdValue == "Enggam!")
        {
            Debug.Log("Hey, Jangan ku di puji!");
            return;
        }

        switch (tresholdValue)
        {
            case "Lagi Basar":
                _numberWizardData.Min = _numberWizardData.OurGuess;
                break;
            case "Lagi Damit":
                _numberWizardData.Max = _numberWizardData.OurGuess;
                break;
            default:
                throw new ArgumentException("Invalid response.");
        }

        _numberWizardData.OurGuess = guessEngine.MakeAGuess(_numberWizardData);
        Debug.Log($"Okay, lagi basar atau damit dari {_numberWizardData.OurGuess}");
    }
}
