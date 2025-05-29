using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Register : MonoBehaviour
{
    public TMP_InputField UserInput;
    public TMP_InputField PasswordInput;
    public Button RegisterButton;
    
    ArrayList datos;

    // Start is called before the first frame update
    void Start()
    {
        RegisterButton.onClick.AddListener(writeToFile);
        

        if (File.Exists(Application.dataPath + "/datos.txt"))
        {
            datos = new ArrayList(File.ReadAllLines(Application.dataPath + "/datos.txt"));
        }
        else
        {
            File.WriteAllText(Application.dataPath + "/datos.txt", "");
        }

    }
    void writeToFile()
    {
        bool isExists = false;

        datos = new ArrayList(File.ReadAllLines(Application.dataPath + "/datos.txt"));
        foreach (var i in datos)
        {
            if (i.ToString().Contains(UserInput.text))
            {
                isExists = true;
                break;
            }
        }

        if (isExists)
        {
            Debug.Log($"Username '{UserInput.text}' already exists");
        }
        else
        {
            datos.Add(UserInput.text + ":" + PasswordInput.text);
            File.WriteAllLines(Application.dataPath + "/datos.txt", (String[])datos.ToArray(typeof(string)));
            Debug.Log("Account Registered");
        }
    }
}
