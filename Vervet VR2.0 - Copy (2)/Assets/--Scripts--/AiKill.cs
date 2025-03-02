using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiKill : MonoBehaviour
{
    public Transform gorillaPlayer;
    public Transform respawnPoint;
    public List<GameObject> mapsToDisable;
    public float delayBeforeReEnabling;
    public float timeBeforeTeleport;
    public GameObject jumpscareObject;
    public float jumpscareDuration;
    public bool isJumpscaring = true;
    public AudioSource audio;
    public float jumpscareAudioDuration;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("HandTag") || other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(TeleportPlayer());

            if (isJumpscaring)
            {
                isJumpscaring = false;
                jumpscareObject.SetActive(true);
                audio.enabled = true;

                Invoke("DisableJumpscare", jumpscareDuration);
                Invoke("DisableJumpscareAudio", jumpscareAudioDuration);
            }
        }
    }

    IEnumerator TeleportPlayer()
    {
        foreach (GameObject x in mapsToDisable)
        {
            x.SetActive(false);
        }

        yield return new WaitForSeconds(timeBeforeTeleport);

        

        foreach (GameObject x in mapsToDisable)
        {
            x.SetActive(true);
        }

        gorillaPlayer.position = respawnPoint.position;
        yield return new WaitForSeconds(delayBeforeReEnabling);
    }

    private void DisableJumpscare()
    {
        jumpscareObject.SetActive(false);
        isJumpscaring = true;
    }

    private void DisableJumpscareAudio()
    {
        audio.enabled = false;
    }
}
