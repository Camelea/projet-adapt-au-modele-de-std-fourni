using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp4.Tables
{
	class Index
	{
		public string Nom;
		public string Colonne;


		public Index(string nom, string colonne)
		{
			this.Nom = nom;
			this.Colonne = colonne;

		}
		public override string ToString()
		{
			return (this.Nom + " " + this.Colonne); //temporaire à regkler plus tard 
		}

		/// <summary>
		/// Fonction qui permet de recuperer la liste des indexes de la table concernée 
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<Index> IndexTables(XmlDocument doc, XmlNamespaceManager nsmgr,int i)
		{
			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<string> ListeIndexes = new List<string>();
	

				string xpath = @"//w:p [ w:pPr / w:pStyle [@w:val='Heading1']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][2]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][6]/ following-sibling::w:tbl / w:tr /w:tc [count(. | //w:p [ w:pPr / w:pStyle [@w:val='Heading1']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']]["+i+ "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][3]/ preceding-sibling::w:tbl / w:tr /w:tc)= count(//w:p [ w:pPr / w:pStyle [@w:val='Heading1']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][3]/preceding-sibling::w:tbl / w:tr /w:tc)]";
				nodeList2 = root.SelectNodes(xpath, nsmgr);


				foreach (XmlNode isbn2 in nodeList2)
				{
					ListeIndexes.Add(isbn2.InnerText);

				}

			return ListeAIndex(ListeIndexes);

		}


		/// <summary>
		/// Fonction qui prend une liste de string et la transforme en liste d'indexes
		/// 
		/// </summary>
		/// <param name="liste"></param>
		/// <returns></returns>
		public static List<Index> ListeAIndex(List<string> liste)
		{
			List<Index> ListeIndexesTables = new List<Index>();
			for (int i = 2; i < liste.Count; i = i + 2)
			{
				ListeIndexesTables.Add(new Index(liste[i], liste[i + 1]));
			}
			return ListeIndexesTables;
		}

	}
}
