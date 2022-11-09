using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{

    // �÷��̾� Hp
    int health = 4;

    // �ǽð� ���� ǥ�� �ؽ�Ʈ
    public Text scoreText;

    // ����
    float score = 0;

    // �ְ� ���� ǥ�� �ؽ�Ʈ
    public Text bestScoreText;

    // ���� ���� üũ ����
    bool gameover = false;

    public Dictionary<string, int> EnemyScoreByName;

    // hp Bar ��ü
    public HpBar hpBar;

    // �÷��̾� ��Ʈ�� ����
    public PlayerControl playerControl;

    // EnemySpawner ����
    public EnemySpawner enemySpawner;

    // ���ӿ���UI ����
    public Component gameOverUI;

    // Private �⺻������ : sigleton
    private GameManager() { }

    // �ν��Ͻ� ���� ���� : sigleton
    private static GameManager instance = null;
   
    void Start()
    {
        score = 0;
        EnemyScoreByName = new Dictionary<string, int>();
        EnemyScoreByName.Add("Rabbit(Clone)", 10);
        EnemyScoreByName.Add("Wolf(Clone)", 10);
        EnemyScoreByName.Add("Deer(Clone)", 10);
        EnemyScoreByName.Add("Boar(Clone)", 10);
        EnemyScoreByName.Add("Fox(Clone)", 10);
    }

    void Awake()
    {
        // ���� ������Ʈ ���� �� ��ü����.
        if (instance == null)
        {
            instance = this;

        }
    }
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                return null;
            }

            return instance;
        }
    }

    void Update()
    {
        scoreUpdate();

        if (gameover && Input.GetKeyDown(KeyCode.R))
        {
            restart();
        }
        else if (!gameover)
        {
            scoreUpdate();
        }
    }

    public void hpDown()
    {

        if (health > 1)
        {
            // Hp ���� �� hpBar ����
            hpBar.setHp(--health);
        }
        else
        {
            // Hp ���� �� hpBar ����
            hpBar.setHp(--health);

            endGame();

        }

    }

    // ���� ���� �޼��� : �ð��� ���� ���� ���� �� UI ǥ��
    void scoreUpdate()
    {
        if (!gameover)
        {
            score += Time.deltaTime;
            scoreText.text = "Score: " + (int)score;
        }
      
    }

    public void endGame()
    {
        // �÷��̾��� ��� ��ũ��Ʈ ����(�ִϸ��̼� ���)
        playerControl.die();

        // EnemySpawner ����
        enemySpawner.gameover();

        // ���ӿ���, ���� UI ����
        gameOverUI.gameObject.SetActive(true);

        // ���ӿ��� üũ ��������
        gameover = true;

        //"BestScore" Ű�� ����Ǿ��ִ� �ְ����� ��������
        float bestScore = PlayerPrefs.GetFloat("BestScore");

        // �ְ����� �������� ���
        if (score > bestScore)
        {
            // �ְ��� ���� ���� ������� ����
            bestScore = score;
            // "BestScore" Ű�� �ְ����� ����
            PlayerPrefs.SetFloat("BestScore", bestScore);
        }
        // �ְ��� ǥ��
        bestScoreText.text = "Best Score: " + (int)bestScore;
    }

    // �� ��ü�� ���� ���� �ٸ��� �߰�
    public void scoreUp(string name)
    {
        score += EnemyScoreByName[name];
        scoreText.text = "Score: " + (int)score;
    }

    // ���� ����� �޼��� : �÷��̾� ��� �� Ư�� ������ ���� ���� ����� : RŰ
    public void restart()
    {
      
        SceneManager.LoadScene("MainMenu");
    }


}