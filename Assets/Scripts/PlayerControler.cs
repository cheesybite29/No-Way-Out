using UnityEngine;
using TMPro;

public class PlayerControler : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject uiObject;
    public HealthBar hpBar;
    public TextMeshProUGUI scoreText;

    private int currentHp;
    public int maxHp = 25;
    private bool isDead;
    private float startTime;

    void Start()
    {
        isDead = false;
        startTime = Time.time;
        currentHp = maxHp;
        hpBar.SetCurrentHealth(maxHp, currentHp);
        uiObject.SetActive(false);
    }
    private void Update()
    {
        if (!isDead) UpdateScore();
    }
    private void UpdateScore()
    {
        scoreText.text = "SCORE: " + Mathf.Ceil((Time.time - startTime) * (Time.time - startTime));
    }

    public void DamagePlayer(int damage)
    {
        currentHp -= damage;
        hpBar.SetCurrentHealth(maxHp, currentHp);
        if (currentHp <= 0)
        {
            uiObject.SetActive(true);
            isDead = true;
            Debug.Log("I died!");
        }
    }
      
}
