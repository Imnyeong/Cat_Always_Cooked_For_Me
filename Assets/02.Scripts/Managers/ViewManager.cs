using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Imnyeong
{
    public class ViewManager : MonoBehaviour
    {
        public BaseView[] views;

        public void ShowView(ViewType _viewType)
        {
            for(int i = 0; i < views.Length; i++)
            {
                views[i].ChangeView(_viewType);
            }
        }
    }
}
