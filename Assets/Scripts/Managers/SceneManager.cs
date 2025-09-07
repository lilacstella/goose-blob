using System.Collections;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public static SceneManager Instance;

    public Animator sceneChangeAnimator;

    public enum Scenes { MAIN_MENU, GAME_SCENE, TRASH_SCENE}

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
            Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) { SwitchScene((int)Scenes.MAIN_MENU); }
        if (Input.GetKeyDown(KeyCode.Alpha2)) { SwitchScene((int)Scenes.GAME_SCENE); }
        if (Input.GetKeyDown(KeyCode.Alpha3)) { SwitchScene((int)Scenes.TRASH_SCENE); }
    }

    public void SwitchScene(int scene)
    {
        StartCoroutine(WaitScene(sceneChangeAnimator, scene));

        IEnumerator WaitScene(Animator animator, int scene)
        {
            animator.Play("Start");
            yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
            UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
            animator.Play("End");
        }
    }
    public void SwitchScene(Scenes scene) { SwitchScene((int)scene); }
}
