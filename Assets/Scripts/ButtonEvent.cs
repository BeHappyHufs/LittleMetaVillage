using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ButtonEvent : MonoBehaviour
{
    //resource에서 태그를 통해 Player게임 오브젝트를 가져온다
    public GameObject player;

    // 그 게임 오브제트에 해당하는 PlayerScript를 연동
    public PlayerScript batcontrol2;

      
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        batcontrol2 = player.GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LeftBtnDown()
    {
        batcontrol2.LeftMove = true;
    }
    public void LeftBtnUp()
    {
        batcontrol2.LeftMove = false;
    }

    public void RightBtnDown()
    {
        batcontrol2.RightMove = true;
    }

    public void RightBtnUp()
    {
        batcontrol2.RightMove = false;
      
    }

    public void UPBtnDown()
    {
        batcontrol2.UPMove = true;
    }

    public void UPBtnUp()
    {
        batcontrol2.UPMove = false;
    }

    public void DownBtnDown()
    {
        batcontrol2.DownMove = true;
    }
    
    public void DownBtnUp()
    {
        batcontrol2.DownMove = false;
    }

    
}
