using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SetClock : MonoBehaviour
{
    float hoursToDegrees = -30f, minutesToDegrees = -6f, secondsToDegrees = -6f;
    
    [SerializeField]
	Transform hoursPivot, minutesPivot, secondsPivot, pin;
 
    string oldSeconds;
    public float speed = 10f;
    int currentPositionIndex = 0;
    private Vector3 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
    targetPosition = transform.position;
    string seconds = System.DateTime.UtcNow.ToString("ss");
    print (seconds); 

    if(seconds != oldSeconds) 
        {
        UpdateTimer ();
        }
    oldSeconds = seconds; 
    }
    void UpdateTimer ()
    { 
        int secondsInt = int.Parse(System.DateTime.UtcNow.ToString("ss")); 
        int minutesInt = int.Parse(System.DateTime.UtcNow.ToString("mm"));
        int hoursInt = int.Parse(System.DateTime.UtcNow.ToLocalTime().ToString("hh"));
        print(hoursInt + " : " + minutesInt + " : "+ secondsInt);

    }
    // Update is called once per frame
    void Update()
    {
      TimeSpan time = DateTime.Now.TimeOfDay;
		hoursPivot.localRotation =
			Quaternion.Euler(0f, 0f, hoursToDegrees * (float)time.TotalHours);
		minutesPivot.localRotation =
			Quaternion.Euler(0f, 0f, minutesToDegrees * (float)time.TotalMinutes);
		secondsPivot.localRotation =
			Quaternion.Euler(0f, 0f, secondsToDegrees * (float)time.TotalSeconds);  
        if (transform.position != targetPosition)
        { 
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
        
    }

   
}
