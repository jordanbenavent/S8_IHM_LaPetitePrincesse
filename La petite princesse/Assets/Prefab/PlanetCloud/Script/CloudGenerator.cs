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
    private Vector3 lastBackgroundCloudPos = new Vector3(0, 0, 0);   // Y position of the last generated cloud
    private bool done = false;

    void Start(){
        ScreenFader.OnFadeComplete += HandleGameEnding;
    }

    void Update()
    {
        if (player.position.y > lastCloudPos.y - 9f + interval && player.position.y < endAltitude)     // check if the player has progressed by the interval distance
        {
            Vector3 position = new Vector3(Random.Range(-5f, 5f), lastCloudPos.y + interval + Random.Range(-0.5f, 0.5f), 0f);   // generate a random position for the cloud
            int index = Random.Range(0, cloudPrefabs.Length);    // choose a random cloud prefab from the array
            GameObject cloud = cloudPrefabs[index];
            Instantiate(cloud , position + cloud.transform.position, Quaternion.identity);  // instantiate the cloud prefab at the position
            lastCloudPos = position;    // update the Y position of the last generated cloud
        }
        else if (player.position.y > lastCloudPos.y - 9f + interval && !done)
        {
            GameObject trophyObj = Instantiate(trophy, lastCloudPos + new Vector3(0, 1f, 0), Quaternion.Euler(-90, 0, 0));
            trophyObj.AddComponent<RotationScript>();
            trophyObj.AddComponent<AddGlowEffect>();
            trophyObj.tag = "trophyTag";
            trophyObj.layer = 7;
            done = true;
        }

        if (player.position.y > lastBackgroundCloudPos.y - 9f && player.position.y < endAltitude + 3f)
        {
            Vector3 position = new Vector3(Random.Range(-5f, 5f), lastBackgroundCloudPos.y + 4f + Random.Range(-0.5f, 2f), 6f + UnityEngine.Random.Range(-1f, 1f));   // generate a random position for the cloud
            int index = Random.Range(0, cloudPrefabs.Length);
            GameObject cloud = Instantiate(cloudPrefabs[index] , position + cloudPrefabs[index].transform.position, Quaternion.identity);
            cloud.AddComponent<BackgroundMovement>();
            if (Random.Range(0f, 2f) < 1f){
                position = new Vector3(Random.Range(-5f, 5f), lastBackgroundCloudPos.y + 4f + Random.Range(-0.5f, 2f), 6f + UnityEngine.Random.Range(-1f, 1f));
                index = Random.Range(0, cloudPrefabs.Length);
                cloud = Instantiate(cloudPrefabs[index] , position + cloudPrefabs[index].transform.position, Quaternion.identity);
                cloud.AddComponent<BackgroundMovement>();
            }
            lastBackgroundCloudPos = position;
        }
    }

    void HandleGameEnding(){
        Debug.Log("Event reached.");
        menuManager mM = FindObjectOfType<menuManager>();
        mM.giveCloudTrophy();
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f;
        SceneManager.LoadScene(1);
        Debug.Log("Done !");
    }
}