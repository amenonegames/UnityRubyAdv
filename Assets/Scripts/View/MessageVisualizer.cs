﻿using amenone.VcontainerExtensions.Identifier;
using TMPro;
using UnityEngine;

namespace DefaultNamespace.View
{
    public class MessageVisualizer : MonoBehaviour , IRegisterMarker , IMessageVisualizable
    {
        private TMP_Text _textMeshPro;
        private TMP_Text ThisTextMeshPro=> _textMeshPro ??= GetComponent<TMP_Text>(); 
        
        public void VisualizeMessage(string message)
        {
            ThisTextMeshPro.text = message;
        }
    }
}