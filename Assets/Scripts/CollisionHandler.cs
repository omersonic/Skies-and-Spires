using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) 
    {
        switch (other.gameObject.tag) // checks the collided object's tag
        {
            case "Friendly":
                Debug.Log("Safe!");
                break;
            case "Finish":
                Debug.Log("Finished!");
                NextLevel();
                break;
            case "Boost":
                Debug.Log("Boost!");
                break;
            default:
                Debug.Log("Hit!");
                ReloadLevel(); 
                break;
        }
    }

    private void ReloadLevel() { // returns the currently active scene + its index, then loads
        Scene scene = SceneManager.GetActiveScene();
        int currentSceneIndex = scene.buildIndex;
        SceneManager.LoadSceneAsync(currentSceneIndex); //Async is preferable, needs an index int
    }

    private void NextLevel() { //loads the next level
        Scene scene = SceneManager.GetActiveScene();
        int currentSceneIndex = scene.buildIndex;
        SceneManager.LoadSceneAsync(currentSceneIndex+1);
    }
}
