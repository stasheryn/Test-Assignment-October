using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Tooltip("Назва сцени з геймплеєм. Введи точну назву сцени тут.")]
    public string gameplaySceneName = "Gameplay";

    // Викликається з Button OnClick()
    public void PlayGame()
    {
        // Можна замінити на LoadSceneAsync для плавнішої загрузки
        SceneManager.LoadScene(gameplaySceneName);
    }

    // Викликається з Button OnClick()
    public void QuitGame()
    {
        // Якщо гра в редакторі — зупиняємо Play Mode
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
