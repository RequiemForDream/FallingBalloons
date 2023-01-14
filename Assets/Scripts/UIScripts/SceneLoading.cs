using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoading : MonoBehaviour
{
    [SerializeField] private string sceneName;

    public void Load()
    {
        SceneManager.LoadScene(sceneName);
    }
}
