using ConsoleApp4.Domain.Entites;
using System.Collections.Generic;
using System.Xml;

namespace ConsoleApp4.Domain.CommonType.Services_Externes
{
	public class ParametreMethode
	{

		#region Attributs

		public string Nom { get; private set; }
		public string Type { get; private set; }
		public string Description { get; private set; }
		public string AValider { get; private set; }

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


		public override string ToString()
		{
			var doc = "/// <param name=\"" + this.Nom + "\">" + this.Description + "." + "</param>";
			return doc;
		}


		/// <summary>
		/// retourne la liste des parametres des methodes des entités 
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<ParametreMethode> ParametresMethodesEntites(XmlDocument doc, XmlNamespaceManager nsmgr,int i , int cmp)
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<string> ListeParametresMethodesEntites = new List<string>();
			
				if (Methode.NombreMethodesEntites(doc, nsmgr,i - 1) != 0)
				{

						string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][7] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][2]/ following-sibling:: w:tbl / w:tr /w:tc  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][7] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][3] / preceding-sibling::w:tbl / w:tr /w:tc)= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][7] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][3] / preceding-sibling::w:tbl / w:tr /w:tc)]";


						nodeList2 = root.SelectNodes(xpath, nsmgr);

						foreach (XmlNode isbn2 in nodeList2)
						{
							if (isbn2.InnerText != "")
							{
								ListeParametresMethodesEntites.Add(isbn2.InnerText.Trim());
							}
						}
				
					}

			return ListeAParametresMethode(ListeParametresMethodesEntites);


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