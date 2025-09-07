using UnityEngine;

public class TrashTask : Task
{
    public override void CompleteTask()
    {
        throw new System.NotImplementedException();
    }

    public override void StartTask()
    {
        if (PlayerInRange)
        {
            SceneManager.Instance.SwitchScene(SceneManager.Scenes.TRASH_SCENE);
        }
    }
}
