using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [field: SerializeField] public float MaxHealthPlayer { get; set; }
    public float CurrentHealthPlayer { get; set; }

    [SerializeField] private GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Damage(float damage)
    {
        CurrentHealthPlayer -= damage;
        if (CurrentHealthPlayer <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(player.gameObject);
    }
    
}
