using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [Header("Scene Names")]
    [SerializeField] private string day1SceneName = "Day1";

    // 从 Main 进入 Day1
    public void LoadDay1()
    {
        if (string.IsNullOrEmpty(day1SceneName))
        {
            Debug.LogWarning("[SceneLoader] day1SceneName 为空，无法加载场景。", this);
            return;
        }

        SceneManager.LoadScene(day1SceneName);
    }
}
