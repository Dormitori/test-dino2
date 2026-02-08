using System;
using UnityEngine;
using YG;

public static class LanguageHandler
{
    static public LanguageType language = LanguageType.Russian;
    
    public static Action onLanguageChanged;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    static void Initialize()
    {
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
        
        onLanguageChanged?.Invoke();
    }
}

public enum LanguageType
{
    Russian,
    English
}