using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [HideInInspector] public int currentSceneIndex;
    private void OnCollisionEnter(Collision other) 
    {
        switch (other.gameObject.tag) // checks the collided object's tag
        {
            case "Friendly":
                Debug.Log("Safe!");
                break;
            case "Finish":
                Debug.Log("Finished!");
                loadLevel();
                break;
            case "Boost":
                Debug.Log("Boost!");
                break;
            case "Boundary":
                Debug.Log("Wall!");
                break;
            default:
                Debug.Log("Hit!");
                ReloadLevel(); 
                break;
        }
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
