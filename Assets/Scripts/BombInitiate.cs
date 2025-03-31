using UnityEngine;

public class BombInitiate : MonoBehaviour
{
    [SerializeField]private GameObject bomb;
    public void DropBomb()
    {
        Instantiate(bomb,transform.position, Quaternion.identity);
    }
}
