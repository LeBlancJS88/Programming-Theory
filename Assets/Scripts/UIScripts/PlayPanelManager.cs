using UnityEngine;
using UnityEngine.UI;

public class PlayPanelManager : MonoBehaviour
{
    public RacketController player1;
    public RacketController player2;
    public Toggle player1Toggle;
    public Toggle player2Toggle;

    private void Start()
    {
        player1Toggle.isOn = player1.isPlayer;
        player2Toggle.isOn = player2.isPlayer;

        player1Toggle.onValueChanged.AddListener(OnPlayer1ToggleValueChanged);
        player2Toggle.onValueChanged.AddListener(OnPlayer2ToggleValueChanged);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.SetActive(false);
        }
    }

    private void OnPlayer1ToggleValueChanged(bool isOn)
    {
        player1.isPlayer = isOn;
    }

    private void OnPlayer2ToggleValueChanged(bool isOn)
    {
        player2.isPlayer = isOn;
    }
}