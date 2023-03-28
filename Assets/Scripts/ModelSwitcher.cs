using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelSwitcher : MonoBehaviour
{
public GameObject originalPrefab; // assign your original prefab to this in the inspector
public GameObject newPrefab; // assign the new prefab you want to switch to in the inspector
private GameObject _currentPrefab; // the currently active prefab
private bool canSwitchPrefab = true; // flag to prevent multiple prefab switches per frame

public Vector3 initialPosition; // assign a different initial position for the prefab in the inspector

public GameObject currentPrefab
{
    get { return _currentPrefab; }
    private set { _currentPrefab = value; }
}

void Start()
{
    // Instantiate the original prefab and set it as the current prefab at the specified initial position
    currentPrefab = Instantiate(originalPrefab, initialPosition, transform.rotation);
}

void Update()
{
    // Switch to the new prefab when the G key is pressed
    if (Input.GetKeyDown(KeyCode.G) && canSwitchPrefab)
    {
        canSwitchPrefab = false; // set the flag to false to prevent multiple prefab switches per frame

        // Get the position and rotation of the current prefab
        Vector3 position = currentPrefab.transform.position;
        Quaternion rotation = currentPrefab.transform.rotation;

        // Destroy the current prefab and instantiate the new one at the same location with the same facing direction
        Destroy(currentPrefab);
        currentPrefab = Instantiate(newPrefab, position, rotation);

        // Set the new prefab's rotation to the old prefab's rotation
        currentPrefab.transform.rotation = rotation;
    }
    
    // Switch back to the original prefab when the G key is pressed again
    else if (Input.GetKeyDown(KeyCode.G) && !canSwitchPrefab)
    {
        canSwitchPrefab = true; // set the flag to true to allow another prefab switch

        // Get the position and rotation of the current prefab
        Vector3 position = currentPrefab.transform.position;
        Quaternion rotation = currentPrefab.transform.rotation;

        // Destroy the current prefab and instantiate the original one at the same location with the same facing direction
        Destroy(currentPrefab);
        currentPrefab = Instantiate(originalPrefab, position, rotation);

        // Set the new prefab's rotation to the old prefab's rotation
        currentPrefab.transform.rotation = rotation;
    }
}

}
