using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    [field: Header("Ability")]
    [field: SerializeField] private Data.AbilityType abilityType { get; }
    [field: SerializeField] private int abilityValue { get ; set ; }

    [field: Header("Work")]
    [field: SerializeField] private int maxWorkPoint { get ; set ; }
    [field: SerializeField] private int currentWorkPoint { get ; set ; }
    [field: SerializeField] private Text textWorkPoint;

    private float workDelay { get; set; } = 1.0f;
    private Coroutine coroutine = null;

    private void Start()
    {
        coroutine = StartCoroutine(WorkCoroutine());
    }
    public void OnClickCharacter()
    {
        IncreaseWorkPoint();
    }

    //public void StopCoroutine()
    //{
    //    if (coroutine != null)
    //    {
    //        StopCoroutine(coroutine);
    //        coroutine = null;
    //    }
    //    else
    //    {
    //        coroutine = StartCoroutine(WorkCoroutine());
    //    }
    //}

    private IEnumerator WorkCoroutine()
    {
        yield return new WaitForSecondsRealtime(workDelay);
        IncreaseWorkPoint();
        coroutine = StartCoroutine(WorkCoroutine());
    }
    private void IncreaseWorkPoint()
    {
        if(currentWorkPoint >= maxWorkPoint)
        {
            switch (abilityType)
            {
                case Data.AbilityType.Fire:
                    {
                        Debug.Log($"불 {abilityValue} 포인트");
                        break;
                    }
                case Data.AbilityType.Wood:
                    {
                        Debug.Log($"나무 {abilityValue} 포인트");
                        break;
                    }
                case Data.AbilityType.Rice:
                    {
                        Debug.Log($"쌀 {abilityValue} 포인트");
                        break;
                    }
                case Data.AbilityType.Fish:
                    {
                        Debug.Log($"낚시 {abilityValue} 포인트");
                        break;
                    }
            }
            currentWorkPoint = 0;
        }
        else
        {
            currentWorkPoint++;
        }
        textWorkPoint.text = currentWorkPoint.ToString();
    }
}
