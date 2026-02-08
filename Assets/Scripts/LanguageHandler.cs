using UnityEngine;
using YG;

public static class LanguageHandler
{
    static public LanguageType language = LanguageType.Russian;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    static void Initialize()
    {
        // Get initial language from YG2
        UpdateLanguageFromYG2(YG2.lang);
        
        // Subscribe to language change events
        YG2.onSwitchLang += UpdateLanguageFromYG2;
        YG2.onCorrectLang += UpdateLanguageFromYG2;
    }

    static void UpdateLanguageFromYG2(string langCode)
    {
        language = langCode.ToLower() switch
        {
            "en" => LanguageType.English,
            "ru" => LanguageType.Russian,
            _ => LanguageType.Russian
        };
    }

    public static string GetLanguageCode()
    {
        return language switch
        {
            LanguageType.English => "en",
            LanguageType.Russian => "ru",
            _ => "ru"
        };
    }
}

public enum LanguageType
{
    Russian,
    English
}