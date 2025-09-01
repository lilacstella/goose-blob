using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class MouthAndTeeth : MonoBehaviour
{
    public List<SpriteRenderer> teethList;

    public Color colorRangeBeginning, colorRangeEnding;

    public void DirtyTeeth()
    {
        foreach (SpriteRenderer go in teethList) { }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
