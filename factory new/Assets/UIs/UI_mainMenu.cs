using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_mainMenu : MonoBehaviour
{

    void Start()
    {
        Cursor.visible = true;
		Screen.lockCursor = false; 
    }
    public void loadExempleMap()
    {
    SceneManager.LoadScene("exceptionsLevel");
    }

    public void loadFreeMap()
    {
    SceneManager.LoadScene("mapLibre");
    }

}
