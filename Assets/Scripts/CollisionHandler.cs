using System;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    static AudioSource audioSource;

    [HideInInspector] public int currentSceneIndex;
    [SerializeField] private float delaySec = 1.5f;
    //controls crash sound and volume
    [SerializeField] AudioClip crashSound;
    [SerializeField] private float crashVol = 0.1f;
    //victory sound and volume
    [SerializeField] AudioClip victorySound;
    [SerializeField] private float victoryVol = 0.8f;

    bool isTransitioning = false; //initiates game state toggling


    void Awake() {
        
        audioSource = GetComponent<AudioSource>();
    }


    private void OnCollisionEnter(Collision other) 
    {
        
        if (isTransitioning) return; //prevents overlapping cases and terminates switch statement

        switch (other.gameObject.tag) // checks the collided object's tag
        {
            case "Friendly":
                Debug.Log("Safe!");
                break;
            case "Finish":
                Debug.Log("Finished!");
                StartSuccess();
                break;
            case "Boost":
                Debug.Log("Boost!");
                break;
            case "Boundary":
                Debug.Log("Wall!");
                break;
            default:
                Debug.Log("Hit!");
                startCrash(); 
                break;
        }
    }

    private void StartSuccess()
    {
        // add SFX and particles
        isTransitioning = true;
        if (victorySound != null && audioSource != null) {
            audioSource.clip = victorySound;
            audioSource.PlayOneShot(victorySound, victoryVol); // plays the sound and volume from the audioSource component
        }
        GetComponent<PlayerMovement>().enabled = false;
        Invoke(nameof(loadLevel), delaySec);
    }

    private void startCrash() {

        isTransitioning = true;
        // add SFX and particles
        if (victorySound != null && audioSource != null) {
            audioSource.clip = crashSound;
            audioSource.PlayOneShot(crashSound, crashVol); // plays the sound and volume from the audioSource component
        }
        GetComponent<PlayerMovement>().enabled = false; //disables player movement script
        Invoke(nameof(ReloadLevel), delaySec); // no longer reliant on string

    }

    
    private void loadLevel() { // returns the currently active scene + its index, then loads.
        Scene scene = SceneManager.GetActiveScene();
        currentSceneIndex = scene.buildIndex;
        int nextSceneIndex = scene.buildIndex+1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings) {
           nextSceneIndex = 0; // resets the index count if reaches final level
        }
         SceneManager.LoadSceneAsync(nextSceneIndex); //Async is preferable, needs an index int
    }

    private void ReloadLevel() {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadSceneAsync(currentSceneIndex);
    }
}
