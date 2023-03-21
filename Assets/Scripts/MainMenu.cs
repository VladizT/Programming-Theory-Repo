using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using TMPro;


#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainMenu : MonoBehaviour
{

    TMP_InputField nameField;

    [SerializeField]
    GameObject errorNameInput;

    private void Start()
    {

        nameField = F.GC<TMP_InputField>("Name Input");

        nameField.onValueChanged.AddListener(NameInput);

        if ( Main.s.namePlayer != "" )
        {
            nameField.text = Main.s.namePlayer;
        }

    }

    void NameInput( string textInput)
    {
        
        Main.s.SetName( textInput );
    }

    public void StartButton()
    {

        if( Main.s.namePlayer == "" )
        {
            errorNameInput.SetActive(true);
        } else
        {
            SceneManager.LoadScene(1);
        }
 
    }

    public void QuitButton()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void OkErrorNIButton()
    {
        errorNameInput.SetActive(false);
    }

}
