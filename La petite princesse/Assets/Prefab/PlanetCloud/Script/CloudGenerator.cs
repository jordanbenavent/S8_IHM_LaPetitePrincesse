using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CloudGenerator : MonoBehaviour
{
    public GameObject[] cloudPrefabs;   // array of cloud prefabs
    public GameObject trophy;
    public float interval = 3f;         // interval in meters between each cloud
    public float endAltitude = 30f;

    public Transform player;           // reference to the player's transform
    private Vector3 lastCloudPos = new Vector3(0, 4f, 0);   // Y position of the last generated cloud
    private bool done = false;

    void Start(){
        ScreenFader.OnFadeComplete += HandleGameEnding;
    }

    void Update()
    {
        if (player.position.y > lastCloudPos.y - 7f + interval && player.position.y < endAltitude)     // check if the player has progressed by the interval distance
        {
            Vector3 position = new Vector3(Random.Range(-5f, 5f), lastCloudPos.y + interval + Random.Range(-0.5f, 0.5f), 0f);   // generate a random position for the cloud
            int index = Random.Range(0, cloudPrefabs.Length);    // choose a random cloud prefab from the array
            GameObject cloud = cloudPrefabs[index];
            Instantiate(cloud , position + cloud.transform.position, Quaternion.identity);  // instantiate the cloud prefab at the position
            lastCloudPos = position;    // update the Y position of the last generated cloud
        }
        else if (player.position.y > lastCloudPos.y - 7f + interval && !done)
        {
            GameObject trophyObj = Instantiate(trophy, lastCloudPos + new Vector3(0, 1f, 0), Quaternion.Euler(-90, 0, 0));
            trophyObj.AddComponent<RotationScript>();
            trophyObj.AddComponent<AddGlowEffect>();
            trophyObj.tag = "trophyTag";
            trophyObj.layer = 7;
            done = true;
        }
    }

    void HandleGameEnding(){
        menuManager mM = FindObjectOfType<menuManager>();
        mM.giveCloudTrophy();
        SceneManager.LoadScene(0);
        Debug.Log("Done !");
    }
}