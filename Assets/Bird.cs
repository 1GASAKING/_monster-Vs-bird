using UnityEngine;
using  UnityEngine.SceneManagement;
public class Bird : MonoBehaviour
{  private Vector3 startPosition;
   [SerializeField] private float launchPower=500;
   private bool wasLaunched=false;
   private float timeSittingStil;
   
    private void Awake()
    {
         startPosition=transform.position;

    }
   private void OnMouseDown()
   {
       GetComponent<SpriteRenderer>().color= Color.red;
       GetComponent<LineRenderer>().enabled=true;
   }
   private void Update()
   {
      GetComponent<LineRenderer>().SetPosition(1,startPosition);
        GetComponent<LineRenderer>().SetPosition(0,transform.position);
       if(transform.position.y>10 ||
          transform.position.y<-10||
          transform.position.x<-10||
          transform.position.x>10 ||
          timeSittingStil>3         )
       {string currntsceneName=SceneManager.GetActiveScene().name;
           SceneManager.LoadScene(currntsceneName);
       }
       
       if (wasLaunched &&   GetComponent<Rigidbody2D>().velocity.magnitude<=0.1)
       {
         timeSittingStil += Time.deltaTime;  
       }
   }
   private void OnMouseUp()
   {
         GetComponent<SpriteRenderer>().color=Color.white;
         Vector2 direction= startPosition-transform.position;
         GetComponent<Rigidbody2D>().AddForce(direction*launchPower);
         GetComponent<Rigidbody2D>().gravityScale=1;
         wasLaunched=true;
          GetComponent<LineRenderer>().enabled=false;

       
   }

   private void OnMouseDrag()
   {   
       Vector3 newPosition=Camera.main.ScreenToWorldPoint( Input.mousePosition);
       newPosition.z=0;
       transform.position= newPosition;

   }
}
