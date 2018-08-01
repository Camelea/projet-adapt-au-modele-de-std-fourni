using System.Collections.Generic;
using System.Xml;

namespace ConsoleApp4.Tables

{       /// <summary>
		/// Classe qui permet de récupérer la liste des contraintes non nulles d'une table 
		/// </summary>
		
	public class ContrainteNonNulle
	{
		#region Attributs
		public string Nom { get; private set; }
		public string Colonne { get; private set; }
		#endregion

		#region Constructeur

		public ContrainteNonNulle(string nom, string colonne)
		{
			this.Nom = nom;
			this.Colonne = colonne;

		}
		#endregion

		#region Méthodes

		public override string ToString()
		{
			return (Nom + " NOT NULL"); //temporaire à regler plus tard 
		}
		/// <summary>
		///  Fonction qui permet de récupérer la liste des contraintes non nulles des tables presnetes dans le fichier 
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<ContrainteNonNulle> ContraintesNonNullesTables(XmlDocument doc, XmlNamespaceManager nsmgr,int i )
		{
			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<string> ListeContraintesNonNullesTables = new List<string>();


				string xpath = @"//w:p [ w:pPr / w:pStyle [@w:val='Heading1']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][2]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][4]/ following-sibling::w:tbl / w:tr /w:tc [count(. | //w:p [ w:pPr / w:pStyle [@w:val='Heading1']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][2]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][5]/ preceding-sibling::w:tbl / w:tr /w:tc)= count(//w:p [ w:pPr / w:pStyle [@w:val='Heading1']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][2]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][5]/preceding-sibling::w:tbl / w:tr /w:tc)]";
				nodeList2 = root.SelectNodes(xpath, nsmgr);


				foreach (XmlNode isbn2 in nodeList2)
				{
					ListeContraintesNonNullesTables.Add(isbn2.InnerText);

				}

			
			return ListeAContraintesNonNulles(ListeContraintesNonNullesTables);

		}


		/// <summary>
		/// Fonction qui prend une liste de string et la transforme en liste de contraintes non nulles
		/// 
		/// </summary>
		/// <param name="liste"></param>
		/// <returns></returns>
		public static List<ContrainteNonNulle> ListeAContraintesNonNulles(List<string> liste)
		{
			List<ContrainteNonNulle> ListeContraintesNonNullesTables = new List<ContrainteNonNulle>();
			for (int i = 2; i < liste.Count; i = i + 2)
			{
				ListeContraintesNonNullesTables.Add(new ContrainteNonNulle(liste[i], liste[i + 1]));
			}
			return ListeContraintesNonNullesTables;
		}
		#endregion
	}
}