using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp4.Domain.CommonType.Services_Externes
{
	class ServiceExterne
	{
		#region Attributs

		public string Nom;
		public string Description;
		public List<Propriete> Proprietes;



		#endregion

		#region Constructeur 
		public ServiceExterne(string nom, string description, List<Propriete> proprietes)
		{
			this.Nom = nom;
			this.Description = description;
			this.Proprietes = proprietes;
		}
		#endregion

		#region Méthodes 


		/// <summary>
		/// Fonction qui retourne les noms des services externes 
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<string> NomsClassesServicesExternes(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;

			List<string> ListeNoms = new List<string>();
			string xpath = @"//w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2]/following:: w:p[ w:pPr / w:pStyle [@w:val='Heading2']][1]
				/following-sibling:: w:p[ w:pPr / w:pStyle [@w:val='Heading3']]
				[count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p[ w:pPr / w:pStyle [@w:val='Heading2']][2]/ preceding-sibling::w:p [ w:pPr / w:pStyle [@w:val='Heading3']])= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2]/following:: w:p[ w:pPr / w:pStyle [@w:val='Heading2']][2]/preceding-sibling::w:p  [ w:pPr / w:pStyle [@w:val='Heading3']])]";

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
		public static List<String> DescriptionServicesExternes(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<string> ListeDescriptionsServicesExternes = new List<string>();

			for (int i = 1; i <NomsClassesServicesExternes(doc, nsmgr).Count + 1; i++)

			{
				string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][1] / following-sibling::w:p [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/ preceding-sibling::w:p)= count(w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/preceding-sibling::w:p)]";

				nodeList2 = root.SelectNodes(xpath, nsmgr);

				foreach (XmlNode isbn2 in nodeList2)
				{
					ListeDescriptionsServicesExternes.Add(isbn2.InnerText);
				}

			}

			return ListeDescriptionsServicesExternes;


		}




		/// <summary>
		/// Fonction qui retourne la listes des services externes 
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<ServiceExterne> WebMethodes(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			List<string> noms = NomsClassesServicesExternes(doc, nsmgr);
			List<ServiceExterne> servicesExternes = new List<ServiceExterne>();
			List<string> descriptions = DescriptionServicesExternes(doc, nsmgr);
			List<List<Propriete>> proprietes = Propriete.ProprietesServicesExternes(doc, nsmgr);
			for (int i = 0; i < noms.Count; i++)
			{
				servicesExternes.Add(new ServiceExterne(noms[i], descriptions[i], proprietes[i]));

			}
			return servicesExternes;

		}













		#endregion


	}
}
