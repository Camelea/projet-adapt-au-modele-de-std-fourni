using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp4.Application.Mappers
{
	class MethodeMapper
	{
		#region Attributs 

		public string Nom;
		public string Descriptions;
		public List<ParametreEntrantMapper> ParametresMethode;
		public List<TypeRetourMapper> TypesRetour;
		public List<AlgorithmeMapper> Algorithme;
		#endregion

		#region Constructeur 

		public MethodeMapper(string nom, string descriptions, List<ParametreEntrantMapper> parametresMethode, List<TypeRetourMapper> typeRetour, List<AlgorithmeMapper> algorithme)
		{
			this.Nom = nom;
			this.Descriptions = descriptions;
			this.ParametresMethode = parametresMethode;
			this.TypesRetour = typeRetour;
			this.Algorithme = algorithme;

		}

		#endregion

		#region Méthodes 

		public override string ToString()
		{
			return (this.Nom);
		}

		/// <summary>
		/// Retourne la liste des noms des méthodes des mappers présentes dans le fichier
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<List<string>> NomsMethodesMappers(XmlDocument doc, XmlNamespaceManager nsmgr)
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<List<string>> MethodesMapper = new List<List<string>>();

			for (int i = 1; i < Mapper.NomsMappers(doc, nsmgr).Count + 1; i++)

			{
				if (i < Mapper.NomsMappers(doc, nsmgr).Count)
				{
					List<string> ListeMethodes = new List<string>();
					string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/ following-sibling::w:p [ w:pPr / w:pStyle [@w:val='Heading5']]  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + (i + 1) + "]]/preceding-sibling:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']] )= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + (i + 1) + "]/preceding-sibling:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']])]";

					nodeList2 = root.SelectNodes(xpath, nsmgr);

					foreach (XmlNode isbn2 in nodeList2)
					{
						ListeMethodes.Add(isbn2.InnerText);
					}
					MethodesMapper.Add(ListeMethodes);

				}
				if (i == Mapper.NomsMappers(doc, nsmgr).Count)
				{
					List<string> ListeMethodes = new List<string>();
					string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/ following-sibling::w:p [ w:pPr / w:pStyle [@w:val='Heading5']]  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][7]/preceding-sibling:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']] )= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][7] /preceding-sibling:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']])]";

					nodeList2 = root.SelectNodes(xpath, nsmgr);

					foreach (XmlNode isbn2 in nodeList2)
					{
						ListeMethodes.Add(isbn2.InnerText);
					}

				}
			}

			return MethodesMapper;


		}


		/// <summary>
		/// Retourne le nombre de methodes de chaque mapper
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<int> NombreMethodesMappers(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			List<int> NombreMethodesMapper = new List<int>();
			foreach (List<string> liste in NomsMethodesMappers(doc, nsmgr))
			{
				NombreMethodesMapper.Add(liste.Count);

			}
			return NombreMethodesMapper;
		}



		/// <summary>
		/// Fonction qui renvoie la liste de toutes les méthodes des mappers
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<List<MethodeMapper>> MethodesMappers(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			List<List<MethodeMapper>> methodes = new List<List<MethodeMapper>>();
			List<List<string>> nomsMethodes = NomsMethodesMappers(doc, nsmgr);
			List<List<AlgorithmeMapper>> algorithmes = AlgorithmeMapper.AlgorithmesMethodesMappers(doc, nsmgr);
			List<List<string>> descriptions = DescriptionsMethodesMappers(doc, nsmgr);
			List<List<ParametreEntrantMapper>> parametresMethodes = ParametreEntrantMapper.ParametresMethodesMappers(doc, nsmgr);
			List<List<TypeRetourMapper>> typesRetour = TypeRetourMapper.TypeRetourMethodesMappers(doc, nsmgr);
			for (int i = 1; i < Mapper.NomsMappers(doc, nsmgr).Count + 1; i++)
			{
				if (NombreMethodesMappers(doc, nsmgr)[i - 1] != 0)
				{
					List<MethodeMapper> methodesInterfacesMappers = new List<MethodeMapper>();

					for (int cmp = 0; cmp < NombreMethodesMappers(doc, nsmgr)[i - 1]; cmp++)
					{

						methodesInterfacesMappers.Add(new MethodeMapper(nomsMethodes[i - 1][cmp], descriptions[i - 1][cmp], parametresMethodes[cmp], typesRetour[cmp], algorithmes[cmp]));


					}
					methodes.Add(methodesInterfacesMappers);
				}


			}
			return methodes;
		}

		

		/// <summary>
		/// Retourne la liste des descriptions des méthodes des mappers présents dans le fichier
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<List<string>> DescriptionsMethodesMappers(XmlDocument doc, XmlNamespaceManager nsmgr)
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<List<string>> MethodesMappers = new List<List<string>>();

			for (int i = 1; i < Mapper.NomsMappers(doc, nsmgr).Count + 1; i++)

			{
				for (int cmp = 0; cmp < NombreMethodesMappers(doc, nsmgr)[i - 1] + 1; cmp++)
				{
					List<string> ListeMethodesMappers = new List<string>();
					string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][1]/ following-sibling::w:p  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][2]/preceding-sibling:: w:p )= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][2]/preceding-sibling:: w:p)]";

					nodeList2 = root.SelectNodes(xpath, nsmgr);

					foreach (XmlNode isbn2 in nodeList2)
					{
						ListeMethodesMappers.Add(isbn2.InnerText);
					}
					MethodesMappers.Add(ListeMethodesMappers);

				}
			}

			return MethodesMappers;


		}



		#endregion
	}
}
