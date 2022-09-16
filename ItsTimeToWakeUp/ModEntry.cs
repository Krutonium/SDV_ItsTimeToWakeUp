using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;
using System;

namespace ItsTimeToWakeUp
{
    public class ModEntry : Mod
    {
        ModConfig config = new ModConfig();
        public override void Entry(IModHelper helper)
        {
            config = Helper.ReadConfig<ModConfig>();
            Helper.Events.GameLoop.DayStarted += GameLoop_DayStarted;
        }

        private void GameLoop_DayStarted(object sender, DayStartedEventArgs e)
        {
            if (!Context.IsWorldReady) return;
            Game1.timeOfDay = config.WakeUpTime;
        }
    }
    public class ModConfig
    {
        public int WakeUpTime = 500;
        public string HowThisWorks = "WakeUpTime should be a value in 24 hour time. Technically you can go as low as you want, even negative numbers, but you should not go past 2 AM (2600).";
    }
}