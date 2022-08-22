using Sirenix.OdinInspector;
using Sirenix.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.GenericVariable
{
    public class BaseGenericVariable<T> : SerializedScriptableObject
    {
        [OdinSerialize] private T variable;

        public Action<T> OnVariableChanged;

        public T Variable
        {
            get => variable; set
            {
                variable = value;
                OnVariableChanged?.Invoke(variable);
            }
        }

        private void OnValidate() => OnVariableChanged?.Invoke(variable);
    }
}