using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HighScoreManager {

    static string SaveFileDirectory = UnityEngine.Application.dataPath + @"\Data";
    static int defaultHighScore = 1000;
    public static int HighScore;

    static HighScoreManager()
    {
        HighScore = 0;
    }
	    
    public static void CheckFile()
    {
        if (!Directory.Exists(SaveFileDirectory))
        {
            Directory.CreateDirectory(SaveFileDirectory);
        }
        if (!File.Exists(SaveFileDirectory + @"\HighScore.txt"))
        {
            using (StreamWriter writer = new StreamWriter(SaveFileDirectory + @"\HighScore.txt"))
            {
                //Write a default high score if there is none
                writer.WriteLine(defaultHighScore.ToString());
            }
        }
	}

    public static void GetHighScore()
    {
        if (File.Exists(SaveFileDirectory + @"\HighScore.txt"))
        {
            using (StreamReader reader = new StreamReader(SaveFileDirectory + @"\HighScore.txt"))
            {
                //Write a default high score if there is none
                string str = reader.ReadLine();
                HighScore = int.Parse(str);
            }
        }
    }

    public static void SaveHighScore()
    {
        using (StreamWriter writer = new StreamWriter(SaveFileDirectory + @"\HighScore.txt"))
        {
            //Write a default high score if there is none
            writer.WriteLine(HighScore.ToString());
        }
    }
}
