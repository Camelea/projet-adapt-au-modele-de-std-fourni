﻿using ConsoleApp4.Domain.Entites;
using System.Collections.Generic;
using System.Xml;

namespace ConsoleApp4.Domain.CommonType.Services_Externes
{
	public class ProprieteDynamique
	{
		#region Attributs 

		private string nom;
		private string type;
		private string description;
		private string get;
		private string set;

		public string Description { get => description; set => description = value; }
		public string Set { get => set; set => set = value; }
		public string Nom { get => nom; set => nom = value; }
		public string Type { get => type; set => type = value; }
		public string Get { get => get; set => get = value; }

		#endregion

		#region Constructeur 

		public ProprieteDynamique(string nom, string description,string type , string get , string set)
		{
			this.Nom = nom;
			this.Type =type;
			this.Description = description;
			this.Get = get;
			this.Set = set;


		}

		#endregion

		#region Méthodes


		/// <summary>
		/// Renvoie la liste des informations de proprietes dynamiques des entitess 
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<List<ProprieteDynamique>> EntitesPartiels(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<List<string>> ListeProprietesDynamiques = new List<List<string>>();
			List<List<ProprieteDynamique>> ProprietesDynamiques = new List<List<ProprieteDynamique>>();
			for (int i = 1; i < Entite.NomsEntites(doc, nsmgr).Count + 1; i++)
			{

				ListeProprietesDynamiques.Add(new List<string>());
				string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][5] / following-sibling::w:tbl/w:tr/w:tc  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1]  /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][6] / preceding-sibling::w:tbl/w:tr/w:tc)= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]  /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][6] / preceding-sibling::w:tbl/w:tr/w:tc)]";


				nodeList2 = root.SelectNodes(xpath, nsmgr);


				foreach (XmlNode isbn2 in nodeList2)
				{

					ListeProprietesDynamiques[i - 1].Add(isbn2.InnerText);

				}
				ProprietesDynamiques.Add(ListeAProprietesDynamiques(ListeProprietesDynamiques[i - 1]));
			}


			return ProprietesDynamiques;

		}



		/// <summary>
		/// Fonction qui prend une liste de string et la transforme en liste de proprietes dynamiques
		/// 
		/// </summary>
		/// <param name="liste"></param>
		/// <returns></returns>
		public static List<ProprieteDynamique> ListeAProprietesDynamiques(List<string> liste)
		{
			List<ProprieteDynamique> ListeProprietesDynamiques = new List<ProprieteDynamique>();
			for (int i = 5; i < liste.Count; i = i + 5)
			{
				ListeProprietesDynamiques.Add(new ProprieteDynamique(liste[i], liste[i + 1], liste[i + 2], liste[i + 2], liste[i + 4]));
			}
			return ListeProprietesDynamiques;
		}


		#endregion
	}
}