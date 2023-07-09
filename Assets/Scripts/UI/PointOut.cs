using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointOut : MonoBehaviour
{
    public AudioSource m_AudioSource;
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
            m_AudioSource.Play();

    }
}
