using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Auth;
using UnityEngine.UI;


public class Authentication : MonoBehaviour
{
    [Header("Firebase")]
    public DependencyStatus dependencyStatus;
    public FirebaseAuth auth;
    public FirebaseUser User;

    [Header("Login")]
    public InputField emailLogin;
    public InputField passwordLogin;

    [Header("Register")]
    public InputField username;
    public InputField emailRegistration;
    public InputField passwordRegistration;


    private void Awake()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            dependencyStatus = task.Result;
            if (dependencyStatus == DependencyStatus.Available)
            {
                Debug.Log("Firebase Authentication ");
                auth = FirebaseAuth.DefaultInstance;
            }
            else
            {
                Debug.LogError("Could not resolve all Firebase dependencies: " + dependencyStatus);
            }
        });
    }


    public void loginButton()
    {
        StartCoroutine(login(emailLogin.text, passwordLogin.text));
    }

    public void registerButton()
    {
        StartCoroutine(signup(username.text, emailRegistration.text, passwordRegistration.text));
    }

    public IEnumerator login(string email, string password)
    {
        var LogTask = auth.SignInWithEmailAndPasswordAsync(email, password);
        yield return new WaitUntil(predicate: () => LogTask.IsCompleted);

        User = LogTask.Result;
        Debug.LogFormat("User signed in successfully: {0} ({1})", User.DisplayName, User.Email);
        Debug.Log("Loge in");
    }

    public IEnumerator signup(string username , string email,string password)
    {
        if(username == "")
        {
            Debug.Log("username missing");
        }

        var SignTask = auth.SignInWithEmailAndPasswordAsync(email, password);
        yield return new WaitUntil(predicate: () => SignTask.IsCompleted);
        Debug.Log("profile is created");

        User = SignTask.Result;

        if (User != null)
        {
            UserProfile profile = new UserProfile { DisplayName = username };
            var createProfile = User.UpdateUserProfileAsync(profile);

            yield return new WaitUntil(predicate: () => createProfile.IsCompleted);
            Debug.Log("Details Updated");
        }
    }
}
