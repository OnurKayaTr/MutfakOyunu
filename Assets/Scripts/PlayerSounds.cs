using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
   
    private Player player;
    private float footstepTimmer;
    private float footstepTimeMax = .1f;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    private void Update()
    {
        footstepTimmer -= Time.deltaTime;

        if(footstepTimmer < 0f)
        {
            footstepTimmer = footstepTimeMax;
        }
        
        
            //SoundManager.Instance.PlayerFootstepsSound(player.transform.position, 1f);
        
    }
}
