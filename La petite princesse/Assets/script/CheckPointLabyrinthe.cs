using UnityEngine.Events; // needed to use UnityEvent
using UnityEngine; // as usual
public class CheckPointLabyrinthe : MonoBehaviour
{

    public UnityEvent<PrincesseIdentity, CheckPointLabyrinthe> onCheckpointEnter;
    void OnTriggerEnter(Collider collider)
    {
        // if entering object is tagged as the Player
        PrincesseIdentity princesse = collider.gameObject.GetComponent<PrincesseIdentity>();
        if (princesse != null)
        {
            // fire an event giving the entering gameObject and this checkpoint
            onCheckpointEnter.Invoke(princesse, this);
            Debug.Log("ici");
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