using ConsoleApp4.Domain.Entites;
using System.Collections.Generic;
using System.Xml;

namespace ConsoleApp4.Domain.CommonType.Services_Externes
{
	public class EntitePartiel
	{
		#region Attributs 

		public string Nom { get; private set; }
		public string Description { get; private set; }

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
		/// Renvoie l'entité partiel de l'entité entré en parametre 
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static EntitePartiel EntitesPartiels(XmlDocument doc, XmlNamespaceManager nsmgr,int i )
		{
			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<string> ListeEntitePartiel = new List<string>();
			

				
				string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2] / following-sibling::w:tbl/w:tr/w:tc  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1]  /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][3] / preceding-sibling::w:tbl/w:tr/w:tc)= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]  /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][3] / preceding-sibling::w:tbl/w:tr/w:tc)]";


				nodeList2 = root.SelectNodes(xpath, nsmgr);


				foreach (XmlNode isbn2 in nodeList2)
				{

					ListeEntitePartiel.Add(isbn2.InnerText);

				}
		


		return new EntitePartiel(ListeEntitePartiel[2],ListeEntitePartiel[3]);

		}

		#endregion
	}
}