using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereShape : BaseShape
{


    // Start is called before the first frame update
    void Start()
    {
        init();  
    }


    public override void Blink( bool action )
    {
        if( action)
        {
            mat.SetColor("_EmissionColor", new Vector4(1, 0.5f, 0.5f, 1));
        }

        base.Blink(action);
    }


}
