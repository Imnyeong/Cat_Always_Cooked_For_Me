using System;
using UnityEngine;
using UnityEngine.UI;

namespace Imnyeong
{
    public class StoreView : BaseView
    {
        public override ViewType viewType => ViewType.Store;

        [SerializeField]
        private Color[] textColor;
        [SerializeField]
        private GameObject buyTab;
        [SerializeField]
        private GameObject sellTab;
        [SerializeField]
        private Text buyText;
        [SerializeField]
        private Text sellText;
        [SerializeField]
        private Button closeButton;
        [SerializeField]
        private Toggle buyToggle;
        [SerializeField]
        private Toggle sellToggle;

        public void Start()
        {
            Init();
        }
        public void OnEnable()
        {
            sellToggle.isOn = false;
            buyToggle.isOn = true;
            OnValueChanged(buyTab);
        }
        public void OnDisable()
        {
            GameManager.instance.CleanFoodInventory();
            buyTab.SetActive(false);
            sellTab.SetActive(false);
        }
        private void Init()
        {
            closeButton.onClick.AddListener(this.HideView);

            buyToggle.onValueChanged.AddListener(delegate
            {
                OnValueChanged(buyTab);
            });
            sellToggle.onValueChanged.AddListener(delegate
            {
                OnValueChanged(sellTab);
            });
        }
        public void OnValueChanged(GameObject _tab)
        {
            buyTab.SetActive(_tab == buyTab);
            sellTab.SetActive(_tab == sellTab);
            buyText.color = textColor[Convert.ToInt32(_tab == buyTab)];
            sellText.color = textColor[Convert.ToInt32(_tab == sellTab)];
        }
    }
}