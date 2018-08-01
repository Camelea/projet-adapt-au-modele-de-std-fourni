using System.Collections.Generic;
using System.Xml;

namespace ConsoleApp4.Tables
{
	public class ClePrimaire
	{
		#region Attributs

		public string Nom;
		public string Colonne;

		#endregion

		#region Constructeur 
		public ClePrimaire(string nom, string colonne)
		{
			this.Nom = nom;
			this.Colonne = colonne;

		}

		#endregion

		#region Méthodes
		public override string ToString()
		{
			return ("CONSTRAINT " + "\"" + this.Nom + "\"" + "PIMARY KEY ( \" " + this.Colonne + " \" REFERENCES \" " + "(" + this.Colonne + ")");
		}

		/// <summary>
		/// Fonction qui renvoie une liste de listes des clées primaires de chaque table 
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<ClePrimaire> ClesPrimairesTables(XmlDocument doc, XmlNamespaceManager nsmgr,int i )
		{
			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<string> ListeClesPrimaires = new List<string>();
			
				string xpath = @"//w:p [ w:pPr / w:pStyle [@w:val='Heading1']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][2]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/ following-sibling::w:tbl / w:tr /w:tc [count(. | //w:p [ w:pPr / w:pStyle [@w:val='Heading1']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][2]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][3]/ preceding-sibling::w:tbl / w:tr /w:tc)= count(//w:p [ w:pPr / w:pStyle [@w:val='Heading1']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][2]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][3]/preceding-sibling::w:tbl / w:tr /w:tc)]";
				nodeList2 = root.SelectNodes(xpath, nsmgr);


				foreach (XmlNode isbn2 in nodeList2)
				{
					ListeClesPrimaires.Add(isbn2.InnerText);

				}

			return ListeAClesPrimaires(ListeClesPrimaires);

		}


		/// <summary>
		/// Fonction qui prend une liste de string et la transforme en liste de cles primaires
		/// 
		/// </summary>
		/// <param name="liste"></param>
		/// <returns></returns>
		public static List<ClePrimaire> ListeAClesPrimaires(List<string> liste)
		{
			List<ClePrimaire> ListeClesPrimaireTables = new List<ClePrimaire>();
			for (int i = 2; i < liste.Count; i = i + 2)
			{
				ListeClesPrimaireTables.Add(new ClePrimaire(liste[i], liste[i + 1]));
			}
			return ListeClesPrimaireTables;
		}

		#endregion

	}
}