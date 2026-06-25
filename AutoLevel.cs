using System;
using System.Collections;
using UnityEngine;

namespace BetterTables
{
    public class AutoLevel : MonoBehaviour
    {
        public ShipItem shipItem;
        public Quaternion shopRot;
        private bool locked;
        private bool locking;
        public Transform col;

        public bool Locked { get => locked; }

        public void Start()
        {
            shopRot = base.transform.rotation;

            shipItem = transform.parent.GetComponent<ShipItem>();


            if (shipItem == null && transform.parent.GetComponent<ItemRigidbody>() is ItemRigidbody itemRigidbody)
            {
                GetComponent<Renderer>().enabled = false;
                itemRigidbody.GetShipItem()?.GetComponentInChildren<AutoLevel>()?.RegisterCol(this);
                //this.enabled = false;
            }
        }

        public void RegisterCol(AutoLevel newCol)
        {
            col = newCol.transform;
            Component.Destroy(newCol);
            Debug.Log("autolevel registered col: " + newCol.name);
            //gameObject.GetComponent<Renderer>().enabled = false;
        }

        private void LateUpdate()
        {
            if (col == null) return;
            if (shipItem.held)
            {
                locked = false;
            }
            else if (!locking && !locked)
            {
                if (!shipItem.sold)
                {
                    StartCoroutine(ShopLockRoutine());
                }
                else
                {
                    StartCoroutine(LockRoutine());
                }
            }
            if (!locked)
            {
                if (shipItem.currentActualBoat != null)
                {
                    base.transform.forward = -shipItem.currentActualBoat.up;
                }
                else
                {
                    base.transform.forward = -Vector3.up;
                }
                transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, 0, 0);
                col.localRotation = transform.localRotation;

            }
        }

        private IEnumerator LockRoutine()
        {
            locking = true;
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
            locked = true;
            locking = false;
        }
        private IEnumerator ShopLockRoutine()
        {
            locking = true;
            Quaternion startRot = base.transform.rotation;
            for (float t = 0f; t < 1f; t += Time.deltaTime * 2f)
            {
                base.transform.rotation = Quaternion.Lerp(startRot, shopRot, t);
                yield return new WaitForEndOfFrame();
            }
            locked = true;
            locking = false;
        }
    }
}
