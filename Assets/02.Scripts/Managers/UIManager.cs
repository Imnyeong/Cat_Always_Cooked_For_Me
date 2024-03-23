using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Imnyeong
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager instance;

        [field: SerializeField]
        private Cat[] cats { get; set; }

        [Header("Top UI")]
        [SerializeField]
        private Text moneyText;
        [SerializeField]
        private Text cashText;
        [SerializeField]
        private Text churText;

        [Header("Bottom UI")]
        [SerializeField]
        private Button inventoryButton;
        [SerializeField]
        private Button cookButton;
        [SerializeField]
        private Button storeButton;
        [SerializeField]
        private Button gachaButton;

        [Header("Managers")]
        [SerializeField]
        private ViewManager viewManager;
        //public GameObject[] popupsLarge;
        //public GameObject[] popupsSmall;

        #region Unity Life Cycle
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
        }

        private void Start()
        {
            Init();
        }
        #endregion

        private void Init()
        {
            RefreshUI();
            inventoryButton.onClick.AddListener(delegate { viewManager.ShowView(ViewType.Inventory); });
            cookButton.onClick.AddListener(delegate { viewManager.ShowView(ViewType.Cook); });
            storeButton.onClick.AddListener(delegate { viewManager.ShowView(ViewType.Store); });
        }

        public void RefreshUI()
        {
            moneyText.text = GameManager.instance.localDataBase.currentMoney.ToString();
            cashText.text = GameManager.instance.localDataBase.currentCash.ToString();
            churText.text = GameManager.instance.localDataBase.currentChur.ToString();
        }
    }
}