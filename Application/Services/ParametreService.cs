using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp4.Application.Services
{
	class ParametreService
	{
		#region Attributs

		public string Nom;
		public string Type;
		public string Description;

		#endregion

		#region Constructeur 

		public ParametreService(string nom, string type, string description)
		{
			this.Nom = nom;
			this.Type = type;
			this.Description = description;
		}

		#endregion

		#region Méthodes 

		/// <summary>
		/// retourne la liste des parametres des methodes des services 
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<List<ParametreService>> ParametresMethodesServices(XmlDocument doc, XmlNamespaceManager nsmgr)
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<List<string>> ListeParametresMethodesServices = new List<List<string>>();
			List<List<ParametreService>> ParametresMethodesServices = new List<List<ParametreService>>();

			for (int i = 1; i < Service.NomsServices(doc, nsmgr).Count + 1; i++)
			{

				if (MethodeService.NombreMethodesServices(doc, nsmgr)[i - 1] != 0)
				{

					for (int cmp = 0; cmp < MethodeService.NombreMethodesServices(doc, nsmgr)[i - 1]; cmp++)
					{

						ListeParametresMethodesServices.Add(new List<string>());
						string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][2]/ following-sibling:: w:tbl / w:tr /w:tc  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][3] / preceding-sibling::w:tbl / w:tr /w:tc)= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][3] / preceding-sibling::w:tbl / w:tr /w:tc)]";


						nodeList2 = root.SelectNodes(xpath, nsmgr);

						foreach (XmlNode isbn2 in nodeList2)
						{
							if (isbn2.InnerText != "")
							{
								ListeParametresMethodesServices[cmp].Add(isbn2.InnerText.Trim());
							}
						}
						ParametresMethodesServices.Add(ListeAParametresServices(ListeParametresMethodesServices[cmp]));

					}

				}
			}
			return ParametresMethodesServices;

		}


		/// <summary>
		/// Renvoie la liste des colonnes de types de retour associés à une liste donnée
		/// </summary>
		/// <returns></returns>
		public static List<ParametreService> ListeAParametresServices(List<string> liste)
		{
			List<ParametreService> ListeParametresServices = new List<ParametreService>();
			for (int i = 3; i < liste.Count; i = i + 3)
			{
				ListeParametresServices.Add(new ParametreService(liste[i], liste[i + 1], liste[i + 2]));
			}
			return ListeParametresServices;
		}





		#endregion
	}
}
