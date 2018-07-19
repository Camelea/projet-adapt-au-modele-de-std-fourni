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
		public List<string> NomsClassesServicesExternes(XmlDocument doc, XmlNamespaceManager nsmgr)
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


















			#endregion


		}
}
