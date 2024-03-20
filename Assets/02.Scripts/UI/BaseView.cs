using UnityEngine;

namespace Imnyeong
{
    public class BaseView : MonoBehaviour
    {
        public virtual ViewType viewType { get; }

        public void ChangeView(ViewType _viewType)
        {
            this.gameObject.SetActive(viewType == _viewType);
        }
        public void HideView()
        {
            this.gameObject.SetActive(false);
        }
    }
}

