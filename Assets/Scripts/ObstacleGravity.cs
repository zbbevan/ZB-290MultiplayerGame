using UnityEngine;

public class ObstacleGravity : MonoBehaviour
{
   void FixedUpdate()
   {
       // Apply a constant downward force to the obstacle
       GetComponent<Rigidbody>().AddForce(Vector3.down * 2, ForceMode.Acceleration);
   }
}
