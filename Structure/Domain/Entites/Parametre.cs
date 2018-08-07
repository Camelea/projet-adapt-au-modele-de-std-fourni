using ConsoleApp4.Domain.Entites;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace ConsoleApp4.Domain.Entites
{
	public class Parametre
	{
		#region Attributs
		public string Nom { get; private set; }
		public string Type { get; private set; }
		public string Description { get; private set; }

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


		
		public static List<Parametre> ParametresEntites(XmlDocument doc, XmlNamespaceManager nsmgr,int i )
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<string> ListeParametresEntites = new List<string>();
			
						string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][6]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][1]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][2]/ following-sibling::w:tbl / w:tr /w:tc  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][6]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][2]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][3]/preceding-sibling:: w:tbl / w:tr /w:tc )= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][6]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][2]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][3]/preceding-sibling:: w:tbl / w:tr /w:tc)]";


						nodeList2 = root.SelectNodes(xpath, nsmgr);

						foreach (XmlNode isbn2 in nodeList2)
						{

							ListeParametresEntites.Add(isbn2.InnerText);

						}
				

			
			return (ListeAParametres(ListeParametresEntites));

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