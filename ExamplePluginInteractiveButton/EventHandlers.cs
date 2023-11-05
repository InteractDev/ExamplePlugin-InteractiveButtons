using Exiled.API.Features;
using Exiled.API.Features.Pickups;
using Exiled.API.Features.Toys;
using Exiled.Events.EventArgs.Player;
using InteractiveButtons.API.Events.EventArgs;
using InteractiveButtons.API.Events.Handlers;
using InteractiveButtons.Component;
using MEC;
using UnityEngine;

namespace ExamplePluginInteractiveButton
{
    public class EventHandlers
    {
        public void OnRoundStart()
        {
            // CreateInteractiveButton(PickupItemType, SpawnRoom, ButtonId, ItemPickupTime = 1f, PickupHasGravity = true, PickupCanCollideWithOtherItems = true, ItemSpawnOffset = Vector3.zero, ItemScale = Vector3.one, ItemRotation = Quaternion.Euler(0, 0, 0))
            InteractiveButtons.API.Features.Create.CreateInteractiveButton(ItemType.Coin, Exiled.API.Enums.RoomType.EzGateA, 1, 2f, false, true, new Vector3(0, 1, 0), new Vector3(2, 2, 2), Quaternion.Euler(0, 0, 0));
            // CreateInteractiveButton(PickupItemType, SpawnRoom, ButtonTextId, ItemPickupTime = 1f, PickupHasGravity = true, PickupCanCollideWithOtherItems = true, ItemSpawnOffset = Vector3.zero, ItemScale = Vector3.one, ItemRotation = Quaternion.Euler(0, 0, 0))
            InteractiveButtons.API.Features.Create.CreateInteractiveButton(ItemType.KeycardScientist, Exiled.API.Enums.RoomType.EzGateB, "One", 5f, false, false, new Vector3(0, 2, 0), new Vector3(3, 3, 3), Quaternion.Euler(90, 0, 0));       
        }

        public void ButtonInteracted(ButtonInteractedEventArgs ev)
        {
            if(ev.InteractiveButton.IsUsingTextID)
            {
                if(ev.InteractiveButton.TextID == "One")
                {
                    ev.Player.Kill("One");
                }
            }
            else
            {
                if (ev.InteractiveButton.ID == 1)
                {
                    ev.Player.Kill("1");
                }
            }
        }

        public void ButtonCreated(ButtonCreatedEventArgs ev)
        {
            if (ev.InteractiveButton.IsUsingTextID)
            {
                if(ev.InteractiveButton.TextID == "One")
                {
                    PluginAPI.Core.Log.Debug($"I'm the first one!");
                }
                else
                {
                    PluginAPI.Core.Log.Debug($"I'm {ev.InteractiveButton.TextID}!");
                }
            }
            else
            {
                if (ev.InteractiveButton.ID == 1)
                {
                    PluginAPI.Core.Log.Debug("I'm number 1!");
                }
                else
                {
                    PluginAPI.Core.Log.Debug($"I'm {ev.InteractiveButton.ID}!");

                }
            }
        }
    }
}