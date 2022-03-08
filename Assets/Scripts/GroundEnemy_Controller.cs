using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemy_Controller : MonoBehaviour
{
    #region parameters
    [SerializeField]
    private float speed;
    [SerializeField]
    private Vector3[] positions;
    private int index;
    [SerializeField]
    private int health = 2;
    #endregion


    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, positions[index], Time.deltaTime * speed);

        if (transform.position == positions[index])
        {
            if (index == positions.Length - 1)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
                index = 0;
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
                index++;
            }
        }
    }
    public void Damage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        Destroy(gameObject);
    }
}
