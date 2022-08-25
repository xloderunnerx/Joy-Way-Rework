using Core.Abstract;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Character.Component
{
    public class BaseHand : SerializedMonoBehaviour
    {
        private CarryableItem item;
        public CarryableItem Item { get => item; private set => item = value; }

        private void LateUpdate()
        {
            Hold();
        }

        public virtual void Pick()
        {
            if (item != null)
            {
                Drop();
                return;
            }
            var hits = Physics.RaycastAll(Camera.main.transform.position, Camera.main.transform.forward, Mathf.Infinity);
            var items = hits
                .Where(h => h.collider.GetComponentInParent<CarryableItem>() != null)
                .Select(h => h.collider.GetComponentInParent<CarryableItem>())
                .ToList();
            if (items.Count == 0)
                return;
            item = items.FirstOrDefault();
        }

        public virtual void Drop()
        {
            item = null;
        }

        public virtual void Use()
        {

        }

        protected virtual void Hold()
        {
            if (item == null)
                return;
            item.transform.position = Vector3.Lerp(item.transform.position, transform.position, 0.05f);
            item.transform.rotation = Quaternion.Lerp(item.transform.rotation, transform.rotation, 0.05f);
        }
    }
}