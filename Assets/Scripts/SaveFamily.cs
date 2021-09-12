using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveFamily : MonoBehaviour
{
    public Button yes;
	public Button no;

	GameObject player;

	// Start is called before the first frame update
    void Start()
    {
		player = GameObject.Find("Player");
		yes.onClick.AddListener(Accept);
		no.onClick.AddListener(Refuse);
    }

	void Accept()
	{
		int currHealth = player.gameObject.GetComponent<Character>().GetHealth();
		player.gameObject.GetComponent<Character>().Hit(currHealth/2);
		gameObject.SetActive(false);
		// Pop up 
	}

	void Refuse()
	{
		gameObject.SetActive(false);
		// Pop up
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
