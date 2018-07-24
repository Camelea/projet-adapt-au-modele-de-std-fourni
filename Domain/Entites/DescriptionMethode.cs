using ConsoleApp4.Domain.Entites;
using System.Collections.Generic;
using System.Xml;

namespace ConsoleApp4.Domain.CommonType.Services_Externes
{

	public class DescriptionMethode
	{

		#region Attributs

		public string Nom;
		public string Type;
		public string Description;

		#endregion

		#region Constructeur 

		public DescriptionMethode(string nom, string type, string description)
		{
			this.Nom = nom;
			this.Type = type;
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
		public static List<List<DescriptionMethode>> DescriptionsMethodesEntites(XmlDocument doc, XmlNamespaceManager nsmgr)
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<List<string>> ListeDescriptionsMethodesEntites = new List<List<string>>();
			List<List<DescriptionMethode>> DescriptionsMethodesEntites = new List<List<DescriptionMethode>>();

			for (int i = 1; i < Entite.NomsEntites(doc, nsmgr).Count + 1; i++)
			{

				if (Methode.NombreMethodesEntites(doc, nsmgr)[i - 1] != 0)
				{

					for (int cmp = 0; cmp < Methode.NombreMethodesEntites(doc, nsmgr)[i - 1]; cmp++)
					{

						ListeDescriptionsMethodesEntites.Add(new List<string>());
						string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][7] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][2]/ following-sibling:: w:tbl / w:tr /w:tc  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][7] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][4] / preceding-sibling::w:tbl / w:tr /w:tc)= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][7] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][2] / preceding-sibling::w:tbl / w:tr /w:tc)]";


						nodeList2 = root.SelectNodes(xpath, nsmgr);

						foreach (XmlNode isbn2 in nodeList2)
						{
							if (isbn2.InnerText != "")
							{
								ListeDescriptionsMethodesEntites[cmp].Add(isbn2.InnerText.Trim());
							}
						}
						DescriptionsMethodesEntites.Add(ListeADescriptionsMethode(ListeDescriptionsMethodesEntites[cmp]));

					}

				}
			}
			return DescriptionsMethodesEntites;

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