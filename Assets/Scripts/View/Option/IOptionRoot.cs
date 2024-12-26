
using System.Collections.Generic;
using NullObjectGenerator;
using UnityEngine;

namespace DefaultNamespace.View
{
    [InterfaceToNullObj]
    public interface IOptionRoot
    {
        Transform Transform { get; }
        
        void SetParent(IEnumerable<OptionViewBase> children);
    }
}