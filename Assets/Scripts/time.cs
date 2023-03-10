using UnityEngine;

public class time : MonoBehaviour
{
	public int managetime;

	// Update is called once per frame
	void Update()
	{
		Time.timeScale = managetime;
	}
}
