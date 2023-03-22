using UnityEngine;
using UnityEngine.SceneManagement;

public class menuManager : MonoBehaviour
{


    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Labyrinthe");
        SceneManager.LoadScene(1); //Labyrinthe
    }

}
