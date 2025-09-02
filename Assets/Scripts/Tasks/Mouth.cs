using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Mouth : MonoBehaviour
{
    public Teeth[] teethList;

    public Color32 colorClean, colorDirty;

    public void MakeTeethDirty()
    {
        foreach (Teeth go in teethList) 
        {
            if (go != null) 
            {
                float ran = Random.Range(0f, 1f);
                go.ChangeColor(Color.Lerp(colorClean, colorDirty, ran));
                go.dirtyness = ran;
            }
        }
    }
    void Start()
    {
        teethList = GetComponentsInChildren<Teeth>();
        MakeTeethDirty();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Teeth go in teethList) 
        {
            if(go.dirtyness >= 0f)
            {
                go.ChangeColor(Color.Lerp(colorClean, colorDirty, go.dirtyness));
            }
        }
    }

    public float GetDirtiness()
    {
        float dirt = 0;
        foreach(Teeth go in teethList)
        {
            dirt += go.dirtyness;
        }
        return dirt;
    }
}
