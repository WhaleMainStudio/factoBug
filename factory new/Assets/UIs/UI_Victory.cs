using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Victory : MonoBehaviour
{

    void Start()
    {
        Cursor.visible = true;
		Screen.lockCursor = false; 
    }
    public void loadMainMenu()
    {
    SceneManager.LoadScene("mainMenu");
    }
}
