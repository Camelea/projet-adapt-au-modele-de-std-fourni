using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp4.Application.Services
{
	class Service
	{
		#region Attributs

		public string Nom;
		public string Description;
		public string InterfaceImplementee;
		public List<MethodeService> Methodes;

		#endregion


		#region Constructeur
		public Service(string nom, string description, string interfaceImplementee, List<MethodeService> methodes)
		{
			this.Nom = nom;
			this.Description = description;
			this.InterfaceImplementee = interfaceImplementee;
			this.Methodes = methodes;
		}
		public Service(string nom, string interfaceImplementee, string description)
		{
			this.Nom = nom;
			this.Description = description;
			this.InterfaceImplementee = interfaceImplementee;

		}


		#endregion


		#region Méthodes 

		public override string ToString()
		{
			return (this.Nom + this.Description);
		}

		/// <summary>
		/// Retourne une liste de noms des services présents dans le fichier
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<string> NomsServices(XmlDocument doc, XmlNamespaceManager nsmgr)
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<string> ListeNoms = new List<string>();
			string xpath = @"//w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6]/following:: w:p[ w:pPr / w:pStyle [@w:val='Heading2']][1]/following-sibling:: w:p[ w:pPr / w:pStyle [@w:val='Heading3']]
				[count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6] /following:: w:p[ w:pPr / w:pStyle [@w:val='Heading2']][2]/ preceding-sibling::w:p [ w:pPr / w:pStyle [@w:val='Heading3']])= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6]/following:: w:p[ w:pPr / w:pStyle [@w:val='Heading2']][2]/preceding-sibling::w:p  [ w:pPr / w:pStyle [@w:val='Heading3']])]";

			nodeList2 = root.SelectNodes(xpath, nsmgr);

			foreach (XmlNode isbn2 in nodeList2)
			{
				ListeNoms.Add(isbn2.InnerText);
			}

			return ListeNoms;


		}

		/// <summary>
		/// Fonction qui retourne la liste des descriptions des services    
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static string DescriptionsService(XmlDocument doc, XmlNamespaceManager nsmgr,int i)
		{
			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;

	
				string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][1] / following-sibling::w:p [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/ preceding-sibling::w:p)= count(w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/preceding-sibling::w:p)]";
				var res = "";
				nodeList2 = root.SelectNodes(xpath, nsmgr);

				foreach (XmlNode isbn2 in nodeList2)
				{
					res = res + " " + (isbn2.InnerText);
				}

			
			return res;


		}

		/// <summary>
		/// Fonction qui retourne la liste des interfaces implementees des services    
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static string InterfacesImplementeesServices(XmlDocument doc, XmlNamespaceManager nsmgr,int i )
		{
			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;


				string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2] ";
				nodeList2 = root.SelectNodes(xpath, nsmgr);
				var res = "";
				foreach (XmlNode isbn2 in nodeList2)
				{
					res = res + " " +(isbn2.InnerText);
				}

			
			return res;


		}


		/// <summary>
		/// Retourne la liste des services du fichier  
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<Service> Services(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			List<Service> services = new List<Service>();
			List<string> noms = NomsServices(doc, nsmgr);
		

			for (int i = 1; i < NomsServices(doc, nsmgr).Count + 1; i++)
			{
				List<MethodeService> methodes = MethodeService.MethodesServices(doc, nsmgr, i);
				string descriptions = DescriptionsService(doc, nsmgr,i);
				string interfacesImplementees = InterfacesImplementeesServices(doc, nsmgr,i);


				if (MethodeService.NombreMethodesServices(doc, nsmgr,i - 1) != 0)
				{

					services.Add(new Service(noms[i - 1], descriptions, interfacesImplementees, methodes));
				}

				if (MethodeService.NombreMethodesServices(doc, nsmgr,i - 1) == 0)
				{

					services.Add(new Service(noms[i - 1], descriptions, interfacesImplementees));
				}



			}
			return services;

		}





		#endregion
	}
}
