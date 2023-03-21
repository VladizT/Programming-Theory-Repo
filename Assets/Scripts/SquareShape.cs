﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareShape : BaseShape
{
    // Start is called before the first frame update
    void Start()
    {
        init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Blink(bool action)
    {
        if (action)
        {
            mat.SetColor("_EmissionColor", new Vector4(0.5f, 1, 0.5f, 1));
        }

        base.Blink(action);
    }

}
