using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp4.Application.Mappers
{
	class AlgorithmeMapper
	{

		#region Attributs
		public string ProprieteSource { get; private set; }
		public string ProprieteDestination { get; private set; }
		public string Algorithme { get; private set; }

		#endregion

		#region Constructeur 
		public AlgorithmeMapper(string proprieteSource, string proprieteDestination, string algorithme)
		{
			this.ProprieteDestination = proprieteDestination;
			this.ProprieteSource = proprieteSource;
			this.Algorithme = algorithme;

		}
		#endregion
		#region Méthodes
		/// <summary>
		/// Retourne la liste des Algorithmes des méthodes des services externes présents dans le fichier
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<List<AlgorithmeMapper>> AlgorithmesMethodesMappers(XmlDocument doc, XmlNamespaceManager nsmgr)
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<List<string>> ListeAlgorithmesMethodesMappers = new List<List<string>>();
			List<List<AlgorithmeMapper>> AlgorithmesMethodesMappers = new List<List<AlgorithmeMapper>>();
			for (int i = 1; i < Mapper.NomsMappers(doc, nsmgr).Count + 1; i++)

			{
				for (int cmp = 0; cmp < MethodeMapper.NombreMethodesMappers(doc, nsmgr)[i - 1] + 1; cmp++)
				{
					if (i < Mapper.NomsMappers(doc, nsmgr).Count || (i == Mapper.NomsMappers(doc, nsmgr).Count && cmp < MethodeMapper.NombreMethodesMappers(doc, nsmgr)[i - 1] - 1))
					{
						ListeAlgorithmesMethodesMappers.Add(new List<string>());
						string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][4]/ following-sibling:: w:tbl / w:tr /w:tc  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 2) + "]  / preceding-sibling::w:tbl / w:tr /w:tc)= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 2) + "]  / preceding-sibling::w:tbl / w:tr /w:tc)]";


						nodeList2 = root.SelectNodes(xpath, nsmgr);

						foreach (XmlNode isbn2 in nodeList2)
						{
							if (isbn2.InnerText != "")
							{
								ListeAlgorithmesMethodesMappers[cmp].Add(isbn2.InnerText.Trim());
							}
						}
						AlgorithmesMethodesMappers.Add(ListeAAlgorithmesMappers(ListeAlgorithmesMethodesMappers[cmp]));


					}



					if (i == Mapper.NomsMappers(doc, nsmgr).Count && cmp == MethodeMapper.NombreMethodesMappers(doc, nsmgr)[i - 1] - 1)
					{
						ListeAlgorithmesMethodesMappers.Add(new List<string>());
						string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][4]/ following-sibling:: w:tbl / w:tr /w:tc  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + (i+1) + "]  / preceding-sibling::w:tbl / w:tr /w:tc)= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + (i +1)+ "]  / preceding-sibling::w:tbl / w:tr /w:tc)]";


						nodeList2 = root.SelectNodes(xpath, nsmgr);

						foreach (XmlNode isbn2 in nodeList2)
						{
							if (isbn2.InnerText != "")
							{
								ListeAlgorithmesMethodesMappers[cmp].Add(isbn2.InnerText.Trim());
							}
						}
						AlgorithmesMethodesMappers.Add(ListeAAlgorithmesMappers(ListeAlgorithmesMethodesMappers[cmp]));


					}
					if (i <Mapper.NomsMappers(doc, nsmgr).Count && cmp == MethodeMapper.NombreMethodesMappers(doc, nsmgr)[i - 1] - 1)
					{
						ListeAlgorithmesMethodesMappers.Add(new List<string>());
						string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][4]/ following-sibling:: w:tbl / w:tr /w:tc  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][7]  / preceding-sibling::w:tbl / w:tr /w:tc)= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][7] / preceding-sibling::w:tbl / w:tr /w:tc)]";


						nodeList2 = root.SelectNodes(xpath, nsmgr);

						foreach (XmlNode isbn2 in nodeList2)
						{
							if (isbn2.InnerText != "")
							{
								ListeAlgorithmesMethodesMappers[cmp].Add(isbn2.InnerText.Trim());
							}
						}
						AlgorithmesMethodesMappers.Add(ListeAAlgorithmesMappers(ListeAlgorithmesMethodesMappers[cmp]));


					}
				}
			}


			return AlgorithmesMethodesMappers;
		}

		/// <summary>
		/// Renvoie la liste des colonnes d'algorithmes associés à une liste donnée
		/// </summary>
		/// <returns></returns>
		public static List<AlgorithmeMapper> ListeAAlgorithmesMappers(List<string> liste)
		{
			List<AlgorithmeMapper> ListeParametresMappers = new List<AlgorithmeMapper>();
			for (int i = 3; i < liste.Count; i = i + 3)
			{
				ListeParametresMappers.Add(new AlgorithmeMapper(liste[i], liste[i + 1], liste[i + 2]));
			}
			return ListeParametresMappers;
		}


		#endregion
	}
}
