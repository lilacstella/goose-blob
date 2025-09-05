using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public void SwitchScene(int scene)
    {
        if (SceneManager.Instance != null) { SceneManager.Instance.SwitchScene(scene); }
    }

    public void ExitGame()
    {

    }
}
