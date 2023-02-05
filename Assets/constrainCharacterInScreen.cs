
using UnityEngine;
public class constrainCharacterInScreen : MonoBehaviour
{
    public GameObject[] colliders; //Array of the collider GameObjects
    public float screenPadding = 0.05f; //Padding around the screen

    private void Start()
    { //Get the screen bounds in world space
        Vector3 bottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector3 topRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));

        //Calculate the width and height of the screen
        float width = topRight.x - bottomLeft.x;
        float height = topRight.y - bottomLeft.y;

        //Set the position and scale of each collider
        colliders[0].transform.position = new Vector3(bottomLeft.x + width / 2, topRight.y + screenPadding, 0);
        colliders[0].transform.localScale = new Vector3(width, screenPadding, 1);

        colliders[1].transform.position = new Vector3(topRight.x + screenPadding, bottomLeft.y + height / 2, 0);
        colliders[1].transform.localScale = new Vector3(screenPadding, height, 1);

        colliders[2].transform.position = new Vector3(bottomLeft.x + width / 2, bottomLeft.y - screenPadding, 0);
        colliders[2].transform.localScale = new Vector3(width, screenPadding, 1);

        colliders[3].transform.position = new Vector3(bottomLeft.x - screenPadding, bottomLeft.y + height / 2, 0);
        colliders[3].transform.localScale = new Vector3(screenPadding, height, 1);
    }
}