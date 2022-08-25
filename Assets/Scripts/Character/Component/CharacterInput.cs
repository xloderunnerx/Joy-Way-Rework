using Core.Input;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.Component
{
    public class CharacterInput : BaseInput
    {
        public event Action OnPickLeft;
        public event Action OnPickRight;
        public event Action OnUseLeft;
        public event Action OnUseRight;
        

        private void Update()
        {
            UpdateInput();
        }

        public override void UpdateInput()
        {
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");
            mouseX = Input.GetAxis("Mouse X");
            mouseY = Input.GetAxis("Mouse Y");
            if (Input.GetKeyDown(KeyCode.Q))
                OnPickLeft?.Invoke();
            if (Input.GetKeyDown(KeyCode.E))
                OnPickRight?.Invoke();
            if (Input.GetKeyDown(KeyCode.Mouse0))
                OnUseLeft?.Invoke();
            if (Input.GetKeyDown(KeyCode.Mouse1))
                OnUseRight?.Invoke();
        }
    }
}