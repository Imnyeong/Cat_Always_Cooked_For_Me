using System;
using UnityEngine;
using UnityEngine.UI;

namespace Imnyeong
{
    public class InventoryView : BaseView
    {
        public override ViewType viewType => ViewType.Inventory;

        [SerializeField]
        private Color[] textColor;
        [SerializeField]
        private GameObject ingredientTab;
        [SerializeField]
        private GameObject foodTab;
        [SerializeField]
        private Text ingredientText;
        [SerializeField]
        private Text foodText;
        [SerializeField]
        private Button closeButton;
        [SerializeField]
        private Toggle ingredientToggle;
        [SerializeField]
        private Toggle foodToggle;

        public void Start()
        {
            Init();
        }
        public void OnEnable()
        {
            foodToggle.isOn = false;
            ingredientToggle.isOn = true;
            OnValueChanged(ingredientTab);
        }
        public void OnDisable()
        {
            ingredientTab.SetActive(false);
            foodTab.SetActive(false);
        }
        private void Init()
        {
            closeButton.onClick.AddListener(this.HideView);

            ingredientToggle.onValueChanged.AddListener(delegate
            {
                OnValueChanged(ingredientTab);
            });
            foodToggle.onValueChanged.AddListener(delegate
            {
                OnValueChanged(foodTab);
            });
        }
        public void OnValueChanged(GameObject _tab)
        {
            ingredientTab.SetActive(_tab == ingredientTab);
            foodTab.SetActive(_tab == foodTab);
            ingredientText.color = textColor[Convert.ToInt32(_tab == ingredientTab)];
            foodText.color = textColor[Convert.ToInt32(_tab == foodTab)];
        }
    }
}