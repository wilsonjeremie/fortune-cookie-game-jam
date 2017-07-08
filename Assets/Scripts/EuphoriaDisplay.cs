using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EuphoriaDisplay : MonoBehaviour {

    public GameObject[] smilies;
    Player player;
    GameObject activeSmiley;

	void Start () {
        player = FindObjectOfType<Player>();
        InitializeSmileys();
	}
	
	void Update () {
        UpdateSmiley();
	}

    void InitializeSmileys()
    {
        foreach (GameObject smilie in smilies)
        {
            smilie.SetActive(false);
        }
        activeSmiley = smilies[0];
    }

    void UpdateSmiley()
    {
        float euphoria = player.Euphoria;

        if (euphoria == 0f)
        {
            SetSmiley(0);
        }
        else if (euphoria > 0f && euphoria < 0.25f)
        {
            SetSmiley(1);
        }
        else if (euphoria >= 0.25f && euphoria < 0.5f)
        {
            SetSmiley(2);
        }
        else if (euphoria >= 0.5f && euphoria < 0.75f)
        {
            SetSmiley(3);
        }
        else if (euphoria >= 0.75f && euphoria < 1f)
        {
            SetSmiley(4);
        }
        else if (euphoria == 1f)
        {
            SetSmiley(5);
        }
    }

    void SetSmiley(int index)
    {
        activeSmiley.SetActive(false);
        activeSmiley = smilies[index];
        activeSmiley.SetActive(true);
    }
}
