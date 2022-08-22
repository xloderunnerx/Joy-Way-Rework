using Sirenix.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.Behaviour
{
    public class AnglesAppendRotationBehaviour : IRotationBehaviour<Transform>
    {
        [OdinSerialize] private float sensetivityX;
        [OdinSerialize] private float sensetivityY;
        [Tooltip("Lesser – slower.")] [OdinSerialize] private float smoothness;

        [OdinSerialize] private bool rotationX;
        [OdinSerialize] private bool rotationY;

        [OdinSerialize] private Vector2 clampX;
        [OdinSerialize] private Vector2 clampY;

        private float x;
        private float y;

        public AnglesAppendRotationBehaviour(float sensetivityH, float sensetivityV)
        {
            this.sensetivityX = sensetivityH;
            this.sensetivityY = sensetivityV;
        }

        public void Rotate(Transform context, Vector3 rotation)
        {
            if (rotationX)
                x += sensetivityX * rotation.x;
            if (rotationY)
                y -= sensetivityY * rotation.z;
            x = (clampX.x == 0 && clampX.y == 0) ? x : Mathf.Clamp(x, clampX.x, clampX.y);
            y = (clampY.x == 0 && clampY.y == 0) ? y : Mathf.Clamp(y, clampY.x, clampY.y);
            context.rotation = Quaternion.Slerp(context.rotation, Quaternion.Euler(new Vector3(y, x, 0)), Time.deltaTime * smoothness);
        }
    }
}