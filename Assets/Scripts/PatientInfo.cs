using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class PatientInfo {

	//Patient Information
	public string firstName;
	public string lastName;
	public int MRN;
	public string medicalHistory;
	public string treatmentPlan;
	public string medication;
	public Sprite profileSprite;
    public string encodedImg;

    public override string ToString()
    {
        string str = "";
        str += firstName + " " + lastName + ":\r\n";
        str += "MRN: " + MRN + "\r\n";
        str += "History: " + medicalHistory + "\r\n";
        str += "Treatment plan: " + treatmentPlan + "\r\n";
        str += "Medication: " + medication + "\r\n";
        str += "Profile pic: " + profileSprite.name;
        return str;
    }
}
	