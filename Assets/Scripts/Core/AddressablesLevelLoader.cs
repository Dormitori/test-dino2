using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;
using System.Collections;

public class AddressablesLevelLoader : MonoBehaviour
{
    public static AddressablesLevelLoader Instance { get; private set; }
    
    [SerializeField] private SplashScreen splashScreen;
    
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
            splashScreen.Show();
        }
        
        if (currentSceneHandle.IsValid())
        {
            var unloadOperation = Addressables.UnloadSceneAsync(currentSceneHandle);
            yield return unloadOperation;
        }
        
        var loadOperation = Addressables.LoadSceneAsync(levelAddress, LoadSceneMode.Single);
        
        while (!loadOperation.IsDone)
        {
            float progress = loadOperation.PercentComplete;
            
            if (splashScreen != null)
            {
                splashScreen.UpdateProgress(progress);
            }
            
            yield return null;
        }
        
        if (loadOperation.Status == AsyncOperationStatus.Succeeded)
        {
            currentSceneHandle = loadOperation;
            
            if (splashScreen != null)
            {
                splashScreen.UpdateProgress(1f);
                yield return new WaitForSeconds(0.5f);
                splashScreen.Hide();
            }
        }
        else
        {
            Debug.LogError($"Failed to load level: {levelAddress}");
            if (splashScreen != null)
            {
                splashScreen.Hide();
            }
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
