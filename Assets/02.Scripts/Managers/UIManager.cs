using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Imnyeong
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager instance;

        public List<Cat> cats;

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
        public PopupManager popupManagerL;
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
            GameManager.instance.LoadData();
        }
        #endregion

        private void Init()
        {
            RefreshUI();
            inventoryButton.onClick.AddListener(delegate { viewManager.ShowView(ViewType.Inventory); });
            cookButton.onClick.AddListener(delegate { viewManager.ShowView(ViewType.Cook); });
            storeButton.onClick.AddListener(delegate { viewManager.ShowView(ViewType.Store); });
            gachaButton.onClick.AddListener(delegate { GameManager.instance.SaveData(); });
        }

        public void RefreshUI()
        {
            moneyText.text = GameManager.instance.localDataBase.currentMoney.ToString();
            cashText.text = GameManager.instance.localDataBase.currentCash.ToString();
            churText.text = GameManager.instance.localDataBase.currentChur.ToString();
        }

        public void SetCats(List<CatData> _data)
        {
            for(int i = 0 ; i < _data.Count ; i++)
            {
                cats[i].SetInfo(_data[i]);
            }
        }
    }
}