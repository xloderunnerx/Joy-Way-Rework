using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.Behaviour
{
    public interface IRotationBehaviour<T>
    {
        public void Rotate(T context, Vector3 rotation);
    }
}