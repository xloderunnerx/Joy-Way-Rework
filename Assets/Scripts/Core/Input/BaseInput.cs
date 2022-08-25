using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Input
{
    public abstract class BaseInput : MonoBehaviour
    {
        protected float horizontal;
        protected float vertical;
        protected float mouseX;
        protected float mouseY;
        public float Horizontal { get => horizontal; protected set => horizontal = value; }
        public float Vertical { get => vertical; protected set => vertical = value; }
        public float MouseX { get => mouseX; protected set => mouseX = value; }
        public float MouseY { get => mouseY; protected set => mouseY = value; }

        public abstract void UpdateInput();
    }
}