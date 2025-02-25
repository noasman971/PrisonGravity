using System;
using UnityEngine;

public class SecurityCameraScript : MonoBehaviour
{
    
    private LineRenderer lineRenderer;
    private PolygonCollider2D polyCollider;
    public float timer = 0;
    public float rotationTimer = 6;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
	    createColliderDraw();
    }

    // Update is called once per frame
    void Update()
    {
	    if (timer > rotationTimer)
	    {
		    timer = 0;
		    gameObject.transform.rotation = Quaternion.Euler(0, 0, 180);
			Destroy(gameObject.GetComponent<LineRenderer>());
		    createColliderDraw();
	    }
	    else
	    {
		    timer += Time.deltaTime;
	    }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player entered");
        }
    }

    void createColliderDraw()
    {	    
	    polyCollider = GetComponent<PolygonCollider2D>();

	    lineRenderer = gameObject.AddComponent<LineRenderer>();
	    lineRenderer.positionCount = polyCollider.points.Length + 1;
	    lineRenderer.startWidth = 0.05f; 
	    lineRenderer.endWidth = 0.05f;
	    lineRenderer.loop = true; 
	    lineRenderer.material = new Material(Shader.Find("Sprites/Default")); 
	    lineRenderer.startColor = Color.gray; 
	    lineRenderer.endColor = Color.gray;

	    DrawCollider();
	    
    }
    
    void DrawCollider()
    {
	    Vector2 offset = polyCollider.offset; // Récupérer l'offset du collider

	    for (int i = 0; i < polyCollider.points.Length; i++)
	    {
		    Vector2 worldPoint = transform.TransformPoint(polyCollider.points[i] + offset); // Corriger l'offset
		    lineRenderer.SetPosition(i, worldPoint);
	    }

	    // Boucler le dernier point avec le premier
	    lineRenderer.SetPosition(polyCollider.points.Length, transform.TransformPoint(polyCollider.points[0] + offset));
    }
}
