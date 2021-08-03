/*
 * Created by SharpDevelop.
 * User: TheRedLord
 * Date: 9/28/2018
 * Time: 9:32 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MoveIt
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		String tip;
		String TirRemeber;
		String Descriere;
		String PleacaTir;
		String PleacaTir1;
		String PleacaTir2;
		String numeRe;
		String uploadFile;
		String directory;
		String FilePath;
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		public String Generate(String Filename)
		{
			String[] separated = Filename.Split('_');
            String id = separated[0];
            String TipOperatie = separated[6];
            String TipOperatieSecundara = separated[2];
            String Palet = separated[2];
			String sDate = DateTime.Now.ToString();
			DateTime datevalue = (Convert.ToDateTime(sDate.ToString()));
			String ReturnThis="";
			String dy = datevalue.Day.ToString();
			String mn = datevalue.Month.ToString();
			String YYYY = datevalue.Year.ToString();
			String yearStamp = YYYY;
            String monthStamp = mn;
            String dayStamp = dy;
            if (separated[6].Contains("ambalare")) {
                if (separated[3].Contains("Tir") == true) {
                    tip = "6";
                    TirRemeber = separated[2];
                    Descriere = separated[3];
                    //1678--Tir -1-ac North-leeds+Black Light 1678-2016-02-03--13.38.32
                    PleacaTir = separated[3];
                    PleacaTir1 = separated[4];
                    PleacaTir2 = separated[5];
                    numeRe = Filename;
                    uploadFile = FilePath;
                    directory = yearStamp + "/pozeSoft/" + monthStamp + "/ambalare/" + id;
                    //
                   

                }else {
                    if (separated[2].Contains("Palet") == true) {
                        tip = "7";
                        Descriere = separated[3];

                        //1678--Tir -1-ac North-leeds+Black Light 1678-2016-02-03--13.38.32
                        PleacaTir = separated[3];
                        PleacaTir1 = separated[4];
                        PleacaTir2 = separated[5];
                        String idTir = separated[7];
                        numeRe = Filename;
                        uploadFile = FilePath;
                        directory = yearStamp + "/pozeSoft/" + monthStamp + "/ambalare/" + idTir + "/paleti/" + Palet;
                        //
                    }
                }
            }else{
            if (separated[6].Contains("calitate")) {
                if (separated[6].Contains("montaj") == true) {
                    tip = "10";
                    TirRemeber = separated[2];
                    Descriere = separated[3];
                    //1678--Tir -1-ac North-leeds+Black Light 1678-2016-02-03--13.38.32
                    PleacaTir = separated[3];
                    PleacaTir1 = separated[4];
                    PleacaTir2 = separated[5];
                    String idTir = separated[7];
                    numeRe = Filename;
                    uploadFile = FilePath;
                    directory = yearStamp + "/pozeSoft/" + monthStamp + "/calitate/montaj/" + dayStamp + "/" + idTir;
                    //
                }else {
                    if (separated[6].Contains("serie-unica") == true) {
                        tip = "10";
                        TirRemeber = separated[2];
                        Descriere = separated[3];
                        //1678--Tir -1-ac North-leeds+Black Light 1678-2016-02-03--13.38.32
                        PleacaTir = separated[3];
                        PleacaTir1 = separated[4];
                        PleacaTir2 = separated[5];
                        String idTir = separated[7];
                        numeRe = Filename;
                        uploadFile = FilePath;
                        directory = yearStamp + "/pozeSoft/" + monthStamp + "/calitate/serie unica/" + idTir;
                        //
                    }
                }
            }else{

            if (separated[6].Contains("magazie")) {
                if (separated[6].Contains("incarcare") == true) {
                    tip = "10";
                    TirRemeber = separated[2];
                    Descriere = separated[3];
                    //1678--Tir -1-ac North-leeds+Black Light 1678-2016-02-03--13.38.32
                    PleacaTir = separated[3];
                    PleacaTir1 = separated[4];
                    PleacaTir2 = separated[5];
                    String idTir = separated[7];
                    numeRe = Filename;
                    uploadFile = FilePath;
                    directory = yearStamp + "/pozeSoft/" + monthStamp + "/ambalare/" + separated[0] + "/incarcare";
                    //
                }else {
                    if (separated[6].Contains("magaziea") == true) {
                        tip = "10";
                        TirRemeber = separated[2];
                        Descriere = separated[3];
                        //1678--Tir -1-ac North-leeds+Black Light 1678-2016-02-03--13.38.32
                        PleacaTir = separated[3];
                        PleacaTir1 = separated[4];
                        PleacaTir2 = separated[5];
                        String idTir = separated[7];
                        numeRe = Filename;
                        uploadFile = FilePath;
                        directory = yearStamp + "/pozeSoft/" + monthStamp + "/magazie/" + dayStamp + "/" + idTir;
                        //
                    }
                }
            }}}
            
            
            ReturnThis=directory;
            return ReturnThis;
		}
		void Button1Click(object sender, EventArgs e)
		{
	using(var fbd = new FolderBrowserDialog())
{
    DialogResult result = fbd.ShowDialog();

    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
    {
		DirectoryInfo d = new DirectoryInfo(fbd.SelectedPath);//Assuming Test is your Folder
FileInfo[] Files = d.GetFiles(); //Getting Text files
string str = "";
foreach(FileInfo file in Files )
{
	try{
  str = str + ", " + file.Name;
  String directoryNew=Generate(file.Name);
  String FinalDestination="D:\\Truck photos\\"+directory;
  String FinalDest2=FinalDestination.Replace("/", "\\");
  String CopyThis=file.FullName;
  System.IO.FileInfo fileDirectory = new System.IO.FileInfo(FinalDest2);
  fileDirectory.Directory.Create(); // If the directory already exists, this method does nothing.
  File.Copy(CopyThis, FinalDest2+file.Name);
	}catch(Exception ea)
	{
		
	}
  
  
  
  
}
        
    }
}
		}
	}
}
