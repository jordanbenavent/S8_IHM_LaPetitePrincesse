using UnityEngine;
using UnityEngine.SceneManagement;


public class loaderScene : MonoBehaviour
{
    public int number;

    void OnCollisionEnter(Collision collision)
    {
        SceneManager.LoadScene(number);
    }

}
