
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp4.Application.Interface
{
	class InterfaceService
	{
		#region Attributs

		public string Nom;
		public string Description;
		public List<Methode> Methodes;

		#endregion


		#region Constructeur
		public InterfaceService(string nom, string description, List<Methode> methodes)
		{
			this.Nom = nom;
			this.Description = description;
			this.Methodes = methodes;
		}
		public InterfaceService(string nom, string description)
		{
			this.Nom = nom;
			this.Description = description;
			
		}


		#endregion

		#region Méthodes 

		public override string ToString()
		{
			return (this.Nom + this.Description);
		}

		/// <summary>
		/// Retourne une liste de noms des interfaces de services présentes dans le fichier
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<string> NomsInterfacesServices(XmlDocument doc, XmlNamespaceManager nsmgr)
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<string> ListeNoms = new List<string>();
			string xpath = @"//w:p [ w:pPr / w:pStyle [@w:val='Heading1']][3]/following:: w:p[ w:pPr / w:pStyle [@w:val='Heading2']][1]/following-sibling:: w:p[ w:pPr / w:pStyle [@w:val='Heading3']]
				[count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][3] /following:: w:p[ w:pPr / w:pStyle [@w:val='Heading2']][2]/ preceding-sibling::w:p [ w:pPr / w:pStyle [@w:val='Heading3']])= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][3]/following:: w:p[ w:pPr / w:pStyle [@w:val='Heading2']][2]/preceding-sibling::w:p  [ w:pPr / w:pStyle [@w:val='Heading3']])]";

			nodeList2 = root.SelectNodes(xpath, nsmgr);

			foreach (XmlNode isbn2 in nodeList2)
			{
				ListeNoms.Add(isbn2.InnerText);
			}

			return ListeNoms;


		}

		/// <summary>
		/// Fonction qui retourne la liste des descriptions des interfaces de service    
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<String> DescriptionsInterfacesServices(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<string> ListeDescriptionsInterfacesServices = new List<string>();

			for (int i = 1; i < NomsInterfacesServices(doc, nsmgr).Count + 1; i++)

			{
				string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][1] / following-sibling::w:p [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/ preceding-sibling::w:p)= count(w:p [ w:pPr / w:pStyle [@w:val='Heading1']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/preceding-sibling::w:p)]";

				nodeList2 = root.SelectNodes(xpath, nsmgr);

				foreach (XmlNode isbn2 in nodeList2)
				{
					ListeDescriptionsInterfacesServices.Add(isbn2.InnerText);
				}

			}
			return ListeDescriptionsInterfacesServices;


		}


		/// <summary>
		/// Retourne la liste des interfaces de service du fichier 
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<InterfaceService> InterfacesService(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			List<InterfaceService> interfacesServices = new List<InterfaceService>();
			List<string> noms = NomsInterfacesServices(doc, nsmgr);
			List<string> descriptions = DescriptionsInterfacesServices(doc, nsmgr);
			List<List<Methode>> methodes = Methode.Methodes(doc, nsmgr);

			for (int i = 1; i < NomsInterfacesServices(doc, nsmgr).Count + 1; i++)
			{


				if (Methode.NombreMethodesInterfacesServices(doc, nsmgr)[i - 1] != 0 )
				{

					interfacesServices.Add(new InterfaceService(noms[i - 1], descriptions[i - 1], methodes[i - 1]));
				}

				if (Methode.NombreMethodesInterfacesServices(doc, nsmgr)[i - 1] == 0)
				{

					interfacesServices.Add(new InterfaceService(noms[i - 1], descriptions[i - 1]));
				}



			}
			return interfacesServices;

		}





		#endregion
	}
}
