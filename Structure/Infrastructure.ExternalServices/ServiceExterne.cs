using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp4.Infrastructure.ExternalServices
{
	class ServiceExterne
	{
		#region Attributs

		public string Nom;
		public string Description;
		public string InterfaceImplementee;
		public List<MethodeServiceExterne> Methodes;

		#endregion


		#region Constructeur
		public ServiceExterne(string nom, string description, string interfaceImplementee, List<MethodeServiceExterne> methodes)
		{
			this.Nom = nom;
			this.Description = description;
			this.InterfaceImplementee = interfaceImplementee;
			this.Methodes = methodes;
		}
		public ServiceExterne(string nom, string interfaceImplementee, string description)
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
		/// Retourne une liste de noms des services externes présents dans le fichier
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<string> NomsServiceExterne(XmlDocument doc, XmlNamespaceManager nsmgr)
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<string> ListeNoms = new List<string>();
			string xpath = @"//w:p [ w:pPr / w:pStyle [@w:val='Heading1']][5]/following-sibling:: w:p[ w:pPr / w:pStyle [@w:val='Heading2']]
				[count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6] / preceding-sibling::w:p [ w:pPr / w:pStyle [@w:val='Heading2']])= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6]/preceding-sibling::w:p  [ w:pPr / w:pStyle [@w:val='Heading2']])]";

			nodeList2 = root.SelectNodes(xpath, nsmgr);

			foreach (XmlNode isbn2 in nodeList2)
			{
				ListeNoms.Add(isbn2.InnerText);
			}

			return ListeNoms;


		}

		/// <summary>
		/// Fonction qui retourne la liste des descriptions des services externes    
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static String DescriptionsServiceExterne(XmlDocument doc, XmlNamespaceManager nsmgr,int i )
		{
			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
		
	
				string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][5] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']]["+i+"] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][1] / following-sibling::w:p [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][5] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']]["+i+ "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][2]/ preceding-sibling::w:p)= count(w:p [ w:pPr / w:pStyle [@w:val='Heading1']][5] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][2]/preceding-sibling::w:p)]";

				nodeList2 = root.SelectNodes(xpath, nsmgr);
			StringBuilder res = new StringBuilder();
			foreach (XmlNode isbn2 in nodeList2)
				{
				res.Append(isbn2.InnerText);
				}


			return res.ToString();


		}

		/// <summary>
		/// Fonction qui retourne la liste des interfaces implementees des services externes     
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static string InterfacesImplementeesServiceExterne(XmlDocument doc, XmlNamespaceManager nsmgr,int i )
		{
			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
	
	
				string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][5] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']]["+i+"] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][2] ";
				nodeList2 = root.SelectNodes(xpath, nsmgr);
			StringBuilder res = new StringBuilder();
			foreach (XmlNode isbn2 in nodeList2)
				{
					res.Append(isbn2.InnerText);
				}

			
			return res.ToString();


		}


		/// <summary>
		/// Retourne la liste des services externes du fichier  
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<ServiceExterne> ServicesExternes(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			List<ServiceExterne> servicesExternes = new List<ServiceExterne>();
			List<string> noms = NomsServiceExterne(doc, nsmgr);


			for (int i = 1; i < NomsServiceExterne(doc, nsmgr).Count + 1; i++)
			{
				List<MethodeServiceExterne> methodes = MethodeServiceExterne.MethodesServiceExterne(doc, nsmgr, i);
				string descriptions = DescriptionsServiceExterne(doc, nsmgr,i-1);
				string interfacesImplementees = InterfacesImplementeesServiceExterne(doc, nsmgr,i-1);


				if (MethodeServiceExterne.NombreMethodesServiceExterne(doc, nsmgr,i - 1) != 0)
				{

					servicesExternes.Add(new ServiceExterne(noms[i - 1], descriptions, interfacesImplementees, methodes));
				}

				if (MethodeServiceExterne.NombreMethodesServiceExterne(doc, nsmgr,i - 1) == 0)
				{

					servicesExternes.Add(new ServiceExterne(noms[i - 1], descriptions, interfacesImplementees));
				}



			}
			return servicesExternes;

		}





		#endregion
	}
}
