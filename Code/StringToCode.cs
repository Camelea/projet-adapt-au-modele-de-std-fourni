using ConsoleApp4.Application.Interface;
using ConsoleApp4.Application.Mappers;
using ConsoleApp4.Application.Services;
using ConsoleApp4.Domain.CommonType;
using ConsoleApp4.Domain.Entites;
using ConsoleApp4.Domain.Interface.De.Registre;
using ConsoleApp4.Domain.InterfaceServiceExterne;
using ConsoleApp4.Domain.Registres;
using ConsoleApp4.Structure.Application.Interface.ObjetPresentation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp4.Code
{
	public class EntiteToCode
	{

		public static void CreateDirectoryOnDesktop(string directoryName)
		{
			Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), directoryName));

		}


		public static void CreerApplication(XmlDocument doc, XmlNamespaceManager nsmgr, string path,string nomProjet) {
		
			var subFolder = path + "\\" + "Application";
			Directory.CreateDirectory(subFolder);
			var mapperFolder = subFolder + "\\" + "Mappers";
			Directory.CreateDirectory(mapperFolder);
			foreach (Mapper m in Mapper.Mappers(doc, nsmgr))
			{
				string chemin = mapperFolder + "\\" + m.Nom.Trim() + ".cs";
				FileStream stream = new FileStream(chemin, FileMode.Append, FileAccess.Write);
				StreamWriter writer = new StreamWriter(stream);
				using (writer)
				writer.WriteLine(" namespace" + " " + nomProjet + ".Application.Services" + "\r\n" + "{" + m.ToString() + "}");

			}

			var serviceFolder = subFolder + "\\" + "Services";
			Directory.CreateDirectory(serviceFolder);
			foreach (Service s in Service.Services(doc, nsmgr))
			{
				string chemin = serviceFolder + "\\" + s.Nom.Trim() + ".cs";
				FileStream stream = new FileStream(chemin, FileMode.Append, FileAccess.Write);
				StreamWriter writer = new StreamWriter(stream);
				using (writer)
					writer.WriteLine(" namespace" + " " + nomProjet + ".Application.Services" + "\r\n" + "{" );
					writer.WriteLine(s.ToString());
				writer.WriteLine("}");
				writer.Close();
			}

		}

		public static void CreerApplicationInterface(XmlDocument doc, XmlNamespaceManager nsmgr, string path, string nomProjet)
		{

			var subFolder = path + "\\" + "Application.Interface";
			Directory.CreateDirectory(subFolder);
			var objetPresentationFolder = subFolder + "\\" + "ObjetsPresentation";
			Directory.CreateDirectory(objetPresentationFolder);
			foreach (MethodeObjetPresentation o in ObjetPresentation.ObjetsPresentation(doc, nsmgr).Methodes)
			{
				string chemin = objetPresentationFolder + "\\" + o.Nom.Trim() + ".cs";
				FileStream stream = new FileStream(chemin, FileMode.Append, FileAccess.Write);
				StreamWriter writer = new StreamWriter(stream);
				using (writer)
					writer.WriteLine(" namespace" + " " + nomProjet + ".Application.Interface.ObjetsPresentation" + "\r\n" + "{");
				writer.WriteLine(o.ToString());
				writer.WriteLine("}");
				writer.Close();
			}

			var interfaceServiceFolder = subFolder + "\\" + "InterfacesServices";
			Directory.CreateDirectory(interfaceServiceFolder);
			foreach (InterfaceService i in InterfaceService.InterfacesService(doc, nsmgr))
			{
				string chemin = interfaceServiceFolder + "\\" + i.Nom.Trim() + ".cs";
				FileStream stream = new FileStream(chemin, FileMode.Append, FileAccess.Write);
				StreamWriter writer = new StreamWriter(stream);
				using (writer)
					writer.WriteLine(" namespace" + " " + nomProjet + ".Application.Interface.InterfacesServices" + "\r\n" + "{");
				writer.WriteLine(i.ToString());
				writer.WriteLine("}");
				writer.Close();
			}

		}

		public static void CreerTables(XmlDocument doc, XmlNamespaceManager nsmgr, string path, string nomProjet)
		{

			var subFolder = path + "\\" + "Tables";
			Directory.CreateDirectory(subFolder);
			foreach (Mapper t in Mapper.Mappers(doc, nsmgr))
			{
				string chemin = subFolder + "\\" + t.Nom.Trim() + ".cs";
				FileStream stream = new FileStream(chemin, FileMode.Append, FileAccess.Write);
				StreamWriter writer = new StreamWriter(stream);
				using (writer)
					writer.WriteLine(" namespace" + " " + nomProjet + ".Tables" + "\r\n" + "{");
				writer.WriteLine(t.ToString());
				writer.WriteLine("}");
				writer.Close();
			}
		}

		public static void CreerDomain(XmlDocument doc, XmlNamespaceManager nsmgr, string path, string nomProjet)
		{


			var subFolder = path + "\\" + "Domain";
			Directory.CreateDirectory(subFolder);
			var InterfaceRegistreFolder = subFolder + "\\" + "Interfaces de registre";
			Directory.CreateDirectory(InterfaceRegistreFolder);
			foreach (InterfaceRegistre i in InterfaceRegistre.InterfacesRegistre(doc, nsmgr))
			{
				string chemin = InterfaceRegistreFolder + "\\" + i.Nom.Trim() + ".cs";
				FileStream stream = new FileStream(chemin, FileMode.Append, FileAccess.Write);
				StreamWriter writer = new StreamWriter(stream);
				using (writer)
					writer.WriteLine(" namespace" + " " + nomProjet + ".Domain.Interfaces.de.Registre" + "\r\n" + "{");
				writer.WriteLine(i.ToString());
				writer.WriteLine("}");
				
			}

			var interfaceServiceExterneFolder = subFolder + "\\" + "Interfaces de services externes" ;
			Directory.CreateDirectory(interfaceServiceExterneFolder);
			foreach (InterfaceServiceExterne i in InterfaceServiceExterne.InterfacesServicesExternes(doc, nsmgr))
			{
				string chemin = interfaceServiceExterneFolder + "\\" + i.Nom.Trim() + ".cs";
				FileStream stream = new FileStream(chemin, FileMode.Append, FileAccess.Write);
				StreamWriter writer = new StreamWriter(stream);
				using (writer)
					writer.WriteLine(" namespace" + " " + nomProjet + ".Domain.Interfaces.de.Services.Externes" + "\r\n" + "{");
				writer.WriteLine(i.ToString());
				writer.WriteLine("}");
				
			}

			var registreFolder = subFolder + "\\" + "Registre";
			Directory.CreateDirectory(registreFolder);
			foreach (Registre r in Registre.Registres(doc, nsmgr))
			{
				string chemin = registreFolder + "\\" + r.Nom.Trim() + ".cs";
				FileStream stream = new FileStream(chemin, FileMode.Append, FileAccess.Write);
				StreamWriter writer = new StreamWriter(stream);
				using (writer)
					writer.WriteLine(" namespace" + " " + nomProjet + ".Domain.Registre" + "\r\n" + "{" + r.ToString() + "}");
				
				
			}

			
			var EntiteFolder = subFolder + "\\" + "Entites";
			Directory.CreateDirectory(EntiteFolder);
			foreach (Entite e in Entite.Entites(doc, nsmgr))
			{
				string chemin = EntiteFolder + "\\" + e.Nom.Trim() + ".cs";
				FileStream stream = new FileStream(chemin, FileMode.Append, FileAccess.Write);
				StreamWriter writer = new StreamWriter(stream);
				using (writer)
					writer.WriteLine(" namespace" + " " + nomProjet + ".Domain.Entites" + "\r\n" + "{");
				writer.WriteLine(e.ToString());
				writer.WriteLine("}");
				writer.Close();
			}

		}

	}
}

