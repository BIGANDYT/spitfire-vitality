using Officecore9x.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Officecore9x.Service.Impl
{
    public class BettingService : IBettingService
    {
        private ArrayList markets = new ArrayList();
        private ArrayList bets = new ArrayList();
        Dictionary<string, List<string>> allbets = new Dictionary<string, List<string>>();

        public ArrayList GetBets(string market)
        {
            if (!String.IsNullOrEmpty(market))
            {
                InitBets();
                DateTime start = DateTime.Today.AddHours(7);
                Random rnd = new Random();
                Random random = new Random();
                List<String> thisBets = allbets[market];
                for (int i = 0; i < thisBets.Count; i++)
                {
                    DateTime value = start.AddMinutes(rnd.Next(241));
                    Bet b = new Bet(market, value.ToString("HH:mm"), thisBets[i], "", random.Next(1, 20) + "/" + random.Next(1, 20), random.Next(1, 20) + "/" + random.Next(1, 20), random.Next(1, 20) + "/" + random.Next(1, 20), random.Next(1, 20) + "+ related bets", new int[] { random.Next(0, 10), random.Next(0, 10), random.Next(0, 10), random.Next(0, 10), random.Next(0, 10) });
                    bets.Add(b);
                }
            }
            return bets;
        }

        private void InitBets()
        {
            List<String> bets = new List<String>();
            bets.Add("Burnley v Tottenham");
            bets.Add("Sunderland v Newcastle");
            bets.Add("Crystal Palace v Man City");
            bets.Add("Aston Villa v QPR");
            bets.Add("Swansea v Everton");
            bets.Add("Southampton v Hull");
            allbets.Add("Football", bets);
            bets = new List<String>();
            bets.Add("Warrington Wolves v Castleford Tigers	");
            bets.Add("St Helens v Hull FC");
            bets.Add("Hull Kingston Rovers v Huddersfield Giants");
            bets.Add("Leeds Rhinos v Wakefield Wildcats");
            bets.Add("Salford Red Devils v Wigan Warriors");
            bets.Add("Parramatta Eels v Wests Tigers");
            allbets.Add("Rugby", bets);
            bets = new List<String>();
            bets.Add("TCM Gaming (UK) v SSOF Gaming (Brazil)");
            bets.Add("Epsilon Esports (UK) v Aztek Gaming (Mexico)");
            bets.Add("TEC Intensity (UK) v Nsp (South Korea)");
            bets.Add("Team Orbit (UK) Immunity (Australia)");
            bets.Add("Vitality Returns (France) VexX Revenge (Canada)");
            bets.Add("Killerfish (Germany) v Echelon (Singapore)");
            allbets.Add("Gaming", bets);
        }
    }
}