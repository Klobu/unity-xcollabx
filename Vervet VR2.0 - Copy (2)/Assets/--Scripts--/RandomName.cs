using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RandomName : MonoBehaviour
{
    public PhotonView view;
    public TextMeshPro text;

    private void Start()
    {
        if (view.IsMine)
        {
            if (text.text == "")
            {
                text.text = "MONKEY" + Random.Range(1000, 9999);
            }
        }
    }
}
