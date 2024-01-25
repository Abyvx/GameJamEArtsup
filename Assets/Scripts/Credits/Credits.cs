using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class ScreenCollider : MonoBehaviour
{
    // public GameObject prefab;


    // void Start()
    // {
    //     int screenWidth = Screen.width;
    //     int screenHeight = Screen.height;

    //     GameObject RightWall = GameObject.Instantiate(prefab, new Vector3(screenWidth/200,0,0),Quaternion.identity);
    //     BoxCollider2D RightWallCollider = RightWall.GetComponent<BoxCollider2D>();
    //     RightWallCollider.size = new Vector2(1,10);        
       
    //     GameObject LeftWall = GameObject.Instantiate(prefab, new Vector3(- screenWidth/200,0,0),Quaternion.identity);
    //     BoxCollider2D LeftWallCollider = LeftWall.GetComponent<BoxCollider2D>();
    //     LeftWallCollider.size = new Vector2(1,10);  
        
    //     GameObject TopWall = GameObject.Instantiate(prefab, new Vector3(0,screenHeight/200,0),Quaternion.identity);
    //     BoxCollider2D TopWallCollider = TopWall.GetComponent<BoxCollider2D>();
    //     TopWallCollider.size = new Vector2(20,1);  
        
    //     GameObject BottomWall = GameObject.Instantiate(prefab, new Vector3(0,-screenHeight/200,0),Quaternion.identity);
    //     BoxCollider2D BottomWallCollider = BottomWall.GetComponent<BoxCollider2D>();
    //     BottomWallCollider.size = new Vector2(20,1);  




    // }
    // void Update()
    // {
    // transform.Translate(Vector3.right * 2 * Time.deltaTime);



    // }
    // void BounceOffScreenEdges()
    // {
    //     Collider2D[] hitColliders = Physics2D.OverlapBoxAll(transform.position, transform.localScale / 2f, 0f);

    //     foreach (Collider2D collider in hitColliders)
    //     {
    //         if (collider.CompareTag("ScreenEdge"))
    //         {
    //             // Reflect the direction when hitting a screen edge
    //             Vector3 normal = collider.transform.up;
    //             Vector3 reflection = - Vector3.Reflect(transform.right, normal);
    //             transform.right = reflection;

    //             // Adjust the position slightly to avoid colliding with the same edge continuously
    //             transform.Translate(Vector3.right * 0.1f);
    //         }
    //     }
    // }


    EdgeCollider2D edgeCollider;

    void Awake()
    {
        edgeCollider = this.GetComponent<EdgeCollider2D>();
        CreateEdgeCollider();
    }

    //call this at start and whenever the resolution changes
    void CreateEdgeCollider()
    {
        List<Vector2> edges = new List<Vector2>();
        edges.Add(Camera.main.ScreenToWorldPoint(Vector2.zero));
        edges.Add(Camera.main.ScreenToWorldPoint(new Vector2(Screen.width,0)));
        edges.Add(Camera.main.ScreenToWorldPoint(new Vector2(Screen.width,Screen.height)));
        edges.Add(Camera.main.ScreenToWorldPoint(new Vector2(0,Screen.height)));
        edges.Add(Camera.main.ScreenToWorldPoint(Vector2.zero));
        edgeCollider.SetPoints(edges);
    }

    //runs when colliding if collider is Not set to Trigger
    // void OnCollisionEnter2D(Collision2D collision)
    // {
    //     //Because of colliders default physics behaviour, and the timing of it
    //     //you have to use the rigidbody's velocity from the previous frame to avoid using a "post default interaction" velocity
    //     //Throwable.velocity allows for that if it's updated regularly (in Throwable.Update(), Path.VisualizePath() for example)
    //     Rigidbody2D collidingRB = collision.transform.GetComponent<Rigidbody2D>();
    //     Vector3 newVelocity = Vector3.Reflect(collidingRB.velocity, -collision.GetContact(0).normal);
    //     collidingRB.velocity = newVelocity;
    //     Debug.Log(newVelocity);
    // }
    //runs when colliding if collider set to Trigger
    void OnTriggerEnter2D(Collider2D collider)
    {
        Rigidbody2D colliderRB = collider.GetComponent<Rigidbody2D>();
        //contact point is gotten by raycasting in the colliders velocity direction at the colliders position.
        RaycastHit2D[] hit2D = Physics2D.RaycastAll(collider.transform.position, colliderRB.velocity);
        //second one is being used because first one is self, could probably ignore self-layer and get as Physics2D.Raycast() instead
        Vector2 contactPoint = hit2D[1].point;
        //Get normal of contact point by creating a line from the contact point to the closest collider point and rotating 90°
        Vector2 normal = Vector2.Perpendicular(contactPoint - GetClosestPoint(collider.transform.position)).normalized;
        //reflect the current velocity at the edge normal
        colliderRB.velocity = Vector2.Reflect(colliderRB.velocity, normal);
    }
    // Goes through edgeCollider Points and returns the one closest to position
    Vector2 GetClosestPoint(Vector2 position)
    {
        Vector2[] points = edgeCollider.points;
        float shortestDistance = Vector2.Distance(position,points[0]);
        Vector2 closestPoint = points[0];
        foreach(Vector2 point in points)
        {
            if(Vector2.Distance(position,point) < shortestDistance)
            {
                shortestDistance = Vector2.Distance(position,point);
                closestPoint = point;
            }
        }
        return closestPoint;
    }
}
