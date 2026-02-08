using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SplashScreen : MonoBehaviour
{
    [SerializeField] private GameObject splashPanel;
    [SerializeField] private Slider progressBar;
    [SerializeField] private TextMeshProUGUI progressText;
    [SerializeField] private CanvasGroup canvasGroup;
    
    private void Awake()
    {
        if (canvasGroup == null)
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }
        
        Hide();
    }
    
    public void Show()
    {
        if (splashPanel != null)
        {
            splashPanel.SetActive(true);
        }
        
        if (canvasGroup != null)
        {
            canvasGroup.alpha = 1f;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = true;
        }
        
        UpdateProgress(0f);
    }
    
    public void Hide()
    {
        if (splashPanel != null)
        {
            splashPanel.SetActive(false);
        }
        
        if (canvasGroup != null)
        {
            canvasGroup.alpha = 0f;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }
    }
    
    public void UpdateProgress(float progress)
    {
        progress = Mathf.Clamp01(progress);
        
        if (progressBar != null)
        {
            progressBar.value = progress;
        }
        
        if (progressText != null)
        {
            progressText.text = $"{Mathf.RoundToInt(progress * 100)}%";
        }
    }
}
