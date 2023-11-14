using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathMenu : MonoBehaviour
{

    public GameObject Cusor;
    int CursorPosition = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
                Cusor.gameObject.transform.position = new Vector3(Cusor.gameObject.transform.position.x, 1.2f, Cusor.gameObject.transform.position.z);
                CursorPosition = 0;
      
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
          
                Cusor.gameObject.transform.position = new Vector3(Cusor.gameObject.transform.position.x, -2.63f, Cusor.gameObject.transform.position.z);
                CursorPosition = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            SelectItem();
        }
    }
        void SelectItem()
        {
            if (CursorPosition == 0)
            {
                SceneManager.LoadScene(1);
            }
            if (CursorPosition == 1)
            {
                Application.Quit();
                UnityEditor.EditorApplication.isPlaying = false;
            }
        }
    }