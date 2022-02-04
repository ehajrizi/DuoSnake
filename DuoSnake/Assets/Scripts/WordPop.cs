using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordPop : MonoBehaviour
{
    public static event Action OnAnyWordPopped;
    private void OnCollisionEnter2D() {
        OnAnyWordPopped?.Invoke();
    }

}
