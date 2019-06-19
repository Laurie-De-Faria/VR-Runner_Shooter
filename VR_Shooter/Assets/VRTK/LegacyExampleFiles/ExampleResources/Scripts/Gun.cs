namespace VRTK.Examples
{
    using UnityEngine;

    public class Gun : VRTK_InteractableObject
    {
        private GameObject bullet;
        private float bulletSpeed = 1000f;
        private float bulletLife = 5f;
        private VRTK_ControllerReference controllerReference;

        public override void StartUsing(VRTK_InteractUse usingObject)
        {
            base.StartUsing(usingObject);
            FireBullet();
        }

        protected void Start()
        {
            bullet = transform.Find("Bullet").gameObject;
            bullet.SetActive(false);
        }

        public override void Grabbed(VRTK_InteractGrab grabbingObject)
        {
            base.Grabbed(grabbingObject);
            controllerReference = VRTK_ControllerReference.GetControllerReference(grabbingObject.controllerEvents.gameObject);
        }

        private void FireBullet()
        {
            GameObject bulletClone = Instantiate(bullet, bullet.transform.position, bullet.transform.rotation) as GameObject;
            bulletClone.SetActive(true);
            Rigidbody rb = bulletClone.GetComponent<Rigidbody>();
            rb.AddForce(-bullet.transform.forward * bulletSpeed);
            VRTK_ControllerHaptics.TriggerHapticPulse(controllerReference, 10, 0.5f, 0.05f);
            Destroy(bulletClone, bulletLife);
        }
    }
}