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

    [Header("Phone")]
    public InputField phoneNumber;
    public InputField verificationCode;
    private uint phoneAuthTimeoutMs = 60 * 1000;
    private string verificationId;

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

    //Email and login (FireBase)

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

    public IEnumerator signup(string username, string email, string password)
    {
        if (username == "")
        {
            Debug.Log("username missing");
        }

        var SignTask = auth.CreateUserWithEmailAndPasswordAsync(email, password);
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

    //Phone Number Authentication (FireBase)

    public void loginPhoneNo()
    {
        PhoneAuthProvider provider = PhoneAuthProvider.GetInstance(auth);
        provider.VerifyPhoneNumber(phoneNumber.text, phoneAuthTimeoutMs, null, verificationCompleted: (Credential) => { },
        verificationFailed: (error) => { }, codeSent: (id, token) => { verificationId = id; Debug.Log("Code sent"); }, 
        codeAutoRetrievalTimeOut: (id) =>{ });
    }
    public void  verifyOtp()
    {
        PhoneAuthProvider provider = PhoneAuthProvider.GetInstance(auth);
        Credential credential = provider.GetCredential(verificationId, verificationCode.text);

        auth.SignInWithCredentialAsync(credential).ContinueWith(task => {
            if (task.IsFaulted)
            {
                Debug.LogError("SignInWithCredentialAsync encountered an error: " +
                               task.Exception);
                return;
            }

            FirebaseUser newUser = task.Result;
            Debug.Log("User signed in successfully");
            // This should display the phone number.
            Debug.Log("Phone number: " + newUser.PhoneNumber);
            // The phone number providerID is 'phone'.
            Debug.Log("Phone provider ID: " + newUser.ProviderId);
        });
    }


}
