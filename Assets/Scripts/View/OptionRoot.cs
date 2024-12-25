using amenone.VcontainerExtensions.Identifier;
using UnityEngine;

namespace DefaultNamespace.View
{
    public class OptionRoot : MonoBehaviour , IRegisterMarker , IOptionRoot
    {
        private Transform _transform;
        public Transform Transform => _transform;
    }
}