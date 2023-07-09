using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DelayExcute : MonoBehaviour
{
    public float DelayDelta = 1.0f;
    public UnityEvent EV;

    public void Start()
    {
        StartCoroutine(Invoke());
    }
    IEnumerator Invoke()
    {
        yield return new WaitForSeconds(DelayDelta);
        if(EV != null )EV.Invoke();
    }

}
