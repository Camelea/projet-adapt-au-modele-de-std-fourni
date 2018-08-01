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

		/// <summary>
		/// retourne la liste des parametres des methodes des registres 
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<List<ParametreRegistre>> ParametresMethodesEntites(XmlDocument doc, XmlNamespaceManager nsmgr)
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<List<string>> ListeParametresMethodesRegistres = new List<List<string>>();
			List<List<ParametreRegistre>> ParametresMethodesRegistres = new List<List<ParametreRegistre>>();

			for (int i = 1; i < Registre.NomsRegistres(doc, nsmgr).Count + 1; i++)
			{

				if (MethodeRegistre.NombreMethodesRegistres(doc, nsmgr)[i - 1] != 0)
				{

					for (int cmp = 0; cmp < MethodeRegistre.NombreMethodesRegistres(doc, nsmgr)[i - 1]; cmp++)
					{

						ListeParametresMethodesRegistres.Add(new List<string>());
						string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][2]/ following-sibling:: w:tbl / w:tr /w:tc  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][3] / preceding-sibling::w:tbl / w:tr /w:tc)= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][3] / preceding-sibling::w:tbl / w:tr /w:tc)]";


						nodeList2 = root.SelectNodes(xpath, nsmgr);

						foreach (XmlNode isbn2 in nodeList2)
						{
							if (isbn2.InnerText != "")
							{
								ListeParametresMethodesRegistres[cmp].Add(isbn2.InnerText.Trim());
							}
						}
						ParametresMethodesRegistres.Add(ListeAParametresRegistre(ListeParametresMethodesRegistres[cmp]));

					}

				}
			}
			return ParametresMethodesRegistres;

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
