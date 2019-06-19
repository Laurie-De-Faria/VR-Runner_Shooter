namespace VRTK.Examples
{
    using UnityEngine;

    public class LightSaber : VRTK_InteractableObject
    {
        private bool beamActive = false;
        private Vector2 beamLimits = new Vector2(0f, 1.2f);
        private float currentBeamSize;
        private float beamExtendSpeed = 0;

        private GameObject blade;
        private Color activeColor;
        private Color targetColor;
        private Color[] bladePhaseColors;

        BoxCollider save;

        private VRTK_ControllerReference controllerReference;

        public override void StartUsing(VRTK_InteractUse currentUsingObject = null)
        {
            base.StartUsing(currentUsingObject);
            beamExtendSpeed = 5f;
            bladePhaseColors = new Color[2] { Color.blue, Color.cyan };
            activeColor = bladePhaseColors[0];
            targetColor = bladePhaseColors[1];
        }

        public override void StopUsing(VRTK_InteractUse previousUsingObject = null, bool resetUsingObjectState = true)
        {
            base.StopUsing(previousUsingObject, resetUsingObjectState);
            beamExtendSpeed = -5f;
            GetComponent<BoxCollider>().size = save.size;
            GetComponent<BoxCollider>().center = save.center;
        }

        protected void Start()
        {
            blade = transform.Find("Blade").gameObject;
            currentBeamSize = beamLimits.x;
            SetBeamSize();
            save = GetComponent<BoxCollider>();
        }

        public override void Grabbed(VRTK_InteractGrab grabbingObject)
        {
            base.Grabbed(grabbingObject);
            controllerReference = VRTK_ControllerReference.GetControllerReference(grabbingObject.controllerEvents.gameObject);
        }

        protected override void Update()
        {
            base.Update();
            currentBeamSize = Mathf.Clamp(blade.transform.localScale.y + (beamExtendSpeed * Time.deltaTime), beamLimits.x, beamLimits.y);
            SetBeamSize();
            PulseBeam();
        }

        private void SetBeamSize()
        {
            blade.transform.localScale = new Vector3(1f, currentBeamSize, 1f);
            BoxCollider box = GetComponent<BoxCollider>();
            box.size = new Vector3(box.size.x, 1, box.size.z);
            box.center = new Vector3(box.center.x, 0.4f, box.center.z);
            beamActive = (currentBeamSize >= beamLimits.y ? true : false);
        }

        private void PulseBeam()
        {
            if (beamActive)
            {
                Color bladeColor = Color.Lerp(activeColor, targetColor, Mathf.PingPong(Time.time, 1));
                blade.transform.Find("Beam").GetComponent<MeshRenderer>().material.color = bladeColor;

                if (bladeColor == targetColor)
                {
                    var previouslyActiveColor = activeColor;
                    activeColor = targetColor;
                    targetColor = previouslyActiveColor;
                }
            }
        }

        private void OnCollisionStay(Collision collision)
        {
            VRTK_ControllerHaptics.TriggerHapticPulse(controllerReference, 1);

        }
    }
}