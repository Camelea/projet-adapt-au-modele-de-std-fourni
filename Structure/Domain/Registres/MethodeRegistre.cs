using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp4.Domain.Registres
{
	class MethodeRegistre
	{
		#region Attributs 

		public string Nom;
		public string Descriptions;
		public List<ParametreRegistre> ParametresMethode;
		public List<TypeRetourRegistre> TypesRetour;
		public string Algorithme;
		#endregion

		#region Constructeur 

		public MethodeRegistre(string nom, string descriptions, List<ParametreRegistre> parametresMethode, List<TypeRetourRegistre> typeRetour, string algorithme)
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
		/// Retourne la liste des noms des méthodes des registres présentes dans le fichier
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<List<string>> NomsMethodesRegistres(XmlDocument doc, XmlNamespaceManager nsmgr)
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<List<string>> MethodesRegistres = new List<List<string>>();

			for (int i = 1; i < Registre.NomsRegistres(doc, nsmgr).Count + 1; i++)

			{
				if (i < Registre.NomsRegistres(doc, nsmgr).Count)
				{
					List<string> ListeMethodes = new List<string>();
					string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][3]/ following-sibling::w:p [ w:pPr / w:pStyle [@w:val='Heading5']]  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + (i + 1) + "]]/preceding-sibling:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']] )= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + (i + 1) + "]/preceding-sibling:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']])]";

					nodeList2 = root.SelectNodes(xpath, nsmgr);

					foreach (XmlNode isbn2 in nodeList2)
					{
						ListeMethodes.Add(isbn2.InnerText);
					}
					MethodesRegistres.Add(ListeMethodes);

				}
				if (i == Registre.NomsRegistres(doc, nsmgr).Count)
				{
					List<string> ListeMethodes = new List<string>();
					string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][3]/ following-sibling::w:p [ w:pPr / w:pStyle [@w:val='Heading5']]  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][4]/preceding-sibling:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']] )= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][4] /preceding-sibling:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']])]";

					nodeList2 = root.SelectNodes(xpath, nsmgr);

					foreach (XmlNode isbn2 in nodeList2)
					{
						ListeMethodes.Add(isbn2.InnerText);
					}
					
				}
			}

			return MethodesRegistres;


		}


		/// <summary>
		/// Retourne le nombre de methodes de chaque registre
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<int> NombreMethodesRegistres(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			List<int> NombreMethodesRegistre = new List<int>();
			foreach (List<string> liste in NomsMethodesRegistres(doc, nsmgr))
			{
				NombreMethodesRegistre.Add(liste.Count);

			}
			return NombreMethodesRegistre;
		}



		/// <summary>
		/// Fonction qui renvoie la liste de toutes les méthodes des Registres
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<List<MethodeRegistre>> MethodesRegistres(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			List<List<MethodeRegistre>> methodes = new List<List<MethodeRegistre>>();
			List<List<string>> nomsMethodes = NomsMethodesRegistres(doc, nsmgr);
			List<List<string>> algorithmes = AlgorithmesMethodesRegsitres(doc, nsmgr);
			List<List<string>> descriptions = DescriptionsMethodesRegistres(doc, nsmgr);
			List<List<ParametreRegistre>> parametresMethodes = ParametreRegistre.ParametresMethodesEntites(doc, nsmgr);
			List<List<TypeRetourRegistre>> typesRetour = TypeRetourRegistre.TypeRetourMethodesRegistres(doc, nsmgr);
			for (int i = 1; i < Registre.NomsRegistres(doc, nsmgr).Count + 1; i++)
			{
				if (NombreMethodesRegistres(doc, nsmgr)[i - 1] != 0)
				{
					List<MethodeRegistre> methodesInterfacesServices = new List<MethodeRegistre>();

					for (int cmp = 0; cmp < NombreMethodesRegistres(doc, nsmgr)[i - 1]; cmp++)
					{

						methodesInterfacesServices.Add(new MethodeRegistre(nomsMethodes[i - 1][cmp], descriptions[i-1][cmp], parametresMethodes[cmp], typesRetour[cmp], algorithmes[i - 1][cmp]));


					}
					methodes.Add(methodesInterfacesServices);
				}


			}
			return methodes;
		}

		/// <summary>
		/// Retourne la liste des Algorithmes des méthodes des registres présents dans le fichier
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<List<string>> AlgorithmesMethodesRegsitres(XmlDocument doc, XmlNamespaceManager nsmgr)
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<List<string>> MethodesRegistres = new List<List<string>>();

			for (int i = 1; i < Registre.NomsRegistres(doc, nsmgr).Count + 1; i++)

			{
				for (int cmp = 0; cmp < NombreMethodesRegistres(doc, nsmgr)[i - 1] + 1; cmp++)
				{
					if (i < Registre.NomsRegistres(doc, nsmgr).Count || (i == Registre.NomsRegistres(doc, nsmgr).Count && cmp < NombreMethodesRegistres(doc, nsmgr)[i - 1] - 1))
					{
						List<string> ListeMethodesEntites = new List<string>();
						string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][3]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][4]/ following-sibling::w:p  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][3]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 2) + "]/preceding-sibling:: w:p )= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][3]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 2) + "]/preceding-sibling:: w:p)]";

						nodeList2 = root.SelectNodes(xpath, nsmgr);
						var res = "";
						foreach (XmlNode isbn2 in nodeList2)
						{
							res = res + (isbn2.InnerText);
						}
						ListeMethodesEntites.Add(res);
						MethodesRegistres.Add(ListeMethodesEntites);

					}



					if (i == Registre.NomsRegistres(doc, nsmgr).Count && cmp == NombreMethodesRegistres(doc, nsmgr)[i - 1] - 1)
					{
						List<string> ListeMethodeRegistres = new List<string>();
						string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][3]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][4]/ following-sibling::w:p  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][4] /preceding-sibling:: w:p )= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][4] /preceding-sibling:: w:p)]";

						nodeList2 = root.SelectNodes(xpath, nsmgr);
						var res = "";
						foreach (XmlNode isbn2 in nodeList2)
						{
							res = res + (isbn2.InnerText);
						}
						ListeMethodeRegistres.Add(res);
						MethodesRegistres.Add(ListeMethodeRegistres);

					}
				}
			}


			return MethodesRegistres;
		}

		/// <summary>
		/// Retourne la liste des descriptions des méthodes des registres présents dans le fichier
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<List<string>> DescriptionsMethodesRegistres(XmlDocument doc, XmlNamespaceManager nsmgr)
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<List<string>> MethodesRegistres = new List<List<string>>();

			for (int i = 1; i < Registre.NomsRegistres(doc, nsmgr).Count + 1; i++)

			{
				for (int cmp = 0; cmp < NombreMethodesRegistres(doc, nsmgr)[i - 1] + 1; cmp++)
				{
					List<string> ListeMethodesRegistres = new List<string>();
					string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][3]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][1]/ following-sibling::w:p  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][3]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][2]/preceding-sibling:: w:p )= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][3]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][2]/preceding-sibling:: w:p)]";

					nodeList2 = root.SelectNodes(xpath, nsmgr);

					foreach (XmlNode isbn2 in nodeList2)
					{
						ListeMethodesRegistres.Add(isbn2.InnerText);
					}
					MethodesRegistres.Add(ListeMethodesRegistres);

				}
			}

			return MethodesRegistres;


		}



		#endregion
	}
}
