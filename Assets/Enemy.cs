using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{ [SerializeField]private GameObject cloudParticle;
  
    private void OnCollisionEnter2D(Collision2D other)
    {
        Bird hitByBird =other.collider.GetComponent<Bird>();
        Enemy hitAnotherEnemy =other.collider.GetComponent<Enemy>();
        if(hitByBird !=null)
        {   
            
            Instantiate(cloudParticle,transform.position,Quaternion.identity);
            Destroy(gameObject);
            return;
        }

       
        if (hitAnotherEnemy!=null)
        {
            return;

        }

         if(other.contacts[0].normal.y< -0.5)
         {   Instantiate(cloudParticle,transform.position,Quaternion.identity);
             Destroy(gameObject);
         }
         

    }
}
