using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineObject : MonoBehaviour
{
    public static CoroutineObject GetCoroutineObject() => new GameObject("CoroutineObject").AddComponent<CoroutineObject>();
    public static CoroutineObject GetCoroutineObject(string origin) => new GameObject($"{origin}CoroutineObject").AddComponent<CoroutineObject>();

    
    public void Execute(IEnumerator routine) => StartCoroutine(routine);
    public void ExecuteAndDestroy(IEnumerator routine) => StartCoroutine(ExecuteAndDestroyCoroutine(routine));

    private IEnumerator ExecuteAndDestroyCoroutine(IEnumerator routine)
    {
        yield return StartCoroutine(routine);
        Destroy(gameObject);
    }
}
