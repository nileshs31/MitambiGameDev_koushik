using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchCount : MonoBehaviour
{
    public int count;

    public Text textcount;
    private void Update()
    {
        textcount.text = count.ToString();
    }
    public void touchCount()
    {
        count++;
    } 
}
