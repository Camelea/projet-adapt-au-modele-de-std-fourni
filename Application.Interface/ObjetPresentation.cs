using ConsoleApp4.Domain.CommonType.Services_Externes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp4.Application.Interface
{
	class ObjetPresentation
	{
		#region Attributs

		public string Nom;
		public string Description;
		public List<Propriete> Proprietes;



		#endregion

		#region Constructeur 
		public ObjetPresentation(string nom, string description, List<Propriete> proprietes)
		{
			this.Nom = nom;
			this.Description = description;
			this.Proprietes = proprietes;
		}
		#endregion

		#region Méthodes 


		/// <summary>
		/// Fonction qui retourne les noms des objets de presentation  
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<string> NomsObjetsPresentation(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;

			List<string> ListeNoms = new List<string>();
			string xpath = @"//w:p [ w:pPr / w:pStyle [@w:val='Heading1']][3]/following:: w:p[ w:pPr / w:pStyle [@w:val='Heading2']][2]
				/following-sibling:: w:p[ w:pPr / w:pStyle [@w:val='Heading3']]
				[count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][3] /following:: w:p[ w:pPr / w:pStyle [@w:val='Heading2']][3]/ preceding-sibling::w:p [ w:pPr / w:pStyle [@w:val='Heading3']])= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2]/following:: w:p[ w:pPr / w:pStyle [@w:val='Heading2']][3]/preceding-sibling::w:p  [ w:pPr / w:pStyle [@w:val='Heading3']])]";

			nodeList2 = root.SelectNodes(xpath, nsmgr);

			foreach (XmlNode isbn2 in nodeList2)
			{
				ListeNoms.Add(isbn2.InnerText);
			}

			return ListeNoms;
		}


		/// <summary>
		/// Fonction qui retourne la liste des descriptions des objets de presentation   
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<String> DescriptionObjetsPresentation(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<string> ListeDescriptionsObjetPresentation = new List<string>();

			for (int i = 1; i < NomsObjetsPresentation(doc, nsmgr).Count + 1; i++)

			{
				string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][1] / following-sibling::w:p [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/ preceding-sibling::w:p)= count(w:p [ w:pPr / w:pStyle [@w:val='Heading1']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/preceding-sibling::w:p)]";

				nodeList2 = root.SelectNodes(xpath, nsmgr);

				foreach (XmlNode isbn2 in nodeList2)
				{
					ListeDescriptionsObjetPresentation.Add(isbn2.InnerText);
				}

			}

			return ListeDescriptionsObjetPresentation;


		}




		/// <summary>
		/// Fonction qui retourne la listes des objets de presentation   
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<ObjetPresentation> ObjetsPresentation(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			List<string> noms = NomsObjetsPresentation(doc, nsmgr);
			List<ObjetPresentation> objetsPresentation = new List<ObjetPresentation>();
			List<string> descriptions = DescriptionObjetsPresentation(doc, nsmgr);
			List<List<Propriete>> proprietes = Propriete.ProprietesObjetsPresentation(doc, nsmgr);
			for (int i = 0; i < noms.Count; i++)
			{
				objetsPresentation.Add(new ObjetPresentation(noms[i], descriptions[i], proprietes[i]));

			}
			return objetsPresentation;

		}
		#endregion
	}
}
