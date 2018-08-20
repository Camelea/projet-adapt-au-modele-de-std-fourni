using ConsoleApp4.Domain.Interface.De.Registre;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace ConsoleApp4.Domain.CommonType.Services_Externes
{
	public class MethodeInterfaceRegistre
	{
		#region Attributs 

		public string Nom { get; private set; }
		public string Description { get; private set; }
		public List<ParametreInterfaceRegistre> ParametresInterfaceRegistre { get; private set; }
		public TypeRetourInterfaceRegistre TypeRetourInterfacesRegistres { get; private set; }

		#endregion

		#region Constructeur 

		public MethodeInterfaceRegistre(string nom, string description, List<ParametreInterfaceRegistre> parametresInterfaceRegistre, TypeRetourInterfaceRegistre typeRetourInterfacesRegistres)
		{
			this.Nom = nom;
			this.Description = description;
			this.ParametresInterfaceRegistre = parametresInterfaceRegistre;
			this.TypeRetourInterfacesRegistres = typeRetourInterfacesRegistres;

		}

		public MethodeInterfaceRegistre(string nom, string description, TypeRetourInterfaceRegistre typeRetourInterfacesRegistres)
		{
			this.Nom = nom;
			this.Description = description;
			this.TypeRetourInterfacesRegistres = typeRetourInterfacesRegistres;

		}

		public MethodeInterfaceRegistre(string nom, string description)
		{
			this.Nom = nom;
			this.Description = description;
			
		}
		public MethodeInterfaceRegistre(string nom, string description, List<ParametreInterfaceRegistre> parametresInterfaceRegistre)
		{
			this.Nom = nom;
			this.Description = description;
			this.ParametresInterfaceRegistre = parametresInterfaceRegistre;
		

		}
		#endregion

		#region Méthodes 

		public override string ToString()
		{
			StringBuilder param = new StringBuilder();
			StringBuilder paramMethode = new StringBuilder();
			paramMethode.Append("(");


			foreach (ParametreInterfaceRegistre p in this.ParametresInterfaceRegistre)
			{
				param.Append(p.ToString() + "\r\n");
				if (p == this.ParametresInterfaceRegistre.Last())
				{
					paramMethode = paramMethode.Append(p.Type + p.Nom + " );");
				}
				else
				{
					paramMethode = paramMethode.Append(p.Type + p.Nom + ",");
				}
			}

			var retour = this.TypeRetourInterfacesRegistres.Type + "\r\n";

			var doc = "/// <summary>" + "\r\n" + "/// " + this.Description + "." + "\r\n" + "/// </summary>" + "\r\n";
			var res = doc + param.ToString() + "\r\n" + this.TypeRetourInterfacesRegistres.ToString() +"\r\n" + "[OperationContract]" + "\r\n" + "public" + " " + retour + this.Nom + " "  + paramMethode.ToString() + "\r\n" + ";";

			return res;
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
		public static string DescriptionsMethodesinterfacesRegistres(XmlDocument doc, XmlNamespaceManager nsmgr,int i,int cmp )
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;

					string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][1]/ following-sibling::w:p  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][2]/preceding-sibling:: w:p )= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][2]/preceding-sibling:: w:p)]";
			StringBuilder res = new StringBuilder();
					nodeList2 = root.SelectNodes(xpath, nsmgr);

					foreach (XmlNode isbn2 in nodeList2)
					{
						res.Append(isbn2.InnerText + "\r\n") ;
					}
					

				
			
			return res.ToString();


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
		public static List<MethodeInterfaceRegistre> MethodesRegistres(XmlDocument doc, XmlNamespaceManager nsmgr, int i)
		{

			List<string> nomsMethodes = NomsMethodesInterfacesRegistres(doc, nsmgr, i);
			List<MethodeInterfaceRegistre> methodesInterfacesRegistres = new List<MethodeInterfaceRegistre>();


			if (NombreMethodesInterfacesRegistres(doc, nsmgr, i) != 0)
			{


				for (int cmp = 0; cmp < NombreMethodesInterfacesRegistres(doc, nsmgr, i); cmp++)
				{
					List<ParametreInterfaceRegistre> parametres = ParametreInterfaceRegistre.ParametresMethodesInterfacesRegistres(doc, nsmgr, i, cmp);
					TypeRetourInterfaceRegistre typesRetour = TypeRetourInterfaceRegistre.TypeRetourMethodesInterfacesRegistres(doc, nsmgr, i, cmp);
					string descriptionsMethodes = DescriptionsMethodesinterfacesRegistres(doc, nsmgr, i, cmp);

					if (typesRetour != null && parametres != null)
					{
						methodesInterfacesRegistres.Add(new MethodeInterfaceRegistre(nomsMethodes[cmp], descriptionsMethodes, parametres, typesRetour));
					}
					else
					{
						if (typesRetour == null && parametres != null)
						{
							methodesInterfacesRegistres.Add(new MethodeInterfaceRegistre(nomsMethodes[cmp], descriptionsMethodes, parametres));
						}
						else
						{
							if (parametres == null && typesRetour != null )
							{
								methodesInterfacesRegistres.Add(new MethodeInterfaceRegistre(nomsMethodes[cmp], descriptionsMethodes, typesRetour));

							}
							else
							{
								methodesInterfacesRegistres.Add(new MethodeInterfaceRegistre(nomsMethodes[cmp], descriptionsMethodes));

							}
						}

					}

				}
			}
				return methodesInterfacesRegistres;
		}
		#endregion

	}
}