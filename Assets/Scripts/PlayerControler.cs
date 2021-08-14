using UnityEngine;
using TMPro;
using System.Collections;


public class PlayerControler : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Unity References")]
    public GameObject uiObject;
    public HealthBar hpBar;
    public TextMeshProUGUI scoreText;
    public PlayerMovement pMovement;
    public SpriteRenderer playerImage;
    public ParticleSystem abilityParticles;

    private int currentHp;
    [Header("Player Settings")]
    public int maxHp = 25;
    [Header("Ability Settings")]
    public float abilityCooldown = 2f;
    public float abilityDuration = 1f;
    private bool isDead;
    private bool isUsingAbility;
    private float startTime;

    private float lastUse;

    void Start()
    {
        isDead = false;
        isUsingAbility = false;
        startTime = Time.time;
        lastUse = abilityCooldown;
        currentHp = maxHp;
        hpBar.SetCurrentHealth(maxHp, currentHp);
        uiObject.SetActive(false);
    }
    private void Update()
    {
        if (!isDead) UpdateScore();
        lastUse += Time.deltaTime;
        if (Input.GetButtonDown("Jump"))
        {
            UseAbility();
        }
    }
    private void UseAbility()
    {
        if (!isDead && lastUse >= abilityCooldown)
        {
            StartCoroutine(AbilityCoroutine());
            Debug.Log("Ability Used");
        }
        else Debug.Log("Ability in cooldown");
    }

    private IEnumerator AbilityCoroutine()
    {
        if (abilityParticles.isPlaying) abilityParticles.Stop();
        abilityParticles.Play();
        var c1 = playerImage.color;
        c1.a = 100f/255f;
        playerImage.color = c1;
        isUsingAbility = true;
        yield return new WaitForSeconds(abilityDuration);
        var c2 = playerImage.color;
        c2.a = 1;
        playerImage.color = c2;
        isUsingAbility = false;
        lastUse = 0;
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
            pMovement.StopMovement();
            playerImage.color = Color.red;
            Debug.Log("I died!");
        }
    }
    public bool PlayerIsDead()
    {
        return isDead || isUsingAbility;
    }
      
}
