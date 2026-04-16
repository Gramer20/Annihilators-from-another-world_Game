using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    [SerializeField] private string _mainMenuSceneName = "01_MainMenu";
    [SerializeField] private string _gameLevelSceneName = "02_GameLevel";
    [SerializeField] private string _fatalSceneSceneName = "03_FatalScene";
    [SerializeField] private string _finalSceneSceneName = "04_FinalScene";

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(_mainMenuSceneName);
    }
    public void LoadGameLevel()
    {
        SceneManager.LoadScene(_gameLevelSceneName);
    }
    public void LoadFatalScene()
    {
        SceneManager.LoadScene(_fatalSceneSceneName);
    }
    public void LoadFinalScene()
    {
        SceneManager.LoadScene(_finalSceneSceneName);
    }
}
