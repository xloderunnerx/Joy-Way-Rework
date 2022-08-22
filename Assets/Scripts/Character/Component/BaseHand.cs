using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.Component
{
    public class BaseHand : SerializedMonoBehaviour
    {
        private IPickableItem item;

        public IPickableItem Item { get => item; private set => item = value; }

        public void PickItem()
        {

        }

        public void DropItem()
        {

        }

        public void UseItem()
        {

        }
    }
}