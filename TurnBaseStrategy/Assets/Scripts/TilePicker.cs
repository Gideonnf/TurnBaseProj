using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilePicker : MonoBehaviour
{
    public GameObject TestCharacter;

    Vector3 TargetPosition;
    public bool isMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // on mouse click
        if (Input.GetMouseButtonDown(0))
        {
            // Cast a ray from mouse cursor
            RaycastHit[] hits;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // Raycast to check for collided targets
            hits = Physics.RaycastAll(ray, 100.0f);
           
            // Loop through the raycast targets
            for (int i = 0; i < hits.Length; i++)
            {
                RaycastHit hit = hits[i];

                // if it collides with a tile
                if (hit.transform.tag == "Tile")
                {
                    Debug.Log("Hit a tile");
                    Debug.Log("Tile Position " + hit.transform.position);

                    if (isMoving == false)
                    {
                        int index = TileGenerator.instance.ListOfTiles.IndexOf(hit.transform.gameObject);
                        if (index >= 0)
                        {
                            // Retrieve that tile
                            GameObject targetTile = TileGenerator.instance.ListOfTiles[index];
                            // Set the target position for the character
                            TargetPosition = targetTile.transform.position;

                            // Set isMoving
                            isMoving = true;
                        }
                    }
                    // Return after finishing what i needa do
                    return;
                }
            }
        }
   
        // if its moving
        if (isMoving)
        {
            // Get the direction to move towards to
            Vector3 dir = TargetPosition - TestCharacter.transform.position;
            dir.y = 0;
            // Normalize it
            dir.Normalize();

            TestCharacter.transform.position += dir * Time.deltaTime * 7.0f;

            
        }
    }
}
