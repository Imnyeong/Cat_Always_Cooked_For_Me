using UnityEngine;
using UnityEngine.UI;

namespace Imnyeong
{
    public class CookView : BaseView
    {
        public override ViewType viewType => ViewType.Cook;
        [SerializeField]
        private Button closeButton;

        public void Start()
        {
            Init();
        }
        private void Init()
        {
            closeButton.onClick.AddListener(this.HideView);
        }
    }
}
