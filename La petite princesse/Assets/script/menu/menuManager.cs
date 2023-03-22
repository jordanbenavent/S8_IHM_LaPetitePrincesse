using UnityEngine;
using UnityEngine.SceneManagement;


public class menuManager : MonoBehaviour
{
    public int number;

    void OnCollisionEnter(Collision collision)
    {
        SceneManager.LoadScene(number); //Labyrinthe
    }

}
