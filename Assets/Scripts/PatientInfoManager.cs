using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class PatientInfoManager : MonoBehaviour {
    public string patientDataFilename = "patient data.json";
    public bool addPatientInfo = false;
    public bool writePatientInfo = false;

    public Image[] imageUIs;
    public Text historyUI; ///TODO: pop up window
	public Text medicationsUI; ///TODO: pop up window
	public Image profilePicUI;
    public Text treatmentPlanUI;
    public Text patientNameUI;
    public Text mrnUI;

    public List<PatientInfo> patientInfos;

	void Start () {
        patientInfos = new List<PatientInfo>();
        LoadPatientInfo();
        if(patientInfos.Count > 0)
        {
            DisplayPatientInfo(0);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (addPatientInfo)
        {
            addPatientInfo = false;
            AddPatientData();
        }
        if (writePatientInfo)
        {
            writePatientInfo = false;
            WritePatientData();
        }
	}

    private void AddPatientData()
    {
        PatientInfo newInfo = new PatientInfo();
        newInfo.firstName = patientNameUI.text.Split(' ')[0];
        newInfo.lastName = patientNameUI.text.Split(' ')[1];
        newInfo.medicalHistory = historyUI.text;
        newInfo.medication = medicationsUI.text;
        newInfo.MRN = int.Parse(mrnUI.text);
        newInfo.profileSprite = profilePicUI.sprite;
        newInfo.treatmentPlan = treatmentPlanUI.text;
        newInfo.encodedImg = System.Convert.ToBase64String(profilePicUI.sprite.texture.EncodeToJPG());

        patientInfos.Add(newInfo);
        Debug.Log("Added patient info:\r\n" + newInfo.ToString());
    }

    private void WritePatientData()
    {
        PatientInfoSet patInfoSet = new PatientInfoSet(patientInfos);
        string patientDataString = JsonUtility.ToJson(patInfoSet);
        FileInfo dataFile = GetDataFile();
        Stream fileStream = new FileStream(dataFile.FullName, FileMode.OpenOrCreate, FileAccess.Write);
        fileStream.SetLength(0);
        StreamWriter writter = new StreamWriter(fileStream);
        writter.Write(patientDataString);
        Debug.Log("Wrote patient infos (" + patientInfos.Count + ") to " + dataFile.FullName);
        writter.Dispose();
        fileStream.Dispose();
    }

    private FileInfo GetDataFile()
    {
        //string fileAddress = Directory.GetCurrentDirectory();
        string fileAddress = Path.Combine(Directory.GetCurrentDirectory(), patientDataFilename);
        //fileAddress += "//ReadWriteTest.txt";
        //fileAddress += Path.VolumeSeparatorChar + patientDataFilename;
        if (!File.Exists(fileAddress))
        {
            File.Create(fileAddress);
        }
        return new FileInfo(fileAddress);
    }

    private void LoadPatientInfo()
    {
        string fileAddress = GetDataFile().FullName;
        //Stream fileStream = new FileStream(fileAddress, FileMode.Open, FileAccess.Read);
        //StreamReader reader = new StreamReader(fileStream);
        StreamReader reader = new StreamReader(fileAddress);
        string dataString = reader.ReadToEnd();
        reader.Dispose();
        //fileStream.Dispose();
        PatientInfoSet pis = JsonUtility.FromJson<PatientInfoSet>(dataString);
        if(pis == null)
        {
            return;
        }
        List<PatientInfo> newPatientInfos = pis.patientInfos;
        if(newPatientInfos != null)
        {
            patientInfos.AddRange(newPatientInfos);
        }
    }

    public void DisplayPatientInfo(int index)
    {
        Debug.Log("Displaying patient " + index + " info.");
        if(index < 0 || index >= patientInfos.Count)
        {
            return;
        }
        historyUI.text = patientInfos[index].medicalHistory;
        medicationsUI.text = patientInfos[index].medication;
        treatmentPlanUI.text = patientInfos[index].treatmentPlan;
        mrnUI.text = patientInfos[index].MRN.ToString();
        patientNameUI.text = patientInfos[index].firstName + " " + patientInfos[index].lastName;
        //profilePicUI.sprite = patientInfos[index].profileSprite;
        byte[] imgData = System.Convert.FromBase64String(patientInfos[index].encodedImg);
        //Texture2D tex = new Texture2D(profilePicUI.sprite.texture.w)
        ImageConversion.LoadImage(profilePicUI.sprite.texture, imgData);
        Debug.Log("Loaded " + patientInfos.Count + " patient infos");
    }
}
