using UnityEngine;

public interface EnemyMoveable 
{
   Rigidbody2D rb { get; set; }
   
   bool IsFacingRight { get; set; }
   
   void MoveEnemy(Vector2 velocity);
   
   void CheckForLeftOrRightFacing(Vector2 velocity);
}
