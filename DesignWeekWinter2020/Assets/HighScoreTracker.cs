using UnityEngine;
using UnityEditor;
using System.IO;
using UnityEngine.UI;

public class HighScoreTracker : MonoBehaviour {

    string fileName;
    public Text display;
    //List<float> scores;
    string[] lines;
    public string stringToEdit = "Enter your Name";
    public Text letter1;
    public Text letter2;
    public Text letter3;
    public Text letter4;
    public Text letter5;
    public GameObject end;
    public float score;

    enum letter { L1, L2, L3, L4, L5, End };
    letter currentLetter;
    Text currentSpot;

    GUIStyle style = new GUIStyle();
    GUIContent content;
    public string[] letters;

    void Start()    
{
        
        currentLetter = letter.L1;
        currentSpot = letter1;
        //content = new GUIContent();

        //style.alignment = TextAnchor.MiddleCenter;
        

        fileName = "highscore.txt";
    var sr = new StreamReader("Assets/Resources/" + fileName);
    var fileContents = sr.ReadToEnd();
    sr.Close();

    //Dictionary<string, float> badguys = new Dictionary<string, float>();
    lines = fileContents.Split("\n"[0]);
    //    lines[-1].Remove();
    float highest = 0;
    float[] scores = new float[lines.Length];
    var holder = new string[lines.Length];
        //List<float> scores = new List<float>();
        int index = 0;

        foreach (string line in lines)
        {

            scores[index] = (float.Parse(line.Split(": "[1])[1]));

            if (scores[index] > highest)
            {
                highest = scores[index];

            }

            if (index == 0)
            {
                holder[0] = lines[0];
            }

            for (int i = 0; i != index; i++)
            {
                print("i: " + i + " | " + index);
                print(float.Parse(holder[i].Split(": "[1])[1]));
                //if (scores[index] > float.Parse(holder[0].Split(": "[1])[1]))
                {
                    if (holder[i] != null)
                    {
                        if (scores[index] > float.Parse(holder[i].Split(": "[1])[1]))
                        {
                            int temp = i;

                            for (int q = index - i; q > 0; q--)
                            {
                                // print("q: "+q);
                                print("q: " +q+ "vs i: "+ i);
                                if (i < q)
                                {
                                    holder[q] = holder[q - i];
                                i++;
                                }
                                
                            }
                            //holder[index] = holder[i];
                            holder[i] = lines[index];
                            break;
                        }
                        else
                        {
                            holder[index] = lines[index];

                        }

                    }
                    //else if (lines[index] != holder[0])
                    
                    print("new: "+holder[i]);        
                }
                //else
                {
                    
                    
                }
            }

            print(holder[0]);

            //print(line);
            index++;
        }
        foreach (string line in holder)
        {
            display.text += line + "\n";
        }
        print(holder[3]);
    }
    private void Update()
    {
        if (currentLetter != letter.End)
        {
            MakeName();
        }
    }

    void AddScore()
    {
        var name = File.CreateText(fileName);
        name.WriteLine(stringToEdit+": "+score);
    }

    Text NextLetter(letter current)
    {

        Text next = letter1;

        if (current == letter.L1)
        {
            currentLetter = letter.L2;
            next = letter2;
        }
        else if (current == letter.L2)
        {
            currentLetter = letter.L3;
            next = letter3;
        }
        else if (current == letter.L3)
        {
            currentLetter = letter.L4;
            next = letter4;
        }
        else if (current == letter.L4)
        {
            currentLetter = letter.L5;
            next = letter5;
        }
        else if (current == letter.L5)
        {
            //end
            //replay
            currentLetter = letter.End;
            next = null;
            stringToEdit = (letter1.text + letter2.text + letter3.text + letter4.text + letter5.text);
        }
        return next;
    }

    public void MakeName()
    {
        //content = new GUIContent("This is a box", BoxTexture, "This is a tooltip");

            if (Input.GetButtonDown("Fire1"))
            {
                currentSpot = NextLetter(currentLetter);
            }

        if (currentSpot == null)
        {

            end.SetActive(true);

        }
        else
        {
            currentSpot.text = letters[Random.Range(0, 26)];
        }
        
   
        /*
        GUI.Box(letter1.rectTransform.rect, letters[Random.Range(0, 26)]);
        GUI.Box(letter2.rectTransform.rect, letters[Random.Range(0, 26)]);
        GUI.Box(letter3.rectTransform.rect, letters[Random.Range(0, 26)]);
        GUI.Box(letter4.rectTransform.rect, letters[Random.Range(0, 26)]);
        GUI.Box(letter5.rectTransform.rect, letters[Random.Range(0, 26)]);
        */
        // if ()
    }
}
