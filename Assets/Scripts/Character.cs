using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private Data.Ability ability { get ; set ; }
    [SerializeField] private int abilityValue { get ; set ; }

    [SerializeField] private int maxWorkPoint { get ; set ; }
    [SerializeField] private int currentWorkPoint { get ; set ; }

    private void Start()
    {
        CoroutineManager.instance.RepeatAction(IncreaseWorkPoint, 1.0f);
    }
    public void OnClickCharacter()
    {

    }

    private void IncreaseWorkPoint()
    {
        if(currentWorkPoint >= maxWorkPoint)
        {
            // ToDo: 포인트가 최대까지 찼을 경우
            switch (ability)
            {
                case Data.Ability.Fire:
                    {
                        Debug.Log($"불 {abilityValue} 포인트");
                        break;
                    }
                case Data.Ability.Wood:
                    {
                        Debug.Log($"나무 {abilityValue} 포인트");
                        break;
                    }
                case Data.Ability.Rice:
                    {
                        Debug.Log($"쌀 {abilityValue} 포인트");
                        break;
                    }
                case Data.Ability.Fish:
                    {
                        Debug.Log($"낚시 {abilityValue} 포인트");
                        break;
                    }
            }
            currentWorkPoint = 0;
        }
        else
        {
            // ToDo: 포인트가 꽉차지 않았을 경우
            currentWorkPoint++;
        }
    }
}
