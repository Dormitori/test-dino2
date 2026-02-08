using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject previousButton;
    [SerializeField]
    private GameObject nextButton;

    public GameObject puzzleName;
    
    [SerializeField]
    private GameObject restartButton;

    [SerializeField]
    private string EnglishName;
    [SerializeField]
    private string RussianName;

    private PuzzleHandler _puzzleHandler;

    private void OnEnable()
    {
        _puzzleHandler.onPlayerWin += ActivateUI;
    }

    private void Awake()
    {
        _puzzleHandler = FindObjectOfType<PuzzleHandler>();
    }

    private void Start()
    {
        puzzleName.GetComponent<Text>().text = (LanguageHandler.language == LanguageType.English) ? EnglishName : RussianName;

        previousButton.SetActive(false);
        nextButton.SetActive(false);
        puzzleName.SetActive(false);
        restartButton.SetActive(false);
    }

    private void OnDisable()
    {
        _puzzleHandler.onPlayerWin -= ActivateUI;
    }

    private void ActivateUI()
    {
        StartCoroutine(WaitToActivate());
    }

    private IEnumerator WaitToActivate()
    {
        yield return new WaitForSeconds(0.2f);

        yield return new WaitForSeconds(14);
        previousButton.SetActive(true);
        nextButton.SetActive(true);

        restartButton.SetActive(true);
    }
}
