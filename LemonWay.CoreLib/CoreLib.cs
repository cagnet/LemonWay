﻿using Newtonsoft.Json;
using log4net;
using System;
using System.Diagnostics;
using System.Xml;

namespace LemonWay
{
    public class CoreLib
    {
        // Instance du logger CoreLib
        private static readonly ILog log = LogManager.GetLogger(typeof(CoreLib));

        #region Fibonacci
        /// <summary>
        /// Indique si le calcule en cache à déjà été fait;
        /// </summary>
        private static bool IsBuild = false;
        /// <summary>
        /// Tableau contenant les 100 premières valeurs calculé de fibonacci (cela évite de devoir refaire le calcule a chaque demande
        /// </summary>
        private static decimal[] FibRes = new decimal[100];

        /// <summary>
        /// Méthode permettant de remplir le cache avec les résultats des 100 premières valeurs de Fibonacci
        /// </summary>
        private static void buildFib()
        {
            log.Debug("Mise en cache des 100 premières valeurs de Fibonacci");
            FibRes[0] = 1;
            FibRes[1] = 1;
            for (int i = 2; i < 100; i++)
            {
                FibRes[i] = FibRes[i - 1] + FibRes[i - 2];
            }
            IsBuild = true;
            log.Debug("Les 100 premières valeurs de Fibonacci sont en cache");
        }

        /// <summary>
        /// Méthode permattant de connaitre la valeur de Fibonacci pour les valeur de 1 à 100
        /// </summary>
        /// <param name="n">Valeur de fibonacci</param>
        /// <returns>Résutat du calcule de Fibonacci si n compris entre 0 et 101 sinon return -1</returns>
        //La valeur de retour a été changée car dans l'ennoncé il est demandé un int hors au dela de 50 la valeur ne tient plus dans un int
        public decimal Fibonacci(int n)
        {
            log.Debug("Appelle de la méthode Fibonacci(" + n + ")");
            if ((1 <= n) & (n <= 100))
            {
                if (!IsBuild)
                    buildFib();
                log.Debug("Résultat:" + FibRes[n - 1]);
                //Le tableur étant indéxé de 0 à 99 pour des valeurs de 1 à 100
                return FibRes[n - 1];
            }
            else
                log.Debug("Résultat:-1");
            return -1;
        }
        #endregion

        #region XmlToJson
        /// <summary>
        /// Méthode servant à convertir un block Xml en text Json
        /// </summary>
        /// <param name="xml">text Xml</param>
        /// <returns>text Json</returns>
        public string XmlToJson(string xml)
        {
            Trace.WriteLine("Appelle de la méthode XmlToJson(" + xml + ")");

            XmlDocument doc = null;
            try
            {
                doc = new XmlDocument();
                doc.LoadXml(xml);
            }
            catch (Exception excp)
            {
                log.Error(string.Format("Une exception de type {0} a levé le message suivant :{1}", excp.GetType().ToString(), excp.Message));
                log.Debug("Résultat:Bad  Xml  format");
                return "Bad  Xml  format";
            }
            string res = JsonConvert.SerializeXmlNode(doc);
            log.Debug("Résultat:" + res);
            return res;
        }
        #endregion

    }
}
