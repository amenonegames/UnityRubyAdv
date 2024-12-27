
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace.View
{
    public interface IOptionRoot
    {
        Transform Transform { get; }
        
        void SetParent(IEnumerable<OptionViewBase> children);
    }
}