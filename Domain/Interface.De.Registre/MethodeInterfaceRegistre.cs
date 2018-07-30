using ConsoleApp4.Domain.Interface.De.Registre;
using System.Collections.Generic;
using System.Xml;

namespace ConsoleApp4.Domain.CommonType.Services_Externes
{
	public class MethodeInterfaceRegistre
	{
		#region Attributs 

		public string Nom;
		public string Description;
		public List<ParametreInterfaceRegistre> ParametresInterfaceRegistre;
		public List<TypeRetourInterfaceRegistre> TypeRetourInterfacesRegistres;

		#endregion

		#region Constructeur 

		public MethodeInterfaceRegistre(string nom, string description, List<ParametreInterfaceRegistre> parametresInterfaceRegistre, List<TypeRetourInterfaceRegistre> typeRetourInterfacesRegistres)
		{
			this.Nom = nom;
			this.Description = description;
			this.ParametresInterfaceRegistre = parametresInterfaceRegistre;
			this.TypeRetourInterfacesRegistres = typeRetourInterfacesRegistres;

		}

		#endregion

		#region Méthodes 

		public override string ToString()
		{
			return (this.Nom + this.Description);
		}

		/// <summary>
		/// Retourne la liste des noms des méthodes des interfaces de registre présentes dans le fichier
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<string> NomsMethodesInterfacesRegistres(XmlDocument doc, XmlNamespaceManager nsmgr,int i )
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<string> MethodesInterfacesRegistres = new List<string>();

			
				string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/ following-sibling::w:p [ w:pPr / w:pStyle [@w:val='Heading5']]  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][2]/preceding-sibling:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']] )= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][2]/preceding-sibling:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']])]";

				nodeList2 = root.SelectNodes(xpath, nsmgr);

				foreach (XmlNode isbn2 in nodeList2)
				{
					MethodesInterfacesRegistres.Add(isbn2.InnerText);
				}
			
			return MethodesInterfacesRegistres;


		}



		/// <summary>
		/// Retourne la liste des descriptions des méthodes des interfaces de registre présentes dans le fichier
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<string> DescriptionsMethodesinterfacesRegistres(XmlDocument doc, XmlNamespaceManager nsmgr,int i )
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<string> MethodesInterfacesRegistres = new List<string>();

				for (int cmp = 0; cmp < NombreMethodesInterfacesRegistres(doc, nsmgr,i - 1) + 1; cmp++)
				{
					string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][1]/ following-sibling::w:p  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][2]/preceding-sibling:: w:p )= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][2]/preceding-sibling:: w:p)]";

					nodeList2 = root.SelectNodes(xpath, nsmgr);

					foreach (XmlNode isbn2 in nodeList2)
					{
						MethodesInterfacesRegistres.Add(isbn2.InnerText);
					}
					

				}
			
			return MethodesInterfacesRegistres;


		}

		/// <summary>
		/// Retourne le nombre de methodes de chaque interface de registre 
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static int NombreMethodesInterfacesRegistres(XmlDocument doc, XmlNamespaceManager nsmgr,int i)
		{

			return NomsMethodesInterfacesRegistres(doc,nsmgr,i).Count;
		}



		/// <summary>
		/// Fonction qui renvoie la liste de toutes les méthodes des interfaces de registre 
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static MethodeInterfaceRegistre MethodesRegistres(XmlDocument doc, XmlNamespaceManager nsmgr,int i,int cmp  )
		{

				List<string> nomsMethodes = NomsMethodesInterfacesRegistres(doc, nsmgr,i-1);
				List<string> descriptionsMethodes = DescriptionsMethodesinterfacesRegistres(doc, nsmgr,i-1);

				List<ParametreInterfaceRegistre> parametres = ParametreInterfaceRegistre.ParametresMethodesInterfacesRegistres(doc, nsmgr, i, cmp);
				List<TypeRetourInterfaceRegistre> typesRetour = TypeRetourInterfaceRegistre.TypeRetourMethodesInterfacesRegistres(doc, nsmgr, i, cmp);
			
			return (new MethodeInterfaceRegistre(nomsMethodes[cmp], descriptionsMethodes[cmp], parametres, typesRetour));

		}
		#endregion

	}
}