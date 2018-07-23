using ConsoleApp4.Domain.Entites;
using System.Collections.Generic;
using System.Xml;

namespace ConsoleApp4.Domain.Entites
{
	public class Parametre
	{
		#region Attributs
		public string Nom;
		public string Type;
		public string Description;

		#endregion

		#region Constructeur 
		public Parametre(string nom, string type, string description)
		{
			this.Nom = nom;
			this.Type = type;
			this.Description = description;

		}

		#endregion

		#region Méthodes

		public override string ToString()
		{
			return (Nom + " " + Type + " " + Description);

		}

		
		public static List<List<Parametre>> ParametresEntites(XmlDocument doc, XmlNamespaceManager nsmgr)
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<List<string>> ListeParametresEntites = new List<List<string>>();
			List<List<Parametre>> ParametresEntites = new List<List<Parametre>>();

			for (int i = 1; i < Entite.NomsEntites(doc, nsmgr).Count + 1; i++)
			{
				
						ListeParametresEntites.Add(new List<string>());
						string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][6]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][1]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][2]/ following-sibling::w:tbl / w:tr /w:tc  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][6]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][2]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][3]/preceding-sibling:: w:tbl / w:tr /w:tc )= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][6]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][2]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][3]/preceding-sibling:: w:tbl / w:tr /w:tc)]";


						nodeList2 = root.SelectNodes(xpath, nsmgr);

						foreach (XmlNode isbn2 in nodeList2)
						{

							ListeParametresEntites[i-1].Add(isbn2.InnerText);

						}
						ParametresEntites.Add(ListeAParametres(ListeParametresEntites[i-1]));

					}

			
			return ParametresEntites;

		}


		/// <summary>
		/// Renvoie la liste des parametres associés à une liste donnée
		/// </summary>
		/// <returns></returns>
		public static List<Parametre> ListeAParametres(List<string> liste)
		{
			List<Parametre> ListeParametres = new List<Parametre>();
			for (int i = 3; i < liste.Count; i = i + 3)
			{
				ListeParametres.Add(new Parametre(liste[i], liste[i + 1], liste[i + 2]));
			}
			return ListeParametres;
		}
		#endregion

	}
}