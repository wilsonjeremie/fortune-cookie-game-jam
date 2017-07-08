using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HighScoreManager {

    static string SaveFileDirectory = UnityEngine.Application.dataPath + @"\Data";
	    
    public static void WriteToFile()
    {
        if (!Directory.Exists(SaveFileDirectory))
        {
            Directory.CreateDirectory(SaveFileDirectory);
        }
        if (!File.Exists(SaveFileDirectory + @"\HighScore.txt"))
        {
            using (StreamWriter a = new StreamWriter(SaveFileDirectory + @"\HighScore.txt"))
            {
                //Write a default high score if there is none
                a.WriteLine("1000000");
            }
        }
	}
}
