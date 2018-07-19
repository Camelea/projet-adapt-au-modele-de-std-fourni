using System.Collections.Generic;
using System.Xml;

namespace ConsoleApp4.Tables
{
	public class Sequence
	{
		public string Nom { get; set; }


		public Sequence(string nom)
		{
			this.Nom = nom;
		}
		public override string ToString()
		{
			return Nom;
		}

		/// <summary>
		/// Renvoie la liste des sequences des tables presentes dans le fichier 
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<Sequence> SequencesTables(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<string> ListeSequences = new List<string>();
			List<Sequence> ListeSequencesTables = new List<Sequence>();


			for (int i = 1; i < Table.NombreTables(doc, nsmgr) + 1; i++)

			{


				string xpath = @"//w:p [ w:pPr / w:pStyle [@w:val='Heading1']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][2]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][1]/ following-sibling::w:tbl / w:tr /w:tc [count(. | //w:p [ w:pPr / w:pStyle [@w:val='Heading1']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][2]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/ preceding-sibling::w:tbl / w:tr /w:tc)= count(//w:p [ w:pPr / w:pStyle [@w:val='Heading1']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][2]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/preceding-sibling::w:tbl / w:tr /w:tc)]";

				nodeList2 = root.SelectNodes(xpath, nsmgr);
				foreach (XmlNode isbn2 in nodeList2)
				{
					ListeSequences.Add(isbn2.InnerText);
				}

			}


			for (int i = 0; i < ListeSequences.Count - 1; i++)
			{
				ListeSequencesTables.Add(new Sequence(ListeSequences[i + 1]));
			}


			while (ListeSequencesTables.Count < Table.NombreTables(doc, nsmgr))
			{
				ListeSequencesTables.Add(new Sequence("none"));
			}
			return ListeSequencesTables;
		}
	}
}