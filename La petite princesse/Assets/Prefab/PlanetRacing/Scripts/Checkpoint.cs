using UnityEngine.Events; // needed to use UnityEvent
using UnityEngine; // as usual
public class Checkpoint : MonoBehaviour
{

    public UnityEvent<CarIdentity, Checkpoint> onCheckpointEnter;
    void OnTriggerEnter(Collider collider)
    {
        // if entering object is tagged as the Player
        CarIdentity car = collider.gameObject.GetComponent<CarIdentity>();
        if (car != null)
        {
            // fire an event giving the entering gameObject and this checkpoint
            onCheckpointEnter.Invoke(car, this);
        }
    }
    /* TD1
   public UnityEvent<GameObject, Checkpoint> onCheckpointEnter;
   void OnTriggerEnter(Collider collider)
   {
       // if entering object is tagged as the Player
       if (collider.gameObject.tag == "Player")
       {
           // fire an event giving the entering gameObject and this checkpoint
           onCheckpointEnter.Invoke(collider.gameObject, this);
       }
   }*/
}
