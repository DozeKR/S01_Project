using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    // 플레이어 Hp
    int health = 4;

    // 점수
    int score = 0;

    // hp Bar 객체
    public HpBar hpBar;

    // 플레이어 컨트롤 변수
    public PlayerAction playerAction;

    // 게임오버 텍스트 변수
    public Text gameoverText;

    // Private 기본생성자 : sigleton
    private GameManager() { }

    // 인스턴스 변수 생성 : sigleton
    private static GameManager instance = null;

    void Awake()
    {
        // 게임 오브젝트 생성 시 객체생성.
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
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

    void update()
    {
        scoreUpdate();

        if (Input.GetKeyDown(KeyCode.R))
        {
            restart();
        }
    }

    public void hpDown()
    {

        if (health > 0)
        {
            // Hp 감소 및 hpBar 갱신
            hpBar.setHp(--health);
        }
        else
        {
            // Hp 감소 및 hpBar 갱신
            hpBar.setHp(--health);
            // 플레이어의 사망 스크립트 수행(애니메이션 재생)
            
            // 게임오버, 점수 UI 적용
            gameoverText.gameObject.SetActive(true);
            // 다시 시작 UI 적용

        }

    }

    // 점수 갱신 메서드 : 시간에 따라 점수 증가 및 UI 표시
    void scoreUpdate()
    {

    }

    // 게임 재시작 메서드 : 플레이어 사망 후 특정 조작을 통해 게임 재시작 : R키
    void restart()
    {

    }

}