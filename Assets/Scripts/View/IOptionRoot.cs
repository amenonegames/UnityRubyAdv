
using NullObjectGenerator;
using UnityEngine;

namespace DefaultNamespace.View
{
    [InterfaceToNullObj]
    public interface IOptionRoot
    {
        Transform Transform { get; }
    }
}