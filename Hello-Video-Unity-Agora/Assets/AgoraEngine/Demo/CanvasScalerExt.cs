using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class CanvasScalerExt : CanvasScaler
{

    Vector2 LandSolution = new Vector2(1500, 2040); // y doesn't matter
    Vector2 PortSolution = new Vector2(600, 400); // y doesn't matter

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (Screen.width > Screen.height)
        {
            m_ReferenceResolution = LandSolution;
        }
        else
        {
            m_ReferenceResolution = PortSolution;
        }
    }
}
