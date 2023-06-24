using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour
{
    public Button playButton;
    public Button shopButton;
    public Button exitButton;
    public PlayerMovement pl;
    private string telegram = "https://t.me/+21tvf210leUyODNi";

    private void Start()
    {
        playButton.onClick.AddListener(StartButton);
        shopButton.onClick.AddListener(ShopClick);
        exitButton.onClick.AddListener(Exit);
    }

    private void StartButton()
    {
        SceneManager.LoadScene("FirstLevel");
    }

    private void ShopClick()
    {
        Application.OpenURL(telegram);
    }

    private void Exit()
    {
        Application.Quit(); 
    }
}
