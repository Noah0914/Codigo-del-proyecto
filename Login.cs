using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Login : MonoBehaviour
{
    public TMP_InputField UserInput;
    public TMP_InputField PasswordInput;
    public Button LoginButton;
    
    ArrayList datos;

    // Start is called before the first frame update
    void Start()
    {
        LoginButton.onClick.AddListener(login);
        
        if (File.Exists(Application.dataPath + "/datos.txt"))
        {
            datos = new ArrayList(File.ReadAllLines(Application.dataPath + "/datos.txt"));
        }
        else
        {
            Debug.Log("Datos file doesn't exist");
        }

    }



    // Update is called once per frame
    void login()
    {
        bool isExists = false;

        datos = new ArrayList(File.ReadAllLines(Application.dataPath + "/datos.txt"));

        foreach (var i in datos)
        {
            string line = i.ToString();
            //Debug.Log(line);
            //Debug.Log(line.Substring(11));
            //substring 0-indexof(:) - indexof(:)+1 - i.length-1
            if (i.ToString().Substring(0, i.ToString().IndexOf(":")).Equals(UserInput.text) &&
                i.ToString().Substring(i.ToString().IndexOf(":") + 1).Equals(PasswordInput.text))
            {
                isExists = true;
                break;
            }
        }

        if (isExists)
        {
            Debug.Log($"Logging in '{UserInput.text}'");
            loadWelcomeScreen();
        }
        else
        {
            Debug.Log("Incorrect credentials");
        }
    }

    void loadWelcomeScreen()
    {
        SceneManager.LoadScene(1);
    }

}

