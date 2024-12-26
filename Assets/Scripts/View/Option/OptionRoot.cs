using System.Collections.Generic;
using amenone.VcontainerExtensions.Identifier;
using UnityEngine;

namespace DefaultNamespace.View
{
    public class OptionRoot : MonoBehaviour ,  IRegisterMarker , IOptionRoot
    {
        public Transform Transform => transform;
        public void SetParent(IEnumerable<OptionViewBase> children)
        {
            RectTransform rectTran = transform as RectTransform;
            
            foreach (var child in children)
            {
                RectTransform childRectTran = child.transform as RectTransform;
                childRectTran.SetParent(transform);
                childRectTran.anchoredPosition = new Vector2(0,0);
            }
        }
    }
}