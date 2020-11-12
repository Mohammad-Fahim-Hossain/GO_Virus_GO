using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject Player;
    public GameObject GameOverPlaner;
    public GameObject ScoreText;
    public GameObject HealthBar;

    public void ContinueGame()
    {
        GameManager.Instance.StopDesObject();
        VaccineBonusSpawner.VaccineBonusSpawnerInstance.StartVaccineBonusSpawning();
        VaccineSpawner.VaccineSpawnerInstance.StartVaccineSpawning();
        EnemySpawner.EnemySpawnerInstance.StartSpawning();
        LifeSpawner.LifeSpawnerInstance.StopLifeSpawning();
        ShieldSpawner.ShieldSpawnerInstance.StartShieldSpawning();

        GameManager.playerHealth = 100;
        GameManager.Instance.IsOver = false;
        GameManager.Score = GameManager.Instance.TempScore;

        Instantiate(Player, new Vector2(0, -3.282402f), Quaternion.identity);
        ScoreText.SetActive(true);
        HealthBar.SetActive(true);

        GameOverPlaner.SetActive(false);

    }
}
