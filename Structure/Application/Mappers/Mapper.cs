using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp4.Application.Mappers
{/// <summary>
 /// Classe qui permet de récupérer la liste des mappers 
 /// </summary>
	class Mapper
	{
		#region Attributs

		public string Nom { get; private set; }
		public string Description { get; private set; }
		public List<MethodeMapper> Methodes { get; private set; }

		#endregion


		#region Constructeur
		public Mapper(string nom, string description,  List<MethodeMapper> methodes)
		{
			this.Nom = nom;
			this.Description = description;
			this.Methodes = methodes;
		}
		public Mapper(string nom, string description)
		{
			this.Nom = nom;
			this.Description = description;

		}


		#endregion


		#region Méthodes 

		public override string ToString()
		{
			var doc = "/// <summary>" + "\r\n" + "/// " + this.Description.Trim() + "." + "\r\n" + "/// </summary>" + "\r\n";
			StringBuilder methodes = new StringBuilder();
			foreach (MethodeMapper m in this.Methodes)
			{
				methodes.Append("\r\n");


				methodes.Append(m.ToString() + "\r\n");

			}
			var res = doc + "\r\n" + "public static class " + this.Nom  + "\r\n" + "#region Méthodes " + "{ " + "\r\n" + methodes.ToString() + "\r\n" + "#endregion" + "\r\n" + "}";

			return res;
		}
		/// <summary>
		/// Retourne une liste de noms des mappers présents dans le fichier
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<string> NomsMappers(XmlDocument doc, XmlNamespaceManager nsmgr)
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<string> ListeNoms = new List<string>();
			string xpath = @"//w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6]/following:: w:p[ w:pPr / w:pStyle [@w:val='Heading2']][2]/following-sibling:: w:p[ w:pPr / w:pStyle [@w:val='Heading3']]
				[count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][7]/ preceding-sibling::w:p [ w:pPr / w:pStyle [@w:val='Heading3']])= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][7]/preceding-sibling::w:p  [ w:pPr / w:pStyle [@w:val='Heading3']])]";

			nodeList2 = root.SelectNodes(xpath, nsmgr);

			foreach (XmlNode isbn2 in nodeList2)
			{
				ListeNoms.Add(isbn2.InnerText);
			}

			return ListeNoms;


		}

		/// <summary>
		/// Fonction qui retourne la liste des descriptions des mappers  
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static string DescriptionsMapper(XmlDocument doc, XmlNamespaceManager nsmgr,int i )
		{
			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			

				string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][1] / following-sibling::w:p [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/ preceding-sibling::w:p)= count(w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/preceding-sibling::w:p)]";

				nodeList2 = root.SelectNodes(xpath, nsmgr);
			StringBuilder res = new StringBuilder();
				foreach (XmlNode isbn2 in nodeList2)
				{
					res.Append(isbn2.InnerText);
				}

			
			return res.ToString();


		}

	


		/// <summary>
		/// Retourne la liste des mappers du fichier  
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<Mapper> Mappers(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			List<Mapper> services = new List<Mapper>();
			List<string> noms = NomsMappers(doc, nsmgr);
		
			
			for (int i = 1; i < NomsMappers(doc, nsmgr).Count + 1; i++)
			{
				List<MethodeMapper> methodes = MethodeMapper.MethodesMappers(doc, nsmgr, i);

				string descriptions = DescriptionsMapper(doc, nsmgr,i);


				if (MethodeMapper.NombreMethodesMappers(doc, nsmgr,i - 1) != 0)
				{

					services.Add(new Mapper(noms[i - 1], descriptions, methodes));
				}

				if (MethodeMapper.NombreMethodesMappers(doc, nsmgr,i - 1) == 0)
				{

					services.Add(new Mapper(noms[i - 1], descriptions));
				}



			}
			return services;

		}





		#endregion
	}
}
