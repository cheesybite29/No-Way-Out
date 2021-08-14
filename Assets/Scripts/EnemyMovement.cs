using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private GameObject player;
    public EnemyStats stats;
    public Rigidbody2D rb;
    private float lastAttack;


    // Update is called once per frame
    private void Start()
    {
        lastAttack = stats.attackSpeed;
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        lastAttack += Time.deltaTime;
    }
    void FixedUpdate()
    {
        if(player.GetComponent<PlayerControler>().PlayerIsDead() == false) rb.MovePosition(Vector2.MoveTowards(transform.position, player.transform.position, stats.moveSpeed * Time.fixedDeltaTime));
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (lastAttack >= stats.attackSpeed)
            {
                player.GetComponent<PlayerControler>().DamagePlayer(stats.damage);
                lastAttack = 0;
            }
        }
    }


}
