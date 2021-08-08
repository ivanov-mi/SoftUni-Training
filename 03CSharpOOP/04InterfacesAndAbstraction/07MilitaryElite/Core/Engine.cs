namespace MilitaryElite.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Enums;
    using Models;

    public class Engine : IEngine
    {
        private Dictionary<int, ISoldier> soldiers;
        public Engine()
        {
            this.soldiers = new Dictionary<int, ISoldier>();
        }
        public void Run()
        {
            var input = Console.ReadLine();

            while (input?.ToLower() != "end")
            {
                try
                {
                    string[] inputInfo = input
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                    var result = this.Read(inputInfo);

                    Console.WriteLine(result);

                }
                catch (Exception)
                {
                }

                input = Console.ReadLine();
            }
        }

        public string Read(string[] args)
        {
            var soldierType = args[0];
            int id = int.Parse(args[1]);
            var firstName = args[2];
            var lastName = args[3];

            ISoldier soldier = null;
            if (soldierType == "Private")
            {
                var salary = decimal.Parse(args[4], System.Globalization.CultureInfo.InvariantCulture);
                soldier = new Private(id, firstName, lastName, salary);
            }
            else if (soldierType == "LieutenantGeneral")
            {
                var salary = decimal.Parse(args[4], System.Globalization.CultureInfo.InvariantCulture);
                var privates = new Dictionary<int, IPrivate>();

                for (int i = 5; i < args.Length; i++)
                {
                    var soldierId = int.Parse(args[i]);
                    var currentSoldier = (IPrivate)soldiers[soldierId];

                    privates.Add(soldierId, currentSoldier);
                }

                soldier = new LeutenantGeneral(id, firstName, lastName, salary, privates);
            }
            else if (soldierType == "Engineer")
            {
                var salary = decimal.Parse(args[4], System.Globalization.CultureInfo.InvariantCulture);
                bool isValidCorps = Enum.TryParse<Corps>(args[5], out Corps corps);

                if (!isValidCorps)
                {
                    throw new Exception();
                }

                ICollection<IRepair> repairs = new List<IRepair>();

                for (int i = 6; i < args.Length; i += 2)
                {
                    var currentName = args[i];
                    var hours = int.Parse(args[i + 1]);

                    IRepair repair = new Repair(currentName, hours);
                    repairs.Add(repair);
                }

                soldier = new Engineer(id, firstName, lastName, salary, corps, repairs);
            }
            else if (soldierType == "Commando")
            {
                var salary = decimal.Parse(args[4], System.Globalization.CultureInfo.InvariantCulture);
                bool isValidCorps = Enum.TryParse<Corps>(args[5], out Corps corps);

                if (!isValidCorps)
                {
                    throw new Exception();
                }

                ICollection<IMission> missions = new List<IMission>();

                for (int i = 6; i < args.Length; i += 2)
                {
                    var missionName = args[i];
                    var missionState = args[i + 1];

                    bool isValidMissionState = Enum.TryParse<MissionState>(missionState, out MissionState state);

                    if (!isValidMissionState)
                    {
                        continue;
                    }

                    IMission mission = new Mission(missionName, state);
                    missions.Add(mission);
                }

                soldier = new Commando(id, firstName, lastName, salary, corps, missions);
            }
            else if (soldierType == "Spy")
            {
                int codeNumber = int.Parse(args[4]);
                soldier = new Spy(id, firstName, lastName, codeNumber);
            }

            soldiers.Add(id, soldier);

            return soldier.ToString();
        }
    }
}
