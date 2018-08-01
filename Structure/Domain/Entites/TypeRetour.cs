using ConsoleApp4.Domain.Entites;
using System.Collections.Generic;
using System.Xml;

namespace ConsoleApp4.Domain.CommonType.Services_Externes
{
	public class TypeRetour
	{
		#region Attributs

		public string Type { get; private set; }
		public string Description { get; private set; }

		#endregion

		#region Constructeur 

		public TypeRetour(string type, string description)
		{
			this.Type = type;
			this.Description = description;

		}

		#endregion

		#region Méthodes 

		/// <summary>
		/// retourne la liste des type de retour des entités 
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<TypeRetour> TypeRetourMethodesEntites(XmlDocument doc, XmlNamespaceManager nsmgr,int i , int cmp)
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<string> ListeMethodesEntites = new List<string>();
			
			
				if (Methode.NombreMethodesEntites(doc, nsmgr,i - 1)!= 0)
				{

						string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][7] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][3]/ following-sibling:: w:tbl / w:tr /w:tc  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][7] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][4] / preceding-sibling::w:tbl / w:tr /w:tc)= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][7] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][4] / preceding-sibling::w:tbl / w:tr /w:tc)]";


						nodeList2 = root.SelectNodes(xpath, nsmgr);

						foreach (XmlNode isbn2 in nodeList2)
						{
							if (isbn2.InnerText != "")
							{
								ListeMethodesEntites.Add(isbn2.InnerText.Trim());
							}
						}
		
					}

			
			return (ListeATypeRetour(ListeMethodesEntites));

		}


		/// <summary>
		/// Renvoie la liste des colonnes de types de retour associés à une liste donnée
		/// </summary>
		/// <returns></returns>
		public static List<TypeRetour> ListeATypeRetour(List<string> liste)
		{
			List<TypeRetour> ListeTypeRetourEntites = new List<TypeRetour>();
			for (int i = 2; i < liste.Count; i = i + 2)
			{
				ListeTypeRetourEntites.Add(new TypeRetour(liste[i], liste[i + 1]));
			}
			return ListeTypeRetourEntites;
		}





		#endregion
	}
}