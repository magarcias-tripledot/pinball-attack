using UnityEngine;

namespace Pinball
{
    [RequireComponent(typeof(Launcher))]
    public class LauncherInput : MonoBehaviour
    {
        [SerializeField]
        private float maxDistanceRange;
        [SerializeField]
        private Launcher launcher;

        private bool isDragging;
        private Vector3 dragStartPosition;

        private void OnValidate()
        {
            launcher = GetComponent<Launcher>();
        }

        private void Update()
        {
            if (launcher.IsCurrentProjectile) {
                return;
            }

            if (Input.GetMouseButtonDown(0)) {
                if (!isDragging) {
                    isDragging = true;
                    dragStartPosition = Input.mousePosition;
                }
            } else if (Input.GetMouseButtonUp(0)) {
                if (isDragging) {
                    isDragging = false;
                    var distance = Vector2.Distance(Input.mousePosition, dragStartPosition);
                    var magnitude = Mathf.Clamp01(distance / maxDistanceRange);
                    launcher.Launch(magnitude);
                }
            } else if (Input.GetMouseButton(0)) {
                if (isDragging) {
                    var dragDirection = dragStartPosition - Input.mousePosition;
                    dragDirection.x = - dragDirection.x;
                    dragDirection.Normalize();
                    
                    var magnitude = GetMagnitude();
                    // Debug.LogWarning($"Magnitude={magnitude}");
                    launcher.SetMagnitude(magnitude);
                    launcher.SetForward(dragDirection);
                }
            }
        }

        private float GetMagnitude()
        {
            if (isDragging) {
                var distance = Vector2.Distance(Input.mousePosition, dragStartPosition);
                // Debug.LogWarning($"GetMagnitude : distance={distance}");
                return Mathf.Clamp01(distance / maxDistanceRange);
            }

            return 0f;
        }
    }
}