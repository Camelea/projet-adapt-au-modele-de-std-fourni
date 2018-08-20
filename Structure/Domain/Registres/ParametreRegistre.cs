using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp4.Domain.Registres
{/// <summary>
 /// Classe qui permet de récupérer les parametres d'un registre donné  
 /// </summary>
	class ParametreRegistre
	{
		#region Attributs

		public string Nom;
		public string Type;
		public string Description;
		public string AValider;

		#endregion

		#region Constructeur 

		public ParametreRegistre(string nom, string type, string description, string aValider)
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
		/// retourne la liste des parametres des methodes des registres 
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<ParametreRegistre> ParametresMethodesEntites(XmlDocument doc, XmlNamespaceManager nsmgr,int i , int cmp )
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<string> ListeParametresMethodesRegistres = new List<string>();

				if (MethodeRegistre.NombreMethodesRegistres(doc, nsmgr,i) != 0)
				{

						
						string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][2]/ following-sibling:: w:tbl / w:tr /w:tc  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][3] / preceding-sibling::w:tbl / w:tr /w:tc)= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][3] / preceding-sibling::w:tbl / w:tr /w:tc)]";


						nodeList2 = root.SelectNodes(xpath, nsmgr);

						foreach (XmlNode isbn2 in nodeList2)
						{
					
								ListeParametresMethodesRegistres.Add(isbn2.InnerText);
							
						}
		
					}
			if (ListeParametresMethodesRegistres.Count < 7)
			{
				return null;
			}

			return ListeAParametresRegistre(ListeParametresMethodesRegistres);

		}


		/// <summary>
		/// Renvoie la liste des colonnes de types de retour associés à une liste donnée
		/// </summary>
		/// <returns></returns>
		public static List<ParametreRegistre> ListeAParametresRegistre(List<string> liste)
		{
			List<ParametreRegistre> ListeParametresRegistre = new List<ParametreRegistre>();
			for (int i = 4; i < liste.Count; i = i + 4)
			{
				ListeParametresRegistre.Add(new ParametreRegistre(liste[i], liste[i + 1], liste[i + 2], liste[i + 3]));
			}
			return ListeParametresRegistre;
		}





		#endregion
	}
}
