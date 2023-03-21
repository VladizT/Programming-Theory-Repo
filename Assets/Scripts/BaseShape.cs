using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class BaseShape : MonoBehaviour
{

    [SerializeField]
    GameObject highlightObject;

    protected Material mat;
    protected Color baseColorEmisson;
    

    private void Awake()
    {
        mat = gameObject.GetComponent<MeshRenderer>().material;
        baseColorEmisson = mat.GetColor("_EmissionColor");
    }

    private void Start()
    {
        
    }

    protected virtual void init()
    {
        HighlightAction(false);
        //Blink(true);
    }

    public void HighlightAction(bool action)
    {
        highlightObject.SetActive(action);
    }

    public virtual void Blink( bool action )
    {
        
        if( !action )
        {
            mat.SetColor("_EmissionColor", baseColorEmisson);
        }
        
    }

    protected void OnMouseDown()
    {
        if (highlightObject.activeSelf)
        {
            Blink(true);
        }
        
    }

    private void OnMouseUp()
    {
        if (highlightObject.activeSelf)
        {
            Blink(false);
            highlightObject.SetActive(false);
            F.GC<GameManager>("Game Manager").Check();
        }
    }

}
