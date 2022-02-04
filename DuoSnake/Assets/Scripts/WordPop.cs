using System;
using System.Collections;
using UnityEngine;

public class WordPop : MonoBehaviour
{
    public static event Action OnAnyWordPopped;
    private void OnCollisionEnter2D() {
        OnAnyWordPopped?.Invoke();
    }

}
