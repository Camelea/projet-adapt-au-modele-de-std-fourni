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

		public MethodeRegistre(string nom, string description, List<ParametreRegistre> parametresMethode, string algorithme)
		{
			this.Nom = nom;
			this.Description = description;
			this.ParametresRegistres = parametresMethode;
			this.Algorithme = algorithme;

		}

		public MethodeRegistre(string nom, string description, TypeRetourRegistre typeRetour, string algorithme)
		{
			this.Nom = nom;
			this.Description = description;
			this.TypesRetour = typeRetour;
			this.Algorithme = algorithme;

		}

		public MethodeRegistre(string nom, string description, string algorithme)
		{
			this.Nom = nom;
			this.Description = description;
			this.Algorithme = algorithme;

		}



		#endregion

		#region Méthodes 

		public override string ToString()
		{
			var res = "";
			if (this.ParametresRegistres != null)
			{
				
					StringBuilder docParam = new StringBuilder();
					StringBuilder param = new StringBuilder();
					param.Append("(");

					foreach (ParametreRegistre p in this.ParametresRegistres)
					{
						docParam.Append(p.ToString() + "\r\n");
						if (p == this.ParametresRegistres.Last())
						{
							param.Append(p.Type + " " + p.Nom + ")");
						}
						else
						{
							param.Append(p.Type + " " + p.Nom + ", ");
						}
					}
				if (this.TypesRetour != null)
				{

					res = "///<summary>" + "\r\n" + "/// " + this.Description + "." + "\r\n" + "/// </summary>" + "\r\n" + docParam.ToString() + "\r\n" + "public" + this.TypesRetour.Type + this.Nom + param.ToString() + "\r\n" + "{" + this.Algorithme + "\r\n" + "}";
				}
				else
				{
					res = "///<summary>" + "\r\n" + "/// " + this.Description + "." + "\r\n" + "/// </summary>" + "\r\n" + docParam.ToString() + "\r\n" + "public" + " void " + this.Nom + param.ToString() + "\r\n" + "{" + this.Algorithme + "\r\n" + "}";

				}
			}
			else
			{
				if (this.TypesRetour != null)
				{
					res = "///<summary>" + "\r\n" + "/// " + this.Description + "." + "\r\n" + "/// </summary>" + "\r\n" + "public" + this.TypesRetour.Type + this.Nom + "( ) " + "\r\n" + "{" + this.Algorithme + "\r\n" + "}";
				}
				else
				{
					res = "///<summary>" + "\r\n" + "/// " + this.Description + "." + "\r\n" + "/// </summary>" + "\r\n" + "public  " + "void"  + this.Nom + " ( ) " + "\r\n" + "{" + this.Algorithme + "\r\n" + "}";

				}
			}
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

			string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][3]/ following-sibling::w:p [ w:pPr / w:pStyle [@w:val='Heading5']]  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][3]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + (i + 1) + "]/preceding-sibling:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']] )= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][3]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + (i + 1) + "] /preceding-sibling:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']])]";


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

				if (NombreMethodesRegistres(doc, nsmgr,i ) != 0)
				{
				List<string> nomsMethodes = NomsMethodesRegistres(doc, nsmgr, i);

					for (int cmp = 0; cmp < NombreMethodesRegistres(doc, nsmgr,i ); cmp++)
					{
					string algorithmes = AlgorithmesMethodesRegsitres(doc, nsmgr,i,cmp);
					string descriptions = DescriptionsMethodesRegistres(doc, nsmgr,i,cmp);
					List<ParametreRegistre> parametresMethodes = ParametreRegistre.ParametresMethodesEntites(doc, nsmgr, i,cmp);
					TypeRetourRegistre typesRetour = TypeRetourRegistre.TypeRetourMethodesRegistres(doc, nsmgr, i, cmp);

					if (typesRetour != null && parametresMethodes != null)
					{
						methodes.Add(new MethodeRegistre(nomsMethodes[cmp], descriptions, parametresMethodes, typesRetour, algorithmes));
					}
					else {
						if (typesRetour != null && parametresMethodes == null)
						{
							methodes.Add(new MethodeRegistre(nomsMethodes[cmp], descriptions, typesRetour, algorithmes));
						}

						else {
							if (parametresMethodes != null && typesRetour == null)
							{
								methodes.Add(new MethodeRegistre(nomsMethodes[cmp], descriptions, parametresMethodes, new TypeRetourRegistre("void", ""), algorithmes));
							}
							else {
								
							

									methodes.Add(new MethodeRegistre(nomsMethodes[cmp], descriptions, algorithmes));
								} } } }
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


			if (i == Registre.NomsRegistres(doc, nsmgr).Count && cmp == NombreMethodesRegistres(doc, nsmgr, i) - 1)
			{
				
				xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][3]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][4]/ following-sibling::w:p  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][4] /preceding-sibling:: w:p )= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][4] /preceding-sibling:: w:p)]";
			}
					

					if (i < Registre.NomsRegistres(doc, nsmgr).Count && cmp == NombreMethodesRegistres(doc, nsmgr,i ) - 1) {
			xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][3]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][4]/ following-sibling::w:p  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + (i +1)+ "]/preceding-sibling:: w:p )= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + (i+1)+ "]/preceding-sibling:: w:p)]";

			}
		nodeList2 = root.SelectNodes(xpath, nsmgr);
			StringBuilder res = new StringBuilder();
			foreach (XmlNode isbn2 in nodeList2)
			{

				 res.Append(isbn2.InnerText + "\r\n");
			}
			

			return res.ToString();
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
			StringBuilder res = new StringBuilder();
					foreach (XmlNode isbn2 in nodeList2)
					{

				res.Append(isbn2.InnerText + "\r\n");
					}


			return res.ToString();


		}



		#endregion
	}
}
