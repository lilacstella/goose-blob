using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SceneManager : MonoBehaviour
{
    public static SceneManager Instance;

    public Animator sceneChangeAnimator;
    private AudioSource _audio;

    private void Awake()
    {
        if (Instance == null) { Instance = this; DontDestroyOnLoad(this); }
        else { Destroy(gameObject); }

        _audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)) { SwitchScene(0); }
        if(Input.GetKeyDown(KeyCode.Alpha2)) { SwitchScene(1); }
    }

    public void SwitchScene(int scene)
    {
        StartCoroutine(WaitScene(sceneChangeAnimator, scene));

        IEnumerator WaitScene(Animator animator, int scene)
        {
            animator.Play("Start");
            yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
            UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
            _audio.Play();
            animator.Play("End");
        }
    }
}
