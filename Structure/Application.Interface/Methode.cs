using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp4.Application.Interface
{	
	public class Methode
	{
		#region Attributs 

		public string Nom { get; private set; }
		public string Description { get; private set; }
		public List<ParametreInterfaceService> Parametres { get; private set; }
		public TypeRetourInterfaceService TypeRetour { get; private set; }

		#endregion

		#region Constructeur 

		public Methode(string nom, string description, List<ParametreInterfaceService> parametreEntrant, TypeRetourInterfaceService parametreSortant)
		{
			this.Nom = nom;
			this.Description = description;
			this.Parametres = parametreEntrant;
			this.TypeRetour = parametreSortant;

		}

		#endregion

		#region Méthodes 

		public override string ToString()
		{
			StringBuilder param = new StringBuilder();
			StringBuilder paramMethode = new StringBuilder();
			paramMethode.Append ("(");


			foreach (ParametreInterfaceService p in this.Parametres)
			{
				param.Append( p.ToString() + "\r\n");
				if (p == this.Parametres.Last())
				{
					paramMethode = paramMethode.Append(p.Type + p.Nom + " )" + "\r\n");
				}
				else
				{
					paramMethode = paramMethode.Append(p.Type + p.Nom + ",");
				}
			}

			var retour = this.TypeRetour.Type ;

			var doc = "/// <summary>" + "\r\n" + "/// " + this.Description + "." + "\r\n" + "/// </summary>" + "\r\n";
			var res = doc + param.ToString() + this.TypeRetour.ToString() +  "\n" + "[OperationContract]" + "\r\n" + "public" + " " + retour + this.Nom + paramMethode.ToString() + "\r\n" + ";";

			return res;
		}
		/// <summary>
		/// Retourne la liste des noms des méthodes des interfaces de service présentes dans le fichier
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<string> NomsMethodesInterfacesServices(XmlDocument doc, XmlNamespaceManager nsmgr,int i )
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<string> MethodesInterfacesServices = new List<string>();

				string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/ following-sibling::w:p [ w:pPr / w:pStyle [@w:val='Heading5']]  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][2]/preceding-sibling:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']] )= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][2]/preceding-sibling:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']])]";

				nodeList2 = root.SelectNodes(xpath, nsmgr);

				foreach (XmlNode isbn2 in nodeList2)
				{
					MethodesInterfacesServices.Add(isbn2.InnerText);
				}
			
			

			return MethodesInterfacesServices;


		}



		/// <summary>
		/// Retourne la liste des descriptions des méthodes des interfaces de service présentes dans le fichier
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static string DescriptionsMethodesinterfacesService(XmlDocument doc, XmlNamespaceManager nsmgr,int i ,int cmp)
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;

					string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][1]/ following-sibling::w:p  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][2]/preceding-sibling:: w:p )= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][2]/preceding-sibling:: w:p)]";
					var res=""; 
					nodeList2 = root.SelectNodes(xpath, nsmgr);

					foreach (XmlNode isbn2 in nodeList2)
					{
						res=res+(isbn2.InnerText);
					}
				

	
			
			return res;


		}

		/// <summary>
		/// Retourne le nombre de methodes de chaque interface de service 
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static int NombreMethodesInterfacesServices(XmlDocument doc, XmlNamespaceManager nsmgr, int i)
		{

			return NomsMethodesInterfacesServices(doc, nsmgr, i).Count;
		}



		/// <summary>
		/// Fonction qui renvoie la liste de toutes les méthodes des interfaces de service 
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<Methode> Methodes(XmlDocument doc, XmlNamespaceManager nsmgr,int i)
		{
			List<Methode> methodesInterfacesServices = new List<Methode>();
			

				TypeRetourInterfaceService typeRetour = TypeRetourInterfaceService.TypesRetourInterfacesServices(doc, nsmgr,i);
				List<string> nomsMethodes = NomsMethodesInterfacesServices(doc, nsmgr, i-1);
				List<ParametreInterfaceService> parametres = ParametreInterfaceService.ParametresInterfacesServices(doc, nsmgr,i);
			if (NombreMethodesInterfacesServices(doc, nsmgr,i - 1) != 0)
				{
				

					for (int cmp = 0; cmp < NombreMethodesInterfacesServices(doc, nsmgr,i-1); cmp++)
					{
					string descriptionsMethodes = DescriptionsMethodesinterfacesService(doc, nsmgr, i, cmp);

					methodesInterfacesServices.Add(new Methode(nomsMethodes[cmp], descriptionsMethodes, parametres, typeRetour));


					}
					
				}

			return methodesInterfacesServices;
		}





		#endregion

	}
}
