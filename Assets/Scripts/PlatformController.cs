using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public Transform startPoint;

    private Vector3 _startPoint;

    public Transform endPoint;

    private Vector3 _endPoint;

    public float time;

    void Start()
    {
        _startPoint = startPoint.position;
        _endPoint = endPoint.position;
        StartCoroutine(LoopSequence());
    }

    IEnumerator LoopSequence()
    {
        yield return StartCoroutine(Move(_startPoint));
        yield return StartCoroutine(Move(_endPoint));
        StartCoroutine(LoopSequence());
    }

    IEnumerator Move(Vector3 targetTransform)
    {
        for (float t = 0; t <= time; t += Time.deltaTime)
        {
            float x = Mathf.Clamp01(t / time);
            float f = 3 * Mathf.Pow(x, 2) - 2 * Mathf.Pow(x, 3);

            transform.position =
                Vector3.Lerp(transform.position, targetTransform, f);
            yield return null;
        }
    }
}
