using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class AddressablesLevelLoader : MonoBehaviour
{
    public static AddressablesLevelLoader Instance { get; private set; }
    
    [SerializeField] private Image splashScreen;
    
    private AsyncOperationHandle<SceneInstance> currentSceneHandle;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void LoadLevel(string levelAddress)
    {
        StartCoroutine(LoadLevelRoutine(levelAddress));
    }
    
    public void LoadLevel(int levelIndex)
    {
        string levelAddress = $"Level {levelIndex}";
        LoadLevel(levelAddress);
    }
    
    private IEnumerator LoadLevelRoutine(string levelAddress)
    {
        if (splashScreen != null)
        {
            splashScreen.gameObject.SetActive(true);
        }
        
        if (currentSceneHandle.IsValid())
        {
            var unloadOperation = Addressables.UnloadSceneAsync(currentSceneHandle);
            yield return unloadOperation;
        }
        
        var loadOperation = Addressables.LoadSceneAsync(levelAddress);

        yield return loadOperation;

        if (loadOperation.Status == AsyncOperationStatus.Succeeded)
        {
            currentSceneHandle = loadOperation;
        }
        else
        {
            Debug.LogError($"Failed to load level: {levelAddress}");
        }

        if (splashScreen != null)
        {
            splashScreen.gameObject.SetActive(false);
        }
    }
    
    public void LoadMenuScene()
    {
        if (currentSceneHandle.IsValid())
        {
            Addressables.UnloadSceneAsync(currentSceneHandle);
        }
        
        SceneManager.LoadScene("MenuScene");
    }
}
