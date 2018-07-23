using ConsoleApp4.Domain.Entites;
using System.Collections.Generic;
using System.Xml;

namespace ConsoleApp4.Domain.CommonType.Services_Externes
{
	public class ClasseParent
	{
		#region Attributs 

		public string Nom;
		public string Description;

		#endregion

		#region Constructeur 

		public ClasseParent(string nom, string description)
		{
			this.Nom = nom;
			this.Description = description;
		}

		#endregion

		#region Méthodes


		/// <summary>
		/// Renvoie la liste des informations des Classes parent des entites 
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<List<ClasseParent>> ClassesParent(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<List<string>> ListeClassesParent = new List<List<string>>();
			List<List<ClasseParent>> ClassesParent = new List<List<ClasseParent>>();
			for (int i = 1; i < Entite.NomsEntites(doc, nsmgr).Count + 1; i++)
			{

				ListeClassesParent.Add(new List<string>());
				string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][3] / following-sibling::w:tbl/w:tr/w:tc  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1]  /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][4] / preceding-sibling::w:tbl/w:tr/w:tc)= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]  /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][4] / preceding-sibling::w:tbl/w:tr/w:tc)]";


				nodeList2 = root.SelectNodes(xpath, nsmgr);


				foreach (XmlNode isbn2 in nodeList2)
				{

					ListeClassesParent[i - 1].Add(isbn2.InnerText);

				}
				ClassesParent.Add(ListeAClasseParent(ListeClassesParent[i - 1]));
			}


			return ClassesParent;

		}



		/// <summary>
		/// Fonction qui prend une liste de string et la transforme en liste de colonnes de classes parent 
		/// 
		/// </summary>
		/// <param name="liste"></param>
		/// <returns></returns>
		public static List<ClasseParent> ListeAClasseParent(List<string> liste)
		{
			List<ClasseParent> ListeClassesParent = new List<ClasseParent>();
			for (int i = 2; i < liste.Count; i = i + 2)
			{
				ListeClassesParent.Add(new ClasseParent(liste[i], liste[i + 1]));
			}
			return ListeClassesParent;
		}


		#endregion
	}
}