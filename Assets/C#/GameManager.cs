using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{

    // 플레이어 Hp
    int health = 4;

    // 실시간 점수 표시 텍스트
    public Text scoreText;

    // 점수
    float score = 0;

    // 최고 점수 표시 텍스트
    public Text bestScoreText;

    // 게임 오버 체크 변수
    bool gameover = false;

    public Dictionary<string, int> EnemyScoreByName;

    // hp Bar 객체
    public HpBar hpBar;

    // 플레이어 컨트롤 변수
    public PlayerControl playerControl;

    // EnemySpawner 변수
    public EnemySpawner enemySpawner;

    // 게임오버UI 변수
    public Component gameOverUI;

    // Private 기본생성자 : sigleton
    private GameManager() { }

    // 인스턴스 변수 생성 : sigleton
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
        // 게임 오브젝트 생성 시 객체생성.
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
            // Hp 감소 및 hpBar 갱신
            hpBar.setHp(--health);
        }
        else
        {
            // Hp 감소 및 hpBar 갱신
            hpBar.setHp(--health);

            endGame();

        }

    }

    // 점수 갱신 메서드 : 시간에 따라 점수 증가 및 UI 표시
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
        // 플레이어의 사망 스크립트 수행(애니메이션 재생)
        playerControl.die();

        // EnemySpawner 정지
        enemySpawner.gameover();

        // 게임오버, 점수 UI 적용
        gameOverUI.gameObject.SetActive(true);

        // 게임오버 체크 변수설정
        gameover = true;

        //"BestScore" 키로 저장되어있는 최고기록을 가져오기
        float bestScore = PlayerPrefs.GetFloat("BestScore");

        // 최고기록을 갱신했을 경우
        if (score > bestScore)
        {
            // 최고기록 값을 현재 기록으로 변경
            bestScore = score;
            // "BestScore" 키로 최고기록을 저장
            PlayerPrefs.SetFloat("BestScore", bestScore);
        }
        // 최고기록 표시
        bestScoreText.text = "Best Score: " + (int)bestScore;
    }

    // 적 개체에 따라서 점수 다르게 추가
    public void scoreUp(string name)
    {
        score += EnemyScoreByName[name];
        scoreText.text = "Score: " + (int)score;
    }

    // 게임 재시작 메서드 : 플레이어 사망 후 특정 조작을 통해 게임 재시작 : R키
    public void restart()
    {
      
        SceneManager.LoadScene("MainMenu");
    }


}