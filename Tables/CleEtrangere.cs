using System.Collections.Generic;
using System.Xml;

namespace ConsoleApp4.Tables
{
	public class CleEtrangere
	{
		#region Attributs
		public string Nom;
		public string Colonne;
		public string NomTable;
		#endregion

		#region Constructeur
		public CleEtrangere(string nom, string colonne, string nomTable)
		{
			this.Nom = nom;
			this.Colonne = colonne;
			this.NomTable = nomTable;
		}
		#endregion

		#region Méthodes 
		public override string ToString()// à corriger 
		{
			return ("CONSTRAINT" + "\"" + this.Nom + "\"" + "FOREIGN KEY ( \" " + this.Colonne + " \" REFERENCES \" " + this.NomTable + "(" + this.Colonne + ")");

		}

		/// <summary>
		/// Renvoie les colonnes de cles etrangeres associés à une liste donnée
		/// </summary>
		/// <returns></returns>
		public static List<CleEtrangere> ListeAClesEtrangeres(List<string> liste)
		{
			List<CleEtrangere> ListeClesEtrangeresTables = new List<CleEtrangere>();
			for (int i = 3; i < liste.Count; i = i + 3)
			{
				ListeClesEtrangeresTables.Add(new CleEtrangere(liste[i], liste[i + 1], liste[i + 2]));
			}
			return ListeClesEtrangeresTables;
		}

		/// <summary>
		/// Methode qui permet de recuperer la liste des colonnes des tables 
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<List<CleEtrangere>> ClesEtrangeresTables(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<List<string>> ListeClesEtrangeres = new List<List<string>>();
			List<List<CleEtrangere>> ListeClesEtrangeresTables = new List<List<CleEtrangere>>();

			for (int i = 1; i < Table.NombreTables(doc, nsmgr) + 1; i++)

			{

				ListeClesEtrangeres.Add(new List<string>());
				string xpath = @"//w:p [ w:pPr / w:pStyle [@w:val='Heading1']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][2]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][3]/ following-sibling::w:tbl / w:tr /w:tc [count(. | //w:p [ w:pPr / w:pStyle [@w:val='Heading1']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][2]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][4]/ preceding-sibling::w:tbl / w:tr /w:tc)= count(//w:p [ w:pPr / w:pStyle [@w:val='Heading1']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][2]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][4]/preceding-sibling::w:tbl / w:tr /w:tc)]";
				nodeList2 = root.SelectNodes(xpath, nsmgr);


				foreach (XmlNode isbn2 in nodeList2)
				{
					ListeClesEtrangeres[i-1].Add(isbn2.InnerText);

				}
				ListeClesEtrangeresTables.Add(ListeAClesEtrangeres(ListeClesEtrangeres[i-1]));

			}
			return ListeClesEtrangeresTables;

		}
		#endregion
	}
}