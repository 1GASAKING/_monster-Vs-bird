using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  UnityEngine.SceneManagement;
public class LevelController : MonoBehaviour
{
    // Start is called before the first frame update
    private Enemy[] enemies;
    private static int nextLevelIndex=1;
    private void OnEnable()
    {
        enemies=FindObjectsOfType<Enemy>();
    
    }

    // Update is called once per frame
    void Update()
    {
       foreach (Enemy enemy in enemies)
       {   
           if (enemy!=null)
             {
                 return;
           
            }
           
       } 
       Debug.Log(" you killed all the enemies");
       nextLevelIndex++;
       string nextLevelName="Level"+ nextLevelIndex;
        SceneManager.LoadScene(nextLevelName);
    }
}
