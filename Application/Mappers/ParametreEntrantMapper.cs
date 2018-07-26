using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp4.Application.Mappers
{
	class ParametreEntrantMapper
	{
		#region Attributs

		public string Nom { get; private set; }
		public string Type { get; private set; }
		public string Description { get; private set; }

		#endregion

		#region Constructeur 

		public ParametreEntrantMapper(string nom, string type, string description)
		{
			this.Nom = nom;
			this.Type = type;
			this.Description = description;
		}

		#endregion

		#region Méthodes 

		/// <summary>
		/// retourne la liste des parametres des methodes des mappers
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<List<ParametreEntrantMapper>> ParametresMethodesMappers(XmlDocument doc, XmlNamespaceManager nsmgr)
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<List<string>> ListeParametresMethodesMappers = new List<List<string>>();
			List<List<ParametreEntrantMapper>> ParametresMethodesMappers = new List<List<ParametreEntrantMapper>>();

			for (int i = 1; i < Mapper.NomsMappers(doc, nsmgr).Count + 1; i++)
			{

				if (MethodeMapper.NombreMethodesMappers(doc, nsmgr)[i - 1] != 0)
				{

					for (int cmp = 0; cmp < MethodeMapper.NombreMethodesMappers(doc, nsmgr)[i - 1]; cmp++)
					{

						ListeParametresMethodesMappers.Add(new List<string>());
						string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][2]/ following-sibling:: w:tbl / w:tr /w:tc  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][3] / preceding-sibling::w:tbl / w:tr /w:tc)= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][3] / preceding-sibling::w:tbl / w:tr /w:tc)]";


						nodeList2 = root.SelectNodes(xpath, nsmgr);

						foreach (XmlNode isbn2 in nodeList2)
						{
							if (isbn2.InnerText != "")
							{
								ListeParametresMethodesMappers[cmp].Add(isbn2.InnerText.Trim());
							}
						}
						ParametresMethodesMappers.Add(ListeAParametresMappers(ListeParametresMethodesMappers[cmp]));

					}

				}
			}
			return ParametresMethodesMappers;

		}


		/// <summary>
		/// Renvoie la liste des colonnes de parametres associés à une liste donnée
		/// </summary>
		/// <returns></returns>
		public static List<ParametreEntrantMapper> ListeAParametresMappers(List<string> liste)
		{
			List<ParametreEntrantMapper> ListeParametresMappers = new List<ParametreEntrantMapper>();
			for (int i = 3; i < liste.Count; i = i + 3)
			{
				ListeParametresMappers.Add(new ParametreEntrantMapper(liste[i], liste[i + 1], liste[i + 2]));
			}
			return ListeParametresMappers;
		}





		#endregion
	}
}
