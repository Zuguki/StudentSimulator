using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void StartScene() => SceneManager.LoadScene("Start");

    public void StatsScene() => SceneManager.LoadScene("Stats");

    public void ScinesScene() => SceneManager.LoadScene("Scines");

    public void RespectScene() => SceneManager.LoadScene("Respect");

    public void MeetScene() => SceneManager.LoadScene("Meet");

    public void MoneyScene() => SceneManager.LoadScene("Money");
}
