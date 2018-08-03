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
		public string Description;
		public List<ParametreRegistre> ParametresRegistres;
		public TypeRetourRegistre TypesRetour;
		public string Algorithme;
		#endregion

		#region Constructeur 

		public MethodeRegistre(string nom, string description, List<ParametreRegistre> parametresMethode, TypeRetourRegistre typeRetour, string algorithme)
		{
			this.Nom = nom;
			this.Description = description;
			this.ParametresRegistres = parametresMethode;
			this.TypesRetour = typeRetour;
			this.Algorithme = algorithme;

		}

		#endregion

		#region Méthodes 

		public override string ToString()
		{ var docParam = "";
			var param = "(";
			foreach (ParametreRegistre p in this.ParametresRegistres)
			{
				docParam = docParam + p.ToString() + "\r\n";
				if (p == this.ParametresRegistres.Last())
				{
					param = param + p.Type + " " + p.Nom + ")";
				}
				else
				{
					param = param + p.Type + " " + p.Nom + ", ";
				}
			}

			var res = "///<summary>" + "\r\n" + "/// " + this.Description + "." + "\r\n" + "/// </summary>" + "\r\n" + docParam + "\r\n" + "public" + this.TypesRetour.Type + this.Nom + param + "\r\n" +"{"  + this.Algorithme + "\r\n" + "}" ;
			return res;
		}

		/// <summary>
		/// Retourne la liste des noms des méthodes des registres présentes dans le fichier
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<string> NomsMethodesRegistres(XmlDocument doc, XmlNamespaceManager nsmgr,int i )
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<string> MethodesRegistres = new List<string>();

			string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][3]/ following-sibling::w:p [ w:pPr / w:pStyle [@w:val='Heading5']]  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + (i + 1) + "]]/preceding-sibling:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']] )= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + (i + 1) + "]/preceding-sibling:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']])]";

					
			if (i == Registre.NomsRegistres(doc, nsmgr).Count)
			{

				xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][3]/ following-sibling::w:p [ w:pPr / w:pStyle [@w:val='Heading5']]  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][4]/preceding-sibling:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']] )= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][4] /preceding-sibling:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']])]";
			}
					nodeList2 = root.SelectNodes(xpath, nsmgr);

					foreach (XmlNode isbn2 in nodeList2)
					{
					MethodesRegistres.Add(isbn2.InnerText);
					}
					

			return MethodesRegistres;


		}


		/// <summary>
		/// Retourne le nombre de methodes de chaque registre
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static int NombreMethodesRegistres(XmlDocument doc, XmlNamespaceManager nsmgr,int i )
		{

			return NomsMethodesRegistres(doc, nsmgr,i).Count ;
		}



		/// <summary>
		/// Fonction qui renvoie la liste de toutes les méthodes des Registres
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<MethodeRegistre> MethodesRegistres(XmlDocument doc, XmlNamespaceManager nsmgr,int i )
		{
			List<MethodeRegistre> methodes = new List<MethodeRegistre>();

				if (NombreMethodesRegistres(doc, nsmgr,i - 1) != 0)
				{
				List<string> nomsMethodes = NomsMethodesRegistres(doc, nsmgr, i);
				List<MethodeRegistre> methodesInterfacesServices = new List<MethodeRegistre>();

					for (int cmp = 0; cmp < NombreMethodesRegistres(doc, nsmgr,i - 1); cmp++)
					{
					string algorithmes = AlgorithmesMethodesRegsitres(doc, nsmgr,i,cmp);
					string descriptions = DescriptionsMethodesRegistres(doc, nsmgr,i,cmp);
					List<ParametreRegistre> parametresMethodes = ParametreRegistre.ParametresMethodesEntites(doc, nsmgr, i,cmp);
					TypeRetourRegistre typesRetour = TypeRetourRegistre.TypeRetourMethodesRegistres(doc, nsmgr, i, cmp);

					methodes.Add(new MethodeRegistre(nomsMethodes[i-1], descriptions, parametresMethodes, typesRetour, algorithmes));


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
		public static string AlgorithmesMethodesRegsitres(XmlDocument doc, XmlNamespaceManager nsmgr,int i ,int cmp)
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			

			string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][3]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][4]/ following-sibling::w:p  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][3]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 2) + "]/preceding-sibling:: w:p )= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][3]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 2) + "]/preceding-sibling:: w:p)]";


			if (i == Registre.NomsRegistres(doc, nsmgr).Count && cmp == NombreMethodesRegistres(doc, nsmgr, i - 1) - 1)
			{
				
				xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][3]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][4]/ following-sibling::w:p  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][4] /preceding-sibling:: w:p )= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][4] /preceding-sibling:: w:p)]";
			}
					

					if (i < Registre.NomsRegistres(doc, nsmgr).Count && cmp == NombreMethodesRegistres(doc, nsmgr,i - 1) - 1) {
			xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][3]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][4]/ following-sibling::w:p  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + (i +1)+ "]/preceding-sibling:: w:p )= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + (i+1)+ "]/preceding-sibling:: w:p)]";

			}
			nodeList2 = root.SelectNodes(xpath, nsmgr);
			var res = "";
			foreach (XmlNode isbn2 in nodeList2)
			{
				res = res + (isbn2.InnerText);
			}
			

			return res;
		}

		/// <summary>
		/// Retourne la liste des descriptions des méthodes des registres présents dans le fichier
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static string DescriptionsMethodesRegistres(XmlDocument doc, XmlNamespaceManager nsmgr,int i , int cmp)
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
		
					string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][3]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][1]/ following-sibling::w:p  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][3]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][2]/preceding-sibling:: w:p )= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][3]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][2]/preceding-sibling:: w:p)]";

					nodeList2 = root.SelectNodes(xpath, nsmgr);
					var res = "";
					foreach (XmlNode isbn2 in nodeList2)
					{
						res = res + (isbn2.InnerText);
					}


			return res;


		}



		#endregion
	}
}
