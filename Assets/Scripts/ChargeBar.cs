using UnityEngine;
using UnityEngine.UI;

namespace Pinball
{
    public class ChargeBar : MonoBehaviour
    {
        [SerializeField]
        private Image fillImage;

        public void SetActive(bool active)
        {
            gameObject.SetActive(active);
        }

        public void SetFillAmount(float fillAmount)
        {
            fillImage.fillAmount = fillAmount;
        }
    }
}