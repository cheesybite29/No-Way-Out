using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image hpImage;
    
    public void SetCurrentHealth(int maxHp, int currentHp)
    {
        if (currentHp < 0) currentHp = 0;
        if (currentHp > maxHp) currentHp = maxHp;
        hpImage.fillAmount = (float)currentHp / (float)maxHp;
    }
}
