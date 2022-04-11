using UnityEngine;

public class ColourChange : MonoBehaviour
{
    //Using a singleton other objects can access to match Player's colour value
    public static ColourChange instance;

    public Renderer rend;

    public TrailRenderer trail;

    //String used for Player's colour
    public string PlayerColour;

    //Integer to determine a value for Player's colour
    public int colourvalue;

    private void Awake()
    {
        instance = this;
    }

    private void OnTriggerEnter(Collider Player)
    {
        if (Player.CompareTag("GPickUp"))
        {
            //Changing Player's colour to green when it collides with the green pick up using tags and its trail renderer
            PlayerColour = "Green";
            colourvalue = 1;
            rend.material.color = Color.green;
            trail.material.color = Color.green;
        }

        if (Player.CompareTag("RPickUp"))
        {
            //Changing Player's colour to red when it collides with the red pick up using tags and its trail renderer
            PlayerColour = "Red";
            colourvalue = 2;
            rend.material.color = Color.red;
            trail.material.color = Color.red;
        }

        if (Player.CompareTag("YPickUp"))
        {
            //Changing Player's colour to yellow when it collides with the yellow pick up using tags and its trail renderer
            PlayerColour = "Yellow";
            colourvalue = 3;
            rend.material.color = Color.yellow;
            trail.material.color = Color.yellow;
        }

        if (Player.CompareTag("MPickUp"))
        {
            //Changing Player's colour to magenta when it collides with the magenta pick up using tags and its trail renderer
            PlayerColour = "Magenta";
            colourvalue = 4;
            rend.material.color = Color.magenta;
            trail.material.color = Color.magenta;
        }

        if (Player.CompareTag("BPickUp"))
        {
            //Changing Player's colour to blue when it collides with the blue pick up using tags and its trail renderer
            PlayerColour = "Blue";
            colourvalue = 5;
            rend.material.color = Color.blue;
            trail.material.color = Color.blue;
        }
    }
}
