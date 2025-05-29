using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Network_Conection : MonoBehaviour
{
    public void CreateUser (string UserName, string Email, string Pass, Action<Response> response) {
        StartCoroutine (CO_CreateUser(UserName, Email, Pass, response));
    }

    private IEnumerator CO_CreateUser (string UserName, string Email, string Pass, Action<Response> response) {
        WWWForm FormUsers = new WWWForm();
        FormUsers.AddField("UserName", UserName);
        FormUsers.AddField("Email", Email);
        FormUsers.AddField("Pass", Pass);

        WWW w = new WWW ("http://localhost/DimensionSTEM/CreateUser.php",FormUsers);

        yield return w;
        
        response(JsonUtility.FromJson<Response>(w.text));
    }

public void CheckUser (string UserName, string Pass, Action<Response> response) {
        StartCoroutine (CO_CheckUser(UserName, Pass, response));
    }

    private IEnumerator CO_CheckUser (string UserName, string Pass, Action<Response> response) {
        WWWForm FormUsers = new WWWForm();
        FormUsers.AddField("UserName", UserName);
        FormUsers.AddField("Pass", Pass);

        WWW w = new WWW ("http://localhost/DimensionSTEM/CheckUser.php",FormUsers);

        yield return w;
        
        response(JsonUtility.FromJson<Response>(w.text));
    }

}

[Serializable]
public class Response{
    public bool     done    = false;
    public string   message = "";
}
