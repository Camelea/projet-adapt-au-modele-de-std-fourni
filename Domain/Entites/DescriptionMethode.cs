using ConsoleApp4.Domain.Entites;
using System.Collections.Generic;
using System.Xml;

namespace ConsoleApp4.Domain.CommonType.Services_Externes
{

	public class DescriptionMethode
	{

		#region Attributs

		public string Nom { get; private set; }
		public string Visibilite { get; private set; }
		public string Description { get; private set; }

		#endregion

		#region Constructeur 

		public DescriptionMethode(string nom, string visibilite, string description)
		{
			this.Nom = nom;
			this.Visibilite = visibilite;
			this.Description = description;

		}

		#endregion

		#region Méthodes 

		/// <summary>
		/// retourne la liste des descriptions des methodes des entités 
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<DescriptionMethode> DescriptionsMethodesEntites(XmlDocument doc, XmlNamespaceManager nsmgr,int i , int cmp)
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<string> ListeDescriptionsMethodesEntites = new List<string>();

				if (Methode.NombreMethodesEntites(doc, nsmgr,i - 1) != 0)
				{
						
						string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][7] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][2]/ following-sibling:: w:tbl / w:tr /w:tc  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][7] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][4] / preceding-sibling::w:tbl / w:tr /w:tc)= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][7] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][2] / preceding-sibling::w:tbl / w:tr /w:tc)]";


						nodeList2 = root.SelectNodes(xpath, nsmgr);

						foreach (XmlNode isbn2 in nodeList2)
						{
							if (isbn2.InnerText != "")
							{
								ListeDescriptionsMethodesEntites.Add(isbn2.InnerText.Trim());
							}
						}
						
					}

			return (ListeADescriptionsMethode(ListeDescriptionsMethodesEntites));

		}


		/// <summary>
		/// Renvoie la liste des colonnes de descriptions associés à une liste donnée
		/// </summary>
		/// <returns></returns>
		public static List<DescriptionMethode> ListeADescriptionsMethode(List<string> liste)
		{
			List<DescriptionMethode> ListeDescriptionsEntites = new List<DescriptionMethode>();
			for (int i = 3; i < liste.Count; i = i + 3)
			{
				ListeDescriptionsEntites.Add(new DescriptionMethode(liste[i], liste[i + 1], liste[i + 2]));
			}
			return ListeDescriptionsEntites;
		}






		#endregion
	}
}