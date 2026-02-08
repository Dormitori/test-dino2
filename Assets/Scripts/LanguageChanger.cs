using UnityEngine;
using UnityEngine.UI;

public class LanguageChanger : MonoBehaviour
{
    public GameObject Pn_Exit;
    
    private void OnEnable()
    {
        LanguageHandler.onLanguageChanged += UpdateUI;
        UpdateUI();
    }
    
    private void OnDisable()
    {
        LanguageHandler.onLanguageChanged -= UpdateUI;
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Pn_Exit.activeSelf == true)
            {
                Pn_Exit.SetActive(false);
            }
            else
            {
                Pn_Exit.SetActive(true);
            }
        }
    }

    private void OnGUI()
    {
        if (LanguageHandler.language == LanguageType.English)
        {
            GetComponent<Text>().text = "EN";
        }
        else
        {
            GetComponent<Text>().text = "RU";
        }
    }

    public void ChangeLanguage()
    {
        string newLang = (LanguageHandler.language == LanguageType.English) ? "ru" : "en";
        YG.YG2.SwitchLanguage(newLang);
    }
    
    private void UpdateUI()
    {
        GameObject textDino = GameObject.Find("TextDino");
        if (textDino != null)
        {
            if (LanguageHandler.language == LanguageType.English)
            {
                textDino.GetComponent<Text>().text = "Dinosaur puzzles";
            }
            else
            {
                textDino.GetComponent<Text>().text = "Пазлы динозавры";
            }
        }
    }
}