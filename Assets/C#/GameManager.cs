using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    // �÷��̾� Hp
    int health = 4;

    // ����
    int score = 0;

    // hp Bar ��ü
    public HpBar hpBar;

    // �÷��̾� ��Ʈ�� ����
    public PlayerAction playerAction;

    // ���ӿ��� �ؽ�Ʈ ����
    public Text gameoverText;

    // Private �⺻������ : sigleton
    private GameManager() { }

    // �ν��Ͻ� ���� ���� : sigleton
    private static GameManager instance = null;

    void Awake()
    {
        // ���� ������Ʈ ���� �� ��ü����.
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
            // Hp ���� �� hpBar ����
            hpBar.setHp(--health);
        }
        else
        {
            // Hp ���� �� hpBar ����
            hpBar.setHp(--health);
            // �÷��̾��� ��� ��ũ��Ʈ ����(�ִϸ��̼� ���)
            
            // ���ӿ���, ���� UI ����
            gameoverText.gameObject.SetActive(true);
            // �ٽ� ���� UI ����

        }

    }

    // ���� ���� �޼��� : �ð��� ���� ���� ���� �� UI ǥ��
    void scoreUpdate()
    {

    }

    // ���� ����� �޼��� : �÷��̾� ��� �� Ư�� ������ ���� ���� ����� : RŰ
    void restart()
    {

    }

}