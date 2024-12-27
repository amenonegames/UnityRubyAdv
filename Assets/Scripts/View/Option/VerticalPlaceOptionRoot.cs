using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DefaultNamespace.View
{
    public class VerticalPlaceOptionRoot : MonoBehaviour , IOptionRoot
    {
        public Transform Transform => transform;
    public void SetParent(IEnumerable<OptionViewBase> children)
    {
        RectTransform rectTran = transform as RectTransform;
        float parentHeight = rectTran.rect.height;
        int childCount = children.Count();
        
        float spacing = parentHeight / (childCount + 1);
        float currentY = parentHeight / 2 - spacing;

        foreach (var child in children)
        {
            RectTransform childRectTran = child.transform as RectTransform;
            childRectTran.SetParent(transform);
            childRectTran.anchoredPosition = new Vector2(0, currentY);
            currentY -= spacing;
        }
    }
    }
}