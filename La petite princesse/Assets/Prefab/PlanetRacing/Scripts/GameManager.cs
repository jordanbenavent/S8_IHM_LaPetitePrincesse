using System.Collections; using UnityEngine;
public class GameManager : MonoBehaviour
{
    public PlayerControls playerControls;
    public AIControls[] aiControls;
    public LapManager lapTracker;
    public TricolorLights tricolorLights;
    public AudioSource AudioSource;
    public AudioClip lowBeep;
    public AudioClip highBeep;
    public Animator cameraIntroAnimator;
    public FollowPlayer followPlayerCamera;

    private void Awake()
   {
       StartIntro();
   }
   public void StartIntro()
   {
       followPlayerCamera.enabled = false;
       cameraIntroAnimator.enabled = true;
       FreezePlayers(true);
   }
   public void StartCountdown()
   {
       followPlayerCamera.enabled = true;
       cameraIntroAnimator.enabled = false;
       StartCoroutine("Countdown");
   }

    public void StartGame()
    {
        FreezePlayers(true);
        StartCoroutine("Countdown");
    }
    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(1);
        Debug.Log("3");
        tricolorLights.SetProgress(1);
        AudioSource.PlayOneShot(lowBeep);
        yield return new WaitForSeconds(1);
        Debug.Log("2");
        tricolorLights.SetProgress(2);
        AudioSource.PlayOneShot(lowBeep);
        yield return new WaitForSeconds(1);
        Debug.Log("1");
        tricolorLights.SetProgress(3);
        AudioSource.PlayOneShot(lowBeep);
        yield return new WaitForSeconds(1);
        Debug.Log("GO");
        AudioSource.PlayOneShot(highBeep);
        tricolorLights.SetProgress(4);
        StartRacing();
        yield return new WaitForSeconds(2f);
        tricolorLights.SetAllLightsOff();
        
    }
    public void StartRacing()
    {
        FreezePlayers(false);
    }
    void FreezePlayers(bool freeze)
    {
        //TODO : freeze players here
        playerControls.enabled  = !freeze;
        foreach(AIControls ia in aiControls){
            ia.enabled  = !freeze;
        }
    }
}