using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class Tweener : Tweening
{
    protected override void Init()
    {
        base.Init();
    }

    void OnEnable()
    {
        if (showOnEnable)
        {
            Show();
        }
    }

    public void ForcedInitialize()
    {
        base.Init();
    }

    public new void Show(Action onComplete = null)
    {
        base.Show(() => {
            if (this != null)
            {
                onComplete?.Invoke();
            }
        });
    }

    public void CloseAfter()
    {
        StartCoroutine(ClosePopUp());
    }

    public IEnumerator ClosePopUp()
    {
        yield return new WaitForSecondsRealtime(1.25f);
        CloseDisable();

    }

    public new void CloseDisable()
    {
        Close(() => {
            if (this != null)
            {
                this.gameObject.SetActive(false);
            }
        });
    }

    public new void Close()
    {
        Close(null);
    }

    public void CloseWithoutDisable()
    {
        base.Close();
    }

    public void CloseWithoutDisable(Action onClose)
    {
        base.Close(onClose);
    }

    public new void Close(Action onClose)
    {
        base.Close(() => {
            if (this != null && this.gameObject != null)
            {
                this.gameObject.SetActive(false);
            }
            if (onClose != null)
                onClose();
        });
    }

}
