using Core.Input;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Character.Component
{
    public class BaseCharacter : SerializedMonoBehaviour, IDisposable
    {
        [Inject] private CharacterInput characterInput;
        [OdinSerialize] private BaseHand leftHand;
        [OdinSerialize] private BaseHand rightHand;

        private void Start()
        {
            InitInput();
        }

        private void Update()
        {
            
        }

        private void OnDestroy()
        {
            Dispose();
        }

        private void InitInput()
        {
            characterInput.OnPickLeft += leftHand.Pick;
            characterInput.OnPickRight += rightHand.Pick;
            characterInput.OnUseLeft += leftHand.Use;
            characterInput.OnUseRight += rightHand.Use;
        }

        public void Dispose()
        {
            characterInput.OnPickLeft -= leftHand.Pick;
            characterInput.OnPickRight -= rightHand.Pick;
            characterInput.OnUseLeft -= leftHand.Use;
            characterInput.OnUseRight -= rightHand.Use;
        }

    }
}