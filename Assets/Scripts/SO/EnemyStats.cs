using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Stats", menuName = "Enemy Stats")]
public class EnemyStats : ScriptableObject
{
    public string monsterName;
    public float attackSpeed;
    public float moveSpeed;
    public int damage;
}
