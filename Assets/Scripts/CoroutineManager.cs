using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CoroutineManager : MonoBehaviour
{
    public static CoroutineManager instance;

    private void Awake()
    {
        DontDestroyOnLoad(this);

        if(instance == null)
        {
            instance = this;
        }
    }

    public void WaitAction(UnityAction _action, float _delay)
    {
        StartCoroutine(WaitCoroutine(_action, _delay));
    }

    private IEnumerator WaitCoroutine(UnityAction _action, float _delay)
    {
        yield return new WaitForSecondsRealtime(_delay);
        _action();
    }

    public void RepeatAction(UnityAction _action, float _delay)
    {
        StartCoroutine(RepeatCoroutine(_action, _delay));
    }

    private IEnumerator RepeatCoroutine(UnityAction _action, float _delay)
    {
        yield return new WaitForSecondsRealtime(_delay);
        _action();
        StartCoroutine(RepeatCoroutine(_action, _delay));
    }

    public void WaitNextAction(UnityAction _action, Coroutine _coroutine)
    {
        StartCoroutine(WaitNextCoroutine(_action, _coroutine));
    }

    private IEnumerator WaitNextCoroutine(UnityAction _action, Coroutine _coroutine)
    {
        yield return _coroutine;
        _action();
    }
}
