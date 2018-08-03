using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp4.Domain.InterfaceServiceExterne
{
	class MethodeInterfaceServiceExterne
	{
		#region Attributs 

		public string Nom;
		public string Description;
		public List<ParametreInterfaceServiceExterne> ParametresInterfaceServiceExterne;
		public TypeRetourInterfaceServiceExterne TypesRetourInterfaceServiceExterne;

		#endregion

		#region Constructeur 

		public MethodeInterfaceServiceExterne(string nom, string description, List<ParametreInterfaceServiceExterne> parametresInterfaceServiceExterne, TypeRetourInterfaceServiceExterne typesRetourInterfaceServiceExterne)
		{
			this.Nom = nom;
			this.Description = description;
			this.ParametresInterfaceServiceExterne = parametresInterfaceServiceExterne;
			this.TypesRetourInterfaceServiceExterne = typesRetourInterfaceServiceExterne;

		}

		#endregion

		#region Méthodes
		public override string ToString()
		{
			var param = "";
			var paramMethode = "(";


			foreach (ParametreInterfaceServiceExterne p in this.ParametresInterfaceServiceExterne)
			{
				param = param + p.ToString() + "\r\n";
				if (p == this.ParametresInterfaceServiceExterne.Last())
				{
					paramMethode = paramMethode + p.Type + p.Nom + " )";
				}
				else
				{
					paramMethode = paramMethode + p.Type + p.Nom + ",";
				}
			}

			var retour = this.TypesRetourInterfaceServiceExterne.Type + "\r\n";

			var doc = "/// <summary>" + "\r\n" + "/// " + this.Description + "." + "\r\n" + "/// </summary>" + "\r\n";
			var res = doc + param + "\n" +  "[OperationContract]" + "\r\n" + "public" + " " + retour + this.Nom + paramMethode + "\r\n" + ";";

			return res;
		}
		/// <summary>
		/// Retourne la liste des noms des méthodes des interfaces de services externes présents dans le fichier
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<string> NomsMethodesInterfaceServiceExterne(XmlDocument doc, XmlNamespaceManager nsmgr,int i )
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<string> MethodesInterfaceServiceExterne = new List<string>();

			string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/ following-sibling::w:p [ w:pPr / w:pStyle [@w:val='Heading4']]  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + (i + 1) + "]/preceding-sibling:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']] )= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + (i + 1) + "]/preceding-sibling:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']])]";


			if (i == InterfaceServiceExterne.NomsInterfacesServicesExternes(doc, nsmgr).Count)
			{

				xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/ following-sibling::w:p [ w:pPr / w:pStyle [@w:val='Heading4']]  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][5]/preceding-sibling:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']] )= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][5] /preceding-sibling:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']])]";
			}

					nodeList2 = root.SelectNodes(xpath, nsmgr);

					foreach (XmlNode isbn2 in nodeList2)
					{
						MethodesInterfaceServiceExterne.Add(isbn2.InnerText);
					}
					
			

			return MethodesInterfaceServiceExterne;


		}

		/// <summary>
		/// Retourne la liste des descriptions des méthodes des interfaces de service externe présentes dans le fichier
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<string> DescriptionsMethodesInterfaceServiceExterne(XmlDocument doc, XmlNamespaceManager nsmgr,int i )
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<string> MethodesInterfaceServiceExterne = new List<string>();


				for (int cmp = 0; cmp < NombreMethodesInterfaceServiceExterne(doc, nsmgr,i - 1) + 1; cmp++)
				{
					string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']]["+(cmp+1)+"]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][1]/ following-sibling::w:p  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][2]/preceding-sibling:: w:p )= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][2]/preceding-sibling:: w:p)]";

					nodeList2 = root.SelectNodes(xpath, nsmgr);

					foreach (XmlNode isbn2 in nodeList2)
					{
						MethodesInterfaceServiceExterne.Add(isbn2.InnerText);
					}
					

				}
			

			return MethodesInterfaceServiceExterne;


		}


		

		/// <summary>
		/// Retourne le nombre de methodes de chaque interface de service externe 
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static int NombreMethodesInterfaceServiceExterne(XmlDocument doc, XmlNamespaceManager nsmgr,int i)
		{
			
			return NomsMethodesInterfaceServiceExterne(doc,nsmgr,i).Count;
		}

		/// <summary>
		/// Fonction qui renvoie la liste de toutes les méthodes des interfaces de de services externes 
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<MethodeInterfaceServiceExterne> MethodeServicesExternes(XmlDocument doc, XmlNamespaceManager nsmgr,int i )
		{
			List<MethodeInterfaceServiceExterne> methodesInterfaceServiceExterne = new List<MethodeInterfaceServiceExterne>();
		
				List<string> nomsMethodes = NomsMethodesInterfaceServiceExterne(doc, nsmgr, i-1);

				if (NombreMethodesInterfaceServiceExterne(doc, nsmgr,i - 1) != 0)
				{
					
					List<string> descriptionsMethodes = DescriptionsMethodesInterfaceServiceExterne(doc, nsmgr,i-1);
					

				for (int cmp = 0; cmp < NombreMethodesInterfaceServiceExterne(doc, nsmgr,i - 1); cmp++)
					{
					List<ParametreInterfaceServiceExterne> parametres = ParametreInterfaceServiceExterne.ParametresMethodesInterfaceServiceExterne(doc, nsmgr, i,cmp);
					TypeRetourInterfaceServiceExterne typesRetour = TypeRetourInterfaceServiceExterne.TypeRetourMethodesInterfaceServiceExterne(doc, nsmgr,i , cmp);

					methodesInterfaceServiceExterne.Add(new MethodeInterfaceServiceExterne(nomsMethodes[cmp], descriptionsMethodes[cmp], parametres, typesRetour));


					}
				

			}
			return methodesInterfaceServiceExterne;

		}

		#endregion
	}
}
