using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp4.Tables
{/// <summary>
 /// Classe qui permet de récupérer les données  d'une table 
 /// </summary>
	class Donnee
	{
		#region Attributs
		public string Nom;
		public string Valeur;

		#endregion

		#region Constructeur 
		public Donnee(string nom, string valeur)
		{
			this.Nom = nom;
			this.Valeur = valeur;

		}

		#endregion

		#region Méthodes 

		public override string ToString()
		{
			return (Nom + " " + Valeur); // à corriger 
		}



		/// <summary>
		/// Renvoie la liste des informaions de colonnes de chaque table
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<Donnee> DonneesTables(XmlDocument doc, XmlNamespaceManager nsmgr,int i)
		{
			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<string> ListeDonnes = new List<string>();


				string xpath = @"//w:p [ w:pPr / w:pStyle [@w:val='Heading1']][1]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']]["+i+"] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][3]/ following-sibling::w:tbl / w:tr /w:tc [count(. | //w:p [ w:pPr / w:pStyle [@w:val='Heading1']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + (i + 1) + "]/ preceding-sibling::w:tbl / w:tr /w:tc)= count(//w:p [ w:pPr / w:pStyle [@w:val='Heading1']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + (i + 1) + "]/preceding-sibling::w:tbl / w:tr /w:tc)]";

				nodeList2 = root.SelectNodes(xpath, nsmgr);


				foreach (XmlNode isbn2 in nodeList2)
				{
					ListeDonnes.Add(isbn2.InnerText);

				}
			
			
			return ListeADonnees(ListeDonnes);

		}


		/// <summary>
		/// Fonction qui prend une liste de string et la transforme en liste de donnes
		/// 
		/// </summary>
		/// <param name="liste"></param>
		/// <returns></returns>
		public static List<Donnee> ListeADonnees(List<string> liste)
		{
			List<Donnee> ListeDonnesTables = new List<Donnee>();
			for (int i = 2; i < liste.Count; i = i + 2)
			{
				ListeDonnesTables.Add(new Donnee(liste[i], liste[i + 1]));
			}
			return ListeDonnesTables;
		}
#endregion
	}
}
