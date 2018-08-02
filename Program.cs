
using ConsoleApp4.Application.Interface;
using ConsoleApp4.Domain.CommonType;
using ConsoleApp4.Domain.CommonType.Metiers;
using ConsoleApp4.Domain.Entites;
using ConsoleApp4.Tables;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ConsoleApp4
{
	public class Program
	{
		public static void Main(string[] args)
		{


			XmlDocument doc = new XmlDocument();
			doc.Load("C:\\Users\\CameleaOUARKOUB\\Pictures\\document.xml");
			//doc.Load("C:\\Users\\CameleaOUARKOUB\\Desktop\\document.xml");


			
			XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
			nsmgr.AddNamespace("wpc", "http://schemas.microsoft.com/office/word/2010/wordprocessingCanvas");
			nsmgr.AddNamespace("cx", "http://schemas.microsoft.com/office/drawing/2014/chartex");
			nsmgr.AddNamespace("cx1", "http://schemas.microsoft.com/office/drawing/2015/9/8/chartex");
			nsmgr.AddNamespace("cx2", "http://schemas.microsoft.com/office/drawing/2015/10/21/chartex");
			nsmgr.AddNamespace("cx3", "http://schemas.microsoft.com/office/drawing/2016/5/9/chartex");
			nsmgr.AddNamespace("cx4", "http://schemas.microsoft.com/office/drawing/2016/5/10/chartex");
			nsmgr.AddNamespace("cx5", "http://schemas.microsoft.com/office/drawing/2016/5/11/chartex");
			nsmgr.AddNamespace("cx6", "http://schemas.microsoft.com/office/drawing/2016/5/12/chartex");
			nsmgr.AddNamespace("cx7", "http://schemas.microsoft.com/office/drawing/2016/5/13/chartex");
			nsmgr.AddNamespace("cx8", "http://schemas.microsoft.com/office/drawing/2016/5/14/chartex");
			nsmgr.AddNamespace("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
			nsmgr.AddNamespace("aink", "http://schemas.microsoft.com/office/drawing/2016/ink");
			nsmgr.AddNamespace("am3d", "http://schemas.microsoft.com/office/drawing/2017/model3d");
			nsmgr.AddNamespace("o", "urn:schemas-microsoft-com:office:office");
			nsmgr.AddNamespace("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
			nsmgr.AddNamespace("m", "http://schemas.openxmlformats.org/officeDocument/2006/math");
			nsmgr.AddNamespace("v", "urn:schemas-microsoft-com:vml");
			nsmgr.AddNamespace("wp14", "http://schemas.microsoft.com/office/word/2010/wordprocessingDrawing");
			nsmgr.AddNamespace("wp", "http://schemas.openxmlformats.org/drawingml/2006/wordprocessingDrawing");
			nsmgr.AddNamespace("w10", "urn:schemas-microsoft-com:office:word");
			nsmgr.AddNamespace("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
			nsmgr.AddNamespace("w14", "http://schemas.microsoft.com/office/word/2010/wordml");
			nsmgr.AddNamespace("w15", "http://schemas.microsoft.com/office/word/2012/wordml");
			nsmgr.AddNamespace("w16se", "http://schemas.microsoft.com/office/word/2015/wordml/symex");
			nsmgr.AddNamespace("wpg", "http://schemas.microsoft.com/office/word/2010/wordprocessingGroup");
			nsmgr.AddNamespace("wpi", "http://schemas.microsoft.com/office/word/2010/wordprocessingInk");
			nsmgr.AddNamespace("wne", "http://schemas.microsoft.com/office/word/2006/wordml");
			nsmgr.AddNamespace("wps", "http://schemas.microsoft.com/office/word/2010/wordprocessingShape");
			nsmgr.AddNamespace("mc: Ignorable", "w14 w15 w16se wp14");

			#region Test Table 

			//var sequences = ConstructeurInitialisation.GetDescriptionContrainteInitialisation(doc, nsmgr);
			//List<string> resultat = sequences;
			//foreach (string y in resultat)
			//{

			//	Console.WriteLine(y.ToString());

			//}

			////#region TestTable 
			//var sequences = Table.Tables(doc, nsmgr);
			//List<Table> resultat = sequences;
			//foreach (Table y in resultat)
			//{
			//	foreach (Donnee c in y.Donnees) {
			//		Console.WriteLine(c.ToString());

			//	}
			//}



			//Console.ReadKey();

			#endregion

			#region Test Service Externe 

			//var proprietes = ServiceExterne.ServicesExternes(doc, nsmgr);
			//List<ServiceExterne> resultat1 = proprietes;
			//foreach (ServiceExterne lp in resultat1)

			//{

			//	Console.WriteLine(lp.ToString());

			//}
			//Console.ReadKey();
			#region Test proprietes services externes 
			//var i = 2;
			//var proprietes = Propriete.ProprietesServicesExternes(doc, nsmgr,i);
			//List<Propriete> resultat1 = proprietes;
			//foreach (Propriete lp in resultat1)

			//{

			//	Console.WriteLine(lp.ToString());

			//}
			#endregion


			//Console.ReadKey();

			#endregion

			#region Test Metier 

			//var proprietes = Metier.Metiers(doc, nsmgr);
			//List<Metier> resultat1 = proprietes;
			//foreach (Metier lp in resultat1)

			//{

			//	Console.WriteLine(lp.ToString());

			//}
			//Console.ReadKey();

			#region Test proprietes metier  
			//var i = 2;
			//var proprietes = Propriete.ProprietesMetier(doc, nsmgr, i);
			//List<Propriete> resultat1 = proprietes;
			//foreach (Propriete lp in resultat1)

			//{

			//	Console.WriteLine(lp.ToString());

			//}
			//Console.ReadKey();
			#endregion

			#endregion

			#region Test Enumerations

			//var proprietes = Enumeration.Enumerations(doc, nsmgr);
			//List<Enumeration> resultat1 = proprietes;
			//foreach (Enumeration lp in resultat1)

			//{

			//	Console.WriteLine(lp.ToString());

			//}
			//Console.ReadKey();

			#region Test proprietes enumerations  
			//var i = 2;
			//var proprietes = Propriete.ValeursEnumeration(doc, nsmgr, i);
			//List<Propriete> resultat1 = proprietes;
			//foreach (Propriete lp in resultat1)

			//{

			//	Console.WriteLine(lp.ToString());

			//}
			//Console.ReadKey();
			#endregion

			#endregion

			#region Interfaces Services 

			//var proprietes =TypeRetourInterfaceService.TypesRetourInterfacesServices(doc, nsmgr);
			//List<List<TypeRetourInterfaceService>> resultat1 = proprietes;

			//foreach (List<TypeRetourInterfaceService> lp in resultat1)

			//{
			//	Console.WriteLine("nouvelle liste");
			//	foreach (TypeRetourInterfaceService p in lp)
			//	{

			//		Console.WriteLine(p.ToString());

			//	}
			//}



			//Console.ReadKey();

			//var proprietes = InterfaceService.InterfacesService(doc, nsmgr);
			//List<InterfaceService> resultat1 = proprietes;

			//foreach (InterfaceService lp in resultat1)

			//{
			//	Console.WriteLine("nouvelle liste");
			//	Console.WriteLine(lp.ToString());


			//}



			//Console.ReadKey();

			#endregion

			#region Parametes entrants 

			//var proprietes = ParametreEntrant.ParametresEntrantsMethodesClasses(doc, nsmgr);
			//List<List<ParametreEntrant>> resultat1 = proprietes;

			//foreach (List<ParametreEntrant> lp in resultat1)

			//{
			//	Console.WriteLine("nouvelle liste");
			//	foreach (ParametreEntrant p in lp)
			//	{

			//		Console.WriteLine(p.ToString());

			//	}
			//}
			//Console.ReadKey();



			#endregion

			#region Parametres Sortants


			//var proprietes = ParametreSortant.ParametresSortantsMethodesClasses(doc, nsmgr);
			//List<List<ParametreSortant>> resultat1 = proprietes;

			//foreach (List<ParametreSortant> lp in resultat1)

			//{
			//	Console.WriteLine("nouvelle liste");
			//	foreach (ParametreSortant p in lp)
			//	{

			//		Console.WriteLine(p.ToString());

			//	}
			//}
			//Console.ReadKey();






			#endregion


			#region Test Methode

			//var proprietes = Methode.Methodes(doc, nsmgr);
			//List<List<Methode>> resultat1 = proprietes;

			//foreach (List<Methode> lp in resultat1)

			//{
			//	Console.WriteLine("nouvelle liste");
			//	foreach (Methode p in lp)
			//	{
			//		Console.WriteLine("nouvelle prop");
			//		Console.WriteLine(p.ToString());

			//	}
			//}



			//Console.ReadKey();

			#endregion

			#region Methodes Entités 

			//var proprietes = Methode.AlgorithmesMethodesEntites(doc, nsmgr);
			//List<List<string>> resultat1 = proprietes;

			//foreach (List<string> lp in resultat1)

			//{
			//	Console.WriteLine("nouvelle liste");
			//	foreach (string p in lp)
			//	{

			//		Console.WriteLine(p.ToString());

			//	}
			//}
			//Console.ReadKey();

			#endregion


			#region Test proprietes entite  
			//var i = 1;
			//var proprietes = Propriete.Proprietes(doc, nsmgr, i);
			//List<Propriete> resultat1 = proprietes;
			//foreach (Propriete lp in resultat1)

			//{

			//	Console.WriteLine(lp.ToString());

			//}
			//Console.ReadKey();
			

		{
				 Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "enumerations"));


				foreach (Enumeration e in Enumeration.Enumerations(doc, nsmgr))
				{
					string chemin = @"C:\Users\CameleaOUARKOUB\Desktop\enumerations\" + e.Nom.Trim() + ".cs"; 
					FileStream stream = new FileStream(chemin, FileMode.Append, FileAccess.Write);
					StreamWriter writer = new StreamWriter(stream);
					using (writer)
					writer.WriteLine(e.ToString());
					writer.Close();
				}
			}
				
			}
			




			#endregion
		}
	}


