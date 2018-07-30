using ConsoleApp4.Domain.Entites;
using System.Collections.Generic;
using System.Xml;

namespace ConsoleApp4.Domain.CommonType.Services_Externes
{
	public class EntitePartiel
	{
		#region Attributs 

		public string Nom;
		public string Description;

		#endregion

		#region Constructeur 

		public EntitePartiel(string nom, string description)
		{
			this.Nom = nom;
			this.Description = description;
		}

		#endregion

		#region Méthodes


		/// <summary>
		/// Renvoie la liste des informations de parametres sortants des services externes 
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<EntitePartiel> EntitesPartiels(XmlDocument doc, XmlNamespaceManager nsmgr,int i )
		{
			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<string> ListeEntitesPartiels = new List<string>();
			

				
				string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2] / following-sibling::w:tbl/w:tr/w:tc  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1]  /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][3] / preceding-sibling::w:tbl/w:tr/w:tc)= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]  /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][3] / preceding-sibling::w:tbl/w:tr/w:tc)]";


				nodeList2 = root.SelectNodes(xpath, nsmgr);


				foreach (XmlNode isbn2 in nodeList2)
				{

					ListeEntitesPartiels.Add(isbn2.InnerText);

				}
		


		return (ListeAEntitePartiel(ListeEntitesPartiels));

		}



		/// <summary>
		/// Fonction qui prend une liste de string et la transforme en liste d'entites partiels 
		/// 
		/// </summary>
		/// <param name="liste"></param>
		/// <returns></returns>
		public static List<EntitePartiel> ListeAEntitePartiel(List<string> liste)
		{
			List<EntitePartiel> ListeEntitesPartiels = new List<EntitePartiel>();
			for (int i = 2; i < liste.Count; i = i + 2)
			{
				ListeEntitesPartiels.Add(new EntitePartiel(liste[i], liste[i + 1]));
			}
			return ListeEntitesPartiels;
		}


		#endregion
	}
}