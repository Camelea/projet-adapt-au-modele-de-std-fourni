using ConsoleApp4.Domain.Entites;
using System.Collections.Generic;
using System.Xml;

namespace ConsoleApp4.Domain.CommonType.Services_Externes
{
	public class ParametreMethode
	{

		#region Attributs

		public string Nom;
		public string Type;
		public string Description;
		public string AValider;

		#endregion

		#region Constructeur 

		public ParametreMethode(string nom ,string type, string description,string aValider)
		{
			this.Nom = nom;
			this.Type = type;
			this.Description = description;
			this.AValider = aValider;
		}

		#endregion

		#region Méthodes 

		/// <summary>
		/// retourne la liste des parametres des methodes des entités 
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<List<ParametreMethode>> ParametresMethodesEntites(XmlDocument doc, XmlNamespaceManager nsmgr)
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<List<string>> ListeParametresMethodesEntites = new List<List<string>>();
			List<List<ParametreMethode>> ParametresMethodesEntites = new List<List<ParametreMethode>>();

			for (int i = 1; i < Entite.NomsEntites(doc, nsmgr).Count + 1; i++)
			{

				if (Methode.NombreMethodesEntites(doc, nsmgr)[i - 1] != 0)
				{

					for (int cmp = 0; cmp < Methode.NombreMethodesEntites(doc, nsmgr)[i - 1]; cmp++)
					{

						ListeParametresMethodesEntites.Add(new List<string>());
						string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][7] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][2]/ following-sibling:: w:tbl / w:tr /w:tc  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][7] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][3] / preceding-sibling::w:tbl / w:tr /w:tc)= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][7] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][3] / preceding-sibling::w:tbl / w:tr /w:tc)]";


						nodeList2 = root.SelectNodes(xpath, nsmgr);

						foreach (XmlNode isbn2 in nodeList2)
						{
							if (isbn2.InnerText != "")
							{
								ListeParametresMethodesEntites[cmp].Add(isbn2.InnerText.Trim());
							}
						}
						ParametresMethodesEntites.Add(ListeAParametresMethode(ListeParametresMethodesEntites[cmp]));

					}

				}
			}
			return ParametresMethodesEntites;

		}


		/// <summary>
		/// Renvoie la liste des colonnes de types de retour associés à une liste donnée
		/// </summary>
		/// <returns></returns>
		public static List<ParametreMethode> ListeAParametresMethode(List<string> liste)
		{
			List<ParametreMethode> ListeParametresEntites = new List<ParametreMethode>();
			for (int i = 4; i < liste.Count; i = i + 4)
			{
				ListeParametresEntites.Add(new ParametreMethode(liste[i], liste[i + 1], liste[i + 2], liste[i + 3]));
			}
			return ListeParametresEntites;
		}





		#endregion
	}
}