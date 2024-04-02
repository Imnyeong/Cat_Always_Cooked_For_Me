using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Imnyeong
{
    [System.Serializable]
    public class Cat : MonoBehaviour
    {
        [SerializeField] public Image thumbnail;

        [Header("CatColor")]
        public CatColor catColor;

        [Header("Level")]
        public int valueLevel = 1;
        public int delayLevel = 1;
        public int neglectLevel = 1;

        [Header("Ability")]
        public AbilityType abilityType;
        public int abilityIndex;
        public int abilityValue = 1;

        [Header("Work")]
        public int maxWorkPoint;
        public int currentWorkPoint;
        public float workDelay = 1.0f;

        //[SerializeField] private Text textWorkPoint;

        [SerializeField] private Slider workSlider;
        [SerializeField] private Button infoButton;

        private Coroutine coroutine = null;
        private int neglectValue = 8640;
        // 5번 강화 시 하루 동안 방치할 수 있도록
        public void SetInfo(CatData _cat)
        {
            this.gameObject.SetActive(true);
            infoButton.onClick.RemoveAllListeners();

            //thumbnail = _cat.thumbnail;

            abilityType = _cat.abilityType;
            abilityIndex = _cat.abilityIndex;
            abilityValue = _cat.abilityValue * _cat.valueLevel;
            
            maxWorkPoint = _cat.maxWorkPoint;
            currentWorkPoint = _cat.currentWorkPoint;

            workSlider.value = ((float)currentWorkPoint / (float)maxWorkPoint);

            workDelay = workDelay / _cat.delayLevel;
            neglectValue = neglectValue * _cat.neglectLevel;

            if (coroutine != null)
            {
                StopCoroutine(coroutine);
                coroutine = null;
            }
            coroutine = StartCoroutine(WorkCoroutine());
            infoButton.onClick.AddListener(OnClickInfo);
        }

        public void SellCat()
        {
            infoButton.onClick.RemoveAllListeners();
            StopCoroutine();
            this.gameObject.SetActive(false);
        }

        public void StopCoroutine()
        {
            if (coroutine != null)
            {
                StopCoroutine(coroutine);
                coroutine = null;
            }
        }

        public void OnClickCharacter()
        {
            IncreaseWorkPoint();
        }
        public void OnClickInfo()
        {
            UIManager.instance.popupManagerL.ShowCatInfoPopup(this);
        }
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
                GameManager.instance.GetIngredient(abilityType, abilityIndex, abilityValue);
                currentWorkPoint = 0;
            }
            workSlider.value = ((float)currentWorkPoint / (float)maxWorkPoint);
            //textWorkPoint.text = $"{currentWorkPoint} / {maxWorkPoint}";
        }
        public void CalculateWorkPoint(int _sec)
        {            
            if (_sec > neglectValue)
                _sec = neglectValue;

            int count = (_sec + currentWorkPoint) / maxWorkPoint;
            int remain = (_sec + currentWorkPoint) % maxWorkPoint;

            Debug.Log(count.ToString() + " count");
            Debug.Log(remain.ToString() + " remain");

            GameManager.instance.GetIngredient(abilityType, abilityIndex, count);

            currentWorkPoint = remain;
            workSlider.value = ((float)currentWorkPoint / (float)maxWorkPoint);
        }
    }
}
