using UnityEngine;
using UnityEngine.UI;

public class MenuLevelButton : MonoBehaviour
{
    [SerializeField] private int levelIndex;
    [SerializeField] private Button button;
    
    private void Awake()
    {
        if (button == null)
        {
            button = GetComponent<Button>();
        }
        
        if (button != null)
        {
            button.onClick.AddListener(OnButtonClick);
        }
    }
    
    private void OnButtonClick()
    {
        if (AddressablesLevelLoader.Instance != null)
        {
            AddressablesLevelLoader.Instance.LoadLevel(levelIndex);
        }
    }
}
