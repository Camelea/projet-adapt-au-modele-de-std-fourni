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
		public static List<String> DescriptionsService(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<string> ListeDescriptionsServices = new List<string>();

			for (int i = 1; i < NomsServices(doc, nsmgr).Count + 1; i++)

			{
				string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][1] / following-sibling::w:p [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/ preceding-sibling::w:p)= count(w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/preceding-sibling::w:p)]";

				nodeList2 = root.SelectNodes(xpath, nsmgr);

				foreach (XmlNode isbn2 in nodeList2)
				{
					ListeDescriptionsServices.Add(isbn2.InnerText);
				}

			}
			return ListeDescriptionsServices;


		}

		/// <summary>
		/// Fonction qui retourne la liste des interfaces implementees des services    
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<String> InterfacesImplementeesServices(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<string> ListeInterfacesImplementeesServices = new List<string>();

			for (int i = 1; i < NomsServices(doc, nsmgr).Count + 1; i++)

			{
				string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2] ";
				nodeList2 = root.SelectNodes(xpath, nsmgr);

				foreach (XmlNode isbn2 in nodeList2)
				{
					ListeInterfacesImplementeesServices.Add(isbn2.InnerText);
				}

			}
			return ListeInterfacesImplementeesServices;


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
			List<string> descriptions = DescriptionsService(doc, nsmgr);
			List<string> interfacesImplementees = InterfacesImplementeesServices(doc, nsmgr);
			List<List<MethodeService>> methodes = MethodeService.MethodesServices(doc, nsmgr);

			for (int i = 1; i < NomsServices(doc, nsmgr).Count + 1; i++)
			{


				if (MethodeService.NombreMethodesServices(doc, nsmgr)[i - 1] != 0)
				{

					services.Add(new Service(noms[i - 1], descriptions[i - 1], interfacesImplementees[i - 1], methodes[i - 1]));
				}

				if (MethodeService.NombreMethodesServices(doc, nsmgr)[i - 1] == 0)
				{

					services.Add(new Service(noms[i - 1], descriptions[i - 1], interfacesImplementees[i - 1]));
				}



			}
			return services;

		}





		#endregion
	}
}
