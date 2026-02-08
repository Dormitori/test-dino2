using UnityEngine;
using UnityEngine.UI;

public class LanguageChanger : MonoBehaviour
{
    public GameObject Pn_Exit;
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
        LanguageHandler.language = (LanguageHandler.language == LanguageType.English)
            ? LanguageType.Russian
            : LanguageType.English;
        if (LanguageHandler.language == LanguageType.English)
        {
            GameObject.Find("TextDino").GetComponent<Text>().text = "Dinosaur puzzles";
        }
        else
        {
            GameObject.Find("TextDino").GetComponent<Text>().text = "Пазлы динозавры";
        }
    }
}