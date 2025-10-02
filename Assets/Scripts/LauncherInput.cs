using UnityEngine;

namespace DefaultNamespace
{
    [RequireComponent(typeof(Launcher))]
    public class LauncherInput : MonoBehaviour
    {
        [SerializeField]
        private float maxDistanceRange;
        [SerializeField]
        private Launcher launcher;

        private bool isDragging;
        private Vector2 dragStartPosition;

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
            } else if (isDragging) {
                isDragging = false;
                var distance = Vector2.Distance(Input.mousePosition, dragStartPosition);
                var magnitude = Mathf.Clamp01(distance / maxDistanceRange);
                launcher.Launch(magnitude);
            }
        }
    }
}