using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StudentDataManager1 : MonoBehaviour
{
    public InputField nameInput;
    public InputField ageInput;
    public InputField studentNumberInput;
    public InputField studentSection;

    public InputField searchInput;

    public Text resultText;

    //save student data
    public void SaveStudentData()
    {
        string studentName = nameInput.text;
        int age;
        int studentNumber;
        string Section = studentSection.text;
        //check if fields are not empty and parse values
        if (!string.IsNullOrEmpty(studentName) &&
            int.TryParse(ageInput.text, out age) &&
             int.TryParse(studentNumberInput.text, out age) &&
              int.TryParse(studentSection.text, out age))
        {
            //save data in playerprefs
            PlayerPrefs.SetInt(studentName + "Age", age);
            PlayerPrefs.SetInt(studentName + "StudentNumber", studentNumber);
            PlayerPrefs.SetString(studentName + "StudentSection", Section);
            PlayerPrefs.Save();
            Debug.Log("Student Data Saved: " + studentName);
        }
        else
        {
            Debug.Log("InvalidInput");
        }
    }

    //loading for student data
    public void LoadStudentData()
    {
        string studentName = searchInput.text;
        if (PlayerPrefs.HasKey(studentName + "Age"))
        {
            int age = PlayerPrefs.GetInt(studentName + "Age");
            int studenNumber = PlayerPrefs.GetInt(studentName + "StudentNumber");
            string Section = PlayerPrefs.GetString(studentName + "Student Section");

            resultText.text = $"Name: {studentName}\nAge: {age}\nSN: {studentNumber}\nSection: {Section}m";
        }
        else
        {
            resultText.text = "Student not found";
        }
    }
}
