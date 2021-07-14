using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveDetails : MonoBehaviour
{
    public Text usernameInput;
    public Text emailInput;
    public Text passwordInput;

    public Text loginEmail,passwordEmail;


    public void SubmitDetailsButton()
    {
        string username = usernameInput.text;
        string email = emailInput.text;
        string password = passwordInput.text;

        PlayerPrefs.SetString("username", username);
        PlayerPrefs.SetString("email", email);
        PlayerPrefs.SetString("pasword", password);

        Debug.Log("Data Saved");
    }

    public void loginButton()
    {
        if (PlayerPrefs.GetString("username")==loginEmail.text  && PlayerPrefs.GetString("password")==passwordEmail.text) {
            
        }
    }
}
