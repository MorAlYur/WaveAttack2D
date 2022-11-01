using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;




/// <summary>
/// Asset usage example.
/// </summary>
public class Example : MonoBehaviour
{


    // public Text FormattedText;

    /// <summary>
    /// Called on app start.
    /// </summary>
    public void Awake()
    {
        LocalizationManager.Read();

        if (PlayerPrefs.HasKey("language"))
        {
            LocalizationManager.Language = PlayerPrefs.GetString("language");
        }
        else
        {
            switch (Application.systemLanguage)
            {
                case SystemLanguage.Russian:
                    LocalizationManager.Language = "Russian";
                    PlayerPrefs.SetString("language", "Russian");
                    break;
                case SystemLanguage.Belarusian:
                    LocalizationManager.Language = "Russian";
                    PlayerPrefs.SetString("language", "Russian");
                    break;
                case SystemLanguage.Ukrainian:
                    LocalizationManager.Language = "Russian";
                    PlayerPrefs.SetString("language", "Russian");
                    break;
                case SystemLanguage.English:
                    LocalizationManager.Language = "English";
                    PlayerPrefs.SetString("language", "English");
                    break;
                default:
                    LocalizationManager.Language = "English";
                    PlayerPrefs.SetString("language", "English");
                    break;
            }
        }
        // This way you can insert values to localized strings.
        //FormattedText.text = LocalizationManager.Localize("Settings.PlayTime", TimeSpan.FromHours(10.5f).TotalHours);

        // This way you can subscribe to localization changed event.
        //LocalizationManager.LocalizationChanged += () => FormattedText.text = LocalizationManager.Localize("Settings.PlayTime", TimeSpan.FromHours(10.5f).TotalHours);
    }

    /// <summary>
    /// Change localization at runtime
    /// </summary>
    public void SetLocalization(string localization)
    {
        LocalizationManager.Language = localization;
        PlayerPrefs.SetString("language",localization);
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    /// <summary>
    /// Write a review.
    /// </summary>
    
}
