using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Imnyeong
{
    public class Character : MonoBehaviour
    {
        [field: Header("Ability")]
        [field: SerializeField] private AbilityType abilityType { get; set; }
        [field: SerializeField] private int abilityValue { get; set; }

        [field: Header("Work")]
        [field: SerializeField] private int maxWorkPoint { get; set; }
        [field: SerializeField] private int currentWorkPoint { get; set; }
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
            currentWorkPoint++;

            if (currentWorkPoint >= maxWorkPoint)
            {
                ItemManager.instance.GetItem(abilityType, abilityValue);
                currentWorkPoint = 0;
            }

            textWorkPoint.text = currentWorkPoint.ToString();
        }
    }
}
