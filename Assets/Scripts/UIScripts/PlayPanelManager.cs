using UnityEngine;
using UnityEngine.UI;

public class PlayPanelManager : MonoBehaviour
{
    [SerializeField] private RacketController player1; // Encapsulation: Serialized field for controlled access, representing the player 1 racket
    [SerializeField] private RacketController player2; // Encapsulation: Serialized field for controlled access, representing the player 2 racket
    [SerializeField] private Toggle player1Toggle; // Encapsulation: Serialized field for controlled access, representing the player 1 toggle UI element
    [SerializeField] private Toggle player2Toggle; // Encapsulation: Serialized field for controlled access, representing the player 2 toggle UI element

    private void Start()
    {
        player1Toggle.isOn = player1.isPlayer; // Encapsulation: Setting the initial state of the player 1 toggle based on the isPlayer property
        player2Toggle.isOn = player2.isPlayer; // Encapsulation: Setting the initial state of the player 2 toggle based on the isPlayer property

        player1Toggle.onValueChanged.AddListener(OnPlayer1ToggleValueChanged); // Abstraction: Registering a listener for the player 1 toggle value change event
        player2Toggle.onValueChanged.AddListener(OnPlayer2ToggleValueChanged); // Abstraction: Registering a listener for the player 2 toggle value change event
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.SetActive(false); // Abstraction: Setting the active state of the game object to false
        }
    }

    private void OnPlayer1ToggleValueChanged(bool isOn)
    {
        player1.isPlayer = isOn; // Encapsulation: Updating the isPlayer property of the player 1 racket based on the toggle value
    }

    private void OnPlayer2ToggleValueChanged(bool isOn)
    {
        player2.isPlayer = isOn; // Encapsulation: Updating the isPlayer property of the player 2 racket based on the toggle value
    }
}