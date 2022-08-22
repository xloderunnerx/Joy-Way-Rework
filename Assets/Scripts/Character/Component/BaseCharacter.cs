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
            characterInput.OnPickLeft += leftHand.PickItem;
            characterInput.OnPickRight += rightHand.PickItem;
            characterInput.OnUseLeft += leftHand.UseItem;
            characterInput.OnUseRight += rightHand.UseItem;
        }

        private void Update()
        {
            
        }

        private void OnDestroy()
        {
            Dispose();
        }
        public void Dispose()
        {
            characterInput.OnPickLeft -= leftHand.PickItem;
            characterInput.OnPickRight -= rightHand.PickItem;
            characterInput.OnUseLeft -= leftHand.UseItem;
            characterInput.OnUseRight -= rightHand.UseItem;
        }

    }
}