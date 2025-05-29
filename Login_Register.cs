using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Login_Register : MonoBehaviour
{
    [Header("Login")]
    [SerializeField] private TMP_InputField LoginUserNameInput    = null;
    [SerializeField] private TMP_InputField LoginPasswordInput    = null;
    [Header("Register")]
    [SerializeField] private TMP_InputField UserNameInput = null;
    [SerializeField] private TMP_InputField EmailInput    = null;
    [SerializeField] private TMP_InputField Pass1Input    = null;
    [SerializeField] private TMP_InputField Pass2Input    = null;
    [SerializeField] private TMP_Text       Message;

    private Network_Conection network_Conection = null;

    private void Awake() {
      network_Conection = GameObject.FindObjectOfType<Network_Conection>();  
    } 

    public void SubmitLogin () {
        if(LoginUserNameInput.text == ""|| LoginPasswordInput.text == "") {
            Message.text = "Por favor llenar todos los campos";
            return;
        }
        else{
            Message.text = "Por favor espere...";

            network_Conection.CheckUser(LoginUserNameInput.text, LoginPasswordInput.text, delegate(Response response)
            {
                Message.text = response.message;
            
            if (response.done) {
                UnityEngine.SceneManagement.SceneManager.LoadScene("Welcome");
            }

            });
            
        }
    }

    public void SubmitRegister () {
        if(UserNameInput.text == ""|| EmailInput.text == ""|| Pass1Input.text == "" || Pass2Input.text == "") {
            Message.text = "Por favor llenar todos los campos";
            return;
            
        }
        
        if (Pass1Input.text == Pass2Input.text) {

            Message.text = "Por favor espere...";

            network_Conection.CreateUser(UserNameInput.text, EmailInput.text, Pass1Input.text, delegate(Response response)
            {
                Message.text = response.message;
            });
        }
        else{
            Message.text = "La contraseña no coincide, por favor verifique";
            
        }
    }

}
