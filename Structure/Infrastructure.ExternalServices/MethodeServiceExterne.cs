using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp4.Infrastructure.ExternalServices
{
	class MethodeServiceExterne
	{
		#region Attributs 

		public string Nom;
		public List<DescriptionServiceExterne> Descriptions;
		public List<ParametreServiceExterne> ParametresMethode;
		public List<TypeRetourServiceExterne> TypesRetour;
		public string Algorithme;
		#endregion

		#region Constructeur 

		public MethodeServiceExterne(string nom, List<DescriptionServiceExterne>  descriptions, List<ParametreServiceExterne> parametresMethode, List<TypeRetourServiceExterne> typeRetour, string algorithme)
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
		/// Retourne la liste des noms des méthodes des services externes présentes dans le fichier
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<string> NomsMethodesServiceExterne(XmlDocument doc, XmlNamespaceManager nsmgr,int i )
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<string> MethodesServiceExterne = new List<string>();

			string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][5] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][3]/ following-sibling::w:p [ w:pPr / w:pStyle [@w:val='Heading4']]  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][5] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + 1 + "]/preceding-sibling:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']] )= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][5] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + (i + 1) + "] /preceding-sibling:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']])]";


			if (i == ServiceExterne.NomsServiceExterne(doc, nsmgr).Count)
			{

				xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][5] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][3]/ following-sibling::w:p [ w:pPr / w:pStyle [@w:val='Heading4']]  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6] /preceding-sibling:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']] )= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6]/preceding-sibling:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']])]";
			}
					nodeList2 = root.SelectNodes(xpath, nsmgr);

					foreach (XmlNode isbn2 in nodeList2)
					{
						MethodesServiceExterne.Add(isbn2.InnerText);
					}

				
			

			return MethodesServiceExterne;


		}


		/// <summary>
		/// Retourne le nombre de methodes de chaque service externe
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static int NombreMethodesServiceExterne(XmlDocument doc, XmlNamespaceManager nsmgr,int i )
		{
			
			return NomsMethodesServiceExterne(doc,nsmgr,i).Count;
		}



		/// <summary>
		/// Fonction qui renvoie la liste de toutes les méthodes des services externes
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<MethodeServiceExterne> MethodesServiceExterne(XmlDocument doc, XmlNamespaceManager nsmgr,int i )
		{
			List<MethodeServiceExterne> methodes = new List<MethodeServiceExterne>();
	
				List<string> nomsMethodes = NomsMethodesServiceExterne(doc, nsmgr,i-1);
				if (NombreMethodesServiceExterne(doc, nsmgr, i - 1) != 0)
				{


					for (int cmp = 0; cmp < NombreMethodesServiceExterne(doc, nsmgr, i - 1); cmp++)

					{
					string algorithmes = AlgorithmesMethodesServiceExterne(doc, nsmgr, i - 1, cmp);
					List<DescriptionServiceExterne> descriptions = DescriptionServiceExterne.DescriptionsMethodesServiceExterne(doc, nsmgr,i,cmp);
					List<ParametreServiceExterne> parametresMethodes = ParametreServiceExterne.ParametresMethodesServiceExterne(doc, nsmgr,i ,cmp);
					List<TypeRetourServiceExterne> typesRetour = TypeRetourServiceExterne.TypeRetourMethodesServiceExternes(doc, nsmgr,i ,cmp);

					methodes.Add(new MethodeServiceExterne(nomsMethodes[cmp], descriptions, parametresMethodes, typesRetour, algorithmes));


					}

			}
			return methodes;
		}

		/// <summary>
		/// Retourne la liste des Algorithmes des méthodes des services externes présents dans le fichier
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static string AlgorithmesMethodesServiceExterne(XmlDocument doc, XmlNamespaceManager nsmgr,int i,int cmp )
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
	
				string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][5] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][3]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][4]/ following-sibling::w:p  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][5] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][3]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][" + (cmp + 2) + "]/preceding-sibling:: w:p )= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][5] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][3]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][" + (cmp + 2) + "]/preceding-sibling:: w:p)]";


				if (i == ServiceExterne.NomsServiceExterne(doc, nsmgr).Count && cmp == NombreMethodesServiceExterne(doc, nsmgr, i - 1) - 1)
				{
					
					xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][5] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][3]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][4]/ following-sibling::w:p  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6] /preceding-sibling:: w:p )= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6] /preceding-sibling:: w:p)]";
				}

				if (i < ServiceExterne.NomsServiceExterne(doc, nsmgr).Count && cmp == NombreMethodesServiceExterne(doc, nsmgr, i - 1) - 1)
				{
					
					 xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][5] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][3]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][4]/ following-sibling::w:p  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][5] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + (i + 1) + "] /preceding-sibling:: w:p )= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][5] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + (i + 1) + "] /preceding-sibling:: w:p)]";
				}

				nodeList2 = root.SelectNodes(xpath, nsmgr);
			StringBuilder res = new StringBuilder();

			foreach (XmlNode isbn2 in nodeList2)
				{
					res.Append(isbn2.InnerText);
				}

			

			return res.ToString();
		}

		

		#endregion

	}
}
