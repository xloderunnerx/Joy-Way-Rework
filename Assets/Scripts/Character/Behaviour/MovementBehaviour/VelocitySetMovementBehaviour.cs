using Sirenix.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.Behaviour
{
    public class VelocitySetMovementBehaviour : IMovementBehaviour<Rigidbody>
    {
        [OdinSerialize] private float velocityMultiplier; 

        public VelocitySetMovementBehaviour(float velocityMultiplier)
        {
            this.velocityMultiplier = velocityMultiplier;
        }

        public void Move(Rigidbody context, Vector3 movement)
        {
            context.velocity = movement * velocityMultiplier;
        }
    }
}