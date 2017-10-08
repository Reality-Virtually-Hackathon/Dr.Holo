using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;
using System;
using System.Linq;


public class PatientSamples : MonoBehaviour {

	public void createPatients ()
    {
        try
        {
            string fileAddress = Directory.GetCurrentDirectory();
            string line;
            StreamReader theReader = new StreamReader(fileAddress, Encoding.Default);
            using (theReader)
            {
                do
                {
                    line = theReader.ReadLine();
                    if (line != null)
                    {
                        //below here is where our stuff would go

                        string[] entries = line.Split(',');
                        if (entries.Length > 0)
                        {                 
                            PatientInfo patient = new PatientInfo();
                            patient.firstName = entries[0];             //first name
                            patient.lastName = entries[1];              //last name
                            int putitin = Int32.Parse(entries[2]);      
                            patient.MRN = putitin;                      //MRN
                            patient.medicalHistory = entries[3];        //medical history
                            patient.medication = entries[4];            //medication
                            patient.treatmentPlan = entries[5];         //treatment plan
                            GetPatients.patients.Add(patient);
                        }
                    }
                }
                while (line != null);
                theReader.Close();
                //return true;
            }
        }
        catch (Exception e)
        {
           Console.WriteLine("{0}\n", e.Message);
           //return false;
        }
    }
		//PatientInfo sam = new PatientInfo();
		//sam.firstName = "sam";
		//sam.lastName = "garcia";
		//sam.MRN = 513425;
		//sam.medicalHistory = "Lactose";
		//sam.medication = "Lactose pills";
		//sam.treatmentPlan = "N/A";
		////sam.profilePics = (Image)Resources.Load("Sam_Face");
		//GetPatients.patients.Add(sam);

		//PatientInfo dennys = new PatientInfo();
		//dennys.firstName = "dennys";
		//dennys.lastName = "pelegrin";
		//dennys.MRN = 748028;
		//dennys.medicalHistory = "N/A";
		//dennys.medication = "N/A";
		//dennys.treatmentPlan = "Healthy";
		////dennys.profilePics = (Image)Resources.Load("Sam_Face");
		//GetPatients.patients.Add(dennys);

		//PatientInfo alec = new PatientInfo();
		//alec.firstName = "alec";
		//alec.lastName = "hoffmann";
		//alec.MRN = 589248;
		//alec.medicalHistory = "Asthma";
		//alec.medication = "Inhaler";
		//alec.treatmentPlan = "N/A";
		////alec.profilePics = (Image)Resources.Load("Sam_Face");
		//GetPatients.patients.Add(alec);

		//PatientInfo abel = new PatientInfo();
		//abel.firstName = "abel";
		//abel.lastName = "paguio";
		//abel.MRN = 830473;
		//abel.medicalHistory = "high blood pressure";
		//abel.medication = "pills";
		//abel.treatmentPlan = "healthy foods";
		////abel.profilePics = (Image)Resources.Load("Sam_Face");
		//GetPatients.patients.Add(abel);

		//PatientInfo juliet = new PatientInfo();
		//juliet.firstName = "juliet";
		//juliet.lastName = "dibs";
		//juliet.MRN = 513425;
		//juliet.medicalHistory = "PTSD";
		//juliet.medication = "pills";
		//juliet.treatmentPlan = "therapy";
		////juliet.profilePics = (Image)Resources.Load("Sam_Face");
        

}

